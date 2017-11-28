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

namespace Temboo.Library.Foursquare.Photos
{
    /// <summary>
    /// AddPhoto
    /// Allows a user to add a new photo to a check-in, tip, or a venue.
    /// </summary>
    public class AddPhoto : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddPhoto Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddPhoto(TembooSession session) : base(session, "/Library/Foursquare/Photos/AddPhoto")
        {
        }

         /// <summary>
         /// (optional, integer) Altitude of the user's location, in meters.
         /// </summary>
         /// <param name="value">Value of the Altitude input for this Choreo.</param>
         public void setAltitude(String value) {
             base.addInput ("Altitude", value);
         }
         /// <summary>
         /// (optional, integer) Vertical accuracy of the user's location, in meters.
         /// </summary>
         /// <param name="value">Value of the AltitudeAccuracy input for this Choreo.</param>
         public void setAltitudeAccuracy(String value) {
             base.addInput ("AltitudeAccuracy", value);
         }
         /// <summary>
         /// (optional, string) Whether to broadcast this photo. Set to "twitter" if you want to send to twitter, "facebook "if you want to send to facebook, or "twitter,facebook" if you want to send to both.
         /// </summary>
         /// <param name="value">Value of the Broadcast input for this Choreo.</param>
         public void setBroadcast(String value) {
             base.addInput ("Broadcast", value);
         }
         /// <summary>
         /// (conditional, any) The ID of the checkin to attach a photo to. One of the id fields (CheckinID, TipID, or VenueID) must be specified.
         /// </summary>
         /// <param name="value">Value of the CheckinID input for this Choreo.</param>
         public void setCheckinID(String value) {
             base.addInput ("CheckinID", value);
         }
         /// <summary>
         /// (conditional, string) The base64 encoded image contents. Required unless using the VaultFile alias (an advanced option used when running Choreos in the Temboo Designer).
         /// </summary>
         /// <param name="value">Value of the ImageFile input for this Choreo.</param>
         public void setImageFile(String value) {
             base.addInput ("ImageFile", value);
         }
         /// <summary>
         /// (optional, integer) Accuracy of the user's latitude and longitude, in meters.
         /// </summary>
         /// <param name="value">Value of the LLAccuracy input for this Choreo.</param>
         public void setLLAccuracy(String value) {
             base.addInput ("LLAccuracy", value);
         }
         /// <summary>
         /// (optional, decimal) Laitude of the user's location.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, decimal) Longitude of the user's location.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (required, string) The Foursquare API OAuth token string.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the tip to attach a photo to. One of the id fields (CheckinID, TipID, or VenueID) must be specified.
         /// </summary>
         /// <param name="value">Value of the TipID input for this Choreo.</param>
         public void setTipID(String value) {
             base.addInput ("TipID", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the venue to attach a photo to. One of the id fields (CheckinID, TipID, or VenueID) must be specified.
         /// </summary>
         /// <param name="value">Value of the VenueID input for this Choreo.</param>
         public void setVenueID(String value) {
             base.addInput ("VenueID", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddPhotoResultSet containing execution metadata and results.</returns>
        new public AddPhotoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddPhotoResultSet results = new JavaScriptSerializer().Deserialize<AddPhotoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddPhoto Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddPhotoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Foursquare. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
