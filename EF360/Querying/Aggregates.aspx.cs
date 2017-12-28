using System;
using System.Globalization;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class Aggregates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aggregation Operation (High/Low/Average price for each category)
            using (var ctx = new EF360Context())
            {
                //-- Compiler infrers type                
                var query =
                    from p in ctx.Products
                    group p by p.Category.CategoryID into g
                    // Order from most to least
                    orderby g.Count() descending

                    //-- 'Select new {}' tells compiler to build anon type
                    //-- Anon type becomes our projection, or result set.
                    select new
                    {
                        //-- Demonstrate 'aggegrate query operators'
                        TotalPrice = g.Sum(p => p.UnitPrice),
                        LowPrice = g.Min(p => p.UnitPrice),
                        HighPrice = g.Max(p => p.UnitPrice),
                        AveragePrice = g.Average(p => p.UnitPrice)
                    };

                gvAggregationOperation.DataSource = query.ToList();
                gvAggregationOperation.DataBind();
            }


        }
    }
}