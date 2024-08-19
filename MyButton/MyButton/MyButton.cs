using System.Drawing.Drawing2D;

namespace MyButton
{
    internal class MyButton : Button
    {
        int c = 0;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            c++;
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
            pevent.Graphics.FillEllipse(new LinearGradientBrush(ClientRectangle,Color.Yellow,Color.WhiteSmoke,90f), ClientRectangle);
            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            pevent.Graphics.DrawString($"{c}x { Text}", SystemFonts.DefaultFont, Brushes.HotPink, ClientRectangle, sf);
        }
    }
}
