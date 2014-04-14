using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using XamarinXmlSerialize.Core;
using System.Xml.Serialization;

namespace XamarinXmlSerialize.iOS
{
    public partial class Xamarin_iOS_SingleViewViewController : UIViewController
    {
        public Xamarin_iOS_SingleViewViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
        MyData _model;

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            _model = new MyData();
            // リストを初期化
            for (int i = 0; i < 10; i++)
            {
                _model.Map.Add(i * 10);
            }
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textModified.Text = _model.Modified.ToString();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="sender"></param>
        partial void ClickLoad(MonoTouch.Foundation.NSObject sender)
        {
            var se = new XmlSerializer(typeof(MyData));
            var documents =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var file = System.IO.Path.Combine(documents, "mydata.xml");
            using (var stream = System.IO.File.OpenRead(file))
            {
                var m = se.Deserialize(stream) as MyData;
                stream.Close();
                m.CopyTo(_model);
            }
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textModified.Text = _model.Modified.ToString();
        }
        /// <summary>
        /// データ保存
        /// </summary>
        /// <param name="sender"></param>
        partial void ClickSave(MonoTouch.Foundation.NSObject sender)
        {
            _model.UserName = textUserName.Text;
            _model.HighScore = int.Parse(textHighScore.Text);
            _model.Modified = DateTime.Parse(textModified.Text);
            var se = new XmlSerializer(typeof(MyData));
            var documents =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var file = System.IO.Path.Combine(documents, "mydata.xml");
            using (var stream = System.IO.File.OpenWrite(file))
            {
                stream.SetLength(0);
                se.Serialize(stream, _model);
                stream.Close();
            }
        }
    }
}

