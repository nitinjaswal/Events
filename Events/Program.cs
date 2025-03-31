using System;

public class User
{
    public string Name { get; set; } //User related data
    public string Email { get; set; } //User related data
    public string PhoneNumber { get; set; } //User related data
    public User(string username, string email)
    {
        Name = username;
        Email = email;
    }
}

// Custom event arguments class: To separate the event data from Domain Models(user)
//let say we want to add phone number to User class, then yuo must mdify the User class because phone number is not related to event, it is user-related data.
//Phone number is a core attribute of a user.
//It’s not just for an event; other parts of the app might need it (e.g registration etc.).

//When we use UserEventArgs
//Is the data is evet specific, then it should go into CustomEventArgs class
//Because Logintime and IPAdress are event specific data, they are not core attributes of a user. The CustomEventArgs (like UserEventArgs) provides more flexibility and follows the standard .NET way to handle evnets
public class UserEventArgs : EventArgs
{
    public User User { get; set; }
    public DateTime LoginTime { get; set; } //Event related data
    public string IPAdress { get;set; } //Event related data
    public UserEventArgs(User user, DateTime loginTime)
    {
        User = user;
        LoginTime = loginTime;
    }
}

class Authenticator
{
    //public event Action<User> OnUserLogin; // Declare event delegate
    public  event EventHandler<UserEventArgs> OnUserLogin; //Follows the.NET EventHandler<T> convention

    public void Login(User user)
    {
        Console.WriteLine($"*** {user.Name} *** logged in successfully!");

        // Invoke all subscribed methods
        OnUserLogin?.Invoke(this,new UserEventArgs(user,DateTime.UtcNow));
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

    static void SendEmailNotification(object sender,UserEventArgs e)
    {
        Console.WriteLine($"Sending login email to {e.User.Email} at {e.LoginTime}...");
    }

    static void LogLoginActivity(object sender, UserEventArgs e)
    {
        Console.WriteLine($"Logging login activity for {e.User.Name} at {e.LoginTime}...");
    }

    static void UpdateDatabase(object sender, UserEventArgs e)
    {
        Console.WriteLine($"Updating database for {e.User.Name}'s login at {e.LoginTime}...");
    }
}
