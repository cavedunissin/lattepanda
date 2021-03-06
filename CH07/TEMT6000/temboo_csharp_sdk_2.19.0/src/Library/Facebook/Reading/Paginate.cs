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

namespace Temboo.Library.Facebook.Reading
{
    /// <summary>
    /// Paginate
    /// Retrieves the next or previous page of results.
    /// </summary>
    public class Paginate : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Paginate Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Paginate(TembooSession session) : base(session, "/Library/Facebook/Reading/Paginate")
        {
        }

         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) A "next" or "previous" URL associated with another page of results to retrieve.
         /// </summary>
         /// <param name="value">Value of the URL input for this Choreo.</param>
         public void setURL(String value) {
             base.addInput ("URL", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PaginateResultSet containing execution metadata and results.</returns>
        new public PaginateResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PaginateResultSet results = new JavaScriptSerializer().Deserialize<PaginateResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Paginate Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PaginateResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Next" output from this Choreo execution
        /// <returns>String - (string) The URL to use to retrieve the next page of the results.</returns>
        /// </summary>
        public String Next
        {
            get
            {
                return (String) base.Output["Next"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Previous" output from this Choreo execution
        /// <returns>String - (string) The URL to use to retrieve the previous page of results.</returns>
        /// </summary>
        public String Previous
        {
            get
            {
                return (String) base.Output["Previous"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Facebook.</returns>
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
