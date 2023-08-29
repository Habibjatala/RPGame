﻿namespace FirstTut.Models
{
    public class User
    { 
        public int Id { get; set; }
        public string Name  { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long Phone { get; set; }

        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; }= new byte[0];

        public List<Character>? Characters  { get; set; }  
    }
}
