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

namespace Temboo.Library.Flickr.PhotoSets
{
    /// <summary>
    /// ListPhotos
    /// Retrieves the list of photos in a set.
    /// </summary>
    public class ListPhotos : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListPhotos Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListPhotos(TembooSession session) : base(session, "/Library/Flickr/PhotoSets/ListPhotos")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Flickr (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The API Secret provided by Flickr (AKA the OAuth Consumer Secret).  Required when accessing a protected resource.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (optional, string) The Access Token retrieved during the OAuth process. Required when accessing a protected resource.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The Access Token Secret retrieved during the OAuth process. Required when accessing a protected resource.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (optional, string) A comma-delimited list of extra information to fetch for each returned record.
         /// </summary>
         /// <param name="value">Value of the Extras input for this Choreo.</param>
         public void setExtras(String value) {
             base.addInput ("Extras", value);
         }
         /// <summary>
         /// (optional, string) Filter results by media type. Possible values are all (default), photos or videos
         /// </summary>
         /// <param name="value">Value of the Media input for this Choreo.</param>
         public void setMedia(String value) {
             base.addInput ("Media", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to return. If this argument is omitted, it defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of photos to return per page. Defaults to 500. The maximum allowed value is 500.
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (required, integer) The ID of the photo set.
         /// </summary>
         /// <param name="value">Value of the PhotoSetID input for this Choreo.</param>
         public void setPhotoSetID(String value) {
             base.addInput ("PhotoSetID", value);
         }
         /// <summary>
         /// (optional, integer) Valid values are: 1 (public photos), 2 (private photos visible to friends), 3 (private photos visible to family), 4 (private photos visible to friends and family), 5 (completely private photos).
         /// </summary>
         /// <param name="value">Value of the PrivacyFilter input for this Choreo.</param>
         public void setPrivacyFilter(String value) {
             base.addInput ("PrivacyFilter", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml and json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListPhotosResultSet containing execution metadata and results.</returns>
        new public ListPhotosResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListPhotosResultSet results = new JavaScriptSerializer().Deserialize<ListPhotosResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListPhotos Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListPhotosResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Flickr.</returns>
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
