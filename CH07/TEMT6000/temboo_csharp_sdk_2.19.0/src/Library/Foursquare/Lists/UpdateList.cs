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

namespace Temboo.Library.Foursquare.Lists
{
    /// <summary>
    /// UpdateList
    /// Updates a given list.
    /// </summary>
    public class UpdateList : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateList Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateList(TembooSession session) : base(session, "/Library/Foursquare/Lists/UpdateList")
        {
        }

         /// <summary>
         /// (optional, boolean) A flag indicating that this list can be edited by friends. Set to 1 for true. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the Collaborative input for this Choreo.</param>
         public void setCollaborative(String value) {
             base.addInput ("Collaborative", value);
         }
         /// <summary>
         /// (optional, string) The description of the list.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (required, string) The id of the list to update.
         /// </summary>
         /// <param name="value">Value of the ListID input for this Choreo.</param>
         public void setListID(String value) {
             base.addInput ("ListID", value);
         }
         /// <summary>
         /// (required, string) The name of the list.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (required, string) The Foursquare API OAuth token string.
         /// </summary>
         /// <param name="value">Value of the OauthToken input for this Choreo.</param>
         public void setOauthToken(String value) {
             base.addInput ("OauthToken", value);
         }
         /// <summary>
         /// (optional, string) The id of a photo that should be set as the list photo.
         /// </summary>
         /// <param name="value">Value of the PhotoID input for this Choreo.</param>
         public void setPhotoID(String value) {
             base.addInput ("PhotoID", value);
         }
         /// <summary>
         /// (optional, string) The format that response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateListResultSet containing execution metadata and results.</returns>
        new public UpdateListResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateListResultSet results = new JavaScriptSerializer().Deserialize<UpdateListResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateList Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateListResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Foursquare. Corresponds to the ResponseFormat input. Defaults to JSON.</returns>
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
