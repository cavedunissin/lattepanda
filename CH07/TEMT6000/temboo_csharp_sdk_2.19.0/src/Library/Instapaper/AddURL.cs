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

namespace Temboo.Library.Instapaper
{
    /// <summary>
    /// AddURL
    /// Add a document to an Instapaper account.
    /// </summary>
    public class AddURL : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddURL Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddURL(TembooSession session) : base(session, "/Library/Instapaper/AddURL")
        {
        }

         /// <summary>
         /// (required, password) Your Instapaper password.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, string) Enter a description of the URL being added.
         /// </summary>
         /// <param name="value">Value of the Selection input for this Choreo.</param>
         public void setSelection(String value) {
             base.addInput ("Selection", value);
         }
         /// <summary>
         /// (optional, string) Enter a titile for the uploaded URL. If no title is provided, Instapaper will crawl the URL to detect a title.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (required, string) Enter the URL of the document that is being added to an Instapaper account.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }
         /// <summary>
         /// (required, string) Your Instapaper username.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddURLResultSet containing execution metadata and results.</returns>
        new public AddURLResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddURLResultSet results = new JavaScriptSerializer().Deserialize<AddURLResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddURL Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddURLResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (integer) The response from Instapaper. Successful reqests will return a 201 status code.</returns>
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
