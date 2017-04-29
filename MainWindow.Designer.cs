namespace AnalysisHypotheses
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxRow = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonShowResult = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxAlpha = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDrawHistogram = new System.Windows.Forms.Button();
            this.radioButtonNormalLaw = new System.Windows.Forms.RadioButton();
            this.radioButtonPuassonLaw = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxAutoFill = new System.Windows.Forms.CheckBox();
            this.checkBoxIntervalOrDiscret = new System.Windows.Forms.CheckBox();
            this.buttonImportData = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listBoxRow
            // 
            this.listBoxRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxRow.FormattingEnabled = true;
            this.listBoxRow.ItemHeight = 16;
            this.listBoxRow.Location = new System.Drawing.Point(323, 51);
            this.listBoxRow.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxRow.Name = "listBoxRow";
            this.listBoxRow.Size = new System.Drawing.Size(315, 260);
            this.listBoxRow.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(269, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введіть дані";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Початок інтервалу:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(36, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кінець інтервалу:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(87, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Частота:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(61, 145);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 28);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Додати";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonShowResult
            // 
            this.buttonShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowResult.Location = new System.Drawing.Point(107, 366);
            this.buttonShowResult.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowResult.Name = "buttonShowResult";
            this.buttonShowResult.Size = new System.Drawing.Size(100, 28);
            this.buttonShowResult.TabIndex = 6;
            this.buttonShowResult.Text = "Перевірити";
            this.buttonShowResult.UseVisualStyleBackColor = true;
            this.buttonShowResult.Click += new System.EventHandler(this.buttonShowResult_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(522, 366);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 28);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Очистити";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxA
            // 
            this.textBoxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxA.Location = new System.Drawing.Point(169, 55);
            this.textBoxA.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(132, 22);
            this.textBoxA.TabIndex = 0;
            this.textBoxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxA_KeyPress);
            // 
            // textBoxB
            // 
            this.textBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxB.Location = new System.Drawing.Point(169, 85);
            this.textBoxB.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(132, 22);
            this.textBoxB.TabIndex = 1;
            this.textBoxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxB_KeyPress);
            // 
            // textBoxN
            // 
            this.textBoxN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxN.Location = new System.Drawing.Point(168, 115);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(132, 22);
            this.textBoxN.TabIndex = 2;
            this.textBoxN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxN_KeyPress);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(169, 145);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 28);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Видалити";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBoxAlpha
            // 
            this.comboBoxAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAlpha.Items.AddRange(new object[] {
            "0,01",
            "0,025",
            "0,05",
            "0,1",
            "0,25",
            "0,5",
            "0,75",
            "0,9",
            "0,95",
            "0,975",
            "0,99"});
            this.comboBoxAlpha.Location = new System.Drawing.Point(168, 251);
            this.comboBoxAlpha.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAlpha.Name = "comboBoxAlpha";
            this.comboBoxAlpha.Size = new System.Drawing.Size(132, 24);
            this.comboBoxAlpha.TabIndex = 5;
            this.comboBoxAlpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxAlpha_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Рівень значущості (альфа):";
            // 
            // buttonDrawHistogram
            // 
            this.buttonDrawHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrawHistogram.Location = new System.Drawing.Point(342, 366);
            this.buttonDrawHistogram.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDrawHistogram.Name = "buttonDrawHistogram";
            this.buttonDrawHistogram.Size = new System.Drawing.Size(172, 28);
            this.buttonDrawHistogram.TabIndex = 7;
            this.buttonDrawHistogram.Text = "Побудувати гістограму";
            this.buttonDrawHistogram.UseVisualStyleBackColor = true;
            this.buttonDrawHistogram.Click += new System.EventHandler(this.buttonDrawHistogram_Click);
            // 
            // radioButtonNormalLaw
            // 
            this.radioButtonNormalLaw.AutoSize = true;
            this.radioButtonNormalLaw.Checked = true;
            this.radioButtonNormalLaw.Location = new System.Drawing.Point(90, 301);
            this.radioButtonNormalLaw.Name = "radioButtonNormalLaw";
            this.radioButtonNormalLaw.Size = new System.Drawing.Size(148, 20);
            this.radioButtonNormalLaw.TabIndex = 11;
            this.radioButtonNormalLaw.TabStop = true;
            this.radioButtonNormalLaw.Text = "нормальний закон";
            this.radioButtonNormalLaw.UseVisualStyleBackColor = true;
            // 
            // radioButtonPuassonLaw
            // 
            this.radioButtonPuassonLaw.AutoSize = true;
            this.radioButtonPuassonLaw.Location = new System.Drawing.Point(90, 327);
            this.radioButtonPuassonLaw.Name = "radioButtonPuassonLaw";
            this.radioButtonPuassonLaw.Size = new System.Drawing.Size(132, 20);
            this.radioButtonPuassonLaw.TabIndex = 11;
            this.radioButtonPuassonLaw.Text = "закон Пуассона";
            this.radioButtonPuassonLaw.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(24, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Закон розподілу:";
            // 
            // checkBoxAutoFill
            // 
            this.checkBoxAutoFill.AutoSize = true;
            this.checkBoxAutoFill.Location = new System.Drawing.Point(47, 180);
            this.checkBoxAutoFill.Name = "checkBoxAutoFill";
            this.checkBoxAutoFill.Size = new System.Drawing.Size(238, 20);
            this.checkBoxAutoFill.TabIndex = 12;
            this.checkBoxAutoFill.Text = "автозаповнення меж інтервалів";
            this.checkBoxAutoFill.UseVisualStyleBackColor = true;
            // 
            // checkBoxIntervalOrDiscret
            // 
            this.checkBoxIntervalOrDiscret.AutoSize = true;
            this.checkBoxIntervalOrDiscret.Checked = true;
            this.checkBoxIntervalOrDiscret.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIntervalOrDiscret.Location = new System.Drawing.Point(47, 204);
            this.checkBoxIntervalOrDiscret.Name = "checkBoxIntervalOrDiscret";
            this.checkBoxIntervalOrDiscret.Size = new System.Drawing.Size(170, 20);
            this.checkBoxIntervalOrDiscret.TabIndex = 12;
            this.checkBoxIntervalOrDiscret.Text = "інтервальні величини";
            this.checkBoxIntervalOrDiscret.UseVisualStyleBackColor = true;
            this.checkBoxIntervalOrDiscret.CheckedChanged += new System.EventHandler(this.checkBoxIntervalOrDiscret_CheckedChanged);
            // 
            // buttonImportData
            // 
            this.buttonImportData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImportData.Location = new System.Drawing.Point(323, 317);
            this.buttonImportData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonImportData.Name = "buttonImportData";
            this.buttonImportData.Size = new System.Drawing.Size(315, 28);
            this.buttonImportData.TabIndex = 7;
            this.buttonImportData.Text = "Імпортувати дані з файлу...";
            this.buttonImportData.UseVisualStyleBackColor = true;
            this.buttonImportData.Click += new System.EventHandler(this.buttonImportData_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CSV-файли|*.csv|Текстові файли |*.txt|Усі файли|*.*";
            this.openFileDialog1.Title = "Відкриття файлу...";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 415);
            this.Controls.Add(this.checkBoxIntervalOrDiscret);
            this.Controls.Add(this.checkBoxAutoFill);
            this.Controls.Add(this.radioButtonPuassonLaw);
            this.Controls.Add(this.radioButtonNormalLaw);
            this.Controls.Add(this.comboBoxAlpha);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.buttonDrawHistogram);
            this.Controls.Add(this.buttonImportData);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonShowResult);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxRow);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевірка статистичних гіпотез";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IntervalRow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonShowResult;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxAlpha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDrawHistogram;
        private System.Windows.Forms.RadioButton radioButtonNormalLaw;
        private System.Windows.Forms.RadioButton radioButtonPuassonLaw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxAutoFill;
        private System.Windows.Forms.CheckBox checkBoxIntervalOrDiscret;
        private System.Windows.Forms.Button buttonImportData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}