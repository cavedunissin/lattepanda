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

namespace Temboo.Library.Zendesk.Organizations
{
    /// <summary>
    /// UpdateOrganization
    /// Update an existing organization.
    /// </summary>
    public class UpdateOrganization : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateOrganization Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateOrganization(TembooSession session) : base(session, "/Library/Zendesk/Organizations/UpdateOrganization")
        {
        }

         /// <summary>
         /// (optional, json) A JSON-formatted string containing the organization properties you wish to set. This can used when you need to set multiple properties.
         /// </summary>
         /// <param name="value">Value of the OrganizationData input for this Choreo.</param>
         public void setOrganizationData(String value) {
             base.addInput ("OrganizationData", value);
         }
         /// <summary>
         /// (required, string) The email address you use to login to your Zendesk account.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (required, string) ID of the organization to update.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (conditional, string) Notes on the organization.
         /// </summary>
         /// <param name="value">Value of the Notes input for this Choreo.</param>
         public void setNotes(String value) {
             base.addInput ("Notes", value);
         }
         /// <summary>
         /// (required, password) Your Zendesk password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) Your Zendesk domain and subdomain (e.g., temboocare.zendesk.com).
         /// </summary>
         /// <param name="value">Value of the Server input for this Choreo.</param>
         public void setServer(String value) {
             base.addInput ("Server", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateOrganizationResultSet containing execution metadata and results.</returns>
        new public UpdateOrganizationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateOrganizationResultSet results = new JavaScriptSerializer().Deserialize<UpdateOrganizationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateOrganization Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateOrganizationResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Zendesk.</returns>
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
