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
    /// CopyObject
    /// Makes a copy of an existing object in S3 Storage.
    /// </summary>
    public class CopyObject : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CopyObject Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CopyObject(TembooSession session) : base(session, "/Library/Amazon/S3/CopyObject")
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
         /// (required, string) The name of the bucket that will be the file destination.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (optional, string) By default all objects are private (only owner has full access control). Valid values: private, public-read, public-read-write, authenticated-read, bucket-owner-read, bucket-owner-full-control.
         /// </summary>
         /// <param name="value">Value of the CannedACL input for this Choreo.</param>
         public void setCannedACL(String value) {
             base.addInput ("CannedACL", value);
         }
         /// <summary>
         /// (optional, string) ContentType. Default is application/octet-stream.
         /// </summary>
         /// <param name="value">Value of the ContentType input for this Choreo.</param>
         public void setContentType(String value) {
             base.addInput ("ContentType", value);
         }
         /// <summary>
         /// (required, string) The name of the file to copy.
         /// </summary>
         /// <param name="value">Value of the FileToCopy input for this Choreo.</param>
         public void setFileToCopy(String value) {
             base.addInput ("FileToCopy", value);
         }
         /// <summary>
         /// (optional, string) Copies the object if its entity tag (ETag) matches the specified tag; otherwise returns a 412 HTTP status code error (failed precondition).
         /// </summary>
         /// <param name="value">Value of the IfMatch input for this Choreo.</param>
         public void setIfMatch(String value) {
             base.addInput ("IfMatch", value);
         }
         /// <summary>
         /// (optional, date) Copies if it has been modified since the specified time; otherwise returns a 412 HTTP status code error (failed precondition). Must be valid HTTP date. Can be used with IfMatch only.
         /// </summary>
         /// <param name="value">Value of the IfModifiedSince input for this Choreo.</param>
         public void setIfModifiedSince(String value) {
             base.addInput ("IfModifiedSince", value);
         }
         /// <summary>
         /// (optional, string) Copies the object if its entity tag (ETag) is different from the specified tag; otherwise returns a 412 HTTP status code error (failed precondition).
         /// </summary>
         /// <param name="value">Value of the IfNoneMatch input for this Choreo.</param>
         public void setIfNoneMatch(String value) {
             base.addInput ("IfNoneMatch", value);
         }
         /// <summary>
         /// (optional, date) Copies if it hasn't been modified since the specified time; otherwise returns a 412 HTTP status code error (failed precondition). Must be valid HTTP date. Can be used with IfMatch or IfNoneMatch only.
         /// </summary>
         /// <param name="value">Value of the IfUnmodifiedSince input for this Choreo.</param>
         public void setIfUnmodifiedSince(String value) {
             base.addInput ("IfUnmodifiedSince", value);
         }
         /// <summary>
         /// (required, string) The file name for the new copy.
         /// </summary>
         /// <param name="value">Value of the NewFileName input for this Choreo.</param>
         public void setNewFileName(String value) {
             base.addInput ("NewFileName", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Specifies the server-side encryption with customer-provided encryption keys (SSE-C) algorithm to use when Amazon S3 creates the target object. Valid value: AES256.
         /// </summary>
         /// <param name="value">Value of the SSECAlgorithm input for this Choreo.</param>
         public void setSSECAlgorithm(String value) {
             base.addInput ("SSECAlgorithm", value);
         }
         /// <summary>
         /// (optional, string) The customer-provided AES-256 256-bit (32-byte) encryption key for Amazon S3 to use to encrypt or decrypt your copied data object.
         /// </summary>
         /// <param name="value">Value of the SSECKey input for this Choreo.</param>
         public void setSSECKey(String value) {
             base.addInput ("SSECKey", value);
         }
         /// <summary>
         /// (optional, string) Specifies the server-side encryption with customer-provided encryption keys (SSE-C) algorithm to use to decrypt the Amazon S3 source object being copied. Valid value: AES256.
         /// </summary>
         /// <param name="value">Value of the SSECSourceAlgorithm input for this Choreo.</param>
         public void setSSECSourceAlgorithm(String value) {
             base.addInput ("SSECSourceAlgorithm", value);
         }
         /// <summary>
         /// (optional, string) The customer-provided AES-256 256-bit (32-byte) encryption key for Amazon S3 to use to decrypt the copy source object.
         /// </summary>
         /// <param name="value">Value of the SSECSourceKey input for this Choreo.</param>
         public void setSSECSourceKey(String value) {
             base.addInput ("SSECSourceKey", value);
         }
         /// <summary>
         /// (optional, string) Specifies the server-side encryption algorithm to use when Amazon S3 creates the target object. Valid value: AES256.
         /// </summary>
         /// <param name="value">Value of the ServerSideEncryption input for this Choreo.</param>
         public void setServerSideEncryption(String value) {
             base.addInput ("ServerSideEncryption", value);
         }
         /// <summary>
         /// (optional, string) Enables RRS customers to store their noncritical, reproducible data at lower levels of redundancy than Amazon S3's standard storage. Valid Values: STANDARD (default), REDUCED_REDUNDANCY.
         /// </summary>
         /// <param name="value">Value of the StorageClass input for this Choreo.</param>
         public void setStorageClass(String value) {
             base.addInput ("StorageClass", value);
         }
         /// <summary>
         /// (required, string) The AWS region that corresponds to the S3 endpoint you wish to access. The default region is "us-east-1".
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }
         /// <summary>
         /// (optional, string) If the bucket is configured as a website, redirects requests for this object to another object in the same bucket or to an external URL. Ex: /anotherPage.html, http://www.page.com. Length limit: 2 K.
         /// </summary>
         /// <param name="value">Value of the WebsiteRedirectLocation input for this Choreo.</param>
         public void setWebsiteRedirectLocation(String value) {
             base.addInput ("WebsiteRedirectLocation", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CopyObjectResultSet containing execution metadata and results.</returns>
        new public CopyObjectResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CopyObjectResultSet results = new JavaScriptSerializer().Deserialize<CopyObjectResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CopyObject Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CopyObjectResultSet : Temboo.Core.ResultSet
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
