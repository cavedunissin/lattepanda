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

namespace Temboo.Library.LittleSis.Entity
{
    /// <summary>
    /// GetLeadershipByOrganization
    /// Retrieves a list of board members and executives for a given organization.
    /// </summary>
    public class GetLeadershipByOrganization : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLeadershipByOrganization Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLeadershipByOrganization(TembooSession session) : base(session, "/Library/LittleSis/Entity/GetLeadershipByOrganization")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from LittleSis.org.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, integer) Set to 1 to limit the relationships returned to only past relationships. Set to 0 to limit relationships returned to only current relationships. Defaults to all.
         /// </summary>
         /// <param name="value">Value of the Current input for this Choreo.</param>
         public void setCurrent(String value) {
             base.addInput ("Current", value);
         }
         /// <summary>
         /// (required, integer) The ID of the organization.
         /// </summary>
         /// <param name="value">Value of the EntityID input for this Choreo.</param>
         public void setEntityID(String value) {
             base.addInput ("EntityID", value);
         }
         /// <summary>
         /// (optional, string) Format of the response returned by LittleSis.org. Acceptable inputs: xml or json. Defaults to xml
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLeadershipByOrganizationResultSet containing execution metadata and results.</returns>
        new public GetLeadershipByOrganizationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLeadershipByOrganizationResultSet results = new JavaScriptSerializer().Deserialize<GetLeadershipByOrganizationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLeadershipByOrganization Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLeadershipByOrganizationResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from LittleSis.org.</returns>
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
