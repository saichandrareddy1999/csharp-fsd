//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace introduction
//{
//    internal class Work
//    {
//        public void Main()

//        {

//            #region Variable Declaration

//            string strtScheduleStartTime = string.Empty;

//            string strScheduleResetTime = string.Empty;



//            int iDataImportID = 0;

//            int iGroupCodeID = 0;

//            int iTimeOK = 0;

//            int iHour = 0;

//            int iWeekDay = 0;

//            int iRetFails = 0;

//            int iDataImportIDOverRide = 0;

//            string strPackageName = string.Empty;

//            string strRxClaimsLoader = string.Empty;

//            string strImportFileName = string.Empty;

//            string strMessage = string.Empty;

//            string strStepName = string.Empty;

//            int iContinue_flag = 0;

//            int iRunImport = 0;

//            int iRunReset = 0;

//            int iRxImport = 0;

//            string strGroupCode = string.Empty;

//            string strErrmsg = string.Empty;

//            string strLogFileName = string.Empty;

//            DateTime HolidayOverRide;

//            #endregion

//            #region ReadInputParam From Varaibles

//            int iTimeOverride = (Dts.Variables["TILDR_TimeOverRide"].Value != null && Dts.Variables["TILDR_TimeOverRide"].Value != "") ? Convert.ToInt32(Dts.Variables["TILDR_TimeOverRide"].Value.ToString()) : 0;
//            string strHolidayOverride = (Dts.Variables["TILDR_HolidayOverRide"].Value != null && Dts.Variables["TILDR_HolidayOverRide"].Value != "") ? Dts.Variables["TILDR_HolidayOverRide"].Value.ToString() : "";

//            string strDataImportIdOverRide = (Dts.Variables["TILDR_DataImportIdOverRide"].Value != null && Dts.Variables["TILDR_DataImportIdOverRide"].Value != "") ? Dts.Variables["TILDR_DataImportIdOverRide"].Value.ToString() : "";

//            //string strPackageStore = (Dts.Variables["TILDR_PackagePath"].Value != null && Dts.Variables["TILDR_PackagePath"].Value != "") ? Dts.Variables["TILDR_PackagePath"].Value.ToString() : "";

//            // string strSSISServer = (Dts.Variables["TILDR_SSIS_Server"].Value != null && Dts.Variables["TILDR_SSIS_Server"].Value != "") ? Dts.Variables["TILDR_SSIS_Server"].Value.ToString() : "";



//            string strSSISSubroConnection = (Dts.Variables["DBSubroConnectionString"].Value != null && Dts.Variables["DBSubroConnectionString"].Value != "") ? Dts.Variables["DBSubroConnectionString"].Value.ToString() : "";
//            string strSSISTapeImportsConnection = (Dts.Variables["DBTapeImportsConnectionString"].Value != null && Dts.Variables["DBTapeImportsConnectionString"].Value != "") ? Dts.Variables["DBTapeImportsConnectionString"].Value.ToString() : "";
//            string strDBSubroConnectionString = (Dts.Variables["SSISSubroConnection"].Value != null && Dts.Variables["SSISSubroConnection"].Value != "") ? Dts.Variables["SSISSubroConnection"].Value.ToString() : "";
//            string strDBTapeImportsConnectionString = (Dts.Variables["SSISTapeImportsConnection"].Value != null && Dts.Variables["SSISTapeImportsConnection"].Value != "") ? Dts.Variables["SSISTapeImportsConnection"].Value.ToString() : "";
//            string strSSISPackagePath = (Dts.Variables["SSISPackagePath"].Value != null && Dts.Variables["SSISPackagePath"].Value != "") ? Dts.Variables["SSISPackagePath"].Value.ToString() : "";
//            string strSSISRXMasterPackageName = (Dts.Variables["SSISRXMasterPackageName"].Value != null && Dts.Variables["SSISRXMasterPackageName"].Value != "") ? Dts.Variables["SSISRXMasterPackageName"].Value.ToString() : "";

//            #endregion



//            #region GetConnection From Connection Manager

//            SqlConnection TI_DB_Connection = new SqlConnection(strDBTapeImportsConnectionString);
//            SqlCommand TI_DB_Cmd = new SqlCommand();

//            // ConnectionManager CI_Cm = Dts.Connections["ADO_SRC_DB"];





//            try

//            {

//                //strPackageStore = strSSISPackagePath;

