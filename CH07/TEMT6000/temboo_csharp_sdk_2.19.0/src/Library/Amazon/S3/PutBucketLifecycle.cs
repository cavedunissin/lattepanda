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

namespace Temboo.Library.Amazon.S3
{
    /// <summary>
    /// PutBucketLifecycle
    /// Sets lifecycle configuration for your bucket. This is used to remove objects from a bucket automatically after a certain time or at a certain date.
    /// </summary>
    public class PutBucketLifecycle : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PutBucketLifecycle Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PutBucketLifecycle(TembooSession session) : base(session, "/Library/Amazon/S3/PutBucketLifecycle")
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
         /// (required, string) The name of the bucket to create or update a policy for.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (optional, xml) Write a custom LifecycleConfiguration xml request for advanced customization. Note - this will overwrite all other inputs other than the AWS AccessKeyId, SecretKeyId, and BucketName.
         /// </summary>
         /// <param name="value">Value of the CustomLifecycleConfiguration input for this Choreo.</param>
         public void setCustomLifecycleConfiguration(String value) {
             base.addInput ("CustomLifecycleConfiguration", value);
         }
         /// <summary>
         /// (optional, date) Date when the rule takes effect. You can specify either DateOfExpiration OR NumberOfDays. The date value must be in ISO 8601 format, time is always midnight UTC. Ex: 2013-04-24T00:00:00.000Z.
         /// </summary>
         /// <param name="value">Value of the DateOfExpiration input for this Choreo.</param>
         public void setDateOfExpiration(String value) {
             base.addInput ("DateOfExpiration", value);
         }
         /// <summary>
         /// (optional, string) A unique ID for this lifecycle (i.e. delete-logs-in-30-days-rule).
         /// </summary>
         /// <param name="value">Value of the LifecycleId input for this Choreo.</param>
         public void setLifecycleId(String value) {
             base.addInput ("LifecycleId", value);
         }
         /// <summary>
         /// (conditional, integer) The number of days to wait until the lifecycle expiration kicks in. Required unless you specify DateOfExpiration or a CustomLifecycleConfiguration instead.
         /// </summary>
         /// <param name="value">Value of the NumberOfDays input for this Choreo.</param>
         public void setNumberOfDays(String value) {
             base.addInput ("NumberOfDays", value);
         }
         /// <summary>
         /// (optional, string) Indicating that objects with this prefix will expire and be removed after the number of days specified. If not specified this lifecycle will apply to all objects in the bucket.
         /// </summary>
         /// <param name="value">Value of the Prefix input for this Choreo.</param>
         public void setPrefix(String value) {
             base.addInput ("Prefix", value);
         }
         /// <summary>
         /// (optional, string) The lifecycle status. Accepted values are: "Enabled" or "Disabled". Defaults to "Enabled".
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }
         /// <summary>
         /// (required, string) The AWS region that corresponds to the S3 endpoint you wish to access. The default region is "us-east-1".
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PutBucketLifecycleResultSet containing execution metadata and results.</returns>
        new public PutBucketLifecycleResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PutBucketLifecycleResultSet results = new JavaScriptSerializer().Deserialize<PutBucketLifecycleResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PutBucketLifecycle Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PutBucketLifecycleResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Stores the response from Amazon. Note that for a successful lifecycle creation, no content is returned and this output variable should be empty.</returns>
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
