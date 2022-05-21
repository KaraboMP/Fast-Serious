using Betelguese.Database;
using Betelguese.Interfaces;
using Betelguese.Models;

namespace Betelguese.Services
{
    public class UserService : IUser
    {
        private readonly IDatabaseAccess _db;

        public UserService(IDatabaseAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<User>> GetUsers() =>
            _db.LoadData<User, dynamic>("dbo.spUser_GetAll", new { });

        public async Task<User?> GetUser(int id)
        {
            var results = await _db.LoadData<User, dynamic>(
                "dbo.spUser_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(User user) =>
            _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName});

        public Task UpdateUser(User user) =>
            _db.SaveData("dbo.spUser_Update", user);

        public Task DeleteUser(int id) =>
            _db.SaveData("dbo.spUser_Delete", new { Id = id });
    }
}
