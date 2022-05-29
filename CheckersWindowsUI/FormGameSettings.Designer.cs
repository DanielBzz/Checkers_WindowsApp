
namespace CheckersWindowsUI
{
    public partial class FormGameSettings
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
            this.radioButton6x6Size = new System.Windows.Forms.RadioButton();
            this.radioButton8x8Size = new System.Windows.Forms.RadioButton();
            this.radioButton10x10Size = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton6x6Size
            // 
            this.radioButton6x6Size.AutoSize = true;
            this.radioButton6x6Size.Location = new System.Drawing.Point(57, 59);
            this.radioButton6x6Size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton6x6Size.Name = "radioButton6x6Size";
            this.radioButton6x6Size.Size = new System.Drawing.Size(51, 21);
            this.radioButton6x6Size.TabIndex = 0;
            this.radioButton6x6Size.TabStop = true;
            this.radioButton6x6Size.Text = "6x6";
            this.radioButton6x6Size.UseVisualStyleBackColor = true;
            this.radioButton6x6Size.CheckedChanged += new System.EventHandler(this.radioButton6x6Size_CheckedChanged);
            // 
            // radioButton8x8Size
            // 
            this.radioButton8x8Size.AutoSize = true;
            this.radioButton8x8Size.Location = new System.Drawing.Point(158, 59);
            this.radioButton8x8Size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton8x8Size.Name = "radioButton8x8Size";
            this.radioButton8x8Size.Size = new System.Drawing.Size(51, 21);
            this.radioButton8x8Size.TabIndex = 1;
            this.radioButton8x8Size.TabStop = true;
            this.radioButton8x8Size.Text = "8x8";
            this.radioButton8x8Size.UseVisualStyleBackColor = true;
            this.radioButton8x8Size.CheckedChanged += new System.EventHandler(this.radioButton8x8Size_CheckedChanged);
            // 
            // radioButton10x10Size
            // 
            this.radioButton10x10Size.AutoSize = true;
            this.radioButton10x10Size.Location = new System.Drawing.Point(268, 59);
            this.radioButton10x10Size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton10x10Size.Name = "radioButton10x10Size";
            this.radioButton10x10Size.Size = new System.Drawing.Size(67, 21);
            this.radioButton10x10Size.TabIndex = 2;
            this.radioButton10x10Size.TabStop = true;
            this.radioButton10x10Size.Text = "10x10";
            this.radioButton10x10Size.UseVisualStyleBackColor = true;
            this.radioButton10x10Size.CheckedChanged += new System.EventHandler(this.radioButton10x10Size_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Board Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Players";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 1";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(57, 170);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(82, 21);
            this.checkBoxPlayer2.TabIndex = 7;
            this.checkBoxPlayer2.Text = "Player 2";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(170, 136);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(167, 22);
            this.textBoxPlayer1.TabIndex = 8;
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Location = new System.Drawing.Point(170, 168);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.ReadOnly = true;
            this.textBoxPlayer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPlayer2.Size = new System.Drawing.Size(167, 22);
            this.textBoxPlayer2.TabIndex = 9;
            this.textBoxPlayer2.Text = "[ Computer ]";
            this.textBoxPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(257, 215);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(79, 30);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.PropertyPage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 258);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton10x10Size);
            this.Controls.Add(this.radioButton8x8Size);
            this.Controls.Add(this.radioButton6x6Size);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormGameSettings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton6x6Size;
        private System.Windows.Forms.RadioButton radioButton8x8Size;
        private System.Windows.Forms.RadioButton radioButton10x10Size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Button buttonDone;
    }
}