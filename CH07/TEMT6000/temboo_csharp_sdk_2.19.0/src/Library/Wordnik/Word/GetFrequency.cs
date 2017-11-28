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

namespace Temboo.Library.Wordnik.Word
{
    /// <summary>
    /// GetFrequency
    /// Retrieves the word frequency of a given word.
    /// </summary>
    public class GetFrequency : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetFrequency Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetFrequency(TembooSession session) : base(session, "/Library/Wordnik/Word/GetFrequency")
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
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Cannonical input for this Choreo.</param>
         public void setCannonical(String value) {
             base.addInput ("Cannonical", value);
         }
         /// <summary>
         /// (optional, integer) End year for which to return word use frequencies. Defaults to 2012.
         /// </summary>
         /// <param name="value">Value of the EndYear input for this Choreo.</param>
         public void setEndYear(String value) {
             base.addInput ("EndYear", value);
         }
         /// <summary>
         /// (optional, string) Response can be either JSON or XML. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, integer) Start year for which to return word use frequencies. Defaults to 1800.
         /// </summary>
         /// <param name="value">Value of the StartYear input for this Choreo.</param>
         public void setStartYear(String value) {
             base.addInput ("StartYear", value);
         }
         /// <summary>
         /// (optional, boolean) If true will try to return the correct word root ('cats' -> 'cat'). If false returns exactly what was requested. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the UseCanonical input for this Choreo.</param>
         public void setUseCanonical(String value) {
             base.addInput ("UseCanonical", value);
         }
         /// <summary>
         /// (required, string) The word you want to look up on Wordnik.
         /// </summary>
         /// <param name="value">Value of the Word input for this Choreo.</param>
         public void setWord(String value) {
             base.addInput ("Word", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetFrequencyResultSet containing execution metadata and results.</returns>
        new public GetFrequencyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetFrequencyResultSet results = new JavaScriptSerializer().Deserialize<GetFrequencyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetFrequency Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetFrequencyResultSet : Temboo.Core.ResultSet
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
