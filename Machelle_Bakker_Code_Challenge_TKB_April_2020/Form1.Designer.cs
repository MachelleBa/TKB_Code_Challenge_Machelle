namespace Machelle_Bakker_Code_Challenge_TKB_April_2020
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
            this.lv_debtors = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_selected_file_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_debtors
            // 
            this.lv_debtors.HideSelection = false;
            this.lv_debtors.Location = new System.Drawing.Point(12, 129);
            this.lv_debtors.Name = "lv_debtors";
            this.lv_debtors.Size = new System.Drawing.Size(555, 297);
            this.lv_debtors.TabIndex = 0;
            this.lv_debtors.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select XML file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected File:";
            // 
            // lbl_selected_file_name
            // 
            this.lbl_selected_file_name.AutoSize = true;
            this.lbl_selected_file_name.Location = new System.Drawing.Point(111, 48);
            this.lbl_selected_file_name.Name = "lbl_selected_file_name";
            this.lbl_selected_file_name.Size = new System.Drawing.Size(48, 17);
            this.lbl_selected_file_name.TabIndex = 3;
            this.lbl_selected_file_name.Text = "          ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selected XML file content:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(298, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "Update database with current XML file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 538);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_selected_file_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_debtors);
            this.Name = "Form1";
            this.Text = "TKB Code Challenge - Machelle Bakker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_debtors;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_selected_file_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

