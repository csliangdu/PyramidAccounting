﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PA.ViewModel;

namespace PA.Helper.DataDefind
{
    class CommonInfo
    {
        private static string username;
        private static string realname;
        private static string authority;
        private static int authority_value;
        private static string system_index;
        private static string currentPassword;
        private static string confirmPassword;
        private static int period;
        private static bool isSaved;
        private static int m_SoftwareState;
        private static string m_deviceID;
        private static string m_bookName;
        private static string company;
        private static string year;

        public static string 年
        {
            get { return CommonInfo.year; }
            set { CommonInfo.year = value; }
        }

        public static string 制表单位
        {
            get { return CommonInfo.company; }
            set { CommonInfo.company = value; }
        }

        public static string 账套信息
        {
            get { return CommonInfo.m_bookName; }
            set { CommonInfo.m_bookName = value; }
        }

        public static string U盘设备ID
        {
            get { return CommonInfo.m_deviceID; }
            set { CommonInfo.m_deviceID = value; }
        }

        public static bool 是否初始化年初数
        {
            get { return CommonInfo.isSaved; }
            set { CommonInfo.isSaved = value; }
        }

        public static int 当前期
        {
            get { return CommonInfo.period; }
            set { CommonInfo.period = value; }
        }


        public static string 验证密码
        {
            get { return CommonInfo.confirmPassword; }
            set { CommonInfo.confirmPassword = value; }
        }

        public static string 登录密码
        {
            get { return CommonInfo.currentPassword; }
            set { CommonInfo.currentPassword = value; }
        }

        public static int 权限值
        {
            get { return CommonInfo.authority_value; }
            set { CommonInfo.authority_value = value; }
        }
        /// <summary>
        /// 012345 按会计制度下拉框索引值设定
        /// </summary>
        public static string 制度索引
        {
            get { return CommonInfo.system_index; }
            set { CommonInfo.system_index = value; }
        }

        public static string 用户权限
        {
            get { return CommonInfo.authority; }
            set { CommonInfo.authority = value; }
        }

        public static string 真实姓名
        {
            get { return CommonInfo.realname; }
            set { CommonInfo.realname = value; }
        }

        public static string 用户名
        {
            get { return username; }
            set { username = value; }
        }

        private static string bookid;

        public static string 账薄号
        {
            get { return CommonInfo.bookid; }
            set { CommonInfo.bookid = value; }
        }

        public static int SoftwareState
        {
            get { return m_SoftwareState; }
            set { m_SoftwareState = value; }
        }

    }
}
