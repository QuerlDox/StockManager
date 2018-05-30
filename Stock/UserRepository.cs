using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class UserRepository : IRepository<User>
    {
        public void Create(User entity)
        {
            
            string insertQuery = @"INSERT INTO [dbo].[Login] ([UserName], [Password]) VALUES  (@UserName, @Password)";
            using (var con = ConnectionFactory.GetConnection()) {
                try
                {
                    con.Execute(insertQuery, new {
                        entity.UserName,
                        entity.Password,
                        entity.Role

                    });
                }
                catch (Exception) {
                    throw;
                }
            }
        }

     
        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
