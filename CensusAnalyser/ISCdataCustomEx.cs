using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser
{
    public class ISCdataCustomEx : Exception
    {

        public enum ExceptionType
        {

            WRONG_RECORDS, WRONG_FILE, WRONG_EXTENSION, WRONG_DELIMITER, WRONG_HEADER
        }
        public ExceptionType Type;

        public ISCdataCustomEx(ExceptionType type, string message) : base(message)
        {
            Type = type;
        }
    }
}
