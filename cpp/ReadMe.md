# Quick Base C++ Craft demo

The purpose of this craft demo is to give us a jumping off point for discussion of your approach to solving problems. We are interested in learning how you approach this problem.
Quick Base C++ is based on Microsoft Windows Stack. However feel free to use your own IDE, Compiler and target platform

# FindMatchingRecords

- We would like to see an implementation of a small in memory database that can perform Fetching of records.

- We provide a simple base implementation of a Record data structure and collection of Records

- We have provided a base FindMatchingRecords Function that we would like to optimize.

- Fee free to provide your own implementation of Record, RecordCollection and FindMatchingRecords

- Feel free to change the profiler function, add unit tests, move the definitions into separate classes to make it more maintainable, add comments.

- Do not assume that the QBRecordCollection is sorted and the recordIDs are monoticinally increasing

# DeleteRecords (Stretch)

- We would like to introduce `DeleteRecordByID(Recordcollection records, uint id)`

- This function should essentially delete the record from your collection so that when you do FindMatchingRecords(RecordCollection records, string matchString), we return empty collection after the record is deleted

# What we expect to see
- We would like you to compare the performance of your implementation of FindMatchingRecords with the base implementation

- We would like to see the data structure choices, usage of memory layouts

- We would like to see usage of modern and standard C++ idioms

- We would like to see familiarity with writing maintainable and correct C++ projects

