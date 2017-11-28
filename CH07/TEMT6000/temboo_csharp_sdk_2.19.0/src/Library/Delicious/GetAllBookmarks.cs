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
    /// GetAllBookmarks
    /// Returns all links posted to a Delicious account.
    /// </summary>
    public class GetAllBookmarks : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetAllBookmarks Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetAllBookmarks(TembooSession session) : base(session, "/Library/Delicious/GetAllBookmarks")
        {
        }

         /// <summary>
         /// (optional, integer) The number of bookmarks to return. Defaults to 15.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, date) Return only bookmarks posted on this date and later. Enter in YYYY-MM-DDThh:mm:ssZ format.
         /// </summary>
         /// <param name="value">Value of the FromDate input for this Choreo.</param>
         public void setFromDate(String value) {
             base.addInput ("FromDate", value);
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
         /// (optional, string) Return only bookmrks tagged with this keyword.
         /// </summary>
         /// <param name="value">Value of the Tag input for this Choreo.</param>
         public void setTag(String value) {
             base.addInput ("Tag", value);
         }
         /// <summary>
         /// (optional, date) Return only bookmarks posted on this date and earlier. Enter in YYYY-MM-DDThh:mm:ssZ format.
         /// </summary>
         /// <param name="value">Value of the ToDate input for this Choreo.</param>
         public void setToDate(String value) {
             base.addInput ("ToDate", value);
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
        /// <returns>A GetAllBookmarksResultSet containing execution metadata and results.</returns>
        new public GetAllBookmarksResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetAllBookmarksResultSet results = new JavaScriptSerializer().Deserialize<GetAllBookmarksResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetAllBookmarks Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetAllBookmarksResultSet : Temboo.Core.ResultSet
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
