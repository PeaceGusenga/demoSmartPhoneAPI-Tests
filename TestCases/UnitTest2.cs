namespace TestCases;
[TestFixture]
public class TestCase2
{
    private RestClient client;

    [SetUp]
    public void Setup()
    {
        string baseURL1 = "https://localhost:5001";
        string baseURL2 = "http://localhost:5000";
        
        //CREATE RESTSHARP REST CLIENT INSTANCE
        client = new RestClient(baseURL1);

        //SETUP LOGS
        NLog.LogManager.LoadConfiguration("nlog.config");
    }

    [Test]
    public void GetAllProcessors()
    {
        //ENDPOINT
        string endpoint = "/GetAllProcessors";

        //CREATE REQUEST INSTANCE
        RestRequest request = new RestRequest(endpoint, Method.GET);

        //HEADER
        request.AddHeader("accept", "text/plain");

        //EXECUTE Reqquest
        IRestResponse response = client.Execute(request);

        //VERIFY STATUS CODE
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        //RESPONSE
        string content = response.Content;

        List<Processor> processors = JsonSerializer.Deserialize<List<Processor>>(content);
        
        foreach(Processor x in processors)
        {
        
        int processorID = x.ProcessorID;
        string processName = x.ProcessorName;

        //RESPONSE BODY
        Assert.IsNotNull(processorID);
        Assert.IsNotEmpty(processName);

        //VERIFY CORRECTNESS
        Assert.IsTrue(processName.Contains("Snapdragon") || processName.Contains("MediaTek"));
        }
    }
}

public class Processor
{
    public int ProcessorID { get; set; }
    public string ProcessorName { get; set; }

}