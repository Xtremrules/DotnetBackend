using DotnetBackend.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBackend.Service
{
    public interface ILocationService
    {
        IEnumerable<StateDTO> GetAllStates();

        LGADTO GetLGAs(long stateId);
    }
}
