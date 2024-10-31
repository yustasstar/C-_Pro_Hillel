namespace ListviewExample
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.режимыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.большиеЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.малыеЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // режимыToolStripMenuItem
            // 
            this.режимыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаToolStripMenuItem,
            this.большиеЗначкиToolStripMenuItem,
            this.малыеЗначкиToolStripMenuItem});
            this.режимыToolStripMenuItem.Name = "режимыToolStripMenuItem";
            this.режимыToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.режимыToolStripMenuItem.Text = "Режимы";
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.таблицаToolStripMenuItem.Text = "Таблица";
            this.таблицаToolStripMenuItem.Click += new System.EventHandler(this.таблицаToolStripMenuItem_Click);
            // 
            // большиеЗначкиToolStripMenuItem
            // 
            this.большиеЗначкиToolStripMenuItem.Name = "большиеЗначкиToolStripMenuItem";
            this.большиеЗначкиToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.большиеЗначкиToolStripMenuItem.Text = "Большие значки";
            this.большиеЗначкиToolStripMenuItem.Click += new System.EventHandler(this.большиеЗначкиToolStripMenuItem_Click);
            // 
            // малыеЗначкиToolStripMenuItem
            // 
            this.малыеЗначкиToolStripMenuItem.Name = "малыеЗначкиToolStripMenuItem";
            this.малыеЗначкиToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.малыеЗначкиToolStripMenuItem.Text = "Малые значки";
            this.малыеЗначкиToolStripMenuItem.Click += new System.EventHandler(this.малыеЗначкиToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ListView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem режимыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem большиеЗначкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem малыеЗначкиToolStripMenuItem;
    }
}

