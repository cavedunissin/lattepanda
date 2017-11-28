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
    /// ListUpdateMember
    /// Update information for a member of a MailChimp list.
    /// </summary>
    public class ListUpdateMember : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListUpdateMember Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListUpdateMember(TembooSession session) : base(session, "/Library/MailChimp/ListUpdateMember")
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
         /// (required, string) The current email address for the subscriber you want to update.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (optional, string) Must be one of 'text', 'html', or 'mobile'. Defaults to html.
         /// </summary>
         /// <param name="value">Value of the EmailType input for this Choreo.</param>
         public void setEmailType(String value) {
             base.addInput ("EmailType", value);
         }
         /// <summary>
         /// (required, string) The id of the list that the existing subsbriber belongs to.
         /// </summary>
         /// <param name="value">Value of the ListId input for this Choreo.</param>
         public void setListId(String value) {
             base.addInput ("ListId", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the first merge var field defined in your account.
         /// </summary>
         /// <param name="value">Value of the Merge1 input for this Choreo.</param>
         public void setMerge1(String value) {
             base.addInput ("Merge1", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the second merge var field defined in your account.
         /// </summary>
         /// <param name="value">Value of the Merge2 input for this Choreo.</param>
         public void setMerge2(String value) {
             base.addInput ("Merge2", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the third merge var field defined in your account.
         /// </summary>
         /// <param name="value">Value of the Merge3 input for this Choreo.</param>
         public void setMerge3(String value) {
             base.addInput ("Merge3", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the fourth merge var field defined in your account.
         /// </summary>
         /// <param name="value">Value of the Merge4 input for this Choreo.</param>
         public void setMerge4(String value) {
             base.addInput ("Merge4", value);
         }
         /// <summary>
         /// (optional, multiline) Set this to update the email address of a subscriber.
         /// </summary>
         /// <param name="value">Value of the NewEmail input for this Choreo.</param>
         public void setNewEmail(String value) {
             base.addInput ("NewEmail", value);
         }
         /// <summary>
         /// (optional, boolean) A flag to determine whether to replace the interest groups with the groups provided or add the provided groups to the member's interest groups. Specify '1' (true) or '0' (false). Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the ReplaceInterests input for this Choreo.</param>
         public void setReplaceInterests(String value) {
             base.addInput ("ReplaceInterests", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListUpdateMemberResultSet containing execution metadata and results.</returns>
        new public ListUpdateMemberResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListUpdateMemberResultSet results = new JavaScriptSerializer().Deserialize<ListUpdateMemberResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListUpdateMember Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListUpdateMemberResultSet : Temboo.Core.ResultSet
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
