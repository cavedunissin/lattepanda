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
    /// UserPlaceReports
    /// Add a new Place to Google Places.
    /// </summary>
    public class UserPlaceReports : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UserPlaceReports Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UserPlaceReports(TembooSession session) : base(session, "/Library/Google/Places/UserPlaceReports")
        {
        }

         /// <summary>
         /// (optional, json) A JSON request body containing the information about the place. This can be specified as an alternative to specifying individual place properties. See Choreo notes for details about formatting.
         /// </summary>
         /// <param name="value">Value of the POSTForm input for this Choreo.</param>
         public void setPOSTForm(String value) {
             base.addInput ("POSTForm", value);
         }
         /// <summary>
         /// (conditional, decimal) The accuracy of the location signal on which this request is based, expressed in meters.
         /// </summary>
         /// <param name="value">Value of the Accuracy input for this Choreo.</param>
         public void setAccuracy(String value) {
             base.addInput ("Accuracy", value);
         }
         /// <summary>
         /// (optional, string) The address of the place you wish to add.
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (required, string) The API Key provided by Google.
         /// </summary>
         /// <param name="value">Value of the Key input for this Choreo.</param>
         public void setKey(String value) {
             base.addInput ("Key", value);
         }
         /// <summary>
         /// (conditional, string) The language in which the place's name is being reported.
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (required, decimal) The latitude point for the place you wish to add (e.g., 38.898717).
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude coordinate for the place you wish to add (e.g., -77.035974).
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (required, string) The full text name of the place
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) The phone number associated with the place.
         /// </summary>
         /// <param name="value">Value of the PhoneNumber input for this Choreo.</param>
         public void setPhoneNumber(String value) {
             base.addInput ("PhoneNumber", value);
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
         /// (required, json) A JSON array of categories in which this place belongs.
         /// </summary>
         /// <param name="value">Value of the Types input for this Choreo.</param>
         public void setTypes(String value) {
             base.addInput ("Types", value);
         }
         /// <summary>
         /// (optional, string) A URL pointing to the authoritative website for this Place, such as a business home page.
         /// </summary>
         /// <param name="value">Value of the Website input for this Choreo.</param>
         public void setWebsite(String value) {
             base.addInput ("Website", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UserPlaceReportsResultSet containing execution metadata and results.</returns>
        new public UserPlaceReportsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UserPlaceReportsResultSet results = new JavaScriptSerializer().Deserialize<UserPlaceReportsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UserPlaceReports Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UserPlaceReportsResultSet : Temboo.Core.ResultSet
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
