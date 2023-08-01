
namespace MasterMech
{
    partial class UserAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountForm));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelMno = new System.Windows.Forms.Label();
            this.textBoxMno = new System.Windows.Forms.TextBox();
            this.labelEid = new System.Windows.Forms.Label();
            this.textBoxEid = new System.Windows.Forms.TextBox();
            this.labelUserType = new System.Windows.Forms.Label();
            this.textBoxUserType = new System.Windows.Forms.TextBox();
            this.labelLL = new System.Windows.Forms.Label();
            this.textBoxLL = new System.Windows.Forms.TextBox();
            this.labelLPC = new System.Windows.Forms.Label();
            this.textBoxLPC = new System.Windows.Forms.TextBox();
            this.labelCreated = new System.Windows.Forms.Label();
            this.textBoxCreated = new System.Windows.Forms.TextBox();
            this.labelCreatedBy = new System.Windows.Forms.Label();
            this.textBoxCreatedBy = new System.Windows.Forms.TextBox();
            this.labelModified = new System.Windows.Forms.Label();
            this.textBoxModified = new System.Windows.Forms.TextBox();
            this.labelModifiedBy = new System.Windows.Forms.Label();
            this.textBoxModifiedBy = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelMnoError = new System.Windows.Forms.Label();
            this.labelEidErrorMsg = new System.Windows.Forms.Label();
            this.labelNameError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(287, 28);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(252, 24);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxName_Validating);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(58, 34);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(84, 18);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "User Name";
            // 
            // labelMno
            // 
            this.labelMno.AutoSize = true;
            this.labelMno.Location = new System.Drawing.Point(58, 82);
            this.labelMno.Name = "labelMno";
            this.labelMno.Size = new System.Drawing.Size(80, 18);
            this.labelMno.TabIndex = 5;
            this.labelMno.Text = "Mobile No.";
            // 
            // textBoxMno
            // 
            this.textBoxMno.Location = new System.Drawing.Point(287, 76);
            this.textBoxMno.Name = "textBoxMno";
            this.textBoxMno.Size = new System.Drawing.Size(252, 24);
            this.textBoxMno.TabIndex = 4;
            this.textBoxMno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMno_KeyPress);
            this.textBoxMno.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMno_Validating);
            // 
            // labelEid
            // 
            this.labelEid.AutoSize = true;
            this.labelEid.Location = new System.Drawing.Point(58, 130);
            this.labelEid.Name = "labelEid";
            this.labelEid.Size = new System.Drawing.Size(63, 18);
            this.labelEid.TabIndex = 7;
            this.labelEid.Text = "Email ID";
            // 
            // textBoxEid
            // 
            this.textBoxEid.Location = new System.Drawing.Point(287, 124);
            this.textBoxEid.Name = "textBoxEid";
            this.textBoxEid.Size = new System.Drawing.Size(252, 24);
            this.textBoxEid.TabIndex = 6;
            this.textBoxEid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEid_KeyPress);
            this.textBoxEid.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEid_Validating);
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(58, 178);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(76, 18);
            this.labelUserType.TabIndex = 9;
            this.labelUserType.Text = "User Type";
            // 
            // textBoxUserType
            // 
            this.textBoxUserType.Location = new System.Drawing.Point(287, 172);
            this.textBoxUserType.Name = "textBoxUserType";
            this.textBoxUserType.Size = new System.Drawing.Size(252, 24);
            this.textBoxUserType.TabIndex = 8;
            // 
            // labelLL
            // 
            this.labelLL.AutoSize = true;
            this.labelLL.Location = new System.Drawing.Point(58, 226);
            this.labelLL.Name = "labelLL";
            this.labelLL.Size = new System.Drawing.Size(76, 18);
            this.labelLL.TabIndex = 11;
            this.labelLL.Text = "Last Login";
            // 
            // textBoxLL
            // 
            this.textBoxLL.Location = new System.Drawing.Point(287, 220);
            this.textBoxLL.Name = "textBoxLL";
            this.textBoxLL.Size = new System.Drawing.Size(252, 24);
            this.textBoxLL.TabIndex = 10;
            // 
            // labelLPC
            // 
            this.labelLPC.AutoSize = true;
            this.labelLPC.Location = new System.Drawing.Point(58, 274);
            this.labelLPC.Name = "labelLPC";
            this.labelLPC.Size = new System.Drawing.Size(170, 18);
            this.labelLPC.TabIndex = 13;
            this.labelLPC.Text = "Last Password Changed";
            // 
            // textBoxLPC
            // 
            this.textBoxLPC.Location = new System.Drawing.Point(287, 268);
            this.textBoxLPC.Name = "textBoxLPC";
            this.textBoxLPC.Size = new System.Drawing.Size(252, 24);
            this.textBoxLPC.TabIndex = 12;
            // 
            // labelCreated
            // 
            this.labelCreated.AutoSize = true;
            this.labelCreated.Location = new System.Drawing.Point(58, 322);
            this.labelCreated.Name = "labelCreated";
            this.labelCreated.Size = new System.Drawing.Size(60, 18);
            this.labelCreated.TabIndex = 15;
            this.labelCreated.Text = "Created";
            // 
            // textBoxCreated
            // 
            this.textBoxCreated.Location = new System.Drawing.Point(287, 316);
            this.textBoxCreated.Name = "textBoxCreated";
            this.textBoxCreated.Size = new System.Drawing.Size(252, 24);
            this.textBoxCreated.TabIndex = 14;
            // 
            // labelCreatedBy
            // 
            this.labelCreatedBy.AutoSize = true;
            this.labelCreatedBy.Location = new System.Drawing.Point(58, 370);
            this.labelCreatedBy.Name = "labelCreatedBy";
            this.labelCreatedBy.Size = new System.Drawing.Size(81, 18);
            this.labelCreatedBy.TabIndex = 17;
            this.labelCreatedBy.Text = "Created By";
            // 
            // textBoxCreatedBy
            // 
            this.textBoxCreatedBy.Location = new System.Drawing.Point(287, 364);
            this.textBoxCreatedBy.Name = "textBoxCreatedBy";
            this.textBoxCreatedBy.Size = new System.Drawing.Size(252, 24);
            this.textBoxCreatedBy.TabIndex = 16;
            // 
            // labelModified
            // 
            this.labelModified.AutoSize = true;
            this.labelModified.Location = new System.Drawing.Point(58, 418);
            this.labelModified.Name = "labelModified";
            this.labelModified.Size = new System.Drawing.Size(64, 18);
            this.labelModified.TabIndex = 19;
            this.labelModified.Text = "Modified";
            // 
            // textBoxModified
            // 
            this.textBoxModified.Location = new System.Drawing.Point(287, 412);
            this.textBoxModified.Name = "textBoxModified";
            this.textBoxModified.Size = new System.Drawing.Size(252, 24);
            this.textBoxModified.TabIndex = 18;
            // 
            // labelModifiedBy
            // 
            this.labelModifiedBy.AutoSize = true;
            this.labelModifiedBy.Location = new System.Drawing.Point(58, 466);
            this.labelModifiedBy.Name = "labelModifiedBy";
            this.labelModifiedBy.Size = new System.Drawing.Size(85, 18);
            this.labelModifiedBy.TabIndex = 21;
            this.labelModifiedBy.Text = "Modified By";
            // 
            // textBoxModifiedBy
            // 
            this.textBoxModifiedBy.Location = new System.Drawing.Point(287, 460);
            this.textBoxModifiedBy.Name = "textBoxModifiedBy";
            this.textBoxModifiedBy.Size = new System.Drawing.Size(252, 24);
            this.textBoxModifiedBy.TabIndex = 20;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(305, 505);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(430, 505);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelMnoError
            // 
            this.labelMnoError.AutoSize = true;
            this.labelMnoError.ForeColor = System.Drawing.Color.Red;
            this.labelMnoError.Location = new System.Drawing.Point(299, 103);
            this.labelMnoError.Name = "labelMnoError";
            this.labelMnoError.Size = new System.Drawing.Size(275, 18);
            this.labelMnoError.TabIndex = 24;
            this.labelMnoError.Text = "Mobile No. not entered in correct format ";
            this.labelMnoError.Visible = false;
            // 
            // labelEidErrorMsg
            // 
            this.labelEidErrorMsg.AutoSize = true;
            this.labelEidErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labelEidErrorMsg.Location = new System.Drawing.Point(302, 149);
            this.labelEidErrorMsg.Name = "labelEidErrorMsg";
            this.labelEidErrorMsg.Size = new System.Drawing.Size(262, 18);
            this.labelEidErrorMsg.TabIndex = 25;
            this.labelEidErrorMsg.Text = "Email ID not entered in correct format. ";
            this.labelEidErrorMsg.Visible = false;
            // 
            // labelNameError
            // 
            this.labelNameError.AutoSize = true;
            this.labelNameError.ForeColor = System.Drawing.Color.Red;
            this.labelNameError.Location = new System.Drawing.Point(302, 53);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(139, 18);
            this.labelNameError.TabIndex = 26;
            this.labelNameError.Text = "User name is blank.";
            this.labelNameError.Visible = false;
            // 
            // UserAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 549);
            this.Controls.Add(this.labelNameError);
            this.Controls.Add(this.labelEidErrorMsg);
            this.Controls.Add(this.labelMnoError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelModifiedBy);
            this.Controls.Add(this.textBoxModifiedBy);
            this.Controls.Add(this.labelModified);
            this.Controls.Add(this.textBoxModified);
            this.Controls.Add(this.labelCreatedBy);
            this.Controls.Add(this.textBoxCreatedBy);
            this.Controls.Add(this.labelCreated);
            this.Controls.Add(this.textBoxCreated);
            this.Controls.Add(this.labelLPC);
            this.Controls.Add(this.textBoxLPC);
            this.Controls.Add(this.labelLL);
            this.Controls.Add(this.textBoxLL);
            this.Controls.Add(this.labelUserType);
            this.Controls.Add(this.textBoxUserType);
            this.Controls.Add(this.labelEid);
            this.Controls.Add(this.textBoxEid);
            this.Controls.Add(this.labelMno);
            this.Controls.Add(this.textBoxMno);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Account";
            this.Load += new System.EventHandler(this.UserAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMno;
        private System.Windows.Forms.TextBox textBoxMno;
        private System.Windows.Forms.Label labelEid;
        private System.Windows.Forms.TextBox textBoxEid;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.TextBox textBoxUserType;
        private System.Windows.Forms.Label labelLL;
        private System.Windows.Forms.TextBox textBoxLL;
        private System.Windows.Forms.Label labelLPC;
        private System.Windows.Forms.TextBox textBoxLPC;
        private System.Windows.Forms.Label labelCreated;
        private System.Windows.Forms.TextBox textBoxCreated;
        private System.Windows.Forms.Label labelCreatedBy;
        private System.Windows.Forms.TextBox textBoxCreatedBy;
        private System.Windows.Forms.Label labelModified;
        private System.Windows.Forms.TextBox textBoxModified;
        private System.Windows.Forms.Label labelModifiedBy;
        private System.Windows.Forms.TextBox textBoxModifiedBy;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelMnoError;
        private System.Windows.Forms.Label labelEidErrorMsg;
        private System.Windows.Forms.Label labelNameError;
    }
}