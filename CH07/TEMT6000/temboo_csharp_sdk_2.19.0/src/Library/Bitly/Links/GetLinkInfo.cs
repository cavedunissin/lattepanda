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

namespace Temboo.Library.Bitly.Links
{
    /// <summary>
    /// GetLinkInfo
    /// Returns the page title for a given Bitly link.
    /// </summary>
    public class GetLinkInfo : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLinkInfo Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLinkInfo(TembooSession session) : base(session, "/Library/Bitly/Links/GetLinkInfo")
        {
        }

         /// <summary>
         /// (required, string) The OAuth access token provided by Bitly.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in. Accepted values are "json" or "xml". Defaults to "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) One or more Bitly links.
         /// </summary>
         /// <param name="value">Value of the ShortURL input for this Choreo.</param>
         public void setShortURL(String value) {
             base.addInput ("ShortURL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLinkInfoResultSet containing execution metadata and results.</returns>
        new public GetLinkInfoResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLinkInfoResultSet results = new JavaScriptSerializer().Deserialize<GetLinkInfoResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLinkInfo Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLinkInfoResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Bitly.</returns>
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
