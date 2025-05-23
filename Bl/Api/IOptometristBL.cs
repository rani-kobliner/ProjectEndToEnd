﻿using Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IOptometristBL
    {
        void AddOptometrist(ManagementOptometristBL optometristBL);
        void RemoveOptometrist(string id);
    }
}
