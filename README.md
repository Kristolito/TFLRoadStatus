# TFLRoadStatus
Road Status Requests to TFL API via command line.

Technologies used.

Visual Studio
C#
ASP.NET Framework 4.7.2
NUnit --> for testing
Moq

# Summary

The program makes requests to the TFL Road Status API in order to get information about a road given.
If the request is successfull the program will display the name and the severity status of the road and it will exit with code 0.
If the road is not valid the program will exit with code 1 displaying a meaningfull message.
In any other case the program will exit with code -1.


# Steps to download and build.

1 -> Download the zip file.
2 -> Extract the folder.
3 -> Load the solution into Visual Studio IDE.
4 -> Build the project.

# Steps to run the project.

After you have build the project click on start from visual studio and then on the command line type "A1" to get a successfull message or "T1" to get an unsuccesfull message.

P.S you will need to add an AppId and your AppKey in the App.config file in order to make the requests.

# Steps to run the tests.

From the toolbar in Visual Studio select Tests --> Run all tests.

# Solution.

The solution consists of two projects.

1-> Main Solution.
Contains the command line program where you can make requests to the TFL API.

2-> Tests.
Contains the tests associated with the main program.




