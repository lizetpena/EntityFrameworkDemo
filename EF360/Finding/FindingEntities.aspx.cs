using System;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Finding
{
    public partial class FindingEntities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var customerId = "GREAL";
                var customerId2 = "HUNGO";
                
                //Retrieve "Great Lakes Food Market" in "OR" customers
                var GreatlakesFoodMarket = ctx.Customers.Where(x => x.CustomerID == customerId).ToList();
                
                //Find "Great Lakes Food Market" in "OR" customers
                //Because, we query against DbContext, we automatically query database, despite
                //fact that "GreatlakesFoodMarket" is already in memory. Results in unnecessary
                //round-trip to database.
                GreatlakesFoodMarket = ctx.Customers.Where(x => x.CustomerID == customerId).ToList();

                //Use DbSet.Find() method to find entity.
                //Will (1) search context first, and, if not found, then (2) search database
                //Must search by primary key of entity
                var Greal = ctx.Customers.Find(customerId);

                //Next find, an entity (Hungry Owl All-Night Grocers, ID=HUNGO), which is not 
                //loaded in DbContext instance
                var Hungo = ctx.Customers.Find(customerId2);

                //Add new customer to context, but do not commit to data store
                ctx.Customers.Add(new Customer
                                      {
                                          CustomerID = "Customer1234",
                                          Address = "1234 Main Street",
                                          City = "Dallas",
                                          Region = "TX",
                                          CompanyName = "Hungry Shark" + new Random().Next(100),
                                      });

                //Find() will locate new entity in context
                var newCustomer = ctx.Customers.Find("Customer1234");

                //Example of deleting entity from Context by using Remove() method.
                //Marks entity for deletion and removes when SaveChanges() called.
                //Removes from context without calling database.
                var deletedCustomer = ctx.Customers.Remove(newCustomer);

                ctx.SaveChanges();

                //var customers = ctx.Customers.Where(x => x.Region == "OR").ToList();

                //gvFindingEntities.DataSource = customers.ToList();
                //gvFindingEntities.DataBind();
            }
        }
    }
}