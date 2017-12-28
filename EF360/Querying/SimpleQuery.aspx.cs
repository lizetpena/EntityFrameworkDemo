using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class SimpleQuery : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _region = "OR";
            var _city = "Elgin";

            using (var ctx = new EF360Context())
            {
                // Demonstate 'Query Syntax'
                var querySyntax = (from c in ctx.Customers
                                   where c.Region == _region
                                         && c.City != _city
                                   orderby c.CompanyName
                                   select c).Skip(1).Take(1);
                                   //select c).Take(1);

                ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                gvQuerySyntax.DataSource = querySyntax.ToList();
                gvQuerySyntax.DataBind();

                //Same query using 'Method Syntax' (extension methods) 
                // with lamda expressions
                var methodSyntax =
                    ctx.Customers.Where(c => c.Region == _region
                        && c.City != _city)
                        .OrderBy(c => c.CompanyName).Skip(1).Take(1);

                gvMethodSyntax.DataSource = methodSyntax.ToList();
                gvMethodSyntax.DataBind();
            }
        }
    }
}