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

namespace Temboo.Library.Yahoo.Finance
{
    /// <summary>
    /// GetNews
    /// Retrieves the most recent Yahoo Finance Company or Industry news items as an RSS feed.
    /// </summary>
    public class GetNews : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetNews Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetNews(TembooSession session) : base(session, "/Library/Yahoo/Finance/GetNews")
        {
        }

         /// <summary>
         /// (required, string) Ticker symbol for one or more companies to search, separated by commas (e.g. YHOO,DIS to include news about Yahoo! and Disney).
         /// </summary>
         /// <param name="value">Value of the Company input for this Choreo.</param>
         public void setCompany(String value) {
             base.addInput ("Company", value);
         }
         /// <summary>
         /// (required, string) Enter the type of news items you want to see in the RSS feed: headline or industry.
         /// </summary>
         /// <param name="value">Value of the NewsType input for this Choreo.</param>
         public void setNewsType(String value) {
             base.addInput ("NewsType", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetNewsResultSet containing execution metadata and results.</returns>
        new public GetNewsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetNewsResultSet results = new JavaScriptSerializer().Deserialize<GetNewsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetNews Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetNewsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Yahoo Finance.</returns>
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
