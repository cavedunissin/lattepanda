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

namespace Temboo.Library.Amazon.Marketplace.Feeds
{
    /// <summary>
    /// GetFeedSubmissionList
    /// Returns a list of all feed submissions submitted in the previous 90 days.
    /// </summary>
    public class GetFeedSubmissionList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetFeedSubmissionList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetFeedSubmissionList(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Feeds/GetFeedSubmissionList")
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
         /// (required, string) The Marketplace ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSMarketplaceId input for this Choreo.</param>
         public void setAWSMarketplaceId(String value) {
             base.addInput ("AWSMarketplaceId", value);
         }
         /// <summary>
         /// (required, string) The Merchant ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSMerchantId input for this Choreo.</param>
         public void setAWSMerchantId(String value) {
             base.addInput ("AWSMerchantId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (conditional, string) The base URL for the MWS endpoint. Defaults to mws.amazonservices.co.uk.
         /// </summary>
         /// <param name="value">Value of the Endpoint input for this Choreo.</param>
         public void setEndpoint(String value) {
             base.addInput ("Endpoint", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of one or more feed processing statuses by which to filter the list of feed submissions.
         /// </summary>
         /// <param name="value">Value of the FeedProcessingStatusList input for this Choreo.</param>
         public void setFeedProcessingStatusList(String value) {
             base.addInput ("FeedProcessingStatusList", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of FeedSubmmissionId values. If you pass in FeedSubmmissionId values in a request, other query conditions are ignored.
         /// </summary>
         /// <param name="value">Value of the FeedSubmissionIdList input for this Choreo.</param>
         public void setFeedSubmissionIdList(String value) {
             base.addInput ("FeedSubmissionIdList", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of one or more FeedType enumeration values by which to filter the list of feed submissions.
         /// </summary>
         /// <param name="value">Value of the FeedTypeList input for this Choreo.</param>
         public void setFeedTypeList(String value) {
             base.addInput ("FeedTypeList", value);
         }
         /// <summary>
         /// (optional, string) The Amazon MWS authorization token for the given seller and developer.
         /// </summary>
         /// <param name="value">Value of the MWSAuthToken input for this Choreo.</param>
         public void setMWSAuthToken(String value) {
             base.addInput ("MWSAuthToken", value);
         }
         /// <summary>
         /// (optional, integer) A non-negative integer that indicates the maximum number of feed submissions to return in the list. Defaults to 10. Max is 100.
         /// </summary>
         /// <param name="value">Value of the MaxCount input for this Choreo.</param>
         public void setMaxCount(String value) {
             base.addInput ("MaxCount", value);
         }
         /// <summary>
         /// (optional, date) The earliest submission date that you are looking for, in ISO8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the SubmittedFromDate input for this Choreo.</param>
         public void setSubmittedFromDate(String value) {
             base.addInput ("SubmittedFromDate", value);
         }
         /// <summary>
         /// (optional, date) The latest submission date that you are looking for, in ISO8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the SubmittedToDate input for this Choreo.</param>
         public void setSubmittedToDate(String value) {
             base.addInput ("SubmittedToDate", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetFeedSubmissionListResultSet containing execution metadata and results.</returns>
        new public GetFeedSubmissionListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetFeedSubmissionListResultSet results = new JavaScriptSerializer().Deserialize<GetFeedSubmissionListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetFeedSubmissionList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetFeedSubmissionListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "FeedProcessingStatus" output from this Choreo execution
        /// <returns>String - (string) The FeedProcessingStatus parsed from the Amazon response.</returns>
        /// </summary>
        public String FeedProcessingStatus
        {
            get
            {
                return (String) base.Output["FeedProcessingStatus"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "FeedSubmissionId" output from this Choreo execution
        /// <returns>String - (integer) The FeedSubmissionId parsed from the Amazon response. If multiple records are returned, this output variable will contain the first id in the list.</returns>
        /// </summary>
        public String FeedSubmissionId
        {
            get
            {
                return (String) base.Output["FeedSubmissionId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) Stores the response from Amazon.</returns>
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
