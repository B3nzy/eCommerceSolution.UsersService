using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser applicationUser)
    {
        applicationUser.UserId = Guid.NewGuid();
        return applicationUser;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        ApplicationUser applicationUser = new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "John Doe",
            Gender = GenderOptions.Male.ToString()
        };

        return applicationUser;
    }
}
