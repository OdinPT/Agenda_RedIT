﻿using Agenda.APi.Dtos;
using Agenda.APi.Helpers;
using Agenda.APi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.APi.Data
{
    public interface IContactRepo
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        //Task <IEnumerable<Contact>> Getcontacts();

        Task<IEnumerable<Contact>> Getcontacts();

        Task<Contact> GetContact(int id);
        //Task<Contact> GetContactx(int name);

        Task<IEnumerable<Contact>> search(string name);

        Task<IEnumerable<Contact>> search4Id(int id);

        Task<Contact> RegisterContact(Contact con, string NomeContact, string EmailContact, string NumeroContact, 
                                            int IdEmployee, string DataAniversarioContact);
        Task<IEnumerable<Nota>> GetNotas(int id);

        Task<Nota> RegisterNotas(Nota con, string TituloNota, string DescNota, int Id_Func);

        Task<Nota> GetNota(int id);

        Task<IEnumerable<Nota>> searchNota(string name);
    }
}
