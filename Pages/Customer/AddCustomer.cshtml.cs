using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC2.UI.Data;
using DC2.UI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DC2.UI.Pages.Customer
{
    [Authorize(Policy = "AdminOnly")]
    public class AddCustomerModel : PageModel
    {
        [BindProperty]
        public CustomerDTO CurrentCustomer { get; set; }
        private DataName Data;

        public AddCustomerModel()
        {
            Data = new DataName();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid) return Page();
            Data.AddCustomer(CurrentCustomer);
            return RedirectToPage("./Customer");
        }
    }
}
