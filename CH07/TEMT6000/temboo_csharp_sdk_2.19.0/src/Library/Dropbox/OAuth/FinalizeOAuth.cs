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

namespace Temboo.Library.Dropbox.OAuth
{
    /// <summary>
    /// FinalizeOAuth
    /// Completes the OAuth process by retrieving a Dropbox access token and access token secret for a user, after they have visited the authorization URL returned by the InitializeOAuth choreo and clicked "allow."
    /// </summary>
    public class FinalizeOAuth : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FinalizeOAuth Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FinalizeOAuth(TembooSession session) : base(session, "/Library/Dropbox/OAuth/FinalizeOAuth")
        {
        }

         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AppKeyName input for this Choreo.</param>
         public void setAppKeyName(String value) {
             base.addInput ("AppKeyName", value);
         }
         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AppKeyValue input for this Choreo.</param>
         public void setAppKeyValue(String value) {
             base.addInput ("AppKeyValue", value);
         }
         /// <summary>
         /// (required, string) The callback token returned by the InitializeOAuth Choreo. Used to retrieve the callback data after the user authorizes.
         /// </summary>
         /// <param name="value">Value of the CallbackID input for this Choreo.</param>
         public void setCallbackID(String value) {
             base.addInput ("CallbackID", value);
         }
         /// <summary>
         /// (required, string) The APP Key provided by Dropbox (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the DropboxAppKey input for this Choreo.</param>
         public void setDropboxAppKey(String value) {
             base.addInput ("DropboxAppKey", value);
         }
         /// <summary>
         /// (required, string) The App Secret provided by Dropbox (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the DropboxAppSecret input for this Choreo.</param>
         public void setDropboxAppSecret(String value) {
             base.addInput ("DropboxAppSecret", value);
         }
         /// <summary>
         /// (required, string) The OAuthTokenSecret returned by the InitializeOAuth Choreo.
         /// </summary>
         /// <param name="value">Value of the OAuthTokenSecret input for this Choreo.</param>
         public void setOAuthTokenSecret(String value) {
             base.addInput ("OAuthTokenSecret", value);
         }
         /// <summary>
         /// (optional, boolean) When set to true, errors received during the OAuth redirect process will be suppressed and returned in the ErrorMessage output.
         /// </summary>
         /// <param name="value">Value of the SuppressErrors input for this Choreo.</param>
         public void setSuppressErrors(String value) {
             base.addInput ("SuppressErrors", value);
         }
         /// <summary>
         /// (optional, integer) The amount of time (in seconds) to poll your Temboo callback URL to see if your app's user has allowed or denied the request for access. Defaults to 20. Max is 60.
         /// </summary>
         /// <param name="value">Value of the Timeout input for this Choreo.</param>
         public void setTimeout(String value) {
             base.addInput ("Timeout", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FinalizeOAuthResultSet containing execution metadata and results.</returns>
        new public FinalizeOAuthResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FinalizeOAuthResultSet results = new JavaScriptSerializer().Deserialize<FinalizeOAuthResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FinalizeOAuth Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FinalizeOAuthResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AccessToken" output from this Choreo execution
        /// <returns>String - (string) The Access Token retrieved during the OAuth process.</returns>
        /// </summary>
        public String AccessToken
        {
            get
            {
                return (String) base.Output["AccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "AccessTokenSecret" output from this Choreo execution
        /// <returns>String - (string) The Access Token Secret retrieved during the OAuth process.</returns>
        /// </summary>
        public String AccessTokenSecret
        {
            get
            {
                return (String) base.Output["AccessTokenSecret"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ErrorMessage" output from this Choreo execution
        /// <returns>String - (string) Contains an error message if an error occurs during the OAuth redirect process and if SuppressErrors is set to true.</returns>
        /// </summary>
        public String ErrorMessage
        {
            get
            {
                return (String) base.Output["ErrorMessage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "UserID" output from this Choreo execution
        /// <returns>String - (integer) The Dropbox user ID associated with the access token and secret returned.</returns>
        /// </summary>
        public String UserID
        {
            get
            {
                return (String) base.Output["UserID"];
            }
        }
    }
}
