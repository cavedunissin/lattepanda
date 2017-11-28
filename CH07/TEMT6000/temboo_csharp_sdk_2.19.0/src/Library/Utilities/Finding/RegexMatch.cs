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

namespace Temboo.Library.Utilities.Finding
{
    /// <summary>
    /// RegexMatch
    /// Returns the first substring that matches the specified regular expression pattern in the specified string.
    /// </summary>
    public class RegexMatch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RegexMatch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RegexMatch(TembooSession session) : base(session, "/Library/Utilities/Finding/RegexMatch")
        {
        }

         /// <summary>
         /// (conditional, string) A regular expression.
         /// </summary>
         /// <param name="value">Value of the Pattern input for this Choreo.</param>
         public void setPattern(String value) {
             base.addInput ("Pattern", value);
         }
         /// <summary>
         /// (conditional, string) The text on which to perform a regex match.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RegexMatchResultSet containing execution metadata and results.</returns>
        new public RegexMatchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RegexMatchResultSet results = new JavaScriptSerializer().Deserialize<RegexMatchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RegexMatch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RegexMatchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Result" output from this Choreo execution
        /// <returns>String - (string) The result of the match.</returns>
        /// </summary>
        public String Result
        {
            get
            {
                return (String) base.Output["Result"];
            }
        }
    }
}
