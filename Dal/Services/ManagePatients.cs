using Dal.Api;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class ManagePatients: IPatientDal
    {
        private readonly dbClass _context;
        public ManagePatients(dbClass context)
        {
            _context = context;
        }

        public void AddPatient(string id, string fName, string lName,
            DateOnly birthday, string gender, string hmo, DateOnly lVisit)
        {
            Patient p = new Patient(id, fName, lName, birthday, gender, hmo, lVisit);
            _context.Patients.Add(p);
        }

        public void RemovePatient(int id)
        {
            Patient p = _context.Patients.Find(id);
            if (p != null)
            {
                _context.Patients.Remove(p);
            }
            else {
                Console.WriteLine(" ");
            }
        }

        public void UpdatePatient(int id, string hmo)
        {
            Patient p = _context.Patients.Find(id);
            if (p != null)
            {
                p.Hmo = hmo;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine(" ");
            }
        }
    }
}
