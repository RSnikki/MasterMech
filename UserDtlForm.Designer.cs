
namespace MasterMech
{
    partial class UserDtlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDtlForm));
            this.labelId = new System.Windows.Forms.Label();
            this.labelPwd = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.labelCnfPwd = new System.Windows.Forms.Label();
            this.textBoxCnfPass = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelMno = new System.Windows.Forms.Label();
            this.textBoxMno = new System.Windows.Forms.TextBox();
            this.labeleid = new System.Windows.Forms.Label();
            this.textBoxEid = new System.Windows.Forms.TextBox();
            this.labeluType = new System.Windows.Forms.Label();
            this.labelRem = new System.Windows.Forms.Label();
            this.textBoxRem = new System.Windows.Forms.TextBox();
            this.labelLLogin = new System.Windows.Forms.Label();
            this.textBoxLL = new System.Windows.Forms.TextBox();
            this.textBoxLPC = new System.Windows.Forms.TextBox();
            this.labelLPC = new System.Windows.Forms.Label();
            this.textBoxCreate = new System.Windows.Forms.TextBox();
            this.labelCreate = new System.Windows.Forms.Label();
            this.textBoxCreateBy = new System.Windows.Forms.TextBox();
            this.labelCreateBy = new System.Windows.Forms.Label();
            this.textBoxModifyBy = new System.Windows.Forms.TextBox();
            this.labelModifyBy = new System.Windows.Forms.Label();
            this.textBoxModify = new System.Windows.Forms.TextBox();
            this.labelModify = new System.Windows.Forms.Label();
            this.comboBoxUType = new System.Windows.Forms.ComboBox();
            this.buttonAction = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelIDValidating = new System.Windows.Forms.Label();
            this.buttonSrch = new System.Windows.Forms.Button();
            this.labelPwdValidating = new System.Windows.Forms.Label();
            this.labelNameValidating = new System.Windows.Forms.Label();
            this.labelMNoValidating = new System.Windows.Forms.Label();
            this.labelEidValidating = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(20, 29);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(72, 20);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "User ID:";
            // 
            // labelPwd
            // 
            this.labelPwd.AutoSize = true;
            this.labelPwd.Location = new System.Drawing.Point(20, 80);
            this.labelPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPwd.Name = "labelPwd";
            this.labelPwd.Size = new System.Drawing.Size(88, 20);
            this.labelPwd.TabIndex = 1;
            this.labelPwd.Text = "Password:";
            // 
            // textBoxId
            // 
            this.textBoxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxId.Location = new System.Drawing.Point(235, 27);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(252, 26);
            this.textBoxId.TabIndex = 2;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            this.textBoxId.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxId_Validating);
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPwd.Location = new System.Drawing.Point(235, 78);
            this.textBoxPwd.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.PasswordChar = '*';
            this.textBoxPwd.Size = new System.Drawing.Size(252, 26);
            this.textBoxPwd.TabIndex = 3;
            this.textBoxPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPwd_KeyPress);
            this.textBoxPwd.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPwd_Validating);
            // 
            // labelCnfPwd
            // 
            this.labelCnfPwd.AutoSize = true;
            this.labelCnfPwd.Location = new System.Drawing.Point(20, 127);
            this.labelCnfPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCnfPwd.Name = "labelCnfPwd";
            this.labelCnfPwd.Size = new System.Drawing.Size(152, 20);
            this.labelCnfPwd.TabIndex = 4;
            this.labelCnfPwd.Text = "Confirm Password:";
            // 
            // textBoxCnfPass
            // 
            this.textBoxCnfPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCnfPass.Location = new System.Drawing.Point(235, 127);
            this.textBoxCnfPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCnfPass.Name = "textBoxCnfPass";
            this.textBoxCnfPass.PasswordChar = '*';
            this.textBoxCnfPass.Size = new System.Drawing.Size(252, 26);
            this.textBoxCnfPass.TabIndex = 5;
            this.textBoxCnfPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCnfPass_KeyPress);
            this.textBoxCnfPass.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCnfPass_Validating);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(24, 180);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(94, 20);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "User Name";
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Location = new System.Drawing.Point(235, 178);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(252, 26);
            this.textBoxName.TabIndex = 7;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxName_Validating);
            // 
            // labelMno
            // 
            this.labelMno.AutoSize = true;
            this.labelMno.Location = new System.Drawing.Point(24, 231);
            this.labelMno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMno.Name = "labelMno";
            this.labelMno.Size = new System.Drawing.Size(93, 20);
            this.labelMno.TabIndex = 8;
            this.labelMno.Text = "Mobile No.:";
            // 
            // textBoxMno
            // 
            this.textBoxMno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMno.Location = new System.Drawing.Point(235, 229);
            this.textBoxMno.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMno.Name = "textBoxMno";
            this.textBoxMno.Size = new System.Drawing.Size(252, 26);
            this.textBoxMno.TabIndex = 9;
            this.textBoxMno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMno_KeyPress);
            this.textBoxMno.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMno_Validating);
            // 
            // labeleid
            // 
            this.labeleid.AutoSize = true;
            this.labeleid.Location = new System.Drawing.Point(24, 282);
            this.labeleid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeleid.Name = "labeleid";
            this.labeleid.Size = new System.Drawing.Size(73, 20);
            this.labeleid.TabIndex = 10;
            this.labeleid.Text = "Email ID";
            // 
            // textBoxEid
            // 
            this.textBoxEid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEid.Location = new System.Drawing.Point(235, 280);
            this.textBoxEid.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEid.Name = "textBoxEid";
            this.textBoxEid.Size = new System.Drawing.Size(252, 26);
            this.textBoxEid.TabIndex = 11;
            this.textBoxEid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEid_KeyPress);
            this.textBoxEid.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEid_Validating);
            // 
            // labeluType
            // 
            this.labeluType.AutoSize = true;
            this.labeluType.Location = new System.Drawing.Point(24, 334);
            this.labeluType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeluType.Name = "labeluType";
            this.labeluType.Size = new System.Drawing.Size(86, 20);
            this.labeluType.TabIndex = 12;
            this.labeluType.Text = "User Type";
            // 
            // labelRem
            // 
            this.labelRem.AutoSize = true;
            this.labelRem.Location = new System.Drawing.Point(24, 385);
            this.labelRem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRem.Name = "labelRem";
            this.labelRem.Size = new System.Drawing.Size(76, 20);
            this.labelRem.TabIndex = 14;
            this.labelRem.Text = "Remarks";
            // 
            // textBoxRem
            // 
            this.textBoxRem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRem.Location = new System.Drawing.Point(235, 383);
            this.textBoxRem.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRem.Name = "textBoxRem";
            this.textBoxRem.Size = new System.Drawing.Size(252, 26);
            this.textBoxRem.TabIndex = 15;
            // 
            // labelLLogin
            // 
            this.labelLLogin.AutoSize = true;
            this.labelLLogin.Location = new System.Drawing.Point(24, 433);
            this.labelLLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLLogin.Name = "labelLLogin";
            this.labelLLogin.Size = new System.Drawing.Size(88, 20);
            this.labelLLogin.TabIndex = 16;
            this.labelLLogin.Text = "Last Login";
            // 
            // textBoxLL
            // 
            this.textBoxLL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLL.Location = new System.Drawing.Point(235, 431);
            this.textBoxLL.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLL.Name = "textBoxLL";
            this.textBoxLL.Size = new System.Drawing.Size(252, 26);
            this.textBoxLL.TabIndex = 17;
            // 
            // textBoxLPC
            // 
            this.textBoxLPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLPC.Location = new System.Drawing.Point(235, 481);
            this.textBoxLPC.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLPC.Name = "textBoxLPC";
            this.textBoxLPC.Size = new System.Drawing.Size(252, 26);
            this.textBoxLPC.TabIndex = 19;
            // 
            // labelLPC
            // 
            this.labelLPC.AutoSize = true;
            this.labelLPC.Location = new System.Drawing.Point(24, 483);
            this.labelLPC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLPC.Name = "labelLPC";
            this.labelLPC.Size = new System.Drawing.Size(192, 20);
            this.labelLPC.TabIndex = 18;
            this.labelLPC.Text = "Last Password Changed";
            // 
            // textBoxCreate
            // 
            this.textBoxCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCreate.Location = new System.Drawing.Point(235, 528);
            this.textBoxCreate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCreate.Name = "textBoxCreate";
            this.textBoxCreate.Size = new System.Drawing.Size(252, 26);
            this.textBoxCreate.TabIndex = 21;
            // 
            // labelCreate
            // 
            this.labelCreate.AutoSize = true;
            this.labelCreate.Location = new System.Drawing.Point(24, 530);
            this.labelCreate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreate.Name = "labelCreate";
            this.labelCreate.Size = new System.Drawing.Size(68, 20);
            this.labelCreate.TabIndex = 20;
            this.labelCreate.Text = "Created";
            // 
            // textBoxCreateBy
            // 
            this.textBoxCreateBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCreateBy.Location = new System.Drawing.Point(235, 575);
            this.textBoxCreateBy.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCreateBy.Name = "textBoxCreateBy";
            this.textBoxCreateBy.Size = new System.Drawing.Size(252, 26);
            this.textBoxCreateBy.TabIndex = 23;
            // 
            // labelCreateBy
            // 
            this.labelCreateBy.AutoSize = true;
            this.labelCreateBy.Location = new System.Drawing.Point(24, 577);
            this.labelCreateBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreateBy.Name = "labelCreateBy";
            this.labelCreateBy.Size = new System.Drawing.Size(93, 20);
            this.labelCreateBy.TabIndex = 22;
            this.labelCreateBy.Text = "Created By";
            // 
            // textBoxModifyBy
            // 
            this.textBoxModifyBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxModifyBy.Location = new System.Drawing.Point(235, 671);
            this.textBoxModifyBy.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxModifyBy.Name = "textBoxModifyBy";
            this.textBoxModifyBy.Size = new System.Drawing.Size(252, 26);
            this.textBoxModifyBy.TabIndex = 27;
            // 
            // labelModifyBy
            // 
            this.labelModifyBy.AutoSize = true;
            this.labelModifyBy.Location = new System.Drawing.Point(24, 673);
            this.labelModifyBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModifyBy.Name = "labelModifyBy";
            this.labelModifyBy.Size = new System.Drawing.Size(97, 20);
            this.labelModifyBy.TabIndex = 26;
            this.labelModifyBy.Text = "Modified By";
            // 
            // textBoxModify
            // 
            this.textBoxModify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxModify.Location = new System.Drawing.Point(235, 623);
            this.textBoxModify.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxModify.Name = "textBoxModify";
            this.textBoxModify.Size = new System.Drawing.Size(252, 26);
            this.textBoxModify.TabIndex = 25;
            // 
            // labelModify
            // 
            this.labelModify.AutoSize = true;
            this.labelModify.Location = new System.Drawing.Point(24, 625);
            this.labelModify.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModify.Name = "labelModify";
            this.labelModify.Size = new System.Drawing.Size(72, 20);
            this.labelModify.TabIndex = 24;
            this.labelModify.Text = "Modified";
            // 
            // comboBoxUType
            // 
            this.comboBoxUType.FormattingEnabled = true;
            this.comboBoxUType.Items.AddRange(new object[] {
            "Adm",
            "Rgl"});
            this.comboBoxUType.Location = new System.Drawing.Point(235, 331);
            this.comboBoxUType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxUType.Name = "comboBoxUType";
            this.comboBoxUType.Size = new System.Drawing.Size(252, 28);
            this.comboBoxUType.TabIndex = 28;
            // 
            // buttonAction
            // 
            this.buttonAction.Location = new System.Drawing.Point(239, 717);
            this.buttonAction.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(94, 30);
            this.buttonAction.TabIndex = 29;
            this.buttonAction.Text = "Save";
            this.buttonAction.UseVisualStyleBackColor = true;
            this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(390, 717);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 30);
            this.buttonCancel.TabIndex = 30;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelIDValidating
            // 
            this.labelIDValidating.AutoSize = true;
            this.labelIDValidating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIDValidating.ForeColor = System.Drawing.Color.Red;
            this.labelIDValidating.Location = new System.Drawing.Point(236, 57);
            this.labelIDValidating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIDValidating.Name = "labelIDValidating";
            this.labelIDValidating.Size = new System.Drawing.Size(251, 17);
            this.labelIDValidating.TabIndex = 31;
            this.labelIDValidating.Text = "UserID is blank. Choose a new UserID.";
            this.labelIDValidating.Visible = false;
            // 
            // buttonSrch
            // 
            this.buttonSrch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSrch.Image")));
            this.buttonSrch.Location = new System.Drawing.Point(495, 25);
            this.buttonSrch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSrch.Name = "buttonSrch";
            this.buttonSrch.Size = new System.Drawing.Size(41, 29);
            this.buttonSrch.TabIndex = 32;
            this.buttonSrch.UseVisualStyleBackColor = true;
            this.buttonSrch.Click += new System.EventHandler(this.buttonSrch_Click);
            // 
            // labelPwdValidating
            // 
            this.labelPwdValidating.AutoSize = true;
            this.labelPwdValidating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPwdValidating.ForeColor = System.Drawing.Color.Red;
            this.labelPwdValidating.Location = new System.Drawing.Point(236, 157);
            this.labelPwdValidating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPwdValidating.Name = "labelPwdValidating";
            this.labelPwdValidating.Size = new System.Drawing.Size(354, 17);
            this.labelPwdValidating.TabIndex = 33;
            this.labelPwdValidating.Text = "Password blank or Pwd and Confirm Pwd do not match.";
            this.labelPwdValidating.Visible = false;
            // 
            // labelNameValidating
            // 
            this.labelNameValidating.AutoSize = true;
            this.labelNameValidating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameValidating.ForeColor = System.Drawing.Color.Red;
            this.labelNameValidating.Location = new System.Drawing.Point(236, 208);
            this.labelNameValidating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNameValidating.Name = "labelNameValidating";
            this.labelNameValidating.Size = new System.Drawing.Size(131, 17);
            this.labelNameValidating.TabIndex = 34;
            this.labelNameValidating.Text = "UserName is blank.";
            this.labelNameValidating.Visible = false;
            // 
            // labelMNoValidating
            // 
            this.labelMNoValidating.AutoSize = true;
            this.labelMNoValidating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMNoValidating.ForeColor = System.Drawing.Color.Red;
            this.labelMNoValidating.Location = new System.Drawing.Point(236, 259);
            this.labelMNoValidating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMNoValidating.Name = "labelMNoValidating";
            this.labelMNoValidating.Size = new System.Drawing.Size(332, 17);
            this.labelMNoValidating.TabIndex = 35;
            this.labelMNoValidating.Text = "Mobile No. is blank or not entered in correct format.";
            this.labelMNoValidating.Visible = false;
            // 
            // labelEidValidating
            // 
            this.labelEidValidating.AutoSize = true;
            this.labelEidValidating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEidValidating.ForeColor = System.Drawing.Color.Red;
            this.labelEidValidating.Location = new System.Drawing.Point(236, 310);
            this.labelEidValidating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEidValidating.Name = "labelEidValidating";
            this.labelEidValidating.Size = new System.Drawing.Size(312, 17);
            this.labelEidValidating.TabIndex = 36;
            this.labelEidValidating.Text = "EmailID is blank or not entered in correct format.";
            this.labelEidValidating.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(495, 79);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 24);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "Show";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // UserDtlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(592, 761);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelEidValidating);
            this.Controls.Add(this.labelMNoValidating);
            this.Controls.Add(this.labelNameValidating);
            this.Controls.Add(this.labelPwdValidating);
            this.Controls.Add(this.buttonSrch);
            this.Controls.Add(this.labelIDValidating);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAction);
            this.Controls.Add(this.comboBoxUType);
            this.Controls.Add(this.textBoxModifyBy);
            this.Controls.Add(this.labelModifyBy);
            this.Controls.Add(this.textBoxModify);
            this.Controls.Add(this.labelModify);
            this.Controls.Add(this.textBoxCreateBy);
            this.Controls.Add(this.labelCreateBy);
            this.Controls.Add(this.textBoxCreate);
            this.Controls.Add(this.labelCreate);
            this.Controls.Add(this.textBoxLPC);
            this.Controls.Add(this.labelLPC);
            this.Controls.Add(this.textBoxLL);
            this.Controls.Add(this.labelLLogin);
            this.Controls.Add(this.textBoxRem);
            this.Controls.Add(this.labelRem);
            this.Controls.Add(this.labeluType);
            this.Controls.Add(this.textBoxEid);
            this.Controls.Add(this.labeleid);
            this.Controls.Add(this.textBoxMno);
            this.Controls.Add(this.labelMno);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxCnfPass);
            this.Controls.Add(this.labelCnfPwd);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelPwd);
            this.Controls.Add(this.labelId);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDtlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Details";
            this.Load += new System.EventHandler(this.UserDtlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelPwd;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label labelCnfPwd;
        private System.Windows.Forms.TextBox textBoxCnfPass;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelMno;
        private System.Windows.Forms.TextBox textBoxMno;
        private System.Windows.Forms.Label labeleid;
        private System.Windows.Forms.TextBox textBoxEid;
        private System.Windows.Forms.Label labeluType;
        private System.Windows.Forms.Label labelRem;
        private System.Windows.Forms.TextBox textBoxRem;
        private System.Windows.Forms.Label labelLLogin;
        private System.Windows.Forms.TextBox textBoxLL;
        private System.Windows.Forms.TextBox textBoxLPC;
        private System.Windows.Forms.Label labelLPC;
        private System.Windows.Forms.TextBox textBoxCreate;
        private System.Windows.Forms.Label labelCreate;
        private System.Windows.Forms.TextBox textBoxCreateBy;
        private System.Windows.Forms.Label labelCreateBy;
        private System.Windows.Forms.TextBox textBoxModifyBy;
        private System.Windows.Forms.Label labelModifyBy;
        private System.Windows.Forms.TextBox textBoxModify;
        private System.Windows.Forms.Label labelModify;
        private System.Windows.Forms.ComboBox comboBoxUType;
        private System.Windows.Forms.Button buttonAction;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelIDValidating;
        private System.Windows.Forms.Button buttonSrch;
        private System.Windows.Forms.Label labelPwdValidating;
        private System.Windows.Forms.Label labelNameValidating;
        private System.Windows.Forms.Label labelMNoValidating;
        private System.Windows.Forms.Label labelEidValidating;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}