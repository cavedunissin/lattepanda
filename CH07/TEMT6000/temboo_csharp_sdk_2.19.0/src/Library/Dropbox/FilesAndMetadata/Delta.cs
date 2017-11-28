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
    /// Delta
    /// Allows you keep up with changes to files and folders in a user's Dropbox.
    /// </summary>
    public class Delta : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Delta Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Delta(TembooSession session) : base(session, "/Library/Dropbox/FilesAndMetadata/Delta")
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
         /// (optional, string) A string that is used to keep track of your current state. On the next call pass in this value to return delta entries that have been recorded since the cursor was returned.
         /// </summary>
         /// <param name="value">Value of the Cursor input for this Choreo.</param>
         public void setCursor(String value) {
             base.addInput ("Cursor", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, each file will include a photo_info dictionary for photos and a video_info dictionary for videos with additional media info.
         /// </summary>
         /// <param name="value">Value of the IncludeMediaInfo input for this Choreo.</param>
         public void setIncludeMediaInfo(String value) {
             base.addInput ("IncludeMediaInfo", value);
         }
         /// <summary>
         /// (optional, string) The metadata returned will have its size field translated based on the given locale.
         /// </summary>
         /// <param name="value">Value of the Locale input for this Choreo.</param>
         public void setLocale(String value) {
             base.addInput ("Locale", value);
         }
         /// <summary>
         /// (optional, string) Filters the response to only include entries at or under the specified path.
         /// </summary>
         /// <param name="value">Value of the PathPrefix input for this Choreo.</param>
         public void setPathPrefix(String value) {
             base.addInput ("PathPrefix", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeltaResultSet containing execution metadata and results.</returns>
        new public DeltaResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeltaResultSet results = new JavaScriptSerializer().Deserialize<DeltaResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Delta Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeltaResultSet : Temboo.Core.ResultSet
    {
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
