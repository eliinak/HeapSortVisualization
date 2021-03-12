namespace HeapSortVisualization
{
    partial class Visualization
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
            this.textBoxValues = new System.Windows.Forms.TextBox();
            this.EnterYourValues = new System.Windows.Forms.Label();
            this.GO = new System.Windows.Forms.Button();
            this.StartVisualization = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ReduceHeap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxValues
            // 
            this.textBoxValues.Location = new System.Drawing.Point(13, 29);
            this.textBoxValues.Name = "textBoxValues";
            this.textBoxValues.Size = new System.Drawing.Size(300, 22);
            this.textBoxValues.TabIndex = 0;
            this.textBoxValues.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValues_KeyPress);
            // 
            // EnterYourValues
            // 
            this.EnterYourValues.AutoSize = true;
            this.EnterYourValues.Location = new System.Drawing.Point(12, 9);
            this.EnterYourValues.Name = "EnterYourValues";
            this.EnterYourValues.Size = new System.Drawing.Size(290, 17);
            this.EnterYourValues.TabIndex = 1;
            this.EnterYourValues.Text = "Enter 3,4 or 5 separeted with coma elements";
            // 
            // GO
            // 
            this.GO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.GO.Location = new System.Drawing.Point(390, 29);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(97, 23);
            this.GO.TabIndex = 2;
            this.GO.Text = "GO";
            this.GO.UseVisualStyleBackColor = false;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // StartVisualization
            // 
            this.StartVisualization.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.StartVisualization.Location = new System.Drawing.Point(380, 571);
            this.StartVisualization.Name = "StartVisualization";
            this.StartVisualization.Size = new System.Drawing.Size(186, 34);
            this.StartVisualization.TabIndex = 3;
            this.StartVisualization.Text = "StepByStep";
            this.StartVisualization.UseVisualStyleBackColor = false;
            this.StartVisualization.Click += new System.EventHandler(this.StartVisualization_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Clear.Location = new System.Drawing.Point(720, 571);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(187, 34);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(474, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(474, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // ReduceHeap
            // 
            this.ReduceHeap.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ReduceHeap.Location = new System.Drawing.Point(504, 28);
            this.ReduceHeap.Name = "ReduceHeap";
            this.ReduceHeap.Size = new System.Drawing.Size(124, 23);
            this.ReduceHeap.TabIndex = 7;
            this.ReduceHeap.Text = "ReduceHeap";
            this.ReduceHeap.UseVisualStyleBackColor = false;
            this.ReduceHeap.Click += new System.EventHandler(this.ReduceHeap_Click);
            // 
            // Visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1009, 617);
            this.Controls.Add(this.ReduceHeap);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.StartVisualization);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.EnterYourValues);
            this.Controls.Add(this.textBoxValues);
            this.Name = "Visualization";
            this.Text = "HeapSortVisualization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValues;
        private System.Windows.Forms.Label EnterYourValues;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.Button StartVisualization;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button ReduceHeap;
    }
}

