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

namespace Temboo.Library.Mixpanel.DataExport.Properties
{
    /// <summary>
    /// PropertyData
    /// Gets unique, total, or average data for of a single event and property over the last N days, weeks, or months.
    /// </summary>
    public class PropertyData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PropertyData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PropertyData(TembooSession session) : base(session, "/Library/Mixpanel/DataExport/Properties/PropertyData")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided my Mixpanel. You can find your Mixpanel API Key in the project settings dialog in the Mixpanel app.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The API Secret provided by Mixpanel. You can find your Mixpanel API Secret in the project settings dialog in the Mixpanel app.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (required, string) The name of the event that you wish to get data for.
         /// </summary>
         /// <param name="value">Value of the EventName input for this Choreo.</param>
         public void setEventName(String value) {
             base.addInput ("EventName", value);
         }
         /// <summary>
         /// (optional, integer) The amount of minutes past NOW() before the request will expire. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Expire input for this Choreo.</param>
         public void setExpire(String value) {
             base.addInput ("Expire", value);
         }
         /// <summary>
         /// (required, integer) The time interval to return. This relates to the value provided for Unit.
         /// </summary>
         /// <param name="value">Value of the Interval input for this Choreo.</param>
         public void setInterval(String value) {
             base.addInput ("Interval", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of values to return. Defaults to 255.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, string) The name of the property you would like to get data for.
         /// </summary>
         /// <param name="value">Value of the PropertyName input for this Choreo.</param>
         public void setPropertyName(String value) {
             base.addInput ("PropertyName", value);
         }
         /// <summary>
         /// (optional, json) A JSON array containing property values that you wish to retrieve.
         /// </summary>
         /// <param name="value">Value of the PropertyValues input for this Choreo.</param>
         public void setPropertyValues(String value) {
             base.addInput ("PropertyValues", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and csv.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The analysis type you would like to get data for. Valid values are: general, unique, or average
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (required, string) The granularity of the data to return. Valid values are: minute, hour, day, week, or month.
         /// </summary>
         /// <param name="value">Value of the Unit input for this Choreo.</param>
         public void setUnit(String value) {
             base.addInput ("Unit", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PropertyDataResultSet containing execution metadata and results.</returns>
        new public PropertyDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PropertyDataResultSet results = new JavaScriptSerializer().Deserialize<PropertyDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PropertyData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PropertyDataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Mixpanel.</returns>
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
