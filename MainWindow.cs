using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnalysisHypotheses
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Додання інтервальних величин
            if (checkBoxIntervalOrDiscret.Checked)
            {
                try
                {
                    Convert.ToDouble(textBoxA.Text);
                    Convert.ToDouble(textBoxB.Text);
                    Convert.ToDouble(textBoxN.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Вводіть числові значення (напр. -6,5) і не залишайте поля порожніми!\n", "Помилка!");
                    return;
                }

                if (Convert.ToDouble(textBoxA.Text) == Convert.ToDouble(textBoxB.Text))
                {
                    MessageBox.Show("Межі проміжку не можуть співпадати!\n", "Помилка");
                    return;
                }
                else if ((Convert.ToDouble(textBoxA.Text) < 0 || Convert.ToDouble(textBoxB.Text) < 0) && !radioButtonNormalLaw.Checked)
                {
                    MessageBox.Show("Межі проміжку не можуть мати від'ємні значення!\n", "Помилка");
                    return;
                }

                try
                {
                    Row.AddToRow(new IntervalVariant(Convert.ToDouble(textBoxA.Text), Convert.ToDouble(textBoxB.Text), Convert.ToInt32(textBoxN.Text)));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "Помилка");
                    return;
                }  
                
                listBoxRow.Items.Add("(" + textBoxA.Text + "; " + textBoxB.Text + ")   |   ni = " + textBoxN.Text);

                if (checkBoxAutoFill.Checked)
                {
                    double delta = Convert.ToDouble(textBoxB.Text) - Convert.ToDouble(textBoxA.Text);
                    textBoxA.Text = textBoxB.Text;
                    delta = Convert.ToDouble(textBoxA.Text) + delta;
                    textBoxB.Text = delta.ToString();
                    textBoxN.Clear();
                }
                else
                {
                    textBoxA.Clear();
                    textBoxB.Clear();
                    textBoxN.Clear();
                }                
            }
            //Додання дискретних величин
            else
            {
                try
                {
                    Convert.ToDouble(textBoxB.Text);
                    Convert.ToDouble(textBoxN.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Вводіть числові значення (напр. -6,5) і не залишайте поля порожніми!\n", "Помилка!");
                    return;
                }
                
                if (Convert.ToDouble(textBoxB.Text) < 0 && !radioButtonNormalLaw.Checked)
                {
                    MessageBox.Show("Межі проміжку не можуть мати від'ємні значення!\n", "Помилка");
                    return;
                }
                    
                try
                {
                    Row.AddToRow(new IntervalVariant(Convert.ToDouble(textBoxB.Text), Convert.ToDouble(textBoxB.Text), Convert.ToInt32(textBoxN.Text)));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "Помилка");
                }

                listBoxRow.Items.Add(textBoxB.Text + "   |   ni = " + textBoxN.Text);

                textBoxA.Clear();
                textBoxB.Clear();
                textBoxN.Clear();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Row.RemoveAt(listBoxRow.SelectedIndex);
            listBoxRow.Items.RemoveAt(listBoxRow.SelectedIndex);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxA.Clear();
            textBoxB.Clear();
            textBoxN.Clear();
            comboBoxAlpha.Text = "";
            listBoxRow.Items.Clear();
            Row.ClearRow();
        }

        private void buttonDrawHistogram_Click(object sender, EventArgs e)
        {
            if (listBoxRow.Items.Count == 0)
            {
                MessageBox.Show("Заповність усі значення!", "Помилка");
                return;
            }

            var hist = new Histogram();
            hist.Show();
        }       

        private void buttonShowResult_Click(object sender, EventArgs e)
        {
            if (listBoxRow.Items.Count == 0 || comboBoxAlpha.Text == "")
            {
                MessageBox.Show("Заповність усі значення!", "Помилка");
                return;
            }

            Row.SetAlpha(Convert.ToDouble(comboBoxAlpha.Text));

            if (radioButtonNormalLaw.Checked)
                Row.CheckNormalLaw();
            else
                Row.CheckPuassonLaw();

            var view = new Viewer();
            view.webBrowser1.Navigate(Directory.GetCurrentDirectory() + "/tmp/htmlFile.html");
            view.Show();
        }

        private void checkBoxIntervalOrDiscret_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxIntervalOrDiscret.Checked)
            {
                textBoxA.Visible = true;
                checkBoxAutoFill.Enabled = true;
                label2.Visible = true;
                label3.Text = "Кінець інтервалу:";
            }
            else
            {
                textBoxA.Visible = false;
                checkBoxAutoFill.Enabled = false;
                label2.Visible = false;
                label3.Text = "Значення варіанти:";
            }
        }

        private void buttonImportData_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonClear_Click(sender, e);

                using (var fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                {
                    ImportAndExportFiles.ImportFile(fs);

                    for (var i = 0; i < Row.GetCount(); i++)
                    {
                        if (Row.GetByIndex(i).a != Row.GetByIndex(i).b)
                            listBoxRow.Items.Add("(" + Row.GetByIndex(i).a + "; " + Row.GetByIndex(i).b + ")   |   ni = " + Row.GetByIndex(i).n);
                        else
                            listBoxRow.Items.Add(Row.GetByIndex(i).a + "   |   ni = " + Row.GetByIndex(i).n);
                    }
                }
            }
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBoxB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBoxN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void comboBoxAlpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 45 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void IntervalRow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
