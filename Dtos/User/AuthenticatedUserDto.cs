﻿namespace FirstTut.Dtos.User
{
    public class AuthenticatedUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public string? Token { get; set; }
    }

}
