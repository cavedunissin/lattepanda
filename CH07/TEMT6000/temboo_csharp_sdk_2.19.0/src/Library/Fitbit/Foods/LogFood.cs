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

namespace Temboo.Library.Fitbit.Foods
{
    /// <summary>
    /// LogFood
    /// Log a new food entry for a particular date.
    /// </summary>
    public class LogFood : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the LogFood Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public LogFood(TembooSession session) : base(session, "/Library/Fitbit/Foods/LogFood")
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
         /// (required, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, integer) The amount of food consumed formatted like X.XX. Note that this input corresponds with the UnitId input.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
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
         /// (required, date) The date that corresponds with the new log entry (in the format yyyy-MM-dd).
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to add food to favorites after creating log entry. Defaults to 0 for false.
         /// </summary>
         /// <param name="value">Value of the Favorite input for this Choreo.</param>
         public void setFavorite(String value) {
             base.addInput ("Favorite", value);
         }
         /// <summary>
         /// (required, integer) The id of the food to create a log entry for.
         /// </summary>
         /// <param name="value">Value of the FoodID input for this Choreo.</param>
         public void setFoodID(String value) {
             base.addInput ("FoodID", value);
         }
         /// <summary>
         /// (required, string) The type of meal. Valid values: Breakfast, Morning Snack, Lunch, Afternoon Snack, Dinner, Anytime.
         /// </summary>
         /// <param name="value">Value of the MealType input for this Choreo.</param>
         public void setMealType(String value) {
             base.addInput ("MealType", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in: xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, integer) This id can be retrieved through other calls such as: Get Foods (Recent, Frequent, Favorite), Search Foods or Get Food Units.
         /// </summary>
         /// <param name="value">Value of the UnitID input for this Choreo.</param>
         public void setUnitID(String value) {
             base.addInput ("UnitID", value);
         }
         /// <summary>
         /// (optional, string) The user's encoded id. Defaults to "-" (dash) which will return data for the user associated with the token credentials provided.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A LogFoodResultSet containing execution metadata and results.</returns>
        new public LogFoodResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            LogFoodResultSet results = new JavaScriptSerializer().Deserialize<LogFoodResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the LogFood Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class LogFoodResultSet : Temboo.Core.ResultSet
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
