using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC2.UI.Data;
using DC2.UI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DC2.UI.Pages.Customer
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly DataName Data;
        public EditModel()
        {
            Data = new DataName();
        }

        [BindProperty]
        public CustomerDTO CurrentCustomer { get; set; }


        public IActionResult OnGet(string id)
        {
            CurrentCustomer = Data.GetById(id);
            if (CurrentCustomer is null) return RedirectToPage("./404");

            return Page();
        }
        public IActionResult OnPostSave()
        {
            if (ModelState.IsValid)
            {
                // save the new user
                Data.UpdateCustomer(CurrentCustomer);
                return RedirectToPage("./Customer", "Edit");
            }
            return Page();
        }
    }
}
