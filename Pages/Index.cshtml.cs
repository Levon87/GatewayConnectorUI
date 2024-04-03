using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LogsUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        string logstorageurl = "http://localhost:8000/api/logs";
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> OnGetGetData()
        {
            var client = _clientFactory.CreateClient();
             
            try
            {
                var response = await client.GetAsync(logstorageurl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<LogModel>>(content);
                    var orderedData = data?.OrderByDescending(x => x.Time);                    
                    return new JsonResult(orderedData);
                }
                else
                {
                    return new JsonResult("Ошибка при получении данных") { StatusCode = (int)response.StatusCode };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении данных: " + ex.Message);
            }
        }
    }
}
