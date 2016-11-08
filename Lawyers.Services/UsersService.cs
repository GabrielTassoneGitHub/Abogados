using Lawyers.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.Contract.Entities;
using Lawyers.DataAccess;
using WebMatrix.WebData;

namespace Lawyers.Services
{
    public class UsersService : IUsers
    {
        public void Create(UserModel Usuario)
        {
            WebSecurity.CreateUserAndAccount(Usuario.Email, Usuario.Password);
            
            /*
            using (LawyersConnection db = new LawyersConnection())
            {
                db.Specializations.Add(new Specialization()
                {
                    SpecializationId = Especializacion.SpecializationId,
                    Name = Especializacion.Name,
                    Description = Especializacion.Description
                });
                db.SaveChanges();
            }*/
        }

        public List<UserModel> UsersList()
        {
            throw new NotImplementedException();
        }
    }
}
