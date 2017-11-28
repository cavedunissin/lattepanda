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

namespace Temboo.Library.Zendesk.Tickets
{
    /// <summary>
    /// CreateTicketNewRequester
    /// Creates a new ticket as well as a new requester account.
    /// </summary>
    public class CreateTicketNewRequester : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateTicketNewRequester Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateTicketNewRequester(TembooSession session) : base(session, "/Library/Zendesk/Tickets/CreateTicketNewRequester")
        {
        }

         /// <summary>
         /// (required, string) The comment for the ticket that is being created.
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
         /// (required, integer) LocaleID for the new requester. Indicate 1 for English, 8 for Deutsch, etc.
         /// </summary>
         /// <param name="value">Value of the LocaleID input for this Choreo.</param>
         public void setLocaleID(String value) {
             base.addInput ("LocaleID", value);
         }
         /// <summary>
         /// (required, string) Name of new requester.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (required, password) Your Zendesk password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) Email of new requester.
         /// </summary>
         /// <param name="value">Value of the RequesterEmail input for this Choreo.</param>
         public void setRequesterEmail(String value) {
             base.addInput ("RequesterEmail", value);
         }
         /// <summary>
         /// (required, string) Your Zendesk domain and subdomain (e.g., temboocare.zendesk.com).
         /// </summary>
         /// <param name="value">Value of the Server input for this Choreo.</param>
         public void setServer(String value) {
             base.addInput ("Server", value);
         }
         /// <summary>
         /// (required, string) The subject for the ticket that is being created.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }
         /// <summary>
         /// (optional, string) The token associated with an upload to attach to this ticket. Note that tokens can be retrieved by running the UploadFile Choreo.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateTicketNewRequesterResultSet containing execution metadata and results.</returns>
        new public CreateTicketNewRequesterResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateTicketNewRequesterResultSet results = new JavaScriptSerializer().Deserialize<CreateTicketNewRequesterResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateTicketNewRequester Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateTicketNewRequesterResultSet : Temboo.Core.ResultSet
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
