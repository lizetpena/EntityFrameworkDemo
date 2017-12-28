using System;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.AdvancedMapping
{
    public partial class EntitySplittingUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                //-- Add new employee which maps to employee table
                var employee = new Employee
                                   {
                                       //-- Add general information to Employee table
                                       FirstName = "Bill",
                                       LastName = "Gates" + new Random().Next(100),
                                       PostalCode = new Random().Next(10000).ToString(),
                                       //-- Add SSN which maps to EmployeePersonal table
                                       SSN = new Random().Next(1000000000).ToString(),
                                       //-- Add employee financial information which maps to EmployeeFinancial Table
                                       CreditScore = new Random().Next(100),
                                       CorporateRiskScore = new Random().Next(9)
                                   };

                ctx.Employees.Add(employee);
                var result = ctx.SaveChanges();

                //-- Get new product key
                int employeeId = employee.EmployeeID;

                var query = from emp in ctx.Employees
                            where emp.EmployeeID == employeeId
                            select new
                            {
                                emp.FirstName,
                                emp.LastName,
                                emp.PostalCode,
                                emp.CreditScore,
                                emp.CorporateRiskScore,
                                emp.SSN
                            };

                gvEntitySplitting.DataSource = query.ToList();
                gvEntitySplitting.DataBind();
            }
        }
    }
}

#region Extra Code

//-- Add new record to Products context
//ctx.AddToProducts(product);                

//-- Insert a new product into an existing category.
//-- When the newly created product is joined with the Category, 
//-- because ObjectContext is managing the Category, the context
//-- will recognize that it needs to create a new ObjectStateEntry
//-- for the Product. Because the Product has no identity key, 
//-- its EntityState will be set to Added. When SaveChanges is called,
//-- because EntityState is Added an Insert command is constructed and
//-- sent to the database. (Lerhman 5-3)

//-- The last thing to point out in the command is that one of the fields 
//-- in the Insert command is the CatgoryID. Remember that the Product entity 
//-- does not have a CategoryID property. The relationship between Category 
//-- and Product is through the 'navigation properties,' and it is the mappings
//-- that interact with the CategoryID foreign key value. When SaveChanges is 
//-- called, part of the process that creates the native command identifies the 
//-- relationship and uses the mappings in the model to determine that the CategoryID 
//-- of the related Category needs to be used for the CategoryID field of the 
//-- Product being inserted into the database.


//using (NorthwindEFEntities ctx = new NorthwindEFEntities())
//{

//    ////IQueryable<Employee> employee = from emp in ctx.Employees
//    ////            where emp.EmployeeID < 6
//    ////            select emp;

//    ////foreach (var x in employee)
//    ////{
//    ////    x.YearsMarried++;
//    ////}

//    //////ctx.SaveChanges();

//    //////var query = from emp in ctx.Employees
//    //////            where emp.EmployeeID < 6
//    //////            select new { EmployeeID = emp.EmployeeID, FirstName = emp.FirstName, LastName = emp.LastName, SSN = emp.SSN, YearsMarried = emp.YearsMarried, NumChildren = emp.NumberOfChildred };

//    //////gvEF.DataSource = query;
//    //////gvEF.DataBind();
//}






//Product product = new Product();

////-- Add general product information that
////-- maps to Products table
//product.ProductName = "Super Skim Milk";
//product.ReorderLevel = 3;
//product.Discontinued = false;
//product.QuantityPerUnit = "3";
//product.UnitPrice = 10;
//product.UnitsInStock = 6000;

////-- Add SecretDiscount, which maps to 
////-- ProductsConfidential table
//product.SecretDiscount = 5;

////-- Add KickBackPercentage, which maps to 
////-- ProductsSensitive table
//product.KickBackPercentage = 7;

////-- To satisfy the ForeignKey constraint from products to categories,
////-- we retrieve the category record that we need and populate the
////-- product.Category requirement with it.
//var category = ctx.Categories.Where(c => c.CategoryID == 4).First();
//product.Category = category;


//ctx.SaveChanges();

////-- Get new product key
//int productKey = product.ProductID;

//var query = from p in ctx.Products
//            where p.ProductID == productKey
//            select p;

#endregion

