﻿using AssessmentFrontEnd.Models;
using Newtonsoft.Json;

namespace AssessmentFrontEnd.Manger
{
    public class DocumentManger
    {
        //https://localhost:7254/api/DocumentApi
        public static List<DocumentVM> GetDocument()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7254/");
            var responce=client.GetAsync("api/DocumentApi").Result;
            var content=responce.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<DocumentVM>>(content);
            return data;
;        }
    }
}