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

namespace Temboo.Library.LittleSis.List
{
    /// <summary>
    /// ListSearchByKeyword
    /// Retrieves the name and description fields of Lists available in LittleSis that match a keyword search.
    /// </summary>
    public class ListSearchByKeyword : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ListSearchByKeyword Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ListSearchByKeyword(TembooSession session) : base(session, "/Library/LittleSis/List/ListSearchByKeyword")
        {
        }

         /// <summary>
         /// (required, string) The API Key obtained from LittleSis.org.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) Enter search text.
         /// </summary>
         /// <param name="value">Value of the Keywords input for this Choreo.</param>
         public void setKeywords(String value) {
             base.addInput ("Keywords", value);
         }
         /// <summary>
         /// (optional, string) Format of the response returned by LittleSis.org. Acceptable inputs: xml or json. Defaults to xml
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ListSearchByKeywordResultSet containing execution metadata and results.</returns>
        new public ListSearchByKeywordResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ListSearchByKeywordResultSet results = new JavaScriptSerializer().Deserialize<ListSearchByKeywordResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ListSearchByKeyword Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ListSearchByKeywordResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from LittleSis.org.</returns>
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
