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

namespace Temboo.Library.Google.Places
{
    /// <summary>
    /// PlaceDetails
    /// Retrieve detailed information about places retrieved by the PlaceSearch Choreo.
    /// </summary>
    public class PlaceDetails : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PlaceDetails Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PlaceDetails(TembooSession session) : base(session, "/Library/Google/Places/PlaceDetails")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Google.
         /// </summary>
         /// <param name="value">Value of the Key input for this Choreo.</param>
         public void setKey(String value) {
             base.addInput ("Key", value);
         }
         /// <summary>
         /// (optional, string) The language code, indicating in which language the results should be returned, if possible. See Choreo notes for a list of supported languages and their codes.
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (conditional, string) A textual identifier that uniquely identifies a place. PlaceIDs are returned by the PlaceSearch Choreo.
         /// </summary>
         /// <param name="value">Value of the PlaceID input for this Choreo.</param>
         public void setPlaceID(String value) {
             base.addInput ("PlaceID", value);
         }
         /// <summary>
         /// (optional, string) A textual identifier that uniquely identifies a place. Note, this parameter is deprecated as of June 24, 2014. Use PlaceID instead.
         /// </summary>
         /// <param name="value">Value of the Reference input for this Choreo.</param>
         public void setReference(String value) {
             base.addInput ("Reference", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether or not the directions request is from a device with a location sensor. Value must be either 1 or 0. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the Sensor input for this Choreo.</param>
         public void setSensor(String value) {
             base.addInput ("Sensor", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PlaceDetailsResultSet containing execution metadata and results.</returns>
        new public PlaceDetailsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PlaceDetailsResultSet results = new JavaScriptSerializer().Deserialize<PlaceDetailsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PlaceDetails Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PlaceDetailsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Google.</returns>
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
