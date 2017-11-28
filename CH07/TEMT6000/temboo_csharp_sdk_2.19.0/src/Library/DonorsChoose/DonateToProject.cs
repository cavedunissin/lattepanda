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

namespace Temboo.Library.DonorsChoose
{
    /// <summary>
    /// DonateToProject
    /// Makes a donation to a specified DonorsChoose.org project.
    /// </summary>
    public class DonateToProject : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DonateToProject Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DonateToProject(TembooSession session) : base(session, "/Library/DonorsChoose/DonateToProject")
        {
        }

         /// <summary>
         /// (required, string) The APIKey provided by DonorsChoose.org.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Your DonorsChoose.org API password. This is only required when performing transactions.
         /// </summary>
         /// <param name="value">Value of the APIPassword input for this Choreo.</param>
         public void setAPIPassword(String value) {
             base.addInput ("APIPassword", value);
         }
         /// <summary>
         /// (optional, string) Line one of the donor's address.
         /// </summary>
         /// <param name="value">Value of the Address1 input for this Choreo.</param>
         public void setAddress1(String value) {
             base.addInput ("Address1", value);
         }
         /// <summary>
         /// (optional, string) Line two of the donor's address.
         /// </summary>
         /// <param name="value">Value of the Address2 input for this Choreo.</param>
         public void setAddress2(String value) {
             base.addInput ("Address2", value);
         }
         /// <summary>
         /// (required, integer) The donation amount. Must be a whole number.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (optional, string) To wrap the response in a callback function, include the name in this input.
         /// </summary>
         /// <param name="value">Value of the Callback input for this Choreo.</param>
         public void setCallback(String value) {
             base.addInput ("Callback", value);
         }
         /// <summary>
         /// (optional, string) The donor's city.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (required, string) The email address of the person who is making the donation.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (optional, string) The first name of the donor.
         /// </summary>
         /// <param name="value">Value of the FirstName input for this Choreo.</param>
         public void setFirstName(String value) {
             base.addInput ("FirstName", value);
         }
         /// <summary>
         /// (optional, string) The last name of the donor.
         /// </summary>
         /// <param name="value">Value of the LastName input for this Choreo.</param>
         public void setLastName(String value) {
             base.addInput ("LastName", value);
         }
         /// <summary>
         /// (required, integer) The ID of the project that will receive the donation.
         /// </summary>
         /// <param name="value">Value of the ProposalId input for this Choreo.</param>
         public void setProposalId(String value) {
             base.addInput ("ProposalId", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Hwo the donor wants to be acknowledged on donorschoose.org.
         /// </summary>
         /// <param name="value">Value of the Salutation input for this Choreo.</param>
         public void setSalutation(String value) {
             base.addInput ("Salutation", value);
         }
         /// <summary>
         /// (optional, string) The donor's state.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (optional, string) The donor's five-digit zip code.
         /// </summary>
         /// <param name="value">Value of the Zip input for this Choreo.</param>
         public void setZip(String value) {
             base.addInput ("Zip", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DonateToProjectResultSet containing execution metadata and results.</returns>
        new public DonateToProjectResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DonateToProjectResultSet results = new JavaScriptSerializer().Deserialize<DonateToProjectResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DonateToProject Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DonateToProjectResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from DonorsChoose.org.</returns>
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
