﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using xls = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using PA.Model.DataGrid;
using PA.Helper.DataDefind;
using PA.Helper.DataBase;

namespace PA.Helper.ExcelHelper
{
    /// <summary>
    /// 事业单位报表导出Excel
    /// </summary>
    class InstitutionsExcelWriter
    {
        private string Path = AppDomain.CurrentDomain.BaseDirectory;
        private object misValue = System.Reflection.Missing.Value;
        private string DateNow = "";

        public InstitutionsExcelWriter()
        {
            DateNow = DateTime.Now.ToString("_yyyyMMddHHmmss");
        }

        #region 3.报表
        /// <summary>
        /// 资产负债表（事业）
        /// </summary>
        /// <param name="ParmPeroid"></param>
        /// <param name="People"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public string ExportBalanceSheet(int ParmPeroid, string People)
        {
            string result = "";
            #region init Excel
            xls.Application xlApp = null;
            xls.Workbook xlWorkBook;
            xls.Worksheet xlWorkSheet;
            string SourceXls = Path + @"Data\打印\资产负债表（事业）模板.xls";
            string ExportXls = Path + @"Excel\打印\资产负债表（事业）" + DateNow + ".xls";
            try
            {
                File.Copy(SourceXls, ExportXls, true);
            }
            catch (FileNotFoundException fe)
            {
                Log.Write(fe.Message);
                return "模板文件未找到";
            }
            catch (IOException ioe)
            {
                Log.Write(ioe.Message);
                return "文件锁定，请关闭Excel再试";
            }
            try
            {
                xlApp = new xls.Application();
            }
            catch (Exception ee)
            {
                Log.Write(ee.Message);
                return "找不到EXCEL软件";
            }
            xlWorkBook = xlApp.Workbooks.Open(ExportXls);
            xlWorkSheet = (xls.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            #endregion

            #region fill data
            List<Model_报表类> data = new PA.ViewModel.ViewModel_ReportManager().GetBalanceSheet(ParmPeroid);
            decimal dy = 0;
            decimal dn = 0;
            decimal sumy1 = 0;
            decimal sumn1 = 0;
            decimal sumy2 = 0;
            decimal sumn2 = 0;
            decimal sumy3 = 0;
            decimal sumn3 = 0;
            decimal sumy4 = 0;
            decimal sumn4 = 0;
            decimal sumy5 = 0;
            decimal sumn5 = 0;

            int x = 1, y = 1;
            DataSet ds;
            if (!new PA.Helper.ExcelHelper.ExcelReader().ExcelDataSource(SourceXls, "Sheet1", out ds))
            {
                return "出错了，请联系管理员。";
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string key = dr[dc].ToString();
                    foreach (Model_报表类 a in data)
                    {
                        if (key == "y" + a.编号)
                        {
                            xlWorkSheet.Cells[y + 1, x] = a.年初数;
                            xlWorkSheet.Cells[y + 1, x + 1] = a.期末数;
                            decimal.TryParse(a.年初数, out dy);
                            decimal.TryParse(a.期末数, out dn);
                            if (a.编号.StartsWith("1"))
                            {
                                sumy1 += dy;
                                sumn1 += dn;
                            }
                            else if (a.编号.StartsWith("2"))
                            {
                                sumy2 += dy;
                                sumn2 += dn;
                            }
                            else if (a.编号.StartsWith("3"))
                            {
                                sumy3 += dy;
                                sumn3 += dn;
                            }
                            else if (a.编号.StartsWith("4"))
                            {
                                sumy4 += dy;
                                sumn4 += dn;
                            }
                            else if (a.编号.StartsWith("5"))
                            {
                                sumy5 += dy;
                                sumn5 += dn;
                            }
                        }
                    }
                    x++;
                }
                y++;
                x = 1;
            }
            xlWorkSheet.Cells[1, "C"] = CommonInfo.年 + " 年 " + ParmPeroid + " 月 资 产 负 债 表 ( 事 业 )";
            xlWorkSheet.Cells[2, "A"] = "编制单位：" + CommonInfo.制表单位;
            xlWorkSheet.Cells[2, "D"] = DateTime.Today.ToLongDateString();
            xlWorkSheet.Cells[18, "C"] = sumy1;
            xlWorkSheet.Cells[18, "D"] = sumn1;
            xlWorkSheet.Cells[30, "C"] = sumy5;
            xlWorkSheet.Cells[30, "D"] = sumn5;
            xlWorkSheet.Cells[16, "G"] = sumy2;
            xlWorkSheet.Cells[16, "H"] = sumn2;
            xlWorkSheet.Cells[25, "G"] = sumy3;
            xlWorkSheet.Cells[25, "H"] = sumn3;
            xlWorkSheet.Cells[34, "G"] = sumy4;
            xlWorkSheet.Cells[34, "H"] = sumn4;

            xlWorkSheet.Cells[35, "C"] = sumy1 + sumy5;
            xlWorkSheet.Cells[35, "D"] = sumn1 + sumn5;
            xlWorkSheet.Cells[35, "G"] = sumy2 + sumy3 + sumy4;
            xlWorkSheet.Cells[35, "H"] = sumn2 + sumn3 + sumn4;

            xlWorkSheet.Cells[36, "A"] = "单位负责人：林广正";
            xlWorkSheet.Cells[36, "C"] = "填表人：" + CommonInfo.真实姓名;
            xlWorkSheet.Cells[36, "F"] = "填表日期：" + DateTime.Now.ToLongDateString();
            #endregion

            xlApp.Visible = true;
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return result;
        }
        /// <summary>
        /// 收入支出总表（事业）
        /// </summary>
        /// <param name="ParmPeroid"></param>
        /// <returns></returns>
        public string ExportIncomeAndExpenditure(int ParmPeroid)
        {
            string result = "";
            #region init Excel
            xls.Application xlApp = null;
            xls.Workbook xlWorkBook;
            xls.Worksheet xlWorkSheet;
            string SourceXls = Path + @"Data\打印\收入支出总表（事业）模板.xls";
            string ExportXls = Path + @"Excel\打印\收入支出总表（事业）" + DateNow + ".xls";
            try
            {
                File.Copy(SourceXls, ExportXls, true);
            }
            catch (FileNotFoundException)
            {
                return "模板文件未找到";
            }
            catch (IOException)
            {
                return "文件锁定，请关闭Excel再试";
            }
            try
            {
                xlApp = new xls.Application();
            }
            catch (Exception)
            {
                return "找不到EXCEL软件";
            }
            xlWorkBook = xlApp.Workbooks.Open(ExportXls);
            xlWorkSheet = (xls.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            #endregion

            #region fill data

            //第一次对一级科目赋值
            List<Model_报表类> data = new PA.ViewModel.ViewModel_ReportManager().GetIncomeAndExpenses(ParmPeroid, new ViewModel.ViewModel_科目管理().GetOneSubjectList());

            decimal dy = 0;
            decimal dn = 0;
            decimal total01 = 0;
            decimal total02 = 0;
            decimal total03 = 0;
            decimal total04 = 0;
            decimal total05 = 0;
            decimal total06 = 0;
            decimal total07 = 0;
            decimal total08 = 0;
            decimal total09 = 0;
            decimal total10 = 0;

            int x = 1, y = 1;
            DataSet ds;
            if (!new PA.Helper.ExcelHelper.ExcelReader().ExcelDataSource(SourceXls, "Sheet1", out ds))
            {
                return "出错了，请联系管理员。";
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string key = dr[dc].ToString();
                    foreach (Model_报表类 m in data)
                    {
                        if (key == "inM" + m.编号)
                        {
                            xlWorkSheet.Cells[y + 1, x] = m.本期数;
                            xlWorkSheet.Cells[y + 1, x + 1] = m.累计数;
                            decimal.TryParse(m.累计数, out dy);
                            decimal.TryParse(m.本期数, out dn);
                            if (m.编号.StartsWith("4"))
                            {
                                if (m.编号.Equals("404"))
                                {
                                    total03 += dn;
                                    total04 += dy;
                                }
                                else
                                {
                                    total01 += dn;
                                    total02 += dy;
                                }
                            }
                            else if (m.编号.StartsWith("5"))
                            {
                                if (m.编号.Equals("512"))
                                {
                                    total07 += dn;
                                    total08 += dy;
                                }
                                else if (m.编号.Equals("501") || m.编号.Equals("503"))
                                {
                                    total09 += dn;
                                    total10 += dy;
                                }
                                else
                                {
                                    total05 += dn;
                                    total06 += dy;
                                }
                            }
                        }
                    }
                    x++;
                }
                y++;
                x = 1;
            }
            xlWorkSheet.Cells[1, "D"] = CommonInfo.年 + " 年 " + ParmPeroid + " 月 收 入 支 出 总 表 （ 事 业 ）";
            xlWorkSheet.Cells[3, "A"] = "编制单位：" + CommonInfo.制表单位;
            xlWorkSheet.Cells[3, "D"] = DateTime.Today.ToLongDateString();

            //小计赋值
            xlWorkSheet.Cells[14, "B"] = total01 == 0 ? "" : "" + total01;
            xlWorkSheet.Cells[14, "C"] = total02 == 0 ? "" : "" + total02;
            xlWorkSheet.Cells[17, "B"] = total03 == 0 ? "" : "" + total03;
            xlWorkSheet.Cells[17, "C"] = total04 == 0 ? "" : "" + total04;
            xlWorkSheet.Cells[14, "E"] = total05 == 0 ? "" : "" + total05;
            xlWorkSheet.Cells[14, "F"] = total06 == 0 ? "" : "" + total06;    
            xlWorkSheet.Cells[17, "E"] = total07 == 0 ? "" : "" + total07;
            xlWorkSheet.Cells[17, "F"] = total08 == 0 ? "" : "" + total08;
            xlWorkSheet.Cells[21, "E"] = total09 == 0 ? "" : "" + total09;
            xlWorkSheet.Cells[21, "F"] = total10 == 0 ? "" : "" + total10;

            xlWorkSheet.Cells[22, "B"] = total01 + total03;
            xlWorkSheet.Cells[22, "C"] = total02 + total04;
            xlWorkSheet.Cells[22, "E"] = total05 + total07 + total09;
            xlWorkSheet.Cells[22, "F"] = total06 + total08 + total10;
            decimal temp = (total02 + total04) - (total06 + total08 + total10);
            xlWorkSheet.Cells[6, "H"] = temp;
            xlWorkSheet.Cells[22, "H"] = temp;

            //第一次对二级科目赋值
            List<Model_报表类> data2 = new PA.ViewModel.ViewModel_ReportManager().GetIncomeAndExpensesForTwoSubject(ParmPeroid, new ViewModel.ViewModel_科目管理().GetIncomeAndOutSubjectList());
            x = 1;
            y = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string key = dr[dc].ToString();
                    foreach (Model_报表类 m in data2)
                    {
                        if (key == "inM" + m.编号)
                        {
                            xlWorkSheet.Cells[y + 1, x] = m.本期数;
                            xlWorkSheet.Cells[y + 1, x + 1] = m.累计数;
                            decimal.TryParse(m.累计数, out dy);
                            decimal.TryParse(m.本期数, out dn);
                            if (m.编号.Equals("30601"))
                            {
                                xlWorkSheet.Cells[7, "H"] = m.累计数;
                            }
                            else if (m.编号.Equals("30602"))
                            {
                                xlWorkSheet.Cells[8, "H"] = m.累计数;
                            }
                        }
                    }
                    x++;
                }
                y++;
                x = 1;
            }

