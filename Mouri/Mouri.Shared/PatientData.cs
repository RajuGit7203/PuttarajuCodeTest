using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouri.Shared
{
    public class PatientData
    {
        public async Task<Patient> GetPatient(string id)
        {

            List<Patient> patients =await  BuildPatientData();
            return patients.Where(x => x.Id == id).FirstOrDefault() ?? null;

        }
        public async Task<IEnumerable> GetAllPatients()
        {

            List<Patient> patients = await BuildPatientData();
            return patients;

        }

        private async Task<List<Patient>> BuildPatientData()
        {
            var listOfPatients = new List<Patient>
            {
               new Patient { Id ="1000", FirstName="Mark",Lastname="Hassan",
                   Address = new AddressInfo{ AddressId =1000, City="Rockville",
                       State="MD", Street="455 Marshall", Zip="20851"},
                   Dob= Convert.ToDateTime("02/10/1985")
               },
                new Patient { Id ="1001", FirstName="Jhon",Lastname="Boss",
                   Address = new AddressInfo{ AddressId =1000, City="GaitherBurg",
                       State="MD", Street="432 Marshall", Zip="20855"},
                   Dob=Convert.ToDateTime("02/10/1980")
               }

            };
            return listOfPatients;
        }
    }
}
