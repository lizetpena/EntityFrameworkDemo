using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;

namespace GettingStarted.UI.EFAdvancedMapping
{
    public partial class OneToOneRelationship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                //-- (1)This time we query products table
                //--    and retrieve a single record with CategoryID == 1.
                //var query =
                //    from s in ctx.Suppliers.Include("SupplierTaxInfo.SupplierSolvent")
                //    where s.SupplierID == 1
                //    select s;

                //List<string> products = new List<string>();

                //gvEF.DataSource = products;
                //gvEF.DataBind();

            }
        }
    }
}
