using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;

namespace EF360CodeOnly.Relationships
{
    public partial class UsingIncludeWithOtherLinqOperators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _region = "OR";
            var _city = "Elgin";

            using (var ctx = new EF360Context())
            {
                //Same query using 'Method Syntax' with different order
                var oregonCustomers =
                    ctx.Customers.Where(x => x.Region == _region && x.City != _city)
                        .GroupBy(x => x.Region);

                var result = oregonCustomers.Include("Regions").First();
                    
                
                //.Include(x => x.Orders)
                //    .Select(x => new { x.CustomerID, x.CompanyName, x.Orders.FirstOrDefault(y => y.OrderID > 1).OrderID });

                gvInclude.DataSource = result.ToList();
                gvInclude.DataBind();

                //Same query using 'Method Syntax' with different order
                var oregonCustomers2 =
                    ctx.Customers.Include(x => x.Orders).Where(c => c.Region == _region && c.City != _city)
                        .OrderBy(c => c.CompanyName)
                        .ThenBy(c => c.City)
                        .Select(x => new { x.CustomerID, x.CompanyName, x.Orders.FirstOrDefault(y => y.OrderID > 1).OrderID });

                gvInclude.DataSource = oregonCustomers2.ToList();
                gvInclude.DataBind();
            }
        }
    }
}