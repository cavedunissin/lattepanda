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
    /// FindPopularItems
    /// Searches for popular items based on a category or keyword.
    /// </summary>
    public class FindPopularItems : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FindPopularItems Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FindPopularItems(TembooSession session) : base(session, "/Library/eBay/Shopping/FindPopularItems")
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
         /// (optional, string) The ID of a category to filter by. Multiple category IDs can be separated by commas.
         /// </summary>
         /// <param name="value">Value of the CategoryID input for this Choreo.</param>
         public void setCategoryID(String value) {
             base.addInput ("CategoryID", value);
         }
         /// <summary>
         /// (conditional, integer) The ID of a category to exclude from the result set. Multiple category IDs can be separated by commas.
         /// </summary>
         /// <param name="value">Value of the CategoryIDExclude input for this Choreo.</param>
         public void setCategoryIDExclude(String value) {
             base.addInput ("CategoryIDExclude", value);
         }
         /// <summary>
         /// (conditional, integer) The maxiumum number of entries to return in the response.
         /// </summary>
         /// <param name="value">Value of the MaxEntries input for this Choreo.</param>
         public void setMaxEntries(String value) {
             base.addInput ("MaxEntries", value);
         }
         /// <summary>
         /// (conditional, string) The text for a keyword search.
         /// </summary>
         /// <param name="value">Value of the QueryKeywords input for this Choreo.</param>
         public void setQueryKeywords(String value) {
             base.addInput ("QueryKeywords", value);
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
        /// <returns>A FindPopularItemsResultSet containing execution metadata and results.</returns>
        new public FindPopularItemsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FindPopularItemsResultSet results = new JavaScriptSerializer().Deserialize<FindPopularItemsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FindPopularItems Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FindPopularItemsResultSet : Temboo.Core.ResultSet
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
