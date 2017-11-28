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
    /// ModifyImageAttribute
    /// Modifies an attribute of an AMI using the Amazon EC2 API.
    /// </summary>
    public class ModifyImageAttribute : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ModifyImageAttribute Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ModifyImageAttribute(TembooSession session) : base(session, "/Library/Amazon/EC2/ModifyImageAttribute")
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
         /// (optional, string) Adds the specified group to the image's list of launch permissions. The only valid value is "all".
         /// </summary>
         /// <param name="value">Value of the AddGroup input for this Choreo.</param>
         public void setAddGroup(String value) {
             base.addInput ("AddGroup", value);
         }
         /// <summary>
         /// (optional, string) Adds the specified AWS account ID to the AMI's list of launch permissions.
         /// </summary>
         /// <param name="value">Value of the AddUserId input for this Choreo.</param>
         public void setAddUserId(String value) {
             base.addInput ("AddUserId", value);
         }
         /// <summary>
         /// (optional, string) Changes the AMI's description to the specified value.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (required, string) The AMI ID.
         /// </summary>
         /// <param name="value">Value of the ImageId input for this Choreo.</param>
         public void setImageId(String value) {
             base.addInput ("ImageId", value);
         }
         /// <summary>
         /// (optional, string) Adds the specified product code to the specified Amazon S3-backed AMI. Once you add a product code to an AMI, it can't be removed.
         /// </summary>
         /// <param name="value">Value of the ProductCode input for this Choreo.</param>
         public void setProductCode(String value) {
             base.addInput ("ProductCode", value);
         }
         /// <summary>
         /// (optional, string) Removes the specified group from the image's list of launch permissions. The only valid value is "all".
         /// </summary>
         /// <param name="value">Value of the RemoveGroup input for this Choreo.</param>
         public void setRemoveGroup(String value) {
             base.addInput ("RemoveGroup", value);
         }
         /// <summary>
         /// (optional, string) Removes the specified AWS account ID from the AMI's list of launch permissions.
         /// </summary>
         /// <param name="value">Value of the RemoveUserId input for this Choreo.</param>
         public void setRemoveUserId(String value) {
             base.addInput ("RemoveUserId", value);
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
        /// <returns>A ModifyImageAttributeResultSet containing execution metadata and results.</returns>
        new public ModifyImageAttributeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ModifyImageAttributeResultSet results = new JavaScriptSerializer().Deserialize<ModifyImageAttributeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ModifyImageAttribute Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ModifyImageAttributeResultSet : Temboo.Core.ResultSet
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
