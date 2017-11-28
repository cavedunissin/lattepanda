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
    /// Dates
    /// Returns the popularity of a given phrase in the Congressional Record over time.
    /// </summary>
    public class Dates : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Dates Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Dates(TembooSession session) : base(session, "/Library/SunlightLabs/CapitolWords/Dates")
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
         /// (optional, string) Limit results to the member of Congress with the given Bioguide ID. The Bioguide ID of any current or past congressional member can be found at bioguide.congress.gov.
         /// </summary>
         /// <param name="value">Value of the BioguideID input for this Choreo.</param>
         public void setBioguideID(String value) {
             base.addInput ("BioguideID", value);
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
         /// (optional, string) The length of time covered by each result. Valid values: year, month, day. Defaults to day.
         /// </summary>
         /// <param name="value">Value of the Granularity input for this Choreo.</param>
         public void setGranularity(String value) {
             base.addInput ("Granularity", value);
         }
         /// <summary>
         /// (optional, boolean) Only returns results where mentions are at or above the supplied threshold.
         /// </summary>
         /// <param name="value">Value of the MinCount input for this Choreo.</param>
         public void setMinCount(String value) {
             base.addInput ("MinCount", value);
         }
         /// <summary>
         /// (optional, string) Limit results to members of congress from a given party. Valid values: R, D, I.
         /// </summary>
         /// <param name="value">Value of the Party input for this Choreo.</param>
         public void setParty(String value) {
             base.addInput ("Party", value);
         }
         /// <summary>
         /// (optional, string) Include the percentage of mentions versus total words in the result objects. Valid values: true, false. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the Percentages input for this Choreo.</param>
         public void setPercentages(String value) {
             base.addInput ("Percentages", value);
         }
         /// <summary>
         /// (required, string) The phrase to search for.
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DatesResultSet containing execution metadata and results.</returns>
        new public DatesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DatesResultSet results = new JavaScriptSerializer().Deserialize<DatesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Dates Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DatesResultSet : Temboo.Core.ResultSet
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
