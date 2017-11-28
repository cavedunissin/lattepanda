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
    /// PutBucketWebsiteRedirectAll
    /// Configures the specified bucket as a website and redirects all web requests to the designated hostname.
    /// </summary>
    public class PutBucketWebsiteRedirectAll : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PutBucketWebsiteRedirectAll Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PutBucketWebsiteRedirectAll(TembooSession session) : base(session, "/Library/Amazon/S3/PutBucketWebsiteRedirectAll")
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
         /// (required, string) The name of the bucket that you wish to configure.
         /// </summary>
         /// <param name="value">Value of the BucketName input for this Choreo.</param>
         public void setBucketName(String value) {
             base.addInput ("BucketName", value);
         }
         /// <summary>
         /// (required, string) Name of the host where requests will be redirected. Ex.: example.com
         /// </summary>
         /// <param name="value">Value of the HostName input for this Choreo.</param>
         public void setHostName(String value) {
             base.addInput ("HostName", value);
         }
         /// <summary>
         /// (optional, string) Protocol to use (http, https) when redirecting requests. The default is http.
         /// </summary>
         /// <param name="value">Value of the Protocol input for this Choreo.</param>
         public void setProtocol(String value) {
             base.addInput ("Protocol", value);
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
        /// <returns>A PutBucketWebsiteRedirectAllResultSet containing execution metadata and results.</returns>
        new public PutBucketWebsiteRedirectAllResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PutBucketWebsiteRedirectAllResultSet results = new JavaScriptSerializer().Deserialize<PutBucketWebsiteRedirectAllResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PutBucketWebsiteRedirectAll Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PutBucketWebsiteRedirectAllResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Stores the response from Amazon. Note that for a successful website configuration request, no content is returned and this output variable will be empty.</returns>
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
