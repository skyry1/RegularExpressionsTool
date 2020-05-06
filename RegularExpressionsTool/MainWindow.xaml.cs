using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RegularExpressionsTool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomButton1.ToolTip = Properties.Settings.Default.CustomButton1Content;
            CustomButton2.ToolTip = Properties.Settings.Default.CustomButton2Content;
            CustomButton3.ToolTip = Properties.Settings.Default.CustomButton3Content;
            CustomButton4.ToolTip = Properties.Settings.Default.CustomButton4Content;
            CustomButton5.ToolTip = Properties.Settings.Default.CustomButton5Content;
        }


        /// <summary>
        /// 変換ボタン押下時の操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversionButton_Click(object sender, RoutedEventArgs e)
        {
            //テキストボックスが空ではないことを確認する。
            if(OrizinalString.Text.Equals(string.Empty) || SearchString.Text.Equals(string.Empty))
            {
                MessageBox.Show("元ネタまたは検索文字列が設定されていません。","入力値不足", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //変換を実施する
            try
            {
                if (!Regex.IsMatch(OrizinalString.Text, SearchString.Text))
                {
                    MessageBox.Show("一致しません", "置換失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string replacement = "";
                if (ReplacementString.Text.Equals(string.Empty))
                {
                    replacement = ReplacementString.Text;
                }
                ConversionString.Text =　Regex.Replace(OrizinalString.Text, SearchString.Text, replacement);

                Properties.Settings.Default.OrizinalString = OrizinalString.Text;
                Properties.Settings.Default.SearchString = SearchString.Text;
                Properties.Settings.Default.ReplacementString = ReplacementString.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "置換失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CustomButton1_Click(object sender, RoutedEventArgs e)
        {
            SearchString.Text += Properties.Settings.Default.CustomButton1Value;
        }

        private void CustomButton2_Click(object sender, RoutedEventArgs e)
        {
            SearchString.Text += Properties.Settings.Default.CustomButton2Value;
        }

        private void CustomButton3_Click(object sender, RoutedEventArgs e)
        {
            SearchString.Text += Properties.Settings.Default.CustomButton3Value;
        }

        private void CustomButton4_Click(object sender, RoutedEventArgs e)
        {
            SearchString.Text += Properties.Settings.Default.CustomButton4Value;
        }

        private void CustomButton5_Click(object sender, RoutedEventArgs e)
        {
            SearchString.Text += Properties.Settings.Default.CustomButton5Value;
        }

    }
}
