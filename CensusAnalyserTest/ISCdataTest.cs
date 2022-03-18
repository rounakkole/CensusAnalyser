using CensusAnalyser.POCO;
using NUnit.Framework;
using CensusAnalyser;

namespace CensusAnalyserTest
{
    public class ISCdataTest
    {
        public ISCdataLoad ISCdataObj;

        public readonly string ISCdata_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyser\Utility\IndiaStateCensusData.csv";
        public readonly string ISCdata_Wrong_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyser\Utilitys\IndiaStateCensusData.csv";
        public readonly string ISCdata_Wrong_Extension_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyserTest\UtilityTest\IndiaStateCensusDataExtension.txt";
        public readonly string ISCdata_Wrong_Delimiter_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyserTest\UtilityTest\IndiaStateCensusDataDelimiter.csv";
        public readonly string ISCdata_Wrong_Header_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyserTest\UtilityTest\IndiaStateCensusDataHeader.csv";
        public readonly string[] HeaderList = { "State,Population,AreaInSqKm,DensityPerSqKm" };

        [SetUp]
        public void Setup()
        {
            ISCdataObj = new ISCdataLoad();
        }

        [Test]
        public void GivenRightPath_LoadCSV_ReturnPass()
        {
            int Records = 29;
            string Expected = "test pass";
            string result = ISCdataObj.ISCdataLoader(ISCdata_FilePath, Records, HeaderList);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongPath_ReturnCustomException()
        {
            int Records = 29;
            string Expected = "wrong file path";
            string result = ISCdataObj.ISCdataLoader(ISCdata_Wrong_FilePath, Records, HeaderList);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongExtension_ReturnCustomException()
        {
            int Records = 29;
            string Expected = "wrong file extension";
            string result = ISCdataObj.ISCdataLoader(ISCdata_Wrong_Extension_FilePath, Records, HeaderList);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongDelimiter_ReturnCustomException()
        {
            int Records = 29;
            string Expected = "wrong csv delimiter";
            string result = ISCdataObj.ISCdataLoader(ISCdata_Wrong_Delimiter_FilePath, Records, HeaderList);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongHeader_ReturnCustomException()
        {
            int Records = 29;
            string Expected = "wrong file header";
            string result = ISCdataObj.ISCdataLoader(ISCdata_Wrong_Header_FilePath, Records, HeaderList);
            Assert.AreEqual(Expected, result);
        }
    }
}