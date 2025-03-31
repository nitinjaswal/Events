using System;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public User(string username, string email)
    {
        Name = username;
        Email = email;
    }
}

class Authenticator
{
    public event Action<User> OnUserLogin; // Declare event delegate

    public void Login(User user)
    {
        Console.WriteLine($"*** {user.Name} *** logged in successfully!");

        // Invoke all subscribed methods
        OnUserLogin?.Invoke(user);
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of Authenticator
        var auth = new Authenticator();

        //Subscribe event handlers (methods that will be called when.Invoke() runs):
        //Registering multiple event handlers that executes on user login
        auth.OnUserLogin += SendEmailNotification;
        auth.OnUserLogin += LogLoginActivity;
        auth.OnUserLogin+=UpdateDatabase;

        // Call Login method" and it will trigger Invoke
        // Creating a user
        var user = new User("NitinJaswal", "nitinjaswal@gmail.com");

        // Calling the Login method
        auth.Login(user);
    }

    static void SendEmailNotification(User user)
    {
        Console.WriteLine($"Sending login email to {user.Email}...");
    }

    static void LogLoginActivity(User user)
    {
        Console.WriteLine($"Logging login activity for {user.Name}...");
    }

    static void UpdateDatabase(User user)
    {
        Console.WriteLine($"Updating database for {user.Name}'s login...");
    }
}