//                //TI_DB_Connection = (SqlConnection)(CI_Cm.AcquireConnection(Dts.Transaction) as SqlConnection);

//                // strTapeImportServer = TI_DB_Connection.DataSource.ToString();

//                // strTapeImportDB = strSSISTapeImportsConnection;

//                //strSubroServer = Dts.Variables["TILDR_SubroServer"].Value != null ? Dts.Variables["TILDR_SubroServer"].Value.ToString() : "";

//                // strSubroDB = strSSISSubroConnection;

//            }

//            catch (Exception ex)
//            {

//                Dts.Events.FireError(0, "TapeImportLoader-ReadConnection", ex.Message.ToString(), string.Empty, 0);

//                Dts.TaskResult = (int)ScriptResults.Failure;

//            }

//            #endregion



//            #region Initialize Variables

//            iRetFails = 0;

//            iTimeOK = 1;

//            iContinue_flag = 0;



//            switch (DateTime.Today.DayOfWeek.ToString())

//            {

//                case "Sunday": iWeekDay = 1; break;

//                case "Monday": iWeekDay = 2; break;

//                case "Tuesday": iWeekDay = 3; break;

//                case "Wednesday": iWeekDay = 4; break;

//                case "Thursday": iWeekDay = 5; break;

//                case "Friday": iWeekDay = 6; break;

//                case "Saturday": iWeekDay = 7; break;

//            }



//            //Check Hr is in 24Hr Format

//            iHour = DateTime.Now.Hour;

//            //iHour = 23;

//            HolidayOverRide = new DateTime(1900, 1, 1);



//            if (strDataImportIdOverRide != null)

//            {

//                if (strDataImportIdOverRide.Trim() != "")

//                {

//                    iDataImportIDOverRide = Convert.ToInt32(strDataImportIdOverRide);

//                }

//            }

//            if (strHolidayOverride != null)

//            {

//                if (strHolidayOverride.Trim() != "")

//                {

//                    HolidayOverRide = new DateTime(Convert.ToInt32(strHolidayOverride.Substring(0, 4)), Convert.ToInt32(strHolidayOverride.Substring(5, 2)), Convert.ToInt32(strHolidayOverride.Substring(8, 2)));

//                }

//            }

//            #endregion



//            if ((iWeekDay == 1)

//                || ((iWeekDay != 1) && ((iHour >= 19 && iHour <= 23) || iHour < 3))

//                || (iWeekDay == 2 && iHour < 4))

//            {

//                iTimeOK = 0;

//            }

//            else

//            {

//                iTimeOK = 1;

//            }



//            if (((iTimeOK == 1 && iTimeOverride == 1 && iDataImportIDOverRide != 0)) || (HolidayOverRide > DateTime.Today))

//            {

//                iTimeOK = 0;

//            }


//            #region Fetch Pacakge from Table and Execute - While Loop



//            while ((iTimeOK == 0) && (iRetFails < 5) && (iContinue_flag == 0))

//            {

//                iContinue_flag = 0;



//                #region Get the Next Import to Run

//                if (iContinue_flag == 0)

//                {

//                    try

//                    {

//                        TI_DB_Cmd.Connection = TI_DB_Connection;

//                        TI_DB_Cmd.CommandText = "TapeImportGetNextJob";

//                        TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                        TI_DB_Cmd.Parameters.AddWithValue("@DataImportIDOverRide", iDataImportIDOverRide);

//                        TI_DB_Cmd.Parameters.Add("@DataImportID", SqlDbType.Int);

//                        TI_DB_Cmd.Parameters["@DataImportID"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@ScheduleTime", SqlDbType.VarChar, 30);

//                        TI_DB_Cmd.Parameters["@ScheduleTime"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@ScheduleResetTime", SqlDbType.VarChar, 30);

//                        TI_DB_Cmd.Parameters["@ScheduleResetTime"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@GroupCodeID", SqlDbType.Int);

//                        TI_DB_Cmd.Parameters["@GroupCodeID"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@importfilename", SqlDbType.VarChar, 8000);

//                        TI_DB_Cmd.Parameters["@importfilename"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@RunImport", SqlDbType.Int);

//                        TI_DB_Cmd.Parameters["@RunImport"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@RunReset", SqlDbType.VarChar, 100);

//                        TI_DB_Cmd.Parameters["@RunReset"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@dtslogfilename", SqlDbType.VarChar, 8000);

