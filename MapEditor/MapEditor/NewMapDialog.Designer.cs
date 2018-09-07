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
			this.nmOKButton = new System.Windows.Forms.Button();
			this.lblRows = new System.Windows.Forms.Label();
			this.lblColumns = new System.Windows.Forms.Label();
			this.textBoxRows = new System.Windows.Forms.TextBox();
			this.textBoxColumns = new System.Windows.Forms.TextBox();
			this.panel = new System.Windows.Forms.Panel();
			this.textBoxTileHeight = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxTileWidth = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblMapSize = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// nmOKButton
			// 
			this.nmOKButton.Location = new System.Drawing.Point(60, 189);
			this.nmOKButton.Name = "nmOKButton";
			this.nmOKButton.Size = new System.Drawing.Size(80, 23);
			this.nmOKButton.TabIndex = 0;
			this.nmOKButton.Text = "OK";
			this.nmOKButton.UseVisualStyleBackColor = true;
			this.nmOKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// lblRows
			// 
			this.lblRows.AutoSize = true;
			this.lblRows.Location = new System.Drawing.Point(65, 38);
			this.lblRows.Name = "lblRows";
			this.lblRows.Size = new System.Drawing.Size(37, 13);
			this.lblRows.TabIndex = 1;
			this.lblRows.Text = "Rows:";
			// 
			// lblColumns
			// 
			this.lblColumns.AutoSize = true;
			this.lblColumns.Location = new System.Drawing.Point(51, 70);
			this.lblColumns.Name = "lblColumns";
			this.lblColumns.Size = new System.Drawing.Size(50, 13);
			this.lblColumns.TabIndex = 1;
			this.lblColumns.Text = "Columns:";
			// 
			// textBoxRows
			// 
			this.textBoxRows.Location = new System.Drawing.Point(106, 36);
			this.textBoxRows.Name = "textBoxRows";
			this.textBoxRows.Size = new System.Drawing.Size(100, 20);
			this.textBoxRows.TabIndex = 2;
			this.textBoxRows.TextChanged += new System.EventHandler(this.textBoxRows_TextChanged);
			// 
			// textBoxColumns
			// 
			this.textBoxColumns.Location = new System.Drawing.Point(106, 68);
			this.textBoxColumns.Name = "textBoxColumns";
			this.textBoxColumns.Size = new System.Drawing.Size(100, 20);
			this.textBoxColumns.TabIndex = 2;
			this.textBoxColumns.TextChanged += new System.EventHandler(this.textBoxColumns_TextChanged);
			// 
			// panel
			// 
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel.Controls.Add(this.textBoxTileHeight);
			this.panel.Controls.Add(this.textBoxColumns);
			this.panel.Controls.Add(this.button1);
			this.panel.Controls.Add(this.nmOKButton);
			this.panel.Controls.Add(this.textBoxTileWidth);
			this.panel.Controls.Add(this.label2);
			this.panel.Controls.Add(this.textBoxRows);
			this.panel.Controls.Add(this.lblMapSize);
			this.panel.Controls.Add(this.label1);
			this.panel.Controls.Add(this.lblRows);
			this.panel.Controls.Add(this.lblColumns);
			this.panel.Location = new System.Drawing.Point(15, 28);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(276, 246);
			this.panel.TabIndex = 3;
			// 
			// textBoxTileHeight
			// 
			this.textBoxTileHeight.Location = new System.Drawing.Point(106, 130);
			this.textBoxTileHeight.Name = "textBoxTileHeight";
			this.textBoxTileHeight.Size = new System.Drawing.Size(100, 20);
			this.textBoxTileHeight.TabIndex = 2;
			this.textBoxTileHeight.TextChanged += new System.EventHandler(this.textBoxTileHeight_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(146, 189);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// textBoxTileWidth
			// 
			this.textBoxTileWidth.Location = new System.Drawing.Point(106, 98);
			this.textBoxTileWidth.Name = "textBoxTileWidth";
			this.textBoxTileWidth.Size = new System.Drawing.Size(100, 20);
			this.textBoxTileWidth.TabIndex = 2;
			this.textBoxTileWidth.TextChanged += new System.EventHandler(this.textBoxTileWidth_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tile Width:";
			// 
			// lblMapSize
			// 
			this.lblMapSize.AutoSize = true;
			this.lblMapSize.Location = new System.Drawing.Point(94, 164);
			this.lblMapSize.Name = "lblMapSize";
			this.lblMapSize.Size = new System.Drawing.Size(91, 13);
			this.lblMapSize.TabIndex = 1;
			this.lblMapSize.Text = "[showMapSizePx]";
			this.lblMapSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tile Height:";
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(12, 9);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(27, 13);
			this.lblSize.TabIndex = 4;
			this.lblSize.Text = "Size";
			// 
			// NewMapDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(303, 286);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.panel);
			this.Name = "NewMapDialog";
			this.Text = "Create New Map...";
			this.Load += new System.EventHandler(this.NewMapDialog_Load);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button nmOKButton;
		private System.Windows.Forms.Label lblRows;
		private System.Windows.Forms.Label lblColumns;
		private System.Windows.Forms.TextBox textBoxRows;
		private System.Windows.Forms.TextBox textBoxColumns;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.TextBox textBoxTileHeight;
		private System.Windows.Forms.TextBox textBoxTileWidth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblMapSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}