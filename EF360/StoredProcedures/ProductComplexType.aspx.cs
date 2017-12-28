using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;

namespace EF360CodeOnly.StoredProcedures
{
    public partial class ProductComplexType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Keep in mind: Querying EF conceptual model, not the database
            using (var ctx = new EF360Context())
            {
                //// Retrieve data from stored procedure setup as a Function Import

                //var product = ctx.ComplexTypeSproc("GREAL");
                //// Bind result to GridView control
                //gvComplex.DataSource = product;
                //gvComplex.DataBind();
            }
        }
    }
}