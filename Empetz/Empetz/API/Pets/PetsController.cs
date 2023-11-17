using Domain.Models;
using Empetz.API.Pets.RequestObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empetz.API.Pets
{
	[Route("api/[controller]")]
	[ApiController]
	public class PetsController : ControllerBase
	{
		[HttpGet]
		[Route("Pets/{breedid}/Pets")]
		public ActionResult ListAllCategories(Guid breedid)
		{
			if (breedid == null)
			{
				return BadRequest();
			}
			List<Pet> petsByBreed = new List<Pet>();
			
			if(petsByBreed==null)
			{
				return NoContent();
			}
			else
			{
				return Ok(petsByBreed);
			}
		
		}
		[HttpGet]
		[Route("Pets/{petid}/Pet")]
		public ActionResult selectPet(Guid petid)
		{
			if (petid == null)
			{
				return BadRequest();
			}
			Pet selectpet=new Pet();
			if (selectpet == null)
			{
				return NoContent();
			}
			
				return Ok(selectpet);
			

		}
		[HttpPost]
		[Route("Pets/Addpet")]
		public ActionResult addpet(PetPost pet)
		{
			if (pet.Image == null)
			{
				return BadRequest();
			}
			if(pet.Discription==null)
			{
				return BadRequest();

			}
			if(pet.PetsCategoryId==null)
			{
				return BadRequest();	
			}
			if(pet.UserId==null)
			{
				return BadRequest();	
			}
			return Ok();

		}
	}
}


