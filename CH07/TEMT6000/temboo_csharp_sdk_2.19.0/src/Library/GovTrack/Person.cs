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
    /// Person
    /// Returns members of Congress and U.S. Presidents since the founding of the nation.
    /// </summary>
    public class Person : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Person Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Person(TembooSession session) : base(session, "/Library/GovTrack/Person")
        {
        }

         /// <summary>
         /// (optional, string) A comma separated list of fields to return in the response. Use double-underscores to span relationships (e.g. person__firstname).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) The person's gender (male or female). For historical data, gender is sometimes not specified. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the Gender input for this Choreo.</param>
         public void setGender(String value) {
             base.addInput ("Gender", value);
         }
         /// <summary>
         /// (optional, string) The representative's last name. Filter operators allowed. Sortable.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
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
         /// (optional, integer) The ID number for a person to retrieve. When using this input, all other filter parameters are ignored, and a single record is returned.
         /// </summary>
         /// <param name="value">Value of the PersonID input for this Choreo.</param>
         public void setPersonID(String value) {
             base.addInput ("PersonID", value);
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
        /// <returns>A PersonResultSet containing execution metadata and results.</returns>
        new public PersonResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PersonResultSet results = new JavaScriptSerializer().Deserialize<PersonResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Person Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PersonResultSet : Temboo.Core.ResultSet
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
