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
    /// Columns
    /// Retrieves a list of NPR column titles and corresponding IDs. Also used to look up the IDs of specific NPR columns by specifying the title as an optional parameter.
    /// </summary>
    public class Columns : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Columns Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Columns(TembooSession session) : base(session, "/Library/NPR/StoryFinder/Columns")
        {
        }

         /// <summary>
         /// (optional, string) The specific column title to return. Multiple column titles can be specified separated by commas (i.e. Book Reviews,My Guilty Pleasure). Column IDs are returned when this input is used.
         /// </summary>
         /// <param name="value">Value of the Column input for this Choreo.</param>
         public void setColumn(String value) {
             base.addInput ("Column", value);
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
        /// <returns>A ColumnsResultSet containing execution metadata and results.</returns>
        new public ColumnsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ColumnsResultSet results = new JavaScriptSerializer().Deserialize<ColumnsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Columns Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ColumnsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Id" output from this Choreo execution
        /// <returns>String - (integer) The ID of the column. This is only returned when the Column input is specified. When columns are specified, this will be a list of IDs separated by commas.</returns>
        /// </summary>
        public String Id
        {
            get
            {
                return (String) base.Output["Id"];
            }
        }
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
