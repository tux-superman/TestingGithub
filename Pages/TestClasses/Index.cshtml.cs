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
    public class IndexModel : PageModel
    {
        private readonly TestingGithub.Models.TestingGithubContext _context;

        public IndexModel(TestingGithub.Models.TestingGithubContext context)
        {
            _context = context;
        }
        public void ie()
        {

        }
        public IList<TestClass> TestClass { get;set; }

        public async Task OnGetAsync()
        {
            TestClass = await _context.TestClass.ToListAsync();
        }
    }
}
