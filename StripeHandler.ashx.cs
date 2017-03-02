using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Stripe;

namespace Triage
{
    /// <summary>
    /// Summary description for StripeHandler
    /// </summary>
    public class StripeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var json = new StreamReader(context.Request.InputStream).ReadToEnd();

            var stripeEvent = StripeEventUtility.ParseEvent(json);

            switch (stripeEvent.Type)
            {
                case StripeEvents.ChargeRefunded:  // all of the types available are listed in StripeEvents
                    var stripeCharge = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                    break;
                case StripeEvents.CustomerSubscriptionUpdated:  // all of the types available are listed in StripeEvents
                    var stripeSubscription = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                    break;
            }

            var eventService = new StripeEventService();
            IEnumerable<StripeEvent> response = eventService.List(); // optional StripeEventListOptions
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}