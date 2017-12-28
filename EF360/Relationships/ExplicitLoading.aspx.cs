using System;
using System.Data.Entity;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Relationships
{
    public partial class ExplicitLoading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var customerId = "LONEP";

                // Explicitly disable Lazy Loading in order to Explicitly load
                ctx.Configuration.LazyLoadingEnabled = false;

                // Demonstrate usage of explicit loading by explicitly fetching child data
                // First, fetch given customer
                var customer = ctx.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                // Then, explicitly load orders for given customer.
                // Note the following code construct that explicitly loads related data:
                //    Entry() exposes information about the Customer entity from context object
                //    Collection() sets up a query to retrieve
                //       child data for the Orders navigation property
                //    Load() executes the query against database and fetches data
                ctx.Entry(customer)
                    .Collection(x => x.Orders)
                    .Load();

                // Reshape data to show selected properties for orders.
                // Note that this command does not execute a database command, as Customer and 
                // Order data has already been fetched into the context object.
                var orders =
                    customer.Orders.Select(
                        x => new
                        {
                            x.OrderID, 
                            x.OrderDate, 
                            x.ShipName, 
                            x.Freight, 
                            x.ShipCity, 
                            x.ShipRegion,
                        }).ToList();

                gvExplicit.DataSource = orders;
                gvExplicit.DataBind();

                // Fetch another customer
                customer = ctx.Customers.FirstOrDefault(x => x.CustomerID == "THEBI");

                // Explicit Loading with Load() provides opportunity to filter 
                // related (or child) data obtained from Include() method. Normally, 
                // you cannot filter child data fetched with an Include construct.

                // Explicitly load orders for given customer.
                // Note the following code construct to explicitly load related data:
                //    Entry() exposes information about the customer entity from context object
                //    Collection() sets up query to retrieve child data 
                //       from Orders navigation property
                //    Query() generates a query to load child objects
                //    Include() eager loads OrderDetails
                //    Where() filters the child, or Order, data
                //    Load() executes the query against database and fetches data
                ctx.Entry(customer)
                    .Collection(x => x.Orders)
                    .Query()
                    // Eager load OrderDetails
                    .Include(y => y.OrderDetails)
                    // Ability to filter child entities. Cannot normally do this from
                    // an Include() method 
                    .Where(y => y.OrderDetails.Any(z => z.Quantity < 5))
                    .Load();

                // Reshape data to show select properties for orders 
                var filteredOrders =
                    customer.Orders.FirstOrDefault()
                        .OrderDetails.Select(x => new
                        {
                            x.ProductID, 
                            x.Quantity, 
                            x.UnitPrice
                        });

                gvExplicitFiltered.DataSource = filteredOrders;
                gvExplicitFiltered.DataBind();

                // Reenable Lazy Loading which is default loading behavior
                ctx.Configuration.LazyLoadingEnabled = true;
            }
        }
    }
}