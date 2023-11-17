using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	[Table("Pet")]
	public class Pet
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid PetId { get; set; }
		[Required]
		public string Name { get; set; }
	
		[ForeignKey(nameof(Breed))]
		public Guid  Breedid{ get; set; }
	
		public int Age { get; set;}
	
		public string Gender { get; set;}
		[Required]
		public string Discription { get; set; }
		[Required]
		[ForeignKey(nameof(PetsCategory))]
		public Guid PetsCategoryId { get; set; }
		[Required]
		public string? Image {  get; set; }
		[Required]
		[ForeignKey(nameof(User))]
		
		public Guid UserId { get; set;}
		[ForeignKey(nameof(Location))]
		public Guid Loacationid { get; set;}	

		//navigation properties
		public virtual PetsCategory PetsCategory { get; set; }
		public virtual PublicUser User { get; set; }
		public virtual Breed Breed { get; set; }
		public virtual Location Location { get; set; }	

	}
}
