using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;
using DAL.Model;

namespace EF360CodeOnly.StoredProcedures
{
    public partial class UpdateEmployee : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new EF360Context())
                {
                    ctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    #region Ignore for Demo -- Create 'Before Result Set'

                    var first = ctx.Employees.FirstOrDefault();
                    var queryBefore =
                        ctx.Employees.Where(x => x.EmployeeID == first.EmployeeID)
                            .Select(y => new {y.EmployeeID, y.LastName, y.FirstName, y.City, y.PostalCode});

                    gvBefore.DataSource = queryBefore.ToList();
                    gvBefore.DataBind();

                    #endregion

                    // Get First Employee
                    var employee = ctx.Employees.FirstOrDefault();

                    // Peak into 'state' of customer entity, 
                    // as tracked by the context object
                    var state = ctx.Entry(employee).State;

                    // Peak into 'initial values' of current entity, 
                    // as cached by the Context object
                    var address = ctx.Entry(employee).Property(x => x.Address).OriginalValue;
                    var city = ctx.Entry(employee).Property(x => x.City).OriginalValue;
                    var zip = ctx.Entry(employee).Property(x => x.PostalCode).OriginalValue;

                    // Modify postal code
                    employee.PostalCode = (int.Parse(employee.PostalCode) + 1).ToString();

                    // Modifications will have changed 'State' of entity
                    state = ctx.Entry(employee).State;

                    // Peak into 'current values' of current entity, 
                    // as cached by the Context object
                    address = ctx.Entry(employee).Property(x => x.Address).CurrentValue;
                    city = ctx.Entry(employee).Property(x => x.City).CurrentValue;
                    zip = ctx.Entry(employee).Property(x => x.PostalCode).CurrentValue;

                    // Perform Update
                    // Call SumbitChanges() to commit our change.
                    // Based upon state of the current entity, entity framework will
                    // build appropriate Update and update both Developer and Order tables
                    ctx.SaveChanges();

                    // Check entity state again
                    state = ctx.Entry(employee).State;

                    // Call SaveChanges again -- this time no update
                    ctx.SaveChanges();

                    // Requery Category from database
                    var queryAfter =
                        ctx.Employees.Where(x => x.EmployeeID == employee.EmployeeID)
                            .Select(y => new {y.EmployeeID, y.LastName, y.FirstName, y.City, y.PostalCode});

                    gvAfter.DataSource = queryAfter.ToList();
                    gvAfter.DataBind();
                }
            }
        }


        private static string PeakIntoEntityState<T>(T targetEntity, ObjectContext ctx)
        {
            ////Peak into 'state' of current entity, as tracked by ObjectStateManager, 
            ////which we reference from the underlying ObjectContext object
            ObjectStateEntry entityState = null;
            return ctx.ObjectStateManager.TryGetObjectStateEntry(targetEntity, out entityState)
                ? entityState.State.ToString()
                : string.Empty;
        }

        private static string PeakInitialValues<T>(T targetEntity, string field, ObjectContext ctx)
        {
            return ctx.ObjectStateManager.GetObjectStateEntry(targetEntity).OriginalValues[field].ToString();
        }

        private static string PeakChangedValues<T>(T targetEntity, string field, ObjectContext ctx)
        {
            return ctx.ObjectStateManager.GetObjectStateEntry(targetEntity).CurrentValues[field].ToString();
        }
    }
}