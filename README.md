# C# Events: Authenticating Users and Notifying Subscribers

## Overview

This repository demonstrates how to effectively use events in C# for user authentication. The `Authenticator` class triggers a `Login` event when a user is successfully authenticated. This event then notifies multiple subscribers (methods) to perform actions such as sending an email, logging the activity, and updating the database.

## What are Events in C#?

Events in C# provide a robust mechanism for implementing the Observer pattern (publisher/subscriber model). Here's a breakdown:

1. Events in C# provide a way to notify multiple method when somehting happens. They are based on delegates and implement the Oberver Pattern (publisher/subscriber model). The publisher is the class that contains the definition of the event and the subscriber is the class that will handle the event. The publisher class decides when to raise the event and the subscriber class decides what to do when the event is raised.
2. Events enable a class or object to notify other classes or objects when something of interest occurs. The class that sends (or raises) the event is called the publisher and the classes that receive (or handle) the event are called subscribers.
3. Events that have no subscribers are never raised.
4. When an event has multiple subscribers, the event handlers are invoked synchronously when an event is raised

## Why Use Events in C#?

1.  **Notification System:** They provide a clean and organized way to notify multiple methods when a specific event occurs.
2.  **Decoupling:** Events promote loose coupling between classes. The publisher class doesn't need to know the implementation details of the subscriber classes. It only needs to know the event's signature and when to raise it. This allows for more maintainable and flexible code.
3.  **GUI Applications:** Events are widely used in GUI applications to handle user interactions, such as button clicks or form submissions.

## Example Scenario: User Authentication

This repository focuses on a user authentication scenario. When a user successfully logs in:

* An email is sent to the user.
* The login activity is logged.
* The user's login status is updated in the database.

Events make it easy to add or modify these actions without changing the core authentication logic.

## Resources
*https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/*


