using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamToDosEntity
{

    public class ComboxItem
    {
        private string text;
        private int value;

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public int Values
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ComboxItem(string _Text, int _Value)
        {
            Text = _Text;
            Values = _Value;
        }
        
    }
}
