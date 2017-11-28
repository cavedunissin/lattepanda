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

namespace Temboo.Library.NYTimes.ArticleSearch
{
    /// <summary>
    /// QueryArticles
    /// Searches New York Times articles and retrieves headlines, abstracts, lead paragraphs, links to associated multimedia, and other article metadata.
    /// </summary>
    public class QueryArticles : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the QueryArticles Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public QueryArticles(TembooSession session) : base(session, "/Library/NYTimes/ArticleSearch/QueryArticles")
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
         /// (optional, date) Filters the result for articles with publication dates of the date specified or later. Dates should be formatted like YYYYMMDD.
         /// </summary>
         /// <param name="value">Value of the BeginDate input for this Choreo.</param>
         public void setBeginDate(String value) {
             base.addInput ("BeginDate", value);
         }
         /// <summary>
         /// (optional, date) Filters the result for articles with publication dates of the date specified or earlier. Dates should be formatted like YYYYMMDD.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, boolean) When set to "true", facet counts will respect any applied filters such as Query, BeginDate, EndDate, etc.
         /// </summary>
         /// <param name="value">Value of the FacetFilter input for this Choreo.</param>
         public void setFacetFilter(String value) {
             base.addInput ("FacetFilter", value);
         }
         /// <summary>
         /// (optional, string) A comma-delimited list of facets. This indicates the sets of facet values to include in the response. Valid facets include: section_name, document_type, type_of_material, source, and day_of_week.
         /// </summary>
         /// <param name="value">Value of the Facets input for this Choreo.</param>
         public void setFacets(String value) {
             base.addInput ("Facets", value);
         }
         /// <summary>
         /// (optional, string) A comma-delimited list of fields to return.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) An advanced search option that allows you to filter by specific fields. See Choreo notes for syntax details.
         /// </summary>
         /// <param name="value">Value of the Filter input for this Choreo.</param>
         public void setFilter(String value) {
             base.addInput ("Filter", value);
         }
         /// <summary>
         /// (optional, boolean) Enables highlighting in search results. When set to "true", the value of Query is highlighted in the headline and lead_paragraph fields. Defaults to "false".
         /// </summary>
         /// <param name="value">Value of the Highlighting input for this Choreo.</param>
         public void setHighlighting(String value) {
             base.addInput ("Highlighting", value);
         }
         /// <summary>
         /// (optional, integer) This corresponds to which set of 10 results is returned. Used to page through results. Set to 0 to return records 0-9, set to 1 to return records 10-19, etc.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (conditional, string) Searches the article body, headline and byline for the specified term.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) By default, search results are sorted by their relevance to the Query provided. Set to "newest" or "oldest" to sort by publication date.
         /// </summary>
         /// <param name="value">Value of the Rank input for this Choreo.</param>
         public void setRank(String value) {
             base.addInput ("Rank", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A QueryArticlesResultSet containing execution metadata and results.</returns>
        new public QueryArticlesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            QueryArticlesResultSet results = new JavaScriptSerializer().Deserialize<QueryArticlesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the QueryArticles Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class QueryArticlesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from the NY Times API.</returns>
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
