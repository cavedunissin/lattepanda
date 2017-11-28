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

namespace Temboo.Library.RunKeeper.Friends
{
    /// <summary>
    /// RetrieveFriends
    /// Returns the friends in a user's network.
    /// </summary>
    public class RetrieveFriends : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetrieveFriends Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetrieveFriends(TembooSession session) : base(session, "/Library/RunKeeper/Friends/RetrieveFriends")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved after the final step in the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, integer) The page of entries to return. This parameter is used in combination with the PageSize input to page through results. Defaults to 0 (the first page).
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number entries to return per page. Defaults to 25.
         /// </summary>
         /// <param name="value">Value of the PageSize input for this Choreo.</param>
         public void setPageSize(String value) {
             base.addInput ("PageSize", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RetrieveFriendsResultSet containing execution metadata and results.</returns>
        new public RetrieveFriendsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetrieveFriendsResultSet results = new JavaScriptSerializer().Deserialize<RetrieveFriendsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetrieveFriends Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetrieveFriendsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Next" output from this Choreo execution
        /// <returns>String - (integer) The next page of entries that is available. This value can be passed into the Page input while paging through entries.</returns>
        /// </summary>
        public String Next
        {
            get
            {
                return (String) base.Output["Next"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Previous" output from this Choreo execution
        /// <returns>String - (integer) The previous page of entries that is available. This value can be passed into the Page input while paging through entries.</returns>
        /// </summary>
        public String Previous
        {
            get
            {
                return (String) base.Output["Previous"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from RunKeeper.</returns>
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
