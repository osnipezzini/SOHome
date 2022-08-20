using System;
using SOHome.Common.Models;

namespace SOHome.Common.DataModels
{
	public class ExpenseModel
	{
		public ExpenseModel()
		{
		}

        public string Name { get; set; }
        public DocumentType DocType { get; set; }
    }
}

