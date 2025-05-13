using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class ManageQueue
    {
        private readonly dbClass _context;

        public ManageQueue(dbClass context)
        {
            _context = context;
        }

        public void FillQueueList(string optometristId, bool available)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);

            // רשימת חגים וערבי חגים לשנת 2025
            List<DateOnly> holidays = new List<DateOnly>
        {
         //   new DateOnly(2025, 2, 12), // ערב ט"ו בשבט
       //     new DateOnly(2025, 2, 13), // ט"ו בשבט
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
       //     new DateOnly(2025, 4, 24), // יום השואה
       //     new DateOnly(2025, 4, 29), // ערב יום הזיכרון
       //     new DateOnly(2025, 4, 30), // יום הזיכרון
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

            TimeOnly workStart = new TimeOnly(9, 0); // 09:00
            TimeOnly workEnd = new TimeOnly(19, 0);   // 19:00
            TimeOnly breakStart = new TimeOnly(14, 0); // 14:00
            TimeOnly breakEnd = new TimeOnly(16, 0);   // 16:00

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                // בדוק אם התאריך הוא יום שבת, יום שישי, יום שלישי או אחד מהחגים
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Friday ||
                    holidays.Contains(DateOnly.FromDateTime(date)))
                {
                    continue; // דלג על היום הזה
                }

                for (TimeOnly time = workStart; time < workEnd; time = time.AddMinutes(30))
                {
                    // דלג על שעות ההפסקה
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
        }
    }
}