﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PA.Model.DataGrid;
using PA.ViewModel;
using PA.Helper.DataBase;
using PA.Helper.DataDefind;
using PA.Helper.ExcelHelper;
using System.IO;
using PA.Model.Others;

namespace PA.ViewModel
{
    class ViewModel_年初金额
    {
        private ViewModel_科目管理 vm = new ViewModel_科目管理();
        private DataBase db = new DataBase();
        /// <summary>
        /// 执行插入语句
        /// </summary>
        /// <param name="bookid"></param>
        public void Insert(string bookid)
        {
            string sql = "insert into " + DBTablesName.T_YEAR_FEE + "(subject_id,fee,bookid,parentid) select subject_id,0,'" + bookid + "',parent_id from " 
                + DBTablesName.T_SUBJECT;
            bool flag = db.Excute(sql);
            if (!flag)
            {
                List<string> list = new List<string>();
                ExcelReader er = new ExcelReader();
                DirectoryInfo theFolder = new DirectoryInfo("Data\\科目");
                List<Model_BalanceSheet> BalanceSheetDatas = new List<Model_BalanceSheet>();
                BalanceSheetDatas = er.ReadBalanceSheet(theFolder.GetFiles()[Int32.Parse(CommonInfo.制度索引)].FullName);
                string baseTableName = "T_SUBJECT";
                string table_Sql = new Helper.SQLHelper.SQLReader().ReadSQL(2, baseTableName, DBTablesName.T_SUBJECT);
                list.Add(table_Sql);
                foreach (Model_BalanceSheet m in BalanceSheetDatas)
                {
                    string sql1 = "insert into " + DBTablesName.T_SUBJECT
                        + "(subject_id,subject_type,subject_name) values ('" + m.Number + "'," + m.Type + ",'" + m.Name + "')";
                    list.Add(sql1);
                }
                flag = db.BatchOperate(list);
                if (flag)
                {
                    db.Excute(sql);
                }
            }
        }

        public bool Update()
        {

            string _sql = "delete from " + DBTablesName.T_FEE + " where period=0";
            db.Excute(_sql);

            string sql = "insert into " + DBTablesName.T_FEE
                + "(period,subject_id,comments,fee,mark) select 0,a.subject_id,'承上年结余',a.fee,b.Borrow_Mark from " 
                + DBTablesName.T_YEAR_FEE + " a left join "
                +  DBTablesName.T_SUBJECT +  " b on a.subject_id=b.subject_id where a.parentid = '0' and a.bookid='" 
                + CommonInfo.账薄号 + "' order by a.subject_id";

            return db.Excute(sql);
        }

        /// <summary>
        /// 检查是否初始化年初金额
        /// </summary>
        /// <returns></returns>
        public bool IsSaved()
        {
            bool flag = false;
            string sql = "select count(1) from " + DBTablesName.T_FEE; 
            string str = db.GetAllData(sql).Split('\t')[0].Split(',')[0];
            if (str.Equals("0"))
            {
                return false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }
    }
}
