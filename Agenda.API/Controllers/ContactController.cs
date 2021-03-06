﻿using Agenda.APi.Data;
using Agenda.APi.Dtos;
using Agenda.APi.Helpers;
using Agenda.APi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agenda.APi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepo _repo;
        private readonly IMapper _mapper;

        public ContactController(IContactRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(ContactToRegisterDto contactToRegisterDto)
        {
            contactToRegisterDto.NomeContact = contactToRegisterDto.NomeContact.ToLower();


            var contacttoCreate  = new Contact
            {
               NomeContact = contactToRegisterDto.NomeContact
            };

            var createdCont = await _repo.RegisterContact(contacttoCreate, contactToRegisterDto.NomeContact, contactToRegisterDto.EmailContact, 
                                                          contactToRegisterDto.NumeroContact, contactToRegisterDto.IdEmployee, contactToRegisterDto.DataAniversarioContact);
            return StatusCode(201);
        }
   
        [HttpGet("{myString}")]
        public async Task<IActionResult> GetContactsbyId( string myString)
        {
            // se passar numero retorna true se for string retorna false

            double num;
            bool isNumber = double.TryParse(myString, out num);

            if (isNumber)
            {
                //string is number
                int myInt = int.Parse(myString);

                var user = await _repo.search4Id(myInt);

                var userToReturn = _mapper.Map<IEnumerable<ContactForListDto>>(user);
               return Ok(userToReturn);
            }
            else
            {
                //string is not a number
                var user = await _repo.search(myString.ToLower());

                var userToReturn = _mapper.Map<IEnumerable<ContactForListDto>>(user);

                return Ok(userToReturn);
            }
        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContacto(int id, ContactToUpdateDto contactToUpdateDto)
        {
            var contacfromRepo = await _repo.GetContact(id);

            _mapper.Map(contactToUpdateDto, contacfromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            //return Ok("teste");
            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelContact(int id)
        {
        
           var Rep = await _repo.GetContact(id);
         
            if (Rep != null) {
              _repo.Delete(Rep);

            } else {
               return BadRequest("");
            }

          return Ok();
        }  

    }
}
