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

namespace Temboo.Library.Amazon.Marketplace.Reports
{
    /// <summary>
    /// GetReportList
    /// Returns a list of reports that were created in the previous 90 days.
    /// </summary>
    public class GetReportList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetReportList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetReportList(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Reports/GetReportList")
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
         /// (optional, boolean) A Boolean value that indicates if an order report has been acknowledged by a prior call to UpdateReportAcknowledgements. Set to "true" to list order reports that have been acknowledged.
         /// </summary>
         /// <param name="value">Value of the Acknowledged input for this Choreo.</param>
         public void setAcknowledged(String value) {
             base.addInput ("Acknowledged", value);
         }
         /// <summary>
         /// (optional, date) The earliest date you are looking for, in ISO8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the AvailableFromDate input for this Choreo.</param>
         public void setAvailableFromDate(String value) {
             base.addInput ("AvailableFromDate", value);
         }
         /// <summary>
         /// (optional, date) The most recent date you are looking for, in ISO8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the AvailableToDate input for this Choreo.</param>
         public void setAvailableToDate(String value) {
             base.addInput ("AvailableToDate", value);
         }
         /// <summary>
         /// (conditional, string) The base URL for the MWS endpoint. Defaults to mws.amazonservices.co.uk.
         /// </summary>
         /// <param name="value">Value of the Endpoint input for this Choreo.</param>
         public void setEndpoint(String value) {
             base.addInput ("Endpoint", value);
         }
         /// <summary>
         /// (optional, string) The Amazon MWS authorization token for the given seller and developer.
         /// </summary>
         /// <param name="value">Value of the MWSAuthToken input for this Choreo.</param>
         public void setMWSAuthToken(String value) {
             base.addInput ("MWSAuthToken", value);
         }
         /// <summary>
         /// (optional, integer) A non-negative integer that represents the maximum number of report requests to return. Defaults to 10. Max is 100.
         /// </summary>
         /// <param name="value">Value of the MaxCount input for this Choreo.</param>
         public void setMaxCount(String value) {
             base.addInput ("MaxCount", value);
         }
         /// <summary>
         /// (optional, integer) A ReportRequestId value. If you pass a ReportRequestId value, other query conditions are ignored.
         /// </summary>
         /// <param name="value">Value of the ReportRequestId input for this Choreo.</param>
         public void setReportRequestId(String value) {
             base.addInput ("ReportRequestId", value);
         }
         /// <summary>
         /// (optional, string) A ReportType enumeration value (i.e. GET_ORDERS_DATA_).
         /// </summary>
         /// <param name="value">Value of the ReportType input for this Choreo.</param>
         public void setReportType(String value) {
             base.addInput ("ReportType", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetReportListResultSet containing execution metadata and results.</returns>
        new public GetReportListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetReportListResultSet results = new JavaScriptSerializer().Deserialize<GetReportListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetReportList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetReportListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ReportId" output from this Choreo execution
        /// <returns>String - (integer) The report id parsed from the Amazon response. If multiple records are returned, this output variable will contain the first id in the list.</returns>
        /// </summary>
        public String ReportId
        {
            get
            {
                return (String) base.Output["ReportId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Stores the response from Amazon.</returns>
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
