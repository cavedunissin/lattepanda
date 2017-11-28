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

namespace Temboo.Library.GovTrack
{
    /// <summary>
    /// Bill
    /// Retrieves bills and resolutions in the U.S. Congress since 1973 (the 93rd Congress).
    /// </summary>
    public class Bill : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Bill Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Bill(TembooSession session) : base(session, "/Library/GovTrack/Bill")
        {
        }

         /// <summary>
         /// (optional, integer) The ID number of the bill to retrieve. When using this input, all other filter parameters are ignored, and a single record is returned.
         /// </summary>
         /// <param name="value">Value of the BillID input for this Choreo.</param>
         public void setBillID(String value) {
             base.addInput ("BillID", value);
         }
         /// <summary>
         /// (optional, string) The bill's type (e.g. house_resolution, senate_bill, house_bill, etc). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the BillType input for this Choreo.</param>
         public void setBillType(String value) {
             base.addInput ("BillType", value);
         }
         /// <summary>
         /// (optional, string) The bill's cosponsors. When using this filter, provide the id of the cosponsor which is returned when requesting a single bill object. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the CoSponsors input for this Choreo.</param>
         public void setCoSponsors(String value) {
             base.addInput ("CoSponsors", value);
         }
         /// <summary>
         /// (optional, string) Committees to which the bill has been referred. When using this filter, provide the id of the committee which is returned when requesting a single bill object. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Committees input for this Choreo.</param>
         public void setCommittees(String value) {
             base.addInput ("Committees", value);
         }
         /// <summary>
         /// (optional, string) The number of the congress in which the bill was introduced. The current congress is 113. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Congress input for this Choreo.</param>
         public void setCongress(String value) {
             base.addInput ("Congress", value);
         }
         /// <summary>
         /// (optional, string) The current status of the bill (e.g. passed_bill, prov_kill_veto, introduced, etc). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the CurrentStatus input for this Choreo.</param>
         public void setCurrentStatus(String value) {
             base.addInput ("CurrentStatus", value);
         }
         /// <summary>
         /// (optional, string) The date of the last major action on the bill corresponding to the CurrentStatus (in YYYY-MM-DD format). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the CurrentStatusDate input for this Choreo.</param>
         public void setCurrentStatusDate(String value) {
             base.addInput ("CurrentStatusDate", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of fields to return in the response. Use double-underscores to span relationships (e.g. person__firstname).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) The date the bill was introduced (in YYYY-MM-DD format). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the IntroducedDate input for this Choreo.</param>
         public void setIntroducedDate(String value) {
             base.addInput ("IntroducedDate", value);
         }
         /// <summary>
         /// (optional, integer) Results are paged 100 per call by default. Set the limit input to a high value to get all of the results at once.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The bill's number. This is different from the BillID. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Number input for this Choreo.</param>
         public void setNumber(String value) {
             base.addInput ("Number", value);
         }
         /// <summary>
         /// (optional, integer) Offset the results by the number given, useful for paging through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (conditional, string) Filters according to a full-text search on the object.
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
         /// (optional, string) You can order the results using fieldname (ascending) or -fieldname (descending) where "fieldname" is one of the variables that is listed as 'Sortable' in the description. Ex: '-congress'
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (optional, string) The ID of the sponsor of the bill. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Sponsor input for this Choreo.</param>
         public void setSponsor(String value) {
             base.addInput ("Sponsor", value);
         }
         /// <summary>
         /// (optional, string) Subject areas associated with the bill. When using this filter, provide the id of the term which is returned when requesting a single bill object. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Terms input for this Choreo.</param>
         public void setTerms(String value) {
             base.addInput ("Terms", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A BillResultSet containing execution metadata and results.</returns>
        new public BillResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            BillResultSet results = new JavaScriptSerializer().Deserialize<BillResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Bill Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class BillResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from GovTrack.</returns>
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
