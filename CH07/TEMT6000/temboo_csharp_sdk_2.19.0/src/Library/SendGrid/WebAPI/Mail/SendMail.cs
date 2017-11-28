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

namespace Temboo.Library.SendGrid.WebAPI.Mail
{
    /// <summary>
    /// SendMail
    /// Allows you to send emails.
    /// </summary>
    public class SendMail : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SendMail Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SendMail(TembooSession session) : base(session, "/Library/SendGrid/WebAPI/Mail/SendMail")
        {
        }

         /// <summary>
         /// (optional, string) The Base64-encoded contents of the file you want to attach.
         /// </summary>
         /// <param name="value">Value of the FileContents input for this Choreo.</param>
         public void setFileContents(String value) {
             base.addInput ("FileContents", value);
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
         /// (optional, string) Enter a BCC recipient.  Multiple recipients can also be passed in as an array of email addresses.
         /// </summary>
         /// <param name="value">Value of the BCC input for this Choreo.</param>
         public void setBCC(String value) {
             base.addInput ("BCC", value);
         }
         /// <summary>
         /// (optional, string) The timestamp of the Block records. Enter 1 to return a date in a MySQL timestamp format - YYYY-MM-DD HH:MM:SS
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, string) The name of the file you are attaching to your email.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (required, string) The originating email address.  Must be from your domain.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (optional, string) The name to be appended to the from email.  For example, your company name, or your name.
         /// </summary>
         /// <param name="value">Value of the FromName input for this Choreo.</param>
         public void setFromName(String value) {
             base.addInput ("FromName", value);
         }
         /// <summary>
         /// (conditional, string) The HTML to be used in the body of your email message. Required unless specifying a plain text body in the Text input.
         /// </summary>
         /// <param name="value">Value of the HTML input for this Choreo.</param>
         public void setHTML(String value) {
             base.addInput ("HTML", value);
         }
         /// <summary>
         /// (optional, json) The collection of key/value pairs in JSON format. Each key represents a header name and the value the header value. For example: {"X-Accept-Language": "en", "X-Mailer": "MyApp"}
         /// </summary>
         /// <param name="value">Value of the Headers input for this Choreo.</param>
         public void setHeaders(String value) {
             base.addInput ("Headers", value);
         }
         /// <summary>
         /// (optional, string) The email address to append to the reply-to field of your email.
         /// </summary>
         /// <param name="value">Value of the ReplyTo input for this Choreo.</param>
         public void setReplyTo(String value) {
             base.addInput ("ReplyTo", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from SendGrid, in either json, or xml.  Default is set to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The subject of the email message.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }
         /// <summary>
         /// (conditional, string) The text of the email message. Required unless providing the message body using the HTML input.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }
         /// <summary>
         /// (required, string) The valid recipient email address.  Multiple addresses can be entered as elements of an array.
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }
         /// <summary>
         /// (optional, string) The name of the email recipient.
         /// </summary>
         /// <param name="value">Value of the ToName input for this Choreo.</param>
         public void setToName(String value) {
             base.addInput ("ToName", value);
         }
         /// <summary>
         /// (optional, json) Must be valid JSON format.  See here for additional info: http://docs.sendgrid.com/documentation/api/smtp-api/
         /// </summary>
         /// <param name="value">Value of the XSMTPAPI input for this Choreo.</param>
         public void setXSMTPAPI(String value) {
             base.addInput ("XSMTPAPI", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SendMailResultSet containing execution metadata and results.</returns>
        new public SendMailResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SendMailResultSet results = new JavaScriptSerializer().Deserialize<SendMailResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SendMail Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SendMailResultSet : Temboo.Core.ResultSet
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
