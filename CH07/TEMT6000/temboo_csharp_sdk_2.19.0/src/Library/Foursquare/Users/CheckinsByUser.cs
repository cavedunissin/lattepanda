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

namespace Temboo.Library.Foursquare.Users
{
    /// <summary>
    /// CheckinsByUser
    /// Retrieve a list of check-ins for an authenticated user.
    /// </summary>
    public class CheckinsByUser : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CheckinsByUser Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CheckinsByUser(TembooSession session) : base(session, "/Library/Foursquare/Users/CheckinsByUser")
        {
        }

         /// <summary>
         /// (optional, date) Retrieve the first results after the seconds entered since epoch time.
         /// </summary>
         /// <param name="value">Value of the AfterTimeStamp input for this Choreo.</param>
         public void setAfterTimeStamp(String value) {
             base.addInput ("AfterTimeStamp", value);
         }
         /// <summary>
         /// (optional, date) Retrieve the first results prior to the seconds specified. Useful for paging backward in time.
         /// </summary>
         /// <param name="value">Value of the BeforeTimeStamp input for this Choreo.</param>
         public void setBeforeTimeStamp(String value) {
             base.addInput ("BeforeTimeStamp", value);
         }
         /// <summary>
         /// (optional, integer) The total number of results to be returned, up to 250.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, string) The Foursquare API Oauth token string.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to skip. Used to page through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Only 'self' is supported at this moment by the Foursquare API. Defaults to: self.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CheckinsByUserResultSet containing execution metadata and results.</returns>
        new public CheckinsByUserResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CheckinsByUserResultSet results = new JavaScriptSerializer().Deserialize<CheckinsByUserResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CheckinsByUser Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CheckinsByUserResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Foursquare. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
