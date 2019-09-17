using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingGithub.Models;

namespace TestingGithub.Pages.TestClasses
{
    public class EditModel : PageModel
    {
        private readonly TestingGithub.Models.TestingGithubContext _context;

        public EditModel(TestingGithub.Models.TestingGithubContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TestClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestClassExists(TestClass.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestClassExists(int id)
        {
            return _context.TestClass.Any(e => e.ID == id);
        }
    }
}
