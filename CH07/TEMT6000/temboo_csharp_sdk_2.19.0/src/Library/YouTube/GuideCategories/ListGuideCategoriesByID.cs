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

namespace Temboo.Library.YouTube.GuideCategories
{
    /// <summary>
    /// ListGuideCategoriesByID
    /// Returns a list of categories that match the IDs provided.
    /// </summary>
    public class ListGuideCategoriesByID : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListGuideCategoriesByID Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListGuideCategoriesByID(TembooSession session) : base(session, "/Library/YouTube/GuideCategories/ListGuideCategoriesByID")
        {
        }

         /// <summary>
         /// (optional, string) The API Key provided by Google for simple API access when you do not need to access user data.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required for OAuth authentication unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Google. Required for OAuth authentication unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required for OAuth authentication unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) Allows you to specify a subset of fields to include in the response using an xpath-like syntax (i.e. items/snippet/title).
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (conditional, string) A comma-separated list of the YouTube channel category ID(s) for the resource(s) that are being retrieved.
         /// </summary>
         /// <param name="value">Value of the GuideCategoryID input for this Choreo.</param>
         public void setGuideCategoryID(String value) {
             base.addInput ("GuideCategoryID", value);
         }
         /// <summary>
         /// (optional, string) The hl parameter specifies the language that should be used for text values in the API response. The default value is en_US.
         /// </summary>
         /// <param name="value">Value of the H1 input for this Choreo.</param>
         public void setH1(String value) {
             base.addInput ("H1", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of one or more guideCategory resource properties that the API response will include. Valid values are: id and snippet.
         /// </summary>
         /// <param name="value">Value of the Part input for this Choreo.</param>
         public void setPart(String value) {
             base.addInput ("Part", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required for OAuth authentication unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListGuideCategoriesByIDResultSet containing execution metadata and results.</returns>
        new public ListGuideCategoriesByIDResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListGuideCategoriesByIDResultSet results = new JavaScriptSerializer().Deserialize<ListGuideCategoriesByIDResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListGuideCategoriesByID Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListGuideCategoriesByIDResultSet : Temboo.Core.ResultSet
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
        /// <returns>String - (json) The response from YouTube.</returns>
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
