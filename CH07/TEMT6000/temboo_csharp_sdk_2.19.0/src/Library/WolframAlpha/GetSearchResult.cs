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

namespace Temboo.Library.WolframAlpha
{
    /// <summary>
    /// GetSearchResult
    /// Allows your application to submit a query to Wolfram|Alpha and return only the plain text from the first result pod.
    /// </summary>
    public class GetSearchResult : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetSearchResult Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetSearchResult(TembooSession session) : base(session, "/Library/WolframAlpha/GetSearchResult")
        {
        }

         /// <summary>
         /// (required, string) The App ID provided by Wolfram|Alpha.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, string) Specifies the input string (e.g., "5 largest countries").
         /// </summary>
         /// <param name="value">Value of the Input input for this Choreo.</param>
         public void setInput(String value) {
             base.addInput ("Input", value);
         }
         /// <summary>
         /// (optional, decimal) When query results depend on your location, use this parameter to specify a latitude point.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (optional, string) When query results depend on your location, use this parameter to specify a location such as "Los Angeles, CA", or "Madrid".
         /// </summary>
         /// <param name="value">Value of the Location input for this Choreo.</param>
         public void setLocation(String value) {
             base.addInput ("Location", value);
         }
         /// <summary>
         /// (optional, decimal) When query results depend on your location, use this parameter to specify a longitude point.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, string) The format for the response. Valid values are JSON and XML. This will be ignored when providng an XPath query because results are returned as a string or JSON depending on the Mode specified.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Whether to allow Wolfram Alpha to try to translate simple queries into English. Defaults to true.
         /// </summary>
         /// <param name="value">Value of the Translation input for this Choreo.</param>
         public void setTranslation(String value) {
             base.addInput ("Translation", value);
         }
         /// <summary>
         /// (optional, string) Lets you specify the preferred measurement system, either "metric" or "nonmetric" (U.S. customary units).
         /// </summary>
         /// <param name="value">Value of the Units input for this Choreo.</param>
         public void setUnits(String value) {
             base.addInput ("Units", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetSearchResultResultSet containing execution metadata and results.</returns>
        new public GetSearchResultResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetSearchResultResultSet results = new JavaScriptSerializer().Deserialize<GetSearchResultResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetSearchResult Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetSearchResultResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Result" output from this Choreo execution
        /// <returns>String - (string) The plain text result parsed from the Wolfram Alpha response.</returns>
        /// </summary>
        public String Result
        {
            get
            {
                return (String) base.Output["Result"];
            }
        }
    }
}
