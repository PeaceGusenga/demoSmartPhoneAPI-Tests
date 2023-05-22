namespace YourNamespace
{
    [TestFixture]
    public class TestCase1
    {
        private RestClient client;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            //CREATE RESTSHARP REST CLIENT INSTANCE
            client = new RestClient("http://localhost:5000");

            //SETUP LOGS
            NLog.LogManager.LoadConfiguration("nlog.config");
        }

        [Test]
        public void CreateProcessorTestValid()
        {

            //REQUEST
            var request = new RestRequest("http://localhost:5000/AddProcessor", Method.POST);
            
            //HEADER
            request.AddHeader("accept", "*/*");
            request.AddHeader("Content-Type", "application/json");

            //BODY
            request.AddJsonBody(new { ProcessorID = "0", ProcessorName = "TestProcessor" });

            //EXECUTE REQUEST
            var response = client.Execute(request);

            //INSPECT RESPONSE
            Logger.Info("This is an informational message.");
            Logger.Debug("This is a debug message.");
            Logger.Error("An error occurred: {0}", exception.Message);


            // ASSERTIONS
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.IsSuccessful, Is.True);

            // RESPONSE BODY ASSERTION
            Assert.That(response.Content, Is.EqualTo("New process added."));
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
            request.AddJsonBody(new { ProcessorID = "-100", ProcessorName = "$$$@#$#@!$asdasvjhbqwe"});

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
            request.AddJsonBody(new { ProcessorID = "100", ProcessorName = "$$$@#$#@!$asdasvjhbqwe"});

            //EXECUTE REQUEST
            var response = client.Execute(request);

            // ASSERTIONS
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.StatusDescription, Is.EqualTo("Processor Information is not valid.")); 
            
        }

    }
}
