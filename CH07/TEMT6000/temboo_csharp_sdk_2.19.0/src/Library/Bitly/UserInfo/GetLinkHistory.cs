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

namespace Temboo.Library.Bitly.UserInfo
{
    /// <summary>
    /// GetLinkHistory
    /// Returns entries from a user's link history in reverse chronological order.
    /// </summary>
    public class GetLinkHistory : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLinkHistory Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLinkHistory(TembooSession session) : base(session, "/Library/Bitly/UserInfo/GetLinkHistory")
        {
        }

         /// <summary>
         /// (required, string) The OAuth access token provided by Bitly.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) Accepted values are: on|off|both.  Whether to include or exclude archived history entries. (on = return only archived history entries). Defaults to "off".
         /// </summary>
         /// <param name="value">Value of the Archived input for this Choreo.</param>
         public void setArchived(String value) {
             base.addInput ("Archived", value);
         }
         /// <summary>
         /// (optional, date) An epoch timestamp representing a date to filter with.
         /// </summary>
         /// <param name="value">Value of the CreatedAfter input for this Choreo.</param>
         public void setCreatedAfter(String value) {
             base.addInput ("CreatedAfter", value);
         }
         /// <summary>
         /// (optional, date) An epoch timestamp representing a date to filter with.
         /// </summary>
         /// <param name="value">Value of the CreatedBefore input for this Choreo.</param>
         public void setCreatedBefore(String value) {
             base.addInput ("CreatedBefore", value);
         }
         /// <summary>
         /// (optional, integer) An integer in the range of 1 to 100, specifying the max number of results to return. Defaults to 50.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The bitly link to return metadata for (when spcified, overrides all other options).
         /// </summary>
         /// <param name="value">Value of the Link input for this Choreo.</param>
         public void setLink(String value) {
             base.addInput ("Link", value);
         }
         /// <summary>
         /// (optional, date) An epoch timestamp representing a date to filter with.
         /// </summary>
         /// <param name="value">Value of the ModifiedAfter input for this Choreo.</param>
         public void setModifiedAfter(String value) {
             base.addInput ("ModifiedAfter", value);
         }
         /// <summary>
         /// (optional, string) An integer specifying the numbered result at which to start (used for pagination).
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) Accepted values are: on|off|both.  Whether to include or exclude archived history entries. (on = return only archived history entries). Defaults to "both".
         /// </summary>
         /// <param name="value">Value of the Private input for this Choreo.</param>
         public void setPrivate(String value) {
             base.addInput ("Private", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in. Accepted values are "json" or "xml". Defaults to "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The user for whom to retrieve history entries (if different from authenticated user).
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLinkHistoryResultSet containing execution metadata and results.</returns>
        new public GetLinkHistoryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLinkHistoryResultSet results = new JavaScriptSerializer().Deserialize<GetLinkHistoryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLinkHistory Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLinkHistoryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Bitly.</returns>
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
