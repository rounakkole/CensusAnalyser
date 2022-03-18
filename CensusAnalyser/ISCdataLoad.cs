using CensusAnalyser.POCO;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser
{
    public class ISCdataLoad
    {

        public List<ISCdata> ISCdataList;
        public string[] CensusData;

        public string ISCdataLoader(string FilePath, int Records, string[] Header)
        {

            try
            {

                if (!File.Exists(FilePath))
                {
                    throw new ISCdataCustomEx(ISCdataCustomEx.ExceptionType.WRONG_FILE, "wrong file path");

                }
                else
                {
                    CensusData = File.ReadAllLines(FilePath);

                }
                if (Path.GetExtension(FilePath) != ".csv")
                {
                    throw new ISCdataCustomEx(ISCdataCustomEx.ExceptionType.WRONG_EXTENSION, "wrong file extension");
                }

                else if (!CensusData[1].Contains(","))
                {
                    throw new ISCdataCustomEx(ISCdataCustomEx.ExceptionType.WRONG_DELIMITER, "wrong csv delimiter");

                }
                else if (CensusData[0] != Header[0])
                {
                    throw new ISCdataCustomEx(ISCdataCustomEx.ExceptionType.WRONG_HEADER, "wrong file header");
                }

                else
                {
                    using (StreamReader sr = File.OpenText(FilePath))
                    using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                    {
                        ISCdataList = csvReader.GetRecords<ISCdata>().ToList();
                    }

                    if (Records != ISCdataList.Count)
                    {
                        throw new ISCdataCustomEx(ISCdataCustomEx.ExceptionType.WRONG_RECORDS, "wrong number of records");
                    }
                    else
                    {
                        return "test pass";
                    }
                }
            }
            catch (ISCdataCustomEx ex)
            {
                return ex.Message;

            }
        }
    }
}
