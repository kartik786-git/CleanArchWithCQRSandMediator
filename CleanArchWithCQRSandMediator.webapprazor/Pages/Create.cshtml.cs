using CleanArchWithCQRSandMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchWithCQRSandMediator.webapprazor.Pages
{
    public class CreateModel : PageModelBase
    {
        [BindProperty]
        public BlogVm Blog { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            await Mediator.Send(new CreateBlogCommand { Name = Blog.Name, Description = Blog.Description, Author = Blog.Author });
            //_context.Blog.Add(Blog);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