//                        TI_DB_Cmd.Parameters["@dtslogfilename"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@DTSPackage", SqlDbType.VarChar, 8000);

//                        TI_DB_Cmd.Parameters["@DTSPackage"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.Parameters.Add("@RXImport", SqlDbType.Int);

//                        TI_DB_Cmd.Parameters["@RxImport"].Direction = ParameterDirection.Output;

//                        TI_DB_Cmd.CommandTimeout = 500;



//                        TI_DB_Connection.Open();

//                        TI_DB_Cmd.ExecuteNonQuery();

//                        TI_DB_Connection.Close();



//                        iDataImportID = TI_DB_Cmd.Parameters["@DataImportID"].Value != DBNull.Value ? (int)TI_DB_Cmd.Parameters["@DataImportID"].Value : 0;

//                        Variables WriteVar = null;

//                        Dts.VariableDispenser.LockOneForWrite("DataImportId", ref WriteVar);

//                        WriteVar["DataImportId"].Value = iDataImportID;

//                        WriteVar.Unlock();



//                        strtScheduleStartTime = TI_DB_Cmd.Parameters["@ScheduleTime"].Value != DBNull.Value ? (string)TI_DB_Cmd.Parameters["@ScheduleTime"].Value : ";

//                        strScheduleResetTime = TI_DB_Cmd.Parameters["@ScheduleResetTime].Value != DBNull.Value ? (string)TI_DB_Cmd.Parameters["@ScheduleResetTime"].Value : ";

//                        iGroupCodeID = TI_DB_Cmd.Parameters["@GroupCodeID].Value != DBNull.Value ? Convert.ToInt32(TI_DB_Cmd.Parameters["@GroupCodeID"].Value) : 0;

//                        strImportFileName = TI_DB_Cmd.Parameters["@importfilename"].Value != DBNull.Value ? (string)TI_DB_Cmd.Parameters["@importfilename"].Value : ";

//                        iRunImport = TI_DB_Cmd.Parameters["@RunImport].Value != DBNull.Value ? Convert.ToInt32(TI_DB_Cmd.Parameters["@RunImport"].Value) : 0;

//                        iRunReset = TI_DB_Cmd.Parameters["@RunReset"].Value != DBNull.Value ? Convert.ToInt32(TI_DB_Cmd.Parameters["@RunReset"].Value) : 0;

//                        strPackageName = TI_DB_Cmd.Parameters["@DTSPackage"].Value != DBNull.Value ? (string)TI_DB_Cmd.Parameters["@DTSPackage"].Value : ";

//                        iRxImport = TI_DB_Cmd.Parameters["@RxImport].Value != DBNull.Value ? Convert.ToInt32(TI_DB_Cmd.Parameters["@RxImport"].Value) : 0;

//                        strLogFileName = TI_DB_Cmd.Parameters["@dtslogfilename"].Value != DBNull.Value ? (string)TI_DB_Cmd.Parameters["@dtslogfilename"].Value : "";



//                    }

//                    catch (Exception ex)
//                    {

//                        Dts.Events.FireError(0, "TapeImportLoader-GetNextJob", ex.Message.ToString(), string.Empty, 0);

//                        iContinue_flag = 1;

//                        //CI_Cm.ReleaseConnection(TI_DB_Connection);

//                        Dts.TaskResult = (int)ScriptResults.Failure;

//                    }

//                    finally

//                    {

//                        TI_DB_Cmd.Parameters.Clear();

//                    }

//                    if ((iContinue_flag == 0)

//                        && ((iDataImportID == 0)

//                        || (iGroupCodeID == 0)

//                        || ((iRunImport == 1) && (strImportFileName == ""))

//                        || ((iRunImport == 1) && (strPackageName == ""))

//                        || ((iRunImport == 1) && (strLogFileName == ""))))

//                    {

//                        iContinue_flag = 1;

//                        //CI_Cm.ReleaseConnection(TI_DB_Connection);

//                        Dts.TaskResult = (int)ScriptResults.Failure;

//                    }

//                }

//                #endregion



//                #region Run Reset

//                if ((iContinue_flag == 0) && (iRunImport == 0) && (iRunReset == 1) && (iRxImport == 0))

//                {

//                    try

//                    {

//                        TI_DB_Cmd.Connection = TI_DB_Connection;

//                        TI_DB_Cmd.CommandText = "TapeImportResetImport";

