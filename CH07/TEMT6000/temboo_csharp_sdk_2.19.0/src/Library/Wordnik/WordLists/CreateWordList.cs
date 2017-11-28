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

namespace Temboo.Library.Wordnik.WordLists
{
    /// <summary>
    /// CreateWordList
    /// Creates a new word list for the specified user.
    /// </summary>
    public class CreateWordList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateWordList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateWordList(TembooSession session) : base(session, "/Library/Wordnik/WordLists/CreateWordList")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from Wordnik.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) A description of the list to create.
         /// </summary>
         /// <param name="value">Value of the ListDescription input for this Choreo.</param>
         public void setListDescription(String value) {
             base.addInput ("ListDescription", value);
         }
         /// <summary>
         /// (required, string) Name of list to create.
         /// </summary>
         /// <param name="value">Value of the ListName input for this Choreo.</param>
         public void setListName(String value) {
             base.addInput ("ListName", value);
         }
         /// <summary>
         /// (optional, string) Determines whether the list to cretae is public or private. Acceptable values: PUBLIC or PRIVATE.
         /// </summary>
         /// <param name="value">Value of the ListStatus input for this Choreo.</param>
         public void setListStatus(String value) {
             base.addInput ("ListStatus", value);
         }
         /// <summary>
         /// (required, string) The Password of the Wordnik account.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) The Username of the Wordnik account.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateWordListResultSet containing execution metadata and results.</returns>
        new public CreateWordListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateWordListResultSet results = new JavaScriptSerializer().Deserialize<CreateWordListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateWordList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateWordListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Wordnik.</returns>
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
