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

namespace Temboo.Library.Dropbox.FilesAndMetadata
{
    /// <summary>
    /// ListFolderContents
    /// Retrieves metadata (including folder contents) for a folder or file in Dropbox.
    /// </summary>
    public class ListFolderContents : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListFolderContents Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListFolderContents(TembooSession session) : base(session, "/Library/Dropbox/FilesAndMetadata/ListFolderContents")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, string) The App Key provided by Dropbox (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the AppKey input for this Choreo.</param>
         public void setAppKey(String value) {
             base.addInput ("AppKey", value);
         }
         /// <summary>
         /// (required, string) The App Secret provided by Dropbox (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the AppSecret input for this Choreo.</param>
         public void setAppSecret(String value) {
             base.addInput ("AppSecret", value);
         }
         /// <summary>
         /// (optional, integer) Dropbox will not return a list that exceeds this specified limit. Defaults to 10,000.
         /// </summary>
         /// <param name="value">Value of the FileLimit input for this Choreo.</param>
         public void setFileLimit(String value) {
             base.addInput ("FileLimit", value);
         }
         /// <summary>
         /// (optional, string) The path to a folder for which to retrieve metadata (i.e. /RootFolder/SubFolder). Note that a path to file can also be passed.
         /// </summary>
         /// <param name="value">Value of the Folder input for this Choreo.</param>
         public void setFolder(String value) {
             base.addInput ("Folder", value);
         }
         /// <summary>
         /// (optional, string) The value of a hash field from a previous request to get metadata on a folder. When provided, a 304 (not Modified) status code is returned instead of a folder listing if no changes have been made.
         /// </summary>
         /// <param name="value">Value of the Hash input for this Choreo.</param>
         public void setHash(String value) {
             base.addInput ("Hash", value);
         }
         /// <summary>
         /// (optional, boolean) Only applicable when List is set. If this parameter is set to true, contents will include the metadata of deleted children.
         /// </summary>
         /// <param name="value">Value of the IncludeDeleted input for this Choreo.</param>
         public void setIncludeDeleted(String value) {
             base.addInput ("IncludeDeleted", value);
         }
         /// <summary>
         /// (optional, boolean) If true (the default), the folder's metadata will include a contents field with a list of metadata entries for the contents of the folder.
         /// </summary>
         /// <param name="value">Value of the List input for this Choreo.</param>
         public void setList(String value) {
             base.addInput ("List", value);
         }
         /// <summary>
         /// (optional, string) If your app supports any language other than English, insert the appropriate IETF language tag, and the metadata returned will have its size field translated based on the given locale (e.g., pt-BR).
         /// </summary>
         /// <param name="value">Value of the Locale input for this Choreo.</param>
         public void setLocale(String value) {
             base.addInput ("Locale", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) When including a particular revision number, only the metadata for that revision will be returned.
         /// </summary>
         /// <param name="value">Value of the Revision input for this Choreo.</param>
         public void setRevision(String value) {
             base.addInput ("Revision", value);
         }
         /// <summary>
         /// (optional, string) Defaults to "auto" which automatically determines the root folder using your app's permission level. Other options are "sandbox" (App Folder) and "dropbox" (Full Dropbox).
         /// </summary>
         /// <param name="value">Value of the Root input for this Choreo.</param>
         public void setRoot(String value) {
             base.addInput ("Root", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListFolderContentsResultSet containing execution metadata and results.</returns>
        new public ListFolderContentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListFolderContentsResultSet results = new JavaScriptSerializer().Deserialize<ListFolderContentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListFolderContents Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListFolderContentsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Dropbox.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Dropbox. Corresponds to the ResponseFormat input. Defaults to json.</returns>
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
