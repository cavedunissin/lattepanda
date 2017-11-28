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

namespace Temboo.Library.SunlightLabs.Congress.Legislator
{
    /// <summary>
    /// GetList
    /// Returns a list of legislators that meet a specified search criteria.
    /// </summary>
    public class GetList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetList(TembooSession session) : base(session, "/Library/SunlightLabs/Congress/Legislator/GetList")
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
         /// (optional, boolean) A boolean flag indicating to search for all legislators even when they are no longer in office.
         /// </summary>
         /// <param name="value">Value of the AllLegislators input for this Choreo.</param>
         public void setAllLegislators(String value) {
             base.addInput ("AllLegislators", value);
         }
         /// <summary>
         /// (optional, string) The bioguide_id of the legislator to return.
         /// </summary>
         /// <param name="value">Value of the BioguideID input for this Choreo.</param>
         public void setBioguideID(String value) {
             base.addInput ("BioguideID", value);
         }
         /// <summary>
         /// (optional, string) The crp_id associated with a legislator to return.
         /// </summary>
         /// <param name="value">Value of the CRPID input for this Choreo.</param>
         public void setCRPID(String value) {
             base.addInput ("CRPID", value);
         }
         /// <summary>
         /// (optional, integer) Narrows the search result by district number.
         /// </summary>
         /// <param name="value">Value of the District input for this Choreo.</param>
         public void setDistrict(String value) {
             base.addInput ("District", value);
         }
         /// <summary>
         /// (optional, string) The fec_id associated with the legislator to return.
         /// </summary>
         /// <param name="value">Value of the FECID input for this Choreo.</param>
         public void setFECID(String value) {
             base.addInput ("FECID", value);
         }
         /// <summary>
         /// (optional, string) The facebook id of a legislator to return.
         /// </summary>
         /// <param name="value">Value of the FacebookID input for this Choreo.</param>
         public void setFacebookID(String value) {
             base.addInput ("FacebookID", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing key/value pairs to be used as filters.
         /// </summary>
         /// <param name="value">Value of the Filters input for this Choreo.</param>
         public void setFilters(String value) {
             base.addInput ("Filters", value);
         }
         /// <summary>
         /// (optional, string) The first name of a legislator to return.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
         }
         /// <summary>
         /// (optional, string) Narrows the search result by gender.
         /// </summary>
         /// <param name="value">Value of the Gender input for this Choreo.</param>
         public void setGender(String value) {
             base.addInput ("Gender", value);
         }
         /// <summary>
         /// (optional, string) The govetrack_id associated with a legistlator to return.
         /// </summary>
         /// <param name="value">Value of the GovTrackID input for this Choreo.</param>
         public void setGovTrackID(String value) {
             base.addInput ("GovTrackID", value);
         }
         /// <summary>
         /// (optional, boolean) Whether or not the individual is in office currently. Valid values are true or false.
         /// </summary>
         /// <param name="value">Value of the InOffice input for this Choreo.</param>
         public void setInOffice(String value) {
             base.addInput ("InOffice", value);
         }
         /// <summary>
         /// (optional, string) The last name of the legislator to return.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (optional, string) Used to order the results by field name (e.g. field__asc).
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (optional, integer) The page offset.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, string) Narrows the search result by party (i.e. "D" or "R").
         /// </summary>
         /// <param name="value">Value of the Party input for this Choreo.</param>
         public void setParty(String value) {
             base.addInput ("Party", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return per page.
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (optional, string) A search term.
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
         /// (optional, string) A state abbreviation to narrow the search results.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (optional, string) The title associated with the individual to return.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (optional, string) The twitter id of the legislator to return (note, this can be a twitter screen name).
         /// </summary>
         /// <param name="value">Value of the TwitterID input for this Choreo.</param>
         public void setTwitterID(String value) {
             base.addInput ("TwitterID", value);
         }
         /// <summary>
         /// (optional, integer) The votesmart_id of a legislator to return.
         /// </summary>
         /// <param name="value">Value of the VoteSmartID input for this Choreo.</param>
         public void setVoteSmartID(String value) {
             base.addInput ("VoteSmartID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetListResultSet containing execution metadata and results.</returns>
        new public GetListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetListResultSet results = new JavaScriptSerializer().Deserialize<GetListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the Sunlight Congress API.</returns>
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
