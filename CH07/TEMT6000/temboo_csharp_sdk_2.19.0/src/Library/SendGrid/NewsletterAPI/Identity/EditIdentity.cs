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

namespace Temboo.Library.SendGrid.NewsletterAPI.Identity
{
    /// <summary>
    /// EditIdentity
    /// Edit a newsletter identity.
    /// </summary>
    public class EditIdentity : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the EditIdentity Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public EditIdentity(TembooSession session) : base(session, "/Library/SendGrid/NewsletterAPI/Identity/EditIdentity")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The username registered with SendGrid. 
         /// </summary>
         /// <param name="value">Value of the APIUser input for this Choreo.</param>
         public void setAPIUser(String value) {
             base.addInput ("APIUser", value);
         }
         /// <summary>
         /// (required, string) The new physical address to be used for this Identity.
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (required, string) The new city for this Identity.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (required, string) The new country to be associated with this Identity.
         /// </summary>
         /// <param name="value">Value of the Country input for this Choreo.</param>
         public void setCountry(String value) {
             base.addInput ("Country", value);
         }
         /// <summary>
         /// (required, string) An email address to be used for this identity.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (required, string) The identity that is to be edited.
         /// </summary>
         /// <param name="value">Value of the Identity input for this Choreo.</param>
         public void setIdentity(String value) {
             base.addInput ("Identity", value);
         }
         /// <summary>
         /// (required, string) The new name to be associated with this identity.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) The new name for this identity.
         /// </summary>
         /// <param name="value">Value of the NewIdentity input for this Choreo.</param>
         public void setNewIdentity(String value) {
             base.addInput ("NewIdentity", value);
         }
         /// <summary>
         /// (required, string) An email address to be used in the Reply-To field.
         /// </summary>
         /// <param name="value">Value of the ReplyTo input for this Choreo.</param>
         public void setReplyTo(String value) {
             base.addInput ("ReplyTo", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from SendGrid: Soecify json, or xml.  Default is set to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The state to be associated with this Identity.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (required, integer) The new zip code associated with this Identity.
         /// </summary>
         /// <param name="value">Value of the Zip input for this Choreo.</param>
         public void setZip(String value) {
             base.addInput ("Zip", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A EditIdentityResultSet containing execution metadata and results.</returns>
        new public EditIdentityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            EditIdentityResultSet results = new JavaScriptSerializer().Deserialize<EditIdentityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the EditIdentity Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class EditIdentityResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from SendGrid. The format corresponds to the ResponseFormat input. Default is json.</returns>
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
