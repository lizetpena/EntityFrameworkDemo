using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Updating
{
    public partial class BasicInserting : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new EF360Context())
                {
                    // Insert Data
                    // Add new "unattached" category entity
                    var category = new Category
                    {
                        CategoryName = "FoodType" + new Random().Next(100)
                    };

                    // Add new "unattached" product entity
                    var product = new Product
                    {
                        ProductName = "NewProduct" + new Random().Next(100),
                        QuantityPerUnit = "10",
                        UnitPrice = 10,
                    };

                    // Add new "unattached" supplier entity
                    var supplier = new Supplier()
                    {
                        CompanyName = "CompanyName" + new Random().Next(100),
                        // Get supplier type entity object
                        SupplierType = ctx.SupplierTypes.Single(x => x.ID == 1),
                    };

                    // Peak into ObjectStateManager
                    // Determine 'state' of each entity
                    var category2State = ctx.Entry(category).State;
                    var product2State = ctx.Entry(product).State;
                    var supplier2State = ctx.Entry(supplier).State;

                    // Fun begins here
                    // Step #1: Attach new grandchild (supplier) to new child (product)
                    // Leveraging inferred relationship
                    product.Supplier = supplier;

                    // Step #2: Attach new child (product) to new parent (category)
                    // Leveraging inferred relationship
                    category.Products.Add(product);

                    // Step #3: Add object graph to context
                    // Can explicitly assign entity state of 'Added' which attaches entire
                    // graph with state of 'Added'
                    //ctx.Entry(category).State = EntityState.Added;

                    // Can ADD object graph to context which also attaches entire
                    // graph with state of 'Added'
                    ctx.Categories.Add(category);

                    ////// Demonstrate fix-up
                    ////ctx.Suppliers.Add(supplier);
                    ////ctx.Products.Add(product);
                    ////ctx.DetectChanges();
                    
                    // Peak into ObjectStateManager
                    category2State = ctx.Entry(category).State;
                    product2State = ctx.Entry(product).State;
                    supplier2State = ctx.Entry(supplier).State;

                    // EF generates 'insert' statements
                    // Because of inferred relationship, EF will:
                    //   1) Insert parent (Category) and grabs new categoryId
                    //   2) Insert child (Supplier) with new supplierId as FK.
                    //   3) Insert child (USAProduct) with new categoryId as FK.
                    //   4) Return Identity values for each and insert into entity objects.
                    ctx.SaveChanges();

                    // Retrieve new primary key values.
                    // EF has automatically inserted new primary keys into exsiting entities
                    var newCateoryId = category.CategoryID;
                    var newProductId = product.ProductID;
                    var supplierId = supplier.SupplierID;

                    #region Requery database

                    var requeryDatabase =
                        // Eager loading using strongly-typed operators
                        from p in ctx.Products.Include(x => x.Category).Include(x => x.Supplier)
                        where p.ProductID >= newProductId
                        select new
                        {
                            CategoryName = category.CategoryName,
                            CategoryId = category.CategoryID,
                            ProductName = product.ProductName,
                            ProductId = product.ProductID,
                            product.UnitPrice,
                            product.QuantityPerUnit,
                            SupplierType = supplier.SupplierType.Description,
                            SupplierName = supplier.CompanyName,
                        };

                    #endregion

                    gvEF.DataSource = requeryDatabase.ToList();
                    gvEF.DataBind();
                }
            }
        }
    }
}