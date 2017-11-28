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

namespace Temboo.Library.Google.Gmailv2.Drafts
{
    /// <summary>
    /// CreateDraft
    /// Creates a new draft with the DRAFT label.
    /// </summary>
    public class CreateDraft : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateDraft Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateDraft(TembooSession session) : base(session, "/Library/Google/Gmailv2/Drafts/CreateDraft")
        {
        }

         /// <summary>
         /// (optional, string) A valid Access Token retrieved during the OAuth2 process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new Access Token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The Content-Type of the attachment. This is required when providing AttachmentFileContent (e.g., image/jpeg, text/plain, etc).
         /// </summary>
         /// <param name="value">Value of the AttachmentContentType input for this Choreo.</param>
         public void setAttachmentContentType(String value) {
             base.addInput ("AttachmentContentType", value);
         }
         /// <summary>
         /// (optional, string) The Base64 encoded file content for the attachment. You must specify the AttachmentFileContentType when including an attachment.
         /// </summary>
         /// <param name="value">Value of the AttachmentFileContent input for this Choreo.</param>
         public void setAttachmentFileContent(String value) {
             base.addInput ("AttachmentFileContent", value);
         }
         /// <summary>
         /// (optional, string) The file name of the attachment.
         /// </summary>
         /// <param name="value">Value of the AttachmentFileName input for this Choreo.</param>
         public void setAttachmentFileName(String value) {
             base.addInput ("AttachmentFileName", value);
         }
         /// <summary>
         /// (optional, string) The address and name (optional) that should be bcc'd e.g., Dan <dan@temboo.com>.
         /// </summary>
         /// <param name="value">Value of the BCC input for this Choreo.</param>
         public void setBCC(String value) {
             base.addInput ("BCC", value);
         }
         /// <summary>
         /// (optional, string) The address and name (optional) that should be cc'd e.g., Dan <dan@temboo.com>.
         /// </summary>
         /// <param name="value">Value of the CC input for this Choreo.</param>
         public void setCC(String value) {
             base.addInput ("CC", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) Used to specify fields to include in a partial response. This can be used to reduce the amount of data returned. See Choreo notes for syntax rules.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (conditional, string) The address and name (optional) that the email is being sent from e.g., Dan <dan@temboo.com>.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (conditional, string) The text for the message body of the email.
         /// </summary>
         /// <param name="value">Value of the MessageBody input for this Choreo.</param>
         public void setMessageBody(String value) {
             base.addInput ("MessageBody", value);
         }
         /// <summary>
         /// (optional, string) The Content-Type of the message body. Defaults to "text/plain; charset=UTF-8".
         /// </summary>
         /// <param name="value">Value of the MessageBodyContentType input for this Choreo.</param>
         public void setMessageBodyContentType(String value) {
             base.addInput ("MessageBodyContentType", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new Access Token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) An email address to set as the Reply-To address.
         /// </summary>
         /// <param name="value">Value of the ReplyTo input for this Choreo.</param>
         public void setReplyTo(String value) {
             base.addInput ("ReplyTo", value);
         }
         /// <summary>
         /// (conditional, string) The email subject.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }
         /// <summary>
         /// (optional, string) The ID of the thread the message belongs to.
         /// </summary>
         /// <param name="value">Value of the ThreadID input for this Choreo.</param>
         public void setThreadID(String value) {
             base.addInput ("ThreadID", value);
         }
         /// <summary>
         /// (conditional, string) The address and name (optional) that the email is being sent to e.g., Dan <dan@temboo.com>.
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }
         /// <summary>
         /// (optional, string) The ID of the acting user. Defaults to "me" indicating the user associated with the Access Token or Refresh Token provided.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateDraftResultSet containing execution metadata and results.</returns>
        new public CreateDraftResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateDraftResultSet results = new JavaScriptSerializer().Deserialize<CreateDraftResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateDraft Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateDraftResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the RefreshToken is provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Google.</returns>
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
