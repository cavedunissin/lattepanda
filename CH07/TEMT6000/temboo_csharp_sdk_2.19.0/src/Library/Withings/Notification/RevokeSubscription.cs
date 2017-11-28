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

namespace Temboo.Library.Withings.Notification
{
    /// <summary>
    /// RevokeSubscription
    /// Allows your application to revoke a previously subscribed notification.
    /// </summary>
    public class RevokeSubscription : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RevokeSubscription Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RevokeSubscription(TembooSession session) : base(session, "/Library/Withings/Notification/RevokeSubscription")
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
         /// (optional, integer) Specifies the device type for which the notification is to be revoked. Set to 1 for Bodyscale.
         /// </summary>
         /// <param name="value">Value of the Application input for this Choreo.</param>
         public void setApplication(String value) {
             base.addInput ("Application", value);
         }
         /// <summary>
         /// (required, string) The URL used when subscribing to the notification service.
         /// </summary>
         /// <param name="value">Value of the CallbackURL input for this Choreo.</param>
         public void setCallbackURL(String value) {
             base.addInput ("CallbackURL", value);
         }
         /// <summary>
         /// (required, string) The Consumer Key provided by Withings.
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (required, string) The Consumer Secret provided by Withings.
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (required, string) The ID of the user to revoke a subscription for.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RevokeSubscriptionResultSet containing execution metadata and results.</returns>
        new public RevokeSubscriptionResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RevokeSubscriptionResultSet results = new JavaScriptSerializer().Deserialize<RevokeSubscriptionResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RevokeSubscription Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RevokeSubscriptionResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Withings.</returns>
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
