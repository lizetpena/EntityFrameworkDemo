using System;
using System.Globalization;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class GroupBy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Grouping Operation - Query Syntax
            // Number of Products in each Category
            using (var ctx = new EF360Context())
            {
                // Perform operation with query syntax
                var query = from x in ctx.Products
                            where x.UnitPrice >= 20
                            group x by x.CategoryID
                            into g
                            select new
                                {
                                    Category = g.Key,
                                    CateogryCount = g.Count()
                                };
                gvGroupingQuerySyntax.DataSource = query.ToList();
                gvGroupingQuerySyntax.DataBind();

                // Grouping Operation - Method Syntax
                // Perform operation with fluent method syntax
                var groupingExample =
                    ctx.Products.Where(p => p.UnitPrice >= 20)
                        .GroupBy(p => p.CategoryID)
                        .Select(g => new { Category = g.Key, CateogryCount = g.Count() });

                gvGroupingMethodSyntax.DataSource = groupingExample.ToList();
                gvGroupingMethodSyntax.DataBind();
            }
        }
    }
}