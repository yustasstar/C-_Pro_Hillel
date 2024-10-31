namespace TextBoxComboBoxControls
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
            this.components = new System.ComponentModel.Container();
            this.result = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.operation = new System.Windows.Forms.ComboBox();
            this.operand2 = new System.Windows.Forms.TextBox();
            this.operand1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.result.Location = new System.Drawing.Point(229, 26);
            this.result.MinimumSize = new System.Drawing.Size(50, 2);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(50, 15);
            this.result.TabIndex = 9;
            this.toolTip2.SetToolTip(this.result, "Результат");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "=";
            this.toolTip1.SetToolTip(this.button1, "Вычислить результат");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // operation
            // 
            this.operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operation.FormattingEnabled = true;
            this.operation.Location = new System.Drawing.Point(78, 22);
            this.operation.Name = "operation";
            this.operation.Size = new System.Drawing.Size(48, 21);
            this.operation.TabIndex = 7;
            this.toolTip1.SetToolTip(this.operation, "Операция");
            // 
            // operand2
            // 
            this.operand2.Location = new System.Drawing.Point(132, 23);
            this.operand2.Name = "operand2";
            this.operand2.Size = new System.Drawing.Size(48, 20);
            this.operand2.TabIndex = 6;
            this.toolTip1.SetToolTip(this.operand2, "Второй операнд");
            // 
            // operand1
            // 
            this.operand1.Location = new System.Drawing.Point(24, 22);
            this.operand1.Name = "operand1";
            this.operand1.Size = new System.Drawing.Size(48, 20);
            this.operand1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.operand1, "Первый операнд");
            // 
            // toolTip2
            // 
            this.toolTip2.IsBalloon = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 66);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.operation);
            this.Controls.Add(this.operand2);
            this.Controls.Add(this.operand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Простейший калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox operation;
        private System.Windows.Forms.TextBox operand2;
        private System.Windows.Forms.TextBox operand1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

