namespace AttendanceRecorder
{
    partial class EmployeePositions
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
            this.dgvEmployeePositions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeePositions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployeePositions
            // 
            this.dgvEmployeePositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeePositions.Location = new System.Drawing.Point(88, 66);
            this.dgvEmployeePositions.Name = "dgvEmployeePositions";
            this.dgvEmployeePositions.RowTemplate.Height = 24;
            this.dgvEmployeePositions.Size = new System.Drawing.Size(726, 359);
            this.dgvEmployeePositions.TabIndex = 0;
            this.dgvEmployeePositions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeePositions_CellValueChanged);
            // 
            // EmployeePositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 456);
            this.Controls.Add(this.dgvEmployeePositions);
            this.Name = "EmployeePositions";
            this.Text = "EmployeePositions";
            this.Load += new System.EventHandler(this.EmployeePositions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeePositions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeePositions;
    }
}