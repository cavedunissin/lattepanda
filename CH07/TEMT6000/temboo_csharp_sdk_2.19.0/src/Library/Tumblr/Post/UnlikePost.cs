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

namespace Temboo.Library.Tumblr.Post
{
    /// <summary>
    /// UnlikePost
    /// Allows a user to like a specified post.
    /// </summary>
    public class UnlikePost : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UnlikePost Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UnlikePost(TembooSession session) : base(session, "/Library/Tumblr/Post/UnlikePost")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Tumblr (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, integer) The ID of the post you want to unlike.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (required, string) The reblog key for the post id. This can be retrieved with the RetrievePublishedPosts Choreo.
         /// </summary>
         /// <param name="value">Value of the ReblogKey input for this Choreo.</param>
         public void setReblogKey(String value) {
             base.addInput ("ReblogKey", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The Secret Key provided by Tumblr (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the SecretKey input for this Choreo.</param>
         public void setSecretKey(String value) {
             base.addInput ("SecretKey", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UnlikePostResultSet containing execution metadata and results.</returns>
        new public UnlikePostResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UnlikePostResultSet results = new JavaScriptSerializer().Deserialize<UnlikePostResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UnlikePost Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UnlikePostResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Tumblr. Default is JSON, can be set to XML by entering 'xml' in ResponseFormat.</returns>
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
