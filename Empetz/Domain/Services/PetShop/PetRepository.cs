using Domain.Models;
using Domain.Services.PetShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.PetShop
{
	public class PetRepository:IPetRepository
	{

		ApplicationDbContext _context;

		public PetRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public Pet getPetbyId(Guid petId)
		{
			var pet = _context.Pet.Where(e => e.PetId == petId).FirstOrDefault();
			return pet;
		}
	}
}
