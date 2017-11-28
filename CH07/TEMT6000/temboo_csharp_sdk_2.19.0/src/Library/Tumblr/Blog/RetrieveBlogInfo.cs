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

namespace Temboo.Library.Tumblr.Blog
{
    /// <summary>
    /// RetrieveBlogInfo
    /// Returns general information about the blog, such as the title, number of posts, and other high-level data.
    /// </summary>
    public class RetrieveBlogInfo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveBlogInfo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveBlogInfo(TembooSession session) : base(session, "/Library/Tumblr/Blog/RetrieveBlogInfo")
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
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveBlogInfoResultSet containing execution metadata and results.</returns>
        new public RetrieveBlogInfoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveBlogInfoResultSet results = new JavaScriptSerializer().Deserialize<RetrieveBlogInfoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveBlogInfo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveBlogInfoResultSet : Temboo.Core.ResultSet
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
