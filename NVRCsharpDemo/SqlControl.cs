using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data;

namespace NVRCsharpDemo
{
    class SqlControl
    {
        string strConn;
        public SqlControl()
        {
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                //string strConn = "";
                string udl = Application.StartupPath + "\\database.udl";
                StreamReader sr = new StreamReader(udl, Encoding.Default);
                for (int i = 0; i < 3; i++)
                {
                    strConn = sr.ReadLine();
                }
            }
            catch(Exception er)
            {
                logControl.saveLogInf("初始化数据库接口发生异常:" + er.Message);
                throw new Exception(er.Message);
            }
        }
        private void saveZbzlToCd(string pzlx, string pzhm, string vin, string zbzl, DateTime jcrq)
        {
            try
            {
                OleDbConnection adoConn = new OleDbConnection();                
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                OleDbCommand cmd = adoConn.CreateCommand();
                OleDbTransaction Trans = adoConn.BeginTransaction();
                cmd.Transaction = Trans;
                Trans.Rollback();
                try
                {
                    logControl.saveLogInf("连接数据库成功");
                    string checksql = "select * from [zbzl] where vin ='" + vin + "' and JCBH=''";
                    string updatesql = "update [zbzl] set pzlx='" + pzlx + "',pzhm='" + pzhm + "',zbzl='" + zbzl + "',jcrq='" + jcrq.ToString("yyyy-MM-dd HH:mm:ss") + "'" + " where vin ='" + vin + "' and JCBH=''";
                    string insertsql = "insert into [zbzl] (pzlx,pzhm,vin,zbzl,jcrq,JCBH) values ('" + pzlx + "','" + pzhm + "','" + vin + "','" + zbzl + "','" + jcrq.ToString("yyyy-MM-dd HH:mm:ss") + "','')";
                    OleDbCommand datacheck = new OleDbCommand(checksql, adoConn);
                    if (null != datacheck.ExecuteScalar())
                    {
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                        dataAdapter.InsertCommand = new OleDbCommand(updatesql, adoConn);
                        dataAdapter.InsertCommand.CommandText = updatesql;
                        dataAdapter.InsertCommand.ExecuteNonQuery();
                        dataAdapter.Dispose();
                        logControl.saveLogInf("更新数据到驰达数据库成功");
                    }
                    else
                    {
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                        dataAdapter.InsertCommand = new OleDbCommand(insertsql, adoConn);
                        dataAdapter.InsertCommand.CommandText = insertsql;
                        dataAdapter.InsertCommand.ExecuteNonQuery();
                        dataAdapter.Dispose();
                        logControl.saveLogInf("插入数据到驰达数据库成功");
                    }

                }
                catch (Exception er)
                {
                    logControl.saveLogInf("插入数据到驰达数据库过程发生异常:" + er.Message);
                    Trans.Rollback();
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                logControl.saveLogInf("链接到驰达数据库失败:" + er.Message);
            }
        }
        public DataTable getCarList(DateTime starttime,DateTime endtime)
        {
            DataTable dt = null;
            try
            {
                OleDbConnection adoConn = new OleDbConnection();
                adoConn.ConnectionString = strConn;
                adoConn.Open();
                OleDbCommand cmd = adoConn.CreateCommand();
                OleDbTransaction Trans = adoConn.BeginTransaction();
                cmd.Transaction = Trans;
                Trans.Rollback();
                try
                {
                    logControl.saveLogInf("连接数据库成功");
                    string checksql = "select CLID,JCSJ,JCKSSJ,JCJSSJ,VideoFrontUrl,VideoBackUrl,HasUpload,LINEID from [已检车辆信息] where JCSJ >'" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "' and JCSJ <'" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "' order by JCSJ";
                    OleDbCommand datacheck = new OleDbCommand(checksql, adoConn);
                    OleDbDataReader reader=datacheck.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("CLID");
                        dt.Columns.Add("JCSJ");
                        dt.Columns.Add("JCKSSJ");
                        dt.Columns.Add("JCJSSJ");
                        dt.Columns.Add("VideoFrontUrl");
                        dt.Columns.Add("VideoBackUrl");
                        dt.Columns.Add("HasUpload");
                        dt.Columns.Add("LINEID");
                        while (reader.Read())
                        {
                            dt.Rows.Add(new object[]{reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString() });
                        }
                        //return dt;
                    }
                }
                catch (Exception er)
                {
                    logControl.saveLogInf("查询数据发生异常:" + er.Message);
                    Trans.Rollback();
                    
                }
                adoConn.Close();
            }
            catch (Exception er)
            {
                logControl.saveLogInf("链接到驰达数据库失败:" + er.Message);
            }
            return dt;
        }
    }
}
