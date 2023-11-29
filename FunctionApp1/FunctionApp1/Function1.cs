using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            var data = ReadData();
            var calced = Calc(data);
            Write(calced);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            if (string.IsNullOrEmpty(name))
                response.WriteString("Welcome to Azure Functions!");

            else
                response.WriteString($"Hallo {name}");

            return response;
        }

        private void Write(object calced)
        {

        }

        private object Calc(object data)
        {
            return "";
        }

        private object ReadData()
        {
            return "";
        }
    }
}
