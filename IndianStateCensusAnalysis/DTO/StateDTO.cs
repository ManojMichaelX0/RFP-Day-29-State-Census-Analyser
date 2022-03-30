using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalysis.POCO
{
    public class StateDTO
    {
        int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public StateDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
    }
}
