using System;
using Temboo.Core;
using System.Web.Script.Serialization;

/*
Copyright 2014 Temboo, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace Temboo.Library.eBay.Shopping
{
    /// <summary>
    /// GetShippingCosts
    /// Retrieves shipping costs for an item.
    /// </summary>
    public class GetShippingCosts : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetShippingCosts Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetShippingCosts(TembooSession session) : base(session, "/Library/eBay/Shopping/GetShippingCosts")
        {
        }

         /// <summary>
         /// (required, string) The unique identifier for the application.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (conditional, string) The shipment destination country code.
         /// </summary>
         /// <param name="value">Value of the DestinationCountryCode input for this Choreo.</param>
         public void setDestinationCountryCode(String value) {
             base.addInput ("DestinationCountryCode", value);
         }
         /// <summary>
         /// (conditional, string) The shipment destination postal code.
         /// </summary>
         /// <param name="value">Value of the DestinationPostalCode input for this Choreo.</param>
         public void setDestinationPostalCode(String value) {
             base.addInput ("DestinationPostalCode", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates whether to return the ShippingDetails container in the response.
         /// </summary>
         /// <param name="value">Value of the IncludeDetails input for this Choreo.</param>
         public void setIncludeDetails(String value) {
             base.addInput ("IncludeDetails", value);
         }
         /// <summary>
         /// (required, string) The ID of the item to get shipping costs for.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
         }
         /// <summary>
         /// (optional, string) The quantity of items being shipped.
         /// </summary>
         /// <param name="value">Value of the QuantitySold input for this Choreo.</param>
         public void setQuantitySold(String value) {
             base.addInput ("QuantitySold", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetShippingCostsResultSet containing execution metadata and results.</returns>
        new public GetShippingCostsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetShippingCostsResultSet results = new JavaScriptSerializer().Deserialize<GetShippingCostsResultSet>(json);

            // Note that we may actually have run into an exception while trying to execute
            // this request; if so, then throw an appropriate exception
            if (results.Execution.LastError != null)
            {
                throw new TembooException(results.Execution.LastError);
            }
            return results;
        }

    }

    /// <summary>
    /// A ResultSet with methods tailored to the values returned by the GetShippingCosts Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetShippingCostsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from eBay.</returns>
        /// </summary>
        public String Response
        {
            get
            {
                return (String) base.Output["Response"];
            }
        }
    }
}
