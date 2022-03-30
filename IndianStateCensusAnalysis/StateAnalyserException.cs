using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalysis
{
    public class StateAnalyserException: Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY
        }
        public ExceptionType eType;
        public StateAnalyserException(string message, ExceptionType exception) : base(message)
        {
            this.eType = exception;
        }
    }
}
