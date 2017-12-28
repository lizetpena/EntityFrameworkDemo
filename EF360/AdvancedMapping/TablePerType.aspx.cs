using System;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.AdvancedMapping
{
    public partial class TablePerType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                //-- StateTaxAudit entity "inherits" from TaxAudit entity.
                //-- No longer need to navigate from StateTaxAudit to TaxAudit 
                //-- to get TaxAudit Information.
                var query = from stateAudit in ctx.TaxAudits.OfType<StateTaxAudit>().OrderBy(x => x.AuditDate) select stateAudit;

                gvBefore.DataSource = query.ToList();
                gvBefore.DataBind();

                //-- Create new StateTaxAudit record
                StateTaxAudit stateTaxAudit = new StateTaxAudit();

                //-- Fields from StateTaxAudit
                stateTaxAudit.Agency = "Texas Franchise Tax Board";
                stateTaxAudit.State = "TX";
                stateTaxAudit.SalesUseTax = false;
                stateTaxAudit.ID = new Random().Next(100000);

                //-- Fields inherited from TaxAudit
                stateTaxAudit.Audtor = "Rob Vettor";
                stateTaxAudit.AuditReason = "Routine";
                stateTaxAudit.Adjustment = Convert.ToDecimal(new Random().Next(10000000));
                stateTaxAudit.AuditDate = DateTime.Now;

                //-- Attach to parent, TaxAudit
                ctx.TaxAudits.Add(stateTaxAudit);

                //-- Next, EF first creates new TaxAudit AND StateTaxAudit Record
                ctx.SaveChanges();

                var queryAfter = from stateAudit in ctx.TaxAudits.OfType<StateTaxAudit>().OrderBy(t => t.AuditDate) select stateAudit;

                gvAfter.DataSource = queryAfter.ToList();
                gvAfter.DataBind();       
            }
        }
    }
}
