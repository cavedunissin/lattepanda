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

namespace Temboo.Library.CorpWatch.Relationships
{
    /// <summary>
    /// CompanyChildren
    /// Returns a list of the subsidiaries, or "children," of a company.
    /// </summary>
    public class CompanyChildren : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CompanyChildren Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CompanyChildren(TembooSession session) : base(session, "/Library/CorpWatch/Relationships/CompanyChildren")
        {
        }

         /// <summary>
         /// (optional, string) The APIKey from CorpWatch if you have one.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) CoprWatch ID for the company. Format looks like: cw_8484.
         /// </summary>
         /// <param name="value">Value of the CWID input for this Choreo.</param>
         public void setCWID(String value) {
             base.addInput ("CWID", value);
         }
         /// <summary>
         /// (optional, integer) Set the index number of the first result to be returned. The index of the first result is 0.
         /// </summary>
         /// <param name="value">Value of the Index input for this Choreo.</param>
         public void setIndex(String value) {
             base.addInput ("Index", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to be returned. Defaults to 100. Maximum is 5000.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) Specify json or xml for the type of response to be returned. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (conditional, integer) If a year is specified, only subsidiaries for that year will be returned and the data in the company objects returned will be set appropriately for the request year. Defaults to 2012 (most recent yr).
         /// </summary>
         /// <param name="value">Value of the Year input for this Choreo.</param>
         public void setYear(String value) {
             base.addInput ("Year", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CompanyChildrenResultSet containing execution metadata and results.</returns>
        new public CompanyChildrenResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CompanyChildrenResultSet results = new JavaScriptSerializer().Deserialize<CompanyChildrenResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CompanyChildren Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CompanyChildrenResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from CorpWatch.</returns>
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
