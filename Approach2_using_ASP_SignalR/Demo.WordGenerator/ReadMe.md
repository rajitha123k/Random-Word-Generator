Pre-requisites and assumptions
  Assuming that project is copied into C:\ drive
  dotnet command line version used 2.1.522 (dotnet --version)
  download link: https://download.visualstudio.microsoft.com/download/pr/c1fd12ab-c597-4cea-8272-874d260447c7/6499d1534178ed0e0abb6451b67133dd/dotnet-sdk-2.1.814-win-x64.exe
  Visual Studio 2017 (.Net Core 2.1)

To run tests using command line:
Please run Server first by clicking on RunServer.bat in C:\Demo.WordGenerator folder
Then run Client by clicking on RunClient.bat in C:\Demo.WordGenerator folder

To run tests using Visual Studio 2017 (.Net Core 2.1)
Open following projects using Visual studio 2017
..\Demo.WordGenerator\Demo.WordGenerator.Server\Demo.WordGenerator.Server.csproj
..\Demo.WordGenerator\Demo.WordGenerator.Client\Demo.WordGenerator.Client.csproj

Run Demo.WordGenerator.Server
Then 
Run Demo.WordGenerator.Client

In Client's Main function(Program.cs->Main) added code to send 10 words to server and then immediately client sends a start command to the Server 
On Receiving Start command Server Shuffles words(WordGeneratorHub.cs->BroadcastWords) and will start a 60-second cycle where each word in the wordList will be populated in CurrentWordSelected state for an equal period of
time and broadcasted to Client. 
After going through the list of words Server will reset the list 

