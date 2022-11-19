using System.Drawing;
using System.Windows.Forms;

namespace Luna_s_Simulator
{
    public class NewProgressBar : ProgressBar
    {
        private Brush _Color = Brushes.Green;
        public NewProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        //Метод принимает Brush, и меняет на него цвет прогресс бара
        public void ChangeColor (Brush Color) => _Color = Color;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(_Color, 2, 2, rec.Width, rec.Height);
        }
    }
}
