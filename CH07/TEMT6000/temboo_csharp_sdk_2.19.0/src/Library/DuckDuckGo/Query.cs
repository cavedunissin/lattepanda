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

namespace Temboo.Library.DuckDuckGo
{
    /// <summary>
    /// Query
    /// Access DuckDuckGo web search functionality.  
    /// </summary>
    public class Query : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Query Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Query(TembooSession session) : base(session, "/Library/DuckDuckGo/Query")
        {
        }

         /// <summary>
         /// (optional, string) Enter: xml, or json.  Default is set to xml.
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (optional, integer) Enter 1 to remove HTML from text. Set only if Format=json.
         /// </summary>
         /// <param name="value">Value of the NoHTML input for this Choreo.</param>
         public void setNoHTML(String value) {
             base.addInput ("NoHTML", value);
         }
         /// <summary>
         /// (optional, integer) Enter 1 to skip HTTP redirects.  This is useful for !bang commands. Set only if Format=json.
         /// </summary>
         /// <param name="value">Value of the NoRedirect input for this Choreo.</param>
         public void setNoRedirect(String value) {
             base.addInput ("NoRedirect", value);
         }
         /// <summary>
         /// (optional, integer) Enter 1 to pretty-print the JSON output.
         /// </summary>
         /// <param name="value">Value of the PrettyPrint input for this Choreo.</param>
         public void setPrettyPrint(String value) {
             base.addInput ("PrettyPrint", value);
         }
         /// <summary>
         /// (required, string) Enter a search query.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, integer) Enter 1 to skip disambiguation. Set only if Format=json.
         /// </summary>
         /// <param name="value">Value of the SkipDisambiguation input for this Choreo.</param>
         public void setSkipDisambiguation(String value) {
             base.addInput ("SkipDisambiguation", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A QueryResultSet containing execution metadata and results.</returns>
        new public QueryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            QueryResultSet results = new JavaScriptSerializer().Deserialize<QueryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Query Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class QueryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from DuckDuckGo in XML or JSON format.</returns>
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
