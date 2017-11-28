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

namespace Temboo.Library.Basecamp
{
    /// <summary>
    /// ReorderItems
    /// Reorders the items in a specified To-do list.
    /// </summary>
    public class ReorderItems : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ReorderItems Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ReorderItems(TembooSession session) : base(session, "/Library/Basecamp/ReorderItems")
        {
        }

         /// <summary>
         /// (required, string) A valid Basecamp account name. This is the first part of the account's URL.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (required, integer) The ID number for the first item in the list.
         /// </summary>
         /// <param name="value">Value of the FirstItemID input for this Choreo.</param>
         public void setFirstItemID(String value) {
             base.addInput ("FirstItemID", value);
         }
         /// <summary>
         /// (required, integer) The ID for the To-do list the items of which you're reordering.
         /// </summary>
         /// <param name="value">Value of the ListID input for this Choreo.</param>
         public void setListID(String value) {
             base.addInput ("ListID", value);
         }
         /// <summary>
         /// (required, password) The Basecamp account password. Use the value 'X' when specifying an API Key for the Username input.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, integer) The ID number for the second item in the list.
         /// </summary>
         /// <param name="value">Value of the SecondItemID input for this Choreo.</param>
         public void setSecondItemID(String value) {
             base.addInput ("SecondItemID", value);
         }
         /// <summary>
         /// (optional, integer) The ID number for the third item in the list.
         /// </summary>
         /// <param name="value">Value of the ThirdItemID input for this Choreo.</param>
         public void setThirdItemID(String value) {
             base.addInput ("ThirdItemID", value);
         }
         /// <summary>
         /// (required, string) A Basecamp account username or API Key.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ReorderItemsResultSet containing execution metadata and results.</returns>
        new public ReorderItemsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ReorderItemsResultSet results = new JavaScriptSerializer().Deserialize<ReorderItemsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ReorderItems Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ReorderItemsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - No response is returned from Basecamp for reorder items requests.</returns>
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
