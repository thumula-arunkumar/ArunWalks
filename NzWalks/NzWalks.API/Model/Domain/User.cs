﻿namespace NzWalks.API.Model.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
