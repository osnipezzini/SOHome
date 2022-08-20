using System;
using System.ComponentModel.DataAnnotations;

namespace SOHome.Common.Models
{
	public enum EntryType
	{
		[Display(Name = "Despesa")]
		Expense,
		[Display(Name = "Doacao")]
		Donation,
		[Display(Name = "Entrada")]
		Income
	}
}

