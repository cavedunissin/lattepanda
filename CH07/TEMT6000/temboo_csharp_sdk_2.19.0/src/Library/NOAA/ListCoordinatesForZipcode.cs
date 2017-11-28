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

namespace Temboo.Library.NOAA
{
    /// <summary>
    /// ListCoordinatesForZipcode
    /// Retrieve latitude and longitude data for a specified zipcode (in 50 U.S. States and Puerto Rico).
    /// </summary>
    public class ListCoordinatesForZipcode : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListCoordinatesForZipcode Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListCoordinatesForZipcode(TembooSession session) : base(session, "/Library/NOAA/ListCoordinatesForZipcode")
        {
        }

         /// <summary>
         /// (integer) Enter the zipcode for which latitude and longitude coordinates will be retrieved.
         /// </summary>
         /// <param name="value">Value of the ListZipCodeList input for this Choreo.</param>
         public void setListZipCodeList(String value) {
             base.addInput ("ListZipCodeList", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListCoordinatesForZipcodeResultSet containing execution metadata and results.</returns>
        new public ListCoordinatesForZipcodeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListCoordinatesForZipcodeResultSet results = new JavaScriptSerializer().Deserialize<ListCoordinatesForZipcodeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListCoordinatesForZipcode Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListCoordinatesForZipcodeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (XML) Response from NDFD servers.</returns>
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
