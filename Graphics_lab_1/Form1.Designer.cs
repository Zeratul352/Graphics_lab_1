namespace Graphics_lab_1
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TryDraw = new System.Windows.Forms.Button();
            this.DrawGrid = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.Ignore = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openfile = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Clear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Picture.Location = new System.Drawing.Point(13, 13);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(600, 600);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            this.Picture.Click += new System.EventHandler(this.Picture_Click);
            this.Picture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseClick);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TryDraw
            // 
            this.TryDraw.Location = new System.Drawing.Point(633, 133);
            this.TryDraw.Name = "TryDraw";
            this.TryDraw.Size = new System.Drawing.Size(126, 38);
            this.TryDraw.TabIndex = 1;
            this.TryDraw.Text = "Draw";
            this.TryDraw.UseVisualStyleBackColor = true;
            this.TryDraw.Click += new System.EventHandler(this.TryDraw_Click);
            // 
            // DrawGrid
            // 
            this.DrawGrid.Location = new System.Drawing.Point(633, 177);
            this.DrawGrid.Name = "DrawGrid";
            this.DrawGrid.Size = new System.Drawing.Size(126, 39);
            this.DrawGrid.TabIndex = 2;
            this.DrawGrid.Text = "Draw grid";
            this.DrawGrid.UseVisualStyleBackColor = true;
            this.DrawGrid.Click += new System.EventHandler(this.DrawGrid_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(633, 222);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(126, 37);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Nextiteration";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // Ignore
            // 
            this.Ignore.Location = new System.Drawing.Point(633, 265);
            this.Ignore.Name = "Ignore";
            this.Ignore.Size = new System.Drawing.Size(126, 36);
            this.Ignore.TabIndex = 4;
            this.Ignore.Text = "Ignore boarder";
            this.Ignore.UseVisualStyleBackColor = true;
            this.Ignore.Click += new System.EventHandler(this.Ignore_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(633, 307);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(126, 32);
            this.openfile.TabIndex = 5;
            this.openfile.Text = "Openrule";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(633, 389);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(126, 51);
            this.save.TabIndex = 6;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bmp";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(633, 345);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(126, 38);
            this.Clear.TabIndex = 7;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2",
            "3",
            "5",
            "6",
            "10",
            "15",
            "20",
            "30",
            "50",
            "100"});
            this.comboBox1.Location = new System.Drawing.Point(635, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(632, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pixels per square";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(631, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Iterations per tick";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "50",
            "100",
            "200",
            "300",
            "500",
            "1000"});
            this.comboBox2.Location = new System.Drawing.Point(635, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(124, 24);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(774, 633);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.save);
            this.Controls.Add(this.openfile);
            this.Controls.Add(this.Ignore);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.DrawGrid);
            this.Controls.Add(this.TryDraw);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button TryDraw;
        private System.Windows.Forms.Button DrawGrid;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button Ignore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

