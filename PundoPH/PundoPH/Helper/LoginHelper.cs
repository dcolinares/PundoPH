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

        public async Task<bool> IsAuthenticated(string token)
        {
            var hasToken = !string.IsNullOrEmpty(token);
            return hasToken;
        }
    }
}
