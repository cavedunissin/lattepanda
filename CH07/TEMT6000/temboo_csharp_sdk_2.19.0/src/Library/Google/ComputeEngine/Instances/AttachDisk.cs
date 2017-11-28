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

namespace Temboo.Library.Google.ComputeEngine.Instances
{
    /// <summary>
    /// AttachDisk
    /// Attaches a Disk resource to an instance.
    /// </summary>
    public class AttachDisk : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AttachDisk Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AttachDisk(TembooSession session) : base(session, "/Library/Google/ComputeEngine/Instances/AttachDisk")
        {
        }

         /// <summary>
         /// (optional, json) A JSON string containing the attached disk properties to set. This can be used as an alternative to the individual inputs representing the attached disk properties.
         /// </summary>
         /// <param name="value">Value of the AttachedDisk input for this Choreo.</param>
         public void setAttachedDisk(String value) {
             base.addInput ("AttachedDisk", value);
         }
         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, boolean) Whether or not this is a boot disk. Valid values are: true or false.
         /// </summary>
         /// <param name="value">Value of the Boot input for this Choreo.</param>
         public void setBoot(String value) {
             base.addInput ("Boot", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (conditional, string) The name of the disk to attach.
         /// </summary>
         /// <param name="value">Value of the DeviceName input for this Choreo.</param>
         public void setDeviceName(String value) {
             base.addInput ("DeviceName", value);
         }
         /// <summary>
         /// (optional, string) Comma-seperated list of fields you want to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (required, string) The name of the instance to attach a disk resource to.
         /// </summary>
         /// <param name="value">Value of the Instance input for this Choreo.</param>
         public void setInstance(String value) {
             base.addInput ("Instance", value);
         }
         /// <summary>
         /// (conditional, string) The mode in which to attach the disk. Valid values are: READ_WRITE or READ_ONLY.
         /// </summary>
         /// <param name="value">Value of the Mode input for this Choreo.</param>
         public void setMode(String value) {
             base.addInput ("Mode", value);
         }
         /// <summary>
         /// (required, string) The ID of a Google Compute project.
         /// </summary>
         /// <param name="value">Value of the Project input for this Choreo.</param>
         public void setProject(String value) {
             base.addInput ("Project", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (conditional, string) The URL to the Disk resource.
         /// </summary>
         /// <param name="value">Value of the Source input for this Choreo.</param>
         public void setSource(String value) {
             base.addInput ("Source", value);
         }
         /// <summary>
         /// (conditional, string) The type of disk. Valid values are: SCRATCH or PERSISTENT. Persistent disks must already exist before you can attach them.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (required, string) The name of the zone associated with this request.
         /// </summary>
         /// <param name="value">Value of the Zone input for this Choreo.</param>
         public void setZone(String value) {
             base.addInput ("Zone", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AttachDiskResultSet containing execution metadata and results.</returns>
        new public AttachDiskResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AttachDiskResultSet results = new JavaScriptSerializer().Deserialize<AttachDiskResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AttachDisk Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AttachDiskResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the RefreshToken is provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Google.</returns>
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
