using Domain.DataAccess.Repository;
using Domain.DataModel;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository<User> _repository;

        public UserRepository(IBaseRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> GetAsync(int id)
        {
            var sql = "SELECT * FROM portal_users WHERE id=:id";
            return await _repository.QueryFirstOrDefaultAsync(sql, new { id });
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            var sql = "SELECT * FROM portal_users WHERE username=:username";
            return await _repository.QueryFirstOrDefaultAsync(sql, new { username });
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            var sql = "SELECT * FROM portal_users ";
            return await _repository.QueryAsync(sql);
        }
        public async Task<int> CreateAsync(User model)
        {
            var sql = "INSERT INTO portal_users (Username) VALUES (:username)";
            return await _repository.ExecuteAsync(sql, new { model.Username });
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE portal_users WHERE Id=:id";
            return await _repository.ExecuteAsync(sql, new { id });
        }

    }
}
