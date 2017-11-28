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

namespace Temboo.Library.Amazon.EC2
{
    /// <summary>
    /// CreateVolume
    /// Calls the Amazon EC2 API to create a new EBS volume that your EC2 instance can attach to.
    /// </summary>
    public class CreateVolume : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateVolume Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateVolume(TembooSession session) : base(session, "/Library/Amazon/EC2/CreateVolume")
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
         /// (required, string) The Availability Zone to use when creating thew new volume (i.e us-east-1a).
         /// </summary>
         /// <param name="value">Value of the AvailabilityZone input for this Choreo.</param>
         public void setAvailabilityZone(String value) {
             base.addInput ("AvailabilityZone", value);
         }
         /// <summary>
         /// (optional, integer) The number of I/O operations per second (IOPS) that the volume supports. Valid range is 100 to 2000. Required when the volume type is io1.
         /// </summary>
         /// <param name="value">Value of the Iops input for this Choreo.</param>
         public void setIops(String value) {
             base.addInput ("Iops", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, integer) The size for the volume (in gigabytes) that you are creating. Valid Values are 1-1024. Required if you're not creating a volume from a snapshot. If the volume type is io1, the min size is 10 GiB.
         /// </summary>
         /// <param name="value">Value of the Size input for this Choreo.</param>
         public void setSize(String value) {
             base.addInput ("Size", value);
         }
         /// <summary>
         /// (conditional, string) The snapshot from which to create the new volume. Required if you are creating a volume from a snapshot.
         /// </summary>
         /// <param name="value">Value of the SnapshotId input for this Choreo.</param>
         public void setSnapshotId(String value) {
             base.addInput ("SnapshotId", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the EC2 endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }
         /// <summary>
         /// (optional, string) The volume type.Valid values are: "standard" (the default) and "io1".
         /// </summary>
         /// <param name="value">Value of the VolumeType input for this Choreo.</param>
         public void setVolumeType(String value) {
             base.addInput ("VolumeType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateVolumeResultSet containing execution metadata and results.</returns>
        new public CreateVolumeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateVolumeResultSet results = new JavaScriptSerializer().Deserialize<CreateVolumeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateVolume Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateVolumeResultSet : Temboo.Core.ResultSet
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
