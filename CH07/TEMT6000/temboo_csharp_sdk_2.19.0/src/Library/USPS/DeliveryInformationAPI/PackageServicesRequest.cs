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

namespace Temboo.Library.USPS.DeliveryInformationAPI
{
    /// <summary>
    /// PackageServicesRequest
    /// Request USPS Parcel Post, Bound Printed Matter, Library Mail, or Media Mail shipping information for a given origin and destination.
    /// </summary>
    public class PackageServicesRequest : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PackageServicesRequest Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PackageServicesRequest(TembooSession session) : base(session, "/Library/USPS/DeliveryInformationAPI/PackageServicesRequest")
        {
        }

         /// <summary>
         /// (required, integer) First 3 digits of a 5-digit zip code.
         /// </summary>
         /// <param name="value">Value of the DestinationZip input for this Choreo.</param>
         public void setDestinationZip(String value) {
             base.addInput ("DestinationZip", value);
         }
         /// <summary>
         /// (optional, string) If you are accessing the production server, set to 'production'. Defaults to 'testing' which indicates that you are using the sandbox.
         /// </summary>
         /// <param name="value">Value of the Endpoint input for this Choreo.</param>
         public void setEndpoint(String value) {
             base.addInput ("Endpoint", value);
         }
         /// <summary>
         /// (required, integer) First 3 digits of a 5-digit zip code.  Required value.
         /// </summary>
         /// <param name="value">Value of the OriginZip input for this Choreo.</param>
         public void setOriginZip(String value) {
             base.addInput ("OriginZip", value);
         }
         /// <summary>
         /// (required, password) The password assigned by USPS
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) Alphanumeric ID assigned by USPS
         /// </summary>
         /// <param name="value">Value of the UserId input for this Choreo.</param>
         public void setUserId(String value) {
             base.addInput ("UserId", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PackageServicesRequestResultSet containing execution metadata and results.</returns>
        new public PackageServicesRequestResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PackageServicesRequestResultSet results = new JavaScriptSerializer().Deserialize<PackageServicesRequestResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PackageServicesRequest Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PackageServicesRequestResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from USPS Web Service</returns>
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
