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
    /// TaggableFriends
    /// Returns a list of friends that can be tagged or mentioned in stories published to Facebook.
    /// </summary>
    public class TaggableFriends : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the TaggableFriends Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public TaggableFriends(TembooSession session) : base(session, "/Library/Facebook/Reading/TaggableFriends")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved from the final step of the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) A cursor that points to the end of the page of data that has been returned. You can pass this cursor to retrievet he next page of results.
         /// </summary>
         /// <param name="value">Value of the After input for this Choreo.</param>
         public void setAfter(String value) {
             base.addInput ("After", value);
         }
         /// <summary>
         /// (optional, string) A cursor that points to the start of the page of data that has been returned. You can pass this cursor to retrieve the previous page of results.
         /// </summary>
         /// <param name="value">Value of the Before input for this Choreo.</param>
         public void setBefore(String value) {
             base.addInput ("Before", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of fields to return (i.e. id,name).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, integer) Limits the number of records returned in the response.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The id of the profile to retrieve tagged places for. Defaults to "me" indicating the authenticated user.
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
        /// <returns>A TaggableFriendsResultSet containing execution metadata and results.</returns>
        new public TaggableFriendsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            TaggableFriendsResultSet results = new JavaScriptSerializer().Deserialize<TaggableFriendsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the TaggableFriends Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class TaggableFriendsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "HasNext" output from this Choreo execution
        /// <returns>String - (boolean) A boolean flag indicating that a next page exists.</returns>
        /// </summary>
        public String HasNext
        {
            get
            {
                return (String) base.Output["HasNext"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "HasPrevious" output from this Choreo execution
        /// <returns>String - (boolean) A boolean flag indicating that a previous page exists.</returns>
        /// </summary>
        public String HasPrevious
        {
            get
            {
                return (String) base.Output["HasPrevious"];
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
