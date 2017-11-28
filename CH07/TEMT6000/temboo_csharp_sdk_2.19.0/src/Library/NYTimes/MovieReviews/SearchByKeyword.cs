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
    /// SearchByKeyword
    /// Searches movie reviews by keyword and various filter parameters.
    /// </summary>
    public class SearchByKeyword : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchByKeyword Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchByKeyword(TembooSession session) : base(session, "/Library/NYTimes/MovieReviews/SearchByKeyword")
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
         /// (optional, string) Set this parameter to Y to limit the results to movies that have been released on DVD. To get only those movies that have not been released on DVD, specify N.
         /// </summary>
         /// <param name="value">Value of the DVD input for this Choreo.</param>
         public void setDVD(String value) {
             base.addInput ("DVD", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) A numeric value indicating the starting point of the result set. This can be used in combination with the Limit input to page through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, date) Limits by date or range of dates. The opening-date is the date the movie's opening date in the New York region. Format YYYY-MM-DD. Separate ranges with semicolons.
         /// </summary>
         /// <param name="value">Value of the OpeningDate input for this Choreo.</param>
         public void setOpeningDate(String value) {
             base.addInput ("OpeningDate", value);
         }
         /// <summary>
         /// (optional, string) Sets the sort order of the results. Accepted values are: by-title, by-publication-date, by-opening-date, by-dvd-release-date.
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (optional, date) Limits by date or range of dates. The publication-date is the date the review was first publish.ed in The Times. Format YYYY-MM-DD. Separate ranges with semicolons.
         /// </summary>
         /// <param name="value">Value of the PublicationDate input for this Choreo.</param>
         public void setPublicationDate(String value) {
             base.addInput ("PublicationDate", value);
         }
         /// <summary>
         /// (conditional, string) A string of search keywords. Matches movie titles and indexed terms.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Limits results to reviews by a specific critic.
         /// </summary>
         /// <param name="value">Value of the Reviewer input for this Choreo.</param>
         public void setReviewer(String value) {
             base.addInput ("Reviewer", value);
         }
         /// <summary>
         /// (optional, string) Set this parameter to Y to limit the results to movies on the Times list of The Best 1,000 Movies Ever Made. To get only those movies that are not on the list, specify N.
         /// </summary>
         /// <param name="value">Value of the ThousandBest input for this Choreo.</param>
         public void setThousandBest(String value) {
             base.addInput ("ThousandBest", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchByKeywordResultSet containing execution metadata and results.</returns>
        new public SearchByKeywordResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchByKeywordResultSet results = new JavaScriptSerializer().Deserialize<SearchByKeywordResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchByKeyword Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchByKeywordResultSet : Temboo.Core.ResultSet
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
