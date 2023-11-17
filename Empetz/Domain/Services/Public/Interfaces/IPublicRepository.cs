using Domain.Models;
using Domain.Services.Public.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Public.Interfaces
{
	public interface IPublicRepository
	{
		public SystemUser MobleNumberVarification(MoblieNumberVarificationObject moblieNumberVarificationObject);

        SystemUser register(SystemUser systemuser);
		SystemUser getuserbyId(Guid userId);
    }
}
