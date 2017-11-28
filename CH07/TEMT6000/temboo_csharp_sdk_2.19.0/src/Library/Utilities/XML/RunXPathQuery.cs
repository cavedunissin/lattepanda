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

namespace Temboo.Library.Utilities.XML
{
    /// <summary>
    /// RunXPathQuery
    /// Executes an XPath query against a specified XML file and returns the result in CSV or JSON format.
    /// </summary>
    public class RunXPathQuery : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RunXPathQuery Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RunXPathQuery(TembooSession session) : base(session, "/Library/Utilities/XML/RunXPathQuery")
        {
        }

         /// <summary>
         /// (conditional, string) Valid values are "select" (the default) or "recursive". Recursive mode will iterate using the provided XPath. Select mode will return the first match if there are multiple rows in the XML provided.
         /// </summary>
         /// <param name="value">Value of the Mode input for this Choreo.</param>
         public void setMode(String value) {
             base.addInput ("Mode", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json or csv.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, xml) The XML that contains the elements or attributes you want to retrieve.
         /// </summary>
         /// <param name="value">Value of the XML input for this Choreo.</param>
         public void setXML(String value) {
             base.addInput ("XML", value);
         }
         /// <summary>
         /// (required, string) The XPath query to run.
         /// </summary>
         /// <param name="value">Value of the XPath input for this Choreo.</param>
         public void setXPath(String value) {
             base.addInput ("XPath", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RunXPathQueryResultSet containing execution metadata and results.</returns>
        new public RunXPathQueryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RunXPathQueryResultSet results = new JavaScriptSerializer().Deserialize<RunXPathQueryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RunXPathQuery Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RunXPathQueryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Result" output from this Choreo execution
        /// <returns>String - The XPath query result.</returns>
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
