using Microsoft.JSInterop;
using System.Threading.Tasks;
using PundoPH.Model;

namespace PundoPH.Helper
{
    public class MessageHelper
    {
        private readonly IJSRuntime _jSRuntime;
        public MessageHelper(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }
        public async Task<bool> MessageBox(string identifier, string text)
        {
            return await _jSRuntime.InvokeAsync<bool>(identifier, text);
        }

        // Method for displaying an alert (no confirmation needed)
        public async Task MessageBox(string text)
        {
           await _jSRuntime.InvokeVoidAsync("alert", text);
        }
    }
}
