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

namespace Temboo.Library.Uber.OAuth
{
    /// <summary>
    /// RefreshToken
    /// Retrieves a fresh Access Token by exchanging the Refresh Token that is associated with the expired Access Token.
    /// </summary>
    public class RefreshToken : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RefreshToken Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RefreshToken(TembooSession session) : base(session, "/Library/Uber/OAuth/RefreshToken")
        {
        }

         /// <summary>
         /// (required, string) The Client ID provided by Uber after registering your application.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (required, string) The Client Secret provided by Uber after registering your application.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (required, string) An OAuth Refresh Token used to generate a new access token when the original token is expired.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RefreshTokenResultSet containing execution metadata and results.</returns>
        new public RefreshTokenResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RefreshTokenResultSet results = new JavaScriptSerializer().Deserialize<RefreshTokenResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RefreshToken Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RefreshTokenResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AccessToken" output from this Choreo execution
        /// <returns>String - (string) The Access Token for the user that has granted access to your application.</returns>
        /// </summary>
        public String AccessToken
        {
            get
            {
                return (String) base.Output["AccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Expires" output from this Choreo execution
        /// <returns>String - (integer) The remaining lifetime of the short-lived access token.</returns>
        /// </summary>
        public String Expires
        {
            get
            {
                return (String) base.Output["Expires"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "NewRefreshToken" output from this Choreo execution
        /// <returns>String - (string) The new Refresh Token which can be used the next time your app needs to get a new Access Token.</returns>
        /// </summary>
        public String NewRefreshToken
        {
            get
            {
                return (String) base.Output["NewRefreshToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Scope" output from this Choreo execution
        /// <returns>String - (string) The scope associated with the new Access Token.</returns>
        /// </summary>
        public String Scope
        {
            get
            {
                return (String) base.Output["Scope"];
            }
        }
    }
}
