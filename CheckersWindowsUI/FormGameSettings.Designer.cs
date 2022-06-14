
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
            this.radioButtonSmallSize = new System.Windows.Forms.RadioButton();
            this.radioButtonMediumSize = new System.Windows.Forms.RadioButton();
            this.radioButtonLargeSize = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonSmallSize
            // 
            this.radioButtonSmallSize.AutoSize = true;
            this.radioButtonSmallSize.Location = new System.Drawing.Point(64, 74);
            this.radioButtonSmallSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSmallSize.Name = "radioButtonSmallSize";
            this.radioButtonSmallSize.Size = new System.Drawing.Size(56, 24);
            this.radioButtonSmallSize.TabIndex = 0;
            this.radioButtonSmallSize.TabStop = true;
            this.radioButtonSmallSize.Text = "6x6";
            this.radioButtonSmallSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonMediumSize
            // 
            this.radioButtonMediumSize.AutoSize = true;
            this.radioButtonMediumSize.Location = new System.Drawing.Point(178, 74);
            this.radioButtonMediumSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonMediumSize.Name = "radioButtonMediumSize";
            this.radioButtonMediumSize.Size = new System.Drawing.Size(56, 24);
            this.radioButtonMediumSize.TabIndex = 1;
            this.radioButtonMediumSize.TabStop = true;
            this.radioButtonMediumSize.Text = "8x8";
            this.radioButtonMediumSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonLargeSize
            // 
            this.radioButtonLargeSize.AutoSize = true;
            this.radioButtonLargeSize.Location = new System.Drawing.Point(302, 74);
            this.radioButtonLargeSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonLargeSize.Name = "radioButtonLargeSize";
            this.radioButtonLargeSize.Size = new System.Drawing.Size(74, 24);
            this.radioButtonLargeSize.TabIndex = 2;
            this.radioButtonLargeSize.TabStop = true;
            this.radioButtonLargeSize.Text = "10x10";
            this.radioButtonLargeSize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Board Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(32, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Players";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 1";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(64, 212);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(92, 24);
            this.checkBoxPlayer2.TabIndex = 7;
            this.checkBoxPlayer2.Text = "Player 2";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(191, 170);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(187, 26);
            this.textBoxPlayer1.TabIndex = 8;
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Location = new System.Drawing.Point(191, 210);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.ReadOnly = true;
            this.textBoxPlayer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPlayer2.Size = new System.Drawing.Size(187, 26);
            this.textBoxPlayer2.TabIndex = 9;
            this.textBoxPlayer2.Text = "Computer";
            this.textBoxPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(289, 269);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(89, 38);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.PropertyPage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 322);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonLargeSize);
            this.Controls.Add(this.radioButtonMediumSize);
            this.Controls.Add(this.radioButtonSmallSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormGameSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonSmallSize;
        private System.Windows.Forms.RadioButton radioButtonMediumSize;
        private System.Windows.Forms.RadioButton radioButtonLargeSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Button buttonDone;
    }
}