using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XamarinXmlSerialize.Core;
using System.Xml.Serialization;

namespace XamarinXmlSerialize.WPF
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
        /// データ保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSave(object sender, RoutedEventArgs e)
        {
            var se = new XmlSerializer(typeof(MyData));
            using (var stream = System.IO.File.OpenWrite("mydata.xml"))
            {
                se.Serialize(stream, _model);
            }
        }

        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLoad(object sender, RoutedEventArgs e)
        {
            var se = new XmlSerializer(typeof(MyData));
            using (var stream = System.IO.File.OpenRead("mydata.xml"))
            {
                var m = se.Deserialize(stream) as MyData;
                m.CopyTo(_model);
            }
        }

        MyData _model;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _model = new MyData();
            // リストを初期化
            for (int i = 0; i < 10; i++)
            {
                _model.Map.Add(i * 10);
            }
            this.DataContext = _model;

        }
    }
}
