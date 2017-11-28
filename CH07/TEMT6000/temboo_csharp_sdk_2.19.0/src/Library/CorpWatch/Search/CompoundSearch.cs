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

namespace Temboo.Library.CorpWatch.Search
{
    /// <summary>
    /// CompoundSearch
    /// Returns a list of companies according to several search parameters such as industry, location, date range, company name, etc.
    /// </summary>
    public class CompoundSearch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CompoundSearch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CompoundSearch(TembooSession session) : base(session, "/Library/CorpWatch/Search/CompoundSearch")
        {
        }

         /// <summary>
         /// (optional, string) The APIKey from CorpWatch if you have one.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (conditional, string) Specific fragment of an address to be searched, such as "empire" or "Main Street."
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (optional, string) Two-letter country code (e.g. VI for Virgin Islands).
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
         }
         /// <summary>
         /// (optional, integer) Set the index number of the first result to be returned. The index of the first result is 0.
         /// </summary>
         /// <param name="value">Value of the Index input for this Choreo.</param>
         public void setIndex(String value) {
             base.addInput ("Index", value);
         }
         /// <summary>
         /// (conditional, integer) Standard Industrial Classification (SIC) code.
         /// </summary>
         /// <param name="value">Value of the IndustryCode input for this Choreo.</param>
         public void setIndustryCode(String value) {
             base.addInput ("IndustryCode", value);
         }
         /// <summary>
         /// (conditional, integer) Standard Industrial Classification (SIC) sector code.
         /// </summary>
         /// <param name="value">Value of the IndustrySector input for this Choreo.</param>
         public void setIndustrySector(String value) {
             base.addInput ("IndustrySector", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to be returned. Defaults to 100. Maximum is 5000.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) By default search terms match against complete words. Use 1 to return cases where the search string matches anywhere in the Name or Address field. Performance is significantly affected when enabled.
         /// </summary>
         /// <param name="value">Value of the Match input for this Choreo.</param>
         public void setMatch(String value) {
             base.addInput ("Match", value);
         }
         /// <summary>
         /// (optional, integer) Indicate desired year of the most recent appearance in SEC filing data (e.g. indicating 2007 will search for companies that ceased filing in 2007).
         /// </summary>
         /// <param name="value">Value of the MaxYear input for this Choreo.</param>
         public void setMaxYear(String value) {
             base.addInput ("MaxYear", value);
         }
         /// <summary>
         /// (optional, integer) Indicate desired year of the most recent appearance in SEC filing data (e.g. indicating 2007 will search for companies that ceased filing in 2007).
         /// </summary>
         /// <param name="value">Value of the MinYear input for this Choreo.</param>
         public void setMinYear(String value) {
             base.addInput ("MinYear", value);
         }
         /// <summary>
         /// (conditional, string) Company name to search. Words in the search query must match to full words in the name. See documentation for more details.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, integer) Limit results to those with a specified number of listed subsidiaries, or "children." (Only immediate relationships are counted.
         /// </summary>
         /// <param name="value">Value of the NumChildren input for this Choreo.</param>
         public void setNumChildren(String value) {
             base.addInput ("NumChildren", value);
         }
         /// <summary>
         /// (optional, integer) Limit results to those with a specified number of listed parent companies (only immediate relationships are counted).
         /// </summary>
         /// <param name="value">Value of the NumParents input for this Choreo.</param>
         public void setNumParents(String value) {
             base.addInput ("NumParents", value);
         }
         /// <summary>
         /// (optional, string) Specify json or xml for the type of response to be returned. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, string) Indicate "filers" to restrict results to those of companies that appeared as a filer on SEC documents, or "relationships" for companies that only appear as subsidiaries on filings.
         /// </summary>
         /// <param name="value">Value of the SourceType input for this Choreo.</param>
         public void setSourceType(String value) {
             base.addInput ("SourceType", value);
         }
         /// <summary>
         /// (optional, string) Two-letter abbreviation for the subdivision of the area to be searched (e.g. "OR" for Oregon when CountryCode is set to "US").
         /// </summary>
         /// <param name="value">Value of the SubdivisionCode input for this Choreo.</param>
         public void setSubdivisionCode(String value) {
             base.addInput ("SubdivisionCode", value);
         }
         /// <summary>
         /// (optional, integer) Limit results by he CWID of the highest-level owning parent of a family of corprorations (or Top Parent). Most company records contain a field for top_parent_id.
         /// </summary>
         /// <param name="value">Value of the TopParent input for this Choreo.</param>
         public void setTopParent(String value) {
             base.addInput ("TopParent", value);
         }
         /// <summary>
         /// (optional, integer) If a year is specified, only records for that year will be returned and the data in the company objects returned will be set appropriately for the request year. Defaults to most recent.
         /// </summary>
         /// <param name="value">Value of the Year input for this Choreo.</param>
         public void setYear(String value) {
             base.addInput ("Year", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CompoundSearchResultSet containing execution metadata and results.</returns>
        new public CompoundSearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CompoundSearchResultSet results = new JavaScriptSerializer().Deserialize<CompoundSearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CompoundSearch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CompoundSearchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from CorpWatch.</returns>
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
