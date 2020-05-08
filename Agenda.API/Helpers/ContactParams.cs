﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.APi.Helpers
{
    public class ContactParams
    {
		private const int MaxPageSize = 50;
		public int PageNumber { get; set; } = 1;

		private int pageSize = 13;

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
		}
		public int UserId { get; set; }
		public string NomeContact { get; set; }

	}
}
