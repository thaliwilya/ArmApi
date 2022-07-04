using ArmApi.Interface;
using ArmApi.Model.Services.GoogleAPI;
using RestSharp;
using RestSharp.Authenticators;

namespace ArmApi.Services.GoogleAPI
{
    public class GoolgePlacesAPI : IGooglePlacesAPI
    {
        private readonly ILogger<GoolgePlacesAPI> _logger;
        private readonly IConfiguration _configuration;
        public GoolgePlacesAPI(ILogger<GoolgePlacesAPI> logger, IConfiguration configuration)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into GoolgeAPI");
            _configuration = configuration;
        }
        public async Task<GooglePlacesAPIResponse> ApplyAsync(string? query)
        {
            var strURL = _configuration["GoogleAPI:TextSearch"];
            query = query != null ? query.ToString() : _configuration["GoogleAPI:DefaultKey"];
            strURL +=  String.Format("json?query=\"{0}\"&type=restaurant", query);
            var client = new RestClient(strURL);
            //client.Authenticator = new HttpBasicAuthenticator("key", _configuration["GoogleAPI:key"]);
            //{ Authenticator = new HttpBasicAuthenticator("key", _configuration["GoogleAPI:key"]) };
            var request = new RestRequest();
            request.AddParameter("key", _configuration["GoogleAPI:key"], ParameterType.GetOrPost);
            //request.AddParameter("key", _configuration["GoogleAPI:key"]);
            //request.AddParameter("query", query);
            //request.AddParameter("type", "restaurant");
            //request.AddHeader("API_KEY", "[THIS IS THE API KEY]");
            //var response = await client.GetAsync(request);
            var response = client.Execute<GooglePlacesAPIResponse>(request);
            //response.Data.results
 ;
            return response.Data;
        }

    }
}
