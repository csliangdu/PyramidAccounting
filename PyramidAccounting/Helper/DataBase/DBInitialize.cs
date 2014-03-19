﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using PA.Helper.XMLHelper;
using PA.Helper.ExcelHelper;
using PA.Model.Others;
using PA.Helper.DataDefind;

namespace PA.Helper.DataBase
{
    public class DBInitialize
    {
        public static string dataSource = "Data\\" + new XMLReader().ReadXML("数据库");
        public static string dbPassword = "";
        private ReadBalanceSheet rs = new ReadBalanceSheet();

        public DBInitialize()
        {
            Log.Write("DBInitialize");
        }
        public void Initialize()
        {
            //新建数据库
            SQLiteConnection.CreateFile(dataSource);
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            SQLiteConnection conn = new SQLiteConnection();
            connstr.DataSource = dataSource;
            conn.ConnectionString = connstr.ToString();

            conn.Open();
            conn.Close();

            DataBase db = new DataBase();
            List<string> dataList = new List<string>();
            dataList = getSqlList(Properties.Resources.DatabaseTable);
            db.BatchOperate(dataList);
            dataList.Clear();
            dataList = getSqlList(Properties.Resources.DatabaseData);
            db.BatchOperate(dataList);
            dataList.Clear();
            dataList = GetSubjectSqlList();
            db.BatchOperate(dataList);
        }
        private List<string> GetSubjectSqlList()
        {
            List<string> list = new List<string>();
            DirectoryInfo theFolder = new DirectoryInfo("Data\\科目");
            int i = 0;
            foreach (FileInfo newFile in theFolder.GetFiles())
            {
                List<Model_BalanceSheet> BalanceSheetDatas = new List<Model_BalanceSheet>();
                BalanceSheetDatas = rs.Read(newFile.FullName);
                string tableName = "T_SUBJECT_" + i;
                string table_Sql = "create table if not exists " + tableName + " as select * from t_subject where 1=0";
                list.Add(table_Sql);
                foreach (Model_BalanceSheet m in BalanceSheetDatas)
                {
                    string sql = "insert into " + tableName + "(subject_id,subject_type,subject_name) values ('" + m.Number + "'," + m.Type + ",'" + m.Name + "')";
                    list.Add(sql);
                }
                i++;
            }
            return list;
        }

        public static SQLiteConnection getDBConnection()
        {
            SQLiteConnection conn = new SQLiteConnection();
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            connstr.DataSource = dataSource;
            conn.ConnectionString = connstr.ToString();
            //conn.SetPassword(password);
            return conn;
        }
        /// <summary>
        /// 获取SQL创建脚步方法，封装成List<string>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> getSqlList(string fileName)
        {
            string filePath = fileName;
            List<string> sqlList = new List<string>();
            {
                string str = filePath;
                string[] arr = str.Split(';');
                foreach (string s in arr)
                {
                    sqlList.Add(s);
                }
            }
            return sqlList;
        }
    }
}
