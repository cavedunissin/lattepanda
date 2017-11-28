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

namespace Temboo.Library.Zendesk.Requests
{
    /// <summary>
    /// UpdateRequest
    /// Updates an existing request.
    /// </summary>
    public class UpdateRequest : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateRequest Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateRequest(TembooSession session) : base(session, "/Library/Zendesk/Requests/UpdateRequest")
        {
        }

         /// <summary>
         /// (optional, json) A JSON-formatted string containing the request properties you wish to set. This can be used as an alternative to setting individual inputs representing request properties.
         /// </summary>
         /// <param name="value">Value of the RequestData input for this Choreo.</param>
         public void setRequestData(String value) {
             base.addInput ("RequestData", value);
         }
         /// <summary>
         /// (conditional, string) A comment associated with the request.
         /// </summary>
         /// <param name="value">Value of the Comment input for this Choreo.</param>
         public void setComment(String value) {
             base.addInput ("Comment", value);
         }
         /// <summary>
         /// (required, string) The email address you use to login to your Zendesk account.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the request to update.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (required, password) Your Zendesk password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (conditional, string) Priority (e.g. low, normal, high, urgent). Defaults to normal.
         /// </summary>
         /// <param name="value">Value of the Priority input for this Choreo.</param>
         public void setPriority(String value) {
             base.addInput ("Priority", value);
         }
         /// <summary>
         /// (required, string) Your Zendesk domain and subdomain (e.g., temboocare.zendesk.com).
         /// </summary>
         /// <param name="value">Value of the Server input for this Choreo.</param>
         public void setServer(String value) {
             base.addInput ("Server", value);
         }
         /// <summary>
         /// (conditional, string) The subject of the request.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }
         /// <summary>
         /// (conditional, string) Type of request (e.g.question, incident, problem, task). Defaults to incident.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateRequestResultSet containing execution metadata and results.</returns>
        new public UpdateRequestResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateRequestResultSet results = new JavaScriptSerializer().Deserialize<UpdateRequestResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateRequest Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateRequestResultSet : Temboo.Core.ResultSet
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
