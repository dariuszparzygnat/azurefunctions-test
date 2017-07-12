using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    // parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "fibonnaciSteps", true) == 0)
        .Value;

    int numberOfFibonnaciSteps;
    if (!Int32.TryParse(name, out numberOfFibonnaciSteps))
        return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");
    var fibonnaciResult = CountFibonnaci(numberOfFibonnaciSteps);
    return req.CreateResponse(HttpStatusCode.OK, "Fibonnaci result" + fibonnaciResult);
}

private static int CountFibonnaci(int n)
{
    int a = 0;
    int b = 1;
    for (int i = 0; i < n; i++)
    {
        int temp = a;
        a = b;
        b = temp + b;
    }
    return a;
}