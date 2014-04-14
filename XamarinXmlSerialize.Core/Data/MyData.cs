using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinXmlSerialize.Core
{
    public class MyData : BindableBase
    {

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { this.SetProperty(ref this._UserName, value); }
        }

        private int _HighScore;
        public int HighScore
        {
            get { return _HighScore; }
            set { this.SetProperty(ref this._HighScore, value); }
        }

        private DateTime _Modified;
        public DateTime Modified
        {
            get { return _Modified; }
            set { this.SetProperty(ref this._Modified, value); }
        }

        private List<int> _Map;
        public List<int> Map
        {
            get { return _Map; }
            set { this.SetProperty(ref this._Map, value); }
        }

        public MyData()
        {
            Map = new List<int>();
            UserName = "your name";
            HighScore = 0;
            Modified = DateTime.Now;
        }
        public void CopyTo(MyData dest)
        {
            dest.UserName = this.UserName;
            dest.HighScore = this.HighScore;
            dest.Modified = this.Modified;
            dest.Map = new List<int>(this.Map);
        }
    }
}
