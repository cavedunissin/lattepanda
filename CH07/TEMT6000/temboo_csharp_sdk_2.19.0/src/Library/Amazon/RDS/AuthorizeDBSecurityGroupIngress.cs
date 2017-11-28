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

namespace Temboo.Library.Amazon.RDS
{
    /// <summary>
    /// AuthorizeDBSecurityGroupIngress
    /// Allows restricted access to your database instance by adding EC2 Security Groups to the DBSecurityGroup or by specifying an allowed IP range.
    /// </summary>
    public class AuthorizeDBSecurityGroupIngress : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AuthorizeDBSecurityGroupIngress Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AuthorizeDBSecurityGroupIngress(TembooSession session) : base(session, "/Library/Amazon/RDS/AuthorizeDBSecurityGroupIngress")
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
         /// (conditional, string) IP range that should have access. Required unless EC2SecurityGroupName and EC2SecurityGroupOwnerId are used.
         /// </summary>
         /// <param name="value">Value of the CIDRIP input for this Choreo.</param>
         public void setCIDRIP(String value) {
             base.addInput ("CIDRIP", value);
         }
         /// <summary>
         /// (required, string) A unique name for the security group you want to authorize.
         /// </summary>
         /// <param name="value">Value of the DBSecurityGroupName input for this Choreo.</param>
         public void setDBSecurityGroupName(String value) {
             base.addInput ("DBSecurityGroupName", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the EC2 security group to authorize. For VPC DB security groups, this is required. Otherwise, EC2SecurityGroupOwnerId and either EC2SecurityGroupName or EC2SecurityGroupId must be provided.
         /// </summary>
         /// <param name="value">Value of the EC2SecurityGroupId input for this Choreo.</param>
         public void setEC2SecurityGroupId(String value) {
             base.addInput ("EC2SecurityGroupId", value);
         }
         /// <summary>
         /// (conditional, string) The EC2 security group to authorize. This and EC2SecurityGroupOwnerId are required if CIDRIP is not used.
         /// </summary>
         /// <param name="value">Value of the EC2SecurityGroupName input for this Choreo.</param>
         public void setEC2SecurityGroupName(String value) {
             base.addInput ("EC2SecurityGroupName", value);
         }
         /// <summary>
         /// (conditional, string) The AWS account number for the security group owner. This and EC2SecurityGroupName are required if CIDRIP is not used.
         /// </summary>
         /// <param name="value">Value of the EC2SecurityGroupOwnerId input for this Choreo.</param>
         public void setEC2SecurityGroupOwnerId(String value) {
             base.addInput ("EC2SecurityGroupOwnerId", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the RDS endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AuthorizeDBSecurityGroupIngressResultSet containing execution metadata and results.</returns>
        new public AuthorizeDBSecurityGroupIngressResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AuthorizeDBSecurityGroupIngressResultSet results = new JavaScriptSerializer().Deserialize<AuthorizeDBSecurityGroupIngressResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AuthorizeDBSecurityGroupIngress Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AuthorizeDBSecurityGroupIngressResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Amazon.</returns>
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
