using System;
using System.Globalization;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class Set : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Simple Set Operation (Customers in both OR and WA)
            using (var ctx = new EF360Context())
            {
                var orCustomers = ctx.Customers.Where(c => c.Region == "OR");
                var waCustomers = ctx.Customers.Where(c => c.Region == "WA");
                var queryUnion = orCustomers.Union(waCustomers);

                gvSetOperation.DataSource = queryUnion.ToList();
                gvSetOperation.DataBind();
            }
        }
    }
}