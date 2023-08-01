
namespace MasterMech
{
    partial class InvoiceAdvanceSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceAdvanceSearchForm));
            this.labelSearchFirstName = new System.Windows.Forms.Label();
            this.labelVehicleReg = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxSearchCustFirstName = new System.Windows.Forms.TextBox();
            this.textBoxSearchVehicleReg = new System.Windows.Forms.TextBox();
            this.textBoxSearchCity = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchAsso = new System.Windows.Forms.TextBox();
            this.labelSearchAsso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSearchFirstName
            // 
            this.labelSearchFirstName.AutoSize = true;
            this.labelSearchFirstName.Location = new System.Drawing.Point(48, 41);
            this.labelSearchFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchFirstName.Name = "labelSearchFirstName";
            this.labelSearchFirstName.Size = new System.Drawing.Size(170, 20);
            this.labelSearchFirstName.TabIndex = 0;
            this.labelSearchFirstName.Text = "Customer First Name";
            // 
            // labelVehicleReg
            // 
            this.labelVehicleReg.AutoSize = true;
            this.labelVehicleReg.Location = new System.Drawing.Point(48, 96);
            this.labelVehicleReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVehicleReg.Name = "labelVehicleReg";
            this.labelVehicleReg.Size = new System.Drawing.Size(133, 20);
            this.labelVehicleReg.TabIndex = 1;
            this.labelVehicleReg.Text = "Vehicle Reg. No.";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(48, 151);
            this.labelCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(38, 20);
            this.labelCity.TabIndex = 2;
            this.labelCity.Text = "City";
            // 
            // textBoxSearchCustFirstName
            // 
            this.textBoxSearchCustFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchCustFirstName.Location = new System.Drawing.Point(229, 39);
            this.textBoxSearchCustFirstName.Name = "textBoxSearchCustFirstName";
            this.textBoxSearchCustFirstName.Size = new System.Drawing.Size(234, 26);
            this.textBoxSearchCustFirstName.TabIndex = 3;
            // 
            // textBoxSearchVehicleReg
            // 
            this.textBoxSearchVehicleReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchVehicleReg.Location = new System.Drawing.Point(229, 94);
            this.textBoxSearchVehicleReg.Name = "textBoxSearchVehicleReg";
            this.textBoxSearchVehicleReg.Size = new System.Drawing.Size(234, 26);
            this.textBoxSearchVehicleReg.TabIndex = 4;
            // 
            // textBoxSearchCity
            // 
            this.textBoxSearchCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchCity.Location = new System.Drawing.Point(229, 149);
            this.textBoxSearchCity.Name = "textBoxSearchCity";
            this.textBoxSearchCity.Size = new System.Drawing.Size(234, 26);
            this.textBoxSearchCity.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(388, 271);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 28);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(267, 271);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 28);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearchAsso
            // 
            this.textBoxSearchAsso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchAsso.Location = new System.Drawing.Point(229, 204);
            this.textBoxSearchAsso.Name = "textBoxSearchAsso";
            this.textBoxSearchAsso.Size = new System.Drawing.Size(234, 26);
            this.textBoxSearchAsso.TabIndex = 8;
            // 
            // labelSearchAsso
            // 
            this.labelSearchAsso.AutoSize = true;
            this.labelSearchAsso.Location = new System.Drawing.Point(48, 206);
            this.labelSearchAsso.Name = "labelSearchAsso";
            this.labelSearchAsso.Size = new System.Drawing.Size(132, 20);
            this.labelSearchAsso.TabIndex = 9;
            this.labelSearchAsso.Text = "Associate Name";
            // 
            // InvoiceAdvanceSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 345);
            this.Controls.Add(this.labelSearchAsso);
            this.Controls.Add(this.textBoxSearchAsso);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxSearchCity);
            this.Controls.Add(this.textBoxSearchVehicleReg);
            this.Controls.Add(this.textBoxSearchCustFirstName);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelVehicleReg);
            this.Controls.Add(this.labelSearchFirstName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceAdvanceSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Advanced Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSearchFirstName;
        private System.Windows.Forms.Label labelVehicleReg;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxSearchCustFirstName;
        private System.Windows.Forms.TextBox textBoxSearchVehicleReg;
        private System.Windows.Forms.TextBox textBoxSearchCity;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchAsso;
        private System.Windows.Forms.Label labelSearchAsso;
    }
}