using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Api;
using Dal.Api;

namespace Bl.Services
{
    public class QueueBL: IQueueBL
    {
        private readonly IQueue dal;
        private readonly IOptometristBL optometristBL;

        public QueueBL(IQueue _dal, IOptometristBL _optometristBL)
        {
            dal = _dal;
            optometristBL = _optometristBL;
        }

        public void FillQueueList(string optometristId, bool available)
        {
            if (string.IsNullOrWhiteSpace(optometristId))
                throw new ArgumentException("Optometrist ID must not be empty.");
            dal.FillQueueList(optometristId, available);
        }

        public void AddQueue(string patientCode, DateOnly date, TimeOnly hour,
            string optometristCode)
        {
            if (string.IsNullOrWhiteSpace(patientCode))
                throw new ArgumentException("Patient code must not be empty.");

            if (string.IsNullOrWhiteSpace(optometristCode))
                throw new ArgumentException("Optometrist code must not be empty.");
            dal.AddQueue(patientCode, date, hour, optometristCode);
        }

        public void RemoveQueue(string patientCode, DateOnly date, TimeOnly hour, 
            string optometristCode)
        {
            if (string.IsNullOrWhiteSpace(patientCode))
                throw new ArgumentException("Patient code must not be empty.");
            if (string.IsNullOrWhiteSpace(optometristCode))
                throw new ArgumentException("Optometrist code must not be empty.");
            dal.RemoveQueue(patientCode, date, hour, optometristCode);
        }

    }
}

