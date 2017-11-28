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

namespace Temboo.Library.Flickr.Photos
{
    /// <summary>
    /// SearchPhotos
    /// Returns a list of photos matching a search criteria.
    /// </summary>
    public class SearchPhotos : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchPhotos Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchPhotos(TembooSession session) : base(session, "/Library/Flickr/Photos/SearchPhotos")
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
         /// (optional, integer) The accuracy level of the location information. Current range is 1-16. World level is 1, Country is ~3, Region is ~6, City is ~11, Street is ~16.
         /// </summary>
         /// <param name="value">Value of the Accuracy input for this Choreo.</param>
         public void setAccuracy(String value) {
             base.addInput ("Accuracy", value);
         }
         /// <summary>
         /// (optional, string) A comma-delimited list of 4 values defining the Bounding Box of the area that will be searched. These values represent the coordinates of the bottom-left corner and top-right corner of the box.
         /// </summary>
         /// <param name="value">Value of the BoundingBox input for this Choreo.</param>
         public void setBoundingBox(String value) {
             base.addInput ("BoundingBox", value);
         }
         /// <summary>
         /// (optional, integer) The content type setting. 1 = photos only, 2 = screenshots only, 3 = other, 4 = photos and screenshots, 5 = screenshots and other, 6 = photos and other, 7 = all.
         /// </summary>
         /// <param name="value">Value of the ContentType input for this Choreo.</param>
         public void setContentType(String value) {
             base.addInput ("ContentType", value);
         }
         /// <summary>
         /// (optional, string) A comma-delimited list of extra information to fetch for each returned record. See documentation for more details on supported fields.
         /// </summary>
         /// <param name="value">Value of the Extras input for this Choreo.</param>
         public void setExtras(String value) {
             base.addInput ("Extras", value);
         }
         /// <summary>
         /// (optional, integer) A numeric value representing the photo's location info beyond latitude and longitude. 0 = not defined, 1 = indoors, 2 = outdoors.
         /// </summary>
         /// <param name="value">Value of the GeoContext input for this Choreo.</param>
         public void setGeoContext(String value) {
             base.addInput ("GeoContext", value);
         }
         /// <summary>
         /// (optional, string) The id of a group who's pool to search. If specified, only matching photos posted to the group's pool will be returned.
         /// </summary>
         /// <param name="value">Value of the GroupID input for this Choreo.</param>
         public void setGroupID(String value) {
             base.addInput ("GroupID", value);
         }
         /// <summary>
         /// (optional, boolean) Limits the search to only photos that are in a gallery. Default is false.
         /// </summary>
         /// <param name="value">Value of the InGallery input for this Choreo.</param>
         public void setInGallery(String value) {
             base.addInput ("InGallery", value);
         }
         /// <summary>
         /// (conditional, decimal) A valid latitude, in decimal format, for performing geo queries (not required if providing another limiting search parameter).
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (conditional, decimal) A valid longitude, in decimal format, for performing geo queries (not required if providing another limiting search parameter).
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, date) The maximum taken date. Photos with an taken date less than or equal to this value will be returned. The date can be in the form of a mysql datetime or unix timestamp.
         /// </summary>
         /// <param name="value">Value of the MaxTakenDate input for this Choreo.</param>
         public void setMaxTakenDate(String value) {
             base.addInput ("MaxTakenDate", value);
         }
         /// <summary>
         /// (optional, date) The maximum upload date. Photos with an upload date less than or equal to this value will be returned. The date can be in the form of a unix timestamp or mysql datetime.
         /// </summary>
         /// <param name="value">Value of the MaxUploadDate input for this Choreo.</param>
         public void setMaxUploadDate(String value) {
             base.addInput ("MaxUploadDate", value);
         }
         /// <summary>
         /// (optional, string) Filter results by media type. Valid values are all (default), photos or videos.
         /// </summary>
         /// <param name="value">Value of the Media input for this Choreo.</param>
         public void setMedia(String value) {
             base.addInput ("Media", value);
         }
         /// <summary>
         /// (optional, date) The minimum taken date. Photos with a taken date greater than or equal to this value will be returned. The date can be in the form of a mysql datetime or unix timestamp.
         /// </summary>
         /// <param name="value">Value of the MinTakenDate input for this Choreo.</param>
         public void setMinTakenDate(String value) {
             base.addInput ("MinTakenDate", value);
         }
         /// <summary>
         /// (optional, date) The minimum upload date. Photos with an upload date greater than or equal to this value will be returned. The date can be in the form of a unix timestamp or mysql datetime.
         /// </summary>
         /// <param name="value">Value of the MinUploadDate input for this Choreo.</param>
         public void setMinUploadDate(String value) {
             base.addInput ("MinUploadDate", value);
         }
         /// <summary>
         /// (optional, integer) The page of results to return. Defaults to 1.
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
         /// (optional, string) A Flickr place id.
         /// </summary>
         /// <param name="value">Value of the PlaceID input for this Choreo.</param>
         public void setPlaceID(String value) {
             base.addInput ("PlaceID", value);
         }
         /// <summary>
         /// (optional, integer) A valid radius used for geo queries, greater than zero and less than 20 miles (or 32 kilometers). Defaults to 5 (km).
         /// </summary>
         /// <param name="value">Value of the Radius input for this Choreo.</param>
         public void setRadius(String value) {
             base.addInput ("Radius", value);
         }
         /// <summary>
         /// (optional, string) The unit of measure when doing radial geo queries. Valid values are: "mi" (miles) and "km" (kilometers). The default is "km".
         /// </summary>
         /// <param name="value">Value of the RadiusUnits input for this Choreo.</param>
         public void setRadiusUnits(String value) {
             base.addInput ("RadiusUnits", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml and json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Defaults to date-posted-desc unless performing a geo query. Valid values are: date-posted-asc, date-posted-desc, date-taken-asc, date-taken-desc, interestingness-desc, interestingness-asc, relevance.
         /// </summary>
         /// <param name="value">Value of the Sort input for this Choreo.</param>
         public void setSort(String value) {
             base.addInput ("Sort", value);
         }
         /// <summary>
         /// (optional, string) Use the mode 'any' to search using an OR combination of tags. Use 'all' for an AND combnation. Defaults to 'any'.
         /// </summary>
         /// <param name="value">Value of the TagMode input for this Choreo.</param>
         public void setTagMode(String value) {
             base.addInput ("TagMode", value);
         }
         /// <summary>
         /// (optional, string) A comma-delimited list of tags. Photos with one or more of the tags listed will be returned. You can exclude results that match a term by prepending it with a hyphen.
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (conditional, string) A keyword search against photo titles, descriptions, or tags. Prepend search term with a hyphen to exclude. Not required if providing another limiting search parameter.
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }
         /// <summary>
         /// (optional, string) The ID of the user who's photo to search. If this parameter isn't passed, all public photos will be searched. A value of "me" will search against the authenticated user's photos.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }
         /// <summary>
         /// (optional, string) The unique 'Where on Earth ID' that uniquely represents spatial entities.
         /// </summary>
         /// <param name="value">Value of the WOEID input for this Choreo.</param>
         public void setWOEID(String value) {
             base.addInput ("WOEID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchPhotosResultSet containing execution metadata and results.</returns>
        new public SearchPhotosResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchPhotosResultSet results = new JavaScriptSerializer().Deserialize<SearchPhotosResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchPhotos Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchPhotosResultSet : Temboo.Core.ResultSet
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
