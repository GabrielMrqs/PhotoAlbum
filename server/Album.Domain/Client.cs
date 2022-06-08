﻿using Shared.Domain;

namespace Albums.Domain
{
    public class Client : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Album? Album { get; set; }

        public Client()
        {
            Album = new();
        }

    }
}