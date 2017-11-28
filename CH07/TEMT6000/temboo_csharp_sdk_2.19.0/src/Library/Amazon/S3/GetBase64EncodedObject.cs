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
    /// GetBase64EncodedObject
    /// Retrieves a specified item from an Amazon S3 bucket, returns the file content as base64-encoded data, and returns the values of key response headers as output variables if available.
    /// </summary>
    public class GetBase64EncodedObject : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetBase64EncodedObject Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetBase64EncodedObject(TembooSession session) : base(session, "/Library/Amazon/S3/GetBase64EncodedObject")
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
         /// (required, string) The name of the bucket that contains the object to retrieve.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (required, string) The name of the file to retrieve.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (optional, string) Returns the object only if its entity tag (ETag) is the same as the one specified, otherwise returns a 412 (precondition failed) error.
         /// </summary>
         /// <param name="value">Value of the IfMatch input for this Choreo.</param>
         public void setIfMatch(String value) {
             base.addInput ("IfMatch", value);
         }
         /// <summary>
         /// (optional, date) Returns the object only if it has been modified since the specific time, otherwise returns a 304 (not modified) error.
         /// </summary>
         /// <param name="value">Value of the IfModifiedSince input for this Choreo.</param>
         public void setIfModifiedSince(String value) {
             base.addInput ("IfModifiedSince", value);
         }
         /// <summary>
         /// (optional, string) Returns the object only if its entity tag (ETag) is different from the one specified, otherwise retuns a 304 (not modified) error. Will not work correctly with IfModifiedSince.
         /// </summary>
         /// <param name="value">Value of the IfNoneMatch input for this Choreo.</param>
         public void setIfNoneMatch(String value) {
             base.addInput ("IfNoneMatch", value);
         }
         /// <summary>
         /// (optional, date) Returns the object only if it has not been modified since the specified time, otherwise returns a 412 (precondition failed) error.
         /// </summary>
         /// <param name="value">Value of the IfUnmodifiedSince input for this Choreo.</param>
         public void setIfUnmodifiedSince(String value) {
             base.addInput ("IfUnmodifiedSince", value);
         }
         /// <summary>
         /// (optional, string) Downloads the specific range of bytes of an object. Ex: 0-9 (returns the first 10 bytes of an object), 100-1000, etc. If the range value exceeds the end of file, it will return up to the end of file.
         /// </summary>
         /// <param name="value">Value of the Range input for this Choreo.</param>
         public void setRange(String value) {
             base.addInput ("Range", value);
         }
         /// <summary>
         /// (optional, string) Specifies the server-side encryption with customer-provided encryption keys (SSE-C) algorithm used when Amazon S3 created the target object. Valid value: AES256.
         /// </summary>
         /// <param name="value">Value of the SSECAlgorithm input for this Choreo.</param>
         public void setSSECAlgorithm(String value) {
             base.addInput ("SSECAlgorithm", value);
         }
         /// <summary>
         /// (optional, string) The customer-provided AES-256 256-bit (32-byte) encryption key for Amazon S3 to use to encrypt or decrypt your data.
         /// </summary>
         /// <param name="value">Value of the SSECKey input for this Choreo.</param>
         public void setSSECKey(String value) {
             base.addInput ("SSECKey", value);
         }
         /// <summary>
         /// (conditional, string) The AWS region that corresponds to the S3 endpoint you wish to access. The default region is "us-east-1".
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetBase64EncodedObjectResultSet containing execution metadata and results.</returns>
        new public GetBase64EncodedObjectResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetBase64EncodedObjectResultSet results = new JavaScriptSerializer().Deserialize<GetBase64EncodedObjectResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetBase64EncodedObject Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetBase64EncodedObjectResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "DeleteMarker" output from this Choreo execution
        /// <returns>String - (boolean) Returns true if the object retrieved was a Delete Marker otherwise no value.</returns>
        /// </summary>
        public String DeleteMarker
        {
            get
            {
                return (String) base.Output["DeleteMarker"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ETag" output from this Choreo execution
        /// <returns>String - (string) The ETag string for the file.</returns>
        /// </summary>
        public String ETag
        {
            get
            {
                return (String) base.Output["ETag"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Expiration" output from this Choreo execution
        /// <returns>String - (string) Appears if the object expiration is configured. It includes expiry-date and URL-encoded rule-id key value pairs providing object expiration information.</returns>
        /// </summary>
        public String Expiration
        {
            get
            {
                return (String) base.Output["Expiration"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Restore" output from this Choreo execution
        /// <returns>String - (string) Provides information about the object restoration operation and expiration time of the restored object copy.</returns>
        /// </summary>
        public String Restore
        {
            get
            {
                return (String) base.Output["Restore"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ServerSideEncryption" output from this Choreo execution
        /// <returns>String - (string) If the object is stored using server-side encryption, response includes this header with value of the encryption algorithm used. Valid Values: AES256.</returns>
        /// </summary>
        public String ServerSideEncryption
        {
            get
            {
                return (String) base.Output["ServerSideEncryption"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "VersionID" output from this Choreo execution
        /// <returns>String - (string) Returns the version ID of the retrieved object if it has a unique version ID.</returns>
        /// </summary>
        public String VersionID
        {
            get
            {
                return (String) base.Output["VersionID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "WebsiteRedirectLocation" output from this Choreo execution
        /// <returns>String - (string) For a bucket configured as a website, this metadata can be set so the website will evaluate the request for the object as a 301 redirect to another object in the same bucket or an external URL.</returns>
        /// </summary>
        public String WebsiteRedirectLocation
        {
            get
            {
                return (String) base.Output["WebsiteRedirectLocation"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) The base64-encoded contents of the file you are retrieving.</returns>
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
