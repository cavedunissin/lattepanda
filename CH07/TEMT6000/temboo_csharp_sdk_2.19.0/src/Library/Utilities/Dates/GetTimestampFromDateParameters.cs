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

namespace Temboo.Library.Utilities.Dates
{
    /// <summary>
    /// GetTimestampFromDateParameters
    /// Returns the specified date parameters, expressed as the number of seconds or milliseconds since January 1, 1970 (epoch time).
    /// </summary>
    public class GetTimestampFromDateParameters : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTimestampFromDateParameters Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTimestampFromDateParameters(TembooSession session) : base(session, "/Library/Utilities/Dates/GetTimestampFromDateParameters")
        {
        }

         /// <summary>
         /// (conditional, integer) Sets the day (1-31) of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Day input for this Choreo.</param>
         public void setDay(String value) {
             base.addInput ("Day", value);
         }
         /// <summary>
         /// (optional, string) Set to "seconds" to return the number of seconds since the epoch. Defaults to "milliseconds".
         /// </summary>
         /// <param name="value">Value of the Granularity input for this Choreo.</param>
         public void setGranularity(String value) {
             base.addInput ("Granularity", value);
         }
         /// <summary>
         /// (optional, integer) Sets the hours (0-23) of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Hour input for this Choreo.</param>
         public void setHour(String value) {
             base.addInput ("Hour", value);
         }
         /// <summary>
         /// (optional, integer) Sets the milliseconds (0-999) of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Milliseconds input for this Choreo.</param>
         public void setMilliseconds(String value) {
             base.addInput ("Milliseconds", value);
         }
         /// <summary>
         /// (optional, integer) Sets the minutes (0-59) of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Minute input for this Choreo.</param>
         public void setMinute(String value) {
             base.addInput ("Minute", value);
         }
         /// <summary>
         /// (conditional, integer) Sets the month (1-12) of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Month input for this Choreo.</param>
         public void setMonth(String value) {
             base.addInput ("Month", value);
         }
         /// <summary>
         /// (optional, integer) Sets the seconds (0-59) of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Second input for this Choreo.</param>
         public void setSecond(String value) {
             base.addInput ("Second", value);
         }
         /// <summary>
         /// (conditional, integer) Sets the year of the timestamp.
         /// </summary>
         /// <param name="value">Value of the Year input for this Choreo.</param>
         public void setYear(String value) {
             base.addInput ("Year", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTimestampFromDateParametersResultSet containing execution metadata and results.</returns>
        new public GetTimestampFromDateParametersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTimestampFromDateParametersResultSet results = new JavaScriptSerializer().Deserialize<GetTimestampFromDateParametersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTimestampFromDateParameters Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTimestampFromDateParametersResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Timestamp" output from this Choreo execution
        /// <returns>String - (date) A number representing the specified date and time, expressed as the number of seconds or milliseconds since January 1, 1970. The Granularity input is used to indicate seconds or milliseconds.</returns>
        /// </summary>
        public String Timestamp
        {
            get
            {
                return (String) base.Output["Timestamp"];
            }
        }
    }
}
