using AssessmentFrontEnd.Models;
using Newtonsoft.Json;
using System.Text;

namespace AssessmentFrontEnd.Manger
{
    public class DocumentManger
    {
        //https://localhost:7254/api/DocumentApi
        private static HttpClient GetApi_Url()
        {
        HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7254/");
            return client;
        }

        public static List<DocumentVM> GetDocument(string SearchVal)
        {
            var client = GetApi_Url();
            string RequistURI = "api/DocumentApi/SearchDocument/" + SearchVal;
            var responce=client.GetAsync(RequistURI).Result;
            var content=responce.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<DocumentVM>>(content);
            return data;
;       }
        //https://localhost:7254/api/DocumentApi
        public static void UploadDocument(DocumentVM Obj)
        {
            var client = GetApi_Url();
            string RequistURI = "api/DocumentApi";
            var content = new StringContent(JsonConvert.SerializeObject(Obj), Encoding.UTF8, "application/json");
                 
            var responce = client.PostAsync(RequistURI,content).Result;
            

            ;
        }
    }
}
