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
    /// XLSToXML
    /// Converts Excel (.xls) formatted data to XML.
    /// </summary>
    public class XLSToXML : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the XLSToXML Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public XLSToXML(TembooSession session) : base(session, "/Library/Utilities/DataConversions/XLSToXML")
        {
        }

         /// <summary>
         /// (conditional, string) The base64-encoded contents of the Excel file that you want to convert to XML. Compatible with Excel 97-2003.
         /// </summary>
         /// <param name="value">Value of the XLS input for this Choreo.</param>
         public void setXLS(String value) {
             base.addInput ("XLS", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A XLSToXMLResultSet containing execution metadata and results.</returns>
        new public XLSToXMLResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            XLSToXMLResultSet results = new JavaScriptSerializer().Deserialize<XLSToXMLResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the XLSToXML Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class XLSToXMLResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "XML" output from this Choreo execution
        /// <returns>String - (xml) The data in XML format.</returns>
        /// </summary>
        public String XML
        {
            get
            {
                return (String) base.Output["XML"];
            }
        }
    }
}
