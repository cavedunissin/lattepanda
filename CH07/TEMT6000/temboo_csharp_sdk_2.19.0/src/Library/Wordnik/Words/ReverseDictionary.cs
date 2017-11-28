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
    /// ReverseDictionary
    /// Retrieves a reverse dictionary search for a given word.
    /// </summary>
    public class ReverseDictionary : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ReverseDictionary Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ReverseDictionary(TembooSession session) : base(session, "/Library/Wordnik/Words/ReverseDictionary")
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
         /// (optional, string) Exclude these comma-delimited source dictionaries: ahd, century, wiktionary,webster, wordnet.
         /// </summary>
         /// <param name="value">Value of the ExcludeSource input for this Choreo.</param>
         public void setExcludeSource(String value) {
             base.addInput ("ExcludeSource", value);
         }
         /// <summary>
         /// (optional, any) Expand terms by either: synonym or hypernym.
         /// </summary>
         /// <param name="value">Value of the ExpandTerms input for this Choreo.</param>
         public void setExpandTerms(String value) {
             base.addInput ("ExpandTerms", value);
         }
         /// <summary>
         /// (optional, string) Only includes the specified comma-delimited parts of speech. Acceptable values include: adjective, noun, etc. See docs for full list.
         /// </summary>
         /// <param name="value">Value of the IncludePartOfSpeech input for this Choreo.</param>
         public void setIncludePartOfSpeech(String value) {
             base.addInput ("IncludePartOfSpeech", value);
         }
         /// <summary>
         /// (optional, string) Only include these comma-delimited source dictionaries: ahd, century, wiktionary,webster, wordnet.
         /// </summary>
         /// <param name="value">Value of the IncludeSource input for this Choreo.</param>
         public void setIncludeSource(String value) {
             base.addInput ("IncludeSource", value);
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
         /// (optional, string) Restricts words and finds the closest sense to the one indicated.
         /// </summary>
         /// <param name="value">Value of the WordSense input for this Choreo.</param>
         public void setWordSense(String value) {
             base.addInput ("WordSense", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ReverseDictionaryResultSet containing execution metadata and results.</returns>
        new public ReverseDictionaryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ReverseDictionaryResultSet results = new JavaScriptSerializer().Deserialize<ReverseDictionaryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ReverseDictionary Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ReverseDictionaryResultSet : Temboo.Core.ResultSet
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
