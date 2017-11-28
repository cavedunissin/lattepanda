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

namespace Temboo.Library.Tumblr.Tagged
{
    /// <summary>
    /// RetrievePostsWithTag
    /// Retrieves posts that have a given tag.
    /// </summary>
    public class RetrievePostsWithTag : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrievePostsWithTag Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrievePostsWithTag(TembooSession session) : base(session, "/Library/Tumblr/Tagged/RetrievePostsWithTag")
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
         /// (optional, string) The timestamp of when you'd like to see posts before (e.g. 1363716547).
         /// </summary>
         /// <param name="value">Value of the Before input for this Choreo.</param>
         public void setBefore(String value) {
             base.addInput ("Before", value);
         }
         /// <summary>
         /// (optional, string) Specifies the post format to return. Valid values are: text (plain text, no html) or raw (as entered by the user).
         /// </summary>
         /// <param name="value">Value of the Filter input for this Choreo.</param>
         public void setFilter(String value) {
             base.addInput ("Filter", value);
         }
         /// <summary>
         /// (optional, integer) The number of posts to return: 1- 20. Defaults to 20.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) The post number to start at. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The tag on the posts you'd like to retrieve.
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrievePostsWithTagResultSet containing execution metadata and results.</returns>
        new public RetrievePostsWithTagResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrievePostsWithTagResultSet results = new JavaScriptSerializer().Deserialize<RetrievePostsWithTagResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrievePostsWithTag Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrievePostsWithTagResultSet : Temboo.Core.ResultSet
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
