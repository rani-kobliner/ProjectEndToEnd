using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Optometrist
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int SpecializationByAge { get; set; }

    public virtual ICollection<PatientsAppointment> PatientsAppointments { get; set; } =
        new List<PatientsAppointment>();

    public virtual ICollection<QueueList> QueueLists { get; set; } = new List<QueueList>();

    public virtual AgeRange SpecializationByAgeNavigation { get; set; } = null!;

    public Optometrist(string id, string firstName, string lastName, string gender,
        int specializationByAge)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        SpecializationByAge = specializationByAge;
    }
}
