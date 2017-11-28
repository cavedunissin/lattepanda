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
    /// GetDate
    /// Formats a specified timestamp, or generates the current date in a desired format.
    /// </summary>
    public class GetDate : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetDate Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetDate(TembooSession session) : base(session, "/Library/Utilities/Dates/GetDate")
        {
        }

         /// <summary>
         /// (optional, integer) Adds the specified number of days to the specified date serial number. A negative number will subtract.
         /// </summary>
         /// <param name="value">Value of the AddDays input for this Choreo.</param>
         public void setAddDays(String value) {
             base.addInput ("AddDays", value);
         }
         /// <summary>
         /// (optional, integer) Adds the specified number of hours to the specified date serial number. A negative number will subtract.
         /// </summary>
         /// <param name="value">Value of the AddHours input for this Choreo.</param>
         public void setAddHours(String value) {
             base.addInput ("AddHours", value);
         }
         /// <summary>
         /// (optional, integer) Adds the specified number of minutes to the specified date serial number. A negative number will subtract.
         /// </summary>
         /// <param name="value">Value of the AddMinutes input for this Choreo.</param>
         public void setAddMinutes(String value) {
             base.addInput ("AddMinutes", value);
         }
         /// <summary>
         /// (optional, integer) Adds the specified number of months to the specified date serial number. A negative number will subtract.
         /// </summary>
         /// <param name="value">Value of the AddMonths input for this Choreo.</param>
         public void setAddMonths(String value) {
             base.addInput ("AddMonths", value);
         }
         /// <summary>
         /// (optional, integer) Adds the specified number of seconds to the specified date serial number. A negative number will subtract.
         /// </summary>
         /// <param name="value">Value of the AddSeconds input for this Choreo.</param>
         public void setAddSeconds(String value) {
             base.addInput ("AddSeconds", value);
         }
         /// <summary>
         /// (optional, integer) Adds the specified number of years to the specified date serial number. A negative number will subtract.
         /// </summary>
         /// <param name="value">Value of the AddYears input for this Choreo.</param>
         public void setAddYears(String value) {
             base.addInput ("AddYears", value);
         }
         /// <summary>
         /// (conditional, string) The format that the timestamp should be in. Java SimpleDateFormat conventions are supported. Defaults to "yyyy-MM-dd HH:mm:ss".
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (optional, string) An ISO country code to specify locale.
         /// </summary>
         /// <param name="value">Value of the LocaleCountry input for this Choreo.</param>
         public void setLocaleCountry(String value) {
             base.addInput ("LocaleCountry", value);
         }
         /// <summary>
         /// (optional, string) An ISO language code to specify locale.
         /// </summary>
         /// <param name="value">Value of the LocaleLanguage input for this Choreo.</param>
         public void setLocaleLanguage(String value) {
             base.addInput ("LocaleLanguage", value);
         }
         /// <summary>
         /// (optional, string) A local variant code such as "NY" to add additional context for a locale.
         /// </summary>
         /// <param name="value">Value of the LocaleVariant input for this Choreo.</param>
         public void setLocaleVariant(String value) {
             base.addInput ("LocaleVariant", value);
         }
         /// <summary>
         /// (optional, integer) Sets the day of month (1-31) of the specified date serial number.
         /// </summary>
         /// <param name="value">Value of the SetDay input for this Choreo.</param>
         public void setSetDay(String value) {
             base.addInput ("SetDay", value);
         }
         /// <summary>
         /// (optional, integer) Sets the hours (0-23) of the specified date serial number.
         /// </summary>
         /// <param name="value">Value of the SetHour input for this Choreo.</param>
         public void setSetHour(String value) {
             base.addInput ("SetHour", value);
         }
         /// <summary>
         /// (optional, integer) Sets the minutes (0-59) of the specified date serial number.
         /// </summary>
         /// <param name="value">Value of the SetMinute input for this Choreo.</param>
         public void setSetMinute(String value) {
             base.addInput ("SetMinute", value);
         }
         /// <summary>
         /// (optional, integer) Sets the month (1-12) of the specified date serial number.
         /// </summary>
         /// <param name="value">Value of the SetMonth input for this Choreo.</param>
         public void setSetMonth(String value) {
             base.addInput ("SetMonth", value);
         }
         /// <summary>
         /// (optional, integer) Sets the seconds (0-59) of the specified date serial number.
         /// </summary>
         /// <param name="value">Value of the SetSecond input for this Choreo.</param>
         public void setSetSecond(String value) {
             base.addInput ("SetSecond", value);
         }
         /// <summary>
         /// (optional, integer) Sets the year (such as 1989) of the specified date serial number.
         /// </summary>
         /// <param name="value">Value of the SetYear input for this Choreo.</param>
         public void setSetYear(String value) {
             base.addInput ("SetYear", value);
         }
         /// <summary>
         /// (optional, string) The timezone to use for the date formatting function. Defaults to UTC.
         /// </summary>
         /// <param name="value">Value of the TimeZone input for this Choreo.</param>
         public void setTimeZone(String value) {
             base.addInput ("TimeZone", value);
         }
         /// <summary>
         /// (conditional, date) A number representing the desired formatted date and time, expressed as the number of milliseconds since January 1, 1970 (epoch time). If not provided, this defaults to NOW().
         /// </summary>
         /// <param name="value">Value of the Timestamp input for this Choreo.</param>
         public void setTimestamp(String value) {
             base.addInput ("Timestamp", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetDateResultSet containing execution metadata and results.</returns>
        new public GetDateResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetDateResultSet results = new JavaScriptSerializer().Deserialize<GetDateResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetDate Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetDateResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "FormattedDate" output from this Choreo execution
        /// <returns>String - (date) The formatted version of the timestamp.</returns>
        /// </summary>
        public String FormattedDate
        {
            get
            {
                return (String) base.Output["FormattedDate"];
            }
        }
    }
}
