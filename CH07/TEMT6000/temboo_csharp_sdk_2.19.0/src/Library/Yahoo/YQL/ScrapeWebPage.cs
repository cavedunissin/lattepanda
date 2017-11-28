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

namespace Temboo.Library.Yahoo.YQL
{
    /// <summary>
    /// ScrapeWebPage
    /// Scrapes HTML from a web page and converts it to JSON or XML so that it can be reused by an application.
    /// </summary>
    public class ScrapeWebPage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ScrapeWebPage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ScrapeWebPage(TembooSession session) : base(session, "/Library/Yahoo/YQL/ScrapeWebPage")
        {
        }

         /// <summary>
         /// (optional, boolean) When set to "true" (the default), additional debug information about the request is returned.
         /// </summary>
         /// <param name="value">Value of the Diagnostics input for this Choreo.</param>
         public void setDiagnostics(String value) {
             base.addInput ("Diagnostics", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The URL of the web page to scrape.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }
         /// <summary>
         /// (optional, string) An XPATH statement that can be used to extract specific information from the HTML.
         /// </summary>
         /// <param name="value">Value of the XPATH input for this Choreo.</param>
         public void setXPATH(String value) {
             base.addInput ("XPATH", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ScrapeWebPageResultSet containing execution metadata and results.</returns>
        new public ScrapeWebPageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ScrapeWebPageResultSet results = new JavaScriptSerializer().Deserialize<ScrapeWebPageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ScrapeWebPage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ScrapeWebPageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Yahoo.</returns>
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
