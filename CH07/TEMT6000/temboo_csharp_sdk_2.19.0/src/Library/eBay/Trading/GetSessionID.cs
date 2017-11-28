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

namespace Temboo.Library.eBay.Trading
{
    /// <summary>
    /// GetSessionID
    /// Generates an authorization URL that an application can use to complete the first step in the authentication process.
    /// </summary>
    public class GetSessionID : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetSessionID Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetSessionID(TembooSession session) : base(session, "/Library/eBay/Trading/GetSessionID")
        {
        }

         /// <summary>
         /// (required, string) The unique identifier for the application.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, string) The certificate that authenticates the application when making API calls.
         /// </summary>
         /// <param name="value">Value of the CertID input for this Choreo.</param>
         public void setCertID(String value) {
             base.addInput ("CertID", value);
         }
         /// <summary>
         /// (required, string) The unique identifier for the developer's account.
         /// </summary>
         /// <param name="value">Value of the DevID input for this Choreo.</param>
         public void setDevID(String value) {
             base.addInput ("DevID", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) Your application's RuName which identifies your application to eBay.
         /// </summary>
         /// <param name="value">Value of the RuName input for this Choreo.</param>
         public void setRuName(String value) {
             base.addInput ("RuName", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetSessionIDResultSet containing execution metadata and results.</returns>
        new public GetSessionIDResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetSessionIDResultSet results = new JavaScriptSerializer().Deserialize<GetSessionIDResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetSessionID Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetSessionIDResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AuthorizationURL" output from this Choreo execution
        /// <returns>String - (string) The URL that you can send the user to so that they can sign-in and approve the user consent form.</returns>
        /// </summary>
        public String AuthorizationURL
        {
            get
            {
                return (String) base.Output["AuthorizationURL"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "SessionID" output from this Choreo execution
        /// <returns>String - (string) The SessionID returned from eBay. This gets passed to the FetchToken Choreo after the user authorizes the request.</returns>
        /// </summary>
        public String SessionID
        {
            get
            {
                return (String) base.Output["SessionID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from eBay.</returns>
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
