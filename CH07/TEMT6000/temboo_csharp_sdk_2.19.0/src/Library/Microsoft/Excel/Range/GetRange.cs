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

namespace Temboo.Library.Microsoft.Excel.Range
{
    /// <summary>
    /// GetRange
    /// Retrieves the properties and relationships of range object.
    /// </summary>
    public class GetRange : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetRange Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetRange(TembooSession session) : base(session, "/Library/Microsoft/Excel/Range/GetRange")
        {
        }

         /// <summary>
         /// (optional, string) A valid Access Token retrieved during the OAuth process. This can be passed if your application is authenticating multiple Office 365 users.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Microsoft. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Microsoft. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (required, string) The location of the spreadsheet in OneDrive (e.g. MyFolder/Book.xlsx).
         /// </summary>
         /// <param name="value">Value of the ItemPath input for this Choreo.</param>
         public void setItemPath(String value) {
             base.addInput ("ItemPath", value);
         }
         /// <summary>
         /// (conditional, password) Your Microsoft password. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (conditional, string) A range to return (e.g. A1:B2).
         /// </summary>
         /// <param name="value">Value of the Range input for this Choreo.</param>
         public void setRange(String value) {
             base.addInput ("Range", value);
         }
         /// <summary>
         /// (optional, string) Comma-separated list of properties to include in the response.
         /// </summary>
         /// <param name="value">Value of the Select input for this Choreo.</param>
         public void setSelect(String value) {
             base.addInput ("Select", value);
         }
         /// <summary>
         /// (conditional, string) Your Microsoft username. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }
         /// <summary>
         /// (required, string) The name or id of the worksheet.
         /// </summary>
         /// <param name="value">Value of the Worksheet input for this Choreo.</param>
         public void setWorksheet(String value) {
             base.addInput ("Worksheet", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetRangeResultSet containing execution metadata and results.</returns>
        new public GetRangeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetRangeResultSet results = new JavaScriptSerializer().Deserialize<GetRangeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetRange Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetRangeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Microsoft.</returns>
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
