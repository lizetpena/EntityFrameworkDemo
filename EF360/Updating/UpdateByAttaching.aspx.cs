using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;

namespace EF360CodeOnly.Updating
{
    public partial class UpdateByAttaching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        //Attaching Entities: http://msdn.microsoft.com/en-us/library/gg696174(v=vs.103).aspx
        //When you execute a query in a context, the returned entities are automatically attached to the context (unless you use the AsNoTracking method to execute the query). The entities are attached in the Unchanged state. You can also attach entities that are obtained from a source other than a query and are known to already exist in the database by using the System.Data.Entity.DbSet.Attach( method. 
        //In the following example, the GetExistingDepartment method returns the Department entity that exists in the database. This entity could have been queried for and updated in another thread or another tier, and now needs to be attached to this context before saving changes.

        //var existingDpt = GetExistingDepartment();
        //using (var context = new SchoolEntities ()) 
        //{
        //    context.Departments.Attach(existingDpt);
        //    // When setting the entry state to Modified
        //    // all the properties of the entity are marked as modified.
        //    context.Entry(existingDpt).State = EntityState.Modified;
        //    context.SaveChanges(); 
        //}




// Tip: 



//If the entity being attached has related entities, those entities are also attached to the context in the Unchanged state.






            using (var ctx = new EF360Context())
            {
                var customer = new Customer
                                   {
                                       CustomerID = "60861",
                                       ContactTitle = "John Smith",
                                       CompanyName = "Microsoft"
                                   };

                ctx.Customers.Attach(customer);

                ctx.Entry(customer).State = EntityState.Modified;

                ctx.SaveChanges();
            }

        }
    }
}