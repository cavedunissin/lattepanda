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

namespace Temboo.Library.PayPal.Payments
{
    /// <summary>
    /// ListPayments
    /// Retrieves a list of payments.
    /// </summary>
    public class ListPayments : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListPayments Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListPayments(TembooSession session) : base(session, "/Library/PayPal/Payments/ListPayments")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved from PayPal. Required unless providing the ClientID and ClientSecret which can be used to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by PayPal. Required unless a valid Access Token is provided.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by PayPal. Required unless a valid Access Token is provided.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, integer) Number of items to return. Default is 10 with a maximum value of 20.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, string) A space delimited list of resource URL endpoints that the token should have access for. This is only used when providing the ClientID and Client Secret in order to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the Scope input for this Choreo.</param>
         public void setScope(String value) {
             base.addInput ("Scope", value);
         }
         /// <summary>
         /// (optional, string) The field to sort results by. Valid values are: create_time and update_time.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (optional, string) The sort order of the results. Valid values are asc and desc (the default).
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (optional, string) The resource ID that indicates the starting resource to return. When results are paged, you can use the next_id response value as the StartID to continue with the next set of results.
         /// </summary>
         /// <param name="value">Value of the StartID input for this Choreo.</param>
         public void setStartID(String value) {
             base.addInput ("StartID", value);
         }
         /// <summary>
         /// (optional, integer) The start index of the resources to be returned. Used to jump to a specific position in the results.
         /// </summary>
         /// <param name="value">Value of the StartIndex input for this Choreo.</param>
         public void setStartIndex(String value) {
             base.addInput ("StartIndex", value);
         }
         /// <summary>
         /// (conditional, boolean) Set to 1 to indicate that you're testing against the PayPal sandbox instead of production. Set to 0 (the default) when moving to production.
         /// </summary>
         /// <param name="value">Value of the UseSandbox input for this Choreo.</param>
         public void setUseSandbox(String value) {
             base.addInput ("UseSandbox", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListPaymentsResultSet containing execution metadata and results.</returns>
        new public ListPaymentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListPaymentsResultSet results = new JavaScriptSerializer().Deserialize<ListPaymentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListPayments Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListPaymentsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) The new access token retrieved from PayPal when providing the Client ID and Client Secret.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from PayPal.</returns>
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
