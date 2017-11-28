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

namespace Temboo.Library.NYTimes.BestSellers
{
    /// <summary>
    /// GetBestSellerHistory
    /// Retrieves information about New York Times best-sellers that match a specified search criteria.
    /// </summary>
    public class GetBestSellerHistory : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetBestSellerHistory Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetBestSellerHistory(TembooSession session) : base(session, "/Library/NYTimes/BestSellers/GetBestSellerHistory")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by NY Times.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) The target age group for the best seller.
         /// </summary>
         /// <param name="value">Value of the AgeGroup input for this Choreo.</param>
         public void setAgeGroup(String value) {
             base.addInput ("AgeGroup", value);
         }
         /// <summary>
         /// (optional, string) The author of the best seller.
         /// </summary>
         /// <param name="value">Value of the Author input for this Choreo.</param>
         public void setAuthor(String value) {
             base.addInput ("Author", value);
         }
         /// <summary>
         /// (optional, string) The author of the best seller, as well as other contributors such as the illustrator.
         /// </summary>
         /// <param name="value">Value of the Contributor input for this Choreo.</param>
         public void setContributor(String value) {
             base.addInput ("Contributor", value);
         }
         /// <summary>
         /// (optional, string) International Standard Book Number, 10 or 13 digits.
         /// </summary>
         /// <param name="value">Value of the ISBN input for this Choreo.</param>
         public void setISBN(String value) {
             base.addInput ("ISBN", value);
         }
         /// <summary>
         /// (optional, integer) The first 20 results are shown by default. To page through the results, set Offset to the appropriate value.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, decimal) The publisher's list price of the best seller, including decimal point.
         /// </summary>
         /// <param name="value">Value of the Price input for this Choreo.</param>
         public void setPrice(String value) {
             base.addInput ("Price", value);
         }
         /// <summary>
         /// (optional, string) The standardized name of the publisher.
         /// </summary>
         /// <param name="value">Value of the Publisher input for this Choreo.</param>
         public void setPublisher(String value) {
             base.addInput ("Publisher", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should bein. Valid values are: json (the default), and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The column name to sort by. Valid values are: age-group, author, contributor, isbn, price, publisher, and title.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (optional, string) The sort order. Valid values are: ASC and DESC.
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }
         /// <summary>
         /// (conditional, string) The title of the best seller to retrieve data for.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetBestSellerHistoryResultSet containing execution metadata and results.</returns>
        new public GetBestSellerHistoryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetBestSellerHistoryResultSet results = new JavaScriptSerializer().Deserialize<GetBestSellerHistoryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetBestSellerHistory Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetBestSellerHistoryResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the NY Times API.</returns>
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
