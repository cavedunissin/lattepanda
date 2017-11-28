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

namespace Temboo.Library.Google.Gmailv2.Messages
{
    /// <summary>
    /// GetLatestMessage
    /// Retrieves the latest email from a user's inbox.
    /// </summary>
    public class GetLatestMessage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLatestMessage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLatestMessage(TembooSession session) : base(session, "/Library/Google/Gmailv2/Messages/GetLatestMessage")
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
         /// (optional, boolean) When set to "true" (the default), the message Body will be Base64 encoded.
         /// </summary>
         /// <param name="value">Value of the EncodeMessage input for this Choreo.</param>
         public void setEncodeMessage(String value) {
             base.addInput ("EncodeMessage", value);
         }
         /// <summary>
         /// (optional, boolean) Set to "true" to include messages from SPAM and TRASH in the results. Defaults to "false".
         /// </summary>
         /// <param name="value">Value of the IncludeSpamTrash input for this Choreo.</param>
         public void setIncludeSpamTrash(String value) {
             base.addInput ("IncludeSpamTrash", value);
         }
         /// <summary>
         /// (optional, string) Returns messages with a label matching this ID.
         /// </summary>
         /// <param name="value">Value of the LabelID input for this Choreo.</param>
         public void setLabelID(String value) {
             base.addInput ("LabelID", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new Access Token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) Returns history records after the specified marker. The history ID is returned by this Choreo after retrieving a message.
         /// </summary>
         /// <param name="value">Value of the StartHistoryID input for this Choreo.</param>
         public void setStartHistoryID(String value) {
             base.addInput ("StartHistoryID", value);
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
        /// <returns>A GetLatestMessageResultSet containing execution metadata and results.</returns>
        new public GetLatestMessageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLatestMessageResultSet results = new JavaScriptSerializer().Deserialize<GetLatestMessageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLatestMessage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLatestMessageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Body" output from this Choreo execution
        /// <returns>String - (string) The message body.</returns>
        /// </summary>
        public String Body
        {
            get
            {
                return (String) base.Output["Body"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "From" output from this Choreo execution
        /// <returns>String - (string) The sender address.</returns>
        /// </summary>
        public String From
        {
            get
            {
                return (String) base.Output["From"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "HistoryID" output from this Choreo execution
        /// <returns>String - (string) The history ID. This can be passed to the StartHistoryID input to retrieve only mail received after this marker.</returns>
        /// </summary>
        public String HistoryID
        {
            get
            {
                return (String) base.Output["HistoryID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "MessageID" output from this Choreo execution
        /// <returns>String - (string) The ID of the message.</returns>
        /// </summary>
        public String MessageID
        {
            get
            {
                return (String) base.Output["MessageID"];
            }
        }
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
        /// Retrieve the value for the "Snippet" output from this Choreo execution
        /// <returns>String - (string) The email body snippet.</returns>
        /// </summary>
        public String Snippet
        {
            get
            {
                return (String) base.Output["Snippet"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Subject" output from this Choreo execution
        /// <returns>String - (string) The message subject.</returns>
        /// </summary>
        public String Subject
        {
            get
            {
                return (String) base.Output["Subject"];
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
