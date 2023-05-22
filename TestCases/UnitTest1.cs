namespace TestCases
{
    [TestFixture]
    public class TestCase1
    {
        private RestClient client;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        [SetUp]
        public void Setup()
        {
            string baseURL = "https://localhost:5001";
            //CREATE RESTSHARP REST CLIENT INSTANCE
            client = new RestClient(baseURL);

            //SETUP LOGS
            NLog.LogManager.LoadConfiguration("nlog.config");

        }

        [Test]
        public void CreateProcessorTestValid()
        {
         try{

            //RESOURCE
            string endpoint = "/AddProcessor";

            //REQUEST
            var request = new RestRequest(endpoint, Method.POST);
            
            //HEADER
            request.AddHeader("Content-Type", "application/json");

            //BODY
            request.AddJsonBody(new { processorID = 0, processorName = "TestProcessor" });

            //EXECUTE REQUEST
            var response = client.Execute(request);
            
            // ASSERTIONS
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // RESPONSE BODY ASSERTION
            Assert.That(response.Content, Is.EqualTo("New process added."));

            }
         catch(Exception exception)
            {
            //INSPECT RESPONSE
            Logger.Info("This is an informational message.");
            Logger.Debug("This is a debug message.");
            Logger.Error("An error occurred: {0}", exception.Message);
            }

        }
        
        [Test]
        public void CreateNegativeProcessorID()
        {   
            
            //REQUEST
            var request = new RestRequest("/AddProcessor", Method.POST);
            
            //HEADER
            request.AddHeader("accept", "*/*");
            request.AddHeader("Content-Type", "application/json");

            //BODY
            request.AddJsonBody(new { processorID = -100, processorName = "$$$@#$#@!$asdasvjhbqwe"});

            //EXECUTE REQUEST
            var response = client.Execute(request);

            // ASSERTIONS
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.StatusDescription, Is.EqualTo("New process added.")); 
            
        }
        [Test]
        public void CreateLargeProcessorID()
        {  

            //REQUEST
            var request = new RestRequest("/AddProcessor", Method.POST);
            
            //HEADER
            request.AddHeader("accept", "*/*");
            request.AddHeader("Content-Type", "application/json");

            //BODY
            request.AddJsonBody(new { ProcessorID = 100, ProcessorName = "$$$@#$#@!$asdasvjhbqwe"});

            //EXECUTE REQUEST
            var response = client.Execute(request);

            // ASSERTIONS
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.StatusDescription, Is.EqualTo("Processor Information is not valid.")); 
            
        }

    }
}
