## Purpose
The purpose of this exercise is not to give a "gotcha" question or puzzle, but a straight-forward (albeit contrived) example of the kind of requirement that might arise in a real project so that we have shared context for a technical conversation during the interview. We are interested in how you approach a project. Use of your favorite libraries or frameworks is fine, but not required. How you demonstrate the correctness of your implementation is up to you.

## Requirements
Create a command line Python program, which retrieves the information of a GitHub User and creates a new Contact or updates an existing contact in Freshdesk, using their respective APIs.

* Use GitHub Rest API v3. Documentation is available at https://developer.github.com/v3/
* Use Freshdesk API v2. Documentation is available at https://developers.freshdesk.com/api/
* Your program should be able to get GitHub user login (username) and Freshdesk subdomain
from the command line.
* For authentication assume GitHub personal access token is given in GITHUB_TOKEN
environmental variable and Freshdesk API key is given in FRESHDESK_TOKEN environmental
variable.
* Transfer all compatible fields from the GitHub User to the Freshdesk Contact by your judgment
* Please provide unit tests for the main program functionality. Create a separate module for the
unit tests.
* You need to use Python 3.x.
* You may also use any Python libraries which will help you with the task, such as requests or
mock, **except for API clients for Freshdesk or GitHub**.
* Please provide a README.md file with instructions on how to run the Python program and the
tests.
