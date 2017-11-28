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
    /// GetObjectACL
    /// Returns the access control list (ACL) of a file or object.
    /// </summary>
    public class GetObjectACL : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetObjectACL Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetObjectACL(TembooSession session) : base(session, "/Library/Amazon/S3/GetObjectACL")
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
         /// (required, string) The name of the bucket associated with the ACL you want to retrieve.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (required, string) Name of the file or object you wish to retrieve the ACL for. Ex.: filename.txt or folder/filename.txt.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
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
        /// <returns>A GetObjectACLResultSet containing execution metadata and results.</returns>
        new public GetObjectACLResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetObjectACLResultSet results = new JavaScriptSerializer().Deserialize<GetObjectACLResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetObjectACL Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetObjectACLResultSet : Temboo.Core.ResultSet
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
