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

namespace Temboo.Library.Basecamp
{
    /// <summary>
    /// CreateMessage
    /// Creates a new message under a specified project.
    /// </summary>
    public class CreateMessage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateMessage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateMessage(TembooSession session) : base(session, "/Library/Basecamp/CreateMessage")
        {
        }

         /// <summary>
         /// (required, string) The Basecamp account name for you or your company. This is the first part of your account URL.
         /// </summary>
         /// <param name="value">Value of the AccountName input for this Choreo.</param>
         public void setAccountName(String value) {
             base.addInput ("AccountName", value);
         }
         /// <summary>
         /// (required, string) The body of the message you're creating.
         /// </summary>
         /// <param name="value">Value of the Body input for this Choreo.</param>
         public void setBody(String value) {
             base.addInput ("Body", value);
         }
         /// <summary>
         /// (required, password) Your Basecamp password.  You can use the value 'X' when specifying an API Key for the Username input.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, integer) The ID of the project that the message will be created under.
         /// </summary>
         /// <param name="value">Value of the ProjectId input for this Choreo.</param>
         public void setProjectId(String value) {
             base.addInput ("ProjectId", value);
         }
         /// <summary>
         /// (required, string) The title of the message you'e creating.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (required, string) Your Basecamp username or API Key.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateMessageResultSet containing execution metadata and results.</returns>
        new public CreateMessageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateMessageResultSet results = new JavaScriptSerializer().Deserialize<CreateMessageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateMessage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateMessageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Basecamp. Note that a successful request returns a null result in this output variable.</returns>
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