//                        TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                        TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                        TI_DB_Cmd.Parameters.AddWithValue("@GroupCodeID", iGroupCodeID);



//                        TI_DB_Connection.Open();

//                        TI_DB_Cmd.ExecuteNonQuery();

//                        TI_DB_Connection.Close();

//                    }

//                    catch (Exception ex)
//                    {

//                        Dts.Events.FireError(0, "TapeImportLoader-ResetImport", ex.Message.ToString(), string.Empty, 0);

//                        iContinue_flag = 1;

//                        //CI_Cm.ReleaseConnection(TI_DB_Connection);

//                        Dts.TaskResult = (int)ScriptResults.Failure;

//                    }

//                    finally

//                    {

//                        TI_DB_Cmd.Parameters.Clear();

//                    }

//                }

//                #endregion



//                #region Run Rx Import

//                if ((iContinue_flag == 0) && (iRxImport == 1))

//                {

//                    try

//                    {

//                        Microsoft.SqlServer.Dts.Runtime.Application appRXSSIS = new Microsoft.SqlServer.Dts.Runtime.Application();

//                        strRxClaimsLoader = strSSISPackagePath + strSSISRXMasterPackageName; //"ESubro_ClaimsRXImport.dtsx";

//                        Package SSIS_RXPacakge = appRXSSIS.LoadPackage(@strRxClaimsLoader, null);

//                        Variables SSIS_RXVariables = SSIS_RXPacakge.Variables;

//                        SSIS_RXVariables["CLMRX_DataImportID"].Value = iDataImportID;

//                        SSIS_RXVariables["CLMRX_GroupCodeID"].Value = iGroupCodeID;

//                        SSIS_RXVariables["CLMRX_ImportFileName"].Value = strImportFileName;

//                        SSIS_RXVariables["CLMRX_PackageName"].Value = strPackageName;

//                        SSIS_RXVariables["DBTapeImportsConnectionString"].Value = strDBTapeImportsConnectionString;

//                        SSIS_RXVariables["SSISTapeImportsConnection"].Value = strSSISTapeImportsConnection;

//                        SSIS_RXVariables["DBSubroConnectionString"].Value = strDBSubroConnectionString;

//                        SSIS_RXVariables["SSISSubroConnection"].Value = strSSISSubroConnection;

//                        SSIS_RXVariables["SSISPackagePath"].Value = strSSISPackagePath;

//                        DTSExecResult SSIS_RXResult = SSIS_RXPacakge.Execute();



//                        if (SSIS_RXResult.ToString() != "Success")
//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-ExecuteRXClaimsSSIS", strPackageName, string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                    }

//                    catch (Exception ex)
//                    {

//                        Dts.Events.FireError(0, "TapeImportLoader-ExecuteRXClaimsSSIS", ex.Message.ToString(), string.Empty, 0);

//                        iContinue_flag = 1;

//                        Dts.TaskResult = (int)ScriptResults.Failure;

//                    }

//                    finally

//                    {

//                        TI_DB_Cmd.Parameters.Clear();

//                    }

//                }

//                #endregion



//                #region RunImport Process

//                if ((iContinue_flag == 0) && (iRunImport == 1) && (iRunReset == 0) && (iRxImport == 0))

//                {

//                    #region Start Import Job

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportStartJob";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);



//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)
//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-TapeImportStartJob", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region Truncate Table

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportTruncateTables";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;



//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)
//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-TapeImportTruncateTables", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                    }

//                    #endregion



//                    #region Execute the SSIS Pacakge

//                    //All Claim Import packages are configured with similar variable names as below

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            Microsoft.SqlServer.Dts.Runtime.Application appSSIS = new Microsoft.SqlServer.Dts.Runtime.Application();

//                            strPackageName = strSSISPackagePath + strPackageName;

//                            Package SSIS_Pacakge = appSSIS.LoadPackage(@strPackageName, null);

//                            Variables SSIS_Variables = SSIS_Pacakge.Variables;

//                            SSIS_Variables["SIC_SourceFilePath"].Value = strImportFileName;

//                            SSIS_Variables["SIC_Subro_Database"].Value = strSSISSubroConnection;

//                            SSIS_Variables["SIC_TapeImport_Database"].Value = strSSISTapeImportsConnection;

//                            try { SSIS_Variables["DataImportId"].Value = iDataImportID; }

//                            catch { }

