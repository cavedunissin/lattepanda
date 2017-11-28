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
    /// Committee
    /// Returns committees and subcommittees in the United States Congress, including historical committees.
    /// </summary>
    public class Committee : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Committee Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Committee(TembooSession session) : base(session, "/Library/GovTrack/Committee")
        {
        }

         /// <summary>
         /// (optional, string) Indicates if the object is a committee or a subcommittee. To filter for committees, you can pass "null". For subcommittees, pass the ID of the parent. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Committee input for this Choreo.</param>
         public void setCommittee(String value) {
             base.addInput ("Committee", value);
         }
         /// <summary>
         /// (optional, integer) The id of the committee resource. When using this input, all other filter parameters are ignored, and a single record is returned.
         /// </summary>
         /// <param name="value">Value of the CommitteeID input for this Choreo.</param>
         public void setCommitteeID(String value) {
             base.addInput ("CommitteeID", value);
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
         /// (optional, string) Whether or not the committee still exists. Set to "true" to return committees that are obsolete. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Obsolete input for this Choreo.</param>
         public void setObsolete(String value) {
             base.addInput ("Obsolete", value);
         }
         /// <summary>
         /// (optional, integer) Offset the results by the number given, useful for paging through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) You can order the results using fieldname (ascending) or -fieldname (descending) where "fieldname" is one of the variables that is listed as 'Sortable' in the description. Ex: '-lastname'
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CommitteeResultSet containing execution metadata and results.</returns>
        new public CommitteeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CommitteeResultSet results = new JavaScriptSerializer().Deserialize<CommitteeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Committee Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CommitteeResultSet : Temboo.Core.ResultSet
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
