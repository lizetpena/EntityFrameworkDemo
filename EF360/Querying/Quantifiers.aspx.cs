using System;
using System.Globalization;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class Quantifiers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Quantifying Operation 
            using (var ctx = new EF360Context())
            {
                // Quantifying Operation  (Are there any records in the sequence?)
                var anyCustomers = ctx.Customers.Any();

                gvAnyCustomers.DataSource = anyCustomers.ToString(CultureInfo.InvariantCulture);
                gvAnyCustomers.DataBind();

                // Quantifying Operation  (Are there any customers in TX?)
                var anyCustomersInTX = ctx.Customers.Any(c => c.Region == "TX");

                gvCustomersInTX.DataSource = anyCustomersInTX.ToString(CultureInfo.InvariantCulture);
                gvCustomersInTX.DataBind();
            }
        }
    }
}