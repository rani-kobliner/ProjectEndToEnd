using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IOptometrist
    {
        void AddOptometrist(string id, string firstName, string lastName,
            string gender, int specializationByAge);
        void RemoveOptometrist(string id);
    }
}
