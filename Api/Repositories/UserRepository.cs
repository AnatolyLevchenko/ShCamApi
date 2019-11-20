using Api.Entities;
using Dapper;

namespace Api.Repositories
{
    public class UserRepository:DapperBase<User>,IRepository<User>
    {
        public User FindUserByToken(string token)
        {
            using (var connection=Helper.CreateConnection())
            {
                var query = @"select u.* from Tokens t
                                INNER JOIN user u on u.Id=t.UserId where Token=@token";
              return  connection.QuerySingleOrDefault<User>(query,new{@token=token});
            }
        }
    }
}