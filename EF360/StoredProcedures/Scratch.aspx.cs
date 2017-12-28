using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.StoredProcedures
{
    public partial class Scratch : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Keep in mind: Querying EF conceptual model, not the database
            using (var ctx = new EF360Context())
            {
                var result = ctx.GetUnitPricing("GREAL");

                // Retrieve data from stored procedure setup as a Function Import
                // This query returns all columns from the Product table
                //var result = ctx.GetComplexTypeMethod("GREAL");
                //gvTopTen.DataSource = result.ToList();
                //gvTopTen.DataBind();
            }
        }
    }
}

