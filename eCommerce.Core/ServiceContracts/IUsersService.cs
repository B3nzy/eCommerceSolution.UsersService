using eCommerce.Core.DTOs;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Interface for the Users Service, which defines the contract for user-related business logic operations. This interface includes methods for user authentication (login) and user registration. The implementation of this interface will handle the business logic for these operations, such as validating user credentials, creating new user accounts, and generating authentication tokens if necessary.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to authenticate a user based on their login credentials. It takes a LoginRequest object as input, which contains the user's email and password. The method returns an AuthenticationResponse object that includes information about the authentication result, such as whether the login was successful, any error messages, and potentially a JWT token for authenticated sessions. If the login fails, the response will indicate the failure and provide relevant error details.
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    /// <summary>
    /// Method to register a new user in the system. It takes a RegisterRequest object as input, which contains the necessary information for creating a new user account, such as email, password, and other relevant details. The method returns an AuthenticationResponse object that indicates the result of the registration process, including whether the registration was successful, any error messages, and potentially a JWT token for authenticated sessions if the registration is successful. If the registration fails, the response will indicate the failure and provide relevant error details.
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    /// <summary>
    /// Method to check if a user exists in the system based on their unique identifier (userId). It takes a Guid representing the user's ID as input and returns a boolean value indicating whether a user with the specified ID exists in the system. This method can be used to validate user existence before performing operations that require a valid user, such as updating user information or assigning roles. If the user exists, it returns true; otherwise, it returns false.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<bool> UserByIdExistsAsync(Guid userId);
}
