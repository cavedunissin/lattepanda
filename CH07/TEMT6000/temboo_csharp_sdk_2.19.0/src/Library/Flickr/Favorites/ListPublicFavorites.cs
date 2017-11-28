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

namespace Temboo.Library.Flickr.Favorites
{
    /// <summary>
    /// ListPublicFavorites
    /// Returns a list of favorite public photos for the given user.
    /// </summary>
    public class ListPublicFavorites : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListPublicFavorites Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListPublicFavorites(TembooSession session) : base(session, "/Library/Flickr/Favorites/ListPublicFavorites")
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
         /// (optional, string) A comma-delimited list of extra information to fetch for each returned record. See Choreo documentation for accepted values.
         /// </summary>
         /// <param name="value">Value of the Extras input for this Choreo.</param>
         public void setExtras(String value) {
             base.addInput ("Extras", value);
         }
         /// <summary>
         /// (optional, date) Maximum date that a photo was favorited on. The date should be in the form of a unix timestamp.
         /// </summary>
         /// <param name="value">Value of the MaxFaveDate input for this Choreo.</param>
         public void setMaxFaveDate(String value) {
             base.addInput ("MaxFaveDate", value);
         }
         /// <summary>
         /// (optional, date) Minimum date that a photo was favorited on. The date should be in the form of a unix timestamp.
         /// </summary>
         /// <param name="value">Value of the MinFaveDate input for this Choreo.</param>
         public void setMinFaveDate(String value) {
             base.addInput ("MinFaveDate", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to return. Used for paging through many results.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, integer) The number of photos to return per page. Defaults to 100.
         /// </summary>
         /// <param name="value">Value of the PerPage input for this Choreo.</param>
         public void setPerPage(String value) {
             base.addInput ("PerPage", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml and json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The user to fetch the favorites list for.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListPublicFavoritesResultSet containing execution metadata and results.</returns>
        new public ListPublicFavoritesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListPublicFavoritesResultSet results = new JavaScriptSerializer().Deserialize<ListPublicFavoritesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListPublicFavorites Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListPublicFavoritesResultSet : Temboo.Core.ResultSet
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
