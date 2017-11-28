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
    /// FlatFileOrderReport
    /// Returns a tab-delimited flat file order report. The report shows orders from the previous 60 days.
    /// </summary>
    public class FlatFileOrderReport : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FlatFileOrderReport Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FlatFileOrderReport(TembooSession session) : base(session, "/Library/Amazon/Marketplace/Reports/FlatFileOrderReport")
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
         /// (optional, date) The end of a date range used for selecting the data to report, in ISO8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
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
         /// (optional, date) The start of a date range used for selecting the data to report, in ISO8601 date format (i.e. 2012-01-01).
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, integer) By default, the Choreo will wait for 5 minutes to see if the report is ready for retrieval. Max is 120 minutes.
         /// </summary>
         /// <param name="value">Value of the TimeToWait input for this Choreo.</param>
         public void setTimeToWait(String value) {
             base.addInput ("TimeToWait", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FlatFileOrderReportResultSet containing execution metadata and results.</returns>
        new public FlatFileOrderReportResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FlatFileOrderReportResultSet results = new JavaScriptSerializer().Deserialize<FlatFileOrderReportResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FlatFileOrderReport Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FlatFileOrderReportResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Report" output from this Choreo execution
        /// <returns>String - (multiline) The report contents.</returns>
        /// </summary>
        public String Report
        {
            get
            {
                return (String) base.Output["Report"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "GeneratedReportId" output from this Choreo execution
        /// <returns>String - (integer) The GeneratedReportId parsed from the Amazon response.</returns>
        /// </summary>
        public String GeneratedReportId
        {
            get
            {
                return (String) base.Output["GeneratedReportId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ReportProcessingStatus" output from this Choreo execution
        /// <returns>String - (string) The status of the report request parsed from the Amazon response.</returns>
        /// </summary>
        public String ReportProcessingStatus
        {
            get
            {
                return (String) base.Output["ReportProcessingStatus"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ReportRequestId" output from this Choreo execution
        /// <returns>String - (integer) The ReportRequestId parsed from the Amazon response. This id is used in GetReportRequestList.</returns>
        /// </summary>
        public String ReportRequestId
        {
            get
            {
                return (String) base.Output["ReportRequestId"];
            }
        }
    }
}
