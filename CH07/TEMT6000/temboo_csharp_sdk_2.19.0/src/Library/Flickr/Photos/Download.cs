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
    /// Download
    /// Retrieves a photo from a constructed source URL and returns the file content as Base64 encoded data.
    /// </summary>
    public class Download : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Download Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Download(TembooSession session) : base(session, "/Library/Flickr/Photos/Download")
        {
        }

         /// <summary>
         /// (conditional, integer) The farm id associated with the photo. Required unless providing the URL.
         /// </summary>
         /// <param name="value">Value of the FarmID input for this Choreo.</param>
         public void setFarmID(String value) {
             base.addInput ("FarmID", value);
         }
         /// <summary>
         /// (optional, string) The image type. Valid values are: jpg, png, or gif. Defaults to "jpg".
         /// </summary>
         /// <param name="value">Value of the ImageType input for this Choreo.</param>
         public void setImageType(String value) {
             base.addInput ("ImageType", value);
         }
         /// <summary>
         /// (conditional, integer) The id of the photo you to download.
         /// </summary>
         /// <param name="value">Value of the PhotoID input for this Choreo.</param>
         public void setPhotoID(String value) {
             base.addInput ("PhotoID", value);
         }
         /// <summary>
         /// (conditional, string) The secret associated with the photo. Required unless providing the URL.
         /// </summary>
         /// <param name="value">Value of the Secret input for this Choreo.</param>
         public void setSecret(String value) {
             base.addInput ("Secret", value);
         }
         /// <summary>
         /// (conditional, integer) The server id associated with the photo. Required unless providing the URL.
         /// </summary>
         /// <param name="value">Value of the ServerID input for this Choreo.</param>
         public void setServerID(String value) {
             base.addInput ("ServerID", value);
         }
         /// <summary>
         /// (conditional, string) The url to download the photo from. Required unless providing the Secret, ServerID, and FarmID parameters.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DownloadResultSet containing execution metadata and results.</returns>
        new public DownloadResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DownloadResultSet results = new JavaScriptSerializer().Deserialize<DownloadResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Download Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DownloadResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) The Base64 encoded image content.</returns>
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
