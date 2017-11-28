using System;
using System.Collections.Generic;

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

namespace Temboo.Core
{
	/// <summary>
	/// ResultSet represents the output values and final state of a completed Choreo execution. 
	/// There are two main components to the ResultSet object: 
	/// 
	/// -ExecutionData, which contains information about the status of the Choreo execution (SUCCESS, ERROR, etc.) 
	/// along with other metadata about the execution including its start time, end time, and error message (if any)
	/// 
	/// -Output, which contains a dictionary of the individual output values returned by the Choreo.
	/// </summary>
	public class ResultSet
	{
		// The following constants represent the possible values of a Choreo's execution status
		public static readonly String STATUS_UNKNOWN = "UNKNOWN";
		public static readonly String STATUS_RUNNING = "RUNNING";
		public static readonly String STATUS_SUCCESS = "SUCCESS";
		public static readonly String STATUS_ERROR = "ERROR";
		public static readonly String STATUS_TERMINATED_MANUALLY = "TERMINATED_MANUALLY";
		public static readonly String STATUS_TERMINATED_LIMIT = "TERMINATED_LIMIT";

        /// <summary>
        /// The last error message for this Choreo execution. If an error was returned by the Temboo platform before
        /// execution began, an error message outside the context of an Execution object may be returned; if so, capture
        /// it here and insert it into the Execution.
        /// </summary>
        public Error Error
        {
            set
            {
                if(this.Execution == null)
                {
                    this.Execution = new ExecutionData();
                    this.Execution.Status = STATUS_ERROR;
                    this.Execution.LastError = value.Message;
                }
            }
        }

		/// <summary>
		/// Get the ExecutionData object for this Choreo execution, containing the completion status of the 
		/// Choreo (SUCCESS, ERROR, etc.) and other metadata about the execution including its start time,
		/// end time, and error message (if any)
		/// </summary>
		/// <value>The ExecutionData object.</value>
        public ExecutionData Execution { get; set; }

		/// <summary>
		/// Get the Output object for this Choreo execution, containing the individual output values
		/// returned by the Choreo upon completion.
		/// </summary>
		/// <value>The output.</value>
		public Dictionary<String, Object> Output { get; set; }
	}

	/// <summary>
	/// ExecutionData represents metadata about a completed Choreo execution.
	/// </summary>
	public class ExecutionData
	{

		/// <summary>
		/// Get the unique ID of this Choreo execution
		/// </summary>
		/// <value>The execution identifier.</value>
		public String Id { get; set; }

		/// <summary>
		/// Get the completion status of this Choreo execution (SUCCESS, ERROR, etc.)
		/// </summary>
		/// <value>The status.</value>
		public String Status { get; set; }

		/// <summary>
		/// Get the start time of this Choreo execution, expressed as a Unix timestamp
		/// </summary>
		/// <value>The start time.</value>
		public long StartTime { get; set; }

		/// <summary>
		/// Get the completion time of this Choreo execution, expressed as a Unix timestamp
		/// </summary>
		/// <value>The end time.</value>
		public long EndTime { get; set; }


		/// <summary>
		/// Get the text of the last error that occurred during this Choreo execution; may be null
		/// if no error(s) occurred.
		/// </summary>
		/// <value>The last error message.</value>
		public String LastError { get; set; }
	}

    /// <summary>
    /// Error represents an error that occurred on the Temboo platform before beginning Choreo execution.
    /// </summary>
    public class Error
    {
        public String Message { get; set; }
    }

}


