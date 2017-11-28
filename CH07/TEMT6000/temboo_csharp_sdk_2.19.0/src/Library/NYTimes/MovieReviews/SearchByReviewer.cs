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

namespace Temboo.Library.NYTimes.MovieReviews
{
    /// <summary>
    /// SearchByReviewer
    /// Retrieves reviews by a specific Times reviewer.
    /// </summary>
    public class SearchByReviewer : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByReviewer Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByReviewer(TembooSession session) : base(session, "/Library/NYTimes/MovieReviews/SearchByReviewer")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by NY Times.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Set this parameter to Y to limt the results to NYT Critics' Picks. To get only those movies that have not been highlighted by Times critics, specify N.
         /// </summary>
         /// <param name="value">Value of the CriticsPick input for this Choreo.</param>
         public void setCriticsPick(String value) {
             base.addInput ("CriticsPick", value);
         }
         /// <summary>
         /// (optional, string) The number of results to return.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) A numeric value indicating the starting point of the result set. Used to page through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) Sets the sort order of the results. Accepted values are: by-title, by-publication-date, by-opening-date, by-dvd-release-date.
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) Limits results to reviews by a specific critic.
         /// </summary>
         /// <param name="value">Value of the ReviewerName input for this Choreo.</param>
         public void setReviewerName(String value) {
             base.addInput ("ReviewerName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchByReviewerResultSet containing execution metadata and results.</returns>
        new public SearchByReviewerResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByReviewerResultSet results = new JavaScriptSerializer().Deserialize<SearchByReviewerResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByReviewer Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByReviewerResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the NY Times API.</returns>
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
