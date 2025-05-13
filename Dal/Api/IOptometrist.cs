using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IOptometrist
    {
        void addOptometrist(string id, string firstName, string lastName,
            string gender, int specializationByAge);
        void removeOptometrist(string id);
    }
}
