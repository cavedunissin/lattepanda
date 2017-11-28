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
    /// GetCategories
    /// Returns the latest category hierarchy for the eBay site.
    /// </summary>
    public class GetCategories : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetCategories Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetCategories(TembooSession session) : base(session, "/Library/eBay/Trading/GetCategories")
        {
        }

         /// <summary>
         /// (optional, string) Indicates the ID of the highest-level category to return. Multiple CategoryParent IDs can be specified in a comma-separated list.
         /// </summary>
         /// <param name="value">Value of the CategoryParent input for this Choreo.</param>
         public void setCategoryParent(String value) {
             base.addInput ("CategoryParent", value);
         }
         /// <summary>
         /// (optional, string) The ID for the site for which to retrieve the category hierarchy. Use the numeric site code (e.g., 0 for US, 77 for eBay Germany, etc).
         /// </summary>
         /// <param name="value">Value of the CategorySiteID input for this Choreo.</param>
         public void setCategorySiteID(String value) {
             base.addInput ("CategorySiteID", value);
         }
         /// <summary>
         /// (optional, string) The level of detail to return in the response. Valid values are: ReturnAll.
         /// </summary>
         /// <param name="value">Value of the DetailLevel input for this Choreo.</param>
         public void setDetailLevel(String value) {
             base.addInput ("DetailLevel", value);
         }
         /// <summary>
         /// (optional, string) Indicates the maximum depth of the category hierarchy to retrieve, where the top-level categories (meta-categories) are at level 1. Default is 0.
         /// </summary>
         /// <param name="value">Value of the LevelLimit input for this Choreo.</param>
         public void setLevelLimit(String value) {
             base.addInput ("LevelLimit", value);
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
         /// (required, string) A valid eBay Auth Token.
         /// </summary>
         /// <param name="value">Value of the UserToken input for this Choreo.</param>
         public void setUserToken(String value) {
             base.addInput ("UserToken", value);
         }
         /// <summary>
         /// (optional, boolean) A flag that controls whether all eBay categories are returned, or only leaf categories are returned. To retrieve leaf categories, set this parameter to 'false'.
         /// </summary>
         /// <param name="value">Value of the ViewAllNodes input for this Choreo.</param>
         public void setViewAllNodes(String value) {
             base.addInput ("ViewAllNodes", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetCategoriesResultSet containing execution metadata and results.</returns>
        new public GetCategoriesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetCategoriesResultSet results = new JavaScriptSerializer().Deserialize<GetCategoriesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetCategories Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetCategoriesResultSet : Temboo.Core.ResultSet
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
