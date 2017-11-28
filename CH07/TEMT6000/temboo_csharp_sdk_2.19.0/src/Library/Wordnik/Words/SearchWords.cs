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

namespace Temboo.Library.Wordnik.Words
{
    /// <summary>
    /// SearchWords
    /// Searches words.
    /// </summary>
    public class SearchWords : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchWords Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchWords(TembooSession session) : base(session, "/Library/Wordnik/Words/SearchWords")
        {
        }

         /// <summary>
         /// (required, string) The API Key from Wordnik.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Makes the query case-insensitive when false. Defaults to true, so queries are case-sensitive.
         /// </summary>
         /// <param name="value">Value of the CaseSensitive input for this Choreo.</param>
         public void setCaseSensitive(String value) {
             base.addInput ("CaseSensitive", value);
         }
         /// <summary>
         /// (optional, string) Excludes the specified comma-delimited parts of speech from the results returned. Acceptable values include: adjective, noun, etc. See docs for full list.
         /// </summary>
         /// <param name="value">Value of the ExcludePartOfSpeech input for this Choreo.</param>
         public void setExcludePartOfSpeech(String value) {
             base.addInput ("ExcludePartOfSpeech", value);
         }
         /// <summary>
         /// (optional, string) Only includes the specified comma-delimited parts of speech. Acceptable values include: adjective, noun, etc. See docs for full list.
         /// </summary>
         /// <param name="value">Value of the IncludePartOfSpeech input for this Choreo.</param>
         public void setIncludePartOfSpeech(String value) {
             base.addInput ("IncludePartOfSpeech", value);
         }
         /// <summary>
         /// (optional, integer) Maximum number of results to return. Defaults to 10.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) Results include a corpus frequency count for each word returned. When this input is specified, results are limited to words with a corpus frequency count below the given number.
         /// </summary>
         /// <param name="value">Value of the MaxCorpus input for this Choreo.</param>
         public void setMaxCorpus(String value) {
             base.addInput ("MaxCorpus", value);
         }
         /// <summary>
         /// (optional, integer) Limits the results to words that have fewer than the given numner of dictionary entries.
         /// </summary>
         /// <param name="value">Value of the MaxEntries input for this Choreo.</param>
         public void setMaxEntries(String value) {
             base.addInput ("MaxEntries", value);
         }
         /// <summary>
         /// (optional, integer) Maximum word length.
         /// </summary>
         /// <param name="value">Value of the MaxLength input for this Choreo.</param>
         public void setMaxLength(String value) {
             base.addInput ("MaxLength", value);
         }
         /// <summary>
         /// (optional, integer) Results include a corpus frequency count for each word returned. When this input is specified, results are limited to words with a corpus frequency count above the given number.
         /// </summary>
         /// <param name="value">Value of the MinCorpus input for this Choreo.</param>
         public void setMinCorpus(String value) {
             base.addInput ("MinCorpus", value);
         }
         /// <summary>
         /// (optional, integer) Limits the results to words that have more than the given numner of dictionary entries.
         /// </summary>
         /// <param name="value">Value of the MinEntries input for this Choreo.</param>
         public void setMinEntries(String value) {
             base.addInput ("MinEntries", value);
         }
         /// <summary>
         /// (optional, integer) ?Minimum word length.
         /// </summary>
         /// <param name="value">Value of the MinLength input for this Choreo.</param>
         public void setMinLength(String value) {
             base.addInput ("MinLength", value);
         }
         /// <summary>
         /// (required, string) Word or fragment to query for in Wordnik.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) Response can be either JSON or XML. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, integer) Number of results to skip.
         /// </summary>
         /// <param name="value">Value of the Skip input for this Choreo.</param>
         public void setSkip(String value) {
             base.addInput ("Skip", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchWordsResultSet containing execution metadata and results.</returns>
        new public SearchWordsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchWordsResultSet results = new JavaScriptSerializer().Deserialize<SearchWordsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchWords Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchWordsResultSet : Temboo.Core.ResultSet
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
