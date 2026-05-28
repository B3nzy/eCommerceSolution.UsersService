using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Interface for the Users Repository, which defines the contract for user-related data operations. This interface includes methods for adding a new user and retrieving a user based on their email and password. The implementation of this interface will handle the actual database interactions to perform these operations.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a new user to the database. It takes an ApplicationUser object as input and returns the added user with its generated UserId. If the operation fails, it returns null.
    /// </summary>
    /// <param name="applicationUser"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser applicationUser);
    /// <summary>
    /// Method to retrieve a user from the database based on their email and password. It takes an email and password as input and returns the corresponding ApplicationUser object if a match is found. If no match is found, it returns null.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    /// <summary>
    /// Method to retrieve a user from the database based on their unique identifier (UserId). It takes a userId as input and returns the corresponding ApplicationUser object if a match is found. If no match is found, it returns null.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserById(Guid? userId);
}
