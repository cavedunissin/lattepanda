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

namespace Temboo.Library.Salesforce.Objects
{
    /// <summary>
    /// GetRecordByExternalID
    /// Retrieve records with a specific external ID.
    /// </summary>
    public class GetRecordByExternalID : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetRecordByExternalID Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetRecordByExternalID(TembooSession session) : base(session, "/Library/Salesforce/Objects/GetRecordByExternalID")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Salesforce. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Salesforce. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (conditional, string) FieldName for external ID
         /// </summary>
         /// <param name="value">Value of the FieldName input for this Choreo.</param>
         public void setFieldName(String value) {
             base.addInput ("FieldName", value);
         }
         /// <summary>
         /// (conditional, string) Field value for external ID
         /// </summary>
         /// <param name="value">Value of the FieldValue input for this Choreo.</param>
         public void setFieldValue(String value) {
             base.addInput ("FieldValue", value);
         }
         /// <summary>
         /// (required, string) The server url prefix that indicates which instance your Salesforce account is on (e.g. na1, na2, na3, etc).
         /// </summary>
         /// <param name="value">Value of the InstanceName input for this Choreo.</param>
         public void setInstanceName(String value) {
             base.addInput ("InstanceName", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) The name of the Salesforce object type being created (e.g. Account, Contact, Lead, etc).
         /// </summary>
         /// <param name="value">Value of the SObjectName input for this Choreo.</param>
         public void setSObjectName(String value) {
             base.addInput ("SObjectName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetRecordByExternalIDResultSet containing execution metadata and results.</returns>
        new public GetRecordByExternalIDResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetRecordByExternalIDResultSet results = new JavaScriptSerializer().Deserialize<GetRecordByExternalIDResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetRecordByExternalID Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetRecordByExternalIDResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the RefreshToken is provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Salesforce.</returns>
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
