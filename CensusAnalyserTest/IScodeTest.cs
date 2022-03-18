using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CensusAnalyser;

namespace CensusAnalyserTest
{
    internal class IScodeTest
    {


        public IScodeLoad IScodeObj;

        public readonly string IScode_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyser\Utility\IndiaStateCode.csv";
        public readonly string IScode_Wrong_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyser\Utilitys\IndiaStateCode.csv";
        public readonly string IScode_Wrong_Extension_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyserTest\UtilityTest\IndiaStateCode Extenstion.txt";
        public readonly string IScode_Wrong_Delimiter_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyserTest\UtilityTest\IndiaStateCodeDelimiter.csv";
        public readonly string IScode_Wrong_Header_FilePath = @"C:\Users\rounak\source\repos\CensusAnalyser\CensusAnalyserTest\UtilityTest\IndiaStateCodeHeader.csv";
        public readonly string[] HeaderList2 = { "SrNo,StateName,TIN,StateCode" };


        [SetUp]
        public void Setup()
        {
            IScodeObj = new IScodeLoad();
        }

        [Test]
        public void GivenRightPath_LoadCSV_ReturnPass()
        {
            int Records = 36;
            string Expected = "test pass";
            string result = IScodeObj.ISCdataLoader(IScode_FilePath, Records, HeaderList2);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongPath_ReturnCustomException()
        {
            int Records = 36;
            string Expected = "wrong file path";
            string result = IScodeObj.ISCdataLoader(IScode_Wrong_FilePath, Records, HeaderList2);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongExtension_ReturnCustomException()
        {
            int Records = 36;
            string Expected = "wrong file extension";
            string result = IScodeObj.ISCdataLoader(IScode_Wrong_Extension_FilePath, Records, HeaderList2);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongDelimiter_ReturnCustomException()
        {
            int Records = 36;
            string Expected = "wrong csv delimiter";
            string result = IScodeObj.ISCdataLoader(IScode_Wrong_Delimiter_FilePath, Records, HeaderList2);
            Assert.AreEqual(Expected, result);
        }

        [Test]
        public void GivenWrongHeader_ReturnCustomException()
        {
            int Records = 36;
            string Expected = "wrong file header";
            string result = IScodeObj.ISCdataLoader(IScode_Wrong_Header_FilePath, Records, HeaderList2);
            Assert.AreEqual(Expected, result);
        }
    }
}
