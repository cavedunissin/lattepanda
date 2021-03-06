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

namespace Temboo.Library.Xively.Devices
{
    /// <summary>
    /// ListAllDevices
    /// Returns a paged list of devices belonging to a specific product.
    /// </summary>
    public class ListAllDevices : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListAllDevices Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListAllDevices(TembooSession session) : base(session, "/Library/Xively/Devices/ListAllDevices")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Filter for returning device serial numbers in the requested activation state. Valid values: "all" (default), "true" or "false".
         /// </summary>
         /// <param name="value">Value of the Activated input for this Choreo.</param>
         public void setActivated(String value) {
             base.addInput ("Activated", value);
         }
         /// <summary>
         /// (optional, integer) Indicates which page of results you are requesting. Starts from 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) Defines how many results to return per page (1 to 1000, default is 30).
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (required, string) The ID for the product you would like to retrieve the list of devices for.
         /// </summary>
         /// <param name="value">Value of the ProductID input for this Choreo.</param>
         public void setProductID(String value) {
             base.addInput ("ProductID", value);
         }
         /// <summary>
         /// (optional, string) Filter by providing an exact or partial serial number string. Letters are case-insensitive. Ex: inputting 'abc' will return serials that contain 'Abc',  'aBc' and 'abc', but not 'ab-c'.
         /// </summary>
         /// <param name="value">Value of the SerialNumber input for this Choreo.</param>
         public void setSerialNumber(String value) {
             base.addInput ("SerialNumber", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListAllDevicesResultSet containing execution metadata and results.</returns>
        new public ListAllDevicesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListAllDevicesResultSet results = new JavaScriptSerializer().Deserialize<ListAllDevicesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListAllDevices Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListAllDevicesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Xively.</returns>
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
