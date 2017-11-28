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
    /// XMLToTSV
    /// Converts an XML file to TSV format (TAB-separated values).
    /// </summary>
    public class XMLToTSV : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the XMLToTSV Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public XMLToTSV(TembooSession session) : base(session, "/Library/Utilities/DataConversions/XMLToTSV")
        {
        }

         /// <summary>
         /// (required, xml) The XML file to convert to TSV data.
         /// </summary>
         /// <param name="value">Value of the XML input for this Choreo.</param>
         public void setXML(String value) {
             base.addInput ("XML", value);
         }
         /// <summary>
         /// (optional, string) If your XML is not in "/rowset/row/column_name" format, specify a path to the rows. See documentation for examples.
         /// </summary>
         /// <param name="value">Value of the Path input for this Choreo.</param>
         public void setPath(String value) {
             base.addInput ("Path", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A XMLToTSVResultSet containing execution metadata and results.</returns>
        new public XMLToTSVResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            XMLToTSVResultSet results = new JavaScriptSerializer().Deserialize<XMLToTSVResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the XMLToTSV Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class XMLToTSVResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "TSV" output from this Choreo execution
        /// <returns>String - (multiline) The tab-separated data generated from the XML input.</returns>
        /// </summary>
        public String TSV
        {
            get
            {
                return (String) base.Output["TSV"];
            }
        }
    }
}
