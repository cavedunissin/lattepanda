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
    /// PutObjectACL
    /// Sets the access control list (ACL) permissions for an existing object.
    /// </summary>
    public class PutObjectACL : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PutObjectACL Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PutObjectACL(TembooSession session) : base(session, "/Library/Amazon/S3/PutObjectACL")
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
         /// (optional, xml) Custom Access Control List xml for advanced configuration. See description for an example, plus Amazon documentation.
         /// </summary>
         /// <param name="value">Value of the AccessControlList input for this Choreo.</param>
         public void setAccessControlList(String value) {
             base.addInput ("AccessControlList", value);
         }
         /// <summary>
         /// (required, string) The name of the bucket that contains the object that you want to create or update a policy for.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (conditional, string) Most common ACL usage, required unless creating a custom policy. Values: private, public-read, public-read-write, authenticated-read, bucket-owner-read, or bucket-owner-full-control.
         /// </summary>
         /// <param name="value">Value of the CannedACL input for this Choreo.</param>
         public void setCannedACL(String value) {
             base.addInput ("CannedACL", value);
         }
         /// <summary>
         /// (required, string) The name of the file or object that you want to put access controls on in S3. Ex.: file.txt or folder/file.txt.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (optional, string) The email address of the owner who is granting permission. Required if creating your own custom ACL policy.
         /// </summary>
         /// <param name="value">Value of the OwnerEmailAddress input for this Choreo.</param>
         public void setOwnerEmailAddress(String value) {
             base.addInput ("OwnerEmailAddress", value);
         }
         /// <summary>
         /// (optional, string) The canonical user id of the owner who is granting permission. Required if creating your own custom ACL policy.
         /// </summary>
         /// <param name="value">Value of the OwnerId input for this Choreo.</param>
         public void setOwnerId(String value) {
             base.addInput ("OwnerId", value);
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
        /// <returns>A PutObjectACLResultSet containing execution metadata and results.</returns>
        new public PutObjectACLResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PutObjectACLResultSet results = new JavaScriptSerializer().Deserialize<PutObjectACLResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PutObjectACL Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PutObjectACLResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Stores the response from Amazon. Note that for a successful ACL creation, no content is returned and this output variable is empty.</returns>
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
