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
    /// ZipBucket
    /// Creates a zip file containing all objects within the specified bucket and returns a download link for the new compressed file.
    /// </summary>
    public class ZipBucket : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ZipBucket Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ZipBucket(TembooSession session) : base(session, "/Library/Amazon/S3/ZipBucket")
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
         /// (required, string) The name of the bucket that contains the list of objects that you want to zip.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (conditional, string) This sets the permissions for the newly created zip file. Valid values are: private, public-read, public-read-write, authenticated-read, bucket-owner-read, or bucket-owner-full-control.
         /// </summary>
         /// <param name="value">Value of the CannedACL input for this Choreo.</param>
         public void setCannedACL(String value) {
             base.addInput ("CannedACL", value);
         }
         /// <summary>
         /// (optional, string) A delimiter is a character you use to group keys. All keys that contain the delimiter are grouped under a single result element, Common Prefixes. For more information see Amazon documentation.
         /// </summary>
         /// <param name="value">Value of the Delimiter input for this Choreo.</param>
         public void setDelimiter(String value) {
             base.addInput ("Delimiter", value);
         }
         /// <summary>
         /// (optional, string) Limits the response to keys that begin with the specified prefix - useful for separating a bucket into different groupings of keys. Ex: specify 'test' to get a list of objects starting with 'test'.
         /// </summary>
         /// <param name="value">Value of the Prefix input for this Choreo.</param>
         public void setPrefix(String value) {
             base.addInput ("Prefix", value);
         }
         /// <summary>
         /// (required, string) The AWS region that corresponds to the S3 endpoint you wish to access. The default region is "us-east-1".
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }
         /// <summary>
         /// (optional, string) The name of the bucket to put the new zip file in. When not specified, the zip file will be put in the bucket that contains the files being zipped.
         /// </summary>
         /// <param name="value">Value of the ZipFileLocation input for this Choreo.</param>
         public void setZipFileLocation(String value) {
             base.addInput ("ZipFileLocation", value);
         }
         /// <summary>
         /// (optional, string) The name of the zip file that will be created. If not specified, the original bucket name will be used with .zip extension.
         /// </summary>
         /// <param name="value">Value of the ZipFileName input for this Choreo.</param>
         public void setZipFileName(String value) {
             base.addInput ("ZipFileName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ZipBucketResultSet containing execution metadata and results.</returns>
        new public ZipBucketResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ZipBucketResultSet results = new JavaScriptSerializer().Deserialize<ZipBucketResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ZipBucket Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ZipBucketResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "URL" output from this Choreo execution
        /// <returns>String - (string) The URL location of the new zip file.</returns>
        /// </summary>
        public String URL
        {
            get
            {
                return (String) base.Output["URL"];
            }
        }
    }
}
