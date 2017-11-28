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

namespace Temboo.Library.Google.Spreadsheets
{
    /// <summary>
    /// SearchColumn
    /// Searches a column for a specified value.
    /// </summary>
    public class SearchColumn : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchColumn Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchColumn(TembooSession session) : base(session, "/Library/Google/Spreadsheets/SearchColumn")
        {
        }

         /// <summary>
         /// (optional, string) A valid Access Token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new Access Token.
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
         /// (optional, password) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new Access Token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, boolean) Set to true to return all matches of the query. When set to true, an array of cell values that meet the query criteria is returned in the Results output. Defaults to true.
         /// </summary>
         /// <param name="value">Value of the ReturnMatches input for this Choreo.</param>
         public void setReturnMatches(String value) {
             base.addInput ("ReturnMatches", value);
         }
         /// <summary>
         /// (required, string) The name of the column to search. This should be the value in row 1 of the column you wish to search.
         /// </summary>
         /// <param name="value">Value of the SearchColumn input for this Choreo.</param>
         public void setSearchColumn(String value) {
             base.addInput ("SearchColumn", value);
         }
         /// <summary>
         /// (required, string) The operator to use in the query. Allowed operators are: >, <, >=, >=, =, contains, and starts_with.
         /// </summary>
         /// <param name="value">Value of the SearchOperator input for this Choreo.</param>
         public void setSearchOperator(String value) {
             base.addInput ("SearchOperator", value);
         }
         /// <summary>
         /// (required, any) The value to search for in the specified column.
         /// </summary>
         /// <param name="value">Value of the SearchValue input for this Choreo.</param>
         public void setSearchValue(String value) {
             base.addInput ("SearchValue", value);
         }
         /// <summary>
         /// (conditional, string) The unique key of the spreadsheet to query. Required unless SpreadsheetName and WorksheetName are supplied.
         /// </summary>
         /// <param name="value">Value of the SpreadsheetKey input for this Choreo.</param>
         public void setSpreadsheetKey(String value) {
             base.addInput ("SpreadsheetKey", value);
         }
         /// <summary>
         /// (optional, string) The name of the spreadsheet to query. This and WorksheetName can be used as an alternative to SpreadsheetKey and WorksheetId to lookup spreadsheet details by name.
         /// </summary>
         /// <param name="value">Value of the SpreadsheetName input for this Choreo.</param>
         public void setSpreadsheetName(String value) {
             base.addInput ("SpreadsheetName", value);
         }
         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }
         /// <summary>
         /// (conditional, string) The unique ID of the worksheet to query. Required unless SpreadsheetName and WorksheetName are supplied.
         /// </summary>
         /// <param name="value">Value of the WorksheetId input for this Choreo.</param>
         public void setWorksheetId(String value) {
             base.addInput ("WorksheetId", value);
         }
         /// <summary>
         /// (optional, string) The name of the worksheet to query. This and SpreadsheetName can be used as an alternative to SpreadsheetKey and WorksheetId to lookup the spreadsheet details by name.
         /// </summary>
         /// <param name="value">Value of the WorksheetName input for this Choreo.</param>
         public void setWorksheetName(String value) {
             base.addInput ("WorksheetName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchColumnResultSet containing execution metadata and results.</returns>
        new public SearchColumnResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchColumnResultSet results = new JavaScriptSerializer().Deserialize<SearchColumnResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchColumn Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchColumnResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "MatchFound" output from this Choreo execution
        /// <returns>String - (boolean) Whether or not a matched result was found.</returns>
        /// </summary>
        public String MatchFound
        {
            get
            {
                return (String) base.Output["MatchFound"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Count" output from this Choreo execution
        /// <returns>String - (integer) The count of matched results. This is only returned when ReturnMatches is set to true.</returns>
        /// </summary>
        public String Count
        {
            get
            {
                return (String) base.Output["Count"];
            }
        }
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
        /// Retrieve the value for the "Results" output from this Choreo execution
        /// <returns>String - (json) Contains an array of the matched cell values. This is only returned when ReturnMatches is set to true.</returns>
        /// </summary>
        public String Results
        {
            get
            {
                return (String) base.Output["Results"];
            }
        }
    }
}
