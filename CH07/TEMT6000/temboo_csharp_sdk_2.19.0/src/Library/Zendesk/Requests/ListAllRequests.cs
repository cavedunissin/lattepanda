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

namespace Temboo.Library.Zendesk.Requests
{
    /// <summary>
    /// ListAllRequests
    /// List all existing requests for your account.
    /// </summary>
    public class ListAllRequests : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListAllRequests Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListAllRequests(TembooSession session) : base(session, "/Library/Zendesk/Requests/ListAllRequests")
        {
        }

         /// <summary>
         /// (required, string) The email address you use to login to your Zendesk account.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (optional, integer) The page number of the results to be returned. Used together with the PerPage parameter to paginate a large set of results.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (required, password) Your Zendesk password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return per page. Maximum is 100 and default is 100.
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (required, string) Your Zendesk domain and subdomain (e.g., temboocare.zendesk.com).
         /// </summary>
         /// <param name="value">Value of the Server input for this Choreo.</param>
         public void setServer(String value) {
             base.addInput ("Server", value);
         }
         /// <summary>
         /// (optional, string) Comma-seperated list of request statuses to match (e.g. hold, open, solved, ccd)
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListAllRequestsResultSet containing execution metadata and results.</returns>
        new public ListAllRequestsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListAllRequestsResultSet results = new JavaScriptSerializer().Deserialize<ListAllRequestsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListAllRequests Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListAllRequestsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NextPage" output from this Choreo execution
        /// <returns>String - (integer) The index for the next page of results.</returns>
        /// </summary>
        public String NextPage
        {
            get
            {
                return (String) base.Output["NextPage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PreviousPage" output from this Choreo execution
        /// <returns>String - (integer) The index for the previous page of results.</returns>
        /// </summary>
        public String PreviousPage
        {
            get
            {
                return (String) base.Output["PreviousPage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Zendesk.</returns>
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
