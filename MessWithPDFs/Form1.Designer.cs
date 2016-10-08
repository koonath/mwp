namespace MessWithPDFs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ActionBox = new System.Windows.Forms.ComboBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.InstructionsLabel2 = new System.Windows.Forms.Label();
            this.DestinationFilePathTextBox = new System.Windows.Forms.TextBox();
            this.InstructionsLabel1 = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RemoveAllButton = new System.Windows.Forms.Button();
            this.PathsListBox = new System.Windows.Forms.ListBox();
            this.HidePathsButton = new System.Windows.Forms.Button();
            this.StampFileBox = new System.Windows.Forms.ListBox();
            this.RemoveImageButton = new System.Windows.Forms.Button();
            this.StampAllButton = new System.Windows.Forms.RadioButton();
            this.StampLastPageButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ActionBox
            // 
            this.ActionBox.FormattingEnabled = true;
            this.ActionBox.Items.AddRange(new object[] {
            "Select action...",
            "Merge PDFs",
            "Explode PDFs",
            "Stamp PDFs",
            "Extract Pages",
            "3D PDFs"});
            this.ActionBox.Location = new System.Drawing.Point(4, 12);
            this.ActionBox.Name = "ActionBox";
            this.ActionBox.Size = new System.Drawing.Size(121, 21);
            this.ActionBox.TabIndex = 0;
            this.ActionBox.Text = "Select action...";
            this.ActionBox.SelectedIndexChanged += new System.EventHandler(this.ActionBox_SelectedIndexChanged);
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(696, 466);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 23);
            this.GoButton.TabIndex = 2;
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Visible = false;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // InstructionsLabel2
            // 
            this.InstructionsLabel2.AutoSize = true;
            this.InstructionsLabel2.Location = new System.Drawing.Point(1, 424);
            this.InstructionsLabel2.Name = "InstructionsLabel2";
            this.InstructionsLabel2.Size = new System.Drawing.Size(0, 13);
            this.InstructionsLabel2.TabIndex = 6;
            this.InstructionsLabel2.Visible = false;
            // 
            // DestinationFilePathTextBox
            // 
            this.DestinationFilePathTextBox.Location = new System.Drawing.Point(4, 440);
            this.DestinationFilePathTextBox.Name = "DestinationFilePathTextBox";
            this.DestinationFilePathTextBox.Size = new System.Drawing.Size(767, 20);
            this.DestinationFilePathTextBox.TabIndex = 5;
            this.DestinationFilePathTextBox.Visible = false;
            this.DestinationFilePathTextBox.TextChanged += new System.EventHandler(this.DestinationFilePathTextBox_TextChanged);
            // 
            // InstructionsLabel1
            // 
            this.InstructionsLabel1.AutoSize = true;
            this.InstructionsLabel1.Location = new System.Drawing.Point(1, 49);
            this.InstructionsLabel1.Name = "InstructionsLabel1";
            this.InstructionsLabel1.Size = new System.Drawing.Size(0, 13);
            this.InstructionsLabel1.TabIndex = 8;
            this.InstructionsLabel1.Visible = false;
            // 
            // FileNameBox
            // 
            this.FileNameBox.AllowDrop = true;
            this.FileNameBox.FormattingEnabled = true;
            this.FileNameBox.HorizontalScrollbar = true;
            this.FileNameBox.Location = new System.Drawing.Point(4, 65);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(191, 290);
            this.FileNameBox.TabIndex = 9;
            this.FileNameBox.Visible = false;
            this.FileNameBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileNameBox_DragDrop);
            this.FileNameBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileNameBox_DragEnter);
            this.FileNameBox.DragOver += new System.Windows.Forms.DragEventHandler(this.FileNameBox_DragOver);
            this.FileNameBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FileNameBox_MouseDown);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(4, 361);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 10;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Visible = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.Location = new System.Drawing.Point(85, 361);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveAllButton.TabIndex = 11;
            this.RemoveAllButton.Text = "Remove All";
            this.RemoveAllButton.UseVisualStyleBackColor = true;
            this.RemoveAllButton.Visible = false;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // PathsListBox
            // 
            this.PathsListBox.AllowDrop = true;
            this.PathsListBox.FormattingEnabled = true;
            this.PathsListBox.HorizontalScrollbar = true;
            this.PathsListBox.Location = new System.Drawing.Point(201, 65);
            this.PathsListBox.Name = "PathsListBox";
            this.PathsListBox.Size = new System.Drawing.Size(570, 290);
            this.PathsListBox.TabIndex = 12;
            this.PathsListBox.Visible = false;
            this.PathsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PathsListBox_DragDrop);
            this.PathsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PathsListBox_DragEnter);
            this.PathsListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.PathsListBox_DragOver);
            this.PathsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PathsListBox_MouseDown);
            // 
            // HidePathsButton
            // 
            this.HidePathsButton.Location = new System.Drawing.Point(201, 361);
            this.HidePathsButton.Name = "HidePathsButton";
            this.HidePathsButton.Size = new System.Drawing.Size(75, 23);
            this.HidePathsButton.TabIndex = 13;
            this.HidePathsButton.UseVisualStyleBackColor = true;
            this.HidePathsButton.Visible = false;
            this.HidePathsButton.Click += new System.EventHandler(this.HidePathsButton_Click);
            // 
            // StampFileBox
            // 
            this.StampFileBox.AllowDrop = true;
            this.StampFileBox.FormattingEnabled = true;
            this.StampFileBox.HorizontalScrollbar = true;
            this.StampFileBox.Location = new System.Drawing.Point(201, 394);
            this.StampFileBox.Name = "StampFileBox";
            this.StampFileBox.Size = new System.Drawing.Size(489, 43);
            this.StampFileBox.TabIndex = 14;
            this.StampFileBox.Visible = false;
            this.StampFileBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.StampFileBox_DragDrop);
            this.StampFileBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.StampFileBox_DragEnter);
            this.StampFileBox.DragOver += new System.Windows.Forms.DragEventHandler(this.StampFileBox_DragOver);
            this.StampFileBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StampFileBox_MouseDown);
            // 
            // RemoveImageButton
            // 
            this.RemoveImageButton.Location = new System.Drawing.Point(696, 414);
            this.RemoveImageButton.Name = "RemoveImageButton";
            this.RemoveImageButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveImageButton.TabIndex = 15;
            this.RemoveImageButton.Text = "Remove";
            this.RemoveImageButton.UseVisualStyleBackColor = true;
            this.RemoveImageButton.Visible = false;
            this.RemoveImageButton.Click += new System.EventHandler(this.RemoveImageButton_Click);
            // 
            // StampAllButton
            // 
            this.StampAllButton.AutoSize = true;
            this.StampAllButton.Location = new System.Drawing.Point(454, 371);
            this.StampAllButton.Name = "StampAllButton";
            this.StampAllButton.Size = new System.Drawing.Size(102, 17);
            this.StampAllButton.TabIndex = 16;
            this.StampAllButton.TabStop = true;
            this.StampAllButton.Text = "Stamp All Pages";
            this.StampAllButton.UseVisualStyleBackColor = true;
            // 
            // StampLastPageButton
            // 
            this.StampLastPageButton.AutoSize = true;
            this.StampLastPageButton.Location = new System.Drawing.Point(562, 371);
            this.StampLastPageButton.Name = "StampLastPageButton";
            this.StampLastPageButton.Size = new System.Drawing.Size(128, 17);
            this.StampLastPageButton.TabIndex = 17;
            this.StampLastPageButton.TabStop = true;
            this.StampLastPageButton.Text = "Stamp Last Page only";
            this.StampLastPageButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(775, 495);
            this.Controls.Add(this.StampLastPageButton);
            this.Controls.Add(this.StampAllButton);
            this.Controls.Add(this.RemoveImageButton);
            this.Controls.Add(this.StampFileBox);
            this.Controls.Add(this.HidePathsButton);
            this.Controls.Add(this.PathsListBox);
            this.Controls.Add(this.RemoveAllButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.FileNameBox);
            this.Controls.Add(this.InstructionsLabel1);
            this.Controls.Add(this.InstructionsLabel2);
            this.Controls.Add(this.DestinationFilePathTextBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.ActionBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mess with PDFs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ActionBox;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label InstructionsLabel2;
        private System.Windows.Forms.TextBox DestinationFilePathTextBox;
        private System.Windows.Forms.Label InstructionsLabel1;
        private System.Windows.Forms.ListBox FileNameBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button RemoveAllButton;
        private System.Windows.Forms.ListBox PathsListBox;
        private System.Windows.Forms.Button HidePathsButton;
        private System.Windows.Forms.ListBox StampFileBox;
        private System.Windows.Forms.Button RemoveImageButton;
        private System.Windows.Forms.RadioButton StampAllButton;
        private System.Windows.Forms.RadioButton StampLastPageButton;

    }
}

