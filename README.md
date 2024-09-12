# OAuthAuthenticator for Unity

## Overview

`OAuthAuthenticator` is a simple Unity class that handles user authentication via OAuth. It allows users to log in using their username and password, and it manages the storage of access tokens and account IDs.

## Features

- Sends login requests to a specified API endpoint.
- Handles successful and failed login attempts.
- Stores access tokens and account IDs using `PlayerPrefs`.

## Installation

1. Create a new C# script in your Unity project and name it `OAuthAuthenticator.cs`.
2. Copy and paste the code from the `OAuthAuthenticator.cs` section above into your script.
3. Attach the `OAuthAuthenticator` script to a GameObject in your Unity scene.

## Usage

To use the `OAuthAuthenticator`, you can create a simple login manager that calls the `Login` method. Here’s an example:

### LoginManager.cs

```csharp
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public OAuthAuthenticator authenticator;

    public void AttemptLogin(string username, string password)
    {
        authenticator.Login(username, password);
    }
}
