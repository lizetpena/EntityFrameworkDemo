using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.StoredProcedures
{
    public partial class TopTen : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Keep in mind: Querying EF conceptual model, not the database
            using (var ctx = new EF360Context())
            {
                // Retrieve data from stored procedure setup as a Function Import
                // This query returns all columns from the Product table
                var topTenRaw = ctx.TenMostExpensiveProducts();

                // As all columns for the table are returned, use Linq query with anonymous type 
                // to filter for columns that are needed. This Linq query also forces enumeration.
                var topTen = topTenRaw.Select(x => new { x.ProductID, x.ProductName, x.UnitPrice });

                // Bind result to GridView control
                gvTopTen.DataSource = topTen.ToList();
                gvTopTen.DataBind();
            }
        }
    }
}

#region Complex Type

               //var topTenFromComplexType = ctx.TenMostExpensiveProductsComplexType();
               // // Bind result to GridView control
               // gvTopTen.DataSource = topTenFromComplexType;
               // gvTopTen.DataBind();

//using (var ctx = new EF360Context())
//{
//    //-- Retrieve from stored procedure setup as a Function Import
//    var query = ctx.ProductGet(1);
//    gvTopTen.DataSource = query;
//    gvTopTen.DataBind();
//}

#endregion