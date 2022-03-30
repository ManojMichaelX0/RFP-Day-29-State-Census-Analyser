using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalysis.POCO
{
    public  class InidanStateAdapter : StateAdapter
    {
        string[] stateData;
        Dictionary<string, StateDTO> stateDataMap;
        public Dictionary<string, StateDTO> LoadStateData(string csvFilePath, string dataHeaders)
        {
            stateDataMap = new Dictionary<string, StateDTO>();
            stateData = GetStateData(csvFilePath, dataHeaders);
            foreach (string data in stateData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new StateAnalyserException("File Contains Wrong Delimiter", StateAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndianStateCode.csv"))
                    stateDataMap.Add(column[1], new StateDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
            }
            return stateDataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
