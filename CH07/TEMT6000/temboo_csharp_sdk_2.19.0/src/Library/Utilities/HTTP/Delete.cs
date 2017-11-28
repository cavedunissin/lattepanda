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

namespace Temboo.Library.Utilities.HTTP
{
    /// <summary>
    /// Delete
    /// Generates a HTTP DELETE request.
    /// </summary>
    public class Delete : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Delete Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Delete(TembooSession session) : base(session, "/Library/Utilities/HTTP/Delete")
        {
        }

         /// <summary>
         /// (optional, boolean) When set to "true", the HTTP debug log will be returned.
         /// </summary>
         /// <param name="value">Value of the Debug input for this Choreo.</param>
         public void setDebug(String value) {
             base.addInput ("Debug", value);
         }
         /// <summary>
         /// (optional, password) A valid password. This is used if the request required basic authentication.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing up to 10 key/value pairs that will be mapped to the HTTP request headers.
         /// </summary>
         /// <param name="value">Value of the RequestHeaders input for this Choreo.</param>
         public void setRequestHeaders(String value) {
             base.addInput ("RequestHeaders", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing up to 10 key/value pairs that will be mapped to the url string as HTTP parameters.
         /// </summary>
         /// <param name="value">Value of the RequestParameters input for this Choreo.</param>
         public void setRequestParameters(String value) {
             base.addInput ("RequestParameters", value);
         }
         /// <summary>
         /// (required, string) The base URL for the request (including http:// or https://).
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }
         /// <summary>
         /// (optional, string) A valid username. This is used if the request required basic authentication.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteResultSet containing execution metadata and results.</returns>
        new public DeleteResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteResultSet results = new JavaScriptSerializer().Deserialize<DeleteResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Delete Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "HTTPLog" output from this Choreo execution
        /// <returns>String - (string) A debug log for the http request that was sent. This is only returned when Debug is set to "true".</returns>
        /// </summary>
        public String HTTPLog
        {
            get
            {
                return (String) base.Output["HTTPLog"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the server.</returns>
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
