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
    /// RandomWords
    /// Retrieves a list of random words.
    /// </summary>
    public class RandomWords : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RandomWords Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RandomWords(TembooSession session) : base(session, "/Library/Wordnik/Words/RandomWords")
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
         /// (optional, string) Excludes the specified comma-delimited parts of speech from the results returned. Acceptable values include: adjective, noun, etc. See docs for full list.
         /// </summary>
         /// <param name="value">Value of the ExcludePartOfSpeech input for this Choreo.</param>
         public void setExcludePartOfSpeech(String value) {
             base.addInput ("ExcludePartOfSpeech", value);
         }
         /// <summary>
         /// (optional, string) Only returns words that have dictionary definitions when true. Otherwise false. Defaults to true.
         /// </summary>
         /// <param name="value">Value of the HasDefinition input for this Choreo.</param>
         public void setHasDefinition(String value) {
             base.addInput ("HasDefinition", value);
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
         /// (optional, integer) Maximum number of dictionaries in which the words appear.
         /// </summary>
         /// <param name="value">Value of the MaxDictionaries input for this Choreo.</param>
         public void setMaxDictionaries(String value) {
             base.addInput ("MaxDictionaries", value);
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
         /// (optional, integer) Minimum number of dictionaries in which the words appear.
         /// </summary>
         /// <param name="value">Value of the MinDictionaries input for this Choreo.</param>
         public void setMinDictionaries(String value) {
             base.addInput ("MinDictionaries", value);
         }
         /// <summary>
         /// (optional, integer) ?Minimum word length.
         /// </summary>
         /// <param name="value">Value of the MinLength input for this Choreo.</param>
         public void setMinLength(String value) {
             base.addInput ("MinLength", value);
         }
         /// <summary>
         /// (optional, string) Response can be either JSON or XML. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, string) Results can be sorted by: alpha, count, or length.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (optional, string) Indicate the order to sort, either asc (ascending) or desc (descending).
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RandomWordsResultSet containing execution metadata and results.</returns>
        new public RandomWordsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RandomWordsResultSet results = new JavaScriptSerializer().Deserialize<RandomWordsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RandomWords Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RandomWordsResultSet : Temboo.Core.ResultSet
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
