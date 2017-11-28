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

namespace Temboo.Library.Facebook.Actions.Books.Rates
{
    /// <summary>
    /// UpdateRating
    /// Updates an existing book rating action.
    /// </summary>
    public class UpdateRating : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateRating Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateRating(TembooSession session) : base(session, "/Library/Facebook/Actions/Books/Rates/UpdateRating")
        {
        }

         /// <summary>
         /// (required, string) The access token retrieved from the final step of the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The id of the action to update.
         /// </summary>
         /// <param name="value">Value of the ActionID input for this Choreo.</param>
         public void setActionID(String value) {
             base.addInput ("ActionID", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing the book.
         /// </summary>
         /// <param name="value">Value of the Book input for this Choreo.</param>
         public void setBook(String value) {
             base.addInput ("Book", value);
         }
         /// <summary>
         /// (optional, date) The time that the user ended the action (e.g. 2013-06-24T18:53:35+0000).
         /// </summary>
         /// <param name="value">Value of the EndTime input for this Choreo.</param>
         public void setEndTime(String value) {
             base.addInput ("EndTime", value);
         }
         /// <summary>
         /// (optional, integer) The amount of time (in milliseconds) from the publish_time that the action will expire.
         /// </summary>
         /// <param name="value">Value of the ExpiresIn input for this Choreo.</param>
         public void setExpiresIn(String value) {
             base.addInput ("ExpiresIn", value);
         }
         /// <summary>
         /// (optional, string) The id of the user's profile. Defaults to "me" indicating the authenticated user.
         /// </summary>
         /// <param name="value">Value of the Message input for this Choreo.</param>
         public void setMessage(String value) {
             base.addInput ("Message", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing the location associated with this action.
         /// </summary>
         /// <param name="value">Value of the Place input for this Choreo.</param>
         public void setPlace(String value) {
             base.addInput ("Place", value);
         }
         /// <summary>
         /// (optional, decimal) The rating expressed as a decimal value between 0 and 1.0.
         /// </summary>
         /// <param name="value">Value of the RatingNormalizedValue input for this Choreo.</param>
         public void setRatingNormalizedValue(String value) {
             base.addInput ("RatingNormalizedValue", value);
         }
         /// <summary>
         /// (optional, integer) The highest possible value in the rating scale.
         /// </summary>
         /// <param name="value">Value of the RatingScale input for this Choreo.</param>
         public void setRatingScale(String value) {
             base.addInput ("RatingScale", value);
         }
         /// <summary>
         /// (optional, decimal) The value of the book rating.
         /// </summary>
         /// <param name="value">Value of the RatingValue input for this Choreo.</param>
         public void setRatingValue(String value) {
             base.addInput ("RatingValue", value);
         }
         /// <summary>
         /// (optional, string) The URL or ID for an Open Graph object representing a book review.
         /// </summary>
         /// <param name="value">Value of the Review input for this Choreo.</param>
         public void setReview(String value) {
             base.addInput ("Review", value);
         }
         /// <summary>
         /// (optional, string) The text content of the book review.
         /// </summary>
         /// <param name="value">Value of the ReviewText input for this Choreo.</param>
         public void setReviewText(String value) {
             base.addInput ("ReviewText", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of other profile IDs that also performed this action.
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateRatingResultSet containing execution metadata and results.</returns>
        new public UpdateRatingResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateRatingResultSet results = new JavaScriptSerializer().Deserialize<UpdateRatingResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateRating Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateRatingResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Facebook.</returns>
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
