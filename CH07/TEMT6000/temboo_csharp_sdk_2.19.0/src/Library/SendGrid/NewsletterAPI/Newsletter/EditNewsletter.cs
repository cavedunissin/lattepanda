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

namespace Temboo.Library.SendGrid.NewsletterAPI.Newsletter
{
    /// <summary>
    /// EditNewsletter
    /// Edit an existing newsletter.
    /// </summary>
    public class EditNewsletter : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the EditNewsletter Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public EditNewsletter(TembooSession session) : base(session, "/Library/SendGrid/NewsletterAPI/Newsletter/EditNewsletter")
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
         /// (required, string) The html portion of the newsletter.
         /// </summary>
         /// <param name="value">Value of the HTML input for this Choreo.</param>
         public void setHTML(String value) {
             base.addInput ("HTML", value);
         }
         /// <summary>
         /// (required, string) The new identity Identiy for the newsletter that is being edited.
         /// </summary>
         /// <param name="value">Value of the Identity input for this Choreo.</param>
         public void setIdentity(String value) {
             base.addInput ("Identity", value);
         }
         /// <summary>
         /// (required, string) The name of the newsletter that is being edited.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (required, string) The new name of the newsletter that is being edited.
         /// </summary>
         /// <param name="value">Value of the NewName input for this Choreo.</param>
         public void setNewName(String value) {
             base.addInput ("NewName", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from SendGrid, in either json, or xml.  Default is set to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The new subject for the edited newsletter.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }
         /// <summary>
         /// (required, string) The text portion of the newsletter.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A EditNewsletterResultSet containing execution metadata and results.</returns>
        new public EditNewsletterResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            EditNewsletterResultSet results = new JavaScriptSerializer().Deserialize<EditNewsletterResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the EditNewsletter Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class EditNewsletterResultSet : Temboo.Core.ResultSet
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
