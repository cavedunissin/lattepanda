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
    /// WriteLocationData
    /// Allows you to easily update the location data of your feed.
    /// </summary>
    public class WriteLocationData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WriteLocationData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WriteLocationData(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/WriteLocationData")
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
         /// (optional, string) Can be set to "mobile" to enable creating waypoints (lat, lon and elevation with timestamp), or "fixed" (default) for a single location. Leave empty to keep existing settings.
         /// </summary>
         /// <param name="value">Value of the Disposition input for this Choreo.</param>
         public void setDisposition(String value) {
             base.addInput ("Disposition", value);
         }
         /// <summary>
         /// (optional, string) The domain of the location, i.e. physical or virtual. Leave empty to keep existing Domain. Type "BLANK" to clear existing Domain. Ex: "physical".
         /// </summary>
         /// <param name="value">Value of the Domain input for this Choreo.</param>
         public void setDomain(String value) {
             base.addInput ("Domain", value);
         }
         /// <summary>
         /// (optional, decimal) Elevation in meters. Leave empty to keep previously existing Elevation. Type "BLANK" to clear existing Elevation. Ex: 20.5.
         /// </summary>
         /// <param name="value">Value of the Elevation input for this Choreo.</param>
         public void setElevation(String value) {
             base.addInput ("Elevation", value);
         }
         /// <summary>
         /// (required, integer) The ID for the feed that you would like to update.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (optional, decimal) Latitude coordinates. Leave empty to keep previously existing Latitude. Type "BLANK" to clear existing Latitude. Ex: 40.728194.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, decimal) Longitude coordinates. Leave empty to keep previously existing Location. Type "BLANK" to clear existing settings. Ex: -73.957316.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) Name of Location. Leave empty to keep existing Location. Type "BLANK" to clear existing settings. Ex.: "My Fitbit Tracker".
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WriteLocationDataResultSet containing execution metadata and results.</returns>
        new public WriteLocationDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WriteLocationDataResultSet results = new JavaScriptSerializer().Deserialize<WriteLocationDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WriteLocationData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WriteLocationDataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful feed location update, the code should be 200.</returns>
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
