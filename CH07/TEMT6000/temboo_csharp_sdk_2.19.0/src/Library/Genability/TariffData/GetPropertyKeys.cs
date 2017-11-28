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

namespace Temboo.Library.Genability.TariffData
{
    /// <summary>
    /// GetPropertyKeys
    /// Returns a list of Property Keys based on a specified search criteria.
    /// </summary>
    public class GetPropertyKeys : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetPropertyKeys Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetPropertyKeys(TembooSession session) : base(session, "/Library/Genability/TariffData/GetPropertyKeys")
        {
        }

         /// <summary>
         /// (conditional, string) The App ID provided by Genability.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, string) The App Key provided by Genability.
         /// </summary>
         /// <param name="value">Value of the AppKey input for this Choreo.</param>
         public void setAppKey(String value) {
             base.addInput ("AppKey", value);
         }
         /// <summary>
         /// (optional, string) Filters the result so that only Properties that belong to this EntityID are returned. When specified, EntityType must also be specified.
         /// </summary>
         /// <param name="value">Value of the EntityID input for this Choreo.</param>
         public void setEntityID(String value) {
             base.addInput ("EntityID", value);
         }
         /// <summary>
         /// (optional, string) Filters the result so that only Properties that belong to this EntityType are returned. When specified, EntityID must also be specified.
         /// </summary>
         /// <param name="value">Value of the EntityType input for this Choreo.</param>
         public void setEntityType(String value) {
             base.addInput ("EntityType", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to return. Defaults to 25.
         /// </summary>
         /// <param name="value">Value of the PageCount input for this Choreo.</param>
         public void setPageCount(String value) {
             base.addInput ("PageCount", value);
         }
         /// <summary>
         /// (optional, integer) The page number to begin the result set from. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the PageStart input for this Choreo.</param>
         public void setPageStart(String value) {
             base.addInput ("PageStart", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetPropertyKeysResultSet containing execution metadata and results.</returns>
        new public GetPropertyKeysResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetPropertyKeysResultSet results = new JavaScriptSerializer().Deserialize<GetPropertyKeysResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetPropertyKeys Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetPropertyKeysResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Genability.</returns>
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
