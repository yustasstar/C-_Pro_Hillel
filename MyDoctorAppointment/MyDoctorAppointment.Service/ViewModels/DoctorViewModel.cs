﻿namespace MyDoctorAppointment.Service.ViewModels
{
    public class DoctorViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }
    }
}