using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Local
{
    public partial class LocalData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                var region = "OR";
                var customerId = "GROWL";
                
                // Add new customer, Growling Dog to customers.
                var customer = new Customer {CustomerID = "GROWL", CompanyName = "Growling Dog", Region = "OR"};
                ctx.Customers.Attach(customer);
                ctx.Entry(customer).State = EntityState.Added;
                ctx.SaveChanges();
                
                // Loads Orgeon customers into DbContext instance.  
                // Load() forces execution of Linq query 
                ctx.Customers.Where(x => x.Region == region).Load();

                // Get reference to DbSet local property, which is typeof IObservable
                var localCustomers = ctx.Customers.Local;

                // Add new customers to local DbContext instance
                localCustomers.Add(new Customer {CustomerID = "MADBR", CompanyName = "Mad Bear", Region = "OR"});

                // Remove 'Growling Dog' from local collection, which replicates to DbContext instance
                // Find first searches context, then, if necessary, queries database
                localCustomers.Remove(ctx.Customers.Find(customerId));

                //Examine contents of context by using 'Local property' of DbContext -- no trip to DB
                //Local Collection: 
                //    Growling Dog excluded as has been marked for deletion
                //    Mad Bear included as has been added, but not yet saved -- key is null
                var customersInContext =
                    localCustomers.Select(
                        x => new {x.CustomerID, x.CompanyName, EntityState = ctx.Entry(x).State.ToString()}).ToList();

                //Examine contents of database -- queries database
                //    Growling Dog marked for deletion
                //    Mad Bear not yet added
                var customersInDatabase = ctx.Customers.Where(x => x.Region == region).ToList()
                    .Where(x => x.Region == region)
                    .Select(x => new {x.CustomerID, 
                        x.CompanyName, 
                        EntityState = ctx.Entry(x).State.ToString()})
                        .ToList();

                gvLocal.DataSource = customersInContext;
                gvLocal.DataBind();

                gvDatabase.DataSource = customersInDatabase;
                gvDatabase.DataBind();

                // Clean Up
                localCustomers.Remove(ctx.Customers.Find("MADBR"));

                ctx.SaveChanges();
                // Purposely update the underlying Carrier table so that the RowVersion value changes
                //ctx.Database.ExecuteSqlCommand(@"DELETE dbo.Customers WHERE CustomerID = 'GROWL'");
            }
        }
    }
}