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

namespace Temboo.Library.eBay.Trading
{
    /// <summary>
    /// GetItemTransactions
    /// Retrieves order line item (transaction) information for a specified ItemID.
    /// </summary>
    public class GetItemTransactions : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetItemTransactions Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetItemTransactions(TembooSession session) : base(session, "/Library/eBay/Trading/GetItemTransactions")
        {
        }

         /// <summary>
         /// (optional, string) The detail level of the response. Valid values are: ItemReturnDescription and ReturnAll.
         /// </summary>
         /// <param name="value">Value of the DetailLevel input for this Choreo.</param>
         public void setDetailLevel(String value) {
             base.addInput ("DetailLevel", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of records to return in the result.
         /// </summary>
         /// <param name="value">Value of the EntriesPerPage input for this Choreo.</param>
         public void setEntriesPerPage(String value) {
             base.addInput ("EntriesPerPage", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, the ContainingOrder container is returned in the response for each transaction node.
         /// </summary>
         /// <param name="value">Value of the IncludeContainingOrder input for this Choreo.</param>
         public void setIncludeContainingOrder(String value) {
             base.addInput ("IncludeContainingOrder", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, the Final Value Fee (FVF) for all order line items is returned in the response.
         /// </summary>
         /// <param name="value">Value of the IncludeFinalValueFee input for this Choreo.</param>
         public void setIncludeFinalValueFee(String value) {
             base.addInput ("IncludeFinalValueFee", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, all variations defined for the item are returned at the root level.
         /// </summary>
         /// <param name="value">Value of the IncludeVariations input for this Choreo.</param>
         public void setIncludeVariations(String value) {
             base.addInput ("IncludeVariations", value);
         }
         /// <summary>
         /// (required, string) The unique identifier for an eBay item listing.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
         }
         /// <summary>
         /// (optional, date) Used to filter by date range (e.g., 2013-02-08T00:00:00.000Z).
         /// </summary>
         /// <param name="value">Value of the ModTimeFrom input for this Choreo.</param>
         public void setModTimeFrom(String value) {
             base.addInput ("ModTimeFrom", value);
         }
         /// <summary>
         /// (optional, date) Used to filter by date range (e.g., 2013-02-08T00:00:00.000Z).
         /// </summary>
         /// <param name="value">Value of the ModTimeTo input for this Choreo.</param>
         public void setModTimeTo(String value) {
             base.addInput ("ModTimeTo", value);
         }
         /// <summary>
         /// (optional, integer) The number of days in the past to search for order line items.
         /// </summary>
         /// <param name="value">Value of the NumberOfDays input for this Choreo.</param>
         public void setNumberOfDays(String value) {
             base.addInput ("NumberOfDays", value);
         }
         /// <summary>
         /// (optional, string) A unique identifier for an eBay order line item.
         /// </summary>
         /// <param name="value">Value of the OrderLineItemID input for this Choreo.</param>
         public void setOrderLineItemID(String value) {
             base.addInput ("OrderLineItemID", value);
         }
         /// <summary>
         /// (optional, integer) Specifies the page number of the results to return.
         /// </summary>
         /// <param name="value">Value of the PageNumber input for this Choreo.</param>
         public void setPageNumber(String value) {
             base.addInput ("PageNumber", value);
         }
         /// <summary>
         /// (optional, string) The name of the eBay co-branded site upon which the order line item was created. Valid values are: eBay, Express, Half, Shopping, or WorldOfGood.
         /// </summary>
         /// <param name="value">Value of the Platform input for this Choreo.</param>
         public void setPlatform(String value) {
             base.addInput ("Platform", value);
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
         /// (optional, string) Include a TransactionID field in the request if you want to retrieve the data for a specific order line item (transaction).
         /// </summary>
         /// <param name="value">Value of the TransactionID input for this Choreo.</param>
         public void setTransactionID(String value) {
             base.addInput ("TransactionID", value);
         }
         /// <summary>
         /// (required, string) A valid eBay Auth Token.
         /// </summary>
         /// <param name="value">Value of the UserToken input for this Choreo.</param>
         public void setUserToken(String value) {
             base.addInput ("UserToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetItemTransactionsResultSet containing execution metadata and results.</returns>
        new public GetItemTransactionsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetItemTransactionsResultSet results = new JavaScriptSerializer().Deserialize<GetItemTransactionsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetItemTransactions Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetItemTransactionsResultSet : Temboo.Core.ResultSet
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
