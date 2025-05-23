﻿using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IOptometrist
    {
        void AddOptometrist(Optometrist optometristDAL);
        void RemoveOptometrist(string id);
    }
}
