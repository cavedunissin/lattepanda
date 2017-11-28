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

namespace Temboo.Library.Microsoft.Translator
{
    /// <summary>
    /// Speak
    /// Returns a Base64 encoded wave or mp3 file of the passed-in text being spoken in the desired language.
    /// </summary>
    public class Speak : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Speak Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Speak(TembooSession session) : base(session, "/Library/Microsoft/Translator/Speak")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token. This can be retrieved by running the GetToken Choreo. Required unless providing the ClientID and ClientSecret.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID obtained when signing up for Microsoft Translator on Azure Marketplace. This is required unless providing an AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret obtained when signing up for Microsoft Translator on Azure Marketplace. This is required unless providing an AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) A string specifying the content-type. Currently, "audio/wav" and "audio/mp3" are available. The default value is "audio/wav".
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (required, string) A string representing the supported ISO 639-1 language code to speak the text in (e.g., es). The code must be present in the list of codes returned from the method GetLanguagesForSpeak.
         /// </summary>
         /// <param name="value">Value of the Language input for this Choreo.</param>
         public void setLanguage(String value) {
             base.addInput ("Language", value);
         }
         /// <summary>
         /// (optional, string) A string specifying the quality of the audio signals. Valid values are: MaxQuality or MinQuality (the default).
         /// </summary>
         /// <param name="value">Value of the Options input for this Choreo.</param>
         public void setOptions(String value) {
             base.addInput ("Options", value);
         }
         /// <summary>
         /// (required, string) A string representing the text to translate. The size of the text must not exceed 10000 characters.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SpeakResultSet containing execution metadata and results.</returns>
        new public SpeakResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SpeakResultSet results = new JavaScriptSerializer().Deserialize<SpeakResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Speak Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SpeakResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AudioFile" output from this Choreo execution
        /// <returns>String - (string) The Base64 encoded audio file in mp3 or wav format.</returns>
        /// </summary>
        public String AudioFile
        {
            get
            {
                return (String) base.Output["AudioFile"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ExpiresIn" output from this Choreo execution
        /// <returns>String - (integer) Contains the number of seconds for which the access token is valid when ClientID and ClientSecret are provided.</returns>
        /// </summary>
        public String ExpiresIn
        {
            get
            {
                return (String) base.Output["ExpiresIn"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the ClientID and ClientSecret are provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
    }
}
