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
            this.tspbLoader = new System.Windows.Forms.ToolStripProgressBar();
            this.lblConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.miLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.hallgatókToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCourseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCourseBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiApplicationForExam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSemesters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTeacherCourseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateExams = new System.Windows.Forms.ToolStripMenuItem();
            this.kurzusinformációkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminisztrátorokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminUniversities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminExams = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminForums = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlOwnHighlightedItemContainer = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbLoader,
            this.lblConnectionState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspbLoader
            // 
            this.tspbLoader.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbLoader.Name = "tspbLoader";
            this.tspbLoader.Size = new System.Drawing.Size(100, 16);
            this.tspbLoader.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspbLoader.Visible = false;
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
            this.hallgatókToolStripMenuItem,
            this.tsmiTeacherCourseInfo,
            this.adminisztrátorokToolStripMenuItem,
            this.tsmRefresh});
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
            this.miLogout,
            this.tsmiOptions,
            this.tsmiExit});
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
            // tsmiOptions
            // 
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(144, 22);
            this.tsmiOptions.Text = "Beállítások";
            this.tsmiOptions.Click += new System.EventHandler(this.tsmiOptions_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(144, 22);
            this.tsmiExit.Text = "Kilépés";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // hallgatókToolStripMenuItem
            // 
            this.hallgatókToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCourseInfo,
            this.tsmiCourseBooking,
            this.tsmiApplicationForExam,
            this.tsmiSemesters});
            this.hallgatókToolStripMenuItem.Name = "hallgatókToolStripMenuItem";
            this.hallgatókToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.hallgatókToolStripMenuItem.Text = "Hallgatók";
            // 
            // tsmiCourseInfo
            // 
            this.tsmiCourseInfo.Name = "tsmiCourseInfo";
            this.tsmiCourseInfo.Size = new System.Drawing.Size(177, 22);
            this.tsmiCourseInfo.Text = "Kurzusinformáció";
            // 
            // tsmiCourseBooking
            // 
            this.tsmiCourseBooking.Name = "tsmiCourseBooking";
            this.tsmiCourseBooking.Size = new System.Drawing.Size(177, 22);
            this.tsmiCourseBooking.Text = "Kurzusfelvétel";
            // 
            // tsmiApplicationForExam
            // 
            this.tsmiApplicationForExam.Name = "tsmiApplicationForExam";
            this.tsmiApplicationForExam.Size = new System.Drawing.Size(177, 22);
            this.tsmiApplicationForExam.Text = "Vizsgára jelentkezés";
            // 
            // tsmiSemesters
            // 
            this.tsmiSemesters.Name = "tsmiSemesters";
            this.tsmiSemesters.Size = new System.Drawing.Size(177, 22);
            this.tsmiSemesters.Text = "Félévek";
            // 
            // tsmiTeacherCourseInfo
            // 
            this.tsmiTeacherCourseInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateCourses,
            this.tsmiCreateExams,
            this.kurzusinformációkToolStripMenuItem});
            this.tsmiTeacherCourseInfo.Name = "tsmiTeacherCourseInfo";
            this.tsmiTeacherCourseInfo.Size = new System.Drawing.Size(61, 20);
            this.tsmiTeacherCourseInfo.Text = "Oktatók";
            // 
            // tsmiCreateCourses
            // 
            this.tsmiCreateCourses.Name = "tsmiCreateCourses";
            this.tsmiCreateCourses.Size = new System.Drawing.Size(197, 22);
            this.tsmiCreateCourses.Text = "Kurzusok meghirdetése";
            // 
            // tsmiCreateExams
            // 
            this.tsmiCreateExams.Name = "tsmiCreateExams";
            this.tsmiCreateExams.Size = new System.Drawing.Size(197, 22);
            this.tsmiCreateExams.Text = "Vizsgák";
            // 
            // kurzusinformációkToolStripMenuItem
            // 
            this.kurzusinformációkToolStripMenuItem.Name = "kurzusinformációkToolStripMenuItem";
            this.kurzusinformációkToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.kurzusinformációkToolStripMenuItem.Text = "Kurzusinformációk";
            // 
            // adminisztrátorokToolStripMenuItem
            // 
            this.adminisztrátorokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdminUniversities,
            this.tsmiAdminCourses,
            this.tsmiAdminExams,
            this.tsmiAdminForums,
            this.tsmiAdminUsers,
            this.tsmiLogging});
            this.adminisztrátorokToolStripMenuItem.Name = "adminisztrátorokToolStripMenuItem";
            this.adminisztrátorokToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.adminisztrátorokToolStripMenuItem.Text = "Adminisztrátorok";
            // 
            // tsmiAdminUniversities
            // 
            this.tsmiAdminUniversities.Name = "tsmiAdminUniversities";
            this.tsmiAdminUniversities.Size = new System.Drawing.Size(152, 22);
            this.tsmiAdminUniversities.Text = "Képzések";
            this.tsmiAdminUniversities.Click += new System.EventHandler(this.tsmiAdminUniversities_Click);
            // 
            // tsmiAdminCourses
            // 
            this.tsmiAdminCourses.Name = "tsmiAdminCourses";
            this.tsmiAdminCourses.Size = new System.Drawing.Size(152, 22);
            this.tsmiAdminCourses.Text = "Kurzusok";
            // 
            // tsmiAdminExams
            // 
            this.tsmiAdminExams.Name = "tsmiAdminExams";
            this.tsmiAdminExams.Size = new System.Drawing.Size(152, 22);
            this.tsmiAdminExams.Text = "Vizsgák";
            // 
            // tsmiAdminForums
            // 
            this.tsmiAdminForums.Name = "tsmiAdminForums";
            this.tsmiAdminForums.Size = new System.Drawing.Size(152, 22);
            this.tsmiAdminForums.Text = "Fórumok";
            // 
            // tsmiAdminUsers
            // 
            this.tsmiAdminUsers.Name = "tsmiAdminUsers";
            this.tsmiAdminUsers.Size = new System.Drawing.Size(152, 22);
            this.tsmiAdminUsers.Text = "Felhasználók";
            this.tsmiAdminUsers.Click += new System.EventHandler(this.tsmiAdminUsers_Click);
            // 
            // tsmiLogging
            // 
            this.tsmiLogging.Name = "tsmiLogging";
            this.tsmiLogging.Size = new System.Drawing.Size(152, 22);
            this.tsmiLogging.Text = "Naplózás";
            this.tsmiLogging.Click += new System.EventHandler(this.tsmiLogging_Click);
            // 
            // tsmRefresh
            // 
            this.tsmRefresh.Name = "tsmRefresh";
            this.tsmRefresh.Size = new System.Drawing.Size(60, 20);
            this.tsmRefresh.Text = "Frissítés";
            this.tsmRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // pnlOwnHighlightedItemContainer
            // 
            this.pnlOwnHighlightedItemContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOwnHighlightedItemContainer.Location = new System.Drawing.Point(12, 27);
            this.pnlOwnHighlightedItemContainer.Name = "pnlOwnHighlightedItemContainer";
            this.pnlOwnHighlightedItemContainer.Size = new System.Drawing.Size(571, 334);
            this.pnlOwnHighlightedItemContainer.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 386);
            this.Controls.Add(this.pnlOwnHighlightedItemContainer);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem hallgatókToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCourseInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCourseBooking;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplicationForExam;
        private System.Windows.Forms.ToolStripMenuItem tsmiSemesters;
        private System.Windows.Forms.ToolStripMenuItem tsmiTeacherCourseInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateCourses;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateExams;
        private System.Windows.Forms.ToolStripMenuItem kurzusinformációkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminisztrátorokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminUniversities;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminCourses;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminExams;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminForums;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminUsers;
        private System.Windows.Forms.Panel pnlOwnHighlightedItemContainer;
        private System.Windows.Forms.ToolStripMenuItem tsmRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogging;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripProgressBar tspbLoader;


    }
}