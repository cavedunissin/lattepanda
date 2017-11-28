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

namespace Temboo.Library.Instagram
{
    /// <summary>
    /// GetLocationInformation
    /// Retrieves information about a location.
    /// </summary>
    public class GetLocationInformation : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLocationInformation Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLocationInformation(TembooSession session) : base(session, "/Library/Instagram/GetLocationInformation")
        {
        }

         /// <summary>
         /// (conditional, string) The access token retrieved during the OAuth 2.0 process. Required unless you provide the ClientID.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Instagram after registering your application. Required unless you provide an AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (required, integer) The ID for the location that you want to retrieve information for.
         /// </summary>
         /// <param name="value">Value of the LocationID input for this Choreo.</param>
         public void setLocationID(String value) {
             base.addInput ("LocationID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLocationInformationResultSet containing execution metadata and results.</returns>
        new public GetLocationInformationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLocationInformationResultSet results = new JavaScriptSerializer().Deserialize<GetLocationInformationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLocationInformation Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLocationInformationResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Instagram.</returns>
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
