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

namespace Temboo.Library.Zoho.CRM
{
    /// <summary>
    /// GetSearchRecordsByPDC
    /// Retrieves records from your Zoho CRM account and searches by predefined columns.
    /// </summary>
    public class GetSearchRecordsByPDC : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetSearchRecordsByPDC Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetSearchRecordsByPDC(TembooSession session) : base(session, "/Library/Zoho/CRM/GetSearchRecordsByPDC")
        {
        }

         /// <summary>
         /// (required, string) A valid authentication token. Permanent authentication tokens can be generated by the GenerateAuthToken Choreo.
         /// </summary>
         /// <param name="value">Value of the AuthenticationToken input for this Choreo.</param>
         public void setAuthenticationToken(String value) {
             base.addInput ("AuthenticationToken", value);
         }
         /// <summary>
         /// (optional, integer) The beginning index of the result set to return. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the FromIndex input for this Choreo.</param>
         public void setFromIndex(String value) {
             base.addInput ("FromIndex", value);
         }
         /// <summary>
         /// (required, string) The Zoho module you want to access. Defaults to 'Leads'.
         /// </summary>
         /// <param name="value">Value of the Module input for this Choreo.</param>
         public void setModule(String value) {
             base.addInput ("Module", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid formats are: json and xml (the default).
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The column name you want to search (such as "email", the column names used in this method are in lowercase)
         /// </summary>
         /// <param name="value">Value of the SearchColumn input for this Choreo.</param>
         public void setSearchColumn(String value) {
             base.addInput ("SearchColumn", value);
         }
         /// <summary>
         /// (required, string) Specify a search value for the column you're searching
         /// </summary>
         /// <param name="value">Value of the SearchValue input for this Choreo.</param>
         public void setSearchValue(String value) {
             base.addInput ("SearchValue", value);
         }
         /// <summary>
         /// (optional, string) The columns to return separated by commas (i.e. First Name,Last Name,Email). When left empty, only IDs are returned.
         /// </summary>
         /// <param name="value">Value of the SelectColumns input for this Choreo.</param>
         public void setSelectColumns(String value) {
             base.addInput ("SelectColumns", value);
         }
         /// <summary>
         /// (optional, integer) The ending index of the result set to return. Defaults to 20. Max is 200.
         /// </summary>
         /// <param name="value">Value of the ToIndex input for this Choreo.</param>
         public void setToIndex(String value) {
             base.addInput ("ToIndex", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetSearchRecordsByPDCResultSet containing execution metadata and results.</returns>
        new public GetSearchRecordsByPDCResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetSearchRecordsByPDCResultSet results = new JavaScriptSerializer().Deserialize<GetSearchRecordsByPDCResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetSearchRecordsByPDC Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetSearchRecordsByPDCResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Zoho. Format corresponds to the ResponseFormat input. Defaults to xml.</returns>
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