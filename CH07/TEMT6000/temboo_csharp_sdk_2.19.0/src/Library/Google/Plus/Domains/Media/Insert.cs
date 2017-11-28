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

namespace Temboo.Library.Google.Plus.Domains.Media
{
    /// <summary>
    /// Insert
    /// Adds a new media item to an album. 
    /// </summary>
    public class Insert : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Insert Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Insert(TembooSession session) : base(session, "/Library/Google/Plus/Domains/Media/Insert")
        {
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
         /// (optional, string) Currently the acceptable values are "cloud".  (Upload the media to share on Google+).
         /// </summary>
         /// <param name="value">Value of the Collection input for this Choreo.</param>
         public void setCollection(String value) {
             base.addInput ("Collection", value);
         }
         /// <summary>
         /// (conditional, string) The Content-Type of the file that is being uploaded (i.e. image/jpg). Required when specifying the FileContent input.
         /// </summary>
         /// <param name="value">Value of the ContentType input for this Choreo.</param>
         public void setContentType(String value) {
             base.addInput ("ContentType", value);
         }
         /// <summary>
         /// (optional, string) The display name for the media. If this parameter is not provided, Google assigns a GUID to the media resource.
         /// </summary>
         /// <param name="value">Value of the DisplayName input for this Choreo.</param>
         public void setDisplayName(String value) {
             base.addInput ("DisplayName", value);
         }
         /// <summary>
         /// (optional, string) Selector specifying a subset of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (conditional, string) The Base64 encoded contents of the file to upload.
         /// </summary>
         /// <param name="value">Value of the FileContent input for this Choreo.</param>
         public void setFileContent(String value) {
             base.addInput ("FileContent", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user to create the activity on behalf of.  The value "me" is set as the default to indicate the authenticated user.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A InsertResultSet containing execution metadata and results.</returns>
        new public InsertResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            InsertResultSet results = new JavaScriptSerializer().Deserialize<InsertResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Insert Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class InsertResultSet : Temboo.Core.ResultSet
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
