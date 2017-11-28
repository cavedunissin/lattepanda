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

namespace Temboo.Library.Utilities.Validation
{
    /// <summary>
    /// XML
    /// Validates XML for basic well-formedness and allows you to check XML against a specified XSD schema file.
    /// </summary>
    public class XML : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the XML Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public XML(TembooSession session) : base(session, "/Library/Utilities/Validation/XML")
        {
        }

         /// <summary>
         /// (required, xml) The XML file you want to validate.
         /// </summary>
         /// <param name="value">Value of the XMLFile input for this Choreo.</param>
         public void setXMLFile(String value) {
             base.addInput ("XMLFile", value);
         }
         /// <summary>
         /// (optional, xml) The XSD file to validate an XML file against.
         /// </summary>
         /// <param name="value">Value of the XSDFile input for this Choreo.</param>
         public void setXSDFile(String value) {
             base.addInput ("XSDFile", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A XMLResultSet containing execution metadata and results.</returns>
        new public XMLResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            XMLResultSet results = new JavaScriptSerializer().Deserialize<XMLResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the XML Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class XMLResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Error" output from this Choreo execution
        /// <returns>String - (string) The error description that is generated if a validation error occurs.</returns>
        /// </summary>
        public String Error
        {
            get
            {
                return (String) base.Output["Error"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Result" output from this Choreo execution
        /// <returns>String - (string) The result of the validation. Returns the string "valid" or "invalid".</returns>
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
