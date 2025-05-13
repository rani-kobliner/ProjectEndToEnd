using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;

namespace Dal.Api
{
    public interface IQueue
    {
        void FillQueueList(string optometristId, TimeOnly startTime, bool available);
        public void MakingAnAppointment(Patient p, QueueList q);
        public void CancelAnAppointment(Patient p, int qId);
        public void UpdateAnAppointment(Patient p, int qId, DateOnly date,
            TimeOnly hour, string oId);
    }
}
