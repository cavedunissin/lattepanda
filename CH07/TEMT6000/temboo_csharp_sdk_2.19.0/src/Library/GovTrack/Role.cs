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
    /// Role
    /// Returns terms held in office by Members of Congress and U.S. Presidents.
    /// </summary>
    public class Role : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Role Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Role(TembooSession session) : base(session, "/Library/GovTrack/Role")
        {
        }

         /// <summary>
         /// (optional, string) Whether the role is currently held, or it is archival information. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Current input for this Choreo.</param>
         public void setCurrent(String value) {
             base.addInput ("Current", value);
         }
         /// <summary>
         /// (optional, string) For representatives, the number of their congressional district. 0 for at-large districts, -1 in historical data if the district is not known. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the District input for this Choreo.</param>
         public void setDistrict(String value) {
             base.addInput ("District", value);
         }
         /// <summary>
         /// (optional, string) The date the role ended - when the person resigned, died, etc. (in YYYY-MM-DD format). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
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
         /// (optional, integer) Offset the results by the number given, useful for paging through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) The political party of the person. If the person changes party, it is usually the most recent party during this role. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Party input for this Choreo.</param>
         public void setParty(String value) {
             base.addInput ("Party", value);
         }
         /// <summary>
         /// (optional, string) The person associated with this role. When using this filter, provide the id of the person which is returned when requesting a single role object.
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
         /// (optional, string) Specify the ID number of a role object to retrieve the record for only that role. When using this input, all other filter parameters are ignored, and a single record is returned.
         /// </summary>
         /// <param name="value">Value of the RoleID input for this Choreo.</param>
         public void setRoleID(String value) {
             base.addInput ("RoleID", value);
         }
         /// <summary>
         /// (optional, string) The type of role (e.g. senator, representative, or president). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the RoleType input for this Choreo.</param>
         public void setRoleType(String value) {
             base.addInput ("RoleType", value);
         }
         /// <summary>
         /// (optional, integer) For senators, their election class, which determines which years they are up for election. Acceptable values: class1, class2, class3. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the SenatorClass input for this Choreo.</param>
         public void setSenatorClass(String value) {
             base.addInput ("SenatorClass", value);
         }
         /// <summary>
         /// (optional, string) You can order the results by date using fieldname (ascending) or -fieldname (descending), where "fieldname" is either startdate or enddate.
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (optional, string) The date the role began  - when the person took office (in YYYY-MM-DD format). Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, string) For senators and representatives, the two-letter USPS abbreviation for the state or territory they are serving. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RoleResultSet containing execution metadata and results.</returns>
        new public RoleResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RoleResultSet results = new JavaScriptSerializer().Deserialize<RoleResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Role Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RoleResultSet : Temboo.Core.ResultSet
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
