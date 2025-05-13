using Dal.Api;
using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IPatient
    {
        void SignUp();
        void SignIn();
        void AddPatient(string id, string fName, string lName,
            DateOnly birthday, string gender, string hmo);
        void RemovePatient(string id);
        void UpdatePatient(string id, string hmo);


    }
}