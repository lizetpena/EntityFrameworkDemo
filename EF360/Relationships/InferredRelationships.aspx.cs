using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Relationships
{
    public partial class InferredRelationships : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                //Explicit Joins 
                //Query across Order Deatils, Orders, Customers and Products
                var queryExplicit =
                    (from od in ctx.OrderDetails  
                     join o in ctx.Orders on od.OrderID equals o.OrderID
                     join p in ctx.Products on od.ProductID equals p.ProductID
                     join c in ctx.Customers on o.CustomerID equals c.CustomerID
                     where od.OrderID == 10248
                     //-- Notice how we traverse navigation properties
                     select new
                                {
                                    c.CompanyName,
                                    o.OrderID,
                                    o.Freight,
                                    od.ProductID,
                                    p.ProductName,
                                    od.UnitPrice,
                                    od.Quantity,
                                });

                gvJoin.DataSource = queryExplicit.ToList();
                gvJoin.DataBind();

                //Inferred Joins
                //Leverage associations between entities, 
                //exposed as navigation property, avoiding explicit joins
                var queryInfer = from od in ctx.OrderDetails
                                 where od.OrderID == 10248
                                 select new
                                            {
                                                od.Order.Customer.CompanyName,
                                                od.OrderID,
                                                od.Order.Freight,
                                                od.ProductID,
                                                od.Product.ProductName,
                                                od.UnitPrice,
                                                od.Quantity,
                                            };

                gvInferred.DataSource = queryInfer.ToList();
                gvInferred.DataBind();
            }
        }
    }
}