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

namespace Temboo.Library.Utilities.DataConversions
{
    /// <summary>
    /// XMLToJSON
    /// Converts data from XML format to JSON format.
    /// </summary>
    public class XMLToJSON : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the XMLToJSON Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public XMLToJSON(TembooSession session) : base(session, "/Library/Utilities/DataConversions/XMLToJSON")
        {
        }

         /// <summary>
         /// (required, xml) The XML file that you want to convert to JSON format.
         /// </summary>
         /// <param name="value">Value of the XML input for this Choreo.</param>
         public void setXML(String value) {
             base.addInput ("XML", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A XMLToJSONResultSet containing execution metadata and results.</returns>
        new public XMLToJSONResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            XMLToJSONResultSet results = new JavaScriptSerializer().Deserialize<XMLToJSONResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the XMLToJSON Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class XMLToJSONResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "JSON" output from this Choreo execution
        /// <returns>String - (json) The converted data in JSON format.</returns>
        /// </summary>
        public String JSON
        {
            get
            {
                return (String) base.Output["JSON"];
            }
        }
    }
}
