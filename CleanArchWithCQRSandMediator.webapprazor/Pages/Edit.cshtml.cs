using CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchWithCQRSandMediator.webapprazor.Pages
{
    public class EditModel : PageModelBase
    {
        [BindProperty]
        public BlogVm Blog { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            var blog=  await Mediator.Send(new GetBlogByIdQuery() { BlogId= id });
            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await Mediator.Send(new UpdateBlogCommand
            {
                Id = Blog.Id,
                Author = Blog.Author,
                Description = Blog.Author,
                Name = Blog.Name
            });
            return RedirectToPage("./Index");
        }

    }
}
