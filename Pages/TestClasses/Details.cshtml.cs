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
    public class DetailsModel : PageModel
    {
        private readonly TestingGithub.Models.TestingGithubContext _context;

        public DetailsModel(TestingGithub.Models.TestingGithubContext context)
        {
            _context = context;
        }

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
    }
}
