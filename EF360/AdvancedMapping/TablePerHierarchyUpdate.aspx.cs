using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.AdvancedMapping
{
    public partial class TablePerHierarchyUpdate : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                //-- Create new employee of type "ManagementEmployee"
                //-- Is separate type, but stored in employee table
                var supplier = new PreferredSupplier
                                   {
                                       CompanyName = "Microsoft",
                                       ContactName = "Brian Moore" + new Random().Next(100),
                                       City = "Seattle",
                                       PostalCode = new Random().Next(10000).ToString(),
                                       Country = "United States",
                                       Phone = new Random().Next(10).ToString(),
                                       // Add preferred supplier discounts
                                       PartnerDiscount = new Random().Next(10),
                                       ShippingDiscount = new Random().Next(10),
                                       VolumeDiscountPercent = new Random().Next(10),
                                       SupplierType = ctx.SupplierTypes.FirstOrDefault(x =>x.Description == "Preferred"),
                                   };

                //-- Attach new entity to parent entity, making context aware of the new object
                ctx.Suppliers.Add(supplier);

                //-- Save changes, inserting new row
                ctx.SaveChanges();

                ////-- obtain new primary key value
                var supplierId = supplier.SupplierID;

                var queryNewSupplier = from newSupplier in ctx.Suppliers.OfType<PreferredSupplier>()
                                       where newSupplier.SupplierID == supplierId
                                       select
                                       new
                                           {
                                               newSupplier.CompanyName,
                                               newSupplier.ContactName,
                                               newSupplier.City,
                                               newSupplier.PartnerDiscount,
                                               newSupplier.ShippingDiscount,
                                               newSupplier.VolumeDiscountPercent
                                           };

                gvManager.DataSource = queryNewSupplier.ToList();
                gvManager.DataBind();
            }
        }
    }
}