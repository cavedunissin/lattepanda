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

namespace Temboo.Library.Nexmo.Voice
{
    /// <summary>
    /// TextToSpeech
    /// Sends a Text-to-Speech message to the specified number.
    /// </summary>
    public class TextToSpeech : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the TextToSpeech Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public TextToSpeech(TembooSession session) : base(session, "/Library/Nexmo/Voice/TextToSpeech")
        {
        }

         /// <summary>
         /// (required, string) Your API Key provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Your API Secret provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (optional, string) The HTTP method for your callback. Valid values are: GET (default) or POST.
         /// </summary>
         /// <param name="value">Value of the CallbackMethod input for this Choreo.</param>
         public void setCallbackMethod(String value) {
             base.addInput ("CallbackMethod", value);
         }
         /// <summary>
         /// (optional, string) A URL that Nexmo will request when the call ends to notify your application.
         /// </summary>
         /// <param name="value">Value of the CallbackURL input for this Choreo.</param>
         public void setCallbackURL(String value) {
             base.addInput ("CallbackURL", value);
         }
         /// <summary>
         /// (optional, integer) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the DropIfMachine input for this Choreo.</param>
         public void setDropIfMachine(String value) {
             base.addInput ("DropIfMachine", value);
         }
         /// <summary>
         /// (optional, string) A voice enabled inbound number associated with your Nexmo account.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (optional, string) The language used to play back your message.  The default is "en-us" which corresponds to United States english.
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (optional, string) If set to "hangup", the call will hang up immediately if a machine is detected, and the status in the CallbackData output will be set to "machine".
         /// </summary>
         /// <param name="value">Value of the MachineDetection input for this Choreo.</param>
         public void setMachineDetection(String value) {
             base.addInput ("MachineDetection", value);
         }
         /// <summary>
         /// (optional, integer) Time allocated to analyze if the call has been answered by a machine. The default value is 15000 (milliseconds).
         /// </summary>
         /// <param name="value">Value of the MachineTimeout input for this Choreo.</param>
         public void setMachineTimeout(String value) {
             base.addInput ("MachineTimeout", value);
         }
         /// <summary>
         /// (optional, integer) Define how many times you want to repeat the text message (default is 1 , maximum is 10).
         /// </summary>
         /// <param name="value">Value of the Repeat input for this Choreo.</param>
         public void setRepeat(String value) {
             base.addInput ("Repeat", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) Body of the text message (with a maximum length of 1000 characters).
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }
         /// <summary>
         /// (required, string) Phone number in international format and one recipient per request. (e.g.: 447525856424 when sending to UK)
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }
         /// <summary>
         /// (optional, string) The voice to be used female (default) or male
         /// </summary>
         /// <param name="value">Value of the Voice input for this Choreo.</param>
         public void setVoice(String value) {
             base.addInput ("Voice", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A TextToSpeechResultSet containing execution metadata and results.</returns>
        new public TextToSpeechResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TextToSpeechResultSet results = new JavaScriptSerializer().Deserialize<TextToSpeechResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the TextToSpeech Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TextToSpeechResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Nexmo. Corresponds to the ResponseFormat input. Defaults to json.</returns>
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
