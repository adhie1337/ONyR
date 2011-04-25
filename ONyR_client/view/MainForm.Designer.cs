namespace ONyR_client.view
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.miLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.kurzusokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionState
            // 
            this.lblConnectionState.Name = "lblConnectionState";
            this.lblConnectionState.Size = new System.Drawing.Size(93, 17);
            this.lblConnectionState.Text = "Nincs kapcsolat.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.kurzusokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLogin,
            this.miLogout});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&Fájl";
            // 
            // miLogin
            // 
            this.miLogin.Name = "miLogin";
            this.miLogin.Size = new System.Drawing.Size(144, 22);
            this.miLogin.Text = "&Bejelentkezés";
            this.miLogin.Click += new System.EventHandler(this.miLogin_Click);
            // 
            // miLogout
            // 
            this.miLogout.Enabled = false;
            this.miLogout.Name = "miLogout";
            this.miLogout.Size = new System.Drawing.Size(144, 22);
            this.miLogout.Text = "&Kijelentkezés";
            this.miLogout.Click += new System.EventHandler(this.miLogout_Click);
            // 
            // kurzusokToolStripMenuItem
            // 
            this.kurzusokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowCourses});
            this.kurzusokToolStripMenuItem.Name = "kurzusokToolStripMenuItem";
            this.kurzusokToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.kurzusokToolStripMenuItem.Text = "Kurzusok";
            // 
            // miShowCourses
            // 
            this.miShowCourses.Name = "miShowCourses";
            this.miShowCourses.Size = new System.Drawing.Size(198, 22);
            this.miShowCourses.Text = "Kurzusok megjelenítése";
            this.miShowCourses.Click += new System.EventHandler(this.miShowCourses_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 386);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Oktatási Nyilvántartó Rendszer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionState;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miLogin;
        private System.Windows.Forms.ToolStripMenuItem miLogout;
        private System.Windows.Forms.ToolStripMenuItem kurzusokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miShowCourses;


    }
}