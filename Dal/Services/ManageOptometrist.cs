using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class ManageOptometrist
    {
        private readonly dbClass _context;

        public ManageOptometrist(dbClass context)
        {
            _context = context;
        }
        public void addOptometrist(string id, string firstName, string lastName,
            string gender, int specializationByAge)
        {
            Optometrist o = new Optometrist(id, firstName, lastName,gender, specializationByAge);
            _context.Optometrists.Add(o);

        }
        public void removeOptometrist(string id)
        {
            Optometrist o = _context.Optometrists.Find(id);
            if (o != null)
            {
                _context.Remove(o);
            }
        }

        //public void updateOptometrist(string id)
        //{
        //    Optometris o = _context.Optometrists.Find(id);
        //    if (o != null)
        //    {
        //        _context.Remove(o);
        //    }
        //}
    }
}
