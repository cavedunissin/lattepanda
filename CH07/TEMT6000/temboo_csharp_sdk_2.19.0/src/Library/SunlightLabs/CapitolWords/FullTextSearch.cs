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

namespace Temboo.Library.SunlightLabs.CapitolWords
{
    /// <summary>
    /// FullTextSearch
    /// Returns a list of Congressional Record documents in which the given phrase appears.
    /// </summary>
    public class FullTextSearch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FullTextSearch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FullTextSearch(TembooSession session) : base(session, "/Library/SunlightLabs/CapitolWords/FullTextSearch")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Sunlight Labs.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Limit results to the member of Congress with the given Bioguide ID. The Bioguide ID of any current or past congressonal member can be found at bioguide.congress.gov.
         /// </summary>
         /// <param name="value">Value of the BioguideID input for this Choreo.</param>
         public void setBioguideID(String value) {
             base.addInput ("BioguideID", value);
         }
         /// <summary>
         /// (optional, string) The pages in the Congressional Record to search.
         /// </summary>
         /// <param name="value">Value of the CRPages input for this Choreo.</param>
         public void setCRPages(String value) {
             base.addInput ("CRPages", value);
         }
         /// <summary>
         /// (optional, string) Limit results to a particular chamber. Valid values: house, senate, extensions.
         /// </summary>
         /// <param name="value">Value of the Chamber input for this Choreo.</param>
         public void setChamber(String value) {
             base.addInput ("Chamber", value);
         }
         /// <summary>
         /// (optional, string) Show results for only the given date. Format: YYYY-MM-DD
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, string) Limit results to those on or before the given date. Format: YYYY-MM-DD.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to show. 100 shown at a time.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, string) Limit results to members of congress from a given party. Valid values: R, D, I.
         /// </summary>
         /// <param name="value">Value of the Party input for this Choreo.</param>
         public void setParty(String value) {
             base.addInput ("Party", value);
         }
         /// <summary>
         /// (required, string) A phrase to search the body of each Congressional Record document for. Either Phrase or Title inputs are required.
         /// </summary>
         /// <param name="value">Value of the Phrase input for this Choreo.</param>
         public void setPhrase(String value) {
             base.addInput ("Phrase", value);
         }
         /// <summary>
         /// (optional, string) Output formats inlcude json and xml. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Limit results to those on or after the given date. Format: YYYY-MM-DD
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, string) Limit results to members from a particular state. Format: 2-letter state abbreviation (e.g. MD, RI, NY)
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (optional, integer) A phrase to search the title of each Congressional Record document for. Either Phrase or Title are required.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FullTextSearchResultSet containing execution metadata and results.</returns>
        new public FullTextSearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FullTextSearchResultSet results = new JavaScriptSerializer().Deserialize<FullTextSearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FullTextSearch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FullTextSearchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from CapitolWords.</returns>
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
