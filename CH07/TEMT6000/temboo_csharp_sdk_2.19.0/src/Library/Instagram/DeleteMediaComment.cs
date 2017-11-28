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

namespace Temboo.Library.Instagram
{
    /// <summary>
    /// DeleteMediaComment
    /// Removes a specified comment from a user's media.
    /// </summary>
    public class DeleteMediaComment : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DeleteMediaComment Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DeleteMediaComment(TembooSession session) : base(session, "/Library/Instagram/DeleteMediaComment")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved during the OAuth 2.0 process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The ID of the comment to delete.
         /// </summary>
         /// <param name="value">Value of the CommentID input for this Choreo.</param>
         public void setCommentID(String value) {
             base.addInput ("CommentID", value);
         }
         /// <summary>
         /// (required, string) The ID of the media object that you want to delete comments from.
         /// </summary>
         /// <param name="value">Value of the MediaID input for this Choreo.</param>
         public void setMediaID(String value) {
             base.addInput ("MediaID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteMediaCommentResultSet containing execution metadata and results.</returns>
        new public DeleteMediaCommentResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteMediaCommentResultSet results = new JavaScriptSerializer().Deserialize<DeleteMediaCommentResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DeleteMediaComment Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteMediaCommentResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Instagram.</returns>
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
