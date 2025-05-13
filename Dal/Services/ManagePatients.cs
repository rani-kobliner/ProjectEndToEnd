using Dal.Api;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class ManagePatients: IPatient
    {
        private readonly dbClass _context;
        public ManagePatients(dbClass context)
        {
            _context = context;
        }

        public void SignUp()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter id: ");
            string id = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (!_context.Patients.Any(p => p.Id == id))
            {
                Console.WriteLine("User does not exist.");
            }
            else
            {
                RegisteredPatient rp = _context.RegisteredPatients.Find(id);
                if (rp!= null)
                {
                    _context.RegisteredPatients.Add(rp);
                    Console.WriteLine("Sign up successful!");
                }
                else
                {
                    Console.WriteLine("Username already exists. Please choose a different username.");
                }    
            }
        }

        public void SignIn()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            RegisteredPatient rp = _context.RegisteredPatients.Find(username);
            if (rp.Password == password)
            {
                Console.WriteLine($"Sign in successful! Welcome {username}");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        public void AddPatient(string id, string fName, string lName,
            DateOnly birthday, string gender, string hmo)
        {

            if (Enum.TryParse<HmoType>(hmo, true, out var hmoValue))
            {
                Patient p = new Patient(id, fName, lName, birthday, gender, hmo);
                _context.Patients.Add(p);
            }
            else throw new Exception("Invalid HMO type specified. Valid options are: Klalit, Macabi, Leumit, Meuhedet.");
        }

        public void RemovePatient(string id)
        {
            Patient p = _context.Patients.Find(id);
            if (p != null)
            {
                _context.Patients.Remove(p);
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        public void UpdatePatient(string id, string hmo)
        {
            Patient p = _context.Patients.Find(id);
            if (p != null)
            {
                p.Hmo = hmo;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
    }
}
