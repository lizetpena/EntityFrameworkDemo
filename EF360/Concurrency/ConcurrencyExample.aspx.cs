using System;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Concurrency
{
    public partial class ConcurrencyExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctx = new EF360Context())
            {
                Carrier carrier = null;
                
                if (!Page.IsPostBack)
                {
                    ConcurrencyResolutionType[] concurrencyResolution =
                    {
                        ConcurrencyResolutionType.ClientWins,
                        ConcurrencyResolutionType.ServerWins,
                        ConcurrencyResolutionType.MergeResults
                    };

                    string[] carrierRatings = {"A", "B", "C", "D"};

                    ddlResolution.DataSource = concurrencyResolution;
                    ddlCarrierRating.DataSource = carrierRatings;

                    ddlResolution.DataBind();
                    ddlCarrierRating.DataBind();

                    carrier = ctx.Carriers.Single(x => x.CarrierId == 1);
                }
                else
                {
                    // Retrieve concurrency resolution type
                    var concurrencyResolution =
                        (ConcurrencyResolutionType)
                            Enum.Parse(typeof (ConcurrencyResolutionType), ddlResolution.SelectedValue);
                    
                    // Retrive updated carrier rating
                    var carrierRating = ddlCarrierRating.SelectedValue;

                    // Get current record and update carrier rating
                    carrier = ctx.Carriers.Single(x => x.CarrierId == 1);
                    carrier.Rating = carrierRating;

                    // Emulate another using changing record while you have it open. 
                    // Purposely update the underlying Carrier table so that the RowVersion value changes
                    ctx.Database.ExecuteSqlCommand(@"UPDATE dbo.Carriers SET rating = 'F' WHERE CarrierId = 1");

                    // Instantiate ConcurrencyClassHelper
                    var concurrencyClassHelper = new ConcurrencyHelperClass
                    {
                        ConcurrencyResolutionTypeValue = concurrencyResolution
                    };
                    concurrencyClassHelper.SaveChangesWithConcurrency(ctx);
                }

                lblId.Text = carrier.CarrierId.ToString();
                lblName.Text = carrier.Name;
                lblAbbrev.Text = carrier.Abbreviation;
                lblRating.Text = carrier.Rating;
                lblMonths.Text = carrier.ActiveMonthAssociated.ToString();
                lblRowVersion.Text = carrier.RowVersion.ToString();
            }
        }
    }
}