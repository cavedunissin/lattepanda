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
    /// GetTeamByShortname
    /// Returns detailed information about one or more teams, using team shortnames.
    /// </summary>
    public class GetTeamByShortname : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTeamByShortname Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTeamByShortname(TembooSession session) : base(session, "/Library/Kiva/Teams/GetTeamByShortname")
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
         /// (optional, string) Output returned can be XML or JSON. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (required, string) The Team shortname for which to return details.
         /// </summary>
         /// <param name="value">Value of the TeamShortname input for this Choreo.</param>
         public void setTeamShortname(String value) {
             base.addInput ("TeamShortname", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTeamByShortnameResultSet containing execution metadata and results.</returns>
        new public GetTeamByShortnameResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTeamByShortnameResultSet results = new JavaScriptSerializer().Deserialize<GetTeamByShortnameResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTeamByShortname Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTeamByShortnameResultSet : Temboo.Core.ResultSet
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
