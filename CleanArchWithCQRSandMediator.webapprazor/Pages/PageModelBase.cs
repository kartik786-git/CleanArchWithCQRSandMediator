using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchWithCQRSandMediator.webapprazor.Pages
{
    public class PageModelBase : PageModel
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