//                            DTSExecResult SSIS_Result = SSIS_Pacakge.Execute();

//                            if (SSIS_Result.ToString() != "Success")
//                            {

//                                Dts.Events.FireError(0, "TapeImportLoader-ExecuteSSIS", strPackageName, string.Empty, 0);

//                                iContinue_flag = 1;

//                                Dts.TaskResult = (int)ScriptResults.Failure;

//                            }

//                        }

//                        catch (Exception ex)
//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-Execute" + strPackageName + "", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                    }

//                    #endregion



//                    #region Count Import Prior to Messing with it

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportPreCounts";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);



//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)
//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-PreCounts", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region FixClaims

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportFixClaim";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.CommandTimeout = 0;



//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-FixClaim", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region Add Subscriber

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportAddNewSubscriber";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.CommandTimeout = 0;



//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-AddNewSubscriber", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region Add Patient

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportAddNewPatient";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.CommandTimeout = 0;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-AddNewPatient", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region Add Provider

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportAddNewProvider";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.CommandTimeout = 0;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-AddNewProvider", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region TapeImportGetClaimIds

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportGetClaimIds";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.CommandTimeout = 0;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-GetClaimIds", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region TapeImportClaimExisting

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            //Group Code from Subro Group code table

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportGetGroupCode";

//                            TI_DB_Cmd.Parameters.AddWithValue("@GroupCodeID", iGroupCodeID);

//                            TI_DB_Cmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10);

//                            TI_DB_Cmd.Parameters["@GroupCode"].Direction = ParameterDirection.Output;

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                            strGroupCode = TI_DB_Cmd.Parameters["@GroupCode"].Value != DBNull.Value ? (string)TI_DB_Cmd.Parameters["@GroupCode"].Value : "";

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-TapeImportGetGroupCode", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }



//                    if (iContinue_flag == 0)

//                    //    && ((strGroupCode !="C000")

//                    //    && (strGroupCode != "9000")

//                    //    && (strGroupCode != "O000")

//                    //    && (strGroupCode != "V000")

//                    //    && (strGroupCode != "S000")

//                    //    && (strGroupCode != "7000")))

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportClaimExisting";

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.CommandTimeout = 0;

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-ClaimExisting", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    //else if((iContinue_flag == 0)

//                    //    && ((strGroupCode == "C000")

//                    //    || (strGroupCode == "9000")

//                    //    || (strGroupCode == "O000")

//                    //    || (strGroupCode == "V000")

//                    //    || (strGroupCode == "S000")

//                    //    || (strGroupCode == "7000"))

//                    //    )

//                    //{

//                    //    try

//                    //    {

//                    //        TI_DB_Cmd.Connection = TI_DB_Connection;

//                    //        TI_DB_Cmd.CommandText = "TapeImportDeleteClaimExist";

//                    //        TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                    //        TI_DB_Cmd.ExecuteNonQuery();

//                    //    }

//                    //    catch (Exception ex)

//                    //    {

//                    //        Dts.Events.FireError(0, "TapeImportLoader-DeleteClaimExist", ex.Message.ToString(), string.Empty, 0);

//                    //        iContinue_flag = 1;

//                    //        Dts.TaskResult = (int)ScriptResults.Failure;

//                    //    }

//                    //    finally

//                    //    {

//                    //        TI_DB_Cmd.Parameters.Clear();

//                    //    }

//                    //}

//                    #endregion



//                    #region TapeImportAddQues

//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportAddQues";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.Parameters.AddWithValue("@GroupCodeID", iGroupCodeID);

//                            TI_DB_Cmd.CommandTimeout = 0;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-AddQues", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion



//                    #region TapeImportAddInvestigationClaims

//                    //Not required since logic moved to Addques

//                    //if (iContinue_flag == 0)

//                    //{

//                    //    try

//                    //    {

//                    //        TI_DB_Cmd.Connection = TI_DB_Connection;

//                    //        TI_DB_Cmd.CommandText = "TapeImportAddInvestigationClaims";

//                    //        TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                    //        TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                    //        TI_DB_Cmd.Parameters.AddWithValue("@GroupCodeID", iGroupCodeID);

//                    //        TI_DB_Cmd.CommandTimeout = 0;

//                    //        TI_DB_Cmd.ExecuteNonQuery();

//                    //    }

//                    //    catch (Exception ex)

//                    //    {

