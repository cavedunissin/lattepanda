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

namespace Temboo.Library.Google.Plus.Domains.People
{
    /// <summary>
    /// ListByActivity
    /// Lists all of the people in the specified collection for a particular activity.
    /// </summary>
    public class ListByActivity : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListByActivity Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListByActivity(TembooSession session) : base(session, "/Library/Google/Plus/Domains/People/ListByActivity")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The ID of the activity to get the list of people for.
         /// </summary>
         /// <param name="value">Value of the ActivityID input for this Choreo.</param>
         public void setActivityID(String value) {
             base.addInput ("ActivityID", value);
         }
         /// <summary>
         /// (optional, string) Specifies a JavaScript function that will be passed the response data for using the API with JSONP.
         /// </summary>
         /// <param name="value">Value of the Callback input for this Choreo.</param>
         public void setCallback(String value) {
             base.addInput ("Callback", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (required, string) The collection of people to list.  Acceptable values are: "plusoners","resharers", "sharedto":
         /// </summary>
         /// <param name="value">Value of the Collection input for this Choreo.</param>
         public void setCollection(String value) {
             base.addInput ("Collection", value);
         }
         /// <summary>
         /// (optional, string) Used to specify fields to include in a partial response. This can be used to reduce the amount of data returned. See documentation for syntax rules.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of circles to include in the response. Used for paging through results. Valid values are: 1 to 20. Default is 10.
         /// </summary>
         /// <param name="value">Value of the MaxResults input for this Choreo.</param>
         public void setMaxResults(String value) {
             base.addInput ("MaxResults", value);
         }
         /// <summary>
         /// (optional, string) The order to return results in. Valid values are: alphabetical and best.
         /// </summary>
         /// <param name="value">Value of the OrderBy input for this Choreo.</param>
         public void setOrderBy(String value) {
             base.addInput ("OrderBy", value);
         }
         /// <summary>
         /// (optional, string) The "NextPageToken" returned in the Choreo output. Used to page through large result sets.
         /// </summary>
         /// <param name="value">Value of the PageToken input for this Choreo.</param>
         public void setPageToken(String value) {
             base.addInput ("PageToken", value);
         }
         /// <summary>
         /// (optional, boolean) A flag used to pretty print the JSON response to make it more readable. Defaults to "true".
         /// </summary>
         /// <param name="value">Value of the PrettyPrint input for this Choreo.</param>
         public void setPrettyPrint(String value) {
             base.addInput ("PrettyPrint", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth Refresh Token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user to get circles for. The value "me" is set as the default to indicate the authenticated user.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }
         /// <summary>
         /// (optional, string) Identifies the IP address of the end user for whom the API call is being made. Used to enforce per-user quotas.
         /// </summary>
         /// <param name="value">Value of the UserIP input for this Choreo.</param>
         public void setUserIP(String value) {
             base.addInput ("UserIP", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListByActivityResultSet containing execution metadata and results.</returns>
        new public ListByActivityResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListByActivityResultSet results = new JavaScriptSerializer().Deserialize<ListByActivityResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListByActivity Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListByActivityResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the RefreshToken is provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Google.</returns>
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
