
namespace ScreenSaver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PictureFrame = new System.Windows.Forms.PictureBox();
            this.PauseCheckbox = new System.Windows.Forms.CheckBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RightArrowButton = new System.Windows.Forms.Button();
            this.LeftArrowButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ImageSpeed = new System.Windows.Forms.HScrollBar();
            this.FileNameTextBox = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureFrame
            // 
            this.PictureFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureFrame.Location = new System.Drawing.Point(11, 110);
            this.PictureFrame.Margin = new System.Windows.Forms.Padding(2);
            this.PictureFrame.Name = "PictureFrame";
            this.PictureFrame.Size = new System.Drawing.Size(1357, 614);
            this.PictureFrame.TabIndex = 0;
            this.PictureFrame.TabStop = false;
            // 
            // PauseCheckbox
            // 
            this.PauseCheckbox.AutoSize = true;
            this.PauseCheckbox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PauseCheckbox.Location = new System.Drawing.Point(8, 32);
            this.PauseCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.PauseCheckbox.Name = "PauseCheckbox";
            this.PauseCheckbox.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.PauseCheckbox.Size = new System.Drawing.Size(91, 34);
            this.PauseCheckbox.TabIndex = 2;
            this.PauseCheckbox.Text = "Pause";
            this.PauseCheckbox.UseVisualStyleBackColor = true;
            this.PauseCheckbox.Click += new System.EventHandler(this.PauseCheckboxClicked);
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.Location = new System.Drawing.Point(0, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(1589, 33);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExitScreenSaver);
            // 
            // RightArrowButton
            // 
            this.RightArrowButton.Image = ((System.Drawing.Image)(resources.GetObject("RightArrowButton.Image")));
            this.RightArrowButton.Location = new System.Drawing.Point(266, 37);
            this.RightArrowButton.Margin = new System.Windows.Forms.Padding(2);
            this.RightArrowButton.Name = "RightArrowButton";
            this.RightArrowButton.Size = new System.Drawing.Size(81, 20);
            this.RightArrowButton.TabIndex = 4;
            this.RightArrowButton.UseVisualStyleBackColor = true;
            this.RightArrowButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GoRightButton);
            // 
            // LeftArrowButton
            // 
            this.LeftArrowButton.Image = ((System.Drawing.Image)(resources.GetObject("LeftArrowButton.Image")));
            this.LeftArrowButton.Location = new System.Drawing.Point(191, 37);
            this.LeftArrowButton.Margin = new System.Windows.Forms.Padding(2);
            this.LeftArrowButton.Name = "LeftArrowButton";
            this.LeftArrowButton.Size = new System.Drawing.Size(73, 20);
            this.LeftArrowButton.TabIndex = 5;
            this.LeftArrowButton.UseVisualStyleBackColor = true;
            this.LeftArrowButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GoLeftButton);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.Location = new System.Drawing.Point(102, 31);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(85, 35);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeletePhoto);
            // 
            // ImageSpeed
            // 
            this.ImageSpeed.LargeChange = 1;
            this.ImageSpeed.Location = new System.Drawing.Point(357, 32);
            this.ImageSpeed.Maximum = 10;
            this.ImageSpeed.Name = "ImageSpeed";
            this.ImageSpeed.Size = new System.Drawing.Size(84, 34);
            this.ImageSpeed.TabIndex = 7;
            this.ImageSpeed.Value = 5;
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileNameTextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FileNameTextBox.Location = new System.Drawing.Point(0, 849);
            this.FileNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(1589, 41);
            this.FileNameTextBox.TabIndex = 8;
            this.FileNameTextBox.Text = "";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Please Select Photo Folder";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.UseDescriptionForTitle = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1589, 890);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.ImageSpeed);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.LeftArrowButton);
            this.Controls.Add(this.RightArrowButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PauseCheckbox);
            this.Controls.Add(this.PictureFrame);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Steve\'s Screen Saver";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureFrame;
        private System.Windows.Forms.CheckBox PauseCheckbox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RightArrowButton;
        private System.Windows.Forms.Button LeftArrowButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.HScrollBar ImageSpeed;
        private System.Windows.Forms.RichTextBox FileNameTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

