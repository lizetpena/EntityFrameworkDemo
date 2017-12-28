using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class QueryMethodOrder : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _region = "OR";
            var _city = "Elgin";

            using (var ctx = new EF360Context())
            {
                //Same query using 'Method Syntax' with different order
                var query1 =
                    ctx.Customers.Where(c => c.Region == _region && c.City != _city)
                        .OrderBy(c => c.CompanyName)
                        .ThenBy(c => c.City)
                        .Select(c => new { c.CompanyName, c.Region, c.City });

                gvQuery1.DataSource = query1.ToList();
                gvQuery1.DataBind();

                //Same query using 'Method Syntax' with different order
                var query2 =
                    ctx.Customers.OrderBy(c => c.CompanyName)
                        .ThenBy(c => c.City)
                        .Where(c => c.Region == _region && c.City != _city)
                        .Select(c => new { c.CompanyName, c.Region, c.City });

                gvQuery2.DataSource = query2.ToList();
                gvQuery2.DataBind();

                //Same query using 'Method Syntax' with different order
                var query3 =
                    ctx.Customers.Select(c => new {c.CompanyName, c.Region, c.City})
                       .Where(c => c.Region == _region && c.City != _city)
                       .OrderBy(c => c.CompanyName)
                       .ThenBy(c => c.City);

                gvQuery3.DataSource = query3.ToList();
                gvQuery3.DataBind();

                //Same query using 'Method Syntax' with different order
                var query4 =
                    ctx.Customers.Where(c => c.Region == _region && c.City != _city)
                        .Select(c => new { c.CompanyName, c.Region, c.City })
                        .OrderBy(c => c.CompanyName)
                        .ThenBy(c => c.City);

                gvQuery4.DataSource = query4.ToList();
                gvQuery4.DataBind();
            }
        }
    }
}