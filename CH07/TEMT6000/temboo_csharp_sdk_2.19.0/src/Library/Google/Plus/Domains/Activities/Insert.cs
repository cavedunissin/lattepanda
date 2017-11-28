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

namespace Temboo.Library.Google.Plus.Domains.Activities
{
    /// <summary>
    /// Insert
    /// Inserts a new activity into a user's stream.
    /// </summary>
    public class Insert : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Insert Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Insert(TembooSession session) : base(session, "/Library/Google/Plus/Domains/Activities/Insert")
        {
        }

         /// <summary>
         /// (optional, string) A JSON-formatted string containing the activity properties you wish to set. This can be used as an alternative to setting individual inputs representing resource properties.
         /// </summary>
         /// <param name="value">Value of the ActivityResource input for this Choreo.</param>
         public void setActivityResource(String value) {
             base.addInput ("ActivityResource", value);
         }
         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) Specifies a JavaScript function that will be passed the response data for using the API with JSONP.
         /// </summary>
         /// <param name="value">Value of the Callback input for this Choreo.</param>
         public void setCallback(String value) {
             base.addInput ("Callback", value);
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
         /// (required, string) Content to post to your stream.
         /// </summary>
         /// <param name="value">Value of the Content input for this Choreo.</param>
         public void setContent(String value) {
             base.addInput ("Content", value);
         }
         /// <summary>
         /// (optional, string) A description for the new activity being created.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) Used to specify fields to include in a partial response. This can be used to reduce the amount of data returned. See documentation for syntax rules.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, boolean) A flag used to pretty print the JSON response to make it more readable. Defaults to "true".
         /// </summary>
         /// <param name="value">Value of the PrettyPrint input for this Choreo.</param>
         public void setPrettyPrint(String value) {
             base.addInput ("PrettyPrint", value);
         }
         /// <summary>
         /// (optional, boolean) If "true", extract the potential media attachments for a URL. The response will include all possible attachments for a URL, including video, photos, and articles based on the content of the page.
         /// </summary>
         /// <param name="value">Value of the Preview input for this Choreo.</param>
         public void setPreview(String value) {
             base.addInput ("Preview", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to share this activity with the entire Domain.
         /// </summary>
         /// <param name="value">Value of the ShareWithDomain input for this Choreo.</param>
         public void setShareWithDomain(String value) {
             base.addInput ("ShareWithDomain", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to share this activity your circles plus all the people in their circles.
         /// </summary>
         /// <param name="value">Value of the ShareWithExtendedCircles input for this Choreo.</param>
         public void setShareWithExtendedCircles(String value) {
             base.addInput ("ShareWithExtendedCircles", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to share this activity with everyone in your Circles.
         /// </summary>
         /// <param name="value">Value of the ShareWithMyCircles input for this Choreo.</param>
         public void setShareWithMyCircles(String value) {
             base.addInput ("ShareWithMyCircles", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to share this activity with everyone on the web.
         /// </summary>
         /// <param name="value">Value of the ShareWithPublic input for this Choreo.</param>
         public void setShareWithPublic(String value) {
             base.addInput ("ShareWithPublic", value);
         }
         /// <summary>
         /// (optional, string) Comma-seperated list of up to 10 IDs of the circles you want to share this activity with.
         /// </summary>
         /// <param name="value">Value of the ShareWithTheseCircles input for this Choreo.</param>
         public void setShareWithTheseCircles(String value) {
             base.addInput ("ShareWithTheseCircles", value);
         }
         /// <summary>
         /// (optional, string) Comma-seperated list of up to 10 IDs of persons you want to share this activity with.
         /// </summary>
         /// <param name="value">Value of the ShareWithThesePeople input for this Choreo.</param>
         public void setShareWithThesePeople(String value) {
             base.addInput ("ShareWithThesePeople", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user to create a circle for. The value "me" is set as the default to indicate the authenticated user.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }
         /// <summary>
         /// (optional, string) Identifies the IP address of the end user for whom the API call is being made. Used to enforce per-user quotas.
         /// </summary>
         /// <param name="value">Value of the UserIP input for this Choreo.</param>
         public void setUserIP(String value) {
             base.addInput ("UserIP", value);
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
