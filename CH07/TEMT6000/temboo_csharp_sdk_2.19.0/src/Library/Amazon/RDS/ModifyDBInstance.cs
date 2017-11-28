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
    /// ModifyDBInstance
    /// Modify settings for a DB Instance. You can change one or more database configuration parameters by specifying values for the Choreo inputs.
    /// </summary>
    public class ModifyDBInstance : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ModifyDBInstance Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ModifyDBInstance(TembooSession session) : base(session, "/Library/Amazon/RDS/ModifyDBInstance")
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
         /// (required, integer) Storage amount (in gigabytes) to be configured for the DB. Use 5 to 1024 for MySQL or 10 to 1024 for Oracle. Value supplied must be at least 10% greater than the current value
         /// </summary>
         /// <param name="value">Value of the AllocatedStorage input for this Choreo.</param>
         public void setAllocatedStorage(String value) {
             base.addInput ("AllocatedStorage", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates that major version upgrades are allowed. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the AllowMajorVersionUpgrade input for this Choreo.</param>
         public void setAllowMajorVersionUpgrade(String value) {
             base.addInput ("AllowMajorVersionUpgrade", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies whether or not the modifications applied as soon as possible, regardless of the PreferredMaintenanceWindow setting for the DB Instance. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the ApplyImmediately input for this Choreo.</param>
         public void setApplyImmediately(String value) {
             base.addInput ("ApplyImmediately", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates that minor version upgrades will be applied automatically to the DB Instance during the maintenance window. Defaults to 0 (false).
         /// </summary>
         /// <param name="value">Value of the AutoMinorVersionUpgrade input for this Choreo.</param>
         public void setAutoMinorVersionUpgrade(String value) {
             base.addInput ("AutoMinorVersionUpgrade", value);
         }
         /// <summary>
         /// (optional, integer) Number of days to retain automated backups. Setting to a positive number enables backups. Setting to 0 disables automated backups. Must be a value from 0 to 8. Defaults to 0 (disabled).
         /// </summary>
         /// <param name="value">Value of the BackupRetentionPeriod input for this Choreo.</param>
         public void setBackupRetentionPeriod(String value) {
             base.addInput ("BackupRetentionPeriod", value);
         }
         /// <summary>
         /// (required, string) Capacity for the DB instance.  (db.m1.small, db.m1.large, db.m1.xlarge, db.m2.xlarge, db.m2.2xlarge, or db.m2.4xlarge).
         /// </summary>
         /// <param name="value">Value of the DBInstanceClass input for this Choreo.</param>
         public void setDBInstanceClass(String value) {
             base.addInput ("DBInstanceClass", value);
         }
         /// <summary>
         /// (required, string) The DB Instance identifier. Should be in all lowercase.
         /// </summary>
         /// <param name="value">Value of the DBInstanceIdentifier input for this Choreo.</param>
         public void setDBInstanceIdentifier(String value) {
             base.addInput ("DBInstanceIdentifier", value);
         }
         /// <summary>
         /// (optional, string) The name of the DB Parameter Group to apply to this DB Instance.
         /// </summary>
         /// <param name="value">Value of the DBParameterGroupName input for this Choreo.</param>
         public void setDBParameterGroupName(String value) {
             base.addInput ("DBParameterGroupName", value);
         }
         /// <summary>
         /// (optional, string) A DB Security Groups to authorize on this DB Instance.
         /// </summary>
         /// <param name="value">Value of the DBSecurityGroup input for this Choreo.</param>
         public void setDBSecurityGroup(String value) {
             base.addInput ("DBSecurityGroup", value);
         }
         /// <summary>
         /// (optional, string) The version number of the database engine to upgrade to.
         /// </summary>
         /// <param name="value">Value of the EngineVersion input for this Choreo.</param>
         public void setEngineVersion(String value) {
             base.addInput ("EngineVersion", value);
         }
         /// <summary>
         /// (required, string) The new password for the DB Instance master user.
         /// </summary>
         /// <param name="value">Value of the MasterUserPassword input for this Choreo.</param>
         public void setMasterUserPassword(String value) {
             base.addInput ("MasterUserPassword", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies if the DB Instance is a Multi-AZ deployment.
         /// </summary>
         /// <param name="value">Value of the MultiAZ input for this Choreo.</param>
         public void setMultiAZ(String value) {
             base.addInput ("MultiAZ", value);
         }
         /// <summary>
         /// (optional, string) The daily time range during which automated backups are created. Format: hh24:mi-hh24:mi (in UTC). Must be at least 30 minutes. Can not conflict with PreferredMaintenanceWindow setting.
         /// </summary>
         /// <param name="value">Value of the PreferredBackupWindow input for this Choreo.</param>
         public void setPreferredBackupWindow(String value) {
             base.addInput ("PreferredBackupWindow", value);
         }
         /// <summary>
         /// (optional, string) The weekly time range (in UTC) during which system maintenance can occur, which may result in an outage. Format: ddd:hh24:mi-ddd:hh24:mi. Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun.
         /// </summary>
         /// <param name="value">Value of the PreferredMaintenanceWindow input for this Choreo.</param>
         public void setPreferredMaintenanceWindow(String value) {
             base.addInput ("PreferredMaintenanceWindow", value);
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
        /// <returns>A ModifyDBInstanceResultSet containing execution metadata and results.</returns>
        new public ModifyDBInstanceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ModifyDBInstanceResultSet results = new JavaScriptSerializer().Deserialize<ModifyDBInstanceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ModifyDBInstance Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ModifyDBInstanceResultSet : Temboo.Core.ResultSet
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
