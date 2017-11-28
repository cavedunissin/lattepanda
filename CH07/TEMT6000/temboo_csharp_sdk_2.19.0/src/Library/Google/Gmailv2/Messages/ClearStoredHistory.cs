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

namespace Temboo.Library.Google.Gmailv2.Messages
{
    /// <summary>
    /// ClearStoredHistory
    /// Clears the history ID stored in your Temboo account when executing the GetNextMessage Choreo.
    /// </summary>
    public class ClearStoredHistory : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ClearStoredHistory Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ClearStoredHistory(TembooSession session) : base(session, "/Library/Google/Gmailv2/Messages/ClearStoredHistory")
        {
        }

         /// <summary>
         /// (optional, string) The Label ID associated with the stored history ID that should be deleted.
         /// </summary>
         /// <param name="value">Value of the LabelID input for this Choreo.</param>
         public void setLabelID(String value) {
             base.addInput ("LabelID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ClearStoredHistoryResultSet containing execution metadata and results.</returns>
        new public ClearStoredHistoryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ClearStoredHistoryResultSet results = new JavaScriptSerializer().Deserialize<ClearStoredHistoryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ClearStoredHistory Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ClearStoredHistoryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Deleted" output from this Choreo execution
        /// <returns>String - (boolean) Returns true when the history ID is successfully deleted.</returns>
        /// </summary>
        public String Deleted
        {
            get
            {
                return (String) base.Output["Deleted"];
            }
        }
    }
}
