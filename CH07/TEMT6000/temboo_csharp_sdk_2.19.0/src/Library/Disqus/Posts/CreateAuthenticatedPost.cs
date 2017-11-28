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

namespace Temboo.Library.Disqus.Posts
{
    /// <summary>
    /// CreateAuthenticatedPost
    /// Create a new post for the authenticated user.
    /// </summary>
    public class CreateAuthenticatedPost : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateAuthenticatedPost Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateAuthenticatedPost(TembooSession session) : base(session, "/Library/Disqus/Posts/CreateAuthenticatedPost")
        {
        }

         /// <summary>
         /// (required, string) A valid OAuth 2.0 access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The date of the post, either in Unix timestamp format, or ISO datetime standard. You must be a moderator to do this.
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, string) The author's IP address. You must be a moderator to do this.
         /// </summary>
         /// <param name="value">Value of the IPAddress input for this Choreo.</param>
         public void setIPAddress(String value) {
             base.addInput ("IPAddress", value);
         }
         /// <summary>
         /// (conditional, string) The ID of a parent post to which the new post will be responding to. Either ParentPost, or Thread must be set, or both.
         /// </summary>
         /// <param name="value">Value of the ParentPost input for this Choreo.</param>
         public void setParentPost(String value) {
             base.addInput ("ParentPost", value);
         }
         /// <summary>
         /// (required, string) The text of this post.
         /// </summary>
         /// <param name="value">Value of the PostContent input for this Choreo.</param>
         public void setPostContent(String value) {
             base.addInput ("PostContent", value);
         }
         /// <summary>
         /// (optional, string) Specify the state of the post (comment). Available options include: unapproved, approved, spam, killed. You must be a moderator to do this. If set, pre-approval validation will be skipped.
         /// </summary>
         /// <param name="value">Value of the PostState input for this Choreo.</param>
         public void setPostState(String value) {
             base.addInput ("PostState", value);
         }
         /// <summary>
         /// (required, string) The Public Key provided by Disqus (AKA the API Key).
         /// </summary>
         /// <param name="value">Value of the PublicKey input for this Choreo.</param>
         public void setPublicKey(String value) {
             base.addInput ("PublicKey", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and jsonp.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Thread input for this Choreo.</param>
         public void setThread(String value) {
             base.addInput ("Thread", value);
         }
         /// <summary>
         /// (conditional, string) The thread ID to attach the new post to. Either ParentPost, or Thread must be set, or both.
         /// </summary>
         /// <param name="value">Value of the ThreadID input for this Choreo.</param>
         public void setThreadID(String value) {
             base.addInput ("ThreadID", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateAuthenticatedPostResultSet containing execution metadata and results.</returns>
        new public CreateAuthenticatedPostResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateAuthenticatedPostResultSet results = new JavaScriptSerializer().Deserialize<CreateAuthenticatedPostResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateAuthenticatedPost Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateAuthenticatedPostResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Disqus.</returns>
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
