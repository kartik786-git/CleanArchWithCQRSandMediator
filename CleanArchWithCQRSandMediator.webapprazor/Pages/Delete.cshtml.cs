using CleanArchWithCQRSandMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchWithCQRSandMediator.webapprazor.Pages
{
    public class DeleteModel : PageModelBase
    {
        [BindProperty]
        public BlogVm Blog { get; set; } = default!;
        public async Task<IActionResult> OnGet(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                Blog = blog;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });

            if (blog != null)
            {
                await Mediator.Send(new DeleteBlogCommand { Id = id });
            }

            return RedirectToPage("./Index");
        }
    }
}