            xlWorkBook.Save();
            
            x = 1;
            y = 1;
            if (!new PA.Helper.ExcelHelper.ExcelReader().ExcelDataSource(ExportXls, "Sheet1", out ds))
            {
                return "出错了，请联系管理员。";
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string key = dr[dc].ToString();
                    if (key.StartsWith("in") || key.StartsWith("B"))
                    {
                        xlWorkSheet.Cells[y + 1, x] = "";
                    }
                    x++;
                }
                y++;
                x = 1;
            }


            #endregion

            xlApp.Visible = true;
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return result;
        }
        /// <summary>
        /// 事业及经营支出明细表
        /// </summary>
        /// <param name="ParmPeroid"></param>
        /// <returns></returns>
        public string ExportAdministrativeExpensesSchedule(int ParmPeroid)
        {
            string result = "";
            #region init Excel
            xls.Application xlApp = null;
            xls.Workbook xlWorkBook;
            xls.Worksheet xlWorkSheet;
            string SourceXls = Path + @"Data\打印\事业及经营支出明细表.xls";
            string ExportXls = Path + @"Excel\打印\事业及经营支出明细表" + DateNow + ".xls";
            try
            {
                File.Copy(SourceXls, ExportXls, true);
            }
            catch (FileNotFoundException)
            {
                return "模板文件未找到";
            }
            catch (IOException)
            {
                return "文件锁定，请关闭Excel再试";
            }
            try
            {
                xlApp = new xls.Application();
            }
            catch (Exception)
            {
                return "找不到EXCEL软件";
            }
            xlWorkBook = xlApp.Workbooks.Open(ExportXls);
            xlWorkSheet = (xls.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            #endregion

            #region fill data
            List<Model_报表类> data = new PA.ViewModel.ViewModel_ReportManager().GetAdministrativeExpenseDetail(ParmPeroid, 504);

            //二级科目
            decimal b101 = 0;
            decimal b102 = 0;
            decimal b201 = 0;
            decimal b202 = 0;
            decimal b301 = 0;
            decimal b302 = 0;
            decimal b401 = 0;
            decimal b402 = 0;
            decimal b501 = 0;
            decimal b502 = 0;
            decimal b601 = 0;
            decimal b602 = 0;
            decimal b701 = 0;
            decimal b702 = 0;

            int x = 1, y = 1;
            DataSet ds;
            if (!new PA.Helper.ExcelHelper.ExcelReader().ExcelDataSource(SourceXls, "Sheet1", out ds))
            {
                return "出错了，请联系管理员。";
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string key = dr[dc].ToString();
                    foreach (Model_报表类 m in data)
                    {
                        if (key == "Label_A" + m.编号.Replace("（", "").Replace("）", ""))
                        {
                            xlWorkSheet.Cells[y + 1, x] = m.本期数;
                            xlWorkSheet.Cells[y + 1, x + 1] = m.累计数;
                        }
                    }
                    x++;
                }
                y++;
                x = 1;
            }

            xlWorkBook.Save();
            x = 1;
            y = 1;
            if (!new PA.Helper.ExcelHelper.ExcelReader().ExcelDataSource(ExportXls, "Sheet1", out ds))
            {
                return "出错了，请联系管理员。";
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string key = dr[dc].ToString();
                    if (key.StartsWith("Label_"))
                    {
                        xlWorkSheet.Cells[y + 1, x] = "";
                    }
                    x++;
                }
                y++;
                x = 1;
            }

            //计算合计
            //工资福利支出
            for (int i = 8; i < 15; i++)
            {
                decimal temp101 = 0m, temp201 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "B"]).Text, out temp101);
                b101 += temp101;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "C"]).Text, out temp201);
                b102 += temp201;
            }
            //商品和服务支出
            for (int i = 16; i < 34; i++)
            {
                decimal temp101 = 0m, temp201 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "B"]).Text, out temp101);
                b201 += temp101;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "C"]).Text, out temp201);
                b202 += temp201;
            }
            //对个人和家庭的补助
            for (int i = 7; i < 15; i++)
            {
                decimal T1 = 0m, T2 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "E"]).Text, out T1);
                b301 += T1;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "F"]).Text, out T2);
                b302 += T2;
            }
            //对企事业单位的补贴
            for (int i = 16; i < 18; i++)
            {
                decimal T1 = 0m, T2 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "E"]).Text, out T1);
                b401 += T1;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "F"]).Text, out T2);
                b402 += T2;
            }
            //债务利息支出
            for (int i = 19; i < 20; i++)
            {
                decimal T1 = 0m, T2 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "E"]).Text, out T1);
                b501 += T1;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "F"]).Text, out T2);
                b502 += T2;
            }
            //其他资本性支出
            for (int i = 21; i < 30; i++)
            {
                decimal T1 = 0m, T2 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "E"]).Text, out T1);
                b601 += T1;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "F"]).Text, out T2);
                b602 += T2;
            }
            //其他支出
            for (int i = 31; i < 33; i++)
            {
                decimal T1 = 0m, T2 = 0m;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "E"]).Text, out T1);
                b701 += T1;
                decimal.TryParse(((xls.Range)xlWorkSheet.Cells[i, "F"]).Text, out T2);
                b702 += T2;
            }
            xlWorkSheet.Cells[2, "A"] = "编制单位：" + CommonInfo.制表单位;
            xlWorkSheet.Cells[1, "C"] = CommonInfo.年 + "年" + ParmPeroid + "月事业及经营支出明细表";

            xlWorkSheet.Cells[7, "B"] = b101;
            xlWorkSheet.Cells[7, "C"] = b102;

            xlWorkSheet.Cells[15, "B"] = b201;
            xlWorkSheet.Cells[15, "C"] = b202;

            xlWorkSheet.Cells[6, "E"] = b301;
            xlWorkSheet.Cells[6, "F"] = b302;

            xlWorkSheet.Cells[15, "E"] = b401;
            xlWorkSheet.Cells[15, "F"] = b402;

            xlWorkSheet.Cells[18, "E"] = b501;
            xlWorkSheet.Cells[18, "F"] = b502;

            xlWorkSheet.Cells[20, "E"] = b601;
            xlWorkSheet.Cells[20, "F"] = b602;

            xlWorkSheet.Cells[30, "E"] = b701;
            xlWorkSheet.Cells[30, "F"] = b702;

            xlWorkSheet.Cells[6, "B"] = (b101 + b201 + b301 + b401 + b501 + b601 + b701);
            xlWorkSheet.Cells[6, "C"] = (b102 + b202 + b302 + b402 + b502 + b602 + b702);

            #endregion

            xlApp.Visible = true;
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return result;
        }
        #endregion

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