//                    //        Dts.Events.FireError(0, "TapeImportLoader-TapeImportAddInvestigationClaims", ex.Message.ToString(), string.Empty, 0);

//                    //        iContinue_flag = 1;

//                    //        Dts.TaskResult = (int)ScriptResults.Failure;

//                    //    }

//                    //    finally

//                    //    {

//                    //        TI_DB_Cmd.Parameters.Clear();

//                    //    }

//                    //}

//                    #endregion



//                    #region TapeImportAddClaimToArchive



//                    if (iContinue_flag == 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "Tapeimportaddclaimtoarchive";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Cmd.Parameters.AddWithValue("@GroupCodeID", iGroupCodeID);

//                            TI_DB_Cmd.CommandTimeout = 0;

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-ArchiveClaims", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 1;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    #endregion

//                }

//                #endregion



//                #region Skip Import

//                if ((iContinue_flag != 0)

//                    || (((iRunImport == 0) && (iRunReset == 0))

//                    || ((iRunImport == 1) && (iRunReset == 1))))

//                {

//                    iRetFails = iRetFails + 1;

//                    if (iDataImportID != 0)

//                    {

//                        try

//                        {

//                            TI_DB_Cmd.Connection = TI_DB_Connection;

//                            TI_DB_Cmd.CommandText = "TapeImportSkipImport";

//                            TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                            TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                            TI_DB_Connection.Open();

//                            TI_DB_Cmd.ExecuteNonQuery();

//                            TI_DB_Connection.Close();

//                        }

//                        catch (Exception ex)

//                        {

//                            Dts.Events.FireError(0, "TapeImportLoader-SkipImport", ex.Message.ToString(), string.Empty, 0);

//                            iContinue_flag = 2;

//                            Dts.TaskResult = (int)ScriptResults.Failure;

//                        }

//                        finally

//                        {

//                            TI_DB_Cmd.Parameters.Clear();

//                        }

//                    }

//                    iContinue_flag = 0;

//                }

//                #endregion



//                #region Reset Priorities

//                if ((iContinue_flag == 0) && !(((iRunImport == 0) && (iRunReset == 0)) || ((iRunImport == 1) && (iRunReset == 1))))

//                {

//                    try

//                    {

//                        TI_DB_Cmd.Connection = TI_DB_Connection;

//                        TI_DB_Cmd.CommandText = "TapeImportSetPiorities";

//                        TI_DB_Cmd.CommandType = CommandType.StoredProcedure;

//                        TI_DB_Cmd.Parameters.AddWithValue("@DataImportID", iDataImportID);

//                        TI_DB_Connection.Open();

//                        TI_DB_Cmd.ExecuteNonQuery();

//                        TI_DB_Connection.Close();

//                    }

//                    catch (Exception ex)

//                    {

//                        Dts.Events.FireError(0, "TapeImportLoader-SetPiorities", ex.Message.ToString(), string.Empty, 0);

//                        iContinue_flag = 2;

//                        //CI_Cm.ReleaseConnection(TI_DB_Connection);

//                        Dts.TaskResult = (int)ScriptResults.Failure;

//                    }

//                    finally

//                    {

//                        TI_DB_Cmd.Parameters.Clear();

//                    }

//                }

//                #endregion



//                switch (DateTime.Today.DayOfWeek.ToString())

//                {

//                    case "Sunday": iWeekDay = 1; break;

//                    case "Monday": iWeekDay = 2; break;

//                    case "Tuesday": iWeekDay = 3; break;

//                    case "Wednesday": iWeekDay = 4; break;

//                    case "Thursday": iWeekDay = 5; break;

//                    case "Friday": iWeekDay = 6; break;

//                    case "Saturday": iWeekDay = 7; break;

//                }

//                //Check Hr is in 24Hr Format

//                iHour = DateTime.Now.Hour;

//                //iHour = 23;

//                if ((iWeekDay == 1)

//                    || ((iWeekDay != 1) && (((iHour >= 19) && (iHour <= 23)) || (iHour < 3)))

//                    || (iWeekDay == 2 && iHour < 4)

//                    || (HolidayOverRide > DateTime.Now))

//                {

//                    iTimeOK = 0;

//                }

//                else

//                {

//                    iTimeOK = 1;

//                }



//            }

//            #endregion

//            Dts.TaskResult = (int)ScriptResults.Success;

//        }

//    }

//}
//    }
//}
