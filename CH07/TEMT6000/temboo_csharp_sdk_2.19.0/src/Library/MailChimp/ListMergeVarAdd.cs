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
    /// ListMergeVarAdd
    /// Add a new field to a MailChimp list.
    /// </summary>
    public class ListMergeVarAdd : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListMergeVarAdd Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListMergeVarAdd(TembooSession session) : base(session, "/Library/MailChimp/ListMergeVarAdd")
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
         /// (optional, string) A list of up to 10 choices for radio and dropdown type fields )separated by commas).
         /// </summary>
         /// <param name="value">Value of the Choices input for this Choreo.</param>
         public void setChoices(String value) {
             base.addInput ("Choices", value);
         }
         /// <summary>
         /// (optional, string) Valid for birthday and date fields. For birthday, must be "MM/DD" (default) or "DD/MM". For date type, must be "MM/DD/YYYY" (default) or "DD/MM/YYYY".
         /// </summary>
         /// <param name="value">Value of the DateFormat input for this Choreo.</param>
         public void setDateFormat(String value) {
             base.addInput ("DateFormat", value);
         }
         /// <summary>
         /// (optional, string) The ISO 3166 2 digit character code for the default country. Defaults to "US".
         /// </summary>
         /// <param name="value">Value of the DefaultCountry input for this Choreo.</param>
         public void setDefaultCountry(String value) {
             base.addInput ("DefaultCountry", value);
         }
         /// <summary>
         /// (optional, string) The default value for the new field.
         /// </summary>
         /// <param name="value">Value of the DefaultValue input for this Choreo.</param>
         public void setDefaultValue(String value) {
             base.addInput ("DefaultValue", value);
         }
         /// <summary>
         /// (optional, string) Must be either left unset or one of 'text', 'number', 'radio', 'dropdown', 'date', 'address', 'phone', 'url', or 'imageurl. Defaults to text.
         /// </summary>
         /// <param name="value">Value of the FieldType input for this Choreo.</param>
         public void setFieldType(String value) {
             base.addInput ("FieldType", value);
         }
         /// <summary>
         /// (required, string) The ID of the list on which to add the new merge var.
         /// </summary>
         /// <param name="value">Value of the ListId input for this Choreo.</param>
         public void setListId(String value) {
             base.addInput ("ListId", value);
         }
         /// <summary>
         /// (required, string) Provide a long merge var name for user display (i.e. First Name)
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) Defaults to "US"  - any other value will cause them to be unformatted (international).
         /// </summary>
         /// <param name="value">Value of the PhoneFormat input for this Choreo.</param>
         public void setPhoneFormat(String value) {
             base.addInput ("PhoneFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether the field is displayed in public. Specify '1' (true) or '0' (false). Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Public input for this Choreo.</param>
         public void setPublic(String value) {
             base.addInput ("Public", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates that the field will be required.  Specify '1' (true) or '0' (false). Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Req input for this Choreo.</param>
         public void setReq(String value) {
             base.addInput ("Req", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether the field is displayed in the app's list member view.  Specify '1' (true) or '0' (false). Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Show input for this Choreo.</param>
         public void setShow(String value) {
             base.addInput ("Show", value);
         }
         /// <summary>
         /// (required, string) Provide a short merge var tag name. MUST be 10 UTF-8 chars, including 'A-Z', '0-9', or '_' only (i.e. DESC123456).
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListMergeVarAddResultSet containing execution metadata and results.</returns>
        new public ListMergeVarAddResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListMergeVarAddResultSet results = new JavaScriptSerializer().Deserialize<ListMergeVarAddResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListMergeVarAdd Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListMergeVarAddResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (boolean) The response from Mailchimp. Returns the string "true" for success and an error description for failures.</returns>
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
