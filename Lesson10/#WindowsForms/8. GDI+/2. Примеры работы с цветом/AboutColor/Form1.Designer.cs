namespace WindowsApplication1
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
            this.butStringToColor = new System.Windows.Forms.Button();
            this.butColorToString = new System.Windows.Forms.Button();
            this.butColorToInt = new System.Windows.Forms.Button();
            this.butSetPixel = new System.Windows.Forms.Button();
            this.butDrawPoint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butStringToColor
            // 
            this.butStringToColor.Location = new System.Drawing.Point(11, 56);
            this.butStringToColor.Margin = new System.Windows.Forms.Padding(2);
            this.butStringToColor.Name = "butStringToColor";
            this.butStringToColor.Size = new System.Drawing.Size(96, 50);
            this.butStringToColor.TabIndex = 0;
            this.butStringToColor.Text = "Преобразовать строку в цвет";
            this.butStringToColor.UseVisualStyleBackColor = true;
            this.butStringToColor.Click += new System.EventHandler(this.butStringToColor_Click);
            // 
            // butColorToString
            // 
            this.butColorToString.Location = new System.Drawing.Point(11, 126);
            this.butColorToString.Margin = new System.Windows.Forms.Padding(2);
            this.butColorToString.Name = "butColorToString";
            this.butColorToString.Size = new System.Drawing.Size(96, 40);
            this.butColorToString.TabIndex = 1;
            this.butColorToString.Text = "Преобразовать цвет в строку";
            this.butColorToString.UseVisualStyleBackColor = true;
            this.butColorToString.Click += new System.EventHandler(this.butColorToString_Click);
            // 
            // butColorToInt
            // 
            this.butColorToInt.Location = new System.Drawing.Point(11, 186);
            this.butColorToInt.Margin = new System.Windows.Forms.Padding(2);
            this.butColorToInt.Name = "butColorToInt";
            this.butColorToInt.Size = new System.Drawing.Size(96, 51);
            this.butColorToInt.TabIndex = 2;
            this.butColorToInt.Text = "Преобразуем целое число в цвет";
            this.butColorToInt.UseVisualStyleBackColor = true;
            this.butColorToInt.Click += new System.EventHandler(this.butColorToInt_Click);
            // 
            // butSetPixel
            // 
            this.butSetPixel.Location = new System.Drawing.Point(11, 257);
            this.butSetPixel.Margin = new System.Windows.Forms.Padding(2);
            this.butSetPixel.Name = "butSetPixel";
            this.butSetPixel.Size = new System.Drawing.Size(96, 37);
            this.butSetPixel.TabIndex = 3;
            this.butSetPixel.Text = "Установить цвет";
            this.butSetPixel.UseVisualStyleBackColor = true;
            this.butSetPixel.Click += new System.EventHandler(this.butSetPixel_Click);
            // 
            // butDrawPoint
            // 
            this.butDrawPoint.Location = new System.Drawing.Point(11, 314);
            this.butDrawPoint.Margin = new System.Windows.Forms.Padding(2);
            this.butDrawPoint.Name = "butDrawPoint";
            this.butDrawPoint.Size = new System.Drawing.Size(96, 35);
            this.butDrawPoint.TabIndex = 5;
            this.butDrawPoint.Text = "Нарисовать точку";
            this.butDrawPoint.UseVisualStyleBackColor = true;
            this.butDrawPoint.Click += new System.EventHandler(this.butDrawPoint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsApplication1.Properties.Resources.cat01;
            this.pictureBox1.Location = new System.Drawing.Point(140, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 393);
            this.Controls.Add(this.butDrawPoint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.butSetPixel);
            this.Controls.Add(this.butColorToInt);
            this.Controls.Add(this.butColorToString);
            this.Controls.Add(this.butStringToColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Примеры работы с цветом";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butStringToColor;
        private System.Windows.Forms.Button butColorToString;
        private System.Windows.Forms.Button butColorToInt;
        private System.Windows.Forms.Button butSetPixel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butDrawPoint;
    }
}

