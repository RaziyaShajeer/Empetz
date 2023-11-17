using Domain.Models;
using Domain.Services.Public.DTOs;
using Domain.Services.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Public
{
	public class PublicRepository : IPublicRepository
	{
		private ApplicationDbContext _context;

		public PublicRepository(ApplicationDbContext context)
		{
			_context = context;
		}
	
		public SystemUser MobleNumberVarification(MoblieNumberVarificationObject moblieNumberVarificationObject)
		{
			SystemUser user = _context.SystemUser.Where(e => e.phone == moblieNumberVarificationObject.phone).FirstOrDefault();
			return user;
		}

		public SystemUser register(SystemUser systemuser)
		{

			systemuser.role = Enums.Role.PublicUser;
			_context.SystemUser.Add(systemuser);
			_context.SaveChanges();


			return systemuser;

			
		}
		public SystemUser getuserbyId(Guid userId) 
		{
			var user=_context.SystemUser.Where(e=>e.id == userId).FirstOrDefault();
			return user;
		}

		
	}
}
