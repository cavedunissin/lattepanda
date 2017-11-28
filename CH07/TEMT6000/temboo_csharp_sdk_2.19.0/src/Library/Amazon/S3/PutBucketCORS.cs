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
    /// PutBucketCORS
    /// Sets the CORS (Cross-Origin Resource Sharing) configuration for a specified bucket.
    /// </summary>
    public class PutBucketCORS : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PutBucketCORS Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PutBucketCORS(TembooSession session) : base(session, "/Library/Amazon/S3/PutBucketCORS")
        {
        }

         /// <summary>
         /// (optional, xml) The CORS Configuration XML containing one or more CORS Rules for advanced configuration. If provided the Choreo will ignore all other inputs except your AWS Key/Secret and BucketName.
         /// </summary>
         /// <param name="value">Value of the CORSConfiguration input for this Choreo.</param>
         public void setCORSConfiguration(String value) {
             base.addInput ("CORSConfiguration", value);
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
         /// (optional, string) Specifies which headers are allowed in a pre-flight OPTIONS request via the Access-Control-Request-Headers header.
         /// </summary>
         /// <param name="value">Value of the AllowedHeader input for this Choreo.</param>
         public void setAllowedHeader(String value) {
             base.addInput ("AllowedHeader", value);
         }
         /// <summary>
         /// (conditional, string) The HTTP verb that you want to allow the origin to execute. Valid values are: GET, PUT, HEAD, POST, DELETE.
         /// </summary>
         /// <param name="value">Value of the AllowedMethod input for this Choreo.</param>
         public void setAllowedMethod(String value) {
             base.addInput ("AllowedMethod", value);
         }
         /// <summary>
         /// (conditional, string) An origin that you want to allow cross-domain requests from. This can contain at most one * wild character (i.e. http://*.example.com).
         /// </summary>
         /// <param name="value">Value of the AllowedOrigin input for this Choreo.</param>
         public void setAllowedOrigin(String value) {
             base.addInput ("AllowedOrigin", value);
         }
         /// <summary>
         /// (required, string) The name of the bucket to set a CORS configuration for.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (optional, string) A header in the response that you want customers to be able to access from their applications.
         /// </summary>
         /// <param name="value">Value of the ExposeHeader input for this Choreo.</param>
         public void setExposeHeader(String value) {
             base.addInput ("ExposeHeader", value);
         }
         /// <summary>
         /// (optional, string) A unique identifier for the rule. The ID value can be up to 255 characters long.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (optional, integer) The time in seconds that your browser is to cache the preflight response for the specified resource.
         /// </summary>
         /// <param name="value">Value of the MaxAgeSeconds input for this Choreo.</param>
         public void setMaxAgeSeconds(String value) {
             base.addInput ("MaxAgeSeconds", value);
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
        /// <returns>A PutBucketCORSResultSet containing execution metadata and results.</returns>
        new public PutBucketCORSResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PutBucketCORSResultSet results = new JavaScriptSerializer().Deserialize<PutBucketCORSResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PutBucketCORS Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PutBucketCORSResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Amazon. Note that for a successful exection, this API operation returns an empty 200 response.</returns>
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
