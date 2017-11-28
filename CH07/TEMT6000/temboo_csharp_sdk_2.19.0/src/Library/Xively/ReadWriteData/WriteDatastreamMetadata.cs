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

namespace Temboo.Library.Xively.ReadWriteData
{
    /// <summary>
    /// WriteDatastreamMetadata
    /// Allows you to easily update the metadata of your datastream.
    /// </summary>
    public class WriteDatastreamMetadata : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WriteDatastreamMetadata Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WriteDatastreamMetadata(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/WriteDatastreamMetadata")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The current value of the datastream. Leave empty to keep existing  CurrentValue. Type "BLANK" to clear existing value.
         /// </summary>
         /// <param name="value">Value of the CurrentValue input for this Choreo.</param>
         public void setCurrentValue(String value) {
             base.addInput ("CurrentValue", value);
         }
         /// <summary>
         /// (optional, json) Custom datastream formatted as a JSON array. See documentation for how to construct your own datastream feed. If custom DatastreamData is used, all other optional inputs are ignored.
         /// </summary>
         /// <param name="value">Value of the CustomDatastreamData input for this Choreo.</param>
         public void setCustomDatastreamData(String value) {
             base.addInput ("CustomDatastreamData", value);
         }
         /// <summary>
         /// (required, string) The ID of the Datastream you would like to add metadata to. Required unless you are using CustomDatastreamData.
         /// </summary>
         /// <param name="value">Value of the DatastreamID input for this Choreo.</param>
         public void setDatastreamID(String value) {
             base.addInput ("DatastreamID", value);
         }
         /// <summary>
         /// (required, integer) The ID for the feed that you would like to update.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (optional, string) The maximum value since the last reset. Leave empty to keep existing MaxValue. Type "BLANK" to clear existing value.
         /// </summary>
         /// <param name="value">Value of the MaxValue input for this Choreo.</param>
         public void setMaxValue(String value) {
             base.addInput ("MaxValue", value);
         }
         /// <summary>
         /// (optional, string) The minimum value since the last reset. Leave empty to keep existing MinValue. Type "BLANK" to clear existing value.
         /// </summary>
         /// <param name="value">Value of the MinValue input for this Choreo.</param>
         public void setMinValue(String value) {
             base.addInput ("MinValue", value);
         }
         /// <summary>
         /// (optional, string) Comma-separated list of searchable tags (the characters ', ", and commas are not allowed). Tags input overwrites previous tags, enter "BLANK" to clear all tags. Ex: "power,energy".
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (optional, string) The symbol of the Unit. Leave empty to keep existing UnitSymbol. Type "BLANK" to clear existing value. Ex: "C".
         /// </summary>
         /// <param name="value">Value of the UnitSymbol input for this Choreo.</param>
         public void setUnitSymbol(String value) {
             base.addInput ("UnitSymbol", value);
         }
         /// <summary>
         /// (optional, string) The type of Unit. Leave empty to keep existing UnitType. Type "BLANK" to clear existing value. Ex: "basicSI".
         /// </summary>
         /// <param name="value">Value of the UnitType input for this Choreo.</param>
         public void setUnitType(String value) {
             base.addInput ("UnitType", value);
         }
         /// <summary>
         /// (optional, string) The units of the datastream. Leave empty to keep existing Units. Type "BLANK" to clear existing Units. Ex: "Celsius".
         /// </summary>
         /// <param name="value">Value of the Units input for this Choreo.</param>
         public void setUnits(String value) {
             base.addInput ("Units", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WriteDatastreamMetadataResultSet containing execution metadata and results.</returns>
        new public WriteDatastreamMetadataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WriteDatastreamMetadataResultSet results = new JavaScriptSerializer().Deserialize<WriteDatastreamMetadataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WriteDatastreamMetadata Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WriteDatastreamMetadataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful datastream update, the code should be 200.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
    }
}
