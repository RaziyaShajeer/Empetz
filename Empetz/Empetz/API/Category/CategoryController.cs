using Domain.Models;
using Domain.Services.Public.DTOs;
using Empetz.API.Public.RequestObject;
using Microsoft.AspNetCore.Mvc;

namespace Empetz.API.Category
{
    public class CategoryController : Controller
    {
		[HttpGet]
		[Route("/Categories")]
		public ActionResult ListAllCategories()
		{
			List<PetsCategory> categories = new List<PetsCategory>();
			return Ok(categories);
			
			

		}
		[HttpGet]
		[Route("Categories/{catid}/Breeds")]
		public ActionResult ListAllBreedsByCategory(Guid catid)
		{
			if (catid == null)
			{
				return BadRequest();
			}
	List<PetsCategory> petscategory= new List<PetsCategory>();
			if(petscategory!= null)
			{
				return Ok(petscategory);
			}
			else
			{

				return NoContent();	
			}
			



		}
	}
}
