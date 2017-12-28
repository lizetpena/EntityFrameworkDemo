using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Relationships
{
    public partial class ObjectGraph : Page
    {
        //Custom class captures information across the object graph

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //First: Demonstrate Deferred Loading 
                using (var ctx = new EF360Context())
                {
                    var queryProducts = ctx.Customers.Where(c => c.Region == "OR").ToList();

                    listBoxCompany.DataTextField = "CompanyName";
                    listBoxCompany.DataValueField = "CustomerId";
                    listBoxCompany.DataSource = queryProducts.ToList();
                    listBoxCompany.DataBind();
                }
            }

            listBoxCompany.BackColor = Color.FromName("#FFFBD6");
        }

        protected void ListBoxCompanySelectedIndexChanged(object sender, EventArgs e)
        {
            var customerId = listBoxCompany.SelectedValue;

            //Instantiate custom OrderDetailInformation collection objects to capture information across the graph
            var orderDetailCollection = new List<OrderDetailInformation>();

            using (var ctx = new EF360Context())
            {
                ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                switch (RadioButtonLoadingType.SelectedValue)
                {
                    case "0": 
                        // Lazy Loading

                        // Query all orders for Oregon for selected customer -- defer child entities, until explicitly referenced
                        var ordersLazy = (from o in ctx.Orders
                                          where o.CustomerID == customerId
                                          select o);

                        // Iterate through each Order                        
                        foreach (var order in ordersLazy)
                        {
                            var BreakPointOrderStart = "";

                            // Iterate through each OrderDetail                        
                            foreach (var orderDetail in order.OrderDetails)
                            {
                                var BreakPointOrderDetailStart = "";

                                orderDetailCollection.Add(new OrderDetailInformation
                                {
                                    OrderId = orderDetail.OrderID,
                                    ProductId = orderDetail.ProductID,
                                    
                                    // Navigate Product entity to obtain product name
                                    // The reference to a property in the Product entity
                                    // will invoke lazy loading the Product entity
                                    ProductName = orderDetail.Product.ProductName,
                                    Quantity = orderDetail.Quantity,
                                    // Navigate across Product to Supplier entity to obtain company name
                                    // Will Lazy Load related Supplier child data
                                    Supplier = orderDetail.Product.Supplier.CompanyName,
                                    // Navigate across Product to Category entity to obtain category name
                                    // Will Lazy Load related Category child data
                                    Category = orderDetail.Product.Category.CategoryName
                                });

                                var BreakPointOrderDetailEnd = "";
                            }

                            var BreakPointOrderEnd = "";
                        }
                        gvLazy.DataSource = orderDetailCollection.ToList();
                        gvLazy.DataBind();

                        break;

                    case "1": //Eager Loading

                        // Query all orders for Oregon for selected customer -- explicitly include OrderDetails, Products, Suppliers and Categories
                        // Note the two Include clauses as we must follow the navigation paths from Orders to get to Supplier and then to Category
                        var ordersEager = (from o in ctx.Orders
                                               .Include("OrderDetails.Product.Supplier")
                                               .Include("OrderDetails.Product.Category")
                                               //.Include(x => x.OrderDetails.Select(y => y.Product.Supplier))
                                               //.Include(x => x.OrderDetails.Select(y => y.Product.Category))
                                           where o.CustomerID == customerId
                                           select o);

                        // Iterate through each Order                        
                        foreach (var order in ordersEager)
                        {
                            var BreakPointOrderStart = "";

                            // Iterate through each OrderDetail                        
                            foreach (var orderDetail in order.OrderDetails)
                            {
                                var BreakPointOrderDetailStart = "";

                                orderDetailCollection.Add(new OrderDetailInformation
                                {
                                    OrderId = orderDetail.OrderID,
                                    ProductId = orderDetail.ProductID,
                                    // Query to Product entity to get associated product information
                                    ProductName = orderDetail.Product.ProductName,
                                    Quantity = orderDetail.Quantity,
                                    // Query to Supplier entity to get associated supplier information
                                    Supplier = orderDetail.Product.Supplier.CompanyName,
                                    // Query to Category entity to get associated category information
                                    Category = orderDetail.Product.Category.CategoryName
                                });

                                var BreakPointOrderDetailEnd = "";
                            }

                            var BreakPointOrderEnd = "";
                        }

                        gvLazy.DataSource = orderDetailCollection.ToList();
                        gvLazy.DataBind();
 
                        break;
                }
            }
        }

        #region Nested type: OrderDetailInformation

        public class OrderDetailInformation
        {
            public int OrderId { get; set; }
            public int Quantity { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public string Supplier { get; set; }
            public string Category { get; set; }
        }

        #endregion
    }
}

#region Extra Code

//Query all orders for Oregon for selected customer -- defer child entities, until explicitly referenced
//var ordersLazy = (from o in ctx.Orders
//                  where o.CustomerID == customerId
//                  select o).FirstOrDefault(); //.Take(1);

//// Query all orders for Oregon for selected customer -- explicitly include OrderDetails, Products, Suppliers and Categories
//// Note the two Include clauses as we must follow the navigation paths from Orders to get to Supplier and then to Category
//var ordersEager = (from o in ctx.Orders
//                       .Include("OrderDetails.Product.Supplier")
//                       .Include("OrderDetails.Product.Category") 
//                   where o.CustomerID == customerId
//                   select o);

//// Iterate through each Order                        
//foreach (var order in ordersEager)
//{
//    var BreakPointOrderStart = "";

//    // Iterate through each OrderDetail                        
//    foreach (var orderDetail in order.OrderDetails)
//    {
//        var BreakPointOrderDetailStart = "";

//        orderDetailCollection.Add(new OrderDetailInformation
//        {
//                                        OrderId = orderDetail.OrderID,
//                                        ProductId = orderDetail.ProductID,
//                                        // Query to Product entity to get associated product information
//                                        ProductName = orderDetail.Product.ProductName,
//                                        Quantity = orderDetail.Quantity,
//                                        // Query to Supplier entity to get associated supplier information
//                                        Supplier = orderDetail.Product.Supplier.CompanyName,
//                                        // Query to Category entity to get associated category information
//                                        Category = orderDetail.Product.Category.CategoryName
//        });

//        var BreakPointOrderDetailEnd = "";
//    }

//    var BreakPointOrderEnd = "";
//}

//gvLazy.DataSource = orderDetailCollection;
//gvLazy.DataBind();



//// Iterate through each Order                        
//foreach (var order in ordersLazy)
//{
//    var BreakPointOrderStart = "";

//    // Iterate through each OrderDetail                        
//    foreach (var orderDetail in order.OrderDetails)
//    {
//        var BreakPointOrderDetailStart = "";

//        orderDetailCollection.Add(new OrderDetailInformation
//                                      {
//                                          OrderId = orderDetail.OrderID,
//                                          ProductId = orderDetail.ProductID,
//                                          // Query to Product entity to get associated product information
//                                          ProductName = orderDetail.Product.ProductName,
//                                          Quantity = orderDetail.Quantity,
//                                          // Query to Supplier entity to get associated supplier information
//                                          Supplier = orderDetail.Product.Supplier.CompanyName,
//                                          // Query to Category entity to get associated category information
//                                          Category = orderDetail.Product.Category.CategoryName
//                                      });

//        var BreakPointOrderDetailEnd = "";
//    }

//    var BreakPointOrderEnd = "";
//}

//gvLazy.DataSource = orderDetailCollection;
//gvLazy.DataBind();



////Query all orders for Oregon for selected customer -- infer child entities
//orderDetailInformation = (from od in ctx.OrderDetails
//                          where od.Order.ShipRegion == "OR" && od.Order.CustomerID == customerId
//                          select new OrderDetailInformation
//                          {
//                              OrderId = od.OrderID,
//                              ProductId = od.ProductID,
//                              ProductName = od.Product.ProductName,
//                              Quantity = od.Quantity,
//                              UnitPrice = od.UnitPrice,
//                          }).ToList();

////Query all orders for Oregon for selected customer -- infer child entities
//ctx.Orders.Where(o => o.ShipRegion == "OR" && o.CustomerID == customerId)
//    .ForEach(o => o.OrderDetails.ForEach(od => orderDetailInformation.Add( //nested foreach constructs to drill into sequences
//        new OrderDetailInformation
//            {
//                OrderId = od.OrderID,
//                ProductId = od.ProductID,
//                ProductName = od.Product.ProductName,
//                Quantity = od.Quantity,
//                UnitPrice = od.UnitPrice,
//            })));


//// Query all orders for Oregon for selected customer -- infer child entities
//    // Include() method forces eager loading -- retrieves all data with single query -- see SQLProfiler
//    // Chain realted entities together with dot (.) notation
//    // Include(x => x.OrderDetails.Select(y => y.Product))

//    orderDetailInformation = (from od in ctx.OrderDetails.Include("OrderDetails.USAProduct")
//                              where od.Order.ShipRegion == "OR" && od.Order.CustomerID == customerId
//                              select new OrderDetailInformation
//                              {
//                                  OrderId = od.OrderID,
//                                  ProductId = od.ProductID,
//                                  ProductName = od.Product.ProductName,
//                                  Quantity = od.Quantity,
//                                  UnitPrice = od.UnitPrice,
//                              }).ToList();


//  ////ctx.Orders.Include("OrderDetails.USAProduct")
//  //  ctx.Orders.Include(x => x.OrderDetails.Select(y => y.Product))
//  //      .Where(o => o.ShipRegion == "OR" && o.CustomerID == customerId)
//  //      .ForEach(o => o.OrderDetails.ForEach(od => orderDetailInformation.Add( //nested foreach constructs to drill into sequences
//  //          new OrderDetailInformation
//  //          {
//  //              OrderId = od.OrderID,
//  //              ProductId = od.ProductID,
//  //              ProductName = od.Product.ProductName,
//  //              Quantity = od.Quantity,
//  //              UnitPrice = od.UnitPrice,
//  //          })));

//    gvLazy.DataSource = orderDetailInformation;
//    gvLazy.DataBind();




//////var ordersDetailLazy = (from o in ctx.OrderDetails
//////                  where o.OrderID == 10248
//////                  select o).FirstOrDefault();

//////orderDetailCollection.Add(new OrderDetailInformation
//////{
//////    OrderId = ordersDetailLazy.OrderID,
//////    ProductId = ordersDetailLazy.Product.ProductID,
//////    // Query to Product entity to get associated product information
//////    ProductName = ordersDetailLazy.Product.ProductName,
//////    Quantity = ordersDetailLazy.Quantity,
//////    // Query to Supplier entity to get associated supplier information
//////    Supplier = ordersDetailLazy.Product.Supplier.CompanyName,
//////    // Query to Category entity to get associated category information
//////    Category = ordersDetailLazy.Product.Category.CategoryName
//////});


////// var ordersDetailEager = (from o in ctx.OrderDetails
//////                  .Include("Product.Supplier")
//////                  .Include("Product.Category")
//////                  where o.OrderID == 10248
//////                  select o).FirstOrDefault();

//////orderDetailCollection.Add(new OrderDetailInformation
//////{
//////    OrderId = ordersDetailEager.OrderID,
//////    ProductId = ordersDetailEager.Product.ProductID,
//////    // Query to Product entity to get associated product information
//////    ProductName = ordersDetailEager.Product.ProductName,
//////    Quantity = ordersDetailEager.Quantity,
//////    // Query to Supplier entity to get associated supplier information
//////    Supplier = ordersDetailEager.Product.Supplier.CompanyName,
//////    // Query to Category entity to get associated category information
//////    Category = ordersDetailEager.Product.Category.CategoryName
//////});
#endregion