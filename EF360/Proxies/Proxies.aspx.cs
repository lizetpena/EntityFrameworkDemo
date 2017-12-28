using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using DAL.Model;

namespace EF360CodeOnly.Proxies
{
    public partial class Proxies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerId = "LONEP";
            
            using (var ctx = new EF360Context())
            {
                // Retrieves proxy object that encapsulates customer
                var targetEntity = ctx.Customers.Where(x => x.CustomerID == customerId).ToList();

                //Dynamically created type from System.Data.Entity.DynamicProxies -- typeName and hash
                var proxyName = targetEntity.Single().ToString();

                // Determine if entity is a proxy object
                var isProxyType = ObjectContext.GetObjectType(targetEntity.GetType()) != typeof (Customer);

                // Proxy object is not created if use 'new' operator to instantiate entity object
                var nonProxyCustomer = new Customer {CustomerID = "abcde", CompanyName = "XYZ"};

                // Proxy object is created 
                // Create() does not add or attach the entity to the context
                var proxyCustoner = ctx.Customers.Create<Customer>();

                // Disable proxy creation, especially for services.
                // But, impacts lazy loading and change tracking.
                ctx.Configuration.ProxyCreationEnabled = false;
                var proxyDisabledCustoner = ctx.Customers.Create<Customer>();
                ctx.Configuration.ProxyCreationEnabled = true;

                gvQuery.DataSource = targetEntity.ToList();
                gvQuery.DataBind();
            }
        }
    }
}