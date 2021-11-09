using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC2.UI.Data;
using DC2.UI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DC2.UI.Pages.Customer
{
    public class CustomerModel : PageModel
    {
        private readonly DataName Data;

        public CustomerModel()
        {
            Data = new DataName();
        }
        [BindProperty]
        public string Id { get; set; }
        public List<CustomerDTO> Customers { get; private set; }

        //[BindProperty]
        //public CustomerDTO CurrentCustomer { get; set; }

        public void OnGet()
        {
            Customers = Data.GetAll();
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid) return Page();
            return RedirectToPage("./Edit", new { id = Id});
        }

        public IActionResult OnPostRemove()
        {
            if (!ModelState.IsValid) return Page();
            return RedirectToPage("./RemoveCustomer", new { id = Id });
        }
    }
}
