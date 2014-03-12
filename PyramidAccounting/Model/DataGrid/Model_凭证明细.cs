﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PA.Model.DataGrid
{
    class Model_凭证明细
    {
        private int id;
        private string parentid;
        private string abstract_comments;
        private string subject_id;
        private string deal;
        private int bookkeep_mark;
        private decimal debit;
        private decimal credit;
        private string book_id;

        public string 账套ID
        {
            get { return book_id; }
            set { book_id = value; }
        }

        public decimal 贷方
        {
            get { return credit; }
            set { credit = value; }
        }

        public decimal 借方
        {
            get { return debit; }
            set { debit = value; }
        }

        public int 记账
        {
            get { return bookkeep_mark; }
            set { bookkeep_mark = value; }
        }

        public string 子细目
        {
            get { return deal; }
            set { deal = value; }
        }

        public string 科目编号
        {
            get { return subject_id; }
            set { subject_id = value; }
        }

        public string 摘要
        {
            get { return abstract_comments; }
            set { abstract_comments = value; }
        }

        public string 父节点ID
        {
            get { return parentid; }
            set { parentid = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
