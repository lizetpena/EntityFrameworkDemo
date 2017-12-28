using System;
using System.Data.Entity;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Updating
{
    public partial class Updates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new EF360Context())
                {
                    #region Ignore for Demo -- Create 'Before Result Set'

                    var queryBefore =
                        from c in ctx.Customers.Include("Orders")
                        where c.CustomerID == "LONEP"
                        select new
                        {
                            c.Address,
                            c.City,
                            c.CompanyName,
                            c.ContactName,
                            c.PostalCode,
                            FreightCosts = c.Orders.FirstOrDefault().Freight
                        };

                    gvInsertBefore.DataSource = queryBefore.ToList();
                    gvInsertBefore.DataBind();

                    #endregion

                    // Update Code
                    // Note the use of Include() to eager join Orders with Developer
                    var customer = ctx.Customers.Include(x => x.Orders).SingleOrDefault(c => c.CustomerID == "LONEP");

                    // Peak into 'state' of customer entity, 
                    // as tracked by the context object 
                    var state = ctx.Entry(customer).State;

                    // Peak into 'initial values' of current entity, 
                    // as tracked by the context object 
                    var address = ctx.Entry(customer).Property(x => x.Address).OriginalValue;
                    var city = ctx.Entry(customer).Property(x => x.City).OriginalValue;
                    var zip = ctx.Entry(customer).Property(x => x.PostalCode).OriginalValue;

                    // Modify postal code
                    customer.PostalCode = (int.Parse(customer.PostalCode) + 1).ToString();

                    // Modify freight charge
                    // Get freight charge for first order
                    var freight = Convert.ToInt32(customer.Orders.FirstOrDefault().Freight);
                    // Increase frieght charge by $1.00
                    customer.Orders.FirstOrDefault().Freight = freight + 1;

                    // Modifications will have changed 'State' of entity
                    state = ctx.Entry(customer).State;

                    // Peak into 'current values' of current entity
                    address = ctx.Entry(customer).Property(x => x.Address).CurrentValue;
                    city = ctx.Entry(customer).Property(x => x.City).CurrentValue;
                    zip = ctx.Entry(customer).Property(x => x.PostalCode).CurrentValue;

                    // Perform Update
                    // Call SumbitChanges() to commit our change.
                    // Based upon state of the current entity, entity framework will
                    // build appropriate Update and update both Developer and Order tables
                    ctx.SaveChanges();

                    var currentCustomerZip = customer.PostalCode;

                    // Check entity state again
                    state = ctx.Entry(customer).State;

                    // Call SaveChanges again -- this time no update
                    ctx.SaveChanges();

                    #region Ignore -- Create 'After Result Set'

                    var queryAfter =
                        from c in ctx.Customers
                        where c.CustomerID == "LONEP"
                        select new
                        {
                            c.Address,
                            c.City,
                            c.CompanyName,
                            c.ContactName,
                            c.PostalCode,
                            FreightCosts = c.Orders.FirstOrDefault().Freight
                        };

                    #endregion

                    gvInsertAfter.DataSource = queryAfter.ToList();
                    gvInsertAfter.DataBind();
                }
            }
        }
    }
}