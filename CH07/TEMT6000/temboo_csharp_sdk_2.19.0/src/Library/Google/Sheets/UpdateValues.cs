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

namespace Temboo.Library.Google.Sheets
{
    /// <summary>
    /// UpdateValues
    /// Updates values in the specified range of a spreadsheet.
    /// </summary>
    public class UpdateValues : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateValues Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateValues(TembooSession session) : base(session, "/Library/Google/Sheets/UpdateValues")
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
         /// (conditional, string) The Client ID provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of fields to include in the response. See Choreo notes for syntax details.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) Indicates the dimension that the values array applies to. Valid values are ROWS (the default) or COLUMNS.
         /// </summary>
         /// <param name="value">Value of the MajorDimension input for this Choreo.</param>
         public void setMajorDimension(String value) {
             base.addInput ("MajorDimension", value);
         }
         /// <summary>
         /// (required, string) The A1 notation of a range to update. See Choreos notes for more details.
         /// </summary>
         /// <param name="value">Value of the Range input for this Choreo.</param>
         public void setRange(String value) {
             base.addInput ("Range", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (required, string) The ID of the spreadsheet. This can be found in the URL when viewing your spreadsheet in your web browser.
         /// </summary>
         /// <param name="value">Value of the SpreadsheetID input for this Choreo.</param>
         public void setSpreadsheetID(String value) {
             base.addInput ("SpreadsheetID", value);
         }
         /// <summary>
         /// (optional, string) Specifies how the input data should be interpreted. Valid values are: RAW (the default) and USER_ENTERED.
         /// </summary>
         /// <param name="value">Value of the ValueInputOption input for this Choreo.</param>
         public void setValueInputOption(String value) {
             base.addInput ("ValueInputOption", value);
         }
         /// <summary>
         /// (required, json) This is an array of arrays. The outer array can represent one or more rows while the inner array can represent one or more cell values. See Choreo notes below for more details.
         /// </summary>
         /// <param name="value">Value of the Values input for this Choreo.</param>
         public void setValues(String value) {
             base.addInput ("Values", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateValuesResultSet containing execution metadata and results.</returns>
        new public UpdateValuesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateValuesResultSet results = new JavaScriptSerializer().Deserialize<UpdateValuesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateValues Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateValuesResultSet : Temboo.Core.ResultSet
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
        /// <returns>String - (json) The response from Google.</returns>
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
