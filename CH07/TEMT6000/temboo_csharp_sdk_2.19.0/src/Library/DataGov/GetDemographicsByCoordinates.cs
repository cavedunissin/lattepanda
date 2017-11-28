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

namespace Temboo.Library.DataGov
{
    /// <summary>
    /// GetDemographicsByCoordinates
    /// Retrieve demographic information for specified geographical coordinates.
    /// </summary>
    public class GetDemographicsByCoordinates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetDemographicsByCoordinates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetDemographicsByCoordinates(TembooSession session) : base(session, "/Library/DataGov/GetDemographicsByCoordinates")
        {
        }

         /// <summary>
         /// (optional, string) Specify the data version to search. Valid values are 2011 or 2012 (the default).
         /// </summary>
         /// <param name="value">Value of the DataVersion input for this Choreo.</param>
         public void setDataVersion(String value) {
             base.addInput ("DataVersion", value);
         }
         /// <summary>
         /// (required, decimal) Specify a latitude to search for, such as "41.486857".
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) Specify a longitude to search for, such as "-71.294392".
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetDemographicsByCoordinatesResultSet containing execution metadata and results.</returns>
        new public GetDemographicsByCoordinatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetDemographicsByCoordinatesResultSet results = new JavaScriptSerializer().Deserialize<GetDemographicsByCoordinatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetDemographicsByCoordinates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetDemographicsByCoordinatesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response returned from the API.</returns>
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
