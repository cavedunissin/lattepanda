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

namespace Temboo.Library.Socrata.SODA
{
    /// <summary>
    /// Query
    /// Performs queries against data on the Socrata Platform.
    /// </summary>
    public class Query : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Query Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Query(TembooSession session) : base(session, "/Library/Socrata/SODA/Query")
        {
        }

         /// <summary>
         /// (optional, string) The App Token provided by Socrata.
         /// </summary>
         /// <param name="value">Value of the AppToken input for this Choreo.</param>
         public void setAppToken(String value) {
             base.addInput ("AppToken", value);
         }
         /// <summary>
         /// (required, string) The domain used in the request (i.e. soda.demo.socrata.com).
         /// </summary>
         /// <param name="value">Value of the Domain input for this Choreo.</param>
         public void setDomain(String value) {
             base.addInput ("Domain", value);
         }
         /// <summary>
         /// (optional, string) Groups results based on the column name provided.
         /// </summary>
         /// <param name="value">Value of the Group input for this Choreo.</param>
         public void setGroup(String value) {
             base.addInput ("Group", value);
         }
         /// <summary>
         /// (optional, string) The maximum number of results to return. Used in combination with the Offset input for pagination. Defaults to 100.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) Indicates the starting point of the result set. Used in combination with the Limit input for pagination. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) Determines how results will be sorted. This input can take a column name, and can sort in either ascending or descending order (i.e. datetime asc).
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (required, string) The unique identifier for a dataset to retrieve (i.e 4tka-6guv or earthquakes).
         /// </summary>
         /// <param name="value">Value of the Resource input for this Choreo.</param>
         public void setResource(String value) {
             base.addInput ("Resource", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default), xml, csv, and rdf.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) A search clause. This wll do a full text search for a value.
         /// </summary>
         /// <param name="value">Value of the Search input for this Choreo.</param>
         public void setSearch(String value) {
             base.addInput ("Search", value);
         }
         /// <summary>
         /// (optional, string) Indicates which columns to return. If not specified, all columns will be returned.
         /// </summary>
         /// <param name="value">Value of the Select input for this Choreo.</param>
         public void setSelect(String value) {
             base.addInput ("Select", value);
         }
         /// <summary>
         /// (optional, string) Filters the results using a WHERE clause.
         /// </summary>
         /// <param name="value">Value of the Where input for this Choreo.</param>
         public void setWhere(String value) {
             base.addInput ("Where", value);
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
        /// Retrieve the value for the "Fields" output from this Choreo execution
        /// <returns>String - (json) This lists the fields returned in this response in a JSON array.</returns>
        /// </summary>
        public String Fields
        {
            get
            {
                return (String) base.Output["Fields"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Types" output from this Choreo execution
        /// <returns>String - (json) This is a list of SODA2 types in a JSON array. These will match up in the same order as the fields in X-SODA2-Fields.</returns>
        /// </summary>
        public String Types
        {
            get
            {
                return (String) base.Output["Types"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "LastModified" output from this Choreo execution
        /// <returns>String - (date) Contains the date returned in the Last-Modified response header.</returns>
        /// </summary>
        public String LastModified
        {
            get
            {
                return (String) base.Output["LastModified"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response form Socrata.</returns>
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
