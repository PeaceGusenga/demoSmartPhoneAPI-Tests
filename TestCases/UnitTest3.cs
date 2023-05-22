namespace TestCases;
[TestFixture]
public class TestCase3
{
    private RestClient client;

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
    public void VerifyGetAllBrands()
    {
        //ENDPOINT
        string endpoint = "/GetAllBrands";
        //REQUEST
        var request = new RestRequest(endpoint, Method.GET);

        //HEADER
        request.AddHeader("accept", "text/plain");

        //REQUEST
        var response = client.Execute(request);

        //VERIFY RESPONSE
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //STORE RESPONSE BODY
        string content = response.Content;

        //RESPONSE BODY CONTENTS
        Assert.IsEmpty(content);

        //RESPONSE CONTENTS
        Assert.IsNotEmpty(content);

        //ASSERT NULL 
        Assert.Null(content);

        //ASSERT NOT NULL
        Assert.IsNotNull(content);
    }
}