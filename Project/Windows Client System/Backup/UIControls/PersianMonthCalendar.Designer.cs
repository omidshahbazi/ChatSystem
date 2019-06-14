namespace BinarySoftCo.UIControls
{
    partial class PersianMonthCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersianMonthCalendar));
            this.lSat = new System.Windows.Forms.Label();
            this.lSun = new System.Windows.Forms.Label();
            this.lMon = new System.Windows.Forms.Label();
            this.LThu = new System.Windows.Forms.Label();
            this.lWen = new System.Windows.Forms.Label();
            this.lTur = new System.Windows.Forms.Label();
            this.lFri = new System.Windows.Forms.Label();
            this.lSpliter = new System.Windows.Forms.Label();
            this.pDays = new System.Windows.Forms.Panel();
            this.pallToday = new BinarySoftCo.UIControls.PersianActiveLinkLabel();
            this.pallMonthYear = new BinarySoftCo.UIControls.PersianActiveLinkLabel();
            this.pallBackMonth = new BinarySoftCo.UIControls.PersianActiveLinkLabel();
            this.pallNextMonth = new BinarySoftCo.UIControls.PersianActiveLinkLabel();
            this.SuspendLayout();
            // 
            // lSat
            // 
            resources.ApplyResources(this.lSat, "lSat");
            this.lSat.Name = "lSat";
            // 
            // lSun
            // 
            resources.ApplyResources(this.lSun, "lSun");
            this.lSun.Name = "lSun";
            // 
            // lMon
            // 
            resources.ApplyResources(this.lMon, "lMon");
            this.lMon.Name = "lMon";
            // 
            // LThu
            // 
            resources.ApplyResources(this.LThu, "LThu");
            this.LThu.Name = "LThu";
            // 
            // lWen
            // 
            resources.ApplyResources(this.lWen, "lWen");
            this.lWen.Name = "lWen";
            // 
            // lTur
            // 
            resources.ApplyResources(this.lTur, "lTur");
            this.lTur.Name = "lTur";
            // 
            // lFri
            // 
            resources.ApplyResources(this.lFri, "lFri");
            this.lFri.ForeColor = System.Drawing.Color.Red;
            this.lFri.Name = "lFri";
            // 
            // lSpliter
            // 
            resources.ApplyResources(this.lSpliter, "lSpliter");
            this.lSpliter.ForeColor = System.Drawing.Color.DarkGray;
            this.lSpliter.Name = "lSpliter";
            // 
            // pDays
            // 
            resources.ApplyResources(this.pDays, "pDays");
            this.pDays.Name = "pDays";
            // 
            // pallToday
            // 
            this.pallToday.ActiveColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pallToday, "pallToday");
            this.pallToday.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.pallToday.LinkColor = System.Drawing.Color.Black;
            this.pallToday.Name = "pallToday";
            this.pallToday.TabStop = true;
            this.pallToday.Tag = "{0} : امروز";
            this.pallToday.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pallToday_LinkClicked);
            // 
            // pallMonthYear
            // 
            this.pallMonthYear.ActiveColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pallMonthYear, "pallMonthYear");
            this.pallMonthYear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.pallMonthYear.LinkColor = System.Drawing.Color.Black;
            this.pallMonthYear.Name = "pallMonthYear";
            this.pallMonthYear.TabStop = true;
            this.pallMonthYear.Tag = "{1} ,{0}";
            this.pallMonthYear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pallMonthYear_LinkClicked);
            // 
            // pallBackMonth
            // 
            this.pallBackMonth.ActiveColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pallBackMonth, "pallBackMonth");
            this.pallBackMonth.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.pallBackMonth.LinkColor = System.Drawing.Color.Black;
            this.pallBackMonth.Name = "pallBackMonth";
            this.pallBackMonth.TabStop = true;
            this.pallBackMonth.Tag = "";
            this.pallBackMonth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pallBackMonth_MouseClick);
            // 
            // pallNextMonth
            // 
            this.pallNextMonth.ActiveColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pallNextMonth, "pallNextMonth");
            this.pallNextMonth.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.pallNextMonth.LinkColor = System.Drawing.Color.Black;
            this.pallNextMonth.Name = "pallNextMonth";
            this.pallNextMonth.TabStop = true;
            this.pallNextMonth.Tag = "";
            this.pallNextMonth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pallNextMonth_MouseClick);
            // 
            // PersianMonthCalendar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pallToday);
            this.Controls.Add(this.pDays);
            this.Controls.Add(this.lSat);
            this.Controls.Add(this.lFri);
            this.Controls.Add(this.lTur);
            this.Controls.Add(this.lWen);
            this.Controls.Add(this.LThu);
            this.Controls.Add(this.lMon);
            this.Controls.Add(this.lSun);
            this.Controls.Add(this.lSpliter);
            this.Controls.Add(this.pallMonthYear);
            this.Controls.Add(this.pallBackMonth);
            this.Controls.Add(this.pallNextMonth);
            this.Name = "PersianMonthCalendar";
            this.Load += new System.EventHandler(this.PersianMonthCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSat;
        private System.Windows.Forms.Label lSun;
        private System.Windows.Forms.Label lMon;
        private System.Windows.Forms.Label LThu;
        private System.Windows.Forms.Label lWen;
        private System.Windows.Forms.Label lTur;
        private System.Windows.Forms.Label lFri;
        private System.Windows.Forms.Label lSpliter;
        private System.Windows.Forms.Panel pDays;
        private PersianActiveLinkLabel pallMonthYear;
        private PersianActiveLinkLabel pallBackMonth;
        private PersianActiveLinkLabel pallNextMonth;
        private PersianActiveLinkLabel pallToday;
    }
}
