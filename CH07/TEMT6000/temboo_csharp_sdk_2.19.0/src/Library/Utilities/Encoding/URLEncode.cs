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

namespace Temboo.Library.Utilities.Encoding
{
    /// <summary>
    /// URLEncode
    /// Returns the specified text string in the application/x-www-form-urlencoded format.
    /// </summary>
    public class URLEncode : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the URLEncode Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public URLEncode(TembooSession session) : base(session, "/Library/Utilities/Encoding/URLEncode")
        {
        }

         /// <summary>
         /// (required, string) The text that should be URL encoded.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A URLEncodeResultSet containing execution metadata and results.</returns>
        new public URLEncodeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            URLEncodeResultSet results = new JavaScriptSerializer().Deserialize<URLEncodeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the URLEncode Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class URLEncodeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "URLEncodedText" output from this Choreo execution
        /// <returns>String - (string) The URL encoded text.</returns>
        /// </summary>
        public String URLEncodedText
        {
            get
            {
                return (String) base.Output["URLEncodedText"];
            }
        }
    }
}
