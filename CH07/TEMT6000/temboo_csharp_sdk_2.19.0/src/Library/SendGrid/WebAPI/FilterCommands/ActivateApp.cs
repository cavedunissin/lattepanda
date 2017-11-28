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

namespace Temboo.Library.SendGrid.WebAPI.FilterCommands
{
    /// <summary>
    /// ActivateApp
    /// Activate an app.
    /// </summary>
    public class ActivateApp : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ActivateApp Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ActivateApp(TembooSession session) : base(session, "/Library/SendGrid/WebAPI/FilterCommands/ActivateApp")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The username registered with SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIUser input for this Choreo.</param>
         public void setAPIUser(String value) {
             base.addInput ("APIUser", value);
         }
         /// <summary>
         /// (required, string) The name of the app to be activated.  A list of available apps can be obtained by running the ListAvailableApps Choreo.
         /// </summary>
         /// <param name="value">Value of the AppName input for this Choreo.</param>
         public void setAppName(String value) {
             base.addInput ("AppName", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from SendGrid, in either json, or xml.  Default is set to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ActivateAppResultSet containing execution metadata and results.</returns>
        new public ActivateAppResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ActivateAppResultSet results = new JavaScriptSerializer().Deserialize<ActivateAppResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ActivateApp Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ActivateAppResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from SendGrid. The format corresponds to the ResponseFormat input. Default is json.</returns>
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
