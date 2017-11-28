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

namespace Temboo.Library.eBay.Shopping
{
    /// <summary>
    /// FindProducts
    /// Retrieves the listings for products that match the specified keywords.
    /// </summary>
    public class FindProducts : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FindProducts Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FindProducts(TembooSession session) : base(session, "/Library/eBay/Shopping/FindProducts")
        {
        }

         /// <summary>
         /// (required, string) The unique identifier for the application.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (optional, boolean) If set to true, only retrieve data for products that have been used to pre-fill active listings. If false, retrieve all products that match the query. Defaults to false.
         /// </summary>
         /// <param name="value">Value of the AvailableItemsOnly input for this Choreo.</param>
         public void setAvailableItemsOnly(String value) {
             base.addInput ("AvailableItemsOnly", value);
         }
         /// <summary>
         /// (conditional, string) Restricts your query to a specific category. The request requires one of the following filter parameters: QueryKeywords, ProductID, or CategoryID. Only one of the filters should be provided.
         /// </summary>
         /// <param name="value">Value of the CategoryID input for this Choreo.</param>
         public void setCategoryID(String value) {
             base.addInput ("CategoryID", value);
         }
         /// <summary>
         /// (optional, string) A domain to search in (e.g. Textbooks).
         /// </summary>
         /// <param name="value">Value of the DomainName input for this Choreo.</param>
         public void setDomainName(String value) {
             base.addInput ("DomainName", value);
         }
         /// <summary>
         /// (optional, string) Specifies whether or not to remove duplicate items from search results.
         /// </summary>
         /// <param name="value">Value of the HideDuplicateItems input for this Choreo.</param>
         public void setHideDuplicateItems(String value) {
             base.addInput ("HideDuplicateItems", value);
         }
         /// <summary>
         /// (optional, string) Defines standard subsets of fields to return within the response. Valid values are: Details, DomainHistogram, and Items.
         /// </summary>
         /// <param name="value">Value of the IncludeSelector input for this Choreo.</param>
         public void setIncludeSelector(String value) {
             base.addInput ("IncludeSelector", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of entries to return in the response.
         /// </summary>
         /// <param name="value">Value of the MaxEntries input for this Choreo.</param>
         public void setMaxEntries(String value) {
             base.addInput ("MaxEntries", value);
         }
         /// <summary>
         /// (optional, string) The page number to retrieve.
         /// </summary>
         /// <param name="value">Value of the PageNumber input for this Choreo.</param>
         public void setPageNumber(String value) {
             base.addInput ("PageNumber", value);
         }
         /// <summary>
         /// (conditional, string) Used to retrieve product details. The request requires one of the following filter parameters: QueryKeywords, ProductID, or CategoryID. Only one of the filters should be provided.
         /// </summary>
         /// <param name="value">Value of the ProductID input for this Choreo.</param>
         public void setProductID(String value) {
             base.addInput ("ProductID", value);
         }
         /// <summary>
         /// (optional, string) Sorts the list of products returned. Valid values are: ItemCount, Popularity, Rating, ReviewCount, and Title.
         /// </summary>
         /// <param name="value">Value of the ProductSort input for this Choreo.</param>
         public void setProductSort(String value) {
             base.addInput ("ProductSort", value);
         }
         /// <summary>
         /// (conditional, string) The query keywords to use for the product search. The request requires one of the following filter parameters: QueryKeywords, ProductID, or CategoryID. Only one of the filters should be provided.
         /// </summary>
         /// <param name="value">Value of the QueryKeywords input for this Choreo.</param>
         public void setQueryKeywords(String value) {
             base.addInput ("QueryKeywords", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (conditional, boolean) Indicates that the request should be made to the sandbox endpoint instead of the production endpoint. Set to 1 to enable sandbox mode.
         /// </summary>
         /// <param name="value">Value of the SandboxMode input for this Choreo.</param>
         public void setSandboxMode(String value) {
             base.addInput ("SandboxMode", value);
         }
         /// <summary>
         /// (optional, string) The eBay site ID that you want to access. Defaults to 0 indicating the US site.
         /// </summary>
         /// <param name="value">Value of the SiteID input for this Choreo.</param>
         public void setSiteID(String value) {
             base.addInput ("SiteID", value);
         }
         /// <summary>
         /// (optional, string) Sorts search results in ascending or descending order. Valid values are: Ascending and Descending.
         /// </summary>
         /// <param name="value">Value of the SortOrder input for this Choreo.</param>
         public void setSortOrder(String value) {
             base.addInput ("SortOrder", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FindProductsResultSet containing execution metadata and results.</returns>
        new public FindProductsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FindProductsResultSet results = new JavaScriptSerializer().Deserialize<FindProductsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FindProducts Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FindProductsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from eBay.</returns>
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
