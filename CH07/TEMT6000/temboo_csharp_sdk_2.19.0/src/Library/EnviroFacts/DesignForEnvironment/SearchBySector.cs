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

namespace Temboo.Library.EnviroFacts.DesignForEnvironment
{
    /// <summary>
    /// SearchBySector
    /// Looks up products by sector in the EPA Design for the Environment database
    /// </summary>
    public class SearchBySector : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchBySector Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchBySector(TembooSession session) : base(session, "/Library/EnviroFacts/DesignForEnvironment/SearchBySector")
        {
        }

         /// <summary>
         /// (conditional, string) Specify either Industrial or Consumer to retrieve a list of products that fall into either category. If a specific SectorKeyword or SectorID is given, this input is ignored.
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
         }
         /// <summary>
         /// (optional, string) Default output is "CONTAINING" and does not require an operator, but users can enter "<", " >", "!=", "BEGINNING", "=" for more customized searches.
         /// </summary>
         /// <param name="value">Value of the Operator input for this Choreo.</param>
         public void setOperator(String value) {
             base.addInput ("Operator", value);
         }
         /// <summary>
         /// (conditional, string) Response can be returned in JSON or XML. Defaults to XML.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) Number 1 or greater indicates the ending row number of the results displayed. Default is 4999 when RowStart is 0. Up to 5000 entries are returned in the output.
         /// </summary>
         /// <param name="value">Value of the RowEnd input for this Choreo.</param>
         public void setRowEnd(String value) {
             base.addInput ("RowEnd", value);
         }
         /// <summary>
         /// (optional, integer) Indicates the starting row number of the results displayed. Default is 0.
         /// </summary>
         /// <param name="value">Value of the RowStart input for this Choreo.</param>
         public void setRowStart(String value) {
             base.addInput ("RowStart", value);
         }
         /// <summary>
         /// (conditional, integer) A number representing the unique identifier for the product's sector in the EnviroFacts database.
         /// </summary>
         /// <param name="value">Value of the SectorID input for this Choreo.</param>
         public void setSectorID(String value) {
             base.addInput ("SectorID", value);
         }
         /// <summary>
         /// (conditional, string) A keyword in the name of the sector to search for. If a specific SectorID is given, this input is ignored.
         /// </summary>
         /// <param name="value">Value of the SectorKeyword input for this Choreo.</param>
         public void setSectorKeyword(String value) {
             base.addInput ("SectorKeyword", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchBySectorResultSet containing execution metadata and results.</returns>
        new public SearchBySectorResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchBySectorResultSet results = new JavaScriptSerializer().Deserialize<SearchBySectorResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchBySector Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchBySectorResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Count" output from this Choreo execution
        /// <returns>String - The total number of records returned for any given search.</returns>
        /// </summary>
        public String Count
        {
            get
            {
                return (String) base.Output["Count"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from EnviroFacts.</returns>
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
