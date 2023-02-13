# ReliabilityChallenge
The purpose of this code project is to start off with an unreliable system. The challenge is to make it reliable.

**File Descriptions:**
- Program.cs: A generic apientry point. You are free to make changes.

Controllers:
- RequestController: A method that takes a Request, and returns a Response. Presumably some reliability handling should go here...

Models:
- Request: Represents some form of request, it has only one attribute which is Id, this is so we can check that all id's were recieved. You are free to add additional Properties if needed.
- Response: Represents some form of response, I have put a RequestId for correlating back to the response. You are free to add additional Props.

Services:
- RequestProcessingService: Has a single method, that represents some semi-long running task. This service is known to cause issues... Do not modify the method  DoWork, this method introduces the instability.
- RequestPersistenceService: Is an Entity Framework context class, that can be used for persisting results. This is relevant later on in the excersize.

Tests:
- A mock request tests, generates 10 requests, each with an Id that increments.

**Rules:**
- You are able to edit all files, except the DoWork method in the "RequestProcessingService.cs" (this is because; this is the file that introduces the unreliability.)
- You must generate your responses using the unreliable RequestingProcessingService DoWork method, you cannot create your own request processing service to side-step the reliability problems within the method.
- You are free to use any libraries to assist, (selecting appropriate libraries is prefered, over coding everything yourself.)
- Your code changes must address the below issues.
- DO NOT POST your answer in a pull request, contact me via email to discuss, or to send your results

**Issues to resolve:**
- Users have been complaning that when using this service in production, they sometimes recieve an unrelated error, something about dividing by zero, they are wondering if theres a way you can make this error go away, while still returning them a result, the user doesnt mind if they have to wait extra time.
- Users have been complaining that the service in production usually works fine most of the time, however sometimes they never see a response, and their browser wheel keeps on spinning forever. Is there something we can do to ensure that they recieve a response in a timely fashion, currently responses takes a few seconds or so, they dont mind if it takes 10 seconds, just as long as they get the result.
- Users have been complaining that during very busy times, the server gets unstable and crashes, when the server restarts all of their requests are gone. Can you put in some mechanism so that the service can survive multiple restarts without losing users requests.
- Users have been complaining that the server routinely has internet problems, and sometimes the internet is working when the user sends the request, but the internet disconnects during the processing phase, and they never recieve a response, when they inspect the logs, they can see that the responses are being processed correctly, however the response is lost due to a http error. The users ask, if there is some way that the responses can be saved somewhere, and sent back to them when the internet is backup and working.
