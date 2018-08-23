namespace MapEditor
{
    partial class TilesetLoaderForm
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
			this.tslDisplayBox = new System.Windows.Forms.PictureBox();
			this.tslOKButton = new System.Windows.Forms.Button();
			this.tslLoadButton = new System.Windows.Forms.Button();
			this.lblCols = new System.Windows.Forms.Label();
			this.lblRows = new System.Windows.Forms.Label();
			this.lblTilewidth = new System.Windows.Forms.Label();
			this.lblTileheight = new System.Windows.Forms.Label();
			this.textBoxColumns = new System.Windows.Forms.TextBox();
			this.textBoxTileWidth = new System.Windows.Forms.TextBox();
			this.textBoxTileHeight = new System.Windows.Forms.TextBox();
			this.textBoxRows = new System.Windows.Forms.TextBox();
			this.tslCancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.tslDisplayBox)).BeginInit();
			this.SuspendLayout();
			// 
			// tslDisplayBox
			// 
			this.tslDisplayBox.Location = new System.Drawing.Point(12, 12);
			this.tslDisplayBox.Name = "tslDisplayBox";
			this.tslDisplayBox.Size = new System.Drawing.Size(1078, 566);
			this.tslDisplayBox.TabIndex = 0;
			this.tslDisplayBox.TabStop = false;
			// 
			// tslOKButton
			// 
			this.tslOKButton.Location = new System.Drawing.Point(884, 584);
			this.tslOKButton.Name = "tslOKButton";
			this.tslOKButton.Size = new System.Drawing.Size(100, 43);
			this.tslOKButton.TabIndex = 1;
			this.tslOKButton.Text = "OK";
			this.tslOKButton.UseVisualStyleBackColor = true;
			this.tslOKButton.Click += new System.EventHandler(this.tslOKButton_Click);
			// 
			// tslLoadButton
			// 
			this.tslLoadButton.Location = new System.Drawing.Point(778, 584);
			this.tslLoadButton.Name = "tslLoadButton";
			this.tslLoadButton.Size = new System.Drawing.Size(100, 43);
			this.tslLoadButton.TabIndex = 1;
			this.tslLoadButton.Text = "Load tileset...";
			this.tslLoadButton.UseVisualStyleBackColor = true;
			this.tslLoadButton.Click += new System.EventHandler(this.tslLoadButton_Click);
			// 
			// lblCols
			// 
			this.lblCols.AutoSize = true;
			this.lblCols.Location = new System.Drawing.Point(189, 599);
			this.lblCols.Name = "lblCols";
			this.lblCols.Size = new System.Drawing.Size(50, 13);
			this.lblCols.TabIndex = 2;
			this.lblCols.Text = "Columns:";
			// 
			// lblRows
			// 
			this.lblRows.AutoSize = true;
			this.lblRows.Location = new System.Drawing.Point(12, 599);
			this.lblRows.Name = "lblRows";
			this.lblRows.Size = new System.Drawing.Size(37, 13);
			this.lblRows.TabIndex = 2;
			this.lblRows.Text = "Rows:";
			// 
			// lblTilewidth
			// 
			this.lblTilewidth.AutoSize = true;
			this.lblTilewidth.Location = new System.Drawing.Point(380, 599);
			this.lblTilewidth.Name = "lblTilewidth";
			this.lblTilewidth.Size = new System.Drawing.Size(58, 13);
			this.lblTilewidth.TabIndex = 2;
			this.lblTilewidth.Text = "Tile Width:";
			// 
			// lblTileheight
			// 
			this.lblTileheight.AutoSize = true;
			this.lblTileheight.Location = new System.Drawing.Point(580, 599);
			this.lblTileheight.Name = "lblTileheight";
			this.lblTileheight.Size = new System.Drawing.Size(61, 13);
			this.lblTileheight.TabIndex = 2;
			this.lblTileheight.Text = "Tile Height:";
			// 
			// textBoxColumns
			// 
			this.textBoxColumns.Location = new System.Drawing.Point(244, 596);
			this.textBoxColumns.Name = "textBoxColumns";
			this.textBoxColumns.Size = new System.Drawing.Size(125, 20);
			this.textBoxColumns.TabIndex = 3;
			this.textBoxColumns.TextChanged += new System.EventHandler(this.textBoxColumns_TextChanged);
			// 
			// textBoxTileWidth
			// 
			this.textBoxTileWidth.Location = new System.Drawing.Point(444, 596);
			this.textBoxTileWidth.Name = "textBoxTileWidth";
			this.textBoxTileWidth.Size = new System.Drawing.Size(125, 20);
			this.textBoxTileWidth.TabIndex = 3;
			this.textBoxTileWidth.TextChanged += new System.EventHandler(this.textBoxTileWidth_TextChanged);
			// 
			// textBoxTileHeight
			// 
			this.textBoxTileHeight.Location = new System.Drawing.Point(647, 596);
			this.textBoxTileHeight.Name = "textBoxTileHeight";
			this.textBoxTileHeight.Size = new System.Drawing.Size(125, 20);
			this.textBoxTileHeight.TabIndex = 3;
			this.textBoxTileHeight.TextChanged += new System.EventHandler(this.textBoxTileHeight_TextChanged);
			// 
			// textBoxRows
			// 
			this.textBoxRows.Location = new System.Drawing.Point(54, 596);
			this.textBoxRows.Name = "textBoxRows";
			this.textBoxRows.Size = new System.Drawing.Size(125, 20);
			this.textBoxRows.TabIndex = 3;
			this.textBoxRows.TextChanged += new System.EventHandler(this.textBoxRows_TextChanged);
			// 
			// tslCancelButton
			// 
			this.tslCancelButton.Location = new System.Drawing.Point(990, 584);
			this.tslCancelButton.Name = "tslCancelButton";
			this.tslCancelButton.Size = new System.Drawing.Size(100, 43);
			this.tslCancelButton.TabIndex = 1;
			this.tslCancelButton.Text = "Cancel";
			this.tslCancelButton.UseVisualStyleBackColor = true;
			this.tslCancelButton.Click += new System.EventHandler(this.tslCancelButton_Click);
			// 
			// TilesetLoaderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1102, 639);
			this.Controls.Add(this.textBoxRows);
			this.Controls.Add(this.textBoxTileHeight);
			this.Controls.Add(this.textBoxTileWidth);
			this.Controls.Add(this.textBoxColumns);
			this.Controls.Add(this.lblTileheight);
			this.Controls.Add(this.lblTilewidth);
			this.Controls.Add(this.lblRows);
			this.Controls.Add(this.lblCols);
			this.Controls.Add(this.tslLoadButton);
			this.Controls.Add(this.tslCancelButton);
			this.Controls.Add(this.tslOKButton);
			this.Controls.Add(this.tslDisplayBox);
			this.Name = "TilesetLoaderForm";
			this.Text = "Tileset Loader";
			this.Load += new System.EventHandler(this.TilesetLoaderForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.tslDisplayBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.PictureBox tslDisplayBox;
		private System.Windows.Forms.Button tslOKButton;
		private System.Windows.Forms.Button tslLoadButton;
		private System.Windows.Forms.Label lblCols;
		private System.Windows.Forms.Label lblRows;
		private System.Windows.Forms.Label lblTilewidth;
		private System.Windows.Forms.Label lblTileheight;
		private System.Windows.Forms.TextBox textBoxColumns;
		private System.Windows.Forms.TextBox textBoxTileWidth;
		private System.Windows.Forms.TextBox textBoxTileHeight;
		private System.Windows.Forms.TextBox textBoxRows;
		private System.Windows.Forms.Button tslCancelButton;
	}
}

