using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.core.tools
{
    internal class AppSidBarButton:AppButton
    {
        Panel Panel;
        private bool _active {  get; set; }=false;
        public bool active { get => _active; set { 
            
            _active = value;

                Panel.Visible=value;

            } }
       public AppSidBarButton() {
            Size = new Size(67, 51);
            Text = "";
            buildPanel();
            SizeChanged += (s, e) => updateLocationPanel();

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
         

        }
        private void buildPanel()
        {
          
            Panel = new Panel() { BackColor=Color.LimeGreen, Visible=active};
            Controls.Add(Panel);
            updateLocationPanel();
        }
        private void updateLocationPanel()
        {
            int w = 4;
            int h = Height / 2;
            int x = Width - w - 4;
            int y = (Height - h) / 2;
            //Location = new Point(x, y), Width = w, BackColor = Color.Aqua, Height = h,
            Panel.Location = new Point(x, y);
            Panel.Size = new Size(w, h);
        }
    }
}
