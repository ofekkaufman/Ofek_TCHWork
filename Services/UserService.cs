using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace Ofek_List.Services;

public class UserService
{
    private const string StorageKey = "Ofek_List_Users";
    private const int Iterations = 100_000;

    private class StoredUser
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Username { get; set; } = "";
        public string Salt { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }

    private List<StoredUser> GetUsers()
    {
        string json = Preferences.Default.Get(StorageKey, "[]");

        return JsonSerializer.Deserialize<List<StoredUser>>(json)
               ?? new List<StoredUser>();
    }

    private void SaveUsers(List<StoredUser> users)
    {
        string json = JsonSerializer.Serialize(users);
        Preferences.Default.Set(StorageKey, json);
    }

    public bool Register(
        string name,
        string email,
        string username,
        string password,
        out string message)
    {
        List<StoredUser> users = GetUsers();

        if (users.Any(u =>
            u.Username.Equals(
                username, StringComparison.OrdinalIgnoreCase)))
        {
            message = "This username already exists.";
            return false;
        }

        if (users.Any(u =>
            u.Email.Equals(
                email, StringComparison.OrdinalIgnoreCase)))
        {
            message = "This email is already registered.";
            return false;
        }

        byte[] salt = RandomNumberGenerator.GetBytes(16);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            32);

        users.Add(new StoredUser
        {
            Name = name,
            Email = email,
            Username = username,
            Salt = Convert.ToBase64String(salt),
            PasswordHash = Convert.ToBase64String(hash)
        });

        SaveUsers(users);

        message = "Your account was created successfully.";
        return true;
    }

    public bool Login(
        string usernameOrEmail,
        string password,
        out string message)
    {
        List<StoredUser> users = GetUsers();

        StoredUser? user = users.FirstOrDefault(u =>
            u.Username.Equals(
                usernameOrEmail,
                StringComparison.OrdinalIgnoreCase)
            ||
            u.Email.Equals(
                usernameOrEmail,
                StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            message = "User not found. Please register first.";
            return false;
        }

        byte[] salt = Convert.FromBase64String(user.Salt);

        byte[] enteredHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            32);

        byte[] savedHash =
            Convert.FromBase64String(user.PasswordHash);

        if (!CryptographicOperations.FixedTimeEquals(
            enteredHash, savedHash))
        {
            message = "Incorrect password.";
            return false;
        }

        message = $"Welcome back, {user.Name}!";
        return true;
    }
}
