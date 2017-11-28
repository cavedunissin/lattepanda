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

namespace Temboo.Library.Google.ComputeEngine.Disks
{
    /// <summary>
    /// InsertDisk
    /// Creates a Persistent Disk resource in the specified project.
    /// </summary>
    public class InsertDisk : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the InsertDisk Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public InsertDisk(TembooSession session) : base(session, "/Library/Google/ComputeEngine/Disks/InsertDisk")
        {
        }

         /// <summary>
         /// (optional, json) A JSON string containing the disk resource properties you wish to set. This can be used as an alternative to individual inputs that represent disk properties.
         /// </summary>
         /// <param name="value">Value of the DiskResource input for this Choreo.</param>
         public void setDiskResource(String value) {
             base.addInput ("DiskResource", value);
         }
         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
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
         /// (required, string) The name of the persistent disk resource being created.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
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
         /// (conditional, string) Size of the persistent disk, specified in GB. This is optional when using a SourceSnapshot or SourceImage, otherwise it is required.
         /// </summary>
         /// <param name="value">Value of the SizeGB input for this Choreo.</param>
         public void setSizeGB(String value) {
             base.addInput ("SizeGB", value);
         }
         /// <summary>
         /// (conditional, string) The URL for the source image to apply to the disk. This is required if SizeGB or SourceSnapshot is not provided.
         /// </summary>
         /// <param name="value">Value of the SourceImage input for this Choreo.</param>
         public void setSourceImage(String value) {
             base.addInput ("SourceImage", value);
         }
         /// <summary>
         /// (conditional, string) The source snapshot used to create this disk. This is required if SizeGB and SourceImage are not specified.
         /// </summary>
         /// <param name="value">Value of the SourceSnapshot input for this Choreo.</param>
         public void setSourceSnapshot(String value) {
             base.addInput ("SourceSnapshot", value);
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
        /// <returns>A InsertDiskResultSet containing execution metadata and results.</returns>
        new public InsertDiskResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            InsertDiskResultSet results = new JavaScriptSerializer().Deserialize<InsertDiskResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the InsertDisk Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class InsertDiskResultSet : Temboo.Core.ResultSet
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
