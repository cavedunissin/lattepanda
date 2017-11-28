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

namespace Temboo.Library.LinkedIn.ShareAndSocialStream
{
    /// <summary>
    /// CreateShare
    /// Allows you to share content on behalf of a LinkedIn member.
    /// </summary>
    public class CreateShare : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateShare Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateShare(TembooSession session) : base(session, "/Library/LinkedIn/ShareAndSocialStream/CreateShare")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by LinkedIn (AKA the Client ID).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process (AKA the OAuth User Token).
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret retrieved during the OAuth process (AKA the OAuth User Secret).
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (conditional, string) The text of the member's comment. Required unless providing Title and URL for a shared post.
         /// </summary>
         /// <param name="value">Value of the Comment input for this Choreo.</param>
         public void setComment(String value) {
             base.addInput ("Comment", value);
         }
         /// <summary>
         /// (optional, string) A description of the shared content.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) The URL for the image of the shared content.
         /// </summary>
         /// <param name="value">Value of the ImageURL input for this Choreo.</param>
         public void setImageURL(String value) {
             base.addInput ("ImageURL", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The Secret Key provided by LinkedIn (AKA the Client Secret).
         /// </summary>
         /// <param name="value">Value of the SecretKey input for this Choreo.</param>
         public void setSecretKey(String value) {
             base.addInput ("SecretKey", value);
         }
         /// <summary>
         /// (conditional, string) The title of the shared content. Required unless providing a Comment.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (conditional, string) The URL for the shared content. Required unless providing a Comment.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }
         /// <summary>
         /// (optional, string) Determines if the post will be visible to everyone, or only those who are connected to you. Valid values are: "anyone" or "connections-only" (the default).
         /// </summary>
         /// <param name="value">Value of the Visibility input for this Choreo.</param>
         public void setVisibility(String value) {
             base.addInput ("Visibility", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateShareResultSet containing execution metadata and results.</returns>
        new public CreateShareResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateShareResultSet results = new JavaScriptSerializer().Deserialize<CreateShareResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateShare Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateShareResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from LinkedIn.</returns>
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
