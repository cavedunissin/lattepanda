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

namespace Temboo.Library.ConstantContact
{
    /// <summary>
    /// SearchContactsByUpdatedSince
    /// Searches your Constant Contact list by last updated date.  Use this Choreo for synchronizing your lists with other systems. 
    /// </summary>
    public class SearchContactsByUpdatedSince : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchContactsByUpdatedSince Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchContactsByUpdatedSince(TembooSession session) : base(session, "/Library/ConstantContact/SearchContactsByUpdatedSince")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Constant Contact.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The list type to query. Supported values for this parameter are: active, removed and do-not-mail. Defaults to 'active'.
         /// </summary>
         /// <param name="value">Value of the ListType input for this Choreo.</param>
         public void setListType(String value) {
             base.addInput ("ListType", value);
         }
         /// <summary>
         /// (optional, string) The URI returned in the "NextPage" output of this Choreo. This value is used to retrieve the next 50 results.
         /// </summary>
         /// <param name="value">Value of the NextResults input for this Choreo.</param>
         public void setNextResults(String value) {
             base.addInput ("NextResults", value);
         }
         /// <summary>
         /// (required, password) Your Constant Contact password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, date) Epoch timestamp in milliseconds or formatted like 2009-12-01T01:00:00.000Z. Used to query for modified records.
         /// </summary>
         /// <param name="value">Value of the UpdatedSince input for this Choreo.</param>
         public void setUpdatedSince(String value) {
             base.addInput ("UpdatedSince", value);
         }
         /// <summary>
         /// (required, string) Your Constant Contact username.
         /// </summary>
         /// <param name="value">Value of the UserName input for this Choreo.</param>
         public void setUserName(String value) {
             base.addInput ("UserName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchContactsByUpdatedSinceResultSet containing execution metadata and results.</returns>
        new public SearchContactsByUpdatedSinceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchContactsByUpdatedSinceResultSet results = new JavaScriptSerializer().Deserialize<SearchContactsByUpdatedSinceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchContactsByUpdatedSince Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchContactsByUpdatedSinceResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NextPage" output from this Choreo execution
        /// <returns>String - (string) A URI used to retrieve the next page of results. If this value is not returned, there are no more results to retrieve. This value can be passed to the "NextResults" input of this Choreo.</returns>
        /// </summary>
        public String NextPage
        {
            get
            {
                return (String) base.Output["NextPage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Constant Contact.</returns>
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
