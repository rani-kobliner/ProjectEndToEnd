using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.models;
using Dal.Services;
using Bl.Api;
using Dal.Api;

namespace Bl.Services
{
    public class OptometristBL : IOptometristBL
    {
        private readonly IOptometrist dal;

        public OptometristBL(IOptometrist _dal)
        {

            dal = _dal;
        }
        public void AddOptometrist(string id, string firstName, string lastName,
                string gender, int specializationByAge)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("המספר מזהה (ID) נדרש");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("שם פרטי נדרש");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("שם משפחה נדרש");

            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("מגדר נדרש");

            if (specializationByAge < 0)
                throw new ArgumentException("גיל התמחות לא תקין");

            dal.AddOptometrist(id, firstName, lastName, gender, specializationByAge);
        }
        public void RemoveOptometrist(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("המספר מזהה (ID) נדרש");

            dal.RemoveOptometrist(id);
        }
    }
}
