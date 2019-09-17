using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingGithub.Models;

namespace TestingGithub.Pages.TestClasses
{
    public class CreateModel : PageModel
    {
        private readonly TestingGithub.Models.TestingGithubContext _context;

        public CreateModel(TestingGithub.Models.TestingGithubContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TestClass TestClass { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TestClass.Add(TestClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}