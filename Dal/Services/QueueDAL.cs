using Dal.Api;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class QueueDAL : IQueue
    {
        private readonly dbClass _context;

        public QueueDAL(dbClass context)
        {
            _context = context;
        }

        public void FillQueueList(string optometristId, bool available)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);

            List<DateOnly> holidays = new List<DateOnly>
        {

            new DateOnly(2025, 3, 12), // ערב פורים
            new DateOnly(2025, 3, 13), // פורים
            new DateOnly(2025, 3, 14), //דמוקפין פורים
            new DateOnly(2025, 4, 11), // ערב פסח
            new DateOnly(2025, 4, 12), // פסח יום א'
            new DateOnly(2025, 4, 13), // פסח יום ב'
            new DateOnly(2025, 4, 14), // פסח יום ג'
            new DateOnly(2025, 4, 15), // פסח יום ד'
            new DateOnly(2025, 4, 16), // פסח יום ה'
            new DateOnly(2025, 4, 17), // ערב שביעי של פסח
            new DateOnly(2025, 4, 18), // שביעי של פסח
            new DateOnly(2025, 5, 1),  // יום העצמאות
            new DateOnly(2025, 5, 31), // ערב שבועות
            new DateOnly(2025, 6, 1),  // שבועות
            new DateOnly(2025, 8, 4),  // ערב תשעה באב
            new DateOnly(2025, 8, 5),  // תשעה באב
            new DateOnly(2025, 10, 2), // ערב ראש השנה
            new DateOnly(2025, 10, 3), // ראש השנה יום א'
            new DateOnly(2025, 10, 4), // ראש השנה יום ב'
            new DateOnly(2025, 10, 11),// ערב יום כיפור
            new DateOnly(2025, 10, 12),// יום כיפור
            new DateOnly(2025, 10, 16),// ערב סוכות
            new DateOnly(2025, 10, 17),// סוכות יום א'
            new DateOnly(2025, 10, 18),// סוכות יום ב'
            new DateOnly(2025, 10, 19),// סוכות יום ג'
            new DateOnly(2025, 10, 20),// סוכות יום ד'
            new DateOnly(2025, 10, 21),// סוכות יום ה'
            new DateOnly(2025, 10, 22),// ערב שמחת תורה
            new DateOnly(2025, 10, 23),// שמחת תורה
        };

            // מחק תורים קיימים עבור האופטומטריסט אם נדרש
            var existingQueues = _context.QueueLists.Where(q => q.OptometrisId == optometristId).ToList();
            if (existingQueues.Any())
            {
                _context.QueueLists.RemoveRange(existingQueues);
            }

            TimeOnly workStart = new TimeOnly(9, 0);
            TimeOnly workEnd = new TimeOnly(19, 0);
            TimeOnly breakStart = new TimeOnly(14, 0);
            TimeOnly breakEnd = new TimeOnly(16, 0);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Friday ||
                    holidays.Contains(DateOnly.FromDateTime(date)))
                {
                    continue;
                }

                for (TimeOnly time = workStart; time < workEnd; time = time.AddMinutes(30))
                {
                    if (time >= breakStart && time < breakEnd)
                    {
                        continue;
                    }

                    QueueList queue = new QueueList(
                        DateOnly.FromDateTime(date),
                        time,
                        available,
                        optometristId
                    );

                    _context.QueueLists.Add(queue);
                   
                }
            }
            _context.SaveChanges();
        }

        public void AddQueue(string patientCode, DateOnly date, TimeOnly hour, string optometristCode)
        {
            var queueItem = _context.QueueLists.FirstOrDefault(q =>
             q.Date == date &&
             q.Hour == hour &&
             q.OptometrisId == optometristCode);

            if (queueItem == null)
                throw new InvalidOperationException("לא נמצא תור פנוי בתאריך ושעה אלו");

            var appointment = new PatientsAppointment(
             id: 0,
             patientCode: patientCode,
             optometristCode: optometristCode,
             date: date,
             hour: hour
             );

            queueItem.Available = true;

            _context.PatientsAppointments.Add(appointment);
            _context.SaveChanges();
        }

        public void RemoveQueue(string patientCode, DateOnly date, TimeOnly hour, string optometristCode)
        {
            var appointment = _context.PatientsAppointments.FirstOrDefault(q =>
             q.Date == date &&
             q.Hour == hour &&
             q.OptometristCode == optometristCode &&
             q.PatientCode == patientCode);

            if (appointment == null)
                throw new InvalidOperationException("לא נמצא תור בתאריך ושעה אלו");

            var queue = _context.QueueLists.FirstOrDefault(q =>
             q.Date == date &&
             q.Hour == hour &&
             q.OptometrisId == optometristCode
             );

            if (queue == null)
                queue.Available = true;
            _context.PatientsAppointments.Remove(appointment);
            _context.SaveChanges();
        }

    }
}