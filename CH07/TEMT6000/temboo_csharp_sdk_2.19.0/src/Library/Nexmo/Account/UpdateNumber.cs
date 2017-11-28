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

namespace Temboo.Library.Nexmo.Account
{
    /// <summary>
    /// UpdateNumber
    /// Updates the callback details for the specified number.
    /// </summary>
    public class UpdateNumber : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateNumber Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateNumber(TembooSession session) : base(session, "/Library/Nexmo/Account/UpdateNumber")
        {
        }

         /// <summary>
         /// (required, string) Your API Key provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Your API Secret provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (optional, string) Mobile originated Callback URL.
         /// </summary>
         /// <param name="value">Value of the CallbackURL input for this Choreo.</param>
         public void setCallbackURL(String value) {
             base.addInput ("CallbackURL", value);
         }
         /// <summary>
         /// (required, string) 2-digit country code. (e.g. CA)
         /// </summary>
         /// <param name="value">Value of the Country input for this Choreo.</param>
         public void setCountry(String value) {
             base.addInput ("Country", value);
         }
         /// <summary>
         /// (required, string) Your inbound (MSISDN) number (e.g. 34911067000).
         /// </summary>
         /// <param name="value">Value of the Number input for this Choreo.</param>
         public void setNumber(String value) {
             base.addInput ("Number", value);
         }
         /// <summary>
         /// (optional, string) The Mobile Orignated associated system type for SMPP client only. (e.g.: inbound)
         /// </summary>
         /// <param name="value">Value of the SMPPSystemType input for this Choreo.</param>
         public void setSMPPSystemType(String value) {
             base.addInput ("SMPPSystemType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateNumberResultSet containing execution metadata and results.</returns>
        new public UpdateNumberResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateNumberResultSet results = new JavaScriptSerializer().Deserialize<UpdateNumberResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateNumber Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateNumberResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Nexmo. A 200 is returned for a successful request.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Nexmo. For a successful request, an empty response body is returned.</returns>
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
