namespace images_from_embedded_resource
{
    partial class MainForm
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
            pictureBox = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonUpArrow = new Button();
            buttonDownArrow = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            tableLayoutPanel1.SetRowSpan(pictureBox, 3);
            pictureBox.Size = new Size(406, 438);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.666666F));
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonUpArrow, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonDownArrow, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(478, 444);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonUpArrow
            // 
            buttonUpArrow.BackColor = Color.Azure;
            buttonUpArrow.Location = new Point(415, 3);
            buttonUpArrow.Name = "buttonUpArrow";
            buttonUpArrow.Size = new Size(60, 34);
            buttonUpArrow.TabIndex = 1;
            buttonUpArrow.UseVisualStyleBackColor = false;
            // 
            // buttonDownArrow
            // 
            buttonDownArrow.BackColor = Color.Azure;
            buttonDownArrow.Location = new Point(415, 407);
            buttonDownArrow.Name = "buttonDownArrow";
            buttonDownArrow.Size = new Size(60, 34);
            buttonDownArrow.TabIndex = 1;
            buttonDownArrow.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 444);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonUpArrow;
        private Button buttonDownArrow;
    }
}