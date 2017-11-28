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
    /// EditQuotePost
    /// Updates a specified quote post on a Tumblr blog.
    /// </summary>
    public class EditQuotePost : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the EditQuotePost Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public EditQuotePost(TembooSession session) : base(session, "/Library/Tumblr/Post/EditQuotePost")
        {
        }

         /// <summary>
         /// (required, string) The full text of the quote. HTML entities must be escpaed.
         /// </summary>
         /// <param name="value">Value of the Quote input for this Choreo.</param>
         public void setQuote(String value) {
             base.addInput ("Quote", value);
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
         /// (required, string) The standard or custom blog hostname (i.e. temboo.tumblr.com).
         /// </summary>
         /// <param name="value">Value of the BaseHostname input for this Choreo.</param>
         public void setBaseHostname(String value) {
             base.addInput ("BaseHostname", value);
         }
         /// <summary>
         /// (optional, date) The GMT date and time of the post. Can be an epoch timestamp in milliseconds or formatted like: Dec 8th, 2011 4:03pm. Defaults to NOW().
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (required, integer) The ID of the post you want to edit.
         /// </summary>
         /// <param name="value">Value of the ID input for this Choreo.</param>
         public void setID(String value) {
             base.addInput ("ID", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates whether the post uses markdown syntax. Defaults to false. Set to 1 to indicate true.
         /// </summary>
         /// <param name="value">Value of the Markdown input for this Choreo.</param>
         public void setMarkdown(String value) {
             base.addInput ("Markdown", value);
         }
         /// <summary>
         /// (optional, any) The format that the response should be in. Can be set to xml or json. Defaults to json.
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
         /// (optional, string) Adds a short text summary to the end of the post URL.
         /// </summary>
         /// <param name="value">Value of the Slug input for this Choreo.</param>
         public void setSlug(String value) {
             base.addInput ("Slug", value);
         }
         /// <summary>
         /// (optional, string) The cited source of the quote. HTML is allowed.
         /// </summary>
         /// <param name="value">Value of the Source input for this Choreo.</param>
         public void setSource(String value) {
             base.addInput ("Source", value);
         }
         /// <summary>
         /// (optional, string) The state of the post. Specify one of the following:  published, draft, queue. Defaults to published.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (optional, string) Comma-separated tags for this post.
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (optional, string) Manages the autotweet (if enabled) for this post. Set to "off" for no tweet. Enter text to override the default tweet.
         /// </summary>
         /// <param name="value">Value of the Tweet input for this Choreo.</param>
         public void setTweet(String value) {
             base.addInput ("Tweet", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A EditQuotePostResultSet containing execution metadata and results.</returns>
        new public EditQuotePostResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            EditQuotePostResultSet results = new JavaScriptSerializer().Deserialize<EditQuotePostResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the EditQuotePost Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class EditQuotePostResultSet : Temboo.Core.ResultSet
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
