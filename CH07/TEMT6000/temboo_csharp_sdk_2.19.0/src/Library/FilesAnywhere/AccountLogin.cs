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

namespace Temboo.Library.FilesAnywhere
{
    /// <summary>
    /// AccountLogin
    /// Retrieves an authentication token from FilesAnywhere.
    /// </summary>
    public class AccountLogin : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AccountLogin Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AccountLogin(TembooSession session) : base(session, "/Library/FilesAnywhere/AccountLogin")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by FilesAnywhere.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) List of allowed IP addresses.  Multiple IP addresses can be separated by commas.
         /// </summary>
         /// <param name="value">Value of the AllowedIPList input for this Choreo.</param>
         public void setAllowedIPList(String value) {
             base.addInput ("AllowedIPList", value);
         }
         /// <summary>
         /// (optional, string) Used to return an encrypted password to use for subsequent logins.
         /// </summary>
         /// <param name="value">Value of the ClientEncryptParam input for this Choreo.</param>
         public void setClientEncryptParam(String value) {
             base.addInput ("ClientEncryptParam", value);
         }
         /// <summary>
         /// (conditional, integer) Defaults to 0 for a FilesAnywhere Web account.  Use 50 for a FilesAnywhere WebAdvanced account.
         /// </summary>
         /// <param name="value">Value of the OrgID input for this Choreo.</param>
         public void setOrgID(String value) {
             base.addInput ("OrgID", value);
         }
         /// <summary>
         /// (required, password) Your FilesAnywhere password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) Your FilesAnywhere username.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AccountLoginResultSet containing execution metadata and results.</returns>
        new public AccountLoginResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AccountLoginResultSet results = new JavaScriptSerializer().Deserialize<AccountLoginResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AccountLogin Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AccountLoginResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Token" output from this Choreo execution
        /// <returns>String - (string) The token value parsed from the FilesAnywhere response.</returns>
        /// </summary>
        public String Token
        {
            get
            {
                return (String) base.Output["Token"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from FilesAnywhere.</returns>
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
