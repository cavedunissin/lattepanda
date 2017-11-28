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
    /// RegisterImage
    /// Registers a new AMI with Amazon EC2 using the Amazon EC2 API.
    /// </summary>
    public class RegisterImage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RegisterImage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RegisterImage(TembooSession session) : base(session, "/Library/Amazon/EC2/RegisterImage")
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
         /// (optional, string) The architecture of the image. Valid values are: i386 or x86_64. Defaults to i386.
         /// </summary>
         /// <param name="value">Value of the Architecture input for this Choreo.</param>
         public void setArchitecture(String value) {
             base.addInput ("Architecture", value);
         }
         /// <summary>
         /// (optional, boolean) Whether the Amazon EBS volume is deleted on instance termination. Defaults to true.
         /// </summary>
         /// <param name="value">Value of the DeleteOnTermination input for this Choreo.</param>
         public void setDeleteOnTermination(String value) {
             base.addInput ("DeleteOnTermination", value);
         }
         /// <summary>
         /// (optional, string) The description of the AMI.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (conditional, string) If registering an Amazon EBS-backed AMI from a snapshot, specify this input with the root device name (e.g., /dev/sda1, or xvda), and SnapshotId.
         /// </summary>
         /// <param name="value">Value of the DeviceName input for this Choreo.</param>
         public void setDeviceName(String value) {
             base.addInput ("DeviceName", value);
         }
         /// <summary>
         /// (conditional, string) Full path to your AMI manifest in Amazon S3 storage. Required if registering an Amazon-S3 backed AMI.
         /// </summary>
         /// <param name="value">Value of the ImageLocation input for this Choreo.</param>
         public void setImageLocation(String value) {
             base.addInput ("ImageLocation", value);
         }
         /// <summary>
         /// (conditional, integer) The number of I/O operations per second (IOPS) that the volume supports. A valid range is: 100 to 2000.
         /// </summary>
         /// <param name="value">Value of the Iops input for this Choreo.</param>
         public void setIops(String value) {
             base.addInput ("Iops", value);
         }
         /// <summary>
         /// (optional, string) The ID of the kernel to select.
         /// </summary>
         /// <param name="value">Value of the KernelId input for this Choreo.</param>
         public void setKernelId(String value) {
             base.addInput ("KernelId", value);
         }
         /// <summary>
         /// (required, string) A name for your AMI.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies that no device should be mapped. Defaults to 1 (true).
         /// </summary>
         /// <param name="value">Value of the NoDevice input for this Choreo.</param>
         public void setNoDevice(String value) {
             base.addInput ("NoDevice", value);
         }
         /// <summary>
         /// (optional, string) The ID of the RAM disk to select.
         /// </summary>
         /// <param name="value">Value of the RamdiskId input for this Choreo.</param>
         public void setRamdiskId(String value) {
             base.addInput ("RamdiskId", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) The root device name (e.g., /dev/sda1, or xvda). Required if registering an Amazon EBS-backed AMI.
         /// </summary>
         /// <param name="value">Value of the RootDeviceName input for this Choreo.</param>
         public void setRootDeviceName(String value) {
             base.addInput ("RootDeviceName", value);
         }
         /// <summary>
         /// (conditional, string) If registering an Amazon EBS-backed AMI from a snapshot, you must at least specify this input with the snapshot ID, and DeviceName with the root device name.
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
         /// (optional, string) The virtual device name.
         /// </summary>
         /// <param name="value">Value of the VirtualName input for this Choreo.</param>
         public void setVirtualName(String value) {
             base.addInput ("VirtualName", value);
         }
         /// <summary>
         /// (conditional, integer) The size of the volume, in GiBs. Required if you are not creating a volume from a snapshot.
         /// </summary>
         /// <param name="value">Value of the VolumeSize input for this Choreo.</param>
         public void setVolumeSize(String value) {
             base.addInput ("VolumeSize", value);
         }
         /// <summary>
         /// (optional, string) The volume type. Valid values are: standard and io.
         /// </summary>
         /// <param name="value">Value of the VolumeType input for this Choreo.</param>
         public void setVolumeType(String value) {
             base.addInput ("VolumeType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RegisterImageResultSet containing execution metadata and results.</returns>
        new public RegisterImageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RegisterImageResultSet results = new JavaScriptSerializer().Deserialize<RegisterImageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RegisterImage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RegisterImageResultSet : Temboo.Core.ResultSet
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
