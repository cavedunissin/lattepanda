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

namespace Temboo.Library.Xively.ReadWriteData
{
    /// <summary>
    /// WriteFeedMetadata
    /// Allows you to easily update the metadata of your feed.
    /// </summary>
    public class WriteFeedMetadata : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WriteFeedMetadata Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WriteFeedMetadata(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/WriteFeedMetadata")
        {
        }

         /// <summary>
         /// (optional, any) Custom data body for the new feed in JSON or XML format (set by FeedType). See documentation for how to write your own feed. If custom FeedData is used, all other optional inputs are ignored.
         /// </summary>
         /// <param name="value">Value of the FeedData input for this Choreo.</param>
         public void setFeedData(String value) {
             base.addInput ("FeedData", value);
         }
         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) A description of the feed. Leave empty to keep existing Description. Type "BLANK" to clear existing Description.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) Contact Email. Leave empty to keep existing Email. Type "BLANK" to clear existing Email.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (required, integer) The ID for the feed that you would like to update.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (optional, string) The type of feed that is being provided for custom FeedData. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the FeedType input for this Choreo.</param>
         public void setFeedType(String value) {
             base.addInput ("FeedType", value);
         }
         /// <summary>
         /// (optional, string) The URL of an icon which is relevant to this feed. Leave empty to keep existing Icon. Type "BLANK" to clear existing Icon.
         /// </summary>
         /// <param name="value">Value of the Icon input for this Choreo.</param>
         public void setIcon(String value) {
             base.addInput ("Icon", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies whether or not the feed is private to the creator of the feed. If 'true' the feed is private, if 'false' the feed is public. Leave empty to keep existing settings.
         /// </summary>
         /// <param name="value">Value of the Private input for this Choreo.</param>
         public void setPrivate(String value) {
             base.addInput ("Private", value);
         }
         /// <summary>
         /// (optional, string) Comma-separated list of searchable tags (the characters ', ", and commas are not allowed). Tags input overwrites previous tags, enter "BLANK" to clear all tags. Ex: "power,energy".
         /// </summary>
         /// <param name="value">Value of the Tags input for this Choreo.</param>
         public void setTags(String value) {
             base.addInput ("Tags", value);
         }
         /// <summary>
         /// (optional, string) A descriptive name for the feed. Leave empty to keep existing Title. Type "BLANK" to clear existing Title.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (optional, string) The URL of a website which is relevant to this feed. Leave empty to keep existing Website. Type "BLANK" to clear existing Website. Ex.: http://www.homepage.com.
         /// </summary>
         /// <param name="value">Value of the Website input for this Choreo.</param>
         public void setWebsite(String value) {
             base.addInput ("Website", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WriteFeedMetadataResultSet containing execution metadata and results.</returns>
        new public WriteFeedMetadataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WriteFeedMetadataResultSet results = new JavaScriptSerializer().Deserialize<WriteFeedMetadataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WriteFeedMetadata Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WriteFeedMetadataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful feed update, the code should be 200.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
    }
}
