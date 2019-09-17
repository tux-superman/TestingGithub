using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingGithub.Models;

namespace TestingGithub.Pages.TestClasses
{
    public class DeleteModel : PageModel
    {
        private readonly TestingGithub.Models.TestingGithubContext _context;

        public DeleteModel(TestingGithub.Models.TestingGithubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TestClass TestClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestClass = await _context.TestClass.FirstOrDefaultAsync(m => m.ID == id);

            if (TestClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestClass = await _context.TestClass.FindAsync(id);

            if (TestClass != null)
            {
                _context.TestClass.Remove(TestClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
