﻿using Agenda.API.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.APi.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

        }
        public static void AddPagination(this HttpResponse response, int currentPage, int ItemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, ItemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination",
                        JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
