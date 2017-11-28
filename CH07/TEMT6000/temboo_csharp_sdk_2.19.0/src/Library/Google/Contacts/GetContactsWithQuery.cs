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

namespace Temboo.Library.Google.Contacts
{
    /// <summary>
    /// GetContactsWithQuery
    /// Retrieves the contact or contacts in that account that match a specified query term.
    /// </summary>
    public class GetContactsWithQuery : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetContactsWithQuery Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetContactsWithQuery(TembooSession session) : base(session, "/Library/Google/Contacts/GetContactsWithQuery")
        {
        }

         /// <summary>
         /// (optional, string) The access token retrieved in the last step of the OAuth process. Access tokens that are expired will be refreshed and returned in the Choreo output.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The OAuth client ID provided by Google when you register your application.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (required, string) The OAuth client secret provided by Google when you registered your application.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) Constrains the results to only the contacts belonging to the group specified. The value of this parameter specifies group ID.
         /// </summary>
         /// <param name="value">Value of the Group input for this Choreo.</param>
         public void setGroup(String value) {
             base.addInput ("Group", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of entries to return.
         /// </summary>
         /// <param name="value">Value of the MaxResults input for this Choreo.</param>
         public void setMaxResults(String value) {
             base.addInput ("MaxResults", value);
         }
         /// <summary>
         /// (required, string) The contact criteria to search for, such as name or email address.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (required, string) The refresh token retrieved in the last step of the OAuth process. This is used when an access token is expired or not provided.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) Sorting order direction. Can be either ascending or descending.
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (optional, integer) The index of the first result to be retrieved (for paging).
         /// </summary>
         /// <param name="value">Value of the StartIndex input for this Choreo.</param>
         public void setStartIndex(String value) {
             base.addInput ("StartIndex", value);
         }
         /// <summary>
         /// (optional, date) The lower bound on entry update dates to filter by (e.g., 2015-01-16T00:00:00).
         /// </summary>
         /// <param name="value">Value of the UpdatedMin input for this Choreo.</param>
         public void setUpdatedMin(String value) {
             base.addInput ("UpdatedMin", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetContactsWithQueryResultSet containing execution metadata and results.</returns>
        new public GetContactsWithQueryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetContactsWithQueryResultSet results = new JavaScriptSerializer().Deserialize<GetContactsWithQueryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetContactsWithQuery Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetContactsWithQueryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AccessToken" output from this Choreo execution
        /// <returns>String - (optional, string) The access token retrieved in the last step of the OAuth process. Access tokens that are expired will be refreshed and returned in the Choreo output.</returns>
        /// </summary>
        public String AccessToken
        {
            get
            {
                return (String) base.Output["AccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ContactID" output from this Choreo execution
        /// <returns>String - (string) The unique ID string for the retrieved contact. If more than one contact is retrieved by the request, only the first contact's ID is output.</returns>
        /// </summary>
        public String ContactID
        {
            get
            {
                return (String) base.Output["ContactID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Link" output from this Choreo execution
        /// <returns>String - (string) The unique edit link for the retrieved contact. If more than one contact is retrieved by the request, only the first contact's edit link is output.</returns>
        /// </summary>
        public String Link
        {
            get
            {
                return (String) base.Output["Link"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Google.</returns>
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
