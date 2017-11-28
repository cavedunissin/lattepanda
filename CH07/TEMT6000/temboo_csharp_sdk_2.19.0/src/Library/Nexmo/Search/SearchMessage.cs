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

namespace Temboo.Library.Nexmo.Search
{
    /// <summary>
    /// SearchMessage
    /// Search for a previously sent message by Message ID.  Note that a sent message won't be immediately available for search.
    /// </summary>
    public class SearchMessage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchMessage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchMessage(TembooSession session) : base(session, "/Library/Nexmo/Search/SearchMessage")
        {
        }

         /// <summary>
         /// (required, string) Your API Key provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Your API Secret provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (required, string) Your Message ID.
         /// </summary>
         /// <param name="value">Value of the MessageID input for this Choreo.</param>
         public void setMessageID(String value) {
             base.addInput ("MessageID", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchMessageResultSet containing execution metadata and results.</returns>
        new public SearchMessageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchMessageResultSet results = new JavaScriptSerializer().Deserialize<SearchMessageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchMessage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchMessageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Nexmo. Corresponds to the ResponseFormat input. Defaults to json.</returns>
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
