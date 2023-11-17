using Domain.Services.PetShop.Interfaces;
using Domain.Services.Public.Interfaces;
using Empetz.API.User.RequestObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Empetz.API.User
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IPetRepository _petRepository { get; set; }
		IPublicService _publicService { get; set; }	
		public UserController(IPetRepository petrepository,IPublicService publicservice)
		{
			petrepository = _petRepository;
			publicservice = _publicService;

			
			
		}

		[HttpPost]
		[Route("wishlist/add")]
		public ActionResult AddtoWishlist(Wishlistrequest wishlist)
		{
			if(wishlist.UserId == null || wishlist.PetId == null)
			{
				return BadRequest();

			}
			var pet=_petRepository.getPetbyId(wishlist.PetId);	
			if(pet==null)
			{
				return BadRequest();
			}
			var user= _publicService.getuserbyId(wishlist.UserId);
			if(user==null)
			{
				return BadRequest();

			}
			return Ok();

			
		}
		[HttpPost]
		[Route("users/{userId}/wishlist")]
		public ActionResult ViewWishlist(Guid userId)
		{
			if ( userId == null)
			{
				return BadRequest();

			}
			
			
			var user = _publicService.getuserbyId(userId);
			if (user == null)
			{
				return BadRequest();

			}
			return Ok();


		}
	}
}
}
