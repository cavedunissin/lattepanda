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

namespace Temboo.Library.LittleSis.Entity
{
    /// <summary>
    /// GetSecondDegreeRelationships
    /// Retrieves a list of all the Entities (people or organizations) that are two-degrees removed by Relationships from the given Entity.
    /// </summary>
    public class GetSecondDegreeRelationships : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetSecondDegreeRelationships Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetSecondDegreeRelationships(TembooSession session) : base(session, "/Library/LittleSis/Entity/GetSecondDegreeRelationships")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from LittleSis.org.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Comma delimited list of Category IDs. Restricts the categories of Relationships that the given Entity and all first degree Entities returned should be connected through.
         /// </summary>
         /// <param name="value">Value of the Category1 input for this Choreo.</param>
         public void setCategory1(String value) {
             base.addInput ("Category1", value);
         }
         /// <summary>
         /// (optional, string) Comma delimited list of Category IDs. Restricts the categories of Relationships that the given Entity and all second degree Entities returned should be connected through.
         /// </summary>
         /// <param name="value">Value of the Category2 input for this Choreo.</param>
         public void setCategory2(String value) {
             base.addInput ("Category2", value);
         }
         /// <summary>
         /// (required, integer) The ID of the person or organization for which records are to be returned.
         /// </summary>
         /// <param name="value">Value of the EntityID input for this Choreo.</param>
         public void setEntityID(String value) {
             base.addInput ("EntityID", value);
         }
         /// <summary>
         /// (optional, integer) Specifies what number of results to show. Used in conjunction with Page parameter, a Number of 20 and a Page of 6 will show results 100-120. Defaults to 20.
         /// </summary>
         /// <param name="value">Value of the Number input for this Choreo.</param>
         public void setNumber(String value) {
             base.addInput ("Number", value);
         }
         /// <summary>
         /// (optional, integer) Specifies the order of the Entities returned in the first degree Relationship. Acceptable values: 1 or 2. See documentation for more on Relationship order.
         /// </summary>
         /// <param name="value">Value of the Order1 input for this Choreo.</param>
         public void setOrder1(String value) {
             base.addInput ("Order1", value);
         }
         /// <summary>
         /// (optional, integer) Specifies the order of the first degree Entity in the second degree Relationship. Acceptable values: 1 or 2. See documentation for more on Relationship order.
         /// </summary>
         /// <param name="value">Value of the Order2 input for this Choreo.</param>
         public void setOrder2(String value) {
             base.addInput ("Order2", value);
         }
         /// <summary>
         /// (optional, integer) Specifies what page of results to show. Used in conjunction with Number parameter. A number of 20 and a Page of 6 will show results 100-120.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, string) Format of the response returned by LittleSis.org. Acceptable inputs: xml or json. Defaults to xml
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetSecondDegreeRelationshipsResultSet containing execution metadata and results.</returns>
        new public GetSecondDegreeRelationshipsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetSecondDegreeRelationshipsResultSet results = new JavaScriptSerializer().Deserialize<GetSecondDegreeRelationshipsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetSecondDegreeRelationships Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetSecondDegreeRelationshipsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from LittleSis.org.</returns>
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
