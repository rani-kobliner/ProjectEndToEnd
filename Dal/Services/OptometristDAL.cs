using Dal.Api;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class OptometristDAL : IOptometrist
    {
        private readonly dbClass _context;

        public OptometristDAL(dbClass context)
        {
            _context = context;
        }
        public void AddOptometrist(string id, string firstName, string lastName, 
            string gender, int specializationByAge)
        {
            if (_context.Optometrists.Any(o => o.Id == id))
                throw new InvalidOperationException("An optometrist with " +
                    "this ID already exists");

            var optometrist = new Optometrist(id, firstName, lastName, gender, specializationByAge);

            try
            {
                _context.Optometrists.Add(optometrist);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding optometrist to the database", ex);
            }
        }

        public void RemoveOptometrist(string id)
        {

            try
            {
                var optometrist = _context.Optometrists.Find(id);
                if (optometrist == null) { 
                    throw new InvalidOperationException("Optometrist not found");
                }
                _context.Optometrists.Remove(optometrist);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to remove optometrist", ex);
            }
        }

    }
}
