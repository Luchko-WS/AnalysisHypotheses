using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalysisHypotheses
{
    public partial class Histogram : Form
    {
        public Histogram()
        {
            InitializeComponent();
        }

        private void Histogram_Paint(object sender, PaintEventArgs e)
        {
            Font fnt = new Font("Times New Roman", 10, FontStyle.Bold);
            var N = Row.GetCount() + 2;

            var max = 0;
            for (var i = 0; i < Row.GetCount(); i++)
                if (Row.GetByIndex(i).n > max) max = Row.GetByIndex(i).n;
            max++;

            var dx = Width / N;
            var dy = (Height - 50) / max;

            for (var i = 0; i < Row.GetCount(); i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 1),
                    dx / 2, dy * (max - Row.GetByIndex(i).n),
                    (N - 1) * dx, dy * (max - Row.GetByIndex(i).n));
            }

            Font fnt2 = new Font("Times New Roman", 10, FontStyle.Bold);
            for (var i = 0; i < Row.GetCount(); i++)
            {
                e.Graphics.FillRectangle(Brushes.Silver, dx + dx * i,
                   dy * (max - Row.GetByIndex(i).n),
                   dx, dy * Row.GetByIndex(i).n);
                e.Graphics.DrawString(Convert.ToString(Row.GetByIndex(i).n), fnt2,
                   Brushes.Black, dx / 2, dy * (max - Row.GetByIndex(i).n));
                e.Graphics.DrawRectangle(new Pen(Color.Black, 2), dx + dx * i,
                    dy * (max - Row.GetByIndex(i).n),
                    dx, dy * Row.GetByIndex(i).n);
                e.Graphics.DrawString(Convert.ToString(Row.GetByIndex(i).x), fnt2,
                    Brushes.Black, dx / 2 + dx + dx * i, dy * (max - Row.GetByIndex(i).n) + dy * Row.GetByIndex(i).n);
            }

            Invalidate();
        }
    }
}
