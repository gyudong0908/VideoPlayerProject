namespace 유튜브프로젝트
{
    partial class ItempanelControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Thumbnail = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblChanelName = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblBorder = new System.Windows.Forms.Label();
            this.comboCategori = new System.Windows.Forms.ComboBox();
            this.btnChangeCategori = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // Thumbnail
            // 
            this.Thumbnail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Thumbnail.Location = new System.Drawing.Point(0, 0);
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.Size = new System.Drawing.Size(258, 148);
            this.Thumbnail.TabIndex = 0;
            this.Thumbnail.TabStop = false;
            this.Thumbnail.Click += new System.EventHandler(this.Thumbnail_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(264, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 12);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "제목";
            // 
            // lblChanelName
            // 
            this.lblChanelName.AutoSize = true;
            this.lblChanelName.Location = new System.Drawing.Point(264, 39);
            this.lblChanelName.Name = "lblChanelName";
            this.lblChanelName.Size = new System.Drawing.Size(53, 12);
            this.lblChanelName.TabIndex = 2;
            this.lblChanelName.Text = "채널이름";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(264, 71);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 12);
            this.lblProgress.TabIndex = 3;
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.AutoSize = true;
            this.lblProgressPercent.Location = new System.Drawing.Point(478, 71);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(33, 12);
            this.lblProgressPercent.TabIndex = 5;
            this.lblProgressPercent.Text = "100%";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(536, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 22);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Location = new System.Drawing.Point(-2, 204);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(0, 12);
            this.lblBorder.TabIndex = 7;
            // 
            // comboCategori
            // 
            this.comboCategori.FormattingEnabled = true;
            this.comboCategori.Location = new System.Drawing.Point(266, 118);
            this.comboCategori.Name = "comboCategori";
            this.comboCategori.Size = new System.Drawing.Size(121, 20);
            this.comboCategori.TabIndex = 8;
            // 
            // btnChangeCategori
            // 
            this.btnChangeCategori.Location = new System.Drawing.Point(403, 116);
            this.btnChangeCategori.Name = "btnChangeCategori";
            this.btnChangeCategori.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCategori.TabIndex = 9;
            this.btnChangeCategori.Text = "변경";
            this.btnChangeCategori.UseVisualStyleBackColor = true;
            this.btnChangeCategori.Click += new System.EventHandler(this.btnChangeCategori_Click);
            // 
            // ItempanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChangeCategori);
            this.Controls.Add(this.comboCategori);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblProgressPercent);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblChanelName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Thumbnail);
            this.Name = "ItempanelControl";
            this.Size = new System.Drawing.Size(815, 150);
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Thumbnail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblChanelName;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.ComboBox comboCategori;
        private System.Windows.Forms.Button btnChangeCategori;
    }
}
