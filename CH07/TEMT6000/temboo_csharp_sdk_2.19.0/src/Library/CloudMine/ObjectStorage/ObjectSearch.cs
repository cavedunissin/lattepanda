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

namespace Temboo.Library.CloudMine.ObjectStorage
{
    /// <summary>
    /// ObjectSearch
    /// Allows you to query key/value pair objects.
    /// </summary>
    public class ObjectSearch : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ObjectSearch Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ObjectSearch(TembooSession session) : base(session, "/Library/CloudMine/ObjectStorage/ObjectSearch")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by CloudMine after registering your app.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The application identifier provided by CloudMine after registering your app.
         /// </summary>
         /// <param name="value">Value of the ApplicationIdentifier input for this Choreo.</param>
         public void setApplicationIdentifier(String value) {
             base.addInput ("ApplicationIdentifier", value);
         }
         /// <summary>
         /// (optional, boolean) Returns a count of the results in the response if set to true. Valid values are true and false.
         /// </summary>
         /// <param name="value">Value of the Count input for this Choreo.</param>
         public void setCount(String value) {
             base.addInput ("Count", value);
         }
         /// <summary>
         /// (optional, integer) Limits the number of results returned. Use -1 for no limit. Use 0 for no results, and with Count=true to just get the number of available results. This defaults to 50.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, string) The query for your search. See Choreo documentation for information on appropriate query syntax.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (conditional, string) The session token for an existing user (returned by the AccountLogin Choreo). This is only required if your app is performing this operation on behalf of another user.
         /// </summary>
         /// <param name="value">Value of the SessionToken input for this Choreo.</param>
         public void setSessionToken(String value) {
             base.addInput ("SessionToken", value);
         }
         /// <summary>
         /// (optional, integer) Indicates to start results after skiping this number objects. Used to page through results.
         /// </summary>
         /// <param name="value">Value of the Skip input for this Choreo.</param>
         public void setSkip(String value) {
             base.addInput ("Skip", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ObjectSearchResultSet containing execution metadata and results.</returns>
        new public ObjectSearchResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ObjectSearchResultSet results = new JavaScriptSerializer().Deserialize<ObjectSearchResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ObjectSearch Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ObjectSearchResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from CloudMine.</returns>
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
