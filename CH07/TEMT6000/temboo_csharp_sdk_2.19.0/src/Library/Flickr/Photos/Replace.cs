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
    /// Replace
    ///  Replaces a photo that has already been uploaded to Flickr.
    /// </summary>
    public class Replace : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Replace Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Replace(TembooSession session) : base(session, "/Library/Flickr/Photos/Replace")
        {
        }

         /// <summary>
         /// (conditional, string) The base-64 encoded file contents to replace. Required unless using the URL input.
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
         /// (optional, boolean) Set to 1 to replace photos in async mode. This can be used if you don't want to wait around for an upload to complete.
         /// </summary>
         /// <param name="value">Value of the Async input for this Choreo.</param>
         public void setAsync(String value) {
             base.addInput ("Async", value);
         }
         /// <summary>
         /// (required, string) The ID of the photo to replace.
         /// </summary>
         /// <param name="value">Value of the PhotoID input for this Choreo.</param>
         public void setPhotoID(String value) {
             base.addInput ("PhotoID", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml and json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) A url for a photo to use as the replacement. Required unless specifying the ImageFileContents.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ReplaceResultSet containing execution metadata and results.</returns>
        new public ReplaceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ReplaceResultSet results = new JavaScriptSerializer().Deserialize<ReplaceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Replace Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ReplaceResultSet : Temboo.Core.ResultSet
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
