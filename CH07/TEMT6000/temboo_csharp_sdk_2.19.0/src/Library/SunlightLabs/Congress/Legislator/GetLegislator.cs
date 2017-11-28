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

namespace Temboo.Library.SunlightLabs.Congress.Legislator
{
    /// <summary>
    /// GetLegislator
    /// Returns information for a particular member with a given identifier.
    /// </summary>
    public class GetLegislator : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLegislator Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLegislator(TembooSession session) : base(session, "/Library/SunlightLabs/Congress/Legislator/GetLegislator")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Sunlight Labs.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, boolean) A boolean flag indicating to search for all legislators even when they are no longer in office.
         /// </summary>
         /// <param name="value">Value of the AllLegislators input for this Choreo.</param>
         public void setAllLegislators(String value) {
             base.addInput ("AllLegislators", value);
         }
         /// <summary>
         /// (conditional, string) The bioguide_id of the legislator to return.
         /// </summary>
         /// <param name="value">Value of the BioguideID input for this Choreo.</param>
         public void setBioguideID(String value) {
             base.addInput ("BioguideID", value);
         }
         /// <summary>
         /// (optional, string) The crp_id associated with a legislator to return.
         /// </summary>
         /// <param name="value">Value of the CRPID input for this Choreo.</param>
         public void setCRPID(String value) {
             base.addInput ("CRPID", value);
         }
         /// <summary>
         /// (optional, string) The fec_id associated with the legislator to return.
         /// </summary>
         /// <param name="value">Value of the FECID input for this Choreo.</param>
         public void setFECID(String value) {
             base.addInput ("FECID", value);
         }
         /// <summary>
         /// (optional, string) A comma-separated list of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (optional, string) The govetrack_id associated with a legistlator to return.
         /// </summary>
         /// <param name="value">Value of the GovTrackID input for this Choreo.</param>
         public void setGovTrackID(String value) {
             base.addInput ("GovTrackID", value);
         }
         /// <summary>
         /// (optional, string) Identifier for this member as it is maintained by the Inter-university Consortium for Political and Social Research.
         /// </summary>
         /// <param name="value">Value of the ICPSRID input for this Choreo.</param>
         public void setICPSRID(String value) {
             base.addInput ("ICPSRID", value);
         }
         /// <summary>
         /// (optional, string) Identifier for this member as it appears on some of Congress' data systems (namely Senate votes).
         /// </summary>
         /// <param name="value">Value of the LISID input for this Choreo.</param>
         public void setLISID(String value) {
             base.addInput ("LISID", value);
         }
         /// <summary>
         /// (optional, string) Identifier for this member across all countries and levels of government, as defined by the Open Civic Data project.
         /// </summary>
         /// <param name="value">Value of the OCDID input for this Choreo.</param>
         public void setOCDID(String value) {
             base.addInput ("OCDID", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Identifier for this member as it appears on THOMAS.gov and Congress.gov.
         /// </summary>
         /// <param name="value">Value of the ThomasID input for this Choreo.</param>
         public void setThomasID(String value) {
             base.addInput ("ThomasID", value);
         }
         /// <summary>
         /// (optional, integer) The votesmart_id of a legislator to return.
         /// </summary>
         /// <param name="value">Value of the VoteSmartID input for this Choreo.</param>
         public void setVoteSmartID(String value) {
             base.addInput ("VoteSmartID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetLegislatorResultSet containing execution metadata and results.</returns>
        new public GetLegislatorResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLegislatorResultSet results = new JavaScriptSerializer().Deserialize<GetLegislatorResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLegislator Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLegislatorResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the Sunlight Congress API.</returns>
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
