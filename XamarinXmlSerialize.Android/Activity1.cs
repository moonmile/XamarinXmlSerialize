using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinXmlSerialize.Core;
using System.Xml.Serialization;


namespace XamarinXmlSerialize.Android
{
    [Activity(Label = "XamarinXmlSerialize.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        MyData _model;
        TextView textUserName, textHighScore, textModified;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            FindViewById<Button>(Resource.Id.buttonLoad).Click += clickLoad;
            FindViewById<Button>(Resource.Id.buttonSave).Click += clickSave;
            textUserName = FindViewById<TextView>(Resource.Id.textUserName);
            textHighScore = FindViewById<TextView>(Resource.Id.textHighScore);
            textModified = FindViewById<TextView>(Resource.Id.textModified);

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

        /// <summary>
        /// データ保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickSave(object sender, EventArgs e)
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
            }
        }

        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickLoad(object sender, EventArgs e)
        {
            var se = new XmlSerializer(typeof(MyData));
            var documents =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var file = System.IO.Path.Combine(documents, "mydata.xml");
            using (var stream = System.IO.File.OpenRead(file))
            {
                var m = se.Deserialize(stream) as MyData;
                m.CopyTo(_model);
            }
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textModified.Text = _model.Modified.ToString();
        }
    }
}

