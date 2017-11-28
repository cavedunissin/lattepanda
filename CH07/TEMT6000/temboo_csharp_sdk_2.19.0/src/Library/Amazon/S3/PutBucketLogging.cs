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
    /// PutBucketLogging
    /// Sets the logging parameters for a bucket and specifies permissions for who can view and modify the logging parameters. Can also be used to disable logging.
    /// </summary>
    public class PutBucketLogging : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PutBucketLogging Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PutBucketLogging(TembooSession session) : base(session, "/Library/Amazon/S3/PutBucketLogging")
        {
        }

         /// <summary>
         /// (optional, any) An XML file that allows custom config, this can be used as an alternative to the other bucket logging inputs. If provided, the Choreo will ignore all inputs except your AWS Key/Secret and BucketName.
         /// </summary>
         /// <param name="value">Value of the BucketLoggingStatus input for this Choreo.</param>
         public void setBucketLoggingStatus(String value) {
             base.addInput ("BucketLoggingStatus", value);
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
         /// (required, string) The name of the bucket that you are setting the logging for.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (conditional, string) The email address of the person being granted logging permissions.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (conditional, string) The logging permissions given to the Grantee for the bucket. Valid values are: FULL_CONTROL, READ, or WRITE.
         /// </summary>
         /// <param name="value">Value of the Permission input for this Choreo.</param>
         public void setPermission(String value) {
             base.addInput ("Permission", value);
         }
         /// <summary>
         /// (conditional, string) The name of the target bucket. To disable logging, just leave this blank.
         /// </summary>
         /// <param name="value">Value of the TargetBucket input for this Choreo.</param>
         public void setTargetBucket(String value) {
             base.addInput ("TargetBucket", value);
         }
         /// <summary>
         /// (conditional, string) Lets you specify a prefix for the keys that the log files will be stored under. Defaults to "/logs"
         /// </summary>
         /// <param name="value">Value of the TargetPrefix input for this Choreo.</param>
         public void setTargetPrefix(String value) {
             base.addInput ("TargetPrefix", value);
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
        /// <returns>A PutBucketLoggingResultSet containing execution metadata and results.</returns>
        new public PutBucketLoggingResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PutBucketLoggingResultSet results = new JavaScriptSerializer().Deserialize<PutBucketLoggingResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PutBucketLogging Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PutBucketLoggingResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Amazon. A successful execution returns an empty 200 response.</returns>
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
