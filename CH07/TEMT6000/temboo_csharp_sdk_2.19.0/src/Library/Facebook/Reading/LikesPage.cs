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

namespace Temboo.Library.Facebook.Reading
{
    /// <summary>
    /// LikesPage
    /// Determines whether or not someone likes a Facebook Page.
    /// </summary>
    public class LikesPage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the LikesPage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public LikesPage(TembooSession session) : base(session, "/Library/Facebook/Reading/LikesPage")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved from the final OAuth step.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The ID of the page to check against the acting user's likes.
         /// </summary>
         /// <param name="value">Value of the PageID input for this Choreo.</param>
         public void setPageID(String value) {
             base.addInput ("PageID", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user whose likes you want to check the PageID against. Defaults to "me" indicating the authenticated user.
         /// </summary>
         /// <param name="value">Value of the ProfileID input for this Choreo.</param>
         public void setProfileID(String value) {
             base.addInput ("ProfileID", value);
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
        /// <returns>A LikesPageResultSet containing execution metadata and results.</returns>
        new public LikesPageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            LikesPageResultSet results = new JavaScriptSerializer().Deserialize<LikesPageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the LikesPage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class LikesPageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Likes" output from this Choreo execution
        /// <returns>String - (boolean) Returns as true or false depending on whether or not the PageID specified is liked by the acting user.</returns>
        /// </summary>
        public String Likes
        {
            get
            {
                return (String) base.Output["Likes"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Facebook. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
