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
    /// CreateSharedLink
    /// Creates a shared link for a particular folder.
    /// </summary>
    public class CreateSharedLink : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateSharedLink Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateSharedLink(TembooSession session) : base(session, "/Library/Box/Folders/CreateSharedLink")
        {
        }

         /// <summary>
         /// (required, json) A JSON object  representing the item?s shared link and associated permissions. See documentation for formatting examples.
         /// </summary>
         /// <param name="value">Value of the SharedLink input for this Choreo.</param>
         public void setSharedLink(String value) {
             base.addInput ("SharedLink", value);
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
         /// (required, string) The id of the folder to get a shared link for.
         /// </summary>
         /// <param name="value">Value of the FolderID input for this Choreo.</param>
         public void setFolderID(String value) {
             base.addInput ("FolderID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateSharedLinkResultSet containing execution metadata and results.</returns>
        new public CreateSharedLinkResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateSharedLinkResultSet results = new JavaScriptSerializer().Deserialize<CreateSharedLinkResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateSharedLink Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateSharedLinkResultSet : Temboo.Core.ResultSet
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
