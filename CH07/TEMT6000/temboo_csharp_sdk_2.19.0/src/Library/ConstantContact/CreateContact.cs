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

namespace Temboo.Library.ConstantContact
{
    /// <summary>
    /// CreateContact
    /// Creates a contact in your Constant Contact account.
    /// </summary>
    public class CreateContact : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateContact Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateContact(TembooSession session) : base(session, "/Library/ConstantContact/CreateContact")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Constant Contact.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The first line of the contact's address.
         /// </summary>
         /// <param name="value">Value of the Addr1 input for this Choreo.</param>
         public void setAddr1(String value) {
             base.addInput ("Addr1", value);
         }
         /// <summary>
         /// (optional, string) The second line of the contact's address.
         /// </summary>
         /// <param name="value">Value of the Addr2 input for this Choreo.</param>
         public void setAddr2(String value) {
             base.addInput ("Addr2", value);
         }
         /// <summary>
         /// (optional, string) The third line of the contact's address.
         /// </summary>
         /// <param name="value">Value of the Addr3 input for this Choreo.</param>
         public void setAddr3(String value) {
             base.addInput ("Addr3", value);
         }
         /// <summary>
         /// (optional, string) The city portion of the contact's address.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (optional, string) The company name for the contact.
         /// </summary>
         /// <param name="value">Value of the CompanyName input for this Choreo.</param>
         public void setCompanyName(String value) {
             base.addInput ("CompanyName", value);
         }
         /// <summary>
         /// (optional, string) The country code associated with the contact's address.
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the Country Name field in Constant Contact
         /// </summary>
         /// <param name="value">Value of the CountryName input for this Choreo.</param>
         public void setCountryName(String value) {
             base.addInput ("CountryName", value);
         }
         /// <summary>
         /// (required, string) The email address for the contact.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (optional, string) The email type that the contact should receive.
         /// </summary>
         /// <param name="value">Value of the EmailType input for this Choreo.</param>
         public void setEmailType(String value) {
             base.addInput ("EmailType", value);
         }
         /// <summary>
         /// (optional, string) The first name of the contact.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
         }
         /// <summary>
         /// (optional, string) The contact's home phone.
         /// </summary>
         /// <param name="value">Value of the HomePhone input for this Choreo.</param>
         public void setHomePhone(String value) {
             base.addInput ("HomePhone", value);
         }
         /// <summary>
         /// (optional, string) The contact's job title.
         /// </summary>
         /// <param name="value">Value of the JobTitle input for this Choreo.</param>
         public void setJobTitle(String value) {
             base.addInput ("JobTitle", value);
         }
         /// <summary>
         /// (optional, string) The last name of the contact.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (required, integer) The ID for the list that you want to add the contact to.
         /// </summary>
         /// <param name="value">Value of the ListId input for this Choreo.</param>
         public void setListId(String value) {
             base.addInput ("ListId", value);
         }
         /// <summary>
         /// (optional, string) The middle name of the contact.
         /// </summary>
         /// <param name="value">Value of the MiddleName input for this Choreo.</param>
         public void setMiddleName(String value) {
             base.addInput ("MiddleName", value);
         }
         /// <summary>
         /// (optional, string) The full name of the contact.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) A note associated with the contact.
         /// </summary>
         /// <param name="value">Value of the Note input for this Choreo.</param>
         public void setNote(String value) {
             base.addInput ("Note", value);
         }
         /// <summary>
         /// (required, password) Your Constant Contact password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) The postal code for the contact's address.
         /// </summary>
         /// <param name="value">Value of the PostalCode input for this Choreo.</param>
         public void setPostalCode(String value) {
             base.addInput ("PostalCode", value);
         }
         /// <summary>
         /// (optional, string) The state code for the contact's address.
         /// </summary>
         /// <param name="value">Value of the StateCode input for this Choreo.</param>
         public void setStateCode(String value) {
             base.addInput ("StateCode", value);
         }
         /// <summary>
         /// (optional, string) Corresponds to the State Name field in Constant Contact
         /// </summary>
         /// <param name="value">Value of the StateName input for this Choreo.</param>
         public void setStateName(String value) {
             base.addInput ("StateName", value);
         }
         /// <summary>
         /// (optional, string) The status of the contact (i.e. Active).
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }
         /// <summary>
         /// (optional, string) The sub postal code for the contact.
         /// </summary>
         /// <param name="value">Value of the SubPostalCode input for this Choreo.</param>
         public void setSubPostalCode(String value) {
             base.addInput ("SubPostalCode", value);
         }
         /// <summary>
         /// (required, string) Your Constant Contact username.
         /// </summary>
         /// <param name="value">Value of the UserName input for this Choreo.</param>
         public void setUserName(String value) {
             base.addInput ("UserName", value);
         }
         /// <summary>
         /// (optional, string) The contact's work phone.
         /// </summary>
         /// <param name="value">Value of the WorkPhone input for this Choreo.</param>
         public void setWorkPhone(String value) {
             base.addInput ("WorkPhone", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateContactResultSet containing execution metadata and results.</returns>
        new public CreateContactResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateContactResultSet results = new JavaScriptSerializer().Deserialize<CreateContactResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateContact Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateContactResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Constant Contact.</returns>
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
