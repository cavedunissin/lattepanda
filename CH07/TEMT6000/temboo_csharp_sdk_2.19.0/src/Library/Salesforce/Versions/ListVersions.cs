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

namespace Temboo.Library.Salesforce.Versions
{
    /// <summary>
    /// ListVersions
    /// Lists summary information about each Salesforce version currently available, including the version, label, and a link to each version's root.
    /// </summary>
    public class ListVersions : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListVersions Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListVersions(TembooSession session) : base(session, "/Library/Salesforce/Versions/ListVersions")
        {
        }

         /// <summary>
         /// (required, string) The server url prefix that indicates which instance your Salesforce account is on (e.g. na1, na2, na3, etc).
         /// </summary>
         /// <param name="value">Value of the InstanceName input for this Choreo.</param>
         public void setInstanceName(String value) {
             base.addInput ("InstanceName", value);
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
        /// <returns>A ListVersionsResultSet containing execution metadata and results.</returns>
        new public ListVersionsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListVersionsResultSet results = new JavaScriptSerializer().Deserialize<ListVersionsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListVersions Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListVersionsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Salesforce.</returns>
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
