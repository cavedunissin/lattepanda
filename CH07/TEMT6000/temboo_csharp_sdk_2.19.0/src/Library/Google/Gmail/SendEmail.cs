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

namespace Temboo.Library.Google.Gmail
{
    /// <summary>
    /// SendEmail
    /// Sends an email using a specified Gmail account.
    /// </summary>
    public class SendEmail : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SendEmail Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SendEmail(TembooSession session) : base(session, "/Library/Google/Gmail/SendEmail")
        {
        }

         /// <summary>
         /// (optional, string) The Base64 encoded contents of the file to attach to the email.  Use this instead of AttachmentURL.
         /// </summary>
         /// <param name="value">Value of the Attachment input for this Choreo.</param>
         public void setAttachment(String value) {
             base.addInput ("Attachment", value);
         }
         /// <summary>
         /// (optional, string) The name of the file to attach to the email.
         /// </summary>
         /// <param name="value">Value of the AttachmentName input for this Choreo.</param>
         public void setAttachmentName(String value) {
             base.addInput ("AttachmentName", value);
         }
         /// <summary>
         /// (optional, string) URL of a hosted file that you wish to add as an attachment.  Use this instead of a normal Attachment.
         /// </summary>
         /// <param name="value">Value of the AttachmentURL input for this Choreo.</param>
         public void setAttachmentURL(String value) {
             base.addInput ("AttachmentURL", value);
         }
         /// <summary>
         /// (optional, string) An email address to BCC on the email you're sending. Can be a comma separated list of email addresses.
         /// </summary>
         /// <param name="value">Value of the BCC input for this Choreo.</param>
         public void setBCC(String value) {
             base.addInput ("BCC", value);
         }
         /// <summary>
         /// (optional, string) An email address to CC on the email you're sending. Can be a comma separated list of email addresses.
         /// </summary>
         /// <param name="value">Value of the CC input for this Choreo.</param>
         public void setCC(String value) {
             base.addInput ("CC", value);
         }
         /// <summary>
         /// (conditional, string) The address and name (optional) that the email is being sent from e.g., "Dan" <dan@temboo.com>
         /// </summary>
         /// <param name="value">Value of the FromAddress input for this Choreo.</param>
         public void setFromAddress(String value) {
             base.addInput ("FromAddress", value);
         }
         /// <summary>
         /// (required, string) The message body for the email.
         /// </summary>
         /// <param name="value">Value of the MessageBody input for this Choreo.</param>
         public void setMessageBody(String value) {
             base.addInput ("MessageBody", value);
         }
         /// <summary>
         /// (required, password) A Google App-specific password that you've generated after enabling 2-Step Verification. See the Gmailv2 bundle for OAuth.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) The subject line of the email.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to enable TSL (port 587).
         /// </summary>
         /// <param name="value">Value of the TLS input for this Choreo.</param>
         public void setTLS(String value) {
             base.addInput ("TLS", value);
         }
         /// <summary>
         /// (required, string) The email address that you want to send an email to. Can be a comma separated list of email addresses.
         /// </summary>
         /// <param name="value">Value of the ToAddress input for this Choreo.</param>
         public void setToAddress(String value) {
             base.addInput ("ToAddress", value);
         }
         /// <summary>
         /// (required, string) Your full Google email address e.g., martha.temboo@gmail.com. See the Gmailv2 bundle for OAuth.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SendEmailResultSet containing execution metadata and results.</returns>
        new public SendEmailResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SendEmailResultSet results = new JavaScriptSerializer().Deserialize<SendEmailResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SendEmail Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SendEmailResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Success" output from this Choreo execution
        /// <returns>String - (boolean) Indicates the result of the SMTP operation. The value will be "true" for a successful request.</returns>
        /// </summary>
        public String Success
        {
            get
            {
                return (String) base.Output["Success"];
            }
        }
    }
}
