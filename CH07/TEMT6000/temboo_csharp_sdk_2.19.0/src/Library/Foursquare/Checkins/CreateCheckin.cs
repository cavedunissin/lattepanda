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

namespace Temboo.Library.Foursquare.Checkins
{
    /// <summary>
    /// CreateCheckin
    /// Allows you to create a check-in with Foursquare.
    /// </summary>
    public class CreateCheckin : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateCheckin Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateCheckin(TembooSession session) : base(session, "/Library/Foursquare/Checkins/CreateCheckin")
        {
        }

         /// <summary>
         /// (optional, integer) Accuracy of the user's latitude and longitude, in meters.
         /// </summary>
         /// <param name="value">Value of the AccuracyOfCoordinates input for this Choreo.</param>
         public void setAccuracyOfCoordinates(String value) {
             base.addInput ("AccuracyOfCoordinates", value);
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
         /// (optional, string) Who to broadcast this check-in to. Can be a comma-delimited list: private, public, facebook, twitter, or followers. Defaults to 'public'.
         /// </summary>
         /// <param name="value">Value of the Broadcast input for this Choreo.</param>
         public void setBroadcast(String value) {
             base.addInput ("Broadcast", value);
         }
         /// <summary>
         /// (optional, string) The event the user is checking in to. A venueId for a venue with this eventId must also be specified in the request.
         /// </summary>
         /// <param name="value">Value of the EventID input for this Choreo.</param>
         public void setEventID(String value) {
             base.addInput ("EventID", value);
         }
         /// <summary>
         /// (optional, decimal) The latitude point of the user's location.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, decimal) The longitude point of the user's location.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (required, string) The FourSquare API Oauth token string.
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
         /// (optional, string) A message about your check-in. The maximum length of this field is 140 characters.
         /// </summary>
         /// <param name="value">Value of the Shout input for this Choreo.</param>
         public void setShout(String value) {
             base.addInput ("Shout", value);
         }
         /// <summary>
         /// (optional, string) If you are not shouting, but you don't have a venue ID or prefer a 'venueless' checkin, pass the venue name as a string using this parameter.
         /// </summary>
         /// <param name="value">Value of the Venue input for this Choreo.</param>
         public void setVenue(String value) {
             base.addInput ("Venue", value);
         }
         /// <summary>
         /// (required, string) The venue where the user is checking in. No venueid is needed if shouting or just providing a venue name.
         /// </summary>
         /// <param name="value">Value of the VenueID input for this Choreo.</param>
         public void setVenueID(String value) {
             base.addInput ("VenueID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateCheckinResultSet containing execution metadata and results.</returns>
        new public CreateCheckinResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateCheckinResultSet results = new JavaScriptSerializer().Deserialize<CreateCheckinResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateCheckin Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateCheckinResultSet : Temboo.Core.ResultSet
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
