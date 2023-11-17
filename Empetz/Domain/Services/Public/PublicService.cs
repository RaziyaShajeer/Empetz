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
	public class PublicService:IPublicService
	{
		private readonly IPublicRepository _publicRepository;

		public PublicService(IPublicRepository publicRepository)
		{
		_publicRepository = publicRepository;
		}
		
		public SystemUser MobleNumberVarification(MoblieNumberVarificationObject moblieNumberVarificationObject)
		{
			return _publicRepository.MobleNumberVarification(moblieNumberVarificationObject);
		}

		public SystemUser register(SystemUser systemuser)
		{
			return _publicRepository.register(systemuser);
		}
		public SystemUser getUserById(Guid userid)
		{
			return _publicRepository.getuserbyId(userid);	
		}
	}
}
