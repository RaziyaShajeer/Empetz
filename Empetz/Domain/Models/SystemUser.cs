using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
	[Table("SystemUser")]
	public class SystemUser
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid id { get; set; }
		[Required]
		public string firstName { get; set; }
		[Required]
		public Role role { get; set; }
		public string? lastName { get; set; }
		[Required]
		public string email { get; set; }
		[Required]
		public string phone { get; set; }	
	}
}
