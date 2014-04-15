using XamarinXmlSerialize.Uni.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Xml.Serialization;
using XamarinXmlSerialize.Core;
using Windows.Storage;

namespace XamarinXmlSerialize.Uni
{
    public sealed partial class BasicPage : Page
    {
        private async void ClickLoad(object sender, RoutedEventArgs e)
        {
            var se = new XmlSerializer(typeof(MyData));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(
                "mydata.xml"))
            {
                var m = se.Deserialize(stream) as MyData;
                m.CopyTo(_model);
            }
        }

        private async void ClickSave(object sender, RoutedEventArgs e)
        {
            var se = new XmlSerializer(typeof(MyData));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                "mydata.xml", CreationCollisionOption.OpenIfExists))
            {
                stream.SetLength(0);
                stream.Position = 0;
                se.Serialize(stream, _model);
            }
        }

        MyData _model;
        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            _model = new MyData();
            this.DataContext = _model;

        }
    }
}
