
namespace MasterMech
{
    partial class UpdatePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePasswordForm));
            this.textBoxOldPwd = new System.Windows.Forms.TextBox();
            this.labelOldPwd = new System.Windows.Forms.Label();
            this.labelNewPwd = new System.Windows.Forms.Label();
            this.textBoxNewPwd = new System.Windows.Forms.TextBox();
            this.labelCPwd = new System.Windows.Forms.Label();
            this.textBoxCPwd = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelOldPwdError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNewPwdError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxOldPwd
            // 
            this.textBoxOldPwd.Location = new System.Drawing.Point(239, 28);
            this.textBoxOldPwd.Name = "textBoxOldPwd";
            this.textBoxOldPwd.Size = new System.Drawing.Size(280, 26);
            this.textBoxOldPwd.TabIndex = 0;
            this.textBoxOldPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOldPwd_KeyPress);
            this.textBoxOldPwd.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxOldPwd_Validating);
            // 
            // labelOldPwd
            // 
            this.labelOldPwd.AutoSize = true;
            this.labelOldPwd.Location = new System.Drawing.Point(33, 31);
            this.labelOldPwd.Name = "labelOldPwd";
            this.labelOldPwd.Size = new System.Drawing.Size(114, 20);
            this.labelOldPwd.TabIndex = 1;
            this.labelOldPwd.Text = "Old Password";
            // 
            // labelNewPwd
            // 
            this.labelNewPwd.AutoSize = true;
            this.labelNewPwd.Location = new System.Drawing.Point(33, 84);
            this.labelNewPwd.Name = "labelNewPwd";
            this.labelNewPwd.Size = new System.Drawing.Size(121, 20);
            this.labelNewPwd.TabIndex = 3;
            this.labelNewPwd.Text = "New Password";
            // 
            // textBoxNewPwd
            // 
            this.textBoxNewPwd.Location = new System.Drawing.Point(239, 81);
            this.textBoxNewPwd.Name = "textBoxNewPwd";
            this.textBoxNewPwd.Size = new System.Drawing.Size(280, 26);
            this.textBoxNewPwd.TabIndex = 2;
            this.textBoxNewPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewPwd_KeyPress);
            this.textBoxNewPwd.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNewPwd_Validating);
            // 
            // labelCPwd
            // 
            this.labelCPwd.AutoSize = true;
            this.labelCPwd.Location = new System.Drawing.Point(33, 139);
            this.labelCPwd.Name = "labelCPwd";
            this.labelCPwd.Size = new System.Drawing.Size(147, 20);
            this.labelCPwd.TabIndex = 5;
            this.labelCPwd.Text = "Confirm Password";
            // 
            // textBoxCPwd
            // 
            this.textBoxCPwd.Location = new System.Drawing.Point(239, 136);
            this.textBoxCPwd.Name = "textBoxCPwd";
            this.textBoxCPwd.Size = new System.Drawing.Size(280, 26);
            this.textBoxCPwd.TabIndex = 4;
            this.textBoxCPwd.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCPwd_Validating);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(264, 194);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(83, 28);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(406, 194);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelOldPwdError
            // 
            this.labelOldPwdError.AutoSize = true;
            this.labelOldPwdError.ForeColor = System.Drawing.Color.Red;
            this.labelOldPwdError.Location = new System.Drawing.Point(236, 58);
            this.labelOldPwdError.Name = "labelOldPwdError";
            this.labelOldPwdError.Size = new System.Drawing.Size(193, 20);
            this.labelOldPwdError.TabIndex = 8;
            this.labelOldPwdError.Text = "Enter Current Password.";
            this.labelOldPwdError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 9;
            // 
            // labelNewPwdError
            // 
            this.labelNewPwdError.AutoSize = true;
            this.labelNewPwdError.ForeColor = System.Drawing.Color.Red;
            this.labelNewPwdError.Location = new System.Drawing.Point(240, 166);
            this.labelNewPwdError.Name = "labelNewPwdError";
            this.labelNewPwdError.Size = new System.Drawing.Size(187, 20);
            this.labelNewPwdError.TabIndex = 10;
            this.labelNewPwdError.Text = "New Password is blank.";
            this.labelNewPwdError.Visible = false;
            // 
            // UpdatePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 244);
            this.Controls.Add(this.labelNewPwdError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelOldPwdError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCPwd);
            this.Controls.Add(this.textBoxCPwd);
            this.Controls.Add(this.labelNewPwd);
            this.Controls.Add(this.textBoxNewPwd);
            this.Controls.Add(this.labelOldPwd);
            this.Controls.Add(this.textBoxOldPwd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOldPwd;
        private System.Windows.Forms.Label labelOldPwd;
        private System.Windows.Forms.Label labelNewPwd;
        private System.Windows.Forms.TextBox textBoxNewPwd;
        private System.Windows.Forms.Label labelCPwd;
        private System.Windows.Forms.TextBox textBoxCPwd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelOldPwdError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNewPwdError;
    }
}