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

namespace Temboo.Library.Disqus.Users
{
    /// <summary>
    /// CheckUsername
    /// Check whether the provided username is available.  An error is returned if the entered username is either taken, or invalid.
    /// </summary>
    public class CheckUsername : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CheckUsername Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CheckUsername(TembooSession session) : base(session, "/Library/Disqus/Users/CheckUsername")
        {
        }

         /// <summary>
         /// (required, string) A valid OAuth 2.0 access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The name of a callback function to wrap the respone in. Used when setting ResponseFormat to "jsonp".
         /// </summary>
         /// <param name="value">Value of the Callback input for this Choreo.</param>
         public void setCallback(String value) {
             base.addInput ("Callback", value);
         }
         /// <summary>
         /// (required, string) The Public Key provided by Disqus (AKA the API Key).
         /// </summary>
         /// <param name="value">Value of the PublicKey input for this Choreo.</param>
         public void setPublicKey(String value) {
             base.addInput ("PublicKey", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and jsonp.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) Enter a Disqus username.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CheckUsernameResultSet containing execution metadata and results.</returns>
        new public CheckUsernameResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CheckUsernameResultSet results = new JavaScriptSerializer().Deserialize<CheckUsernameResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CheckUsername Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CheckUsernameResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Disqus.</returns>
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
