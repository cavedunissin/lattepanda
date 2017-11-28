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

namespace Temboo.Library.eBay.Finding
{
    /// <summary>
    /// GetHistograms
    /// Returns category and/or aspect histogram information for the eBay category ID you specify.
    /// </summary>
    public class GetHistograms : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetHistograms Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetHistograms(TembooSession session) : base(session, "/Library/eBay/Finding/GetHistograms")
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
         /// (required, string) Specifies the category from which you want to retrieve histogram information.
         /// </summary>
         /// <param name="value">Value of the CategoryID input for this Choreo.</param>
         public void setCategoryID(String value) {
             base.addInput ("CategoryID", value);
         }
         /// <summary>
         /// (optional, integer) The global ID of the eBay site to access (e.g., EBAY-US).
         /// </summary>
         /// <param name="value">Value of the GlobalID input for this Choreo.</param>
         public void setGlobalID(String value) {
             base.addInput ("GlobalID", value);
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetHistogramsResultSet containing execution metadata and results.</returns>
        new public GetHistogramsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetHistogramsResultSet results = new JavaScriptSerializer().Deserialize<GetHistogramsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetHistograms Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetHistogramsResultSet : Temboo.Core.ResultSet
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
