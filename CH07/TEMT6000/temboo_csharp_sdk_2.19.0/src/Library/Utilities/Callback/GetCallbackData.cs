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

namespace Temboo.Library.Utilities.Callback
{
    /// <summary>
    /// GetCallbackData
    /// Retrieves data captured from a request to your callback URL.
    /// </summary>
    public class GetCallbackData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetCallbackData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetCallbackData(TembooSession session) : base(session, "/Library/Utilities/Callback/GetCallbackData")
        {
        }

         /// <summary>
         /// (required, string) The ID that can used to retrieve request data that the callback URL has captured.
         /// </summary>
         /// <param name="value">Value of the CallbackID input for this Choreo.</param>
         public void setCallbackID(String value) {
             base.addInput ("CallbackID", value);
         }
         /// <summary>
         /// (optional, string) Allows you to filter callback data by a query parameter key-value pair. FilterValue is required when using this input.
         /// </summary>
         /// <param name="value">Value of the FilterName input for this Choreo.</param>
         public void setFilterName(String value) {
             base.addInput ("FilterName", value);
         }
         /// <summary>
         /// (optional, string) Allows you to filter callback data by a query parameter key-value pair. FilterName is required when using this input.
         /// </summary>
         /// <param name="value">Value of the FilterValue input for this Choreo.</param>
         public void setFilterValue(String value) {
             base.addInput ("FilterValue", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetCallbackDataResultSet containing execution metadata and results.</returns>
        new public GetCallbackDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetCallbackDataResultSet results = new JavaScriptSerializer().Deserialize<GetCallbackDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetCallbackData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetCallbackDataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CallbackData" output from this Choreo execution
        /// <returns>String - Contains the request data received at your CalllbackURL.</returns>
        /// </summary>
        public String CallbackData
        {
            get
            {
                return (String) base.Output["CallbackData"];
            }
        }
    }
}
