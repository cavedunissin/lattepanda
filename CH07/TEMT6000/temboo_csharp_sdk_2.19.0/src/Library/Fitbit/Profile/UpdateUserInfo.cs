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

namespace Temboo.Library.Fitbit.Profile
{
    /// <summary>
    /// UpdateUserInfo
    /// Updates a user's profile data.
    /// </summary>
    public class UpdateUserInfo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateUserInfo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateUserInfo(TembooSession session) : base(session, "/Library/Fitbit/Profile/UpdateUserInfo")
        {
        }

         /// <summary>
         /// (optional, string) The user's About Me string.
         /// </summary>
         /// <param name="value">Value of the AboutMe input for this Choreo.</param>
         public void setAboutMe(String value) {
             base.addInput ("AboutMe", value);
         }
         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (optional, date) Date of Birth; in the format yyyy-MM-dd.
         /// </summary>
         /// <param name="value">Value of the Birthday input for this Choreo.</param>
         public void setBirthday(String value) {
             base.addInput ("Birthday", value);
         }
         /// <summary>
         /// (optional, string) The user's city information.
         /// </summary>
         /// <param name="value">Value of the City input for this Choreo.</param>
         public void setCity(String value) {
             base.addInput ("City", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (optional, string) The two-character code for the user's country.
         /// </summary>
         /// <param name="value">Value of the Country input for this Choreo.</param>
         public void setCountry(String value) {
             base.addInput ("Country", value);
         }
         /// <summary>
         /// (optional, string) Food Database Locale; in the format "xx_XX".
         /// </summary>
         /// <param name="value">Value of the FoodLocale input for this Choreo.</param>
         public void setFoodLocale(String value) {
             base.addInput ("FoodLocale", value);
         }
         /// <summary>
         /// (optional, string) The user's full name.
         /// </summary>
         /// <param name="value">Value of the FullName input for this Choreo.</param>
         public void setFullName(String value) {
             base.addInput ("FullName", value);
         }
         /// <summary>
         /// (optional, string) The user's gender (MALE/FEMALE/NA).
         /// </summary>
         /// <param name="value">Value of the Gender input for this Choreo.</param>
         public void setGender(String value) {
             base.addInput ("Gender", value);
         }
         /// <summary>
         /// (optional, decimal) The blood glucose unit of measurement being used. Valid values are: en_US, any,  METRIC.
         /// </summary>
         /// <param name="value">Value of the GlucoseUnit input for this Choreo.</param>
         public void setGlucoseUnit(String value) {
             base.addInput ("GlucoseUnit", value);
         }
         /// <summary>
         /// (optional, decimal) The user's height; in the format X.XX (inches).
         /// </summary>
         /// <param name="value">Value of the Height input for this Choreo.</param>
         public void setHeight(String value) {
             base.addInput ("Height", value);
         }
         /// <summary>
         /// (optional, decimal) The height unit being used. Valid values are: en_US, any,  METRIC.
         /// </summary>
         /// <param name="value">Value of the HeightUnit input for this Choreo.</param>
         public void setHeightUnit(String value) {
             base.addInput ("HeightUnit", value);
         }
         /// <summary>
         /// (optional, string) Locale of website (country/language); one of the locales, currently – (en_US, fr_FR, de_DE, es_ES, en_GB, en_AU, en_NZ, ja_JP).
         /// </summary>
         /// <param name="value">Value of the Locale input for this Choreo.</param>
         public void setLocale(String value) {
             base.addInput ("Locale", value);
         }
         /// <summary>
         /// (optional, string) The user's nickname.
         /// </summary>
         /// <param name="value">Value of the Nickname input for this Choreo.</param>
         public void setNickname(String value) {
             base.addInput ("Nickname", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in: xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The two-character state abbreviation for the user.
         /// </summary>
         /// <param name="value">Value of the State input for this Choreo.</param>
         public void setState(String value) {
             base.addInput ("State", value);
         }
         /// <summary>
         /// (optional, decimal) Running stride length; in the format X.XX.
         /// </summary>
         /// <param name="value">Value of the StrideLengthRunning input for this Choreo.</param>
         public void setStrideLengthRunning(String value) {
             base.addInput ("StrideLengthRunning", value);
         }
         /// <summary>
         /// (optional, decimal) Walking stride length; in the format X.XX.
         /// </summary>
         /// <param name="value">Value of the StrideLengthWalking input for this Choreo.</param>
         public void setStrideLengthWalking(String value) {
             base.addInput ("StrideLengthWalking", value);
         }
         /// <summary>
         /// (optional, string) The user's timezone; in the format "America/Los_Angeles"
         /// </summary>
         /// <param name="value">Value of the Timezone input for this Choreo.</param>
         public void setTimezone(String value) {
             base.addInput ("Timezone", value);
         }
         /// <summary>
         /// (optional, string) The user's encoded id. Defaults to "-" (dash) which will return data for the user associated with the token credentials provided.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }
         /// <summary>
         /// (optional, decimal) The water unit being used. Valid values are: en_US, any,  METRIC.
         /// </summary>
         /// <param name="value">Value of the WaterUnit input for this Choreo.</param>
         public void setWaterUnit(String value) {
             base.addInput ("WaterUnit", value);
         }
         /// <summary>
         /// (optional, string) The weight unit being used. Valid values are: en_US, any,  METRIC.
         /// </summary>
         /// <param name="value">Value of the WeightUnit input for this Choreo.</param>
         public void setWeightUnit(String value) {
             base.addInput ("WeightUnit", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateUserInfoResultSet containing execution metadata and results.</returns>
        new public UpdateUserInfoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateUserInfoResultSet results = new JavaScriptSerializer().Deserialize<UpdateUserInfoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateUserInfo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateUserInfoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Fitbit.</returns>
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
