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
    /// AddBookmark
    /// Adds a link bookmark to a Delicious account.
    /// </summary>
    public class AddBookmark : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddBookmark Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddBookmark(TembooSession session) : base(session, "/Library/Delicious/AddBookmark")
        {
        }

         /// <summary>
         /// (required, string) A description for the link to post.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) Descriptive notes for the posted link.
         /// </summary>
         /// <param name="value">Value of the Notes input for this Choreo.</param>
         public void setNotes(String value) {
             base.addInput ("Notes", value);
         }
         /// <summary>
         /// (required, password) The password that corresponds to the specified Delicious account username.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, integer) Specify "1" to replace the post if the URL has already been posted. Set to "0" (don't replace) by default.
         /// </summary>
         /// <param name="value">Value of the Replace input for this Choreo.</param>
         public void setReplace(String value) {
             base.addInput ("Replace", value);
         }
         /// <summary>
         /// (optional, integer) Specify "1" to make the posted link private. Set to "0" (shared) by default.
         /// </summary>
         /// <param name="value">Value of the Shared input for this Choreo.</param>
         public void setShared(String value) {
             base.addInput ("Shared", value);
         }
         /// <summary>
         /// (optional, string) Add keyword tags to the posted link. Separate multiple tags with commas.
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (required, string) The URL for the link to post.
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
        /// <returns>A AddBookmarkResultSet containing execution metadata and results.</returns>
        new public AddBookmarkResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddBookmarkResultSet results = new JavaScriptSerializer().Deserialize<AddBookmarkResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddBookmark Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddBookmarkResultSet : Temboo.Core.ResultSet
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
