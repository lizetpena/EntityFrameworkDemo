using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using DAL.Model;

namespace GettingStarted.UI.EFAdvancedMapping
{
    public partial class TablePerTypeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
            //    var query2 = from l in ctx.LocalTaxAuditSet
            //                 select l;
                
                
                
                
            //    //-- Now, StateTaxAudit entity "inherits" the TaxAudit entity.
            //    //-- Retrieve all StateTaxAudit records, which includes associated
            //    //-- record from TaxAudit, without referring to TaxAudit, as
            //    //-- SalesTaxAudit inherits from TaxAudit
            //    var query = from stateAudit in ctx.TaxAudit.OfType<StateTaxAudit>()
            //                orderby stateAudit.AuditDate
            //                select new
            //                {
            //                    //-- Properties from Tax Audit
            //                    stateAudit.AuditDate,
            //                    stateAudit.AuditReason,
            //                    stateAudit.Adjustment,
            //                    stateAudit.Audtor,
            //                    //-- Properties from State Tax Audit
            //                    stateAudit.State,
            //                    stateAudit.Agency,
            //                    stateAudit.SalesUseTax
            //                };
                           
            //    gvBefore.DataSource = query;
            //    gvBefore.DataBind();
            //}

            //using (NorthwindEFEntities ctx = new NorthwindEFEntities())
            //{
            //    //-- Now, FederalTaxAudit entity "inherits" the TaxAudit entity.
            //    //-- Retrieve all FederalTaxAudit records, which includes associated
            //    //-- record from TaxAudit, without referring to TaxAudit, as
            //    //-- FederalTaxAudit inherits from TaxAudit
            //    var query = from federalAudit in ctx.TaxAudit.OfType<FederalTaxAudit>()
            //                orderby federalAudit.AuditDate
            //                select new
            //                {
            //                    //-- Properties from Tax Audit
            //                    federalAudit.AuditDate,
            //                    federalAudit.AuditReason,
            //                    federalAudit.Adjustment,
            //                    federalAudit.Audtor,
            //                    //-- Properties from Federal Tax Audit
            //                    federalAudit.IRSDistrict,
            //                    federalAudit.TaxYear,
            //                    federalAudit.DIFScore
            //                };

            //    gvAfter.DataSource = query;
            //    gvAfter.DataBind();
            }

        
        
        }
    }
}
