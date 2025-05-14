using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IQueue
    {
        void FillQueueList(string optometristId, TimeOnly startTime, bool available);
    }
}
