using System;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.AdvancedMapping
{
    public partial class EntitySplittingView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                // Will retrieve only records which contain records in all three product tables. 
                // Note in designer how both EmployeeFinacial and EmployeePersonal are both mapped to Employees
                var query = from emp in ctx.Employees
                            orderby emp.LastName descending
                            select new
                            {
                                emp.EmployeeID,
                                emp.FirstName,
                                emp.LastName,
                                emp.HireDate,
                                emp.PostalCode,
                                // Information from EmployeeFinancial Table
                                emp.CreditScore,
                                emp.CorporateRiskScore,
                                // Information from EmployeePersonal Table
                                emp.SSN
                            };

                gvEntitySplitting.DataSource = query.ToList();
                gvEntitySplitting.DataBind();
            }
        }
    }
}
