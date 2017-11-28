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
    /// DescribeImages
    /// Queries the Amazon EC2 API to return information about Amazon Machine Image(s) that are available to you.
    /// </summary>
    public class DescribeImages : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DescribeImages Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DescribeImages(TembooSession session) : base(session, "/Library/Amazon/EC2/DescribeImages")
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
         /// (optional, string) The user ID that has explicit launch permissions. The user ID can be an AWS account ID, "self", or "all" to return AMIs with public launch permissions.
         /// </summary>
         /// <param name="value">Value of the ExecutableBy input for this Choreo.</param>
         public void setExecutableBy(String value) {
             base.addInput ("ExecutableBy", value);
         }
         /// <summary>
         /// (optional, string) The name of a supported filter to narrow results with.
         /// </summary>
         /// <param name="value">Value of the FilterName input for this Choreo.</param>
         public void setFilterName(String value) {
             base.addInput ("FilterName", value);
         }
         /// <summary>
         /// (optional, string) A value for the specified filter.
         /// </summary>
         /// <param name="value">Value of the FilterValue input for this Choreo.</param>
         public void setFilterValue(String value) {
             base.addInput ("FilterValue", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the AMI that you want to return. Returns all AMIs when this parameter is not specified.
         /// </summary>
         /// <param name="value">Value of the ImageId input for this Choreo.</param>
         public void setImageId(String value) {
             base.addInput ("ImageId", value);
         }
         /// <summary>
         /// (conditional, string) The IDs "amazon", "aws-marketplace", and "self" can be used to include AMIs owned by Amazon, AWS Marketplace, or AMIs owned by you, respectively.
         /// </summary>
         /// <param name="value">Value of the Owner input for this Choreo.</param>
         public void setOwner(String value) {
             base.addInput ("Owner", value);
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
        /// <returns>A DescribeImagesResultSet containing execution metadata and results.</returns>
        new public DescribeImagesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DescribeImagesResultSet results = new JavaScriptSerializer().Deserialize<DescribeImagesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DescribeImages Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DescribeImagesResultSet : Temboo.Core.ResultSet
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
