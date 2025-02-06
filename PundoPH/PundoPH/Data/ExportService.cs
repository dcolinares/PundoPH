
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PundoPH.Model;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System;

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

        public async Task Excel(string fileName, List<Contribution> contributions)
        {
            var response = await _http.PostAsJsonAsync($"api/download/excel?fileName={fileName}", contributions);
            if (response.IsSuccessStatusCode)
            {
                var fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                using var streamRef = new DotNetStreamReference(new MemoryStream(fileBytes));
                await _JSRuntime.InvokeVoidAsync("downloadFile", fileName, streamRef, fileType);
            } else
            {
                Console.WriteLine("Failed to fetch excel.");
            }
        }

        public async Task Pdf(List<Contribution> contributions, string fileName)
        {
            var response = await _http.PostAsJsonAsync($"api/download/pdf?fileName={fileName}", contributions);
            if (response.IsSuccessStatusCode)
            {
                var fileType = "application/pdf";
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                using var streamRef = new DotNetStreamReference(new MemoryStream(fileBytes));
                await _JSRuntime.InvokeVoidAsync("downloadFile", fileName, streamRef, fileType);
            } else
            {
                Console.WriteLine("Failed to fetch PDF.");
            }
        }
    }
}
