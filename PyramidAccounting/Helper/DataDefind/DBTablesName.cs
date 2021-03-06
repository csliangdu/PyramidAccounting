﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PA.Helper.DataDefind
{
    class DBTablesName
    {
        private static readonly string t_BOOKS = "T_BOOKS";
        private static readonly string t_VOUCHER = "T_VOUCHER";
        private static readonly string t_VOUCHER_DETAIL = "T_VOUCHERDETAIL";
        private static readonly string t_SUBJECT = "T_SUBJECT";
        private static readonly string t_SUBJECT_TYPE = "T_SUBJECTTYPE";
        private static readonly string t_USER = "T_USER";
        private static readonly string t_RECORD = "T_RECORD";
        private static readonly string t_YEAR_FEE = "T_YEARFEE";
        private static readonly string t_FEE = "T_FEE";
        private static readonly string t_FIXEDASSETS = "T_FIXEDASSETS";
        private static readonly string t_SYSTEMINFO = "T_SYSTEMINFO";
        
        #region GETSET
        public static string T_SYSTEMINFO
        {
            get { return DBTablesName.t_SYSTEMINFO; }
        } 

        public static string T_YEAR_FEE
        {
            get { return DBTablesName.t_YEAR_FEE; }
        } 
        public static string T_BOOKS
        {
            get { return DBTablesName.t_BOOKS; }
        } 

        public static string T_VOUCHER
        {
            get { return DBTablesName.t_VOUCHER + "_" + CommonInfo.账薄号; }
        }

        public static string T_VOUCHER_DETAIL
        {
            get { return DBTablesName.t_VOUCHER_DETAIL + "_" + CommonInfo.账薄号; }
        }

        public static string T_SUBJECT
        {
            get { return DBTablesName.t_SUBJECT + "_" + CommonInfo.制度索引; }
        }

        public static string T_SUBJECT_TYPE
        {
            get { return DBTablesName.t_SUBJECT_TYPE; }
        }

        public static string T_USER
        {
            get { return DBTablesName.t_USER; }
        }

        public static string T_RECORD
        {
            get { return DBTablesName.t_RECORD + "_" + CommonInfo.账薄号; }
        }

        public static string T_FEE
        {
            get { return DBTablesName.t_FEE + "_" + CommonInfo.账薄号; }
        }

        public static string T_FIXEDASSETS
        {
            get { return t_FIXEDASSETS; }
        }

        #endregion
    }
}
