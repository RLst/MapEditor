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
			this.DisplayBox = new System.Windows.Forms.PictureBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.tslLoadButton = new System.Windows.Forms.Button();
			this.lblRows = new System.Windows.Forms.Label();
			this.lblTilewidth = new System.Windows.Forms.Label();
			this.lblTileheight = new System.Windows.Forms.Label();
			this.textBoxRows = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.lblCols = new System.Windows.Forms.Label();
			this.textBoxColumns = new System.Windows.Forms.TextBox();
			this.textBoxTileWidth = new System.Windows.Forms.TextBox();
			this.textBoxTileHeight = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
			this.SuspendLayout();
			// 
			// DisplayBox
			// 
			this.DisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DisplayBox.Location = new System.Drawing.Point(12, 12);
			this.DisplayBox.Name = "DisplayBox";
			this.DisplayBox.Size = new System.Drawing.Size(760, 452);
			this.DisplayBox.TabIndex = 0;
			this.DisplayBox.TabStop = false;
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(606, 470);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(80, 43);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// tslLoadButton
			// 
			this.tslLoadButton.Location = new System.Drawing.Point(520, 470);
			this.tslLoadButton.Name = "tslLoadButton";
			this.tslLoadButton.Size = new System.Drawing.Size(80, 43);
			this.tslLoadButton.TabIndex = 1;
			this.tslLoadButton.Text = "Load tileset...";
			this.tslLoadButton.UseVisualStyleBackColor = true;
			this.tslLoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// lblRows
			// 
			this.lblRows.AutoSize = true;
			this.lblRows.Location = new System.Drawing.Point(17, 485);
			this.lblRows.Name = "lblRows";
			this.lblRows.Size = new System.Drawing.Size(37, 13);
			this.lblRows.TabIndex = 2;
			this.lblRows.Text = "Rows:";
			// 
			// lblTilewidth
			// 
			this.lblTilewidth.AutoSize = true;
			this.lblTilewidth.Location = new System.Drawing.Point(247, 485);
			this.lblTilewidth.Name = "lblTilewidth";
			this.lblTilewidth.Size = new System.Drawing.Size(58, 13);
			this.lblTilewidth.TabIndex = 2;
			this.lblTilewidth.Text = "Tile Width:";
			// 
			// lblTileheight
			// 
			this.lblTileheight.AutoSize = true;
			this.lblTileheight.Location = new System.Drawing.Point(377, 485);
			this.lblTileheight.Name = "lblTileheight";
			this.lblTileheight.Size = new System.Drawing.Size(61, 13);
			this.lblTileheight.TabIndex = 2;
			this.lblTileheight.Text = "Tile Height:";
			// 
			// textBoxRows
			// 
			this.textBoxRows.Location = new System.Drawing.Point(59, 482);
			this.textBoxRows.Name = "textBoxRows";
			this.textBoxRows.Size = new System.Drawing.Size(60, 20);
			this.textBoxRows.TabIndex = 3;
			this.textBoxRows.TextChanged += new System.EventHandler(this.TextBoxRows_TextChanged);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(692, 470);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(80, 43);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// lblCols
			// 
			this.lblCols.AutoSize = true;
			this.lblCols.Location = new System.Drawing.Point(125, 485);
			this.lblCols.Name = "lblCols";
			this.lblCols.Size = new System.Drawing.Size(50, 13);
			this.lblCols.TabIndex = 2;
			this.lblCols.Text = "Columns:";
			// 
			// textBoxColumns
			// 
			this.textBoxColumns.Location = new System.Drawing.Point(181, 482);
			this.textBoxColumns.Name = "textBoxColumns";
			this.textBoxColumns.Size = new System.Drawing.Size(60, 20);
			this.textBoxColumns.TabIndex = 4;
			this.textBoxColumns.TextChanged += new System.EventHandler(this.TextBoxColumns_TextChanged);
			// 
			// textBoxTileWidth
			// 
			this.textBoxTileWidth.Location = new System.Drawing.Point(311, 482);
			this.textBoxTileWidth.Name = "textBoxTileWidth";
			this.textBoxTileWidth.Size = new System.Drawing.Size(60, 20);
			this.textBoxTileWidth.TabIndex = 4;
			this.textBoxTileWidth.TextChanged += new System.EventHandler(this.TextBoxTileWidth_TextChanged);
			// 
			// textBoxTileHeight
			// 
			this.textBoxTileHeight.Location = new System.Drawing.Point(444, 482);
			this.textBoxTileHeight.Name = "textBoxTileHeight";
			this.textBoxTileHeight.Size = new System.Drawing.Size(60, 20);
			this.textBoxTileHeight.TabIndex = 4;
			this.textBoxTileHeight.TextChanged += new System.EventHandler(this.TextBoxTileHeight_TextChanged);
			// 
			// TilesetLoaderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 520);
			this.Controls.Add(this.textBoxTileHeight);
			this.Controls.Add(this.textBoxTileWidth);
			this.Controls.Add(this.textBoxColumns);
			this.Controls.Add(this.textBoxRows);
			this.Controls.Add(this.lblTileheight);
			this.Controls.Add(this.lblTilewidth);
			this.Controls.Add(this.lblRows);
			this.Controls.Add(this.lblCols);
			this.Controls.Add(this.tslLoadButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.DisplayBox);
			this.Name = "TilesetLoaderForm";
			this.Text = "Tileset Loader";
			this.Load += new System.EventHandler(this.TilesetLoaderForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.PictureBox DisplayBox;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button tslLoadButton;
		private System.Windows.Forms.Label lblRows;
		private System.Windows.Forms.Label lblTilewidth;
		private System.Windows.Forms.Label lblTileheight;
		private System.Windows.Forms.TextBox textBoxRows;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label lblCols;
		private System.Windows.Forms.TextBox textBoxColumns;
		private System.Windows.Forms.TextBox textBoxTileWidth;
		private System.Windows.Forms.TextBox textBoxTileHeight;
	}
}

