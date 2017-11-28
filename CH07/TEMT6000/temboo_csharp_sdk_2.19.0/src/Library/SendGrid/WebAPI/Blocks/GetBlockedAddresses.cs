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

namespace Temboo.Library.SendGrid.WebAPI.Blocks
{
    /// <summary>
    /// GetBlockedAddresses
    /// Retrieve a list of blocked emails, with response codes, and optional dates.
    /// </summary>
    public class GetBlockedAddresses : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetBlockedAddresses Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetBlockedAddresses(TembooSession session) : base(session, "/Library/SendGrid/WebAPI/Blocks/GetBlockedAddresses")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The username registered with SendGrid.
         /// </summary>
         /// <param name="value">Value of the APIUser input for this Choreo.</param>
         public void setAPIUser(String value) {
             base.addInput ("APIUser", value);
         }
         /// <summary>
         /// (optional, string) The timestamp of the Block records. Enter 1 to return a date in a MySQL timestamp format - YYYY-MM-DD HH:MM:SS
         /// </summary>
         /// <param name="value">Value of the Date input for this Choreo.</param>
         public void setDate(String value) {
             base.addInput ("Date", value);
         }
         /// <summary>
         /// (optional, integer) The number of days (greater than 0) for which block data will be retrieved.
         /// </summary>
         /// <param name="value">Value of the Days input for this Choreo.</param>
         public void setDays(String value) {
             base.addInput ("Days", value);
         }
         /// <summary>
         /// (optional, string) Specify the end of the date range for which blocks are to be retireved. The specified date must be in YYYY-MM-DD format.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, string) The format of the response from SendGrid, in either json, or xml.  Default is set to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The start of the date range for which blocks are to be retireved. The specified date must be in YYYY-MM-DD format, and must be earlier than the EndDate variable value.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetBlockedAddressesResultSet containing execution metadata and results.</returns>
        new public GetBlockedAddressesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetBlockedAddressesResultSet results = new JavaScriptSerializer().Deserialize<GetBlockedAddressesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetBlockedAddresses Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetBlockedAddressesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from SendGrid. The format corresponds to the ResponseFormat input. Default is json.</returns>
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
