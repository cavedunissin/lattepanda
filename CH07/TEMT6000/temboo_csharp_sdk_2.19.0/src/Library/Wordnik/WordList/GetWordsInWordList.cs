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

namespace Temboo.Library.Wordnik.WordList
{
    /// <summary>
    /// GetWordsInWordList
    /// Retrievs the words in a word list.
    /// </summary>
    public class GetWordsInWordList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetWordsInWordList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetWordsInWordList(TembooSession session) : base(session, "/Library/Wordnik/WordList/GetWordsInWordList")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from Wordnik.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, integer) Limits teh number of results returned. Defaults to 100.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, string) The Password of the Wordnik user account.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) Response can be either JSON or XML. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, integer) Number of results to skip. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Skip input for this Choreo.</param>
         public void setSkip(String value) {
             base.addInput ("Skip", value);
         }
         /// <summary>
         /// (optional, string) Sorts the results by either alpha (alphabetically) or createDate (the date created). Defaults to createDate.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (optional, string) The direction to sort results by either asc (ascending) or desc (descending). Defaults to desc.
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (required, string) The Username of the Wordnik user.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }
         /// <summary>
         /// (required, string) The perma-link for the Word List to retrieve.
         /// </summary>
         /// <param name="value">Value of the WordList input for this Choreo.</param>
         public void setWordList(String value) {
             base.addInput ("WordList", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetWordsInWordListResultSet containing execution metadata and results.</returns>
        new public GetWordsInWordListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetWordsInWordListResultSet results = new JavaScriptSerializer().Deserialize<GetWordsInWordListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetWordsInWordList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetWordsInWordListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Wordnik.</returns>
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
