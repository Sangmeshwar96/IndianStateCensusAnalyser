using IndianStateCensusAnalyser.DTO;
using IndianStateCensusAnalyser.POCO;
using System;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }

}
