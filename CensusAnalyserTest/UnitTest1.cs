using NUnit.Framework;
using IndianStateCensusAnalysis.POCO;
using IndianStateCensusAnalysis;
using System.Collections.Generic;
using static IndianStateCensusAnalysis.CensusAnalyser;
using static IndianStateCensusAnalysis.POCO.StateAnalyser;


namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityInSqKm";
        static string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        static string wrongHeaderIndianCensusDataFilePath = @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\wrongIndianCensusData.csv";
        static string delimiterIndianCensusFilePath = @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\DelimiterIndianStateCensusData.csv";
        static string wrongIndianStateCensusFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianData.csv";
        static string wrongIndianStateCensusFileType= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCensusData.txt";
        static string indianStateCodeFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCode.csv";
        static string wrongIndianStateCodeFileType= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\IndianStateCode.txt";
        static string delimiterIndianStateCodeFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\DelimiterIndianStateCode.csv";
        static string wrongHeaderStateCodeFilePath= @"D:\.net\Day 29 Indian States\IndianStateCensusAnalysis\CensusAnalyserTest\CSVFiles\wrongIndianStateCode.csv";

        IndianStateCensusAnalysis.CensusAnalyser censusAnalyser;
        IndianStateCensusAnalysis.POCO.StateAnalyser stateAnalyser;
        Dictionary<string ,CensusDTO> totalRecord;
        Dictionary<string, StateDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalysis.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateAnalyser = new IndianStateCensusAnalysis.POCO.StateAnalyser();
            stateRecord = new Dictionary<string, StateDTO>();

        }
        //1.1
        [Test]
        public void GivenIndianStateCensusDataFile_ReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            
        }
        //1.2 
        [Test]
        public void GivenWrongIndianCensusDataFile_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //1.3 
        [Test]
        public void GivenWrongIndianCensusDataFileType_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);

        }
        //1.4 
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //1.5 
        [Test]
        public void GivenIndianCensusDataFileButWrongHeader_ReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusDataFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        //2.1
        [Test]
        public void GivenIndianStateDataFile_ReturnCensusDataCount()
        {
            stateRecord = stateAnalyser.LoadStateData(Country1.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(32, stateRecord.Count);
        }
        //2.2
        [Test]
        public void GivenWrongIndianstateDataFile_ReturnCustomException()
        {
            var stateException = Assert.Throws<StateAnalyserException>(() => stateAnalyser.LoadStateData(Country1.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(StateAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //2.3
        [Test]
        public void GivenWrongIndianStateDataFileType_ReturnCustomException()
        {
            var stateException = Assert.Throws<StateAnalyserException>(() => stateAnalyser.LoadStateData(Country1.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(StateAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        //2.4
        [Test]
        public void GivenIndianStateDataFile_WhenDelimiterNotProper_ReturnCustomException()
        {
            var stateException = Assert.Throws<StateAnalyserException>(() => stateAnalyser.LoadStateData(Country1.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(StateAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
        //2.5
        [Test]
        public void GivenIndianStateDataFileButWrongHeader_ReturnCustomException()
        {
            var stateException = Assert.Throws<StateAnalyserException>(() => stateAnalyser.LoadStateData(Country1.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(StateAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

    }
}