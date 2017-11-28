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

namespace Temboo.Library.Flickr.Photos
{
    /// <summary>
    /// Upload
    /// Uploads a photo to Flickr.
    /// </summary>
    public class Upload : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Upload Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Upload(TembooSession session) : base(session, "/Library/Flickr/Photos/Upload")
        {
        }

         /// <summary>
         /// (conditional, string) The base-64 encoded file contents to upload. Required unless using the URL input.
         /// </summary>
         /// <param name="value">Value of the ImageFileContents input for this Choreo.</param>
         public void setImageFileContents(String value) {
             base.addInput ("ImageFileContents", value);
         }
         /// <summary>
         /// (required, string) The API Key provided by Flickr (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The API Secret provided by Flickr (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
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
         /// (optional, integer) The type of content you are uploading. Set to 1 for Photo, 2 for Screenshot, or 3 for Other. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the ContentType input for this Choreo.</param>
         public void setContentType(String value) {
             base.addInput ("ContentType", value);
         }
         /// <summary>
         /// (optional, string) A description for the photo.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, integer) Set to 1 to allow photos to appear in global search results, 2 to be hidden from public searches. Defaults to 2.
         /// </summary>
         /// <param name="value">Value of the Hidden input for this Choreo.</param>
         public void setHidden(String value) {
             base.addInput ("Hidden", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 0 for no, 1 for yes. Specifies who can view the photo. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the IsFamily input for this Choreo.</param>
         public void setIsFamily(String value) {
             base.addInput ("IsFamily", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 0 for no, 1 for yes. Specifies who can view the photo. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the IsFriend input for this Choreo.</param>
         public void setIsFriend(String value) {
             base.addInput ("IsFriend", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 0 for no, 1 for yes. Specifies who can view the photo. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the IsPublic input for this Choreo.</param>
         public void setIsPublic(String value) {
             base.addInput ("IsPublic", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml and json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) Set value to 1 for Safe, 2 for Moderate, or 3 for Restricted. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the SafetyLevel input for this Choreo.</param>
         public void setSafetyLevel(String value) {
             base.addInput ("SafetyLevel", value);
         }
         /// <summary>
         /// (optional, string) A list of tags to apply to the photo. Separate multiple tags with spaces.
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (optional, string) The title of the photo you're uploading.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (conditional, string) A url for a photo to upload to Flickr. Required unless specifying the ImageFileContents.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UploadResultSet containing execution metadata and results.</returns>
        new public UploadResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UploadResultSet results = new JavaScriptSerializer().Deserialize<UploadResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Upload Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UploadResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Flickr.</returns>
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
