﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;

namespace Dal.Api
{
    public interface IQueue
    {
        void FillQueueList(string optometristId, bool available);
        public void AddQueue(string patientCode, DateOnly date, TimeOnly hour,
            string optometristCode);
        public void RemoveQueue(string patientCode, DateOnly date, TimeOnly hour,
            string optometristCode);
    }
}
