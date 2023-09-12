namespace 유튜브프로젝트
{
    partial class CategoriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textnsertCategori = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboCategori = new System.Windows.Forms.ComboBox();
            this.btnInsertCategori = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "카테고리를 선택해 주세요";
            // 
            // textnsertCategori
            // 
            this.textnsertCategori.Location = new System.Drawing.Point(12, 64);
            this.textnsertCategori.Name = "textnsertCategori";
            this.textnsertCategori.Size = new System.Drawing.Size(138, 21);
            this.textnsertCategori.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboCategori
            // 
            this.comboCategori.FormattingEnabled = true;
            this.comboCategori.Location = new System.Drawing.Point(239, 30);
            this.comboCategori.Name = "comboCategori";
            this.comboCategori.Size = new System.Drawing.Size(121, 20);
            this.comboCategori.TabIndex = 3;
            // 
            // btnInsertCategori
            // 
            this.btnInsertCategori.Location = new System.Drawing.Point(158, 62);
            this.btnInsertCategori.Name = "btnInsertCategori";
            this.btnInsertCategori.Size = new System.Drawing.Size(75, 23);
            this.btnInsertCategori.TabIndex = 4;
            this.btnInsertCategori.Text = "추가";
            this.btnInsertCategori.UseVisualStyleBackColor = true;
            this.btnInsertCategori.Click += new System.EventHandler(this.btnInsertCategori_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(239, 62);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CategoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 106);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsertCategori);
            this.Controls.Add(this.comboCategori);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textnsertCategori);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoriForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categori";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CategoriForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textnsertCategori;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboCategori;
        private System.Windows.Forms.Button btnInsertCategori;
        private System.Windows.Forms.Button btnDelete;
    }
}