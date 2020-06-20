using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UpKeepV2.App.Models;

namespace UpKeepV2.App.Data
{
    public class MedarbejderInfoDataService
    {
        private static HttpClient client = new HttpClient();

        public MedarbejderInfoDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://upkeepcabservice20200607084941.azurewebsites.net/api/MedarbejderInfo/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<MedarbejderInfo>> ToList()
        {
            var data = new List<MedarbejderInfo>();
            try
            {
                var response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<MedarbejderInfo>>(responseString);
                }
                client.Dispose();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal async Task<MedarbejderInfo> Find(int id) // Change to int
        {
            var data = new MedarbejderInfo();
            try
            {
                var response = await client.GetAsync(id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<MedarbejderInfo>(responseString);
                }
                client.Dispose();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal async Task Add(MedarbejderInfo data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException();
            }
            client.Dispose();
        }

        internal async Task Update(MedarbejderInfo data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PutAsync(data.Medarbejder_InfoID.ToString(), content);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException();
            }
            client.Dispose();
        }
        internal async Task Remove(int id)
        {
            var response = await client.DeleteAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
            }
            client.Dispose();
        }
    }
}
