using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
//using Common.ExtensionClasses;

namespace EF360CodeOnly.Relationships
{
    public partial class ExplicitRelationships : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listBoxSupplierTypes.Items.Add(new ListItem("Standard", "1"));                
                listBoxSupplierTypes.Items.Add(new ListItem("Preferred", "2"));                
                listBoxSupplierTypes.Items.Add(new ListItem("Partner", "3"));                
                listBoxSupplierTypes.Items.Add(new ListItem("Partner", "4"));                
                listBoxSupplierTypes.Items.Add(new ListItem("Invalid", "1"));                
            }
            
            
            
            using (var ctx = new EF360Context())
            {
                var queryExplicit =
                    (from x in ctx.Suppliers
                    where x.SupplierType.ID == 1
                    select new
                               {
                                   x.SupplierID,
                                   x.CompanyName,
                                   x.Address,
                                   x.City,
                                   x.Region,
                                   x.PostalCode,
                                   x.Phone,
                                   x.Fax
                               }).Take(5);

                //var queryExplicit = ctx.SupplierTypes.Where(x => x.ID == 1).ForEach(y =>
                //{
                    
                //});

                gvExplicit.DataSource = queryExplicit.ToList();
                gvExplicit.DataBind();

            }


        }

        protected void ListBoxCompanySelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}