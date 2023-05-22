namespace YourNamespace
{
    [TestFixture]
    public class TestCase1
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            //CREATE RESTSHARP REST CLIENT INSTANCE
            client = new RestClient("https://localhost:5001");
        }

        [Test]
        public void CreateProcessorTestValid()
        {
            //REQUEST
            var request = new RestRequest("/AddProcessor", Method.POST);
            
            //HEADER
            request.AddHeader("accept", "*/*");
            request.AddHeader("Content-Type", "application/json");

            //BODY
            request.AddJsonBody(new { ProcessorID = "0", ProcessorName = "TestProcessor" });

            //EXECUTE REQUEST
            var response = client.Execute(request);

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
            request.AddJsonBody(new { ProcessorID = "-100", ProcessorName = "$$$@#$#@!$asdasvjhbqwe"});

            //EXECUTE REQUEST
            var response = client.Execute(request);

            // ASSERTIONS
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.StatusDescription, Is.EqualTo("Processor Information is not valid.")); 
            
        }

    }
}
