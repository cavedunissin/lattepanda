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

namespace Temboo.Library.Stripe.Customers
{
    /// <summary>
    /// UpdateCustomer
    /// Updates a specified customer record.
    /// </summary>
    public class UpdateCustomer : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateCustomer Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateCustomer(TembooSession session) : base(session, "/Library/Stripe/Customers/UpdateCustomer")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Stripe
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, integer) The amount in cents for the starting account balance. A negative amount represents a credit that will be used before charging the customer's card; a positive amount will be added to the next invoice.
         /// </summary>
         /// <param name="value">Value of the AccountBalance input for this Choreo.</param>
         public void setAccountBalance(String value) {
             base.addInput ("AccountBalance", value);
         }
         /// <summary>
         /// (optional, string) If you provide a coupon code, it can be specified here
         /// </summary>
         /// <param name="value">Value of the Coupon input for this Choreo.</param>
         public void setCoupon(String value) {
             base.addInput ("Coupon", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the customer you want to update
         /// </summary>
         /// <param name="value">Value of the CustomerID input for this Choreo.</param>
         public void setCustomerID(String value) {
             base.addInput ("CustomerID", value);
         }
         /// <summary>
         /// (optional, string) An arbitrary string of text that will be associated with the charge as a description
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) The customer's email address
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (optional, json) A JSON object used to attach key-value data to this Stripe object.
         /// </summary>
         /// <param name="value">Value of the Metadata input for this Choreo.</param>
         public void setMetadata(String value) {
             base.addInput ("Metadata", value);
         }
         /// <summary>
         /// (optional, string) The token associated with a set of credit card details.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateCustomerResultSet containing execution metadata and results.</returns>
        new public UpdateCustomerResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateCustomerResultSet results = new JavaScriptSerializer().Deserialize<UpdateCustomerResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateCustomer Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateCustomerResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Stripe</returns>
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
