
namespace EntityFrameworkTest
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.dgvUsersInGroup = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 12);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(300, 278);
            this.dgvUsers.TabIndex = 0;
            // 
            // dgvGroups
            // 
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(346, 12);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(300, 278);
            this.dgvGroups.TabIndex = 1;
            this.dgvGroups.SelectionChanged += new System.EventHandler(this.dgvGroups_SelectionChanged);
            // 
            // dgvUsersInGroup
            // 
            this.dgvUsersInGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersInGroup.Location = new System.Drawing.Point(691, 12);
            this.dgvUsersInGroup.Name = "dgvUsersInGroup";
            this.dgvUsersInGroup.Size = new System.Drawing.Size(300, 278);
            this.dgvUsersInGroup.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvUsersInGroup);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.dgvUsers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.DataGridView dgvUsersInGroup;
        private System.Windows.Forms.Button button1;
    }
}

