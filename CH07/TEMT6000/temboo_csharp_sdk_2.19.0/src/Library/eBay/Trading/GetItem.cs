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
    /// GetItem
    /// Returns item data such as title, description, price information, and seller information.
    /// </summary>
    public class GetItem : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetItem Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetItem(TembooSession session) : base(session, "/Library/eBay/Trading/GetItem")
        {
        }

         /// <summary>
         /// (optional, string) The response detail level. Valid values are: ItemReturnAttributes, ItemReturnDescription, and ReturnAll.
         /// </summary>
         /// <param name="value">Value of the DetailLevel input for this Choreo.</param>
         public void setDetailLevel(String value) {
             base.addInput ("DetailLevel", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, the response returns the ItemSpecifics node (if the listing has custom Item Specifics).
         /// </summary>
         /// <param name="value">Value of the IncludeItemSpecifics input for this Choreo.</param>
         public void setIncludeItemSpecifics(String value) {
             base.addInput ("IncludeItemSpecifics", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, an associated tax table is returned in the response.
         /// </summary>
         /// <param name="value">Value of the IncludeTaxTable input for this Choreo.</param>
         public void setIncludeTaxTable(String value) {
             base.addInput ("IncludeTaxTable", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates if the caller wants to include watch count for that item in the response when set to true. Only the seller is allowed to use this argument.
         /// </summary>
         /// <param name="value">Value of the IncludeWatchCount input for this Choreo.</param>
         public void setIncludeWatchCount(String value) {
             base.addInput ("IncludeWatchCount", value);
         }
         /// <summary>
         /// (required, string) The ItemID that uniquely identifies the item listing to retrieve.
         /// </summary>
         /// <param name="value">Value of the ItemID input for this Choreo.</param>
         public void setItemID(String value) {
             base.addInput ("ItemID", value);
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
         /// (optional, string) A unique identifier for a transaction (i.e.  an order line item). An order line item is created when the buyer commits to purchasing an item.
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
        /// <returns>A GetItemResultSet containing execution metadata and results.</returns>
        new public GetItemResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetItemResultSet results = new JavaScriptSerializer().Deserialize<GetItemResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetItem Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetItemResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CurrentPrice" output from this Choreo execution
        /// <returns>String - (decimal) The current price for the item.</returns>
        /// </summary>
        public String CurrentPrice
        {
            get
            {
                return (String) base.Output["CurrentPrice"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "DaysLeft" output from this Choreo execution
        /// <returns>String - (integer) The number of days until the auction ends.</returns>
        /// </summary>
        public String DaysLeft
        {
            get
            {
                return (String) base.Output["DaysLeft"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "HoursLeft" output from this Choreo execution
        /// <returns>String - (integer) The number of hours until the auction ends.</returns>
        /// </summary>
        public String HoursLeft
        {
            get
            {
                return (String) base.Output["HoursLeft"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "MinutesLeft" output from this Choreo execution
        /// <returns>String - (integer) The number of minutes until the auction ends.</returns>
        /// </summary>
        public String MinutesLeft
        {
            get
            {
                return (String) base.Output["MinutesLeft"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "SecondsLeft" output from this Choreo execution
        /// <returns>String - (integer) The number of seconds until the auction ends.</returns>
        /// </summary>
        public String SecondsLeft
        {
            get
            {
                return (String) base.Output["SecondsLeft"];
            }
        }
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
