using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class PatientsAppointment
{
    public int Id { get; set; }

    public string PatientCode { get; set; } = null!;

    public string OptometristCode { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly Hour { get; set; }

    public virtual Optometrist OptometristCodeNavigation { get; set; } = null!;

    public virtual Patient PatientCodeNavigation { get; set; } = null!;

    public PatientsAppointment(int id, string patientCode, string optometristCode,
        DateOnly date, TimeOnly hour)
    {
        Id = id;
        PatientCode = patientCode;
        OptometristCode = optometristCode;
        Date = date;
        Hour = hour;
    }
}
