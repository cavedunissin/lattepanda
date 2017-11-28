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

namespace Temboo.Library.Microsoft.PowerBI
{
    /// <summary>
    /// CreateDataset
    /// Creates a new Dataset from a JSON schema definition and returns the Dataset ID and the properties of the dataset created.
    /// </summary>
    public class CreateDataset : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateDataset Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateDataset(TembooSession session) : base(session, "/Library/Microsoft/PowerBI/CreateDataset")
        {
        }

         /// <summary>
         /// (required, json) A JSON object containing information about the dataset table and columns. See Choreo notes for formatting details.
         /// </summary>
         /// <param name="value">Value of the SchemaDefinition input for this Choreo.</param>
         public void setSchemaDefinition(String value) {
             base.addInput ("SchemaDefinition", value);
         }
         /// <summary>
         /// (optional, string) A valid Access Token retrieved during the OAuth process. This can be passed if your application is authenticating multiple Power BI users.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Power BI. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Power BI. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) Enables a default retention policy to automatically clean up old data while keeping a constant flow of new data going into your dashboard. Valid values are: None (the default) or basicFIFO.
         /// </summary>
         /// <param name="value">Value of the DefaultRetentionPolicy input for this Choreo.</param>
         public void setDefaultRetentionPolicy(String value) {
             base.addInput ("DefaultRetentionPolicy", value);
         }
         /// <summary>
         /// (conditional, password) Your Power BI password. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (conditional, string) Your Power BI username. This is requried unless providing a valid AccessToken (see optional inputs).
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateDatasetResultSet containing execution metadata and results.</returns>
        new public CreateDatasetResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateDatasetResultSet results = new JavaScriptSerializer().Deserialize<CreateDatasetResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateDataset Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateDatasetResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Power BI.</returns>
        /// </summary>
        public String ResponseCode
        {
            get
            {
                return (String) base.Output["ResponseCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Power BI.</returns>
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
