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

namespace Temboo.Library.Instagram
{
    /// <summary>
    /// GetRecentMediaForUser
    /// Retrieves the most recent media published by a user.
    /// </summary>
    public class GetRecentMediaForUser : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetRecentMediaForUser Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetRecentMediaForUser(TembooSession session) : base(session, "/Library/Instagram/GetRecentMediaForUser")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved during the OAuth 2.0 process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, string) Return media liked before this id.
         /// </summary>
         /// <param name="value">Value of the MaxID input for this Choreo.</param>
         public void setMaxID(String value) {
             base.addInput ("MaxID", value);
         }
         /// <summary>
         /// (optional, string) Returns media later than this min_id.
         /// </summary>
         /// <param name="value">Value of the MinID input for this Choreo.</param>
         public void setMinID(String value) {
             base.addInput ("MinID", value);
         }
         /// <summary>
         /// (optional, date) Returns media after this UNIX timestamp.
         /// </summary>
         /// <param name="value">Value of the MinTimestamp input for this Choreo.</param>
         public void setMinTimestamp(String value) {
             base.addInput ("MinTimestamp", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user whose media to return. Defaults to 'self' indicating that the authenticating user is assumed.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetRecentMediaForUserResultSet containing execution metadata and results.</returns>
        new public GetRecentMediaForUserResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetRecentMediaForUserResultSet results = new JavaScriptSerializer().Deserialize<GetRecentMediaForUserResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetRecentMediaForUser Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetRecentMediaForUserResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Instagram.</returns>
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
