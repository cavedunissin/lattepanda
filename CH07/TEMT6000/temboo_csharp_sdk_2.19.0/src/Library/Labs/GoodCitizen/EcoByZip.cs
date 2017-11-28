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

namespace Temboo.Library.Labs.GoodCitizen
{
    /// <summary>
    /// EcoByZip
    /// Returns a host of eco-conscious environmental information for a specified location based on zip code.
    /// </summary>
    public class EcoByZip : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the EcoByZip Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public EcoByZip(TembooSession session) : base(session, "/Library/Labs/GoodCitizen/EcoByZip")
        {
        }

         /// <summary>
         /// (optional, string) A JSON dictionary containing credentials for Genability. See Choreo documentation for formatting examples.
         /// </summary>
         /// <param name="value">Value of the APICredentials input for this Choreo.</param>
         public void setAPICredentials(String value) {
             base.addInput ("APICredentials", value);
         }
         /// <summary>
         /// (optional, integer) The number of facility records to search for in the Envirofacts database.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, integer) The zip code for the user's current location.
         /// </summary>
         /// <param name="value">Value of the Zip input for this Choreo.</param>
         public void setZip(String value) {
             base.addInput ("Zip", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A EcoByZipResultSet containing execution metadata and results.</returns>
        new public EcoByZipResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            EcoByZipResultSet results = new JavaScriptSerializer().Deserialize<EcoByZipResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the EcoByZip Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class EcoByZipResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from the Eco Choreo.</returns>
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
