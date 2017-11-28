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

namespace Temboo.Library.Kiva.Teams
{
    /// <summary>
    /// GetTeamLenders
    /// Returns a list of public lenders belonging to a specific team.
    /// </summary>
    public class GetTeamLenders : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTeamLenders Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTeamLenders(TembooSession session) : base(session, "/Library/Kiva/Teams/GetTeamLenders")
        {
        }

         /// <summary>
         /// (optional, string) Your unique application ID, usually in reverse DNS notation.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (optional, integer) The page position of results to return. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, string) Output returned can be XML or JSON. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, string) The order by which to sort results: oldest  or newest. Defaults to newest.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (required, string) The TeamID for which to return lenders.
         /// </summary>
         /// <param name="value">Value of the TeamID input for this Choreo.</param>
         public void setTeamID(String value) {
             base.addInput ("TeamID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTeamLendersResultSet containing execution metadata and results.</returns>
        new public GetTeamLendersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTeamLendersResultSet results = new JavaScriptSerializer().Deserialize<GetTeamLendersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTeamLenders Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTeamLendersResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Kiva.</returns>
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
