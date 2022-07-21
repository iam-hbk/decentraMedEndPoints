using decentraMed.Models;
using System.Text.Json;

namespace decentraMed.service
{
    public class Service
    {
        private HttpClient Client = new HttpClient();


        public async Task<Models.Diagnosis> GetDiagnosis(String tokenID)
        {
            var response = await Client.GetAsync("http://localhost:5002/getMetaData/" + tokenID);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();


                var deptObj = JsonSerializer.Deserialize<Metadata>(responseString);

                var obj = JsonSerializer.Deserialize<Diagnosis>(deptObj.metadata);

                return obj;
            }

            return null;
        }
        public async Task<Allergies> GetAllergies(String tokenID)
        {
            var response = await Client.GetAsync("http://localhost:5002/getMetaData/" + tokenID);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();


                var deptObj = JsonSerializer.Deserialize<Metadata>(responseString);

                var obj = JsonSerializer.Deserialize<Allergies>(deptObj.metadata);

                return obj;
            }

            return null;
        }
        public async Task<Visits> GetVisits(String tokenID)
        {
            var response = await Client.GetAsync("http://localhost:5002/getMetaData/" + tokenID);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();


                var deptObj = JsonSerializer.Deserialize<Metadata>(responseString);

                var obj = JsonSerializer.Deserialize<Visits>(deptObj.metadata);

                return obj;
            }

            return null;
        }
        public async Task<Presciptions> GetPrescriptions(String tokenID)
        {
            var response = await Client.GetAsync("http://localhost:5002/getMetaData/" + tokenID);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();


                var deptObj = JsonSerializer.Deserialize<Metadata>(responseString);

                var obj = JsonSerializer.Deserialize<Presciptions>(deptObj.metadata);

                return obj;
            }

            return null;
        }


    }
}
