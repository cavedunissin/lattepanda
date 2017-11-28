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

namespace Temboo.Library.YouTube.Search
{
    /// <summary>
    /// ListSearchResults
    /// Returns a list of search results that match the specified query parameters.
    /// </summary>
    public class ListSearchResults : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListSearchResults Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListSearchResults(TembooSession session) : base(session, "/Library/YouTube/Search/ListSearchResults")
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
         /// (optional, string) Indicates that the response should only contain resources created by this channel.
         /// </summary>
         /// <param name="value">Value of the ChannelID input for this Choreo.</param>
         public void setChannelID(String value) {
             base.addInput ("ChannelID", value);
         }
         /// <summary>
         /// (optional, string) Restricts a search to a particular type of channel. Valid values are: "any" (returns all channels) and "show" (only retrieves shows).
         /// </summary>
         /// <param name="value">Value of the ChannelType input for this Choreo.</param>
         public void setChannelType(String value) {
             base.addInput ("ChannelType", value);
         }
         /// <summary>
         /// (optional, string) The Client ID provided by Google. Required for OAuth authentication unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (optional, string) The Client Secret provided by Google. Required for OAuth authentication unless providing a valid AccessToken.
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
         /// (optional, integer) The maximum number of results to return.
         /// </summary>
         /// <param name="value">Value of the MaxResults input for this Choreo.</param>
         public void setMaxResults(String value) {
             base.addInput ("MaxResults", value);
         }
         /// <summary>
         /// (optional, string) Indicates how the results are sorted. Valid values are: date, rating, relevance, and viewCount.
         /// </summary>
         /// <param name="value">Value of the Order input for this Choreo.</param>
         public void setOrder(String value) {
             base.addInput ("Order", value);
         }
         /// <summary>
         /// (optional, string) The "nextPageToken" found in the response which is used to page through results.
         /// </summary>
         /// <param name="value">Value of the PageToken input for this Choreo.</param>
         public void setPageToken(String value) {
             base.addInput ("PageToken", value);
         }
         /// <summary>
         /// (optional, string) Specifies a comma-separated list of one or more search resource properties that the API response will include. Part names that you can pass are 'id' and 'snippet' (the default).
         /// </summary>
         /// <param name="value">Value of the Part input for this Choreo.</param>
         public void setPart(String value) {
             base.addInput ("Part", value);
         }
         /// <summary>
         /// (optional, date) Returns only results created after the specified time (formatted as a RFC 3339 date-time i.e. 1970-01-01T00:00:00Z).
         /// </summary>
         /// <param name="value">Value of the PublishedAfter input for this Choreo.</param>
         public void setPublishedAfter(String value) {
             base.addInput ("PublishedAfter", value);
         }
         /// <summary>
         /// (optional, date) Returns only results created before the specified time (formatted as a RFC 3339 date-time i.e. 1970-01-01T00:00:00Z).
         /// </summary>
         /// <param name="value">Value of the PublishedBefore input for this Choreo.</param>
         public void setPublishedBefore(String value) {
             base.addInput ("PublishedBefore", value);
         }
         /// <summary>
         /// (conditional, string) A query string for searching videos.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required for OAuth authentication unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) Returns results for the specified country. The parameter value is an ISO 3166-1 alpha-2 country code.
         /// </summary>
         /// <param name="value">Value of the RegionCode input for this Choreo.</param>
         public void setRegionCode(String value) {
             base.addInput ("RegionCode", value);
         }
         /// <summary>
         /// (optional, string) Retrieves a list of videos that are related to this video id. When using this parameter, the Type parameter must be set to video.
         /// </summary>
         /// <param name="value">Value of the RelatedToVideoID input for this Choreo.</param>
         public void setRelatedToVideoID(String value) {
             base.addInput ("RelatedToVideoID", value);
         }
         /// <summary>
         /// (optional, string) Returns only results associated with the specified topic.
         /// </summary>
         /// <param name="value">Value of the TopicID input for this Choreo.</param>
         public void setTopicID(String value) {
             base.addInput ("TopicID", value);
         }
         /// <summary>
         /// (optional, string) Restricts a search query to only retrieve a particular type of resource. The default value is: video,channel,playlist.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (optional, string) Returns filtered results based on whether videos have captions. Valid values are: any (the default), closedCaption (only returns videos with captions), or none (only returns videos without captions).
         /// </summary>
         /// <param name="value">Value of the VideoCaption input for this Choreo.</param>
         public void setVideoCaption(String value) {
             base.addInput ("VideoCaption", value);
         }
         /// <summary>
         /// (optional, string) Filters video search results based on their category.
         /// </summary>
         /// <param name="value">Value of the VideoCategoryID input for this Choreo.</param>
         public void setVideoCategoryID(String value) {
             base.addInput ("VideoCategoryID", value);
         }
         /// <summary>
         /// (optional, string) Filters video results based high or standard definition. Valid values are: any, high, or standard.
         /// </summary>
         /// <param name="value">Value of the VideoDefinition input for this Choreo.</param>
         public void setVideoDefinition(String value) {
             base.addInput ("VideoDefinition", value);
         }
         /// <summary>
         /// (optional, string) Restrict a search to only retrieve 2D or 3D videos. Valid values are: 2d, 3d, or any.
         /// </summary>
         /// <param name="value">Value of the VideoDimension input for this Choreo.</param>
         public void setVideoDimension(String value) {
             base.addInput ("VideoDimension", value);
         }
         /// <summary>
         /// (optional, string) Filters search results based on the video duration. Valid values are: any, long, medium, and short.
         /// </summary>
         /// <param name="value">Value of the VideoDuration input for this Choreo.</param>
         public void setVideoDuration(String value) {
             base.addInput ("VideoDuration", value);
         }
         /// <summary>
         /// (optional, string) Filters search results to include only videos that can be embedded into a webpage. Valid values are: any (the default) or true (which will enable this filter).
         /// </summary>
         /// <param name="value">Value of the VideoEmbeddable input for this Choreo.</param>
         public void setVideoEmbeddable(String value) {
             base.addInput ("VideoEmbeddable", value);
         }
         /// <summary>
         /// (optional, string) Filters search results to only include videos with a particular license. Valid values are: any, creativeCommon, and youtube.
         /// </summary>
         /// <param name="value">Value of the VideoLicense input for this Choreo.</param>
         public void setVideoLicense(String value) {
             base.addInput ("VideoLicense", value);
         }
         /// <summary>
         /// (optional, string) Filters search results for videos that can be played outside of youtube.com. Valid values are: any (the default) or true (which will enable this filter).
         /// </summary>
         /// <param name="value">Value of the VideoSyndicated input for this Choreo.</param>
         public void setVideoSyndicated(String value) {
             base.addInput ("VideoSyndicated", value);
         }
         /// <summary>
         /// (optional, string) Filters search results to a particular type of videos. Valid values are: any, episode, and movie.
         /// </summary>
         /// <param name="value">Value of the VideoType input for this Choreo.</param>
         public void setVideoType(String value) {
             base.addInput ("VideoType", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListSearchResultsResultSet containing execution metadata and results.</returns>
        new public ListSearchResultsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListSearchResultsResultSet results = new JavaScriptSerializer().Deserialize<ListSearchResultsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListSearchResults Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListSearchResultsResultSet : Temboo.Core.ResultSet
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
