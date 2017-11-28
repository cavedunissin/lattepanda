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
    /// ZipFile
    /// Creates a zipped version of the specified Box file and returns a link to the new compressed file.
    /// </summary>
    public class ZipFile : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ZipFile Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ZipFile(TembooSession session) : base(session, "/Library/Box/Files/ZipFile")
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
         /// (required, string) The id of the file to zip.
         /// </summary>
         /// <param name="value">Value of the FileID input for this Choreo.</param>
         public void setFileID(String value) {
             base.addInput ("FileID", value);
         }
         /// <summary>
         /// (conditional, json) A JSON object  representing the item?s shared link and associated permissions. See documentation for formatting examples.
         /// </summary>
         /// <param name="value">Value of the SharedLink input for this Choreo.</param>
         public void setSharedLink(String value) {
             base.addInput ("SharedLink", value);
         }
         /// <summary>
         /// (conditional, string) The id of the folder to put the new zip file in. When not specified, the zip file will be put in the root folder.
         /// </summary>
         /// <param name="value">Value of the ZipFileLocation input for this Choreo.</param>
         public void setZipFileLocation(String value) {
             base.addInput ("ZipFileLocation", value);
         }
         /// <summary>
         /// (required, string) The name of the zip file that will be created.
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
        /// <returns>String - (string) The url for the newly created zip file.</returns>
        /// </summary>
        public String URL
        {
            get
            {
                return (String) base.Output["URL"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) The response from Box. This contains the newly created zip file metadata.</returns>
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
