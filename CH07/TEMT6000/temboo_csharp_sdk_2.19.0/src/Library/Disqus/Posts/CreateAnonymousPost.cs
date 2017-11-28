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
    /// CreateAnonymousPost
    /// Creates an anonymous post.
    /// </summary>
    public class CreateAnonymousPost : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateAnonymousPost Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateAnonymousPost(TembooSession session) : base(session, "/Library/Disqus/Posts/CreateAnonymousPost")
        {
        }

         /// <summary>
         /// (required, string) The email address of the post author.
         /// </summary>
         /// <param name="value">Value of the AuthorEmail input for this Choreo.</param>
         public void setAuthorEmail(String value) {
             base.addInput ("AuthorEmail", value);
         }
         /// <summary>
         /// (required, string) The name of the post author.
         /// </summary>
         /// <param name="value">Value of the AuthorName input for this Choreo.</param>
         public void setAuthorName(String value) {
             base.addInput ("AuthorName", value);
         }
         /// <summary>
         /// (optional, string) The URL of the author's Disqus profile.
         /// </summary>
         /// <param name="value">Value of the AuthorURL input for this Choreo.</param>
         public void setAuthorURL(String value) {
             base.addInput ("AuthorURL", value);
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
        /// <returns>A CreateAnonymousPostResultSet containing execution metadata and results.</returns>
        new public CreateAnonymousPostResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateAnonymousPostResultSet results = new JavaScriptSerializer().Deserialize<CreateAnonymousPostResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateAnonymousPost Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateAnonymousPostResultSet : Temboo.Core.ResultSet
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
