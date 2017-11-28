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
    /// MassPayments
    /// Generates multiple payments from your PayPal Premier account or Business account to existing PayPal account holders.
    /// </summary>
    public class MassPayments : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the MassPayments Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public MassPayments(TembooSession session) : base(session, "/Library/PayPal/Merchant/MassPayments")
        {
        }

         /// <summary>
         /// (required, any) An input file containing the payments to process. This data can either be in CSV or XML format. The format should be indicated using the InputFormat input. See Choreo documentation for schema details.
         /// </summary>
         /// <param name="value">Value of the InputFile input for this Choreo.</param>
         public void setInputFile(String value) {
             base.addInput ("InputFile", value);
         }
         /// <summary>
         /// (optional, string) The subject line of the email that PayPal sends when the transaction is completed. This is the same for all recipients. Character length and limitations: 255 single-byte alphanumeric characters.
         /// </summary>
         /// <param name="value">Value of the EmailSubject input for this Choreo.</param>
         public void setEmailSubject(String value) {
             base.addInput ("EmailSubject", value);
         }
         /// <summary>
         /// (required, string) The type of input you are providing for this mass payment. Accepted values are "csv" or "xml". See Choreo documentation for expected schema details.
         /// </summary>
         /// <param name="value">Value of the InputFormat input for this Choreo.</param>
         public void setInputFormat(String value) {
             base.addInput ("InputFormat", value);
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
        /// <returns>A MassPaymentsResultSet containing execution metadata and results.</returns>
        new public MassPaymentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            MassPaymentsResultSet results = new JavaScriptSerializer().Deserialize<MassPaymentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the MassPayments Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class MassPaymentsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Result" output from this Choreo execution
        /// <returns>String - The MassPayment result from PayPal returned in the same format you've submitted.</returns>
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
