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
    /// AssociateAddress
    /// Associates an Elastic IP address with an instance or a network interface using the Amazon EC2 API.
    /// </summary>
    public class AssociateAddress : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AssociateAddress Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AssociateAddress(TembooSession session) : base(session, "/Library/Amazon/EC2/AssociateAddress")
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
         /// (optional, string) [EC2-VPC] The allocation ID.  Required for a VPC.
         /// </summary>
         /// <param name="value">Value of the AllocationId input for this Choreo.</param>
         public void setAllocationId(String value) {
             base.addInput ("AllocationId", value);
         }
         /// <summary>
         /// (optional, string) [EC2-VPC] Allows an Elastic IP address that is already associated with an instance or network interface to be re-associated with the specified instance or network interface. False if not specified.
         /// </summary>
         /// <param name="value">Value of the AllowReassociation input for this Choreo.</param>
         public void setAllowReassociation(String value) {
             base.addInput ("AllowReassociation", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the instance.  Required for EC2-Classic. For a VPC, you can specify either an instance ID or a network interface ID, but not both.
         /// </summary>
         /// <param name="value">Value of the InstanceId input for this Choreo.</param>
         public void setInstanceId(String value) {
             base.addInput ("InstanceId", value);
         }
         /// <summary>
         /// (optional, string) [EC2-VPC] The ID of the network interface. Association fails when specifying an instance ID unless exactly one interface is attached.
         /// </summary>
         /// <param name="value">Value of the NetworkInterfaceId input for this Choreo.</param>
         public void setNetworkInterfaceId(String value) {
             base.addInput ("NetworkInterfaceId", value);
         }
         /// <summary>
         /// (optional, string) [EC2-VPC] The primary or secondary private IP address to associate with the Elastic IP address. If nothing is specified, the Elastic IP address is associated with the primary private IP address.
         /// </summary>
         /// <param name="value">Value of the PrivateIpAddress input for this Choreo.</param>
         public void setPrivateIpAddress(String value) {
             base.addInput ("PrivateIpAddress", value);
         }
         /// <summary>
         /// (conditional, string) The Elastic IP address.
         /// </summary>
         /// <param name="value">Value of the PublicIp input for this Choreo.</param>
         public void setPublicIp(String value) {
             base.addInput ("PublicIp", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the EC2 endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AssociateAddressResultSet containing execution metadata and results.</returns>
        new public AssociateAddressResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AssociateAddressResultSet results = new JavaScriptSerializer().Deserialize<AssociateAddressResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AssociateAddress Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AssociateAddressResultSet : Temboo.Core.ResultSet
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
