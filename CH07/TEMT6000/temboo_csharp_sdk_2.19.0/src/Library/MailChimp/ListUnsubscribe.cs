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

namespace Temboo.Library.MailChimp
{
    /// <summary>
    /// ListUnsubscribe
    /// Remove a subscriber from a MailChimp list.
    /// </summary>
    public class ListUnsubscribe : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListUnsubscribe Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListUnsubscribe(TembooSession session) : base(session, "/Library/MailChimp/ListUnsubscribe")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Mailchimp.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, boolean) A flag used to completely delete the member from your list instead of just unsubscribing. Specify '1' (true) or '0' (false). Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the DeleteMember input for this Choreo.</param>
         public void setDeleteMember(String value) {
             base.addInput ("DeleteMember", value);
         }
         /// <summary>
         /// (required, string) The email address to unsubscribe.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (required, string) The id of the list that contains the email address you want to unsubscribe.
         /// </summary>
         /// <param name="value">Value of the ListId input for this Choreo.</param>
         public void setListId(String value) {
             base.addInput ("ListId", value);
         }
         /// <summary>
         /// (optional, boolean) A flag used to send the goodbye email to the email address. Specify '1' (true) or '0' (false). Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the SendGoodbye input for this Choreo.</param>
         public void setSendGoodbye(String value) {
             base.addInput ("SendGoodbye", value);
         }
         /// <summary>
         /// (optional, boolean) A flag used to send the unsubscribe notification email to the address defined in the list email notification settings. Specify '1' (true) or '0' (false). Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the SendNotify input for this Choreo.</param>
         public void setSendNotify(String value) {
             base.addInput ("SendNotify", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListUnsubscribeResultSet containing execution metadata and results.</returns>
        new public ListUnsubscribeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListUnsubscribeResultSet results = new JavaScriptSerializer().Deserialize<ListUnsubscribeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListUnsubscribe Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListUnsubscribeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Mailchimp. Returns the string "true" for success and an error description for failures.</returns>
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
