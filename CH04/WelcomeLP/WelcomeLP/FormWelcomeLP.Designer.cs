namespace WelcomeLP
{
    partial class WelcomeLP
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelFlameTelemetry = new System.Windows.Forms.Label();
            this.labelFlameSensor = new System.Windows.Forms.Label();
            this.buttonLEDSW = new System.Windows.Forms.Button();
            this.labelLEDSW = new System.Windows.Forms.Label();
            this.labelDashboard = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.12546F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.87454F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4984F));
            this.tableLayoutPanelMain.Controls.Add(this.labelFlameSensor, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelLEDSW, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonLEDSW, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonStart, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelFlameTelemetry, 2, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(88, 109);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(5256, 151);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelFlameTelemetry
            // 
            this.labelFlameTelemetry.AutoSize = true;
            this.labelFlameTelemetry.Location = new System.Drawing.Point(273, 75);
            this.labelFlameTelemetry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFlameTelemetry.Name = "labelFlameTelemetry";
            this.labelFlameTelemetry.Size = new System.Drawing.Size(49, 13);
            this.labelFlameTelemetry.TabIndex = 3;
            this.labelFlameTelemetry.Text = "telemetry";
            // 
            // labelFlameSensor
            // 
            this.labelFlameSensor.AutoSize = true;
            this.labelFlameSensor.Location = new System.Drawing.Point(2, 75);
            this.labelFlameSensor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFlameSensor.Name = "labelFlameSensor";
            this.labelFlameSensor.Size = new System.Drawing.Size(71, 13);
            this.labelFlameSensor.TabIndex = 1;
            this.labelFlameSensor.Text = "Flame Sensor";
            this.labelFlameSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLEDSW
            // 
            this.buttonLEDSW.Location = new System.Drawing.Point(127, 3);
            this.buttonLEDSW.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonLEDSW.Name = "buttonLEDSW";
            this.buttonLEDSW.Size = new System.Drawing.Size(56, 20);
            this.buttonLEDSW.TabIndex = 2;
            this.buttonLEDSW.Text = "0/ 1";
            this.buttonLEDSW.UseVisualStyleBackColor = true;
            this.buttonLEDSW.Click += new System.EventHandler(this.buttonLEDSW_Click);
            // 
            // labelLEDSW
            // 
            this.labelLEDSW.AutoSize = true;
            this.labelLEDSW.Location = new System.Drawing.Point(2, 0);
            this.labelLEDSW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLEDSW.Name = "labelLEDSW";
            this.labelLEDSW.Size = new System.Drawing.Size(63, 13);
            this.labelLEDSW.TabIndex = 0;
            this.labelLEDSW.Text = "LED Switch";
            this.labelLEDSW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDashboard.Location = new System.Drawing.Point(80, 36);
            this.labelDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(227, 48);
            this.labelDashboard.TabIndex = 1;
            this.labelDashboard.Text = "Dashboard";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(127, 78);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(56, 20);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // WelcomeLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 305);
            this.Controls.Add(this.labelDashboard);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "WelcomeLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome LP　　　Powered by Ted好玩";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelLEDSW;
        private System.Windows.Forms.Label labelFlameSensor;
        private System.Windows.Forms.Button buttonLEDSW;
        private System.Windows.Forms.Label labelFlameTelemetry;
        private System.Windows.Forms.Label labelDashboard;
        private System.Windows.Forms.Button buttonStart;
    }
}

