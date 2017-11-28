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
    /// CreateImage
    /// Creates an Amazon Machine Image from an Amazon EBS-backed instance using the Amazon EC2 API. The image can be used later to launch other identical servers.
    /// </summary>
    public class CreateImage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateImage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateImage(TembooSession session) : base(session, "/Library/Amazon/EC2/CreateImage")
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
         /// (optional, boolean) Whether the volume is deleted on instance termination. Defaults to "true".
         /// </summary>
         /// <param name="value">Value of the DeleteOnTermination input for this Choreo.</param>
         public void setDeleteOnTermination(String value) {
             base.addInput ("DeleteOnTermination", value);
         }
         /// <summary>
         /// (optional, string) A description for the image you want to create.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (conditional, string) The device name exposed to the instance (i.e. /dev/sdh or xvdh). When registering an AMI from a snapshot, DiviceName is required as well as SnapshotId.
         /// </summary>
         /// <param name="value">Value of the DeviceName input for this Choreo.</param>
         public void setDeviceName(String value) {
             base.addInput ("DeviceName", value);
         }
         /// <summary>
         /// (required, string) The ID of the instance to create the image on.
         /// </summary>
         /// <param name="value">Value of the InstanceId input for this Choreo.</param>
         public void setInstanceId(String value) {
             base.addInput ("InstanceId", value);
         }
         /// <summary>
         /// (conditional, integer) The number of I/O operations per second (IOPS) that the volume supports. Valid range is 100 to 2000.
         /// </summary>
         /// <param name="value">Value of the Iops input for this Choreo.</param>
         public void setIops(String value) {
             base.addInput ("Iops", value);
         }
         /// <summary>
         /// (required, string) The name for the image you are creating.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, boolean) Suppresses a device mapping. Defaults to "true".
         /// </summary>
         /// <param name="value">Value of the NoDevice input for this Choreo.</param>
         public void setNoDevice(String value) {
             base.addInput ("NoDevice", value);
         }
         /// <summary>
         /// (optional, boolean) Defaults to "false". Amazon EC2 will attempt to shut down the instance before and after creating the image. Set to "true" for NoReboot.
         /// </summary>
         /// <param name="value">Value of the NoReboot input for this Choreo.</param>
         public void setNoReboot(String value) {
             base.addInput ("NoReboot", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the snapshot. Required when registering from a snapshot. You must also specify DeviceName with the root device name.
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
         /// (optional, string) The name of the virtual device.
         /// </summary>
         /// <param name="value">Value of the VirtualName input for this Choreo.</param>
         public void setVirtualName(String value) {
             base.addInput ("VirtualName", value);
         }
         /// <summary>
         /// (conditional, string) The size of the volume, in GiBs. Required unless you're creating the volume from a snapshot which indicates that the size will be the size of the snapshot.
         /// </summary>
         /// <param name="value">Value of the VolumeSize input for this Choreo.</param>
         public void setVolumeSize(String value) {
             base.addInput ("VolumeSize", value);
         }
         /// <summary>
         /// (optional, string) The volume type. Valid values are: standard (the default) and io1.
         /// </summary>
         /// <param name="value">Value of the VolumeType input for this Choreo.</param>
         public void setVolumeType(String value) {
             base.addInput ("VolumeType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateImageResultSet containing execution metadata and results.</returns>
        new public CreateImageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateImageResultSet results = new JavaScriptSerializer().Deserialize<CreateImageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateImage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateImageResultSet : Temboo.Core.ResultSet
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
