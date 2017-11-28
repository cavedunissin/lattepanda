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

namespace Temboo.Library.PayPal.Merchant
{
    /// <summary>
    /// AddressVerify
    /// Confirms whether a postal address and postal code match those of the specified PayPal account holder.
    /// </summary>
    public class AddressVerify : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AddressVerify Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AddressVerify(TembooSession session) : base(session, "/Library/PayPal/Merchant/AddressVerify")
        {
        }

         /// <summary>
         /// (required, string) The email address of a PayPal member to verify.
         /// </summary>
         /// <param name="value">Value of the Email input for this Choreo.</param>
         public void setEmail(String value) {
             base.addInput ("Email", value);
         }
         /// <summary>
         /// (required, password) The API Password provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) The postal code to verify.
         /// </summary>
         /// <param name="value">Value of the PostalCode input for this Choreo.</param>
         public void setPostalCode(String value) {
             base.addInput ("PostalCode", value);
         }
         /// <summary>
         /// (required, string) The API Signature provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Signature input for this Choreo.</param>
         public void setSignature(String value) {
             base.addInput ("Signature", value);
         }
         /// <summary>
         /// (required, string) The first line of the billing or shipping address to verify.
         /// </summary>
         /// <param name="value">Value of the Street input for this Choreo.</param>
         public void setStreet(String value) {
             base.addInput ("Street", value);
         }
         /// <summary>
         /// (conditional, boolean) Set to 1 to indicate that you're testing against the PayPal sandbox instead of production. Set to 0 (the default) when moving to production.
         /// </summary>
         /// <param name="value">Value of the UseSandbox input for this Choreo.</param>
         public void setUseSandbox(String value) {
             base.addInput ("UseSandbox", value);
         }
         /// <summary>
         /// (required, string) The API Username provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AddressVerifyResultSet containing execution metadata and results.</returns>
        new public AddressVerifyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AddressVerifyResultSet results = new JavaScriptSerializer().Deserialize<AddressVerifyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AddressVerify Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AddressVerifyResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) Response from PayPal formatted in name/value pairs.</returns>
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
