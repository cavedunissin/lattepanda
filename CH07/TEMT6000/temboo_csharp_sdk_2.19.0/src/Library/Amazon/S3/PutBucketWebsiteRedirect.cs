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
    /// PutBucketWebsiteRedirect
    /// Configures the specified bucket as a website and sets the web request redirects to a designated endpoint.
    /// </summary>
    public class PutBucketWebsiteRedirect : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PutBucketWebsiteRedirect Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PutBucketWebsiteRedirect(TembooSession session) : base(session, "/Library/Amazon/S3/PutBucketWebsiteRedirect")
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
         /// (optional, xml) A custom xml file for adding advanced website redirection rule(s). See description and Amazon  docs for details. Note - inputting a custom xml file will overwrite all other optional input values.
         /// </summary>
         /// <param name="value">Value of the CustomWebsiteRedirection input for this Choreo.</param>
         public void setCustomWebsiteRedirection(String value) {
             base.addInput ("CustomWebsiteRedirection", value);
         }
         /// <summary>
         /// (optional, string) The object key name to use when a 4XX class error occurs. Returns specified page when such an error occurs. Ex.: Error.html.
         /// </summary>
         /// <param name="value">Value of the ErrorDocument input for this Choreo.</param>
         public void setErrorDocument(String value) {
             base.addInput ("ErrorDocument", value);
         }
         /// <summary>
         /// (optional, string) Name of the host where requests will be redirected. Used when setting redirect rules, optional if specifying ReplaceKeyPrefixWith or ReplaceKeyWith input variables). Ex.: example.com.
         /// </summary>
         /// <param name="value">Value of the HostName input for this Choreo.</param>
         public void setHostName(String value) {
             base.addInput ("HostName", value);
         }
         /// <summary>
         /// (optional, string) The HTTP error code condition for which a redirect occurs. If there's an error and the error code equals this value, then the specified redirect is applied. Can use with KeyPrefixEquals. Ex:  404.
         /// </summary>
         /// <param name="value">Value of the HttpErrorCodeReturnedEquals input for this Choreo.</param>
         public void setHttpErrorCodeReturnedEquals(String value) {
             base.addInput ("HttpErrorCodeReturnedEquals", value);
         }
         /// <summary>
         /// (optional, string) The HTTP redirect code to use on the response.
         /// </summary>
         /// <param name="value">Value of the HttpRedirectCode input for this Choreo.</param>
         public void setHttpRedirectCode(String value) {
             base.addInput ("HttpRedirectCode", value);
         }
         /// <summary>
         /// (optional, string) The name or prefix condition of the object that will trigger the redirect action. Can use with HttpErrorCodeReturnedEquals. Ex:  Single page: ExamplePage.html, All pages with prefix: /images.
         /// </summary>
         /// <param name="value">Value of the KeyPrefixEquals input for this Choreo.</param>
         public void setKeyPrefixEquals(String value) {
             base.addInput ("KeyPrefixEquals", value);
         }
         /// <summary>
         /// (optional, string) Sets protocol to use when redirecting requests. Optional if you are specifying either ReplaceKeyPrefixWith or ReplaceKeyWith optional inputs. Possible values: http, https.
         /// </summary>
         /// <param name="value">Value of the Protocol input for this Choreo.</param>
         public void setProtocol(String value) {
             base.addInput ("Protocol", value);
         }
         /// <summary>
         /// (optional, string) The object key prefix to use in the redirect request. Redirects requests to the specified prefix. Cannot be used with ReplaceKeyWith. Ex.: /documents.
         /// </summary>
         /// <param name="value">Value of the ReplaceKeyPrefixWith input for this Choreo.</param>
         public void setReplaceKeyPrefixWith(String value) {
             base.addInput ("ReplaceKeyPrefixWith", value);
         }
         /// <summary>
         /// (optional, string) The specific object key to use in the redirect request. Cannot be used with ReplaceKeyPrefixWith. Ex.: error.html.
         /// </summary>
         /// <param name="value">Value of the ReplaceKeyWith input for this Choreo.</param>
         public void setReplaceKeyWith(String value) {
             base.addInput ("ReplaceKeyWith", value);
         }
         /// <summary>
         /// (optional, string) The default page returned when there is a request to a directory. I.e.: if you input index.html, a request for /images/ will return the data for the object '/images/index.html'. Default is index.html.
         /// </summary>
         /// <param name="value">Value of the Suffix input for this Choreo.</param>
         public void setSuffix(String value) {
             base.addInput ("Suffix", value);
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
        /// <returns>A PutBucketWebsiteRedirectResultSet containing execution metadata and results.</returns>
        new public PutBucketWebsiteRedirectResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PutBucketWebsiteRedirectResultSet results = new JavaScriptSerializer().Deserialize<PutBucketWebsiteRedirectResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PutBucketWebsiteRedirect Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PutBucketWebsiteRedirectResultSet : Temboo.Core.ResultSet
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
