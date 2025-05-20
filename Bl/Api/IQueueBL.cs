using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IQueueBL
    {
        public void FillQueueList(string optometristId, bool available);
        public void AddQueue(string patientCode, DateOnly date, TimeOnly hour,
            string optometristCode);
        public void RemoveQueue(string patientCode, DateOnly date, TimeOnly hour,
            string optometristCode);
    }
}
