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

namespace Temboo.Library.NPR.StoryFinder
{
    /// <summary>
    /// GetListByID
    /// Retrieves a list of NPR categories from a specified list type ID.
    /// </summary>
    public class GetListByID : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetListByID Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetListByID(TembooSession session) : base(session, "/Library/NPR/StoryFinder/GetListByID")
        {
        }

         /// <summary>
         /// (optional, integer) Returns only items which are assigned to the given topic ID. For example, if Id=3006 and ChildrenOf=1008 only recent series which are assigned to "Arts & Life" are returned.
         /// </summary>
         /// <param name="value">Value of the ChildrenOf input for this Choreo.</param>
         public void setChildrenOf(String value) {
             base.addInput ("ChildrenOf", value);
         }
         /// <summary>
         /// (optional, boolean) If set to "1", returns only topics which are not subtopics of another topic.
         /// </summary>
         /// <param name="value">Value of the HideChildren input for this Choreo.</param>
         public void setHideChildren(String value) {
             base.addInput ("HideChildren", value);
         }
         /// <summary>
         /// (required, integer) The id of the list type you want to retrieve. For example, the list type id for Music Genres is 3218).
         /// </summary>
         /// <param name="value">Value of the Id input for this Choreo.</param>
         public void setId(String value) {
             base.addInput ("Id", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are xml (the default), and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) Returns only items with at least this number of associated stories.
         /// </summary>
         /// <param name="value">Value of the StoryCountAll input for this Choreo.</param>
         public void setStoryCountAll(String value) {
             base.addInput ("StoryCountAll", value);
         }
         /// <summary>
         /// (optional, integer) Returns only items with at least this number of associated stories published in the last month.
         /// </summary>
         /// <param name="value">Value of the StoryCountMonth input for this Choreo.</param>
         public void setStoryCountMonth(String value) {
             base.addInput ("StoryCountMonth", value);
         }
         /// <summary>
         /// (optional, integer) Returns only items with at least this number of associated stories published today.
         /// </summary>
         /// <param name="value">Value of the StoryCountToday input for this Choreo.</param>
         public void setStoryCountToday(String value) {
             base.addInput ("StoryCountToday", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetListByIDResultSet containing execution metadata and results.</returns>
        new public GetListByIDResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetListByIDResultSet results = new JavaScriptSerializer().Deserialize<GetListByIDResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetListByID Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetListByIDResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from NPR.</returns>
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
