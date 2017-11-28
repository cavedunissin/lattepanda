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

namespace Temboo.Library.eBay.Trading
{
    /// <summary>
    /// UploadSiteHostedPictures
    /// Allows you to uploads a picture to eBay Picture Services by specifying a binary attachment or image URL.
    /// </summary>
    public class UploadSiteHostedPictures : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UploadSiteHostedPictures Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UploadSiteHostedPictures(TembooSession session) : base(session, "/Library/eBay/Trading/UploadSiteHostedPictures")
        {
        }

         /// <summary>
         /// (optional, integer) The number of days to extend the expiration date for the specified image, after a listing has ended.
         /// </summary>
         /// <param name="value">Value of the ExtensionInDays input for this Choreo.</param>
         public void setExtensionInDays(String value) {
             base.addInput ("ExtensionInDays", value);
         }
         /// <summary>
         /// (conditional, string) The URL of an image to upload. Required unless providing PictureData. Max image size is 7 MB. Max URL length is 1024. Formats supported are: JPG, GIF, PNG, BMP, and TIF.
         /// </summary>
         /// <param name="value">Value of the ExternalPictureURL input for this Choreo.</param>
         public void setExternalPictureURL(String value) {
             base.addInput ("ExternalPictureURL", value);
         }
         /// <summary>
         /// (conditional, string) The Base64 encoded string for an the image data. Required unless providing the ExternalPictureURL. Max image size is 7 MB. Formats supported are: JPG, GIF, PNG, BMP, and TIF.
         /// </summary>
         /// <param name="value">Value of the PictureData input for this Choreo.</param>
         public void setPictureData(String value) {
             base.addInput ("PictureData", value);
         }
         /// <summary>
         /// (optional, string) The name of the picture.
         /// </summary>
         /// <param name="value">Value of the PictureName input for this Choreo.</param>
         public void setPictureName(String value) {
             base.addInput ("PictureName", value);
         }
         /// <summary>
         /// (optional, string) The image sizes that will be generated. Valid values are: Standard and Supersize.
         /// </summary>
         /// <param name="value">Value of the PictureSet input for this Choreo.</param>
         public void setPictureSet(String value) {
             base.addInput ("PictureSet", value);
         }
         /// <summary>
         /// (optional, string) Indicates that an uploaded picture is available to a seller on the eBay site. Valid values are: Add and ClearAndAdd.
         /// </summary>
         /// <param name="value">Value of the PictureUploadPolicy input for this Choreo.</param>
         public void setPictureUploadPolicy(String value) {
             base.addInput ("PictureUploadPolicy", value);
         }
         /// <summary>
         /// (optional, string) The type of watermark that should be applied to the pictures hosted by the eBay Picture Services. Valid values are: User and Icon.
         /// </summary>
         /// <param name="value">Value of the PictureWatermark input for this Choreo.</param>
         public void setPictureWatermark(String value) {
             base.addInput ("PictureWatermark", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (required, string) A valid eBay Auth Token.
         /// </summary>
         /// <param name="value">Value of the UserToken input for this Choreo.</param>
         public void setUserToken(String value) {
             base.addInput ("UserToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UploadSiteHostedPicturesResultSet containing execution metadata and results.</returns>
        new public UploadSiteHostedPicturesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UploadSiteHostedPicturesResultSet results = new JavaScriptSerializer().Deserialize<UploadSiteHostedPicturesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UploadSiteHostedPictures Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UploadSiteHostedPicturesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from eBay.</returns>
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
