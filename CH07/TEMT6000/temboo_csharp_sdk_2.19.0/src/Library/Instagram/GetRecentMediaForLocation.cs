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

namespace Temboo.Library.Instagram
{
    /// <summary>
    /// GetRecentMediaForLocation
    /// Retrieves a list of recent media objects from a given location.
    /// </summary>
    public class GetRecentMediaForLocation : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetRecentMediaForLocation Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetRecentMediaForLocation(TembooSession session) : base(session, "/Library/Instagram/GetRecentMediaForLocation")
        {
        }

         /// <summary>
         /// (conditional, string) The access token retrieved during the OAuth 2.0 process. Required unless you provide the ClientID.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Instagram after registering your application. Required unless you provide an AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (required, integer) The ID for the location that you want to retrieve information for.
         /// </summary>
         /// <param name="value">Value of the LocationID input for this Choreo.</param>
         public void setLocationID(String value) {
             base.addInput ("LocationID", value);
         }
         /// <summary>
         /// (optional, string) Returns media after this max_id.
         /// </summary>
         /// <param name="value">Value of the MaxID input for this Choreo.</param>
         public void setMaxID(String value) {
             base.addInput ("MaxID", value);
         }
         /// <summary>
         /// (optional, date) Returns media before this UNIX timestamp.
         /// </summary>
         /// <param name="value">Value of the MaxTimestamp input for this Choreo.</param>
         public void setMaxTimestamp(String value) {
             base.addInput ("MaxTimestamp", value);
         }
         /// <summary>
         /// (optional, string) Returns media before this min_id.
         /// </summary>
         /// <param name="value">Value of the MinID input for this Choreo.</param>
         public void setMinID(String value) {
             base.addInput ("MinID", value);
         }
         /// <summary>
         /// (optional, date) Returns media after this UNIX timestamp.
         /// </summary>
         /// <param name="value">Value of the MinTimestamp input for this Choreo.</param>
         public void setMinTimestamp(String value) {
             base.addInput ("MinTimestamp", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetRecentMediaForLocationResultSet containing execution metadata and results.</returns>
        new public GetRecentMediaForLocationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetRecentMediaForLocationResultSet results = new JavaScriptSerializer().Deserialize<GetRecentMediaForLocationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetRecentMediaForLocation Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetRecentMediaForLocationResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Instagram.</returns>
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
