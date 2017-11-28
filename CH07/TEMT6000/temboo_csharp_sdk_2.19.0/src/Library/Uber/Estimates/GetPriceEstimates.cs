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

namespace Temboo.Library.Uber.Estimates
{
    /// <summary>
    /// GetPriceEstimates
    /// Returns an estimated price range for each product offered at a given location.
    /// </summary>
    public class GetPriceEstimates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetPriceEstimates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetPriceEstimates(TembooSession session) : base(session, "/Library/Uber/Estimates/GetPriceEstimates")
        {
        }

         /// <summary>
         /// (required, decimal) The latitude coordinate for the destination e.g., 40.650729.
         /// </summary>
         /// <param name="value">Value of the EndLatitude input for this Choreo.</param>
         public void setEndLatitude(String value) {
             base.addInput ("EndLatitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude coordinate for the destination e.g., -74.009536.
         /// </summary>
         /// <param name="value">Value of the EndLongitude input for this Choreo.</param>
         public void setEndLongitude(String value) {
             base.addInput ("EndLongitude", value);
         }
         /// <summary>
         /// (required, string) The Sever Token provided by Uber.
         /// </summary>
         /// <param name="value">Value of the ServerToken input for this Choreo.</param>
         public void setServerToken(String value) {
             base.addInput ("ServerToken", value);
         }
         /// <summary>
         /// (required, decimal) The latitude coordinate for the starting location e.g., 40.71863.
         /// </summary>
         /// <param name="value">Value of the StartLatitude input for this Choreo.</param>
         public void setStartLatitude(String value) {
             base.addInput ("StartLatitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude coordinate for the starting location e.g., -74.005584.
         /// </summary>
         /// <param name="value">Value of the StartLongitude input for this Choreo.</param>
         public void setStartLongitude(String value) {
             base.addInput ("StartLongitude", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetPriceEstimatesResultSet containing execution metadata and results.</returns>
        new public GetPriceEstimatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetPriceEstimatesResultSet results = new JavaScriptSerializer().Deserialize<GetPriceEstimatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetPriceEstimates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetPriceEstimatesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Uber.</returns>
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
