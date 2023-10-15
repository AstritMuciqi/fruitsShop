using FruitsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsShop.Data
{
    public interface IUserRepository
    {
        ApplicationUser Create(ApplicationUser users);
        ApplicationUser GetByEmail(string email);
        ApplicationUser GetById(string id);

    }
}
