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
    /// ApprovePosts
    /// Approves a post.
    /// </summary>
    public class ApprovePosts : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ApprovePosts Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ApprovePosts(TembooSession session) : base(session, "/Library/Disqus/Posts/ApprovePosts")
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
         /// (required, integer) The post ID which is to be approved. Note that you must be a forum moderator to approve posts.
         /// </summary>
         /// <param name="value">Value of the PostID input for this Choreo.</param>
         public void setPostID(String value) {
             base.addInput ("PostID", value);
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ApprovePostsResultSet containing execution metadata and results.</returns>
        new public ApprovePostsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ApprovePostsResultSet results = new JavaScriptSerializer().Deserialize<ApprovePostsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ApprovePosts Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ApprovePostsResultSet : Temboo.Core.ResultSet
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
