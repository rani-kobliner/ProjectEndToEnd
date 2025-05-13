using Dal.Api;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class ManageOptometrist : IOptometrist
    {
        private readonly dbClass _context;

        public ManageOptometrist(dbClass context)
        {
            _context = context;
        }
        public void AddOptometrist(string id, string firstName, string lastName,
            string gender, int specializationByAge)
        {
            Optometrist o = new Optometrist(id, firstName, lastName, gender, specializationByAge);
            _context.Optometrists.Add(o);
            _context.SaveChanges();

        }

        public void RemoveOptometrist(string id)
        {
            Optometrist o = _context.Optometrists.Find(id) ;
            _context.Optometrists.Remove(o);
            _context.SaveChanges();
        }


    }
}
