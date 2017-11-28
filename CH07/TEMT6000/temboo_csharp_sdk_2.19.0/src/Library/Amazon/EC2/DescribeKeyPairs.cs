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

namespace Temboo.Library.Amazon.EC2
{
    /// <summary>
    /// DescribeKeyPairs
    /// Queries the Amazon EC2 API to describe one or more of your key pairs.
    /// </summary>
    public class DescribeKeyPairs : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DescribeKeyPairs Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DescribeKeyPairs(TembooSession session) : base(session, "/Library/Amazon/EC2/DescribeKeyPairs")
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
         /// (optional, string) The name of a supported filter to narrow the results with.
         /// </summary>
         /// <param name="value">Value of the FilterName input for this Choreo.</param>
         public void setFilterName(String value) {
             base.addInput ("FilterName", value);
         }
         /// <summary>
         /// (optional, string) A value for the specified filter.
         /// </summary>
         /// <param name="value">Value of the FilterValue input for this Choreo.</param>
         public void setFilterValue(String value) {
             base.addInput ("FilterValue", value);
         }
         /// <summary>
         /// (optional, string) One or more key pair names to return. This can be a comma-separated list of up to 10 key pair namess.
         /// </summary>
         /// <param name="value">Value of the KeyName input for this Choreo.</param>
         public void setKeyName(String value) {
             base.addInput ("KeyName", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the EC2 endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DescribeKeyPairsResultSet containing execution metadata and results.</returns>
        new public DescribeKeyPairsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DescribeKeyPairsResultSet results = new JavaScriptSerializer().Deserialize<DescribeKeyPairsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DescribeKeyPairs Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DescribeKeyPairsResultSet : Temboo.Core.ResultSet
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
