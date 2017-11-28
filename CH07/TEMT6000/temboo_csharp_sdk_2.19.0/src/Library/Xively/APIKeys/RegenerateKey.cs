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
    /// RegenerateKey
    /// Allows you to regenerate a new key with the same attributes and permissions as a previous key.
    /// </summary>
    public class RegenerateKey : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RegenerateKey Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RegenerateKey(TembooSession session) : base(session, "/Library/Xively/APIKeys/RegenerateKey")
        {
        }

         /// <summary>
         /// (required, string) The API Key you would like to regenerate. On successful regeneration, this API Key will no longer be valid.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Specify a MasterAPIKey with sufficient permissions if the APIKey you would like to regenerate does not have the permissions to do so.
         /// </summary>
         /// <param name="value">Value of the MasterAPIKey input for this Choreo.</param>
         public void setMasterAPIKey(String value) {
             base.addInput ("MasterAPIKey", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RegenerateKeyResultSet containing execution metadata and results.</returns>
        new public RegenerateKeyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RegenerateKeyResultSet results = new JavaScriptSerializer().Deserialize<RegenerateKeyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RegenerateKey Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RegenerateKeyResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "APIKeyLocation" output from this Choreo execution
        /// <returns>String - (string) The URL of the newly regenerated APIKey.</returns>
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
        /// <returns>String - (string) The regenerated APIKey obtained from the APIKeyLocation returned by this Choreo.</returns>
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
