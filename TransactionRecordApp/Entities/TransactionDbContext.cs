using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace TransactionRecordApp.Entities
{
    /// <summary>
    /// This class will inherit from the Entity Framework (EF) class
    /// called DbContext and is used by the code to interact with the DB
    /// </summary>
    public class TransactionDbContext : DbContext
    {
        /// <summary>
        /// Define a constructor that simply passes the options argument
        /// up to the base class constuctor
        /// </summary>
        /// <param name="options"></param>
        /// 
        public TransactionDbContext(DbContextOptions options)
            : base(options) { }



        // Adding a property to access all transactionss
        public DbSet<Transaction> Transactions { get; set; }


        // override the OnModelBuilding method as a place to do init'n
        // which for us will be to seed the DB w some data:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed the DB with at least 4 Transactions
            modelBuilder.Entity<Transaction>().HasData(
                 new Transaction()
                 {
                     TransactionId = 1,
                     TickerSymbol = "AAPL",
                     CompanyName = "Apple",
                     Quantity = 2,
                     SharePrice = 194.62
                 },
                 new Transaction()
                 {
                     TransactionId = 2,
                     TickerSymbol = "F",
                     CompanyName = "Ford Motors Company",
                     Quantity = 4,
                     SharePrice = 11.34
                 },
                 new Transaction()
                 {
                     TransactionId = 3,
                     TickerSymbol = "GOOG",
                     CompanyName = "Alphabet Inc.",
                     Quantity = 100,
                     SharePrice = 146.51
                 },
                 new Transaction()
                 {
                     TransactionId = 4,
                     TickerSymbol = "MSFT",
                     CompanyName = "Microsoft Corporation",
                     Quantity = 100,
                     SharePrice = 397.21
                 }
            ) ;


        }
    }
}
