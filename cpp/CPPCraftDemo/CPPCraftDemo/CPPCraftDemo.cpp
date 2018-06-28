/**
    We provide a simple base implementation of a Record datastructure and collection of Records
    We would like to implement FindMatchingRecords function that searches through the records for a string

*/
#include "stdafx.h"
#include <string>
#include <vector>

/*
Represents a Record Object
*/
class QBRecord
    {
    int id;
    std::string value;

    public QBRecord(int id, std::string value) : id(id), value(value)
        {

        }
    };

typedef std::vector<QBRecord> QBRecordColleciton;

QBRecordColleciton QBFindMatchingRecords(QBRecordColleciton records)
    {

    }

QBRecordColleciton populateDummyData()
    {
    QBRecordColleciton data;
    for (int i = 0; i < 1000; i++)
        {
        data.push_back(QBRecord(i, i));
        }
    }

int main(int argc, _TCHAR* argv[])
{

	return 0;
}

