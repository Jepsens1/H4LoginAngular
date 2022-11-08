﻿namespace H4LoginAPI.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public User(string username, string password, string salt)
        {
            Username = username;
            Password = password;
            Salt = salt;
        }
    }
}
