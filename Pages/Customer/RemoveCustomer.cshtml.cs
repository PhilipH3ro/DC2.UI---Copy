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
    public class RemoveCustomerModel : PageModel
    {

        [BindProperty]
        public CustomerDTO CurrentCustomer { get; set; }
        private DataName Data;

        public RemoveCustomerModel()
        {
            Data = new DataName();
        }
        public IActionResult OnGet(string id)
        {
            CurrentCustomer = Data.GetById(id);

            Data.RemoveCustomer(CurrentCustomer);
            return RedirectToPage("./Customer");
        }

    }
}
