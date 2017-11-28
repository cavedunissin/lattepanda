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

namespace Temboo.Library.Facebook.Reading
{
    /// <summary>
    /// Picture
    /// Retrieves a person's profile picture.
    /// </summary>
    public class Picture : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Picture Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Picture(TembooSession session) : base(session, "/Library/Facebook/Reading/Picture")
        {
        }

         /// <summary>
         /// (conditional, string) The access token retrieved from the final step of the OAuth process. This is not required when providing a ProfileID.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, integer) Restricts the picture height to this size in pixels.
         /// </summary>
         /// <param name="value">Value of the Height input for this Choreo.</param>
         public void setHeight(String value) {
             base.addInput ("Height", value);
         }
         /// <summary>
         /// (conditional, string) The id of the profile to retrieve a profile picture for. Defaults to "me" indicating the authenticated user.
         /// </summary>
         /// <param name="value">Value of the ProfileID input for this Choreo.</param>
         public void setProfileID(String value) {
             base.addInput ("ProfileID", value);
         }
         /// <summary>
         /// (optional, boolean) By default, the picture itself is returned as Base64 encoded data.and not a JSON. To return a JSON response, set Redirect to "false".
         /// </summary>
         /// <param name="value">Value of the Redirect input for this Choreo.</param>
         public void setRedirect(String value) {
             base.addInput ("Redirect", value);
         }
         /// <summary>
         /// (optional, boolean) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the ReturnSSLResources input for this Choreo.</param>
         public void setReturnSSLResources(String value) {
             base.addInput ("ReturnSSLResources", value);
         }
         /// <summary>
         /// (optional, string) The size of the image to retrieve. Valid values: square (50x50), small (50 pixels wide, variable height), normal (100 pixels wide, variable height), and large (about 200 pixels wide, variable height)
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (optional, integer) Restricts the picture width to this size in pixels. When Height and Width are both used, the image will be scaled as close to the dimensions as possible and then cropped down.
         /// </summary>
         /// <param name="value">Value of the Width input for this Choreo.</param>
         public void setWidth(String value) {
             base.addInput ("Width", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PictureResultSet containing execution metadata and results.</returns>
        new public PictureResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PictureResultSet results = new JavaScriptSerializer().Deserialize<PictureResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Picture Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PictureResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - Contains the Base64 encoded value of the image retrieved from Facebook by default. When setting Redirect to "false", the response is a JSON string containing the image URL.</returns>
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
