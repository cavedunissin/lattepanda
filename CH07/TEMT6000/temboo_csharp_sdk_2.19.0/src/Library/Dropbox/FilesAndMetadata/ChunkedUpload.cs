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
    /// ChunkedUpload
    /// Uploads larger files to Dropbox in multiple chunks, and offers a way to resume if an upload gets interrupted.
    /// </summary>
    public class ChunkedUpload : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ChunkedUpload Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ChunkedUpload(TembooSession session) : base(session, "/Library/Dropbox/FilesAndMetadata/ChunkedUpload")
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
         /// (conditional, string) A Base64 encoded chunk of data from the file being uploaded. If resuming and upload, the chunk should begin at the number of bytes into the file that equals the NextOffset.
         /// </summary>
         /// <param name="value">Value of the Chunk input for this Choreo.</param>
         public void setChunk(String value) {
             base.addInput ("Chunk", value);
         }
         /// <summary>
         /// (conditional, string) The byte offset of this chunk, relative to the beginning of the full file. This is not required when uploading the first chunk of a file.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the upload session returned after uploading the initial file chunk. This is not required when uploading the first chunk of a file. This value is returned in the UploadSessionID output.
         /// </summary>
         /// <param name="value">Value of the UploadID input for this Choreo.</param>
         public void setUploadID(String value) {
             base.addInput ("UploadID", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ChunkedUploadResultSet containing execution metadata and results.</returns>
        new public ChunkedUploadResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ChunkedUploadResultSet results = new JavaScriptSerializer().Deserialize<ChunkedUploadResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ChunkedUpload Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ChunkedUploadResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Expires" output from this Choreo execution
        /// <returns>String - (string) The expiration time of the upload.</returns>
        /// </summary>
        public String Expires
        {
            get
            {
                return (String) base.Output["Expires"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "NextOffset" output from this Choreo execution
        /// <returns>String - (string) The current byte offset that the server will expect. This value can be passed to the Offset input on subsequent requests when uploading chunks repeatedly.</returns>
        /// </summary>
        public String NextOffset
        {
            get
            {
                return (String) base.Output["NextOffset"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "UploadSessionID" output from this Choreo execution
        /// <returns>String - (string) The upload ID returned after uploading an initial file chunk. This can be passed to the UploadID input for uploading subsequent chunks, and finally to the CommitChunkedUpload Choreo.</returns>
        /// </summary>
        public String UploadSessionID
        {
            get
            {
                return (String) base.Output["UploadSessionID"];
            }
        }
    }
}
