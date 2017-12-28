using System;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class Projection : Page
    {
        #region Concrete Class Definition

        //-- Concrete type to represent each object in sequence
        public class ProductInformation
        {
            public string ProductName { get; set; }
            public decimal? UnitPrice { get; set; }
            public short? UnitsInStock { get; set; }
            public short? UnitsOnOrder { get; set; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Project Entire Sequence
            //-- Filter on price < $20, taking first 5 records,
            //-- Return entire entity. 
            using (var ctx = new EF360Context())
            {
                var queryEntireObject = (from p in ctx.Products
                                         where p.UnitPrice < 20
                                         select p).Take(5);
                gvEntireObject.DataSource = queryEntireObject.ToList();
                gvEntireObject.DataBind();
            }


            //-- Project Single Element
            //-- Return products whose name begins with "C", skipping
            //-- the first 4 products that begin with "C".  
            //-- Return single value (product name)
            using (var ctx = new EF360Context())
            {
                var querySingleValue = (from p in ctx.Products
                                        where p.ProductName.StartsWith("C")
                                        orderby p.ProductName
                                        select p.ProductName).Skip(4).Take(5);
                gvSingeValue.DataSource = querySingleValue.ToList();
                gvSingeValue.DataBind();
            }

            //-- Project Multiple Elements - Anonymous Type
            //-- Next, demonstrate type inference by /projecting against anon type.
            //-- Compiler 'infers' type from right-hand side of expression
            //-- Hover over var to show inferred type
            using (var ctx = new EF360Context())
            {
                //-- Compiler infrers type                
                var query = (from p in ctx.Products
                    where p.ProductName.StartsWith("C")
                    orderby p.ProductName
                    select new
                    {
                        p.ProductName,
                        p.UnitPrice,
                        p.UnitsInStock,
                        p.UnitsOnOrder
                    }).Skip(4).Take(5);     
                   
                gvInfer.DataSource = query.ToList();
                gvInfer.DataBind();
            }

            //-- Project Multiple Elements - Concrete Type
            //-- Explicilty specifiy concrete class 
            //-- IQueryable variable of type 'LongHandResultSet'
            using (var ctx = new EF360Context())
            {
                //-- Specify concrete class
                var query2 = (from p in ctx.Products
                    where p.ProductName.StartsWith("C")
                    orderby p.ProductName
                    select new ProductInformation
                    {
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        UnitsInStock = p.UnitsInStock,
                        UnitsOnOrder = p.UnitsOnOrder
                    }).Skip(4).Take(5); ;   

                gvExplicit.DataSource = query2.ToList();
                gvExplicit.DataBind();
            }
        }
    }
}