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

namespace Temboo.Library.Box.Folders
{
    /// <summary>
    /// CopyFolder
    /// Creates a copy of a folder in another folder.
    /// </summary>
    public class CopyFolder : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CopyFolder Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CopyFolder(TembooSession session) : base(session, "/Library/Box/Folders/CopyFolder")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved during the OAuth2 process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user. Only used for enterprise administrators to make API calls for their managed users.
         /// </summary>
         /// <param name="value">Value of the AsUser input for this Choreo.</param>
         public void setAsUser(String value) {
             base.addInput ("AsUser", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (required, string) The id of the folder to copy.
         /// </summary>
         /// <param name="value">Value of the FolderID input for this Choreo.</param>
         public void setFolderID(String value) {
             base.addInput ("FolderID", value);
         }
         /// <summary>
         /// (required, string) An optional new name for the folder.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (required, string) The ID of the destination folder to copy the folder to.
         /// </summary>
         /// <param name="value">Value of the ParentID input for this Choreo.</param>
         public void setParentID(String value) {
             base.addInput ("ParentID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CopyFolderResultSet containing execution metadata and results.</returns>
        new public CopyFolderResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CopyFolderResultSet results = new JavaScriptSerializer().Deserialize<CopyFolderResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CopyFolder Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CopyFolderResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Box.</returns>
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
