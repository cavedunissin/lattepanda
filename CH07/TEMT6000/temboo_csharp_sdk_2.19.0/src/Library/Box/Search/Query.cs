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

namespace Temboo.Library.Box.Search
{
    /// <summary>
    /// Query
    /// Searches a user's Box account for items that match a specified keyword.
    /// </summary>
    public class Query : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Query Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Query(TembooSession session) : base(session, "/Library/Box/Search/Query")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved during the OAuth2 process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) A comma-seperated list of folder IDs which are used to filter your search.
         /// </summary>
         /// <param name="value">Value of the AncestorFolderIDs input for this Choreo.</param>
         public void setAncestorFolderIDs(String value) {
             base.addInput ("AncestorFolderIDs", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user. Only used for enterprise administrators to make API calls for their managed users.
         /// </summary>
         /// <param name="value">Value of the AsUser input for this Choreo.</param>
         public void setAsUser(String value) {
             base.addInput ("AsUser", value);
         }
         /// <summary>
         /// (optional, string) A comma-seperated list of content types used to filter your search.  Acceptable types are: name, description, file_content, comments, and tags.
         /// </summary>
         /// <param name="value">Value of the ContentTypes input for this Choreo.</param>
         public void setContentTypes(String value) {
             base.addInput ("ContentTypes", value);
         }
         /// <summary>
         /// (optional, date) A comma-seperated date range in ISO-8601 (2012-11-02T11:43:14-07:00) format used to filter your search.  Acceptable values are "from-date, to-date", "from-date, " and ", to-date".
         /// </summary>
         /// <param name="value">Value of the CreatedAtRange input for this Choreo.</param>
         public void setCreatedAtRange(String value) {
             base.addInput ("CreatedAtRange", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) A comma-seperated list of extension types used to filter your search (e.g., pdf, png doc).
         /// </summary>
         /// <param name="value">Value of the FileExtensions input for this Choreo.</param>
         public void setFileExtensions(String value) {
             base.addInput ("FileExtensions", value);
         }
         /// <summary>
         /// (optional, integer) The number of search results to return. Defaults to 30.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) Filters for a specific metadata template. Visit the metadata search documentation for more information (See Choreo notes for more details).
         /// </summary>
         /// <param name="value">Value of the MDFilters input for this Choreo.</param>
         public void setMDFilters(String value) {
             base.addInput ("MDFilters", value);
         }
         /// <summary>
         /// (optional, integer) The search result at which to start the response. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) A comma-seperated list of owner IDs which are used to filter your search.
         /// </summary>
         /// <param name="value">Value of the OwnerUserIDs input for this Choreo.</param>
         public void setOwnerUserIDs(String value) {
             base.addInput ("OwnerUserIDs", value);
         }
         /// <summary>
         /// (required, string) The string to search for; can be matched against item names, descriptions, text content of a file, and other fields of the different item types.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) The scope for which you want to limit your search to. Can be user_content for a search limited to only the current user or enterprise_content for the entire enterprise.
         /// </summary>
         /// <param name="value">Value of the Scope input for this Choreo.</param>
         public void setScope(String value) {
             base.addInput ("Scope", value);
         }
         /// <summary>
         /// (optional, string) Filter by a file size range. Specify the file size range in bytes separated by a comma (e.g., 50, 100).
         /// </summary>
         /// <param name="value">Value of the SizeRange input for this Choreo.</param>
         public void setSizeRange(String value) {
             base.addInput ("SizeRange", value);
         }
         /// <summary>
         /// (optional, string) The type you want to return in your search. Can be file, folder, or web_link.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (optional, date) A comma-seperated date range in ISO-8601 (2012-11-02T11:43:14-07:00) format used to filter your search.  Acceptable values are "from-date, to-date", "from-date, " and ", to-date".
         /// </summary>
         /// <param name="value">Value of the UpdatedAtRange input for this Choreo.</param>
         public void setUpdatedAtRange(String value) {
             base.addInput ("UpdatedAtRange", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A QueryResultSet containing execution metadata and results.</returns>
        new public QueryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            QueryResultSet results = new JavaScriptSerializer().Deserialize<QueryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Query Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class QueryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Box.</returns>
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
