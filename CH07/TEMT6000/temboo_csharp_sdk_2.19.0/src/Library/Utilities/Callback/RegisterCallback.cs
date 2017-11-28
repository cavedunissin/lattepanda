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

namespace Temboo.Library.Utilities.Callback
{
    /// <summary>
    /// RegisterCallback
    /// Allows you to generate a unique URL that can "listen" for incoming data from web request.
    /// </summary>
    public class RegisterCallback : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RegisterCallback Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RegisterCallback(TembooSession session) : base(session, "/Library/Utilities/Callback/RegisterCallback")
        {
        }

         /// <summary>
         /// (optional, string) This value is used to register a unique URL associated with your account. If omitted, a random identifier is generated. Using a custom value here is useful when you need the URL to be static.
         /// </summary>
         /// <param name="value">Value of the CustomCallbackD input for this Choreo.</param>
         public void setCustomCallbackD(String value) {
             base.addInput ("CustomCallbackD", value);
         }
         /// <summary>
         /// (optional, string) When using a Custom Callback ID, it can be useful to filter requests using a query parameter. This value is used as a query parameter name, and can be used to lookup request data.
         /// </summary>
         /// <param name="value">Value of the FilterName input for this Choreo.</param>
         public void setFilterName(String value) {
             base.addInput ("FilterName", value);
         }
         /// <summary>
         /// (optional, string) When using a Custom Callback ID, it can be useful to filter requests using a query parameter. This value is used as a query parameter value, and can be used to lookup request data.
         /// </summary>
         /// <param name="value">Value of the FilterValue input for this Choreo.</param>
         public void setFilterValue(String value) {
             base.addInput ("FilterValue", value);
         }
         /// <summary>
         /// (optional, string) The URL that Temboo will redirect a users to after they visit your URL. This should include the "https://" or "http://" prefix and be a fully qualified URL.
         /// </summary>
         /// <param name="value">Value of the ForwardingURL input for this Choreo.</param>
         public void setForwardingURL(String value) {
             base.addInput ("ForwardingURL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RegisterCallbackResultSet containing execution metadata and results.</returns>
        new public RegisterCallbackResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RegisterCallbackResultSet results = new JavaScriptSerializer().Deserialize<RegisterCallbackResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RegisterCallback Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RegisterCallbackResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "CallbackID" output from this Choreo execution
        /// <returns>String - (string) The ID that can used to retrieve request data that the Callback URL captures.</returns>
        /// </summary>
        public String CallbackID
        {
            get
            {
                return (String) base.Output["CallbackID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CallbackURL" output from this Choreo execution
        /// <returns>String - (string) The URL that is listening for an incoming request. Note that this URL will expire in 10 minutes.</returns>
        /// </summary>
        public String CallbackURL
        {
            get
            {
                return (String) base.Output["CallbackURL"];
            }
        }
    }
}
