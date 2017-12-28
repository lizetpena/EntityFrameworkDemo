using System;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.AdvancedMapping
{
    public partial class TablePerHierarchyView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve management employees only
            using (var ctx = new EF360Context())
            {
                // Use the OfType<>() method to filter on type, 
                // without using Where Clause
                var query = from supplier in ctx.Suppliers.OfType<PreferredSupplier>()
                            orderby supplier.CompanyName
                            select new
                            {
                                supplier.CompanyName,
                                supplier.ContactName,
                                supplier.City,
                                supplier.Country,
                                supplier.Phone,
                                //-- Properties from derived
                                //-- PreferredSupplier Type
                                supplier.VolumeDiscountPercent,
                                supplier.PartnerDiscount,
                                supplier.ShippingDiscount
                            };

                gvManagement.DataSource = query.ToList();
                gvManagement.DataBind();
            }

            //-- Retrieve all employees
            using (var ctx = new EF360Context())
            {
                //-- Use the OfType<>() method to filter on type, 
                //-- without using Where Clause
                var query = from supplier in ctx.Suppliers.OfType<Supplier>()
                            orderby supplier.CompanyName
                            select new
                            {
                                supplier.CompanyName,
                                supplier.ContactName,
                                supplier.City,
                                supplier.Country,
                                supplier.Phone,
                            };

                gvEmployees.DataSource = query.ToList();
                gvEmployees.DataBind();
            }
        }
    }
}
