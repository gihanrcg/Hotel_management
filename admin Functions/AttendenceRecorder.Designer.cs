namespace AttendanceRecorder
{
    partial class AttendenceRecorder
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
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(112, 78);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(240, 224);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.Location = new System.Drawing.Point(360, 82);
            this.btnOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(240, 224);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "Out";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // AttendenceRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 321);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttendenceRecorder";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "AttendenceRecorder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOut;
    }
}