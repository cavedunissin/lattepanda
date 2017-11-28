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

namespace Temboo.Library.Amazon.RDS
{
    /// <summary>
    /// RestoreDBInstanceToPointInTime
    /// Restores a DB Instance to an specified point-in-time.
    /// </summary>
    public class RestoreDBInstanceToPointInTime : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RestoreDBInstanceToPointInTime Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RestoreDBInstanceToPointInTime(TembooSession session) : base(session, "/Library/Amazon/RDS/RestoreDBInstanceToPointInTime")
        {
        }

         /// <summary>
         /// (required, string) The Access Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSAccessKeyId input for this Choreo.</param>
         public void setAWSAccessKeyId(String value) {
             base.addInput ("AWSAccessKeyId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates that minor version upgrades will be applied automatically to the DB Instance during the maintenance window. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the AutoMinorVersionUpgrade input for this Choreo.</param>
         public void setAutoMinorVersionUpgrade(String value) {
             base.addInput ("AutoMinorVersionUpgrade", value);
         }
         /// <summary>
         /// (optional, string) The EC2 Availability Zone that the database instance will be created in. A random one is chose if not provided. Can not be specified if the MultiAZ parameter is set to 1 (true).
         /// </summary>
         /// <param name="value">Value of the AvailabilityZone input for this Choreo.</param>
         public void setAvailabilityZone(String value) {
             base.addInput ("AvailabilityZone", value);
         }
         /// <summary>
         /// (optional, string) The compute and memory capacity of the Amazon RDS DB instance. Valid Values: db.m1.small | db.m1.large | db.m1.xlarge | db.m2.2xlarge | db.m2.4xlarge.
         /// </summary>
         /// <param name="value">Value of the DBInstanceClass input for this Choreo.</param>
         public void setDBInstanceClass(String value) {
             base.addInput ("DBInstanceClass", value);
         }
         /// <summary>
         /// (optional, string) The database name for the restored DB Instance. Note that this parameter doesn't apply to the MySQL engine.
         /// </summary>
         /// <param name="value">Value of the DBName input for this Choreo.</param>
         public void setDBName(String value) {
             base.addInput ("DBName", value);
         }
         /// <summary>
         /// (optional, string) The database engine to use for the new instance. Valid Values: MySQL | oracle-se1 | oracle-se | oracle-ee.
         /// </summary>
         /// <param name="value">Value of the Engine input for this Choreo.</param>
         public void setEngine(String value) {
             base.addInput ("Engine", value);
         }
         /// <summary>
         /// (optional, string) License model information for the restored DB Instance. Valid values: license-included | bring-your-own-license | general-public-license.
         /// </summary>
         /// <param name="value">Value of the LicenseModel input for this Choreo.</param>
         public void setLicenseModel(String value) {
             base.addInput ("LicenseModel", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies if the DB Instance is a Multi-AZ deployment. Do not specify the AvailabilityZone parameter if the MultiAZ parameter is set to 1 (true).
         /// </summary>
         /// <param name="value">Value of the MultiAZ input for this Choreo.</param>
         public void setMultiAZ(String value) {
             base.addInput ("MultiAZ", value);
         }
         /// <summary>
         /// (optional, integer) The port number on which the database accepts connections.
         /// </summary>
         /// <param name="value">Value of the Port input for this Choreo.</param>
         public void setPort(String value) {
             base.addInput ("Port", value);
         }
         /// <summary>
         /// (optional, date) The date and time to restore from in UTC. Cannot be specified if UseLatestRestorableTime parameter is set to 1. (format: 2009-09-07T23:45:00Z).
         /// </summary>
         /// <param name="value">Value of the RestoreTime input for this Choreo.</param>
         public void setRestoreTime(String value) {
             base.addInput ("RestoreTime", value);
         }
         /// <summary>
         /// (required, string) The identifier of the source DB Instance from which to restore.
         /// </summary>
         /// <param name="value">Value of the SourceDBInstanceIdentifier input for this Choreo.</param>
         public void setSourceDBInstanceIdentifier(String value) {
             base.addInput ("SourceDBInstanceIdentifier", value);
         }
         /// <summary>
         /// (required, string) The name of the new database instance to be created.
         /// </summary>
         /// <param name="value">Value of the TargetDBInstanceIdentifier input for this Choreo.</param>
         public void setTargetDBInstanceIdentifier(String value) {
             base.addInput ("TargetDBInstanceIdentifier", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies whether or not the DB Instance is restored from the latest backup time. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the UseLatestRestorableTime input for this Choreo.</param>
         public void setUseLatestRestorableTime(String value) {
             base.addInput ("UseLatestRestorableTime", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the RDS endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RestoreDBInstanceToPointInTimeResultSet containing execution metadata and results.</returns>
        new public RestoreDBInstanceToPointInTimeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RestoreDBInstanceToPointInTimeResultSet results = new JavaScriptSerializer().Deserialize<RestoreDBInstanceToPointInTimeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RestoreDBInstanceToPointInTime Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RestoreDBInstanceToPointInTimeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Amazon.</returns>
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
