using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer.DTO
{
    public class CBBItem
    {
        // loc cac doi tuong LSH -> hien thi ten ComboBox
        public string Text { get; set; }
        public int Value { get; set; } // thuoc tinh khoa chinh ID_Lop
        public override string ToString()
        {
            return Text;
        }
    }
}
