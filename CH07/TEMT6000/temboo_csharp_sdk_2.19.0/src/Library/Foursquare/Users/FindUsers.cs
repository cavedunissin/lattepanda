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
    /// FindUsers
    /// Allows a user to locate friends.
    /// </summary>
    public class FindUsers : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FindUsers Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FindUsers(TembooSession session) : base(session, "/Library/Foursquare/Users/FindUsers")
        {
        }

         /// <summary>
         /// (conditional, string) A comma-delimited list of email addresses to look for. Must specify one of Name, Phone, Email, FacebookID, Twitter, or TwitterSource.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (conditional, string) A comma-delimited list of Facebook ID's to look for. Must specify one of Name, Phone, Email, FacebookID, Twitter, or TwitterSource.
         /// </summary>
         /// <param name="value">Value of the FacebookID input for this Choreo.</param>
         public void setFacebookID(String value) {
             base.addInput ("FacebookID", value);
         }
         /// <summary>
         /// (conditional, string) A single string to search for in users' names. A single string to search for in users' names. Must specify one of Name, Phone, Email, FacebookID, Twitter, or TwitterSource.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (required, string) The Foursquare API OAuth token string.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (conditional, string) A comma-delimited list of phone numbers to look for. Must specify one of Name, Phone, Email, FacebookID, Twitter, or TwitterSource.
         /// </summary>
         /// <param name="value">Value of the Phone input for this Choreo.</param>
         public void setPhone(String value) {
             base.addInput ("Phone", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) A comma-delimited list of Twitter handles to look for. Must specify one of Name, Phone, Email, FacebookID, Twitter, or TwitterSource.
         /// </summary>
         /// <param name="value">Value of the Twitter input for this Choreo.</param>
         public void setTwitter(String value) {
             base.addInput ("Twitter", value);
         }
         /// <summary>
         /// (conditional, string) A single Twitter handle. Results will be users that this handle follows on Twitter who use Foursquare. Must specify one of Name, Phone, Email, FacebookID, Twitter, or TwitterSource.
         /// </summary>
         /// <param name="value">Value of the TwitterSource input for this Choreo.</param>
         public void setTwitterSource(String value) {
             base.addInput ("TwitterSource", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FindUsersResultSet containing execution metadata and results.</returns>
        new public FindUsersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FindUsersResultSet results = new JavaScriptSerializer().Deserialize<FindUsersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FindUsers Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FindUsersResultSet : Temboo.Core.ResultSet
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
