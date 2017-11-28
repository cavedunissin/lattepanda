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
    /// ListBatchSubscribe
    /// Adds or updates multiple Mailchimp list subscribers.
    /// </summary>
    public class ListBatchSubscribe : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListBatchSubscribe Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListBatchSubscribe(TembooSession session) : base(session, "/Library/MailChimp/ListBatchSubscribe")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Mailchimp
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, boolean) Flag to control whether a double opt-in confirmation message is sent. Specify '1' (true) or '0' (false). Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the DoubleOptIn input for this Choreo.</param>
         public void setDoubleOptIn(String value) {
             base.addInput ("DoubleOptIn", value);
         }
         /// <summary>
         /// (optional, string) Must be one of 'text', 'html', or 'mobile'. Defaults to html.
         /// </summary>
         /// <param name="value">Value of the EmailType input for this Choreo.</param>
         public void setEmailType(String value) {
             base.addInput ("EmailType", value);
         }
         /// <summary>
         /// (required, string) The id of the Mailchimp list the subscribers will be added to.
         /// </summary>
         /// <param name="value">Value of the ListId input for this Choreo.</param>
         public void setListId(String value) {
             base.addInput ("ListId", value);
         }
         /// <summary>
         /// (optional, boolean) A flag to determine whether to replace the interest groups with the groups provided or add the provided groups to the member's interest groups. Specify '1' (true) or '0' (false). Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the ReplaceInterests input for this Choreo.</param>
         public void setReplaceInterests(String value) {
             base.addInput ("ReplaceInterests", value);
         }
         /// <summary>
         /// (optional, boolean) If double_optin is false and this flag is true, a welcome email will be sent. Note that this does not apply when updating records. Specify '1' (true) or '0' (false). Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the SendWelcome input for this Choreo.</param>
         public void setSendWelcome(String value) {
             base.addInput ("SendWelcome", value);
         }
         /// <summary>
         /// (required, json) An array of JSON objects containing the subscribers to insert. See Choreo documentation for the specific format for this JSON input.
         /// </summary>
         /// <param name="value">Value of the Subscribers input for this Choreo.</param>
         public void setSubscribers(String value) {
             base.addInput ("Subscribers", value);
         }
         /// <summary>
         /// (optional, boolean) Whether or not to suppress errors that arise from attempting to add/update a subscriber. Defaults to 0 (false). Set to 1 (true) to supress errors.
         /// </summary>
         /// <param name="value">Value of the SupressErrors input for this Choreo.</param>
         public void setSupressErrors(String value) {
             base.addInput ("SupressErrors", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates that if the email already exists, this request will perform an update instead of an insert. Specify '1' (true) or '0' (false). Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the UpdateExisting input for this Choreo.</param>
         public void setUpdateExisting(String value) {
             base.addInput ("UpdateExisting", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListBatchSubscribeResultSet containing execution metadata and results.</returns>
        new public ListBatchSubscribeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListBatchSubscribeResultSet results = new JavaScriptSerializer().Deserialize<ListBatchSubscribeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListBatchSubscribe Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListBatchSubscribeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ErrorList" output from this Choreo execution
        /// <returns>String - (json) A list of emails that were not successfully subscribed.</returns>
        /// </summary>
        public String ErrorList
        {
            get
            {
                return (String) base.Output["ErrorList"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "SuccessList" output from this Choreo execution
        /// <returns>String - (json) A list of email successfully subscribed.</returns>
        /// </summary>
        public String SuccessList
        {
            get
            {
                return (String) base.Output["SuccessList"];
            }
        }
    }
}
