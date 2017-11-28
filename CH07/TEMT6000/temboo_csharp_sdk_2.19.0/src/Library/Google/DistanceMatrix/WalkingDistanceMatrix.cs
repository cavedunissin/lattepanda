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

namespace Temboo.Library.Google.DistanceMatrix
{
    /// <summary>
    /// WalkingDistanceMatrix
    /// Obtain walking distances and times for a matrix of addresses and/or latitude/longitude coordinates.
    /// </summary>
    public class WalkingDistanceMatrix : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WalkingDistanceMatrix Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WalkingDistanceMatrix(TembooSession session) : base(session, "/Library/Google/DistanceMatrix/WalkingDistanceMatrix")
        {
        }

         /// <summary>
         /// (optional, string) If set to true, additional routes will be returned.
         /// </summary>
         /// <param name="value">Value of the Alternatives input for this Choreo.</param>
         public void setAlternatives(String value) {
             base.addInput ("Alternatives", value);
         }
         /// <summary>
         /// (required, string) Enter the address or latitude/longitude coordinates to which directions will be generated. Multiple destinations can be separated by pipes (|).  For example: Boston, MA|New Haven|40.7160,-74.0037.
         /// </summary>
         /// <param name="value">Value of the Destinations input for this Choreo.</param>
         public void setDestinations(String value) {
             base.addInput ("Destinations", value);
         }
         /// <summary>
         /// (optional, string) Set the language in which to return restults.  A list of supported languages is available here: https://spreadsheets.google.com/pub?key=p9pdwsai2hDMsLkXsoM05KQ&gid=1
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (required, string) Enter the address(es) or geo-coordinates from which distance and time will be computed. Multiple destinations can be separated by pipes (|).  For example: Boston, MA|New Haven|40.7160,-74.0037.
         /// </summary>
         /// <param name="value">Value of the Origins input for this Choreo.</param>
         public void setOrigins(String value) {
             base.addInput ("Origins", value);
         }
         /// <summary>
         /// (optional, string) Enter the region code for the directions, specified as a ccTLD two-character value.
         /// </summary>
         /// <param name="value">Value of the Region input for this Choreo.</param>
         public void setRegion(String value) {
             base.addInput ("Region", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether or not the directions request is from a device with a location sensor. Value must be either 1 or 0. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the Sensor input for this Choreo.</param>
         public void setSensor(String value) {
             base.addInput ("Sensor", value);
         }
         /// <summary>
         /// (optional, string) Specify the units to be used when displaying results.  Options include, metric, or imperial.
         /// </summary>
         /// <param name="value">Value of the Units input for this Choreo.</param>
         public void setUnits(String value) {
             base.addInput ("Units", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WalkingDistanceMatrixResultSet containing execution metadata and results.</returns>
        new public WalkingDistanceMatrixResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WalkingDistanceMatrixResultSet results = new JavaScriptSerializer().Deserialize<WalkingDistanceMatrixResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WalkingDistanceMatrix Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WalkingDistanceMatrixResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Distance" output from this Choreo execution
        /// <returns>String - (integer) The distance of this route, expressed in meters.</returns>
        /// </summary>
        public String Distance
        {
            get
            {
                return (String) base.Output["Distance"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Duration" output from this Choreo execution
        /// <returns>String - (integer) The duration of this route, expressed in meters.</returns>
        /// </summary>
        public String Duration
        {
            get
            {
                return (String) base.Output["Duration"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Google.</returns>
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
