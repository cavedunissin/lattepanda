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
    /// GetTranslationsArray
    /// Retrieves multiple translation candidates for multiple source texts.
    /// </summary>
    public class GetTranslationsArray : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTranslationsArray Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTranslationsArray(TembooSession session) : base(session, "/Library/Microsoft/Translator/GetTranslationsArray")
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
         /// (optional, string) A string containing the category (domain) of the translation. Defaults to "general".
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
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
         /// (optional, string) The format of the text being translated. The only supported, and the default, option is "text/plain".
         /// </summary>
         /// <param name="value">Value of the ContentType input for this Choreo.</param>
         public void setContentType(String value) {
             base.addInput ("ContentType", value);
         }
         /// <summary>
         /// (required, string) A string representing the ISO 639-1 language code of the translation text (e.g., en).
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (required, integer) An integer representing the maximum number of translations to return.
         /// </summary>
         /// <param name="value">Value of the MaxTranslations input for this Choreo.</param>
         public void setMaxTranslations(String value) {
             base.addInput ("MaxTranslations", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) User state to help correlate request and response. The same contents will be returned in the response.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (required, json) An array containing the texts for translation. All strings must be of the same language. The total of all texts must not exceed 10000 characters. The max number of array items is 2000.
         /// </summary>
         /// <param name="value">Value of the Texts input for this Choreo.</param>
         public void setTexts(String value) {
             base.addInput ("Texts", value);
         }
         /// <summary>
         /// (required, string) A string representing the ISO 639-1 language code to translate the text into (e.g., es).
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }
         /// <summary>
         /// (optional, string) Filter results by this URI. Default: all
         /// </summary>
         /// <param name="value">Value of the URI input for this Choreo.</param>
         public void setURI(String value) {
             base.addInput ("URI", value);
         }
         /// <summary>
         /// (optional, string) Filter results by this user. Default: all
         /// </summary>
         /// <param name="value">Value of the User input for this Choreo.</param>
         public void setUser(String value) {
             base.addInput ("User", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTranslationsArrayResultSet containing execution metadata and results.</returns>
        new public GetTranslationsArrayResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTranslationsArrayResultSet results = new JavaScriptSerializer().Deserialize<GetTranslationsArrayResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTranslationsArray Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTranslationsArrayResultSet : Temboo.Core.ResultSet
    {
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
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Microsoft.</returns>
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
