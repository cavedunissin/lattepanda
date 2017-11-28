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
    /// UserIsFollowedBy
    /// Retrieve the list of users following the authenticating user.
    /// </summary>
    public class UserIsFollowedBy : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UserIsFollowedBy Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UserIsFollowedBy(TembooSession session) : base(session, "/Library/Instagram/UserIsFollowedBy")
        {
        }

         /// <summary>
         /// (conditional, string) The access token retrieved during the OAuth 2.0 process. Required unless you provide the ClientID.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Instagram after registering your application. Required unless you provide the AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, string) The "next cursor" used to retrieve the next page of results.
         /// </summary>
         /// <param name="value">Value of the Cursor input for this Choreo.</param>
         public void setCursor(String value) {
             base.addInput ("Cursor", value);
         }
         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UserIsFollowedByResultSet containing execution metadata and results.</returns>
        new public UserIsFollowedByResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UserIsFollowedByResultSet results = new JavaScriptSerializer().Deserialize<UserIsFollowedByResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UserIsFollowedBy Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UserIsFollowedByResultSet : Temboo.Core.ResultSet
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
