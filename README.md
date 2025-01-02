# SigmaTestTask
asp.net task
This Api is the Backend for handeling candidate information.
application is written in .NET 6 LTS

## Project Structure
```
├── src
│   ── CandidateInformationApi	  
|	        
│   ── BLL (Business Logic Layer)	
|	  ├── CandidateService
|	  	   
│   ── DAL	(Data Access Layer)
|	  ├── CandidateRepository

|	── Domain (Data Models)
|	  

├── Test
│   └── CandidateInformation.Test
 
```

- `appsettings.json` is .NET Core Web API environment config
- `Program.cs` is .NET Core Web API Entry Point for registring services and dependencies 

# Running the application
For now data are not stored physically on sql server. However, if we need to store them use can use sql server instance and 
make the changes to use connection for sql server  on Program.cs file and nothing to be changed.

To create database, both code first approach or database first approch can be followed.

For running the application, click on the play button or press F5. After which we will be able to see swagger documentation page.
There we shall feed data to the model for candidate post method and store the values to add or update candidates.
We can also execute get method to fetch all the saved candidates.

# Middleware
Middleware has been added. For now it handles all the exceptions within the application. We can also use this middleware to 
log the error. 