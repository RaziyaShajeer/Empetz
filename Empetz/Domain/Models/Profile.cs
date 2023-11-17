using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	[Table("Profile")]
	public class Profile
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid id { get; set; }	
		public string profileName { get; set; }
		public string gender { get; set; }
		public  string? description { get; set; }
		public string? image { get; set; }
		[Required]
		[ForeignKey(nameof(User))]
		public Guid userId { get; set; }
		public virtual SystemUser User { get; set; }


	}
}
