using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Common.Helpers
{
    public class HttpClientService
    {


        static async Task TeachHttp()
        {
            string baseUrl = "https://your-api-base-url.com"; // Replace with your API base URL
            string teacherId = "your-teacher-id"; // Replace with the teacher ID you want to fetch

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{baseUrl}/teachId/{teacherId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        // You can deserialize the content as needed
                        // For simplicity, let's assume the content is JSON
                        // Replace "Teacher" with the actual class you want to deserialize into
                        var teacher = Newtonsoft.Json.JsonConvert.DeserializeObject<Teacher>(content);
                        
                    }
                    else
                    {
                        Console.WriteLine($"HTTP Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }

}

