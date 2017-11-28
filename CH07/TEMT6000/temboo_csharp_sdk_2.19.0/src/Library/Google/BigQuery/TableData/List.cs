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

namespace Temboo.Library.Google.BigQuery.TableData
{
    /// <summary>
    /// List
    /// Retrieves table data from a specified set of rows.
    /// </summary>
    public class List : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the List Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public List(TembooSession session) : base(session, "/Library/Google/BigQuery/TableData/List")
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
         /// (required, string) The ID of the dataset that your table belongs to.
         /// </summary>
         /// <param name="value">Value of the DatasetID input for this Choreo.</param>
         public void setDatasetID(String value) {
             base.addInput ("DatasetID", value);
         }
         /// <summary>
         /// (optional, string) Selector specifying which fields to include in a partial response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, integer) Maximum number of results to return. Defaults to 100. Max is 1000.
         /// </summary>
         /// <param name="value">Value of the MaxResults input for this Choreo.</param>
         public void setMaxResults(String value) {
             base.addInput ("MaxResults", value);
         }
         /// <summary>
         /// (optional, string) Page token, returned by a previous call, identifying the result set.
         /// </summary>
         /// <param name="value">Value of the PageToken input for this Choreo.</param>
         public void setPageToken(String value) {
             base.addInput ("PageToken", value);
         }
         /// <summary>
         /// (required, string) The ID of your Google API project.
         /// </summary>
         /// <param name="value">Value of the ProjectID input for this Choreo.</param>
         public void setProjectID(String value) {
             base.addInput ("ProjectID", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new Access Token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, integer) Zero-based index of the starting row to read.
         /// </summary>
         /// <param name="value">Value of the StartIndex input for this Choreo.</param>
         public void setStartIndex(String value) {
             base.addInput ("StartIndex", value);
         }
         /// <summary>
         /// (required, string) The ID of the BigQuery table to insert a row into.
         /// </summary>
         /// <param name="value">Value of the TableID input for this Choreo.</param>
         public void setTableID(String value) {
             base.addInput ("TableID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListResultSet containing execution metadata and results.</returns>
        new public ListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListResultSet results = new JavaScriptSerializer().Deserialize<ListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the List Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListResultSet : Temboo.Core.ResultSet
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
