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

namespace Temboo.Library.Disqus.Threads
{
    /// <summary>
    /// ListThreads
    /// Retrieve a list of threads ordered by date of creation.
    /// </summary>
    public class ListThreads : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListThreads Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListThreads(TembooSession session) : base(session, "/Library/Disqus/Threads/ListThreads")
        {
        }

         /// <summary>
         /// (optional, string) A valid OAuth 2.0 access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, integer) A Disqus User ID, for which threads will be retrieved. If AuthorID is set, then AuthorUsername must be null.
         /// </summary>
         /// <param name="value">Value of the AuthorID input for this Choreo.</param>
         public void setAuthorID(String value) {
             base.addInput ("AuthorID", value);
         }
         /// <summary>
         /// (optional, string) A Disqus username for which threads will be retrieved.  If AuthorUsername is being set, then AuthorID must be null.
         /// </summary>
         /// <param name="value">Value of the AuthorUsername input for this Choreo.</param>
         public void setAuthorUsername(String value) {
             base.addInput ("AuthorUsername", value);
         }
         /// <summary>
         /// (optional, integer) Specify a category ID for which threads wil be retrieved.
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
         }
         /// <summary>
         /// (optional, string) Default is set to null.
         /// </summary>
         /// <param name="value">Value of the Cursor input for this Choreo.</param>
         public void setCursor(String value) {
             base.addInput ("Cursor", value);
         }
         /// <summary>
         /// (optional, string) Forum Short Name (i.e., the subdomain of the Disqus Site URL).  All threads in this forum will be retrieved.  If null, threads from all forums moderated by the authenticating user will be retrieved.
         /// </summary>
         /// <param name="value">Value of the Forum input for this Choreo.</param>
         public void setForum(String value) {
             base.addInput ("Forum", value);
         }
         /// <summary>
         /// (optional, string) Specify a post status parameter to filter results by. Valid parameters include: open, closed, killed.  Default is set to: open, closed.
         /// </summary>
         /// <param name="value">Value of the Include input for this Choreo.</param>
         public void setInclude(String value) {
             base.addInput ("Include", value);
         }
         /// <summary>
         /// (optional, integer) The number of records to return. Maximum value is 100.  Defaults to 25.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The sort order for the results. Valid values are: asc or desc. Default is set to: asc.
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
         /// (optional, string) Indicates the relations to include with your response.  Valid entries include: forum, author, category
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
         /// (optional, string) A Thread ID to narrow search results.
         /// </summary>
         /// <param name="value">Value of the ThreadID input for this Choreo.</param>
         public void setThreadID(String value) {
             base.addInput ("ThreadID", value);
         }
         /// <summary>
         /// (optional, string) An identifier to retrieve associated threads. Note that a Forum must also be provided when using this parameter. If set, ThreadID and ThreadLink cannot be used.
         /// </summary>
         /// <param name="value">Value of the ThreadIdentifier input for this Choreo.</param>
         public void setThreadIdentifier(String value) {
             base.addInput ("ThreadIdentifier", value);
         }
         /// <summary>
         /// (optional, string) A link pointing to the thread that is to be retrieved. Note that a Forum must also be provided when using this parameter. If set, ThreadID and ThreadIdentifier cannot be set.
         /// </summary>
         /// <param name="value">Value of the ThreadLink input for this Choreo.</param>
         public void setThreadLink(String value) {
             base.addInput ("ThreadLink", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListThreadsResultSet containing execution metadata and results.</returns>
        new public ListThreadsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListThreadsResultSet results = new JavaScriptSerializer().Deserialize<ListThreadsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListThreads Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListThreadsResultSet : Temboo.Core.ResultSet
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
