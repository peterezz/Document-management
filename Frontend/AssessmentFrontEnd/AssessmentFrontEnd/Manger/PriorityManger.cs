using AssessmentFrontEnd.Models;
using Newtonsoft.Json;

namespace AssessmentFrontEnd.Manger
{
    public class PriorityManger
    {
        //https://localhost:7254/api/Priorities
        private static HttpClient GetApi_Url()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7254/");
            return client;
        }
        public static List<PrioritiesVM> GetPriorities()
        {
            var client = GetApi_Url();
            string RequistURI = "api/Priorities";
            var responce = client.GetAsync(RequistURI).Result;
            var content = responce.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<PrioritiesVM>>(content);
            return data;
            ;
        }
    }
}
