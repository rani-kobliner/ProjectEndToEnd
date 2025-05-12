using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Patient
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthdayDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Hmo { get; set; } = null!;

    public DateOnly? LastVisit { get; set; }

    public virtual ICollection<PatientsAppointment> PatientsAppointments 
    { get; set; } = new List<PatientsAppointment>();

    public Patient(string id ,string firstName ,string lastName , DateOnly birthdayDate , 
        string gender ,string hmo , DateOnly lastVisit)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthdayDate = birthdayDate;
        Gender = gender;
        Hmo = hmo;
        LastVisit = lastVisit;
    }
}
