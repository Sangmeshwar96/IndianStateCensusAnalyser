using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.CensusAnalyzer;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;


namespace CensusAnalyserTest
{
    public class CensusAnalyzerTest
    {
        public class CensusAnalyserTest
        {
            public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
            // Correct Csv file path
            public static string indianStateCensusFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
            public static string indianStateCodeFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
            // Wrong delimiter 
            public static string delimiterIndianStateCensusFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
            public static string delimiterIndianStateCodeFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
            // Wrong File Path
            public static string wrongIndianStateCensusFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\wrongpath.csv";
            // Wrong File Type
            public static string wrongIndianStateCensusFileType = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
            public static string wrongIndianStateCodeFileType = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
            // Wrong Header
            public static string wrongHeaderIndianCensusFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
            public static string wrongHeaderStateCodeFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";

            CensusAnalyzer censusAnalyser;
            Dictionary<string, CensusDTO> totalRecord;
            Dictionary<string, CensusDTO> stateRecord;

            [SetUp]
            public void Setup()
            {
                censusAnalyser = new CensusAnalyzer();
                totalRecord = new Dictionary<string, CensusDTO>();
                stateRecord = new Dictionary<string, CensusDTO>();
            }

            [Test]
            public void Test1()
            {
                Assert.Pass();
            }

            [Test]
            public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
                stateRecord = censusAnalyser.LoadCensusData( Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
                Assert.AreEqual(29, totalRecord.Count);
                Assert.AreEqual(37, stateRecord.Count);
            }

            [Test]
            public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
                var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
            }

            [Test]
            public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
                var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
            }

            [Test]
            public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCensusFilePath, indianStateCensusHeaders));
                var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
            }

            [Test]
            public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
                var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
            }
        }
    }
}
