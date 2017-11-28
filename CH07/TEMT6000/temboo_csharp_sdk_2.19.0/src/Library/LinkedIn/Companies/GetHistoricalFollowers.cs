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

namespace Temboo.Library.LinkedIn.Companies
{
    /// <summary>
    /// GetHistoricalFollowers
    /// Returns a company's followers, by date range.
    /// </summary>
    public class GetHistoricalFollowers : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetHistoricalFollowers Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetHistoricalFollowers(TembooSession session) : base(session, "/Library/LinkedIn/Companies/GetHistoricalFollowers")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by LinkedIn (AKA the Client ID).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process (AKA the OAuth User Token).
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret retrieved during the OAuth process (AKA the OAuth User Secret).
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, integer) A LinkedIn assigned ID associated with the company.
         /// </summary>
         /// <param name="value">Value of the CompanyID input for this Choreo.</param>
         public void setCompanyID(String value) {
             base.addInput ("CompanyID", value);
         }
         /// <summary>
         /// (optional, date) The starting timestamp of when the stats search should begin (milliseconds since epoch). The current time will be used if a timestamp is not provided.
         /// </summary>
         /// <param name="value">Value of the EndTimestamp input for this Choreo.</param>
         public void setEndTimestamp(String value) {
             base.addInput ("EndTimestamp", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The Secret Key provided by LinkedIn (AKA the Client Secret).
         /// </summary>
         /// <param name="value">Value of the SecretKey input for this Choreo.</param>
         public void setSecretKey(String value) {
             base.addInput ("SecretKey", value);
         }
         /// <summary>
         /// (required, date) The starting timestamp of when the stats search should begin (milliseconds since epoch). The current time will be used if a timestamp is not provided.
         /// </summary>
         /// <param name="value">Value of the StartTimestamp input for this Choreo.</param>
         public void setStartTimestamp(String value) {
             base.addInput ("StartTimestamp", value);
         }
         /// <summary>
         /// (required, string) Granularity of statistics. Valid values are: day, month.
         /// </summary>
         /// <param name="value">Value of the TimeGranularity input for this Choreo.</param>
         public void setTimeGranularity(String value) {
             base.addInput ("TimeGranularity", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetHistoricalFollowersResultSet containing execution metadata and results.</returns>
        new public GetHistoricalFollowersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetHistoricalFollowersResultSet results = new JavaScriptSerializer().Deserialize<GetHistoricalFollowersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetHistoricalFollowers Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetHistoricalFollowersResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from LinkedIn.</returns>
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
