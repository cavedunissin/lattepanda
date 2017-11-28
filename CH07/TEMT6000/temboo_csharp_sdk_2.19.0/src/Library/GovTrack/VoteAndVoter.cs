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
    /// VoteAndVoter
    /// Retrieves how people voted on roll call votes in the U.S. Congress since 1789. 
    /// </summary>
    public class VoteAndVoter : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the VoteAndVoter Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public VoteAndVoter(TembooSession session) : base(session, "/Library/GovTrack/VoteAndVoter")
        {
        }

         /// <summary>
         /// (optional, string) The date (and in recent history also the time) on which the vote was held (in YYYY-MM-DD format). Filter operators allowed. Sortable.
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
         /// (optional, integer) The ID of the resource to retrieve. When using this input, all other filter parameters are ignored, and a single record is returned.
         /// </summary>
         /// <param name="value">Value of the ObjectID input for this Choreo.</param>
         public void setObjectID(String value) {
             base.addInput ("ObjectID", value);
         }
         /// <summary>
         /// (optional, integer) Offset the results by the number given, useful for paging through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) The way a particular person voted. The value corresponds to the key of an option returned on the Vote Choreo. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Option input for this Choreo.</param>
         public void setOption(String value) {
             base.addInput ("Option", value);
         }
         /// <summary>
         /// (optional, string) The person making this vote. This is an ID number. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Person input for this Choreo.</param>
         public void setPerson(String value) {
             base.addInput ("Person", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) You can order the results by date using fieldname (ascending) or -fieldname (descending), where "fieldname" is either startdate or enddate.
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (optional, string) The ID number of the vote that this was part of. This is in the form of an ID number. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Vote input for this Choreo.</param>
         public void setVote(String value) {
             base.addInput ("Vote", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A VoteAndVoterResultSet containing execution metadata and results.</returns>
        new public VoteAndVoterResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            VoteAndVoterResultSet results = new JavaScriptSerializer().Deserialize<VoteAndVoterResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the VoteAndVoter Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class VoteAndVoterResultSet : Temboo.Core.ResultSet
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
