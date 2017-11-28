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

namespace Temboo.Library.Twilio.ConnectApps
{
    /// <summary>
    /// UpdateConnectApp
    /// Updates the details for an individual Connect App associated with a Twilio account.
    /// </summary>
    public class UpdateConnectApp : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateConnectApp Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateConnectApp(TembooSession session) : base(session, "/Library/Twilio/ConnectApps/UpdateConnectApp")
        {
        }

         /// <summary>
         /// (required, string) The AccountSID provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AccountSID input for this Choreo.</param>
         public void setAccountSID(String value) {
             base.addInput ("AccountSID", value);
         }
         /// <summary>
         /// (required, string) The authorization token provided when you signed up for a Twilio account.
         /// </summary>
         /// <param name="value">Value of the AuthToken input for this Choreo.</param>
         public void setAuthToken(String value) {
             base.addInput ("AuthToken", value);
         }
         /// <summary>
         /// (optional, string) The URL the user's browser will redirect to after Twilio authenticates the user and obtains authorization for this Connect App.
         /// </summary>
         /// <param name="value">Value of the AuthorizeRedirectURL input for this Choreo.</param>
         public void setAuthorizeRedirectURL(String value) {
             base.addInput ("AuthorizeRedirectURL", value);
         }
         /// <summary>
         /// (optional, string) The company name for this Connect App.
         /// </summary>
         /// <param name="value">Value of the CompanyName input for this Choreo.</param>
         public void setCompanyName(String value) {
             base.addInput ("CompanyName", value);
         }
         /// <summary>
         /// (required, string) The id of the Connect App to update.
         /// </summary>
         /// <param name="value">Value of the ConnectAppSID input for this Choreo.</param>
         public void setConnectAppSID(String value) {
             base.addInput ("ConnectAppSID", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method to be used when making a request to the DeauthorizeCallbackUrl. Either GET or POST.
         /// </summary>
         /// <param name="value">Value of the DeauthorizeCallbackMethod input for this Choreo.</param>
         public void setDeauthorizeCallbackMethod(String value) {
             base.addInput ("DeauthorizeCallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) The URL to which Twilio will send a request when a user de-authorizes this Connect App.
         /// </summary>
         /// <param name="value">Value of the DeauthorizeCallbackURL input for this Choreo.</param>
         public void setDeauthorizeCallbackURL(String value) {
             base.addInput ("DeauthorizeCallbackURL", value);
         }
         /// <summary>
         /// (optional, string) A more detailed human readable description of the Connect App.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) A human readable description of the Connect App, with maximum length 64 characters.
         /// </summary>
         /// <param name="value">Value of the FriendlyName input for this Choreo.</param>
         public void setFriendlyName(String value) {
             base.addInput ("FriendlyName", value);
         }
         /// <summary>
         /// (optional, string) The public URL where users can obtain more information about this Connect App.
         /// </summary>
         /// <param name="value">Value of the HomepageURL input for this Choreo.</param>
         public void setHomepageURL(String value) {
             base.addInput ("HomepageURL", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of permssions you will request from users of this ConnectApp. Valid permssions are get-all or post-all.
         /// </summary>
         /// <param name="value">Value of the Permissions input for this Choreo.</param>
         public void setPermissions(String value) {
             base.addInput ("Permissions", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateConnectAppResultSet containing execution metadata and results.</returns>
        new public UpdateConnectAppResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateConnectAppResultSet results = new JavaScriptSerializer().Deserialize<UpdateConnectAppResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateConnectApp Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateConnectAppResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Twilio.</returns>
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
