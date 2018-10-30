namespace rightClick
{
    partial class Option
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbxSprint = new System.Windows.Forms.CheckBox();
            this.cbxGeneric = new System.Windows.Forms.CheckBox();
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDirectory = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(651, 71);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 35);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbxSprint
            // 
            this.cbxSprint.AutoSize = true;
            this.cbxSprint.Location = new System.Drawing.Point(340, 45);
            this.cbxSprint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSprint.Name = "cbxSprint";
            this.cbxSprint.Size = new System.Drawing.Size(199, 24);
            this.cbxSprint.TabIndex = 1;
            this.cbxSprint.Text = "Create Sprint Structure";
            this.cbxSprint.UseVisualStyleBackColor = true;
            // 
            // cbxGeneric
            // 
            this.cbxGeneric.AutoSize = true;
            this.cbxGeneric.Checked = true;
            this.cbxGeneric.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGeneric.Location = new System.Drawing.Point(549, 45);
            this.cbxGeneric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxGeneric.Name = "cbxGeneric";
            this.cbxGeneric.Size = new System.Drawing.Size(213, 24);
            this.cbxGeneric.TabIndex = 2;
            this.cbxGeneric.Text = "Create Generic Structure";
            this.cbxGeneric.UseVisualStyleBackColor = true;
            // 
            // cbxMonth
            // 
            this.cbxMonth.AutoCompleteCustomSource.AddRange(new string[] {
            "January",
            "February",
            "Marh",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbxMonth.Location = new System.Drawing.Point(24, 45);
            this.cbxMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(306, 28);
            this.cbxMonth.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Next Release";
            // 
            // cbxDirectory
            // 
            this.cbxDirectory.AutoSize = true;
            this.cbxDirectory.Location = new System.Drawing.Point(340, 80);
            this.cbxDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDirectory.Name = "cbxDirectory";
            this.cbxDirectory.Size = new System.Drawing.Size(182, 24);
            this.cbxDirectory.TabIndex = 5;
            this.cbxDirectory.Text = "Create Directory Info";
            this.cbxDirectory.UseVisualStyleBackColor = true;
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 134);
            this.Controls.Add(this.cbxDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMonth);
            this.Controls.Add(this.cbxGeneric);
            this.Controls.Add(this.cbxSprint);
            this.Controls.Add(this.btnCreate);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Option";
            this.Text = "Option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox cbxSprint;
        private System.Windows.Forms.CheckBox cbxGeneric;
        private System.Windows.Forms.ComboBox cbxMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxDirectory;
    }
}