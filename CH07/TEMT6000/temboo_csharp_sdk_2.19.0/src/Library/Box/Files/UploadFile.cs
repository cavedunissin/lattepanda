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

namespace Temboo.Library.Box.Files
{
    /// <summary>
    /// UploadFile
    /// Uploads a new file to a user's account. This can also be used when updating the contents of an existing file.
    /// </summary>
    public class UploadFile : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UploadFile Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UploadFile(TembooSession session) : base(session, "/Library/Box/Files/UploadFile")
        {
        }

         /// <summary>
         /// (conditional, string) The Base64 encoded contents of the file you want to upload.
         /// </summary>
         /// <param name="value">Value of the FileContents input for this Choreo.</param>
         public void setFileContents(String value) {
             base.addInput ("FileContents", value);
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
         /// (optional, string) When providing the id of an existing file, the content of the file will be updated.
         /// </summary>
         /// <param name="value">Value of the FileID input for this Choreo.</param>
         public void setFileID(String value) {
             base.addInput ("FileID", value);
         }
         /// <summary>
         /// (conditional, string) The name of the new file to upload. Note that when providing the FileID in order to perform an update to a file, it is not necessary to provide the FileName.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (optional, string) The ID of the target folder to upload the file to. Defaults to 0 indicating the root folder.
         /// </summary>
         /// <param name="value">Value of the FolderID input for this Choreo.</param>
         public void setFolderID(String value) {
             base.addInput ("FolderID", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UploadFileResultSet containing execution metadata and results.</returns>
        new public UploadFileResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UploadFileResultSet results = new JavaScriptSerializer().Deserialize<UploadFileResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UploadFile Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UploadFileResultSet : Temboo.Core.ResultSet
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
