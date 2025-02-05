using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.JSInterop;
using PundoPH.Model;
using System.IO;
using static System.Net.WebRequestMethods;

namespace PundoPH.Data
{
    public class ExportService
    {
        private readonly IJSRuntime _JSRuntime;
        private readonly HttpClient _http;

        public ExportService(HttpClient http, IJSRuntime jSRuntime)
        {
            _http = http;
            _JSRuntime = jSRuntime;
        }

        public async Task DownloadExcel(string fileName, List<Contribution> contributions)
        {
            var response = await _http.PostAsJsonAsync("api/excel/export", contributions);
            if (response.IsSuccessStatusCode)
            {
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                using var streamRef = new DotNetStreamReference(new MemoryStream(fileBytes));
                await _JSRuntime.InvokeVoidAsync("downloadFile", fileName, streamRef);
            }
        }
    }
}
