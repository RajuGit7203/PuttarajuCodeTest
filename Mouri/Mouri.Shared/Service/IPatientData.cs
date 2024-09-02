using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouri.Shared
{
    public interface IPatientData
    {
        Task<Patient> GetPatient(string id);
    }
}
