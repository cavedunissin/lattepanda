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

namespace Temboo.Library.Xively.APIKeys
{
    /// <summary>
    /// CreateKey
    /// Creates a new APIKey.
    /// </summary>
    public class CreateKey : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateKey Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateKey(TembooSession session) : base(session, "/Library/Xively/APIKeys/CreateKey")
        {
        }

         /// <summary>
         /// (required, string) The master API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (conditional, string) Comma-separated input containing one or more allowed HTTP methods that the key is allowed. Valid values: get, put, post, and/or delete. Ex.: "put,post". Required unless writing your own CustomKey.
         /// </summary>
         /// <param name="value">Value of the AccessMethods input for this Choreo.</param>
         public void setAccessMethods(String value) {
             base.addInput ("AccessMethods", value);
         }
         /// <summary>
         /// (optional, any) Optional Custom key to send to Xively. Type and format depends on CustomType. Please see documentation for more information on constructing your own body. If used, all other scalar inputs are ignored.
         /// </summary>
         /// <param name="value">Value of the CustomKey input for this Choreo.</param>
         public void setCustomKey(String value) {
             base.addInput ("CustomKey", value);
         }
         /// <summary>
         /// (optional, any) Optional custom permissions for advanced configuration. Type and format depends on CustomType. If specified, ignores SourceIP, ResourcesData and AccessMethodsData.
         /// </summary>
         /// <param name="value">Value of the CustomPermissions input for this Choreo.</param>
         public void setCustomPermissions(String value) {
             base.addInput ("CustomPermissions", value);
         }
         /// <summary>
         /// (optional, string) The datatype that is being input if adding custom permission objects. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the CustomType input for this Choreo.</param>
         public void setCustomType(String value) {
             base.addInput ("CustomType", value);
         }
         /// <summary>
         /// (optional, date) Expiration date for the key, after which it won't work. Must be in ISO 8601 format, default zone is UTC.  Ex: 2013-05-07T00:00:00Z.
         /// </summary>
         /// <param name="value">Value of the ExpirationDate input for this Choreo.</param>
         public void setExpirationDate(String value) {
             base.addInput ("ExpirationDate", value);
         }
         /// <summary>
         /// (conditional, string) A label by which the key can be referenced. Required unless writing your own CustomKey.
         /// </summary>
         /// <param name="value">Value of the Label input for this Choreo.</param>
         public void setLabel(String value) {
             base.addInput ("Label", value);
         }
         /// <summary>
         /// (optional, string) Flag that indicates whether this key can access private resources belonging to the user. To turn on, input "true", leave blank for "false".
         /// </summary>
         /// <param name="value">Value of the PrivateAccess input for this Choreo.</param>
         public void setPrivateAccess(String value) {
             base.addInput ("PrivateAccess", value);
         }
         /// <summary>
         /// (optional, integer) Specify a particular FeedID that the new APIKey should have access to. If not specified, the new APIKey permissions will apply to all feeds you are authorized to access.
         /// </summary>
         /// <param name="value">Value of the ResourceFeedID input for this Choreo.</param>
         public void setResourceFeedID(String value) {
             base.addInput ("ResourceFeedID", value);
         }
         /// <summary>
         /// (optional, string) An IP address that, when specified, limits incoming requests to that specific IP address only.
         /// </summary>
         /// <param name="value">Value of the SourceIP input for this Choreo.</param>
         public void setSourceIP(String value) {
             base.addInput ("SourceIP", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateKeyResultSet containing execution metadata and results.</returns>
        new public CreateKeyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateKeyResultSet results = new JavaScriptSerializer().Deserialize<CreateKeyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateKey Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateKeyResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "APIKeyLocation" output from this Choreo execution
        /// <returns>String - (string) The URL of the newly created APIKey.</returns>
        /// </summary>
        public String APIKeyLocation
        {
            get
            {
                return (String) base.Output["APIKeyLocation"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "NewAPIKey" output from this Choreo execution
        /// <returns>String - (string) The new APIKey obtained from the APIKeyLocation returned by this Choreo.</returns>
        /// </summary>
        public String NewAPIKey
        {
            get
            {
                return (String) base.Output["NewAPIKey"];
            }
        }
    }
}
