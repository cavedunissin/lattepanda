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
    /// SearchMessagesByRecipientAndDate
    /// Searches sent messages by Date and Recipient. Note that a sent message won't be immediately available for searching.
    /// </summary>
    public class SearchMessagesByRecipientAndDate : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchMessagesByRecipientAndDate Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchMessagesByRecipientAndDate(TembooSession session) : base(session, "/Library/Nexmo/Search/SearchMessagesByRecipientAndDate")
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
         /// (required, string) Date message was sent in the form of YYYY-MM-DD (UTC). (e.g. 2013-07-01)
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The recipient's phone number.  (e.g. 123456780)
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchMessagesByRecipientAndDateResultSet containing execution metadata and results.</returns>
        new public SearchMessagesByRecipientAndDateResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchMessagesByRecipientAndDateResultSet results = new JavaScriptSerializer().Deserialize<SearchMessagesByRecipientAndDateResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchMessagesByRecipientAndDate Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchMessagesByRecipientAndDateResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Nexmo. Corresponds to the ResponseFormat input. Defaults to json.  Note that if no matches are found for the specified Date and To, the Response will contain an error-code "-2".</returns>
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
