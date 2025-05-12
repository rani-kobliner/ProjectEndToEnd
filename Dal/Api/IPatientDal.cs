using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    internal interface IPatientDal
    {


        void AddPatient(string id, string fName, string lName,
            DateOnly birthday, string gender, string hmo, DateOnly lVisit);
    }
}