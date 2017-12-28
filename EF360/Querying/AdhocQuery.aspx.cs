using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Querying
{
    public partial class AdhocQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                // Build adhoc parameterized SQL statement
                var sql = "select * from customers where region=@Region";

                // Build strongly-typed parameter, note how we add precision 
                // to help minimize SQL injection attacks
                var parameter = new DbParameter[]
                {
                    new SqlParameter
                    {
                        DbType = DbType.String,
                        Precision = 2,
                        ParameterName = "Region",
                        Value = "OR",
                    }
                };

                // Leverage SQLQuery() method from Database property to execute.
                // Result is a materialized, strongly-typed collection of customers.
                var query = ctx.Database.SqlQuery<Customer>(sql, parameter);

                gvQuerySyntax.DataSource = query.ToList();
                gvQuerySyntax.DataBind();

                // Next, leverage ExecuteSqlCommand() method to add and then delete data
                sql = @"Insert into customers(CustomerId, CompanyName) values(@p0, @p1)";
                // Note that the SaveChanges() command is unnessecary as we are 
                // directly accessing the database
                var rowcount = ctx.Database.ExecuteSqlCommand(sql, "abcde", "Test Customer");

                // Next, leverage ExecuteSqlCommand() method to add and then delete data
                sql = @"delete from customers where CompanyName=@p0";
                // Note that the SaveChanges() command is unnessecary as we are 
                // directly accessing the database
                rowcount = ctx.Database.ExecuteSqlCommand(sql, "Test Customer");
            }
        }
    }
}