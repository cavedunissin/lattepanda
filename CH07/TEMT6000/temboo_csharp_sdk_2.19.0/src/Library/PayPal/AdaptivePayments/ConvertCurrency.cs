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

namespace Temboo.Library.PayPal.AdaptivePayments
{
    /// <summary>
    /// ConvertCurrency
    /// Converts a payment amount from one currency to another.
    /// </summary>
    public class ConvertCurrency : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ConvertCurrency Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ConvertCurrency(TembooSession session) : base(session, "/Library/PayPal/AdaptivePayments/ConvertCurrency")
        {
        }

         /// <summary>
         /// (required, decimal) The amount that should be converted to a new currency.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (required, string) Your PayPal AppID (or the default AppID for the PayPal sandbox).
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, string) The currency code that you want to convert to (i.e. GBP).
         /// </summary>
         /// <param name="value">Value of the ConvertToCurrency input for this Choreo.</param>
         public void setConvertToCurrency(String value) {
             base.addInput ("ConvertToCurrency", value);
         }
         /// <summary>
         /// (required, string) The currency code that you want to convert. (i.e. USD).
         /// </summary>
         /// <param name="value">Value of the CurrencyCode input for this Choreo.</param>
         public void setCurrencyCode(String value) {
             base.addInput ("CurrencyCode", value);
         }
         /// <summary>
         /// (required, password) The API Password provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) The API Signature provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Signature input for this Choreo.</param>
         public void setSignature(String value) {
             base.addInput ("Signature", value);
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
        /// <returns>A ConvertCurrencyResultSet containing execution metadata and results.</returns>
        new public ConvertCurrencyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ConvertCurrencyResultSet results = new JavaScriptSerializer().Deserialize<ConvertCurrencyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ConvertCurrency Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ConvertCurrencyResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from PayPal.</returns>
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
