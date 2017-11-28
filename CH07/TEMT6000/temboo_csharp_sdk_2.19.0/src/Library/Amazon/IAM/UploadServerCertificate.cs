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

namespace Temboo.Library.Amazon.IAM
{
    /// <summary>
    /// UploadServerCertificate
    /// Uploads a server certificate entity for the AWS account. The server certificate entity includes a public key certificate, a private key, and an optional certificate chain, which should all be PEM-encoded.
    /// </summary>
    public class UploadServerCertificate : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UploadServerCertificate Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UploadServerCertificate(TembooSession session) : base(session, "/Library/Amazon/IAM/UploadServerCertificate")
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
         /// (required, multiline) The contents of the signing certificate.
         /// </summary>
         /// <param name="value">Value of the CertificateBody input for this Choreo.</param>
         public void setCertificateBody(String value) {
             base.addInput ("CertificateBody", value);
         }
         /// <summary>
         /// (optional, multiline) The contents of the certificate chain. This is typically a concatenation of the PEM-encoded public key certificates of the chain.
         /// </summary>
         /// <param name="value">Value of the CertificateChain input for this Choreo.</param>
         public void setCertificateChain(String value) {
             base.addInput ("CertificateChain", value);
         }
         /// <summary>
         /// (optional, string) The path for the server certificate.
         /// </summary>
         /// <param name="value">Value of the Path input for this Choreo.</param>
         public void setPath(String value) {
             base.addInput ("Path", value);
         }
         /// <summary>
         /// (required, multiline) The contents of the private key in PEM-encoded format.
         /// </summary>
         /// <param name="value">Value of the PrivateKey input for this Choreo.</param>
         public void setPrivateKey(String value) {
             base.addInput ("PrivateKey", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The name for the server certificate. Do not include the path in this value.
         /// </summary>
         /// <param name="value">Value of the ServerCertificateName input for this Choreo.</param>
         public void setServerCertificateName(String value) {
             base.addInput ("ServerCertificateName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UploadServerCertificateResultSet containing execution metadata and results.</returns>
        new public UploadServerCertificateResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UploadServerCertificateResultSet results = new JavaScriptSerializer().Deserialize<UploadServerCertificateResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UploadServerCertificate Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UploadServerCertificateResultSet : Temboo.Core.ResultSet
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
