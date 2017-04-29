using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalysisHypotheses
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3, 3) == "csv")
                    ImportAndExportFiles.ExportFile(saveFileDialog1.FileName, 1);
                else if(saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 4, 4) == "html")
                    ImportAndExportFiles.ExportFile(saveFileDialog1.FileName, 2);
                else
                    ImportAndExportFiles.ExportFile(saveFileDialog1.FileName, 3);
            }
        }
    }
}
