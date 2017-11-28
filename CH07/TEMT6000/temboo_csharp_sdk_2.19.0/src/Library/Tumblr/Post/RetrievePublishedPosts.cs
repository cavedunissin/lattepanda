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
    /// RetrievePublishedPosts
    /// Retrieves published posts using various search and filter parameters.
    /// </summary>
    public class RetrievePublishedPosts : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrievePublishedPosts Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrievePublishedPosts(TembooSession session) : base(session, "/Library/Tumblr/Post/RetrievePublishedPosts")
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
         /// (required, string) The standard or custom blog hostname (i.e. temboo.tumblr.com).
         /// </summary>
         /// <param name="value">Value of the BaseHostname input for this Choreo.</param>
         public void setBaseHostname(String value) {
             base.addInput ("BaseHostname", value);
         }
         /// <summary>
         /// (optional, string) Specifies the post format to return. Valid values are: text (Plain text, no HTML), raw (As entered by user). HTML is returned when left null.
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (optional, integer) The specified post ID in order to return a single post.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (optional, integer) The number of posts to return: 1- 20. Defaults to 20.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether to return notes information (specify true or false). Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the NotesInfo input for this Choreo.</param>
         public void setNotesInfo(String value) {
             base.addInput ("NotesInfo", value);
         }
         /// <summary>
         /// (optional, integer) The post number to start at. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether to return reblog information (specify 1 or 0). Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the ReblogInfo input for this Choreo.</param>
         public void setReblogInfo(String value) {
             base.addInput ("ReblogInfo", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Limits the response to posts with the specified tag.
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }
         /// <summary>
         /// (optional, string) The type of post to return. Specify one of the following:  text, quote, link, answer, video, audio, photo. When null, all types are returned.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrievePublishedPostsResultSet containing execution metadata and results.</returns>
        new public RetrievePublishedPostsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrievePublishedPostsResultSet results = new JavaScriptSerializer().Deserialize<RetrievePublishedPostsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrievePublishedPosts Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrievePublishedPostsResultSet : Temboo.Core.ResultSet
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
