namespace Farsight
{
    partial class mainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainScreen));
            this.summonerAccountsComboBox = new System.Windows.Forms.ComboBox();
            this.addNewSummonerButton = new System.Windows.Forms.Button();
            this.addMatchHistoryButton = new System.Windows.Forms.Button();
            this.activeGameButton = new System.Windows.Forms.Button();
            this.matchHistoryFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.summonerInfoPanel = new System.Windows.Forms.Panel();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.clientStatusLabel = new System.Windows.Forms.Label();
            this.clientStatusButton = new System.Windows.Forms.Button();
            this.runePagesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // summonerAccountsComboBox
            // 
            this.summonerAccountsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summonerAccountsComboBox.FormattingEnabled = true;
            this.summonerAccountsComboBox.Location = new System.Drawing.Point(0, 40);
            this.summonerAccountsComboBox.Name = "summonerAccountsComboBox";
            this.summonerAccountsComboBox.Size = new System.Drawing.Size(184, 28);
            this.summonerAccountsComboBox.TabIndex = 0;
            this.summonerAccountsComboBox.Text = "Choose Account";
            // 
            // addNewSummonerButton
            // 
            this.addNewSummonerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewSummonerButton.Location = new System.Drawing.Point(0, 216);
            this.addNewSummonerButton.Name = "addNewSummonerButton";
            this.addNewSummonerButton.Size = new System.Drawing.Size(184, 28);
            this.addNewSummonerButton.TabIndex = 1;
            this.addNewSummonerButton.Text = "Add New Summoner";
            this.addNewSummonerButton.UseVisualStyleBackColor = true;
            this.addNewSummonerButton.Click += new System.EventHandler(this.addNewSummonerButton_Click);
            // 
            // addMatchHistoryButton
            // 
            this.addMatchHistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addMatchHistoryButton.Location = new System.Drawing.Point(0, 250);
            this.addMatchHistoryButton.Name = "addMatchHistoryButton";
            this.addMatchHistoryButton.Size = new System.Drawing.Size(184, 29);
            this.addMatchHistoryButton.TabIndex = 2;
            this.addMatchHistoryButton.Text = "Match History";
            this.addMatchHistoryButton.UseVisualStyleBackColor = true;
            this.addMatchHistoryButton.Click += new System.EventHandler(this.addMatchHistoryButton_Click);
            // 
            // activeGameButton
            // 
            this.activeGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.activeGameButton.Location = new System.Drawing.Point(0, 285);
            this.activeGameButton.Name = "activeGameButton";
            this.activeGameButton.Size = new System.Drawing.Size(184, 31);
            this.activeGameButton.TabIndex = 3;
            this.activeGameButton.Text = "Active Game";
            this.activeGameButton.UseVisualStyleBackColor = true;
            this.activeGameButton.Click += new System.EventHandler(this.activeGameButton_Click);
            // 
            // matchHistoryFlowLayoutPanel
            // 
            this.matchHistoryFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(67)))));
            this.matchHistoryFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matchHistoryFlowLayoutPanel.Location = new System.Drawing.Point(392, 0);
            this.matchHistoryFlowLayoutPanel.Name = "matchHistoryFlowLayoutPanel";
            this.matchHistoryFlowLayoutPanel.Size = new System.Drawing.Size(979, 688);
            this.matchHistoryFlowLayoutPanel.TabIndex = 4;
            // 
            // summonerInfoPanel
            // 
            this.summonerInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.summonerInfoPanel.Location = new System.Drawing.Point(184, 0);
            this.summonerInfoPanel.Name = "summonerInfoPanel";
            this.summonerInfoPanel.Size = new System.Drawing.Size(208, 696);
            this.summonerInfoPanel.TabIndex = 5;
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.programNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programNameLabel.ForeColor = System.Drawing.Color.White;
            this.programNameLabel.Location = new System.Drawing.Point(0, 0);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(184, 39);
            this.programNameLabel.TabIndex = 6;
            this.programNameLabel.Text = "Farsight    ";
            // 
            // clientStatusLabel
            // 
            this.clientStatusLabel.AutoSize = true;
            this.clientStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientStatusLabel.ForeColor = System.Drawing.Color.White;
            this.clientStatusLabel.Location = new System.Drawing.Point(16, 112);
            this.clientStatusLabel.Name = "clientStatusLabel";
            this.clientStatusLabel.Size = new System.Drawing.Size(75, 29);
            this.clientStatusLabel.TabIndex = 7;
            this.clientStatusLabel.Text = "Client";
            this.clientStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clientStatusButton
            // 
            this.clientStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientStatusButton.Location = new System.Drawing.Point(0, 144);
            this.clientStatusButton.Name = "clientStatusButton";
            this.clientStatusButton.Size = new System.Drawing.Size(184, 32);
            this.clientStatusButton.TabIndex = 8;
            this.clientStatusButton.Text = "Get Client Status";
            this.clientStatusButton.UseVisualStyleBackColor = true;
            this.clientStatusButton.Click += new System.EventHandler(this.clientStatusButton_Click);
            // 
            // runePagesButton
            // 
            this.runePagesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.runePagesButton.Location = new System.Drawing.Point(1, 321);
            this.runePagesButton.Name = "runePagesButton";
            this.runePagesButton.Size = new System.Drawing.Size(184, 31);
            this.runePagesButton.TabIndex = 9;
            this.runePagesButton.Text = "Rune Page Editor";
            this.runePagesButton.UseVisualStyleBackColor = true;
            this.runePagesButton.Click += new System.EventHandler(this.runePagesButton_Click);
            // 
            // mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1372, 688);
            this.Controls.Add(this.runePagesButton);
            this.Controls.Add(this.clientStatusButton);
            this.Controls.Add(this.clientStatusLabel);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.summonerInfoPanel);
            this.Controls.Add(this.matchHistoryFlowLayoutPanel);
            this.Controls.Add(this.activeGameButton);
            this.Controls.Add(this.addMatchHistoryButton);
            this.Controls.Add(this.addNewSummonerButton);
            this.Controls.Add(this.summonerAccountsComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainScreen";
            this.Text = "mainScreen";
            this.Load += new System.EventHandler(this.mainScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox summonerAccountsComboBox;
        private System.Windows.Forms.Button addNewSummonerButton;
        private System.Windows.Forms.Button addMatchHistoryButton;
        private System.Windows.Forms.Button activeGameButton;
        private System.Windows.Forms.FlowLayoutPanel matchHistoryFlowLayoutPanel;
        public System.Windows.Forms.Panel summonerInfoPanel;
        private System.Windows.Forms.Label programNameLabel;
        public System.Windows.Forms.Label clientStatusLabel;
        public System.Windows.Forms.Button clientStatusButton;
        private System.Windows.Forms.Button runePagesButton;
    }
}