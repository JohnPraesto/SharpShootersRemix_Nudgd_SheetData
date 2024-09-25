using SharpShootersRemix_Nudgd_SheetData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetSheetsAPITestMVC.Controllers
{
    public class SheetRowController : Controller
    {
        // URL till Google Sheets webhook
        private readonly string apiUrl = "https://script.google.com/macros/s/AKfycbx9EzQLS4-ZjBucKNZpCRzxVgo8Qbhvv-Yut4mvdjXFaMiQUCXXv3jufjZgQHFy6xY/exec?action=read&sheetName=Blad1";

        // GET: SheetRow
        public async Task<IActionResult> Index()
        {
            // Skicka HTTP GET-förfrågan till din API-länk
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Läs JSON-svaret som en sträng
                string responseBody = await response.Content.ReadAsStringAsync();

                // Omvandla JSON-svaret till en lista med SheetRow-objekt
                var json = JObject.Parse(responseBody);
                var dataArray = json["data"] as JArray;
                var sheetRowList = new List<SheetRow>();

                foreach (var item in dataArray)
                {
                    var sheetRow = new SheetRow
                    {
                        DATA_TYPE = (string)item["DATA_TYPE"],
                        Client = (string)item["Client"],
                        Project = (string)item["Project"],
                        Signed_Date = (string)item["Signed_Date"],
                        Start_Date = (string)item["Start_Date"],
                        End_Date = (string)item["End_Date"],
                        Vertical = (string)item["Vertical"],
                        Project_Type = (string)item["Project_Type"],
                        Time_to_close = (string)item["Time_to_close"],
                        Time_in_project = (string)item["Time_in_project"],
                        Project_Milestones = (string)item["Project_Milestones"],
                        Budget_SEK = (string)item["Budget_SEK"],
                        Budget_h = (string)item["Budget_h"],
                        Client_Cost = (string)item["Client_Cost"],
                    };
                    sheetRowList.Add(sheetRow);
                }

                // Skicka listan till vyn
                return View(sheetRowList);
            }
        }
    }
}
