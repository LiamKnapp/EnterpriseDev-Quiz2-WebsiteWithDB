using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TransactionRecordApp.Entities;

namespace TransactionRecordApp.Controllers
{
    /// <summary>
    /// Controls the Add, Edit and Delete functions
    /// </summary>
    public class TransactionController : Controller
    {
        private TransactionDbContext _transactionDbContext;

        public TransactionController (TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }

        // Here we use attr routing to specify the URL
        // and this allows us to rename the method to something more meaningful
        [HttpGet("/transaction/list")]
        public IActionResult GetAllTransactions()
        {
            // Use our DB context to query for all transactions, order them by GrossValue:
            List<Transaction> transactions = _transactionDbContext.Transactions
                .OrderBy(t => t.CompanyName)
                .ToList();

            // Pass that list off to the view using the view name:
            return View("List", transactions);
        }


    }
}
