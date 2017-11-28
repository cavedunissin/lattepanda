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

namespace Temboo.Library.Mixpanel.DataExport.Segmentation
{
    /// <summary>
    /// Numeric
    /// Gets data for an event, segmented and filtered by properties, with values placed into numeric buckets.
    /// </summary>
    public class Numeric : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Numeric Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Numeric(TembooSession session) : base(session, "/Library/Mixpanel/DataExport/Segmentation/Numeric")
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
         /// (required, integer) The number of buckets that you wish to divide the numeric values up into. Bucket ranges are automatically computed based on the maximum and minimum of the 'On' expression.
         /// </summary>
         /// <param name="value">Value of the Buckets input for this Choreo.</param>
         public void setBuckets(String value) {
             base.addInput ("Buckets", value);
         }
         /// <summary>
         /// (required, string) The event that you wish to segment on.
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
         /// (required, date) The date in yyyy-mm-dd format from which to begin querying for the event from. This date is inclusive.
         /// </summary>
         /// <param name="value">Value of the FromDate input for this Choreo.</param>
         public void setFromDate(String value) {
             base.addInput ("FromDate", value);
         }
         /// <summary>
         /// (required, string) The property expression to segment the event on. Must be a numeric expression (e.g., number(properties["time"]). See Choreo description for examples.
         /// </summary>
         /// <param name="value">Value of the On input for this Choreo.</param>
         public void setOn(String value) {
             base.addInput ("On", value);
         }
         /// <summary>
         /// (required, date) The date in yyyy-mm-dd format from which to stop querying for the event from. This date is inclusive.
         /// </summary>
         /// <param name="value">Value of the ToDate input for this Choreo.</param>
         public void setToDate(String value) {
             base.addInput ("ToDate", value);
         }
         /// <summary>
         /// (optional, string) The analysis type you would like to get data for. Valid values are: general, unique, or average
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (optional, string) Determines the buckets into which the property values that you segment on are placed. Valid values are: hour or day.
         /// </summary>
         /// <param name="value">Value of the Unit input for this Choreo.</param>
         public void setUnit(String value) {
             base.addInput ("Unit", value);
         }
         /// <summary>
         /// (optional, string) An expression to filter events by  (e.g., number(properties["time"]) >= 2000). See Choreo description for examples.
         /// </summary>
         /// <param name="value">Value of the Where input for this Choreo.</param>
         public void setWhere(String value) {
             base.addInput ("Where", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A NumericResultSet containing execution metadata and results.</returns>
        new public NumericResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            NumericResultSet results = new JavaScriptSerializer().Deserialize<NumericResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Numeric Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class NumericResultSet : Temboo.Core.ResultSet
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
