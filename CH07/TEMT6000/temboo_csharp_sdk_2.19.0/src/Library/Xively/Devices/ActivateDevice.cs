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
    /// ActivateDevice
    /// Activates (or reactivates) a device given an authorization code. Returns the device API Key and Feed ID. 
    /// </summary>
    public class ActivateDevice : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ActivateDevice Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ActivateDevice(TembooSession session) : base(session, "/Library/Xively/Devices/ActivateDevice")
        {
        }

         /// <summary>
         /// (optional, string) Not required for first activation. If re-activating a device, either the original device APIKey returned from the first activation or the master APIKey is required.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Activation code provided when pre-registering a device with a serial number.
         /// </summary>
         /// <param name="value">Value of the ActivationCode input for this Choreo.</param>
         public void setActivationCode(String value) {
             base.addInput ("ActivationCode", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ActivateDeviceResultSet containing execution metadata and results.</returns>
        new public ActivateDeviceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ActivateDeviceResultSet results = new JavaScriptSerializer().Deserialize<ActivateDeviceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ActivateDevice Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ActivateDeviceResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Xively. Upon successful activation, it returns a JSON array containing the device APIKey, FeedID and Datastreams.</returns>
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
