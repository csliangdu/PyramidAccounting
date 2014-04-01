﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PA.Model.CustomEventArgs;
using PA.Model.ComboBox;

namespace PA.View.Pages.Pop.凭证录入
{
    public delegate void Page_凭证录入_子细目_FillDateEventHandle(object sender, MyEventArgs e);

    public partial class Page_凭证录入_子细目 : Page
    {
        public event Page_凭证录入_子细目_FillDateEventHandle FillDate;
        private string _name;
        public Page_凭证录入_子细目(string _name)
        {
            InitializeComponent();
            this._name = _name;
            this.ListBox_子细目.ItemsSource = new ComboBox_科目().GetChildSubjectList("", _name);
        }

        private void OnFillDate(string str)
        {
            if (FillDate != null)
            {
                MyEventArgs e = new MyEventArgs();
                e.Str = str;
                FillDate(this, e);
            }
        }

        private void ListBox_子细目_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.ListBox_子细目.SelectedValue != null)
            {
                OnFillDate(this.ListBox_子细目.SelectedValue.ToString());
            }
        }

        private void TextBox_子细目_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            this.ListBox_子细目.ItemsSource = new ComboBox_科目().GetChildSubjectList(tb.Text.Trim(), _name);
        }

        private void Button_确定_Click(object sender, RoutedEventArgs e)
        {
            ListBox_子细目_MouseDoubleClick(this, null);
        }
    }
}
