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

namespace Temboo.Library.LittleSis.Relationship
{
    /// <summary>
    /// GetBatchRelationships
    /// Retrieves information about a batch of relationships in LittleSis according to the relationship IDs provided.
    /// </summary>
    public class GetBatchRelationships : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetBatchRelationships Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetBatchRelationships(TembooSession session) : base(session, "/Library/LittleSis/Relationship/GetBatchRelationships")
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
         /// (optional, integer) Indicate 1 to include details for each relationship record returned. Otherwise, only a basic record will be returned.
         /// </summary>
         /// <param name="value">Value of the Details input for this Choreo.</param>
         public void setDetails(String value) {
             base.addInput ("Details", value);
         }
         /// <summary>
         /// (required, string) The IDs of the relationship records to be returned as a comma delimited string.
         /// </summary>
         /// <param name="value">Value of the RelationshipIDs input for this Choreo.</param>
         public void setRelationshipIDs(String value) {
             base.addInput ("RelationshipIDs", value);
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
        /// <returns>A GetBatchRelationshipsResultSet containing execution metadata and results.</returns>
        new public GetBatchRelationshipsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetBatchRelationshipsResultSet results = new JavaScriptSerializer().Deserialize<GetBatchRelationshipsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetBatchRelationships Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetBatchRelationshipsResultSet : Temboo.Core.ResultSet
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
