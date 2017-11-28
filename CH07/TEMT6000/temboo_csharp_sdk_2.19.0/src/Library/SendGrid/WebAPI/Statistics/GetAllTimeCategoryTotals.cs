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

namespace Temboo.Library.SendGrid.WebAPI.Statistics
{
    /// <summary>
    /// GetAllTimeCategoryTotals
    /// Obtain statistics by specified categories.
    /// </summary>
    public class GetAllTimeCategoryTotals : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetAllTimeCategoryTotals Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetAllTimeCategoryTotals(TembooSession session) : base(session, "/Library/SendGrid/WebAPI/Statistics/GetAllTimeCategoryTotals")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The username registered with SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIUser input for this Choreo.</param>
         public void setAPIUser(String value) {
             base.addInput ("APIUser", value);
         }
         /// <summary>
         /// (required, integer) Retrieve category statistics.  Default is set to 1.
         /// </summary>
         /// <param name="value">Value of the Aggregate input for this Choreo.</param>
         public void setAggregate(String value) {
             base.addInput ("Aggregate", value);
         }
         /// <summary>
         /// (required, string) Enter a category for which statistics will be retrieved. It must be an existing category that has statistics. If the category entered does not exist, an empty result set will be returned.
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
         }
         /// <summary>
         /// (optional, integer) The number of days (greater than 0) for which block data will be retrieved. Note that you can use either the days parameter or the start_date and end_date parameter.
         /// </summary>
         /// <param name="value">Value of the Days input for this Choreo.</param>
         public void setDays(String value) {
             base.addInput ("Days", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from SendGrid, in either json, or xml.  Default is set to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The start of the date range for which blocks are to be retireved. The specified date must be in YYYY-MM-DD format, and must be earlier than the EndDate variable value. Use this ,or Days.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetAllTimeCategoryTotalsResultSet containing execution metadata and results.</returns>
        new public GetAllTimeCategoryTotalsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetAllTimeCategoryTotalsResultSet results = new JavaScriptSerializer().Deserialize<GetAllTimeCategoryTotalsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetAllTimeCategoryTotals Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetAllTimeCategoryTotalsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from SendGrid. The format corresponds to the ResponseFormat input. Default is json.</returns>
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
