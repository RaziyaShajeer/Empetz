using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	[Table("ReportedPost")]
	public class ReportedPost
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required]
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		[Required]
		[ForeignKey(nameof(Pet))]
		public Guid PetId { get; set; }
		[Required]
		public string Reason { get; set; }
		public virtual Pet Pet { get; set; }
		public virtual PublicUser User { get; set; }
	}
}
