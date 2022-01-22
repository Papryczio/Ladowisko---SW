namespace Ladowisko
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.picture_ori_det = new System.Windows.Forms.PictureBox();
            this.picture_ori = new System.Windows.Forms.PictureBox();
            this.button_From_File_PB1 = new System.Windows.Forms.Button();
            this.button_Browse_Files_PB1 = new System.Windows.Forms.Button();
            this.textBox_Image_Path_PB1 = new System.Windows.Forms.TextBox();
            this.button_Czysc = new System.Windows.Forms.Button();
            this.button_detect = new System.Windows.Forms.Button();
            this.picture_post_det = new System.Windows.Forms.PictureBox();
            this.picture_post = new System.Windows.Forms.PictureBox();
            this.listView_pos = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_cameraJPG = new System.Windows.Forms.Button();
            this.button_cameraMovie = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button_lowPass = new System.Windows.Forms.Button();
            this.button_threshold = new System.Windows.Forms.Button();
            this.button_highPass = new System.Windows.Forms.Button();
            this.button_erode = new System.Windows.Forms.Button();
            this.button_dilate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_param1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_blockSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picture_post_sur = new System.Windows.Forms.PictureBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.picture_sur = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_ori_det)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_ori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_post_det)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_post)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_blockSize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_post_sur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_sur)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_ori_det
            // 
            this.picture_ori_det.BackColor = System.Drawing.Color.Black;
            this.picture_ori_det.Location = new System.Drawing.Point(0, 547);
            this.picture_ori_det.Name = "picture_ori_det";
            this.picture_ori_det.Size = new System.Drawing.Size(640, 360);
            this.picture_ori_det.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_ori_det.TabIndex = 50;
            this.picture_ori_det.TabStop = false;
            // 
            // picture_ori
            // 
            this.picture_ori.BackColor = System.Drawing.Color.Black;
            this.picture_ori.Location = new System.Drawing.Point(3, 130);
            this.picture_ori.Name = "picture_ori";
            this.picture_ori.Size = new System.Drawing.Size(640, 360);
            this.picture_ori.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_ori.TabIndex = 49;
            this.picture_ori.TabStop = false;
            this.picture_ori.Click += new System.EventHandler(this.picture_ori_Click);
            // 
            // button_From_File_PB1
            // 
            this.button_From_File_PB1.Location = new System.Drawing.Point(3, 31);
            this.button_From_File_PB1.Name = "button_From_File_PB1";
            this.button_From_File_PB1.Size = new System.Drawing.Size(93, 22);
            this.button_From_File_PB1.TabIndex = 51;
            this.button_From_File_PB1.Text = "Z pliku";
            this.button_From_File_PB1.UseVisualStyleBackColor = true;
            this.button_From_File_PB1.Click += new System.EventHandler(this.button_From_File_PB1_Click);
            // 
            // button_Browse_Files_PB1
            // 
            this.button_Browse_Files_PB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Browse_Files_PB1.Location = new System.Drawing.Point(251, 3);
            this.button_Browse_Files_PB1.Name = "button_Browse_Files_PB1";
            this.button_Browse_Files_PB1.Size = new System.Drawing.Size(28, 20);
            this.button_Browse_Files_PB1.TabIndex = 54;
            this.button_Browse_Files_PB1.Text = "...";
            this.button_Browse_Files_PB1.UseVisualStyleBackColor = true;
            this.button_Browse_Files_PB1.Click += new System.EventHandler(this.button_Browse_Files_PB1_Click);
            // 
            // textBox_Image_Path_PB1
            // 
            this.textBox_Image_Path_PB1.Location = new System.Drawing.Point(3, 3);
            this.textBox_Image_Path_PB1.Name = "textBox_Image_Path_PB1";
            this.textBox_Image_Path_PB1.Size = new System.Drawing.Size(247, 20);
            this.textBox_Image_Path_PB1.TabIndex = 53;
            this.textBox_Image_Path_PB1.Text = "C:\\Users\\patri\\Desktop\\testy_wizyjne\\hard.png";
            // 
            // button_Czysc
            // 
            this.button_Czysc.Location = new System.Drawing.Point(0, 0);
            this.button_Czysc.Name = "button_Czysc";
            this.button_Czysc.Size = new System.Drawing.Size(75, 23);
            this.button_Czysc.TabIndex = 0;
            // 
            // button_detect
            // 
            this.button_detect.Location = new System.Drawing.Point(993, 10);
            this.button_detect.Name = "button_detect";
            this.button_detect.Size = new System.Drawing.Size(75, 23);
            this.button_detect.TabIndex = 56;
            this.button_detect.Text = "Detect";
            this.button_detect.UseVisualStyleBackColor = true;
            this.button_detect.Click += new System.EventHandler(this.button_detect_Click);
            // 
            // picture_post_det
            // 
            this.picture_post_det.BackColor = System.Drawing.Color.Black;
            this.picture_post_det.Location = new System.Drawing.Point(900, 547);
            this.picture_post_det.Name = "picture_post_det";
            this.picture_post_det.Size = new System.Drawing.Size(640, 360);
            this.picture_post_det.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_post_det.TabIndex = 57;
            this.picture_post_det.TabStop = false;
            // 
            // picture_post
            // 
            this.picture_post.BackColor = System.Drawing.Color.Black;
            this.picture_post.Location = new System.Drawing.Point(900, 130);
            this.picture_post.Name = "picture_post";
            this.picture_post.Size = new System.Drawing.Size(640, 360);
            this.picture_post.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_post.TabIndex = 58;
            this.picture_post.TabStop = false;
            this.picture_post.Click += new System.EventHandler(this.picture_post_Click);
            // 
            // listView_pos
            // 
            this.listView_pos.HideSelection = false;
            this.listView_pos.Location = new System.Drawing.Point(664, 146);
            this.listView_pos.Name = "listView_pos";
            this.listView_pos.Size = new System.Drawing.Size(215, 138);
            this.listView_pos.TabIndex = 62;
            this.listView_pos.UseCompatibleStateImageBehavior = false;
            this.listView_pos.View = System.Windows.Forms.View.List;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
            // 
            // button_cameraJPG
            // 
            this.button_cameraJPG.Location = new System.Drawing.Point(184, 30);
            this.button_cameraJPG.Name = "button_cameraJPG";
            this.button_cameraJPG.Size = new System.Drawing.Size(95, 23);
            this.button_cameraJPG.TabIndex = 65;
            this.button_cameraJPG.Text = "Z kamery (jpg)";
            this.button_cameraJPG.UseVisualStyleBackColor = true;
            this.button_cameraJPG.Click += new System.EventHandler(this.button_cameraJPG_Click);
            // 
            // button_cameraMovie
            // 
            this.button_cameraMovie.Location = new System.Drawing.Point(184, 57);
            this.button_cameraMovie.Name = "button_cameraMovie";
            this.button_cameraMovie.Size = new System.Drawing.Size(95, 23);
            this.button_cameraMovie.TabIndex = 66;
            this.button_cameraMovie.Text = "Nagranie";
            this.button_cameraMovie.UseVisualStyleBackColor = true;
            this.button_cameraMovie.Click += new System.EventHandler(this.button_cameraMovie_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(664, 393);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(215, 97);
            this.listView1.TabIndex = 72;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(664, 290);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(215, 97);
            this.listView2.TabIndex = 73;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // button_lowPass
            // 
            this.button_lowPass.Location = new System.Drawing.Point(6, 22);
            this.button_lowPass.Name = "button_lowPass";
            this.button_lowPass.Size = new System.Drawing.Size(75, 23);
            this.button_lowPass.TabIndex = 74;
            this.button_lowPass.Text = "low-pass";
            this.button_lowPass.UseVisualStyleBackColor = true;
            this.button_lowPass.Click += new System.EventHandler(this.button_lowPass_Click);
            // 
            // button_threshold
            // 
            this.button_threshold.Location = new System.Drawing.Point(201, 48);
            this.button_threshold.Name = "button_threshold";
            this.button_threshold.Size = new System.Drawing.Size(75, 23);
            this.button_threshold.TabIndex = 75;
            this.button_threshold.Text = "Threshold";
            this.button_threshold.UseVisualStyleBackColor = true;
            this.button_threshold.Click += new System.EventHandler(this.button_threshold_Click);
            // 
            // button_highPass
            // 
            this.button_highPass.Location = new System.Drawing.Point(134, 22);
            this.button_highPass.Name = "button_highPass";
            this.button_highPass.Size = new System.Drawing.Size(75, 23);
            this.button_highPass.TabIndex = 76;
            this.button_highPass.Text = "high-pass";
            this.button_highPass.UseVisualStyleBackColor = true;
            this.button_highPass.Click += new System.EventHandler(this.button_highPass_Click);
            // 
            // button_erode
            // 
            this.button_erode.Location = new System.Drawing.Point(6, 71);
            this.button_erode.Name = "button_erode";
            this.button_erode.Size = new System.Drawing.Size(75, 23);
            this.button_erode.TabIndex = 77;
            this.button_erode.Text = "Erode";
            this.button_erode.UseVisualStyleBackColor = true;
            this.button_erode.Click += new System.EventHandler(this.button_erode_Click);
            // 
            // button_dilate
            // 
            this.button_dilate.Location = new System.Drawing.Point(134, 71);
            this.button_dilate.Name = "button_dilate";
            this.button_dilate.Size = new System.Drawing.Size(75, 23);
            this.button_dilate.TabIndex = 78;
            this.button_dilate.Text = "Dilate";
            this.button_dilate.UseVisualStyleBackColor = true;
            this.button_dilate.Click += new System.EventHandler(this.button_dilate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_erode);
            this.groupBox2.Controls.Add(this.button_dilate);
            this.groupBox2.Controls.Add(this.button_highPass);
            this.groupBox2.Controls.Add(this.button_lowPass);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox2.Location = new System.Drawing.Point(664, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 100);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operacje";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown_param1);
            this.groupBox3.Controls.Add(this.numericUpDown_blockSize);
            this.groupBox3.Controls.Add(this.button_threshold);
            this.groupBox3.Location = new System.Drawing.Point(318, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 77);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Threshold";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 79;
            this.label8.Text = "param1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Block Size";
            // 
            // numericUpDown_param1
            // 
            this.numericUpDown_param1.Location = new System.Drawing.Point(75, 51);
            this.numericUpDown_param1.Name = "numericUpDown_param1";
            this.numericUpDown_param1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_param1.TabIndex = 77;
            this.numericUpDown_param1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown_blockSize
            // 
            this.numericUpDown_blockSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_blockSize.Location = new System.Drawing.Point(75, 22);
            this.numericUpDown_blockSize.Maximum = new decimal(new int[] {
            501,
            0,
            0,
            0});
            this.numericUpDown_blockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_blockSize.Name = "numericUpDown_blockSize";
            this.numericUpDown_blockSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_blockSize.TabIndex = 76;
            this.numericUpDown_blockSize.Value = new decimal(new int[] {
            81,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Obraz oryginalny";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(907, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Obraz po obróbce";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Obraz oryginalny z wykrytym lądowiskiem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(907, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Obraz po obróbce z wykrytym lądowiskiem";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.picture_post_sur);
            this.panel1.Controls.Add(this.listView3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.picture_sur);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.picture_ori_det);
            this.panel1.Controls.Add(this.button_detect);
            this.panel1.Controls.Add(this.picture_post_det);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Image_Path_PB1);
            this.panel1.Controls.Add(this.picture_post);
            this.panel1.Controls.Add(this.button_From_File_PB1);
            this.panel1.Controls.Add(this.button_Browse_Files_PB1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_cameraJPG);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.picture_ori);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.listView_pos);
            this.panel1.Controls.Add(this.button_cameraMovie);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 981);
            this.panel1.TabIndex = 87;
            // 
            // picture_post_sur
            // 
            this.picture_post_sur.BackColor = System.Drawing.Color.Black;
            this.picture_post_sur.Location = new System.Drawing.Point(900, 956);
            this.picture_post_sur.Name = "picture_post_sur";
            this.picture_post_sur.Size = new System.Drawing.Size(640, 360);
            this.picture_post_sur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_post_sur.TabIndex = 91;
            this.picture_post_sur.TabStop = false;
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(670, 1275);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(215, 97);
            this.listView3.TabIndex = 90;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.List;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(661, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Pozycja względem środka:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 940);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "Wycinek obrazu dookoła objektu";
            // 
            // picture_sur
            // 
            this.picture_sur.BackColor = System.Drawing.Color.Black;
            this.picture_sur.Location = new System.Drawing.Point(0, 956);
            this.picture_sur.Name = "picture_sur";
            this.picture_sur.Size = new System.Drawing.Size(640, 360);
            this.picture_sur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_sur.TabIndex = 86;
            this.picture_sur.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(897, 940);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(295, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "Wycinek obrazu dookoła objektu po binaryzacji adaptacyjnej";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 981);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Projekt - Lądowisko";
            ((System.ComponentModel.ISupportInitialize)(this.picture_ori_det)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_ori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_post_det)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_post)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_blockSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_post_sur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_sur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_ori_det;
        private System.Windows.Forms.PictureBox picture_ori;
        private System.Windows.Forms.Button button_From_File_PB1;
        private System.Windows.Forms.Button button_Browse_Files_PB1;
        private System.Windows.Forms.TextBox textBox_Image_Path_PB1;
        private System.Windows.Forms.Button button_Czysc;
        private System.Windows.Forms.Button button_detect;
        private System.Windows.Forms.PictureBox picture_post_det;
        private System.Windows.Forms.PictureBox picture_post;
        private System.Windows.Forms.ListView listView_pos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_cameraJPG;
        private System.Windows.Forms.Button button_cameraMovie;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button_lowPass;
        private System.Windows.Forms.Button button_threshold;
        private System.Windows.Forms.Button button_highPass;
        private System.Windows.Forms.Button button_erode;
        private System.Windows.Forms.Button button_dilate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown_param1;
        private System.Windows.Forms.NumericUpDown numericUpDown_blockSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picture_sur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.PictureBox picture_post_sur;
        private System.Windows.Forms.Label label9;
    }
}

