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
    /// ProfileFeed
    /// Retrieves the feed from a specified user's Wall.
    /// </summary>
    public class ProfileFeed : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ProfileFeed Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ProfileFeed(TembooSession session) : base(session, "/Library/Facebook/Reading/ProfileFeed")
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
         /// (optional, string) Filters results by a given "edge". Valid values are: links, posts, statuses, or tagged.
         /// </summary>
         /// <param name="value">Value of the Edge input for this Choreo.</param>
         public void setEdge(String value) {
             base.addInput ("Edge", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of fields to return (i.e. id,name).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) Retrieve only posts that match a particular stream filter. See Choreo notes for valid filters that can be used here.
         /// </summary>
         /// <param name="value">Value of the Filter input for this Choreo.</param>
         public void setFilter(String value) {
             base.addInput ("Filter", value);
         }
         /// <summary>
         /// (optional, integer) Used to page through results. Limits the number of records returned in the response.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) Used to page through results. Returns results starting from the specified number.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, string) The id of the profile to retrieve a feed for. Defaults to "me" indicating the authenticated user.
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
         /// (optional, date) Used for time-based pagination. Values can be a unix timestamp or any date accepted by strtotime.
         /// </summary>
         /// <param name="value">Value of the Since input for this Choreo.</param>
         public void setSince(String value) {
             base.addInput ("Since", value);
         }
         /// <summary>
         /// (optional, date) Used for time-based pagination. Values can be a unix timestamp or any date accepted by strtotime.
         /// </summary>
         /// <param name="value">Value of the Until input for this Choreo.</param>
         public void setUntil(String value) {
             base.addInput ("Until", value);
         }
         /// <summary>
         /// (optional, string) Can be set to "location" to retrieve only posts associated with a location attached.
         /// </summary>
         /// <param name="value">Value of the With input for this Choreo.</param>
         public void setWith(String value) {
             base.addInput ("With", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ProfileFeedResultSet containing execution metadata and results.</returns>
        new public ProfileFeedResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ProfileFeedResultSet results = new JavaScriptSerializer().Deserialize<ProfileFeedResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ProfileFeed Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ProfileFeedResultSet : Temboo.Core.ResultSet
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
