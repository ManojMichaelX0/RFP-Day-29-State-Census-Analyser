using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalysis.POCO
{
    public class StateAnalyser
    {
        public enum Country1
        {
            INDIA, US, BRAZIL
        }

        Dictionary<string, StateDTO> dataMap;
        public Dictionary<string, StateDTO> LoadStateData(Country1 country1, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdaptorFactory().LoadStateData(country1, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
