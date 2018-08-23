namespace MapEditor
{
	partial class NewMapDialog
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
			this.NewMapButton = new System.Windows.Forms.Button();
			this.LabelWidth = new System.Windows.Forms.Label();
			this.LabelHeight = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// NewMapButton
			// 
			this.NewMapButton.Location = new System.Drawing.Point(69, 120);
			this.NewMapButton.Name = "NewMapButton";
			this.NewMapButton.Size = new System.Drawing.Size(75, 23);
			this.NewMapButton.TabIndex = 0;
			this.NewMapButton.Text = "OK";
			this.NewMapButton.UseVisualStyleBackColor = true;
			// 
			// LabelWidth
			// 
			this.LabelWidth.AutoSize = true;
			this.LabelWidth.Location = new System.Drawing.Point(40, 37);
			this.LabelWidth.Name = "LabelWidth";
			this.LabelWidth.Size = new System.Drawing.Size(37, 13);
			this.LabelWidth.TabIndex = 1;
			this.LabelWidth.Text = "Rows:";
			// 
			// LabelHeight
			// 
			this.LabelHeight.AutoSize = true;
			this.LabelHeight.Location = new System.Drawing.Point(27, 65);
			this.LabelHeight.Name = "LabelHeight";
			this.LabelHeight.Size = new System.Drawing.Size(50, 13);
			this.LabelHeight.TabIndex = 1;
			this.LabelHeight.Text = "Columns:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(83, 34);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(83, 62);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 2;
			// 
			// NewMapDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(212, 155);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.LabelHeight);
			this.Controls.Add(this.LabelWidth);
			this.Controls.Add(this.NewMapButton);
			this.Name = "NewMapDialog";
			this.Text = "NewMap";
			this.Load += new System.EventHandler(this.NewMapDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button NewMapButton;
		private System.Windows.Forms.Label LabelWidth;
		private System.Windows.Forms.Label LabelHeight;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
	}
}