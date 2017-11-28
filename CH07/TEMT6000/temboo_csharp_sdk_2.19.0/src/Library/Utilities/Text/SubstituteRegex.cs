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

namespace Temboo.Library.Utilities.Text
{
    /// <summary>
    /// SubstituteRegex
    /// Finds all instances of the specified regular expression pattern within the given string and passes the specified new sub-string to the result variable. 
    /// </summary>
    public class SubstituteRegex : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SubstituteRegex Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SubstituteRegex(TembooSession session) : base(session, "/Library/Utilities/Text/SubstituteRegex")
        {
        }

         /// <summary>
         /// (required, string) New sub-string to replace with.
         /// </summary>
         /// <param name="value">Value of the New input for this Choreo.</param>
         public void setNew(String value) {
             base.addInput ("New", value);
         }
         /// <summary>
         /// (required, string) Regex pattern to use.
         /// </summary>
         /// <param name="value">Value of the Pattern input for this Choreo.</param>
         public void setPattern(String value) {
             base.addInput ("Pattern", value);
         }
         /// <summary>
         /// (required, string) Text to peform substitution.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SubstituteRegexResultSet containing execution metadata and results.</returns>
        new public SubstituteRegexResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SubstituteRegexResultSet results = new JavaScriptSerializer().Deserialize<SubstituteRegexResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SubstituteRegex Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SubstituteRegexResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) The result after the substitution.</returns>
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
