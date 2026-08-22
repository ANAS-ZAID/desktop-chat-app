using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.core.tools
{
    internal class Text:Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font = new System.Drawing.Font("Tahoma", 10F);
        }
    }
}
