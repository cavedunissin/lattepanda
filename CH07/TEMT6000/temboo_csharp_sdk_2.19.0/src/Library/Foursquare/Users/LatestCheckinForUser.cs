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
    /// LatestCheckinForUser
    /// Retrieves the latest check-in for an authenticated user.
    /// </summary>
    public class LatestCheckinForUser : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the LatestCheckinForUser Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public LatestCheckinForUser(TembooSession session) : base(session, "/Library/Foursquare/Users/LatestCheckinForUser")
        {
        }

         /// <summary>
         /// (required, string) The Foursquare API Oauth token string.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
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
        /// <returns>A LatestCheckinForUserResultSet containing execution metadata and results.</returns>
        new public LatestCheckinForUserResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            LatestCheckinForUserResultSet results = new JavaScriptSerializer().Deserialize<LatestCheckinForUserResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the LatestCheckinForUser Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class LatestCheckinForUserResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "City" output from this Choreo execution
        /// <returns>String - (string) The city that the venue is located in.</returns>
        /// </summary>
        public String City
        {
            get
            {
                return (String) base.Output["City"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CreatedAt" output from this Choreo execution
        /// <returns>String - (date) The date associated with the user's latest check-in.</returns>
        /// </summary>
        public String CreatedAt
        {
            get
            {
                return (String) base.Output["CreatedAt"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "FormattedAddress" output from this Choreo execution
        /// <returns>String - (string) The formatted address of the venue associated with the user's latest check-in.</returns>
        /// </summary>
        public String FormattedAddress
        {
            get
            {
                return (String) base.Output["FormattedAddress"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PostalCode" output from this Choreo execution
        /// <returns>String - (integer) The postal code of the venue.</returns>
        /// </summary>
        public String PostalCode
        {
            get
            {
                return (String) base.Output["PostalCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "State" output from this Choreo execution
        /// <returns>String - (string) The state that the venue is located in.</returns>
        /// </summary>
        public String State
        {
            get
            {
                return (String) base.Output["State"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "VenueID" output from this Choreo execution
        /// <returns>String - (string) The ID of the venue associated with the user's latest check-in.</returns>
        /// </summary>
        public String VenueID
        {
            get
            {
                return (String) base.Output["VenueID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "VenueName" output from this Choreo execution
        /// <returns>String - (string) The name of the venue that the user last checked into.</returns>
        /// </summary>
        public String VenueName
        {
            get
            {
                return (String) base.Output["VenueName"];
            }
        }
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
