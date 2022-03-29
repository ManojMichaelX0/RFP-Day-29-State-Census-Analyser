using NUnit.Framework;
using IndianStateCensusAnalysis.POCO;
using IndianStateCensusAnalysis;
using System.Collections.Generic;
using Newtonsoft.Json;
using static IndianStateCensusAnalysis.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityInSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN, StateCode";
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
        Dictionary<string ,CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalysis.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }

        [Test]
        public void GivenIndianStateCensusDataFile_ReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
    }
}