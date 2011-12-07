using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JM_Sistema_Prestamo
{
    public class AddValue
    {
        private string m_Display;
        private string m_Value;
        public AddValue(string Display, string  Value)
        {
            m_Display = Display;
            m_Value = Value;
        }
        public string Display
        {
            get { return m_Display; }
        }
        public string Value
        {
            get { return m_Value; }
        }
    }
}
