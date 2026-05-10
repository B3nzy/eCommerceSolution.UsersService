using Dapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dapperDbContext)
    {
        _dbContext = dapperDbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser applicationUser)
    {
        applicationUser.UserId = Guid.NewGuid();

        string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password)";
        int rowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, applicationUser);
        if(rowsAffected == 0)
        {
            return null;
        }

        return applicationUser;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        ApplicationUser? applicationUserFromDB = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new {email, password });

        if(applicationUserFromDB == null)
        {
            return null;
        }
        return applicationUserFromDB;
    }
}
