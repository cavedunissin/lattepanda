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

namespace Temboo.Library.SendGrid.WebAPI.Bounces
{
    /// <summary>
    /// DeleteBouncedAddress
    /// Delete an address from the bounced email list.
    /// </summary>
    public class DeleteBouncedAddress : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DeleteBouncedAddress Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DeleteBouncedAddress(TembooSession session) : base(session, "/Library/SendGrid/WebAPI/Bounces/DeleteBouncedAddress")
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
         /// (optional, string) The valid email address to be deleted from your block list.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (optional, string) The end of the date range for which blocks are to be retireved. The specified date must be in YYYY-MM-DD format.
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
         /// (optional, string) The type of bounce to search for. Choices include: hard, or soft.
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteBouncedAddressResultSet containing execution metadata and results.</returns>
        new public DeleteBouncedAddressResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteBouncedAddressResultSet results = new JavaScriptSerializer().Deserialize<DeleteBouncedAddressResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DeleteBouncedAddress Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteBouncedAddressResultSet : Temboo.Core.ResultSet
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
