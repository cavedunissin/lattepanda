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

namespace Temboo.Library.Delicious
{
    /// <summary>
    /// GetBookmark
    /// Retrieves one or more bookmarked links posted on a single day.
    /// </summary>
    public class GetBookmark : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetBookmark Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetBookmark(TembooSession session) : base(session, "/Library/Delicious/GetBookmark")
        {
        }

         /// <summary>
         /// (optional, string) Return only bookmarks with the URL MD5 signatures you enter, regardless of posting date. Separate multiple signatures with spaces.
         /// </summary>
         /// <param name="value">Value of the ChangeSignature input for this Choreo.</param>
         public void setChangeSignature(String value) {
             base.addInput ("ChangeSignature", value);
         }
         /// <summary>
         /// (optional, date) Return only bookmarks posted on a date specified here. Enter in YYYY-MM-DDThh:mm:ssZ format. Defaults to the most recent date.
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, string) Specify "1" to include a change-detection signature for each item returned. Defaults to "0", or no meta attributes retained.
         /// </summary>
         /// <param name="value">Value of the Meta input for this Choreo.</param>
         public void setMeta(String value) {
             base.addInput ("Meta", value);
         }
         /// <summary>
         /// (required, password) The password that corresponds to the specified Delicious account username.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) Return only items tagged with the specified keyword. Separate multiple tags with spaces.
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }
         /// <summary>
         /// (optional, string) Return only items with the specified URL, regardless of posting date.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }
         /// <summary>
         /// (required, string) A valid Delicious account username.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetBookmarkResultSet containing execution metadata and results.</returns>
        new public GetBookmarkResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetBookmarkResultSet results = new JavaScriptSerializer().Deserialize<GetBookmarkResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetBookmark Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetBookmarkResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response returned from Delicious.</returns>
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
