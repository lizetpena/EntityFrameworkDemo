using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using DAL.Model;
using DALOrdering;

namespace EF360CodeOnly.Updating
{
    public partial class ExplicitTransactions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerId = "LONEP";
                var errorMessage = string.Empty;

                #region Ignore for Demo -- Create 'Before Result Set'

                using (var ctx = new EF360Context())
                {
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

                    // Use TransactionScope class to perform distributed transaction.
                    // TransactionScope leveages the MTC (Microsoft Transaction Coordinator)
                    // which can be expensive.
                    using (var transactionScope = new TransactionScope())
                    {
                        try
                        {
                            UpdateMainContext(customerId);
                            UpdateOrderingContext(customerId);
                        }
                        catch (Exception ex)
                        {
                            if (ex.GetType() != typeof (UpdateException))
                                errorMessage = ex.Message;
                            else
                                errorMessage = ex.InnerException.Message;
                        }

                        // Must call transaction.Complete() or
                        // changes will be rolled back
                        transactionScope.Complete();
                    }

                    using (var ctx2 = new EF360Context())
                    {
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

        private void UpdateOrderingContext(string customerId)
        {
            using (var orderingContext = new EF360Ordering())
            {
                var orders = orderingContext.Orders.Where(x => x.CustomerID == customerId);

                // Modify freight charge
                // Get freight charge for first order
                var freight = Convert.ToInt32(orders.FirstOrDefault().Freight);
                //// Increase frieght charge by $1.00
                orders.FirstOrDefault().Freight = freight + 1;
                orderingContext.SaveChanges();
            }
        }

        private void UpdateMainContext(string id)
        {
            // Generate transaction across multiple contexts
            using (var ctx = new EF360Context())
            {
                // Update Code
                var customer = ctx.Customers.SingleOrDefault(c => c.CustomerID == id);

                // Modify postal code
                customer.PostalCode = (int.Parse(customer.PostalCode) + 1).ToString();
                ctx.SaveChanges();
            }
        }
    }
}