using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusAnalysis.POCO;

namespace IndianStateCensusAnalysis
{
    public class CSVAdaptorFactory
    {
        public Dictionary<string, CensusDTO> LoadCSVData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
        public Dictionary<string, StateDTO> LoadStateData(StateAnalyser.Country1 country1, string csvFilePath, string dataHeaders)
        {
            switch (country1)
            {
                case (StateAnalyser.Country1.INDIA):
                    return new InidanStateAdapter().LoadStateData(csvFilePath, dataHeaders);
                default:
                    throw new StateAnalyserException("No Such Country", StateAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
