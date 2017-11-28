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
    /// RunInstances
    /// Calls the Amazon EC2 API to launch the specified number of instances of an AMI for which you have permissions.
    /// </summary>
    public class RunInstances : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RunInstances Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RunInstances(TembooSession session) : base(session, "/Library/Amazon/EC2/RunInstances")
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
         /// (optional, boolean) Sets whether the volume is deleted on instance termination. Defaults to "true". This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the DeleteOnTermination input for this Choreo.</param>
         public void setDeleteOnTermination(String value) {
             base.addInput ("DeleteOnTermination", value);
         }
         /// <summary>
         /// (optional, string) The device name exposed to the instance (i.e. /dev/sdh or xvdh). This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the DeviceName input for this Choreo.</param>
         public void setDeviceName(String value) {
             base.addInput ("DeviceName", value);
         }
         /// <summary>
         /// (required, string) The ID of the AMI.
         /// </summary>
         /// <param name="value">Value of the ImageId input for this Choreo.</param>
         public void setImageId(String value) {
             base.addInput ("ImageId", value);
         }
         /// <summary>
         /// (optional, string) The instance type (i.e. t1.micro, m1.small, m1.medium, m1.large, m1.xlarge). Default is m1.small.
         /// </summary>
         /// <param name="value">Value of the InstanceType input for this Choreo.</param>
         public void setInstanceType(String value) {
             base.addInput ("InstanceType", value);
         }
         /// <summary>
         /// (optional, integer) The number of I/O operations per second (IOPS) that the volume supports. Valid range is 100 to 2000. This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the Iops input for this Choreo.</param>
         public void setIops(String value) {
             base.addInput ("Iops", value);
         }
         /// <summary>
         /// (optional, string) The ID of the kernel with which to launch the instance.
         /// </summary>
         /// <param name="value">Value of the KernelId input for this Choreo.</param>
         public void setKernelId(String value) {
             base.addInput ("KernelId", value);
         }
         /// <summary>
         /// (optional, string) The name of the key pair to use.
         /// </summary>
         /// <param name="value">Value of the KeyName input for this Choreo.</param>
         public void setKeyName(String value) {
             base.addInput ("KeyName", value);
         }
         /// <summary>
         /// (required, integer) The maximum number of instances to launch. If the value is more than Amazon EC2 can launch, the largest possible number above MinCount will be launched instead.
         /// </summary>
         /// <param name="value">Value of the MaxCount input for this Choreo.</param>
         public void setMaxCount(String value) {
             base.addInput ("MaxCount", value);
         }
         /// <summary>
         /// (required, integer) The minimum number of instances to launch. If the value is more than Amazon EC2 can launch, no instances are launched at all.
         /// </summary>
         /// <param name="value">Value of the MinCount input for this Choreo.</param>
         public void setMinCount(String value) {
             base.addInput ("MinCount", value);
         }
         /// <summary>
         /// (optional, boolean) Enables monitoring for the instance. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the MonitoringEnabled input for this Choreo.</param>
         public void setMonitoringEnabled(String value) {
             base.addInput ("MonitoringEnabled", value);
         }
         /// <summary>
         /// (optional, boolean) Suppresses a device mapping. This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the NoDevice input for this Choreo.</param>
         public void setNoDevice(String value) {
             base.addInput ("NoDevice", value);
         }
         /// <summary>
         /// (optional, string) The Availability Zone to launch the instance into.
         /// </summary>
         /// <param name="value">Value of the PlacementAvailabilityZone input for this Choreo.</param>
         public void setPlacementAvailabilityZone(String value) {
             base.addInput ("PlacementAvailabilityZone", value);
         }
         /// <summary>
         /// (optional, string) The name of an existing placement group you want to launch the instance into (for cluster instances).
         /// </summary>
         /// <param name="value">Value of the PlacementGroupName input for this Choreo.</param>
         public void setPlacementGroupName(String value) {
             base.addInput ("PlacementGroupName", value);
         }
         /// <summary>
         /// (optional, string) The tenancy of the instance. When set to "dedicated", the instance will run on single-tenant hardware and can only be launched into a VPC.
         /// </summary>
         /// <param name="value">Value of the PlacementTenancy input for this Choreo.</param>
         public void setPlacementTenancy(String value) {
             base.addInput ("PlacementTenancy", value);
         }
         /// <summary>
         /// (optional, string) The ID of the RAM disk.
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
         /// (optional, string) One or more security group names. This can be a comma-separated list of up to 10 security group names.
         /// </summary>
         /// <param name="value">Value of the SecurityGroup input for this Choreo.</param>
         public void setSecurityGroup(String value) {
             base.addInput ("SecurityGroup", value);
         }
         /// <summary>
         /// (optional, string) One or more security group IDs. This can be a comma-separated list of up to 10 security group ids.
         /// </summary>
         /// <param name="value">Value of the SecurityGroupId input for this Choreo.</param>
         public void setSecurityGroupId(String value) {
             base.addInput ("SecurityGroupId", value);
         }
         /// <summary>
         /// (optional, string) Whether the instance stops or terminates on instance-initiated shutdown. Valid values are: stop and terminate.
         /// </summary>
         /// <param name="value">Value of the ShutdownBehavior input for this Choreo.</param>
         public void setShutdownBehavior(String value) {
             base.addInput ("ShutdownBehavior", value);
         }
         /// <summary>
         /// (optional, string) The ID of the snapshot. This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the SnapshotId input for this Choreo.</param>
         public void setSnapshotId(String value) {
             base.addInput ("SnapshotId", value);
         }
         /// <summary>
         /// (optional, string) The ID of the subnet to launch the instance into (i.e. subnet-dea63cb7).
         /// </summary>
         /// <param name="value">Value of the SubnetId input for this Choreo.</param>
         public void setSubnetId(String value) {
             base.addInput ("SubnetId", value);
         }
         /// <summary>
         /// (optional, string) The Base64-encoded MIME user data to be made available to the instance(s).
         /// </summary>
         /// <param name="value">Value of the UserData input for this Choreo.</param>
         public void setUserData(String value) {
             base.addInput ("UserData", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the EC2 endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }
         /// <summary>
         /// (optional, string) The name of the virtual device. This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the VirtualName input for this Choreo.</param>
         public void setVirtualName(String value) {
             base.addInput ("VirtualName", value);
         }
         /// <summary>
         /// (optional, string) The size of the volume, in GiBs. Required unless you're creating the volume from a snapshot which indicates that the size will be the size of the snapshot. This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the VolumeSize input for this Choreo.</param>
         public void setVolumeSize(String value) {
             base.addInput ("VolumeSize", value);
         }
         /// <summary>
         /// (optional, string) The volume type. Valid values are: standard (the default) and io1. This is a Block Device Mapping parameter.
         /// </summary>
         /// <param name="value">Value of the VolumeType input for this Choreo.</param>
         public void setVolumeType(String value) {
             base.addInput ("VolumeType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RunInstancesResultSet containing execution metadata and results.</returns>
        new public RunInstancesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RunInstancesResultSet results = new JavaScriptSerializer().Deserialize<RunInstancesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RunInstances Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RunInstancesResultSet : Temboo.Core.ResultSet
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
