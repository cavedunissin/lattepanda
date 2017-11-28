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

namespace Temboo.Library.Google.Drive.Files
{
    /// <summary>
    /// Copy
    /// Creates a copy of the specified file.
    /// </summary>
    public class Copy : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Copy Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Copy(TembooSession session) : base(session, "/Library/Google/Drive/Files/Copy")
        {
        }

         /// <summary>
         /// (optional, json) A JSON representation of fields in a file resource. File metadata information (such as the title) can be set using this input. See documentation for formatting examples.
         /// </summary>
         /// <param name="value">Value of the RequestBody input for this Choreo.</param>
         public void setRequestBody(String value) {
             base.addInput ("RequestBody", value);
         }
         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth2 process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
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
         /// (optional, boolean) Whether to convert this file to the corresponding Google Docs format. (Default: false).
         /// </summary>
         /// <param name="value">Value of the Convert input for this Choreo.</param>
         public void setConvert(String value) {
             base.addInput ("Convert", value);
         }
         /// <summary>
         /// (optional, string) Selector specifying a subset of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (required, string) The ID of the file to copy.
         /// </summary>
         /// <param name="value">Value of the FileID input for this Choreo.</param>
         public void setFileID(String value) {
             base.addInput ("FileID", value);
         }
         /// <summary>
         /// (optional, boolean) Whether to attempt OCR on .jpg, .png, .gif, or .pdf uploads. (Default: false)
         /// </summary>
         /// <param name="value">Value of the OCR input for this Choreo.</param>
         public void setOCR(String value) {
             base.addInput ("OCR", value);
         }
         /// <summary>
         /// (optional, string) If ocr is true, hints at the language to use. Valid values are ISO 639-1 codes.
         /// </summary>
         /// <param name="value">Value of the OcrLanguage input for this Choreo.</param>
         public void setOcrLanguage(String value) {
             base.addInput ("OcrLanguage", value);
         }
         /// <summary>
         /// (optional, boolean) Whether to pin the head revision of the uploaded file. (Default: false).
         /// </summary>
         /// <param name="value">Value of the Pinned input for this Choreo.</param>
         public void setPinned(String value) {
             base.addInput ("Pinned", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) The language of the original file to be translated.
         /// </summary>
         /// <param name="value">Value of the SourceLanguage input for this Choreo.</param>
         public void setSourceLanguage(String value) {
             base.addInput ("SourceLanguage", value);
         }
         /// <summary>
         /// (optional, string) Target language to translate the file to. If no sourceLanguage is provided, the API will attempt to detect the language.
         /// </summary>
         /// <param name="value">Value of the TargetLanguage input for this Choreo.</param>
         public void setTargetLanguage(String value) {
             base.addInput ("TargetLanguage", value);
         }
         /// <summary>
         /// (optional, string) The language of the timed text.
         /// </summary>
         /// <param name="value">Value of the TimedTextLanguage input for this Choreo.</param>
         public void setTimedTextLanguage(String value) {
             base.addInput ("TimedTextLanguage", value);
         }
         /// <summary>
         /// (optional, string) The timed text track name.
         /// </summary>
         /// <param name="value">Value of the TimedTextTrackName input for this Choreo.</param>
         public void setTimedTextTrackName(String value) {
             base.addInput ("TimedTextTrackName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CopyResultSet containing execution metadata and results.</returns>
        new public CopyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CopyResultSet results = new JavaScriptSerializer().Deserialize<CopyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Copy Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CopyResultSet : Temboo.Core.ResultSet
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
