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

namespace Temboo.Library.Uber.Products
{
    /// <summary>
    /// GetProductTypes
    /// Returns information about the Uber products offered at a given location.
    /// </summary>
    public class GetProductTypes : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetProductTypes Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetProductTypes(TembooSession session) : base(session, "/Library/Uber/Products/GetProductTypes")
        {
        }

         /// <summary>
         /// (required, decimal) The latitude coordinate for the location e.g., 40.71863.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) The longitude coordinate for the location e.g., -74.005584.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (required, string) The Sever Token provided by Uber.
         /// </summary>
         /// <param name="value">Value of the ServerToken input for this Choreo.</param>
         public void setServerToken(String value) {
             base.addInput ("ServerToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetProductTypesResultSet containing execution metadata and results.</returns>
        new public GetProductTypesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetProductTypesResultSet results = new JavaScriptSerializer().Deserialize<GetProductTypesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetProductTypes Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetProductTypesResultSet : Temboo.Core.ResultSet
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
