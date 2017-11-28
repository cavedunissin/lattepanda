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
    /// FetchToken
    /// Completes the authentication process by retrieving an eBay user token after they have visited the authorization URL returned by the GetSessionID Choreo and clicked "I agree".
    /// </summary>
    public class FetchToken : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FetchToken Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FetchToken(TembooSession session) : base(session, "/Library/eBay/Trading/FetchToken")
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
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (required, string) The SessionID returned from PayPal. This gets passed to the FetchToken Choreo after the user authorizes the request.
         /// </summary>
         /// <param name="value">Value of the SessionID input for this Choreo.</param>
         public void setSessionID(String value) {
             base.addInput ("SessionID", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (optional, integer) The amount of time (in seconds) to poll eBay to see if your app's user has allowed or denied the request for access. Defaults to 20. Max is 60.
         /// </summary>
         /// <param name="value">Value of the Timeout input for this Choreo.</param>
         public void setTimeout(String value) {
             base.addInput ("Timeout", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FetchTokenResultSet containing execution metadata and results.</returns>
        new public FetchTokenResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FetchTokenResultSet results = new JavaScriptSerializer().Deserialize<FetchTokenResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FetchToken Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FetchTokenResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "UserToken" output from this Choreo execution
        /// <returns>String - (string) An eBay Auth Token which can be used to make requests the user's behalf.</returns>
        /// </summary>
        public String UserToken
        {
            get
            {
                return (String) base.Output["UserToken"];
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
