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

namespace Temboo.Library.Utilities.Test
{
    /// <summary>
    /// HelloWorld
    /// Allows you to run a simple test that outputs "Hello, world!" when executed.
    /// </summary>
    public class HelloWorld : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the HelloWorld Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public HelloWorld(TembooSession session) : base(session, "/Library/Utilities/Test/HelloWorld")
        {
        }

         /// <summary>
         /// (conditional, string) An optional test value to pass into the result message.
         /// </summary>
         /// <param name="value">Value of the Value input for this Choreo.</param>
         public void setValue(String value) {
             base.addInput ("Value", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A HelloWorldResultSet containing execution metadata and results.</returns>
        new public HelloWorldResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            HelloWorldResultSet results = new JavaScriptSerializer().Deserialize<HelloWorldResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the HelloWorld Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class HelloWorldResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Result" output from this Choreo execution
        /// <returns>String - (string) Contains a sample Choreo output. If no input is provided, the result will be "Hello, world!". When passing an input value, the result will be "Hello, {Value}!".</returns>
        /// </summary>
        public String Result
        {
            get
            {
                return (String) base.Output["Result"];
            }
        }
    }
}
