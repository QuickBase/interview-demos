#include "stdafx.h"
#include <string>
#include <vector>
#include <algorithm>
#include <assert.h>
#include <ctime>
#include <iostream>

/**
    Represents a Record Object
*/
class QBRecord
    {

    public:
        int recordId;
        std::string stringValue;

        QBRecord(int recordId, std::string stringValue) : recordId(recordId), stringValue(stringValue)
        {
        }
    };

typedef std::vector<QBRecord> QBRecordCollection;

/**
    Return records that contains a string in the StringValue field
    records - the initial set of records to filter
    matchString - the string to search for
*/
QBRecordCollection QBFindMatchingRecords(QBRecordCollection records, std::string matchString)
    {
    QBRecordCollection result;
    std::copy_if(records.begin(), records.end(), std::back_inserter(result), [matchString](QBRecord rec){return rec.stringValue.find(matchString) != std::string::npos; });
    return result;
    }

/**
    Utility to populate a record collection
*/
QBRecordCollection populateDummyData(const std::string& prefix, int iterations)
    {
    QBRecordCollection data;
    for (int i = 0; i < iterations; i++)
        {
        data.push_back(QBRecord(i, prefix + std::to_string(i)));
        }

    return data;
    }



int main(int argc, _TCHAR* argv[])
{
    auto data = populateDummyData("testdata", 1000);
    std::clock_t startTimer = std::clock();
    auto filteredSet = QBFindMatchingRecords(data, "testdata500");
    std::cout << "profiler: " << (std::clock() - startTimer) / (double)(CLOCKS_PER_SEC / 1000) << std::endl;
    assert(filteredSet.size() == 1);
	return 0;
}

