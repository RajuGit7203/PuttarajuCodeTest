
using System.Collections.Generic;

namespace Mouri.Shared
{
    public class PatientDataService : IPatientData
    {
        PatientData data = new PatientData();
        public PatientDataService() { }

        public async Task<Patient> GetPatient(string id)
        {
            return await data.GetPatient(id);
        }


    }
}
