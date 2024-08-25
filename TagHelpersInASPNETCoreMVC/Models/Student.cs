﻿namespace TagHelpersInASPNETCoreMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Branch? Branch { get; set; }
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBorth { get; set; }
    }
}
