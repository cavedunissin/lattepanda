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

namespace Temboo.Library.Disqus.Users
{
    /// <summary>
    /// ListPosts
    /// List posts made by a user.
    /// </summary>
    public class ListPosts : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListPosts Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListPosts(TembooSession session) : base(session, "/Library/Disqus/Users/ListPosts")
        {
        }

         /// <summary>
         /// (optional, string) Default is set to null.
         /// </summary>
         /// <param name="value">Value of the Cursor input for this Choreo.</param>
         public void setCursor(String value) {
             base.addInput ("Cursor", value);
         }
         /// <summary>
         /// (optional, string) Specify the type of posts that are to be retrieved. Valid values are: unapproved, approved, spam, deleted, flagged, highlighted.  Default is: approved.
         /// </summary>
         /// <param name="value">Value of the Included input for this Choreo.</param>
         public void setIncluded(String value) {
             base.addInput ("Included", value);
         }
         /// <summary>
         /// (optional, integer) The number of records to return. Defaults to 25.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The sort order for the results. valid values are: asc or desc. Default is set to: asc.
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (required, string) The Public Key provided by Disqus (AKA the API Key).
         /// </summary>
         /// <param name="value">Value of the PublicKey input for this Choreo.</param>
         public void setPublicKey(String value) {
             base.addInput ("PublicKey", value);
         }
         /// <summary>
         /// (optional, string) Indicates the relations to include with your response. Valid values are: forum and thread.
         /// </summary>
         /// <param name="value">Value of the Related input for this Choreo.</param>
         public void setRelated(String value) {
             base.addInput ("Related", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default), jsonp, or rss.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) A Unix timestamp (or ISO datetime standard) to obtain results from. (e.g. 2014-02-02T01:01:00Z) Default is set to null.
         /// </summary>
         /// <param name="value">Value of the Since input for this Choreo.</param>
         public void setSince(String value) {
             base.addInput ("Since", value);
         }
         /// <summary>
         /// (optional, integer) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the SinceID input for this Choreo.</param>
         public void setSinceID(String value) {
             base.addInput ("SinceID", value);
         }
         /// <summary>
         /// (conditional, string) The Disqus User ID, for which active forum information will be retrieved.  If UserID is set, then Username must be null.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }
         /// <summary>
         /// (conditional, string) A Disqus username. If Username is being set, then UserID must be null.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListPostsResultSet containing execution metadata and results.</returns>
        new public ListPostsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListPostsResultSet results = new JavaScriptSerializer().Deserialize<ListPostsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListPosts Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListPostsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Disqus.</returns>
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
