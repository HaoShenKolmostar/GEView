namespace GEView
{
    partial class GEView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.gwb_ge = new FC.GEPluginCtrls.GEWebBrowser();
            this.b_init = new System.Windows.Forms.Button();
            this.tb_lat = new System.Windows.Forms.TextBox();
            this.tb_lon = new System.Windows.Forms.TextBox();
            this.tb_alt = new System.Windows.Forms.TextBox();
            this.tb_head = new System.Windows.Forms.TextBox();
            this.tb_tilt = new System.Windows.Forms.TextBox();
            this.tb_roll = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.b_cap = new System.Windows.Forms.Button();
            this.tb_fov = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.b_csv = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.wb_gm = new System.Windows.Forms.WebBrowser();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.rb_equ = new System.Windows.Forms.RadioButton();
            this.rb_ortho = new System.Windows.Forms.RadioButton();
            this.pb_fish = new System.Windows.Forms.PictureBox();
            this.b_update = new System.Windows.Forms.Button();
            this.cb_line = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_ell = new System.Windows.Forms.RadioButton();
            this.rb_abs = new System.Windows.Forms.RadioButton();
            this.rb_rel = new System.Windows.Forms.RadioButton();
            this.cb_3D = new System.Windows.Forms.CheckBox();
            this.b_kml = new System.Windows.Forms.Button();
            this.openKmlDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fish)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gwb_ge
            // 
            this.gwb_ge.AllowNavigation = false;
            this.gwb_ge.ImageryBase = FC.GEPluginCtrls.ImageryBase.Earth;
            this.gwb_ge.IsWebBrowserContextMenuEnabled = false;
            this.gwb_ge.Location = new System.Drawing.Point(12, 12);
            this.gwb_ge.MinimumSize = new System.Drawing.Size(20, 20);
            this.gwb_ge.Name = "gwb_ge";
            this.gwb_ge.RedirectLinksToSystemBrowser = false;
            this.gwb_ge.ScrollBarsEnabled = false;
            this.gwb_ge.Size = new System.Drawing.Size(900, 900);
            this.gwb_ge.TabIndex = 0;
            this.gwb_ge.WebBrowserShortcutsEnabled = false;
            // 
            // b_init
            // 
            this.b_init.Enabled = false;
            this.b_init.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_init.Location = new System.Drawing.Point(1105, 923);
            this.b_init.Name = "b_init";
            this.b_init.Size = new System.Drawing.Size(55, 19);
            this.b_init.TabIndex = 1;
            this.b_init.Text = "init";
            this.b_init.UseVisualStyleBackColor = true;
            this.b_init.Click += new System.EventHandler(this.b_init_Click);
            // 
            // tb_lat
            // 
            this.tb_lat.Location = new System.Drawing.Point(32, 923);
            this.tb_lat.Name = "tb_lat";
            this.tb_lat.Size = new System.Drawing.Size(80, 19);
            this.tb_lat.TabIndex = 2;
            this.tb_lat.Text = "43.567073";
            // 
            // tb_lon
            // 
            this.tb_lon.Location = new System.Drawing.Point(139, 923);
            this.tb_lon.Name = "tb_lon";
            this.tb_lon.Size = new System.Drawing.Size(80, 19);
            this.tb_lon.TabIndex = 3;
            this.tb_lon.Text = "1.475306";
            // 
            // tb_alt
            // 
            this.tb_alt.Location = new System.Drawing.Point(242, 923);
            this.tb_alt.Name = "tb_alt";
            this.tb_alt.Size = new System.Drawing.Size(40, 19);
            this.tb_alt.TabIndex = 4;
            this.tb_alt.Text = "2.0";
            // 
            // tb_head
            // 
            this.tb_head.Location = new System.Drawing.Point(534, 922);
            this.tb_head.Name = "tb_head";
            this.tb_head.Size = new System.Drawing.Size(40, 19);
            this.tb_head.TabIndex = 5;
            this.tb_head.Text = "0.0";
            // 
            // tb_tilt
            // 
            this.tb_tilt.Location = new System.Drawing.Point(600, 922);
            this.tb_tilt.Name = "tb_tilt";
            this.tb_tilt.Size = new System.Drawing.Size(40, 19);
            this.tb_tilt.TabIndex = 6;
            this.tb_tilt.Text = "180.0";
            // 
            // tb_roll
            // 
            this.tb_roll.Location = new System.Drawing.Point(669, 922);
            this.tb_roll.Name = "tb_roll";
            this.tb_roll.Size = new System.Drawing.Size(40, 19);
            this.tb_roll.TabIndex = 7;
            this.tb_roll.Text = "0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 926);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(116, 926);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(222, 926);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Alt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(488, 925);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Heading:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(577, 925);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tilt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(643, 925);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Roll:";
            // 
            // b_cap
            // 
            this.b_cap.Enabled = false;
            this.b_cap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_cap.Location = new System.Drawing.Point(1163, 923);
            this.b_cap.Name = "b_cap";
            this.b_cap.Size = new System.Drawing.Size(55, 19);
            this.b_cap.TabIndex = 20;
            this.b_cap.Text = "capture";
            this.b_cap.UseVisualStyleBackColor = true;
            this.b_cap.Click += new System.EventHandler(this.b_cap_Click);
            // 
            // tb_fov
            // 
            this.tb_fov.Enabled = false;
            this.tb_fov.Location = new System.Drawing.Point(745, 922);
            this.tb_fov.Name = "tb_fov";
            this.tb_fov.Size = new System.Drawing.Size(50, 19);
            this.tb_fov.TabIndex = 18;
            this.tb_fov.Text = "160.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(714, 925);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "FOV:";
            // 
            // b_csv
            // 
            this.b_csv.Enabled = false;
            this.b_csv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_csv.Location = new System.Drawing.Point(1279, 923);
            this.b_csv.Name = "b_csv";
            this.b_csv.Size = new System.Drawing.Size(55, 19);
            this.b_csv.TabIndex = 21;
            this.b_csv.Text = "csv";
            this.b_csv.UseVisualStyleBackColor = true;
            this.b_csv.Click += new System.EventHandler(this.b_csv_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "csv file (*.csv)|*.csv|All files (*.*)|*.*\"";
            // 
            // wb_gm
            // 
            this.wb_gm.AllowWebBrowserDrop = false;
            this.wb_gm.Location = new System.Drawing.Point(928, 489);
            this.wb_gm.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_gm.Name = "wb_gm";
            this.wb_gm.ScrollBarsEnabled = false;
            this.wb_gm.Size = new System.Drawing.Size(460, 423);
            this.wb_gm.TabIndex = 25;
            this.wb_gm.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "jpeg file (*.jpg)|*.jpg";
            // 
            // rb_equ
            // 
            this.rb_equ.AutoSize = true;
            this.rb_equ.Checked = true;
            this.rb_equ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_equ.Location = new System.Drawing.Point(802, 923);
            this.rb_equ.Name = "rb_equ";
            this.rb_equ.Size = new System.Drawing.Size(80, 16);
            this.rb_equ.TabIndex = 26;
            this.rb_equ.TabStop = true;
            this.rb_equ.Text = "Equidistant";
            this.rb_equ.UseVisualStyleBackColor = true;
            this.rb_equ.CheckedChanged += new System.EventHandler(this.rb_equ_CheckedChanged);
            // 
            // rb_ortho
            // 
            this.rb_ortho.AutoSize = true;
            this.rb_ortho.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_ortho.Location = new System.Drawing.Point(882, 923);
            this.rb_ortho.Name = "rb_ortho";
            this.rb_ortho.Size = new System.Drawing.Size(92, 16);
            this.rb_ortho.TabIndex = 27;
            this.rb_ortho.Text = "Orthographic ";
            this.rb_ortho.UseVisualStyleBackColor = true;
            this.rb_ortho.CheckedChanged += new System.EventHandler(this.rb_ortho_CheckedChanged);
            // 
            // pb_fish
            // 
            this.pb_fish.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pb_fish.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pb_fish.Location = new System.Drawing.Point(928, 12);
            this.pb_fish.Name = "pb_fish";
            this.pb_fish.Size = new System.Drawing.Size(460, 460);
            this.pb_fish.TabIndex = 24;
            this.pb_fish.TabStop = false;
            // 
            // b_update
            // 
            this.b_update.Enabled = false;
            this.b_update.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_update.Location = new System.Drawing.Point(1221, 923);
            this.b_update.Name = "b_update";
            this.b_update.Size = new System.Drawing.Size(55, 19);
            this.b_update.TabIndex = 28;
            this.b_update.Text = "update";
            this.b_update.UseVisualStyleBackColor = true;
            this.b_update.Click += new System.EventHandler(this.b_update_Click);
            // 
            // cb_line
            // 
            this.cb_line.AutoSize = true;
            this.cb_line.Location = new System.Drawing.Point(970, 924);
            this.cb_line.Name = "cb_line";
            this.cb_line.Size = new System.Drawing.Size(94, 16);
            this.cb_line.TabIndex = 29;
            this.cb_line.Text = "Elevation plot";
            this.cb_line.UseVisualStyleBackColor = true;
            this.cb_line.CheckedChanged += new System.EventHandler(this.cb_line_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ell);
            this.panel1.Controls.Add(this.rb_abs);
            this.panel1.Controls.Add(this.rb_rel);
            this.panel1.Location = new System.Drawing.Point(286, 923);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 17);
            this.panel1.TabIndex = 33;
            // 
            // rb_ell
            // 
            this.rb_ell.AutoSize = true;
            this.rb_ell.Enabled = false;
            this.rb_ell.Location = new System.Drawing.Point(134, 0);
            this.rb_ell.Name = "rb_ell";
            this.rb_ell.Size = new System.Drawing.Size(66, 16);
            this.rb_ell.TabIndex = 35;
            this.rb_ell.Text = "Ellipsoid";
            this.rb_ell.UseVisualStyleBackColor = true;
            this.rb_ell.CheckedChanged += new System.EventHandler(this.rb_ell_CheckedChanged);
            // 
            // rb_abs
            // 
            this.rb_abs.AutoSize = true;
            this.rb_abs.Enabled = false;
            this.rb_abs.Location = new System.Drawing.Point(67, 0);
            this.rb_abs.Name = "rb_abs";
            this.rb_abs.Size = new System.Drawing.Size(68, 16);
            this.rb_abs.TabIndex = 34;
            this.rb_abs.Text = "Absolute";
            this.rb_abs.UseVisualStyleBackColor = true;
            this.rb_abs.CheckedChanged += new System.EventHandler(this.rb_abs_CheckedChanged);
            // 
            // rb_rel
            // 
            this.rb_rel.AutoSize = true;
            this.rb_rel.Checked = true;
            this.rb_rel.Enabled = false;
            this.rb_rel.Location = new System.Drawing.Point(2, 0);
            this.rb_rel.Name = "rb_rel";
            this.rb_rel.Size = new System.Drawing.Size(65, 16);
            this.rb_rel.TabIndex = 33;
            this.rb_rel.TabStop = true;
            this.rb_rel.Text = "Relative";
            this.rb_rel.UseVisualStyleBackColor = true;
            this.rb_rel.CheckedChanged += new System.EventHandler(this.rb_rel_CheckedChanged);
            // 
            // cb_3D
            // 
            this.cb_3D.AutoSize = true;
            this.cb_3D.Checked = true;
            this.cb_3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_3D.Location = new System.Drawing.Point(1065, 924);
            this.cb_3D.Name = "cb_3D";
            this.cb_3D.Size = new System.Drawing.Size(38, 16);
            this.cb_3D.TabIndex = 34;
            this.cb_3D.Text = "3D";
            this.cb_3D.UseVisualStyleBackColor = true;
            this.cb_3D.CheckedChanged += new System.EventHandler(this.cb_3D_CheckedChanged);
            // 
            // b_kml
            // 
            this.b_kml.Enabled = false;
            this.b_kml.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_kml.Location = new System.Drawing.Point(1337, 923);
            this.b_kml.Name = "b_kml";
            this.b_kml.Size = new System.Drawing.Size(55, 19);
            this.b_kml.TabIndex = 35;
            this.b_kml.Text = "kml";
            this.b_kml.UseVisualStyleBackColor = true;
            this.b_kml.Click += new System.EventHandler(this.b_kml_Click);
            // 
            // openKmlDialog
            // 
            this.openKmlDialog.Filter = "kml/kmz file (*.kml;*.kmz)|*.kml;*.kmz|All files (*.*)|*.*\"";
            this.openKmlDialog.Title = "Select Kml/Kmz file";
            // 
            // GEView
            // 
            this.ClientSize = new System.Drawing.Size(1400, 947);
            this.Controls.Add(this.b_kml);
            this.Controls.Add(this.cb_3D);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cb_line);
            this.Controls.Add(this.b_update);
            this.Controls.Add(this.rb_ortho);
            this.Controls.Add(this.rb_equ);
            this.Controls.Add(this.wb_gm);
            this.Controls.Add(this.pb_fish);
            this.Controls.Add(this.b_csv);
            this.Controls.Add(this.b_cap);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_fov);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_roll);
            this.Controls.Add(this.tb_tilt);
            this.Controls.Add(this.tb_head);
            this.Controls.Add(this.tb_alt);
            this.Controls.Add(this.tb_lon);
            this.Controls.Add(this.tb_lat);
            this.Controls.Add(this.b_init);
            this.Controls.Add(this.gwb_ge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GEView";
            this.Text = "GEView";
            ((System.ComponentModel.ISupportInitialize)(this.pb_fish)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FC.GEPluginCtrls.GEWebBrowser gwb_ge;
        private System.Windows.Forms.Button b_init;
        private System.Windows.Forms.TextBox tb_lat;
        private System.Windows.Forms.TextBox tb_lon;
        private System.Windows.Forms.TextBox tb_alt;
        private System.Windows.Forms.TextBox tb_head;
        private System.Windows.Forms.TextBox tb_tilt;
        private System.Windows.Forms.TextBox tb_roll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_cap;
        private System.Windows.Forms.TextBox tb_fov;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button b_csv;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pb_fish;
        private System.Windows.Forms.WebBrowser wb_gm;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton rb_equ;
        private System.Windows.Forms.RadioButton rb_ortho;
        private System.Windows.Forms.Button b_update;
        private System.Windows.Forms.CheckBox cb_line;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_ell;
        private System.Windows.Forms.RadioButton rb_abs;
        private System.Windows.Forms.RadioButton rb_rel;
        private System.Windows.Forms.CheckBox cb_3D;
        private System.Windows.Forms.Button b_kml;
        private System.Windows.Forms.OpenFileDialog openKmlDialog;
    }
}

