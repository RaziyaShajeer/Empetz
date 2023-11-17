using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	//[Table("PublicUser")]
	public class PublicUser : SystemUser
	{
		//[Key]
		//[Required]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public Guid id { get; set; }
		//[Required]
		//[ForeignKey(nameof(User))]
		//public Guid SystemUserId { get; set; }
		//public virtual SystemUser User { get; set; }
	}
}
