## Purpose  
The purpose of this exercise is not to give a "gotcha" question or puzzle, but a straight-forward (albeit contrived) example of the kind of requirement that might arise in a real project so that we have shared context for a technical conversation during the interview. We are interested in how you approach a project. Use of your favorite libraries or frameworks is fine, but not required. How you demonstrate the correctness of your implementation is up to you.  
  
  
## Core requirements / tasks
* Create a command line Node program, which retrieves the information of a GitHub User and creates a new Contact or updates an existing contact in Freshdesk, using their respective APIs. You may use either JavaScript or TypeScript for this task.
* Transfer any fields that you think are compatible from the GitHub User to the Freshdesk Contact 
* Use GitHub Rest API v3. Documentation is available at https://developer.github.com/v3/  
* Use Freshdesk API v2. Documentation is available at https://developers.freshdesk.com/api/  
* Your program should be able to take GitHub user login (username) and Freshdesk subdomain  
as inputs from the command line.  
* For authentication assume GitHub personal access token is given in `GITHUB_TOKEN` 
environmental variable and Freshdesk API key is given in `FRESHDESK_TOKEN` environmental  
variable.  
* You may also use any JS or TS libraries which will help you with the task, such as requests or  
mock, except for API clients for Freshdesk or GitHub.  
* While you may create trial accounts in GitHub and Freshdesk, this is not a requirement. You can  
use the examples from the documentation as test data.  
* Please provide a `README.md` file with instructions on how to run the Node program. 

## Stretch requirements / tasks
These are bonus tasks to consider. Complete the core tasks before attempting one of these. You can also feel free to consider your own ideas for extension if you have time to complete additional requirements. These are only suggestions.

* Use a database (MongoDB or another) to store to combined fields from Github and Freshdesk once the user has been fetched. 
* Consider adding session-based authentication to your program. 
* Provide unit tests for the functionality. 
* Design and/or implement a UI to replace the command line interface.
* Create an Express server that exposes an API to interact with the program. This API should allow for the same operations as the command line interface, but through HTTP requests.