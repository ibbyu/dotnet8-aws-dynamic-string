using DynamicString.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DynamicString.Pages
{
    public class IndexModel(IParameterStore parameterStore) : PageModel
    {
        public string DisplayString { get; set; } = string.Empty;

        public async Task OnGet()
        {
            DisplayString = await parameterStore.GetDynamicStringAsync();
        }
    }
}