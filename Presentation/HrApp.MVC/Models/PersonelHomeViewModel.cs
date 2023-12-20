﻿namespace HrApp.MVC.Models
{
    public class PersonelHomeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public string? SecondSurname { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
    }
}
