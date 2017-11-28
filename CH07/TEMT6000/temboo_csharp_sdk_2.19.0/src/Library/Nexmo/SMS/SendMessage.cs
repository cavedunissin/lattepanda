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

namespace Temboo.Library.Nexmo.SMS
{
    /// <summary>
    /// SendMessage
    /// Send a text message to any global number.
    /// </summary>
    public class SendMessage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SendMessage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SendMessage(TembooSession session) : base(session, "/Library/Nexmo/SMS/SendMessage")
        {
        }

         /// <summary>
         /// (required, string) Your API Key provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Your API Secret provided to you by Nexmo.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (optional, string) Hex encoded binary data. (e.g. 0011223344556677).  Required when Type is binary.
         /// </summary>
         /// <param name="value">Value of the Body input for this Choreo.</param>
         public void setBody(String value) {
             base.addInput ("Body", value);
         }
         /// <summary>
         /// (conditional, string) A unique identifier that is part of your Temboo callback URL registered at Nexmo. Required in order to listen for a reply. See Choreo description for details.
         /// </summary>
         /// <param name="value">Value of the CallbackID input for this Choreo.</param>
         public void setCallbackID(String value) {
             base.addInput ("CallbackID", value);
         }
         /// <summary>
         /// (optional, string) Include a note for your reference. (40 characters max).
         /// </summary>
         /// <param name="value">Value of the ClientReference input for this Choreo.</param>
         public void setClientReference(String value) {
             base.addInput ("ClientReference", value);
         }
         /// <summary>
         /// (optional, integer) Set to 1 to receive a Delivery Receipt for this message. Make sure to configure your "Callback URL" in your "API Settings".
         /// </summary>
         /// <param name="value">Value of the DeliveryReceipt input for this Choreo.</param>
         public void setDeliveryReceipt(String value) {
             base.addInput ("DeliveryReceipt", value);
         }
         /// <summary>
         /// (required, string) The phone number associated with your Nexmo account e.g. 17185551234.
         /// </summary>
         /// <param name="value">Value of the From input for this Choreo.</param>
         public void setFrom(String value) {
             base.addInput ("From", value);
         }
         /// <summary>
         /// (optional, integer) Set to 0 for Flash SMS.
         /// </summary>
         /// <param name="value">Value of the MessageClass input for this Choreo.</param>
         public void setMessageClass(String value) {
             base.addInput ("MessageClass", value);
         }
         /// <summary>
         /// (optional, string) Sends this message to the specifed network operator (MCCMNC).
         /// </summary>
         /// <param name="value">Value of the NetworkCode input for this Choreo.</param>
         public void setNetworkCode(String value) {
             base.addInput ("NetworkCode", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "json" (the default) and "xml".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, integer) Message life span (Time to  live) in milliseconds.
         /// </summary>
         /// <param name="value">Value of the TTL input for this Choreo.</param>
         public void setTTL(String value) {
             base.addInput ("TTL", value);
         }
         /// <summary>
         /// (conditional, string) Required when Type is "text".  Body of the text message (with a maximum length of 3200 characters).
         /// </summary>
         /// <param name="value">Value of the Text input for this Choreo.</param>
         public void setText(String value) {
             base.addInput ("Text", value);
         }
         /// <summary>
         /// (conditional, integer) The amount of time (in minutes) to wait for a reply when a CallbackID is provided. Defaults to 10. See Choreo description for details.
         /// </summary>
         /// <param name="value">Value of the Timeout input for this Choreo.</param>
         public void setTimeout(String value) {
             base.addInput ("Timeout", value);
         }
         /// <summary>
         /// (required, string) The mobile number in international format (e.g. 447525856424 or 00447525856424 when sending to UK).
         /// </summary>
         /// <param name="value">Value of the To input for this Choreo.</param>
         public void setTo(String value) {
             base.addInput ("To", value);
         }
         /// <summary>
         /// (optional, string) This can be omitted for text (default), but is required when sending a Binary (binary), WAP Push (wappush), Unicode message (unicode), VCal (vcal) or VCard (vcard).
         /// </summary>
         /// <param name="value">Value of the Type input for this Choreo.</param>
         public void setType(String value) {
             base.addInput ("Type", value);
         }
         /// <summary>
         /// (optional, string) Hex encoded User data header. (e.g. 06050415811581) (Required when Type is binary).
         /// </summary>
         /// <param name="value">Value of the UDH input for this Choreo.</param>
         public void setUDH(String value) {
             base.addInput ("UDH", value);
         }
         /// <summary>
         /// (optional, string) Correctly formatted VCal text body.
         /// </summary>
         /// <param name="value">Value of the VCal input for this Choreo.</param>
         public void setVCal(String value) {
             base.addInput ("VCal", value);
         }
         /// <summary>
         /// (optional, string) Correctly formatted VCard text body.
         /// </summary>
         /// <param name="value">Value of the VCard input for this Choreo.</param>
         public void setVCard(String value) {
             base.addInput ("VCard", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SendMessageResultSet containing execution metadata and results.</returns>
        new public SendMessageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SendMessageResultSet results = new JavaScriptSerializer().Deserialize<SendMessageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SendMessage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SendMessageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CallbackData" output from this Choreo execution
        /// <returns>String - The Nexmo callback data retrieved after a user has replied to the SMS message. This is only returned if you've setup your Temboo callback URL at Nexmo, and  have provided the CallbackID input.</returns>
        /// </summary>
        public String CallbackData
        {
            get
            {
                return (String) base.Output["CallbackData"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Nexmo. Corresponds to the ResponseFormat input. Defaults to json.</returns>
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
