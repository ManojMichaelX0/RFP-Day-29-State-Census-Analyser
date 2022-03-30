using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndianStateCensusAnalysis
{
    public class StateAdapter
    {
        protected string[] GetStateData(string csvFilePath, string dataHeaders)
        {
            string[] stateData;
            if (!File.Exists(csvFilePath))
            {
                throw new StateAnalyserException("File Not Found", StateAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new StateAnalyserException("Invalid File Type", StateAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            stateData = File.ReadAllLines(csvFilePath);
            if (stateData[0] != dataHeaders)
            {
                throw new StateAnalyserException("Incorrect header in Data", StateAnalyserException.ExceptionType.INCORRECT_HEADER);
            }

            return stateData;
        }
    }
}
