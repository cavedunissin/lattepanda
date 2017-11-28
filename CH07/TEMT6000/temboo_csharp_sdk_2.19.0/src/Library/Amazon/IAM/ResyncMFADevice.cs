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

namespace Temboo.Library.Amazon.IAM
{
    /// <summary>
    /// ResyncMFADevice
    /// Synchronizes the specified MFA device with AWS servers.
    /// </summary>
    public class ResyncMFADevice : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ResyncMFADevice Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ResyncMFADevice(TembooSession session) : base(session, "/Library/Amazon/IAM/ResyncMFADevice")
        {
        }

         /// <summary>
         /// (required, string) The Access Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSAccessKeyId input for this Choreo.</param>
         public void setAWSAccessKeyId(String value) {
             base.addInput ("AWSAccessKeyId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (required, string) An authentication code emitted by the device.
         /// </summary>
         /// <param name="value">Value of the AuthenticationCode1 input for this Choreo.</param>
         public void setAuthenticationCode1(String value) {
             base.addInput ("AuthenticationCode1", value);
         }
         /// <summary>
         /// (required, string) A subsequent authentication code emitted by the device.
         /// </summary>
         /// <param name="value">Value of the AuthenticationCode2 input for this Choreo.</param>
         public void setAuthenticationCode2(String value) {
             base.addInput ("AuthenticationCode2", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The serial number that uniquely identifies the MFA device. For virtual MFA devices, the serial number is the same as the ARN.
         /// </summary>
         /// <param name="value">Value of the SerialNumber input for this Choreo.</param>
         public void setSerialNumber(String value) {
             base.addInput ("SerialNumber", value);
         }
         /// <summary>
         /// (required, string) Name of the user for whom you want to enable the MFA device.
         /// </summary>
         /// <param name="value">Value of the UserName input for this Choreo.</param>
         public void setUserName(String value) {
             base.addInput ("UserName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ResyncMFADeviceResultSet containing execution metadata and results.</returns>
        new public ResyncMFADeviceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ResyncMFADeviceResultSet results = new JavaScriptSerializer().Deserialize<ResyncMFADeviceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ResyncMFADevice Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ResyncMFADeviceResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Amazon.</returns>
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
