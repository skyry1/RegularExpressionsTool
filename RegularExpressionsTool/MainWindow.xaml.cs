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
        }


        /// <summary>
        /// 変換ボタン押下時の操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversionButton_Click(object sender, RoutedEventArgs e)
        {
            //テキストボックスが空ではないことを確認する。
            if(OrizinalString.Text.Equals(string.Empty) || SearchString.Text.Equals(string.Empty) || ReplacementString.Text.Equals(string.Empty))
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
                ConversionString.Text =　Regex.Replace(OrizinalString.Text, SearchString.Text, ReplacementString.Text);

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["OrizinalString"].Value = OrizinalString.Text;
                config.AppSettings.Settings["SearchString"].Value = SearchString.Text;
                config.AppSettings.Settings["ReplacementString"].Value = ReplacementString.Text;
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "置換失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
