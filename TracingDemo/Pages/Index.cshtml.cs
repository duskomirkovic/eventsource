using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TracingDemo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly IInstrumentation _instrumentation;

    private readonly IDemoService _svc;

    public IndexModel(ILogger<IndexModel> logger, IInstrumentation instrumentation, IDemoService svc)
    {
        _logger = logger;
        _instrumentation = instrumentation;
        _svc = svc;
    }

    public void OnGet()
    {
        try
        {
            _instrumentation.IndexGetStart();

            int x = _svc.GetSomeData();
            int y = _svc.GetSomeMoreData();
        }
        finally
        {
            _instrumentation.IndexGetStop();
        }
    }
}
