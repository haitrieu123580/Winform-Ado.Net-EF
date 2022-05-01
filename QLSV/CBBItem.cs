using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    // class nay được tạo ra để xử lý trường hợp
    // có 2 lớp cùng tên nhưng khác ID -> lấy ra các Item có khoá chính khác nhau
    // khi nhấn vào comboBox và lựa chọn Item -> chuyển SelectedItem đó thành (CBBItem) 
    // để lấy thuộc tính Value( khoá chính) và lấy Text 
    internal class CBBItem
    {
        public int Value { get; set; }   // thuộc tính khoá chính ( ID_Lop)
        public string Text {get; set;} // thuộc tính text hiển thị trên cbb ( ung voi phan Name trong comboBox)
        public override string ToString()
        {
            return Text;
        }
    }
}
