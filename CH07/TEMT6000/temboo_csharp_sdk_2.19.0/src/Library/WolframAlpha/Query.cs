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
    /// Query
    /// Allows your application to submit free-form queries similar to the queries one might enter at the Wolfram|Alpha website.
    /// </summary>
    public class Query : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Query Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Query(TembooSession session) : base(session, "/Library/WolframAlpha/Query")
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
         /// (optional, string) Up to 10 comma-seperated assumptions to narrow a query.  Wolfram|Alpha provides you with a list of assumptons in the response of a previous query.  Please consult the documentation for more details.
         /// </summary>
         /// <param name="value">Value of the Assumption input for this Choreo.</param>
         public void setAssumption(String value) {
             base.addInput ("Assumption", value);
         }
         /// <summary>
         /// (optional, boolean) Set to true to specify that asynchronous mode should be used. This allows partial results to come back before all the pods are computed.
         /// </summary>
         /// <param name="value">Value of the Async input for this Choreo.</param>
         public void setAsync(String value) {
             base.addInput ("Async", value);
         }
         /// <summary>
         /// (optional, string) Specifies the IDs of the pod(s) to exlude from the response. All pod IDs are returned by default.
         /// </summary>
         /// <param name="value">Value of the ExcludePodID input for this Choreo.</param>
         public void setExcludePodID(String value) {
             base.addInput ("ExcludePodID", value);
         }
         /// <summary>
         /// (optional, string) The desired result formats separated by commas. Valid values are image, plaintext, minput, moutput, cell, mathml, imagemap, sound, wav. Defaults to "plaintext,image".
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (optional, decimal) The number of seconds to allow Wolfram Alpha to spend in the "format" stage for the entire collection of pods. Default value is 8.0.
         /// </summary>
         /// <param name="value">Value of the FormatTimeout input for this Choreo.</param>
         public void setFormatTimeout(String value) {
             base.addInput ("FormatTimeout", value);
         }
         /// <summary>
         /// (optional, boolean) Whether to force Wolfram Alpha to ignore case in queries. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the IgnoreCase input for this Choreo.</param>
         public void setIgnoreCase(String value) {
             base.addInput ("IgnoreCase", value);
         }
         /// <summary>
         /// (optional, string) Specifies the IDs of the pod(s) to include in the response. All pod IDs are returned by default.
         /// </summary>
         /// <param name="value">Value of the IncludePodID input for this Choreo.</param>
         public void setIncludePodID(String value) {
             base.addInput ("IncludePodID", value);
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
         /// (optional, decimal) Controls the magnification of pod images. The default value is 1.0, indicating no magnification.
         /// </summary>
         /// <param name="value">Value of the Magnification input for this Choreo.</param>
         public void setMagnification(String value) {
             base.addInput ("Magnification", value);
         }
         /// <summary>
         /// (optional, integer) Used to change the default width of pod images. Width and MaxWidth apply to images of text and tables. This can be used to avoid undesirable line breaks if the value of Width is too small.
         /// </summary>
         /// <param name="value">Value of the MaxWidth input for this Choreo.</param>
         public void setMaxWidth(String value) {
             base.addInput ("MaxWidth", value);
         }
         /// <summary>
         /// (optional, decimal) The number of seconds to allow Wolfram Alpha to spend in the "parsing" stage of processing. Default value is 5.0.
         /// </summary>
         /// <param name="value">Value of the ParseTimeout input for this Choreo.</param>
         public void setParseTimeout(String value) {
             base.addInput ("ParseTimeout", value);
         }
         /// <summary>
         /// (optional, integer) Controls the width at which plots and graphics are rendered. The default value is 200 pixels.
         /// </summary>
         /// <param name="value">Value of the PlotWidth input for this Choreo.</param>
         public void setPlotWidth(String value) {
             base.addInput ("PlotWidth", value);
         }
         /// <summary>
         /// (optional, string) Specifies the index of the pod(s) to return. This is an alternative to specifying pods by title or ID. You can give a single number or a sequence like "2,3,5".
         /// </summary>
         /// <param name="value">Value of the PodIndex input for this Choreo.</param>
         public void setPodIndex(String value) {
             base.addInput ("PodIndex", value);
         }
         /// <summary>
         /// (optional, string) Specifies a pod state change, which replaces a pod with a modified version, such as a switch from Imperial to metric units.
         /// </summary>
         /// <param name="value">Value of the PodState input for this Choreo.</param>
         public void setPodState(String value) {
             base.addInput ("PodState", value);
         }
         /// <summary>
         /// (optional, decimal) The number of seconds to allow Wolfram Alpha to spend in the "format" stage for any one pod. Default value is 4.0.
         /// </summary>
         /// <param name="value">Value of the PodTimeout input for this Choreo.</param>
         public void setPodTimeout(String value) {
             base.addInput ("PodTimeout", value);
         }
         /// <summary>
         /// (optional, string) Specifies the titles of the pod(s) to include in the response. All pod titles are returned by default. You can use * as a wildcard to match zero or more characters in pod titles.
         /// </summary>
         /// <param name="value">Value of the PodTitle input for this Choreo.</param>
         public void setPodTitle(String value) {
             base.addInput ("PodTitle", value);
         }
         /// <summary>
         /// (optional, boolean) Whether to allow Wolfram Alpha to reinterpret queries that would otherwise not be understood. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the Reinterpret input for this Choreo.</param>
         public void setReinterpret(String value) {
             base.addInput ("Reinterpret", value);
         }
         /// <summary>
         /// (optional, string) The format for the response. Valid values are JSON and XML. This will be ignored when providng an XPath query because results are returned as a string or JSON depending on the Mode specified.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, decimal) The number of seconds to allow Wolfram Alpha to compute results in the "scan" stage of processing. Default value is 3.0.
         /// </summary>
         /// <param name="value">Value of the ScanTimeout input for this Choreo.</param>
         public void setScanTimeout(String value) {
             base.addInput ("ScanTimeout", value);
         }
         /// <summary>
         /// (optional, string) Specifies that only pods produced by the given scanner should be returned. (e.g. Numeric, Music).  Defaults to all pods.
         /// </summary>
         /// <param name="value">Value of the Scanner input for this Choreo.</param>
         public void setScanner(String value) {
             base.addInput ("Scanner", value);
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
         /// (optional, integer) Used to change the default width of pod images. The default is 500 pixels. Width and MaxWidth apply to images of text and tables.
         /// </summary>
         /// <param name="value">Value of the Width input for this Choreo.</param>
         public void setWidth(String value) {
             base.addInput ("Width", value);
         }
         /// <summary>
         /// (optional, string) An XPath query to apply to the API results.
         /// </summary>
         /// <param name="value">Value of the XPath input for this Choreo.</param>
         public void setXPath(String value) {
             base.addInput ("XPath", value);
         }
         /// <summary>
         /// (optional, string) Valid values are "select" (the default) or "recursive". Recursive mode will iterate using the provided XPath. Select mode will return the first match at the position indicated by the provided XPath.
         /// </summary>
         /// <param name="value">Value of the XPathMode input for this Choreo.</param>
         public void setXPathMode(String value) {
             base.addInput ("XPathMode", value);
         }
         /// <summary>
         /// (optional, string) A regular expression that can be applied to the result of the XPath query provided.
         /// </summary>
         /// <param name="value">Value of the XPathRegex input for this Choreo.</param>
         public void setXPathRegex(String value) {
             base.addInput ("XPathRegex", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A QueryResultSet containing execution metadata and results.</returns>
        new public QueryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            QueryResultSet results = new JavaScriptSerializer().Deserialize<QueryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Query Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class QueryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Wolfram Alpha.</returns>
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
