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

namespace Temboo.Library.Facebook.Publishing
{
    /// <summary>
    /// UploadPhoto
    /// Uploads a photo to a given album.
    /// </summary>
    public class UploadPhoto : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UploadPhoto Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UploadPhoto(TembooSession session) : base(session, "/Library/Facebook/Publishing/UploadPhoto")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved from the final step of the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The id of the album to upload the photo to.
         /// </summary>
         /// <param name="value">Value of the AlbumID input for this Choreo.</param>
         public void setAlbumID(String value) {
             base.addInput ("AlbumID", value);
         }
         /// <summary>
         /// (optional, string) A message to attach to the photo.
         /// </summary>
         /// <param name="value">Value of the Message input for this Choreo.</param>
         public void setMessage(String value) {
             base.addInput ("Message", value);
         }
         /// <summary>
         /// (conditional, string) The Base64 encoded image to upload. This is required unless using the URL input to publish the photo.
         /// </summary>
         /// <param name="value">Value of the Photo input for this Choreo.</param>
         public void setPhoto(String value) {
             base.addInput ("Photo", value);
         }
         /// <summary>
         /// (optional, string) The ID of a location where the photo was taken.
         /// </summary>
         /// <param name="value">Value of the Place input for this Choreo.</param>
         public void setPlace(String value) {
             base.addInput ("Place", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the Source input for this Choreo.</param>
         public void setSource(String value) {
             base.addInput ("Source", value);
         }
         /// <summary>
         /// (conditional, string) A URL to a hosted photo that should be uploaded. This is required unless providing a Base64 encoded image for the Photo input.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UploadPhotoResultSet containing execution metadata and results.</returns>
        new public UploadPhotoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UploadPhotoResultSet results = new JavaScriptSerializer().Deserialize<UploadPhotoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UploadPhoto Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UploadPhotoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Facebook. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
