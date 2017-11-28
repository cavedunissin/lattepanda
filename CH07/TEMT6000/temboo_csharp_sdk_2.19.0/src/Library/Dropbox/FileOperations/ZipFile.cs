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

namespace Temboo.Library.Dropbox.FileOperations
{
    /// <summary>
    /// ZipFile
    /// Creates a zipped version of the specified Dropbox file and returns a shareable link to the new compressed file.
    /// </summary>
    public class ZipFile : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ZipFile Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ZipFile(TembooSession session) : base(session, "/Library/Dropbox/FileOperations/ZipFile")
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
         /// (required, string) The name of the Dropbox file you want to zip.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (conditional, string) The name of the folder that contains the file you want to zip. A path to a sub-folder is also valid (i.e. RootFolder/SubFolder). Not required if the file is at the root level.
         /// </summary>
         /// <param name="value">Value of the Folder input for this Choreo.</param>
         public void setFolder(String value) {
             base.addInput ("Folder", value);
         }
         /// <summary>
         /// (optional, string) Defaults to "auto" which automatically determines the root folder using your app's permission level. Other options are "sandbox" (App Folder) and "dropbox" (Full Dropbox).
         /// </summary>
         /// <param name="value">Value of the Root input for this Choreo.</param>
         public void setRoot(String value) {
             base.addInput ("Root", value);
         }
         /// <summary>
         /// (optional, string) The name of the folder to put the new zip file in.A path to a sub-folder is also valid (i.e. RootFolder/SubFolder).  When not specified, the zip file will be put in the root folder.
         /// </summary>
         /// <param name="value">Value of the ZipFileLocation input for this Choreo.</param>
         public void setZipFileLocation(String value) {
             base.addInput ("ZipFileLocation", value);
         }
         /// <summary>
         /// (optional, string) The name of the zip file that will be created. If not specified, the original file name will be used with a .zip extension.
         /// </summary>
         /// <param name="value">Value of the ZipFileName input for this Choreo.</param>
         public void setZipFileName(String value) {
             base.addInput ("ZipFileName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ZipFileResultSet containing execution metadata and results.</returns>
        new public ZipFileResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ZipFileResultSet results = new JavaScriptSerializer().Deserialize<ZipFileResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ZipFile Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ZipFileResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "URL" output from this Choreo execution
        /// <returns>String - (string) The shared link for the new zip file.</returns>
        /// </summary>
        public String URL
        {
            get
            {
                return (String) base.Output["URL"];
            }
        }
    }
}
