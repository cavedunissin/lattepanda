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
    /// Vote
    /// Returns roll call votes in the U.S. Congress since 1789.
    /// </summary>
    public class Vote : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Vote Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Vote(TembooSession session) : base(session, "/Library/GovTrack/Vote")
        {
        }

         /// <summary>
         /// (optional, string) The chamber in which the vote was held. Valid values are: house or senate. Filter operators allowed but only when filtering by Congress as well. Sortable.
         /// </summary>
         /// <param name="value">Value of the Chamber input for this Choreo.</param>
         public void setChamber(String value) {
             base.addInput ("Chamber", value);
         }
         /// <summary>
         /// (optional, string) The number of the congress in which the vote took place. The current congress is 113. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Congress input for this Choreo.</param>
         public void setCongress(String value) {
             base.addInput ("Congress", value);
         }
         /// <summary>
         /// (optional, string) The date (and in recent history also the time) on which the vote was held. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Created input for this Choreo.</param>
         public void setCreated(String value) {
             base.addInput ("Created", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of fields to return in the response. Use double-underscores to span relationships (e.g. person__firstname).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, integer) Results are paged 100 per call by default. Set the limit input to a high value to get all of the results at once.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The number of the vote, unique to a Congress and session pair. Filter operators allowed. Sortable.
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
         /// (optional, string) The ID of a related amendment. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the RelatedAmendment input for this Choreo.</param>
         public void setRelatedAmendment(String value) {
             base.addInput ("RelatedAmendment", value);
         }
         /// <summary>
         /// (optional, string) A bill related to this vote. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the RelatedBill input for this Choreo.</param>
         public void setRelatedBill(String value) {
             base.addInput ("RelatedBill", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The session of congress. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Session input for this Choreo.</param>
         public void setSession(String value) {
             base.addInput ("Session", value);
         }
         /// <summary>
         /// (optional, string) You can order the results using created (ascending) or -created (descending) for the dates that each vote was held.
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (optional, integer) The ID of a vote object to retrieve. When using this input, all other filter parameters are ignored, and a single record is returned.
         /// </summary>
         /// <param name="value">Value of the VoteID input for this Choreo.</param>
         public void setVoteID(String value) {
             base.addInput ("VoteID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A VoteResultSet containing execution metadata and results.</returns>
        new public VoteResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            VoteResultSet results = new JavaScriptSerializer().Deserialize<VoteResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Vote Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class VoteResultSet : Temboo.Core.ResultSet
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
