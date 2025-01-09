using Microsoft.JSInterop;

namespace PundoPH.Helper
{
    public class LoginHelper
    {
        private readonly IJSRuntime _jSRuntime;

        public LoginHelper(IJSRuntime jSRuntime) 
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<bool> IsAuthenticated()
        {
            var hasToken = await _jSRuntime.InvokeAsync<bool>("sessionStorage.getItem", "Token");
            return hasToken;
        }
    }
}
