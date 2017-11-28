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

namespace Temboo.Library.DonorsChoose
{
    /// <summary>
    /// MathAndScience
    /// Returns results for projects within the Math and Science category.
    /// </summary>
    public class MathAndScience : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the MathAndScience Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public MathAndScience(TembooSession session) : base(session, "/Library/DonorsChoose/MathAndScience")
        {
        }

         /// <summary>
         /// (optional, string) The APIKey provided by DonorsChoose.org. Defaults to the test  APIKey 'DONORSCHOOSE'.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, integer) The number of the first row to return in the result. For example, if index=10, the results could show rows 10-59.
         /// </summary>
         /// <param name="value">Value of the Index input for this Choreo.</param>
         public void setIndex(String value) {
             base.addInput ("Index", value);
         }
         /// <summary>
         /// (optional, integer) The max number of projects to return. Can return up to 50 rows at a time. Defaults to 10 when left empty.
         /// </summary>
         /// <param name="value">Value of the Max input for this Choreo.</param>
         public void setMax(String value) {
             base.addInput ("Max", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Set to 1 to show the synopsis for each project listing
         /// </summary>
         /// <param name="value">Value of the ShowSynopsis input for this Choreo.</param>
         public void setShowSynopsis(String value) {
             base.addInput ("ShowSynopsis", value);
         }
         /// <summary>
         /// (optional, string) Enter a sub-category of Math & Science. When left empty, all Math & Science projects are returned.
         /// </summary>
         /// <param name="value">Value of the Subject input for this Choreo.</param>
         public void setSubject(String value) {
             base.addInput ("Subject", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A MathAndScienceResultSet containing execution metadata and results.</returns>
        new public MathAndScienceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            MathAndScienceResultSet results = new JavaScriptSerializer().Deserialize<MathAndScienceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the MathAndScience Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class MathAndScienceResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from DonorsChoose.org</returns>
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
