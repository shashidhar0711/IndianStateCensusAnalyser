using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        /// <summary>
        /// The indian state census headers and indian state code headers
        /// CSV file paths
        /// </summary>
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensus.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndianStateCode.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\wrongIndianStateCensusFileType.txt";
        static string wrongIndianStateCodeFileType = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\wrongIndianStateCodeFileType.txt";
        static string delimiterIndianCensusFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndianCodeFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCensusFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongHeaderCensusAnalyser.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Theja\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\wrongHeaderStateCodeFilePath.csv";

        /// <summary>
        /// The census analyser
        /// </summary>
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test case 1.1
        /// Givens the indian census data file when readed should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// Test case 1.2
        /// Givens the wrong indian census data file when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// Test case 1.3
        /// Givens the wrong indian census data file type when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// Test case 1.4
        /// Givens the indian census data file when not proper should return exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// Tset case 1.5
        /// Givens the indian census data file when header not proper should return exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        /// <summary>
        /// Test case 2.1
        /// Givens the indian state code file when read should return state code data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnStateCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// <summary>
        /// Test case 2.2
        /// Givens the wrong indian state code file when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        /// <summary>
        /// Test case 2.3
        /// Givens the wrong indian state code file type when read should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// Test case 2.4
        /// Givens the indian state code file when delimiter not proper should return exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        /// <summary>
        /// Test case 2.5
        /// Givens the indian state code file when header not proper it should return exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}