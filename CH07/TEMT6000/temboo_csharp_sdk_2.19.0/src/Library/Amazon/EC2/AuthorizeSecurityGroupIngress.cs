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
    /// AuthorizeSecurityGroupIngress
    /// Adds an ingress rule to a security group using the Amazon EC2 API.
    /// </summary>
    public class AuthorizeSecurityGroupIngress : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AuthorizeSecurityGroupIngress Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AuthorizeSecurityGroupIngress(TembooSession session) : base(session, "/Library/Amazon/EC2/AuthorizeSecurityGroupIngress")
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
         /// (conditional, string) The ID of the security group to modify. Can be used instead of GroupName.
         /// </summary>
         /// <param name="value">Value of the GroupId input for this Choreo.</param>
         public void setGroupId(String value) {
             base.addInput ("GroupId", value);
         }
         /// <summary>
         /// (conditional, string) The name of the security group to modify. Can be used instead of GroupId.
         /// </summary>
         /// <param name="value">Value of the GroupName input for this Choreo.</param>
         public void setGroupName(String value) {
             base.addInput ("GroupName", value);
         }
         /// <summary>
         /// (optional, string) The CIDR range. Cannot be used when specifying a source security group.
         /// </summary>
         /// <param name="value">Value of the IpPermissionsCidrIp input for this Choreo.</param>
         public void setIpPermissionsCidrIp(String value) {
             base.addInput ("IpPermissionsCidrIp", value);
         }
         /// <summary>
         /// (optional, integer) The start of port range for the TCP and UDP protocols, or an ICMP type number. For the ICMP type number, you can use -1 to specify all ICMP types.
         /// </summary>
         /// <param name="value">Value of the IpPermissionsFromPort input for this Choreo.</param>
         public void setIpPermissionsFromPort(String value) {
             base.addInput ("IpPermissionsFromPort", value);
         }
         /// <summary>
         /// (optional, string) The ID of the source security group. Cannot be used when specifying a CIDR IP address.
         /// </summary>
         /// <param name="value">Value of the IpPermissionsGroupId input for this Choreo.</param>
         public void setIpPermissionsGroupId(String value) {
             base.addInput ("IpPermissionsGroupId", value);
         }
         /// <summary>
         /// (optional, string) The name of the source security group. Cannot be used when specifying a CIDR IP address.
         /// </summary>
         /// <param name="value">Value of the IpPermissionsGroupName input for this Choreo.</param>
         public void setIpPermissionsGroupName(String value) {
             base.addInput ("IpPermissionsGroupName", value);
         }
         /// <summary>
         /// (required, string) The IP protocol name or number. Valid values for EC2-Classic: tcp, udp, icmp (or 6, 17, 1). Valid values for EC2-VPC: tcp, udp, icmp, any valid protocol number (0-254), or -1 (to specify all).
         /// </summary>
         /// <param name="value">Value of the IpPermissionsIpProtocol input for this Choreo.</param>
         public void setIpPermissionsIpProtocol(String value) {
             base.addInput ("IpPermissionsIpProtocol", value);
         }
         /// <summary>
         /// (optional, integer) The end of port range for the TCP and UDP protocols, or an ICMP code number. For the ICMP code number, you can use -1 to specify all ICMP codes for the given ICMP type.
         /// </summary>
         /// <param name="value">Value of the IpPermissionsToPort input for this Choreo.</param>
         public void setIpPermissionsToPort(String value) {
             base.addInput ("IpPermissionsToPort", value);
         }
         /// <summary>
         /// (optional, string) The AWS account ID that owns the source security group. Cannot be used when specifying a CIDR IP address.
         /// </summary>
         /// <param name="value">Value of the IpPermissionsUserId input for this Choreo.</param>
         public void setIpPermissionsUserId(String value) {
             base.addInput ("IpPermissionsUserId", value);
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
        /// <returns>A AuthorizeSecurityGroupIngressResultSet containing execution metadata and results.</returns>
        new public AuthorizeSecurityGroupIngressResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AuthorizeSecurityGroupIngressResultSet results = new JavaScriptSerializer().Deserialize<AuthorizeSecurityGroupIngressResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AuthorizeSecurityGroupIngress Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AuthorizeSecurityGroupIngressResultSet : Temboo.Core.ResultSet
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
