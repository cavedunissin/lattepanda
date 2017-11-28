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
    /// RenameTag
    /// Renames a specified tag.
    /// </summary>
    public class RenameTag : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RenameTag Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RenameTag(TembooSession session) : base(session, "/Library/Delicious/RenameTag")
        {
        }

         /// <summary>
         /// (required, string) The new tag name.
         /// </summary>
         /// <param name="value">Value of the NewTag input for this Choreo.</param>
         public void setNewTag(String value) {
             base.addInput ("NewTag", value);
         }
         /// <summary>
         /// (required, string) The existing tag to rename.
         /// </summary>
         /// <param name="value">Value of the OldTag input for this Choreo.</param>
         public void setOldTag(String value) {
             base.addInput ("OldTag", value);
         }
         /// <summary>
         /// (required, password) The password that corresponds to the specified Delicious account username.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
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
        /// <returns>A RenameTagResultSet containing execution metadata and results.</returns>
        new public RenameTagResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RenameTagResultSet results = new JavaScriptSerializer().Deserialize<RenameTagResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RenameTag Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RenameTagResultSet : Temboo.Core.ResultSet
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
