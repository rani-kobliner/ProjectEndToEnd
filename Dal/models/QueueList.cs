using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class QueueList
{
    private static int _currentId = 0;
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public TimeOnly Hour { get; set; }

    public bool Available { get; set; }

    public string OptometrisId { get; set; } = null!;

    public virtual Optometrist Optometris { get; set; } = null!;

    public QueueList( DateOnly date, TimeOnly hour, bool available,
        string optometrisId)
    {
        Id = _currentId++;
        Date = date;
        Hour = hour;
        Available = available;
        OptometrisId = optometrisId;
    }

    public static void ResetId()
    {
        _currentId = 0;
    }

}
