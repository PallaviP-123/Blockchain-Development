namespace First_App
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
            this.label1 = new System.Windows.Forms.Label();
            this.enterbox = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.fd = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ENTER TEXT TO BE STORED";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // enterbox
            // 
            this.enterbox.Location = new System.Drawing.Point(227, 106);
            this.enterbox.Name = "enterbox";
            this.enterbox.Size = new System.Drawing.Size(529, 22);
            this.enterbox.TabIndex = 1;
            this.enterbox.TextChanged += new System.EventHandler(this.enterbox_TextChanged);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(375, 159);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "SUBMIT";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(608, 166);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(312, 205);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(216, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "See Transaction On Block Explorer";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "FLODATA ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fd
            // 
            this.fd.Location = new System.Drawing.Point(227, 250);
            this.fd.Multiline = true;
            this.fd.Name = "fd";
            this.fd.Size = new System.Drawing.Size(529, 120);
            this.fd.TabIndex = 8;
            this.fd.TextChanged += new System.EventHandler(this.flodata_TextChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(375, 399);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(87, 23);
            this.search.TabIndex = 9;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.search);
            this.Controls.Add(this.fd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.enterbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Adding Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox enterbox;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fd;
        private System.Windows.Forms.Button search;
    }
}

