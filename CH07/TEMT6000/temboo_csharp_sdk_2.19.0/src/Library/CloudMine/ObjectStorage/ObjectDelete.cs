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
    /// ObjectDelete
    /// Deletes one or more specified keys.
    /// </summary>
    public class ObjectDelete : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ObjectDelete Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ObjectDelete(TembooSession session) : base(session, "/Library/CloudMine/ObjectStorage/ObjectDelete")
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
         /// (conditional, boolean) Indicates that all keys should be deleted if the Keys input is left empty. Set to "true" to delete all keys.
         /// </summary>
         /// <param name="value">Value of the All input for this Choreo.</param>
         public void setAll(String value) {
             base.addInput ("All", value);
         }
         /// <summary>
         /// (required, string) The application identifier provided by CloudMine after registering your app.
         /// </summary>
         /// <param name="value">Value of the ApplicationIdentifier input for this Choreo.</param>
         public void setApplicationIdentifier(String value) {
             base.addInput ("ApplicationIdentifier", value);
         }
         /// <summary>
         /// (conditional, string) A comma separated list of keys to delete. Required unless specifying "true" for the All parameter.
         /// </summary>
         /// <param name="value">Value of the Keys input for this Choreo.</param>
         public void setKeys(String value) {
             base.addInput ("Keys", value);
         }
         /// <summary>
         /// (conditional, string) The session token for an existing user (returned by the AccountLogin Choreo). This is only required if your app is performing this operation on behalf of another user.
         /// </summary>
         /// <param name="value">Value of the SessionToken input for this Choreo.</param>
         public void setSessionToken(String value) {
             base.addInput ("SessionToken", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ObjectDeleteResultSet containing execution metadata and results.</returns>
        new public ObjectDeleteResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ObjectDeleteResultSet results = new JavaScriptSerializer().Deserialize<ObjectDeleteResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ObjectDelete Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ObjectDeleteResultSet : Temboo.Core.ResultSet
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