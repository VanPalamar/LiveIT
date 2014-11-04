namespace LiveIT2._1
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
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._waterButton = new System.Windows.Forms.Button();
            this._dirtButton = new System.Windows.Forms.Button();
            this._snowButton = new System.Windows.Forms.Button();
            this._desertButton = new System.Windows.Forms.Button();
            this._grassButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _waterButton
            // 
            this._waterButton.Location = new System.Drawing.Point(13, 85);
            this._waterButton.Name = "_waterButton";
            this._waterButton.Size = new System.Drawing.Size(75, 23);
            this._waterButton.TabIndex = 0;
            this._waterButton.Text = "Water";
            this._waterButton.UseVisualStyleBackColor = true;
            this._waterButton.Click += new System.EventHandler(this._waterButton_Click);
            // 
            // _dirtButton
            // 
            this._dirtButton.Location = new System.Drawing.Point(13, 135);
            this._dirtButton.Name = "_dirtButton";
            this._dirtButton.Size = new System.Drawing.Size(75, 23);
            this._dirtButton.TabIndex = 1;
            this._dirtButton.Text = "Dirt";
            this._dirtButton.UseVisualStyleBackColor = true;
            this._dirtButton.Click += new System.EventHandler(this._dirtButton_Click);
            // 
            // _snowButton
            // 
            this._snowButton.Location = new System.Drawing.Point(13, 186);
            this._snowButton.Name = "_snowButton";
            this._snowButton.Size = new System.Drawing.Size(75, 23);
            this._snowButton.TabIndex = 2;
            this._snowButton.Text = "Snow";
            this._snowButton.UseVisualStyleBackColor = true;
            this._snowButton.Click += new System.EventHandler(this._snowButton_Click);
            // 
            // _desertButton
            // 
            this._desertButton.Location = new System.Drawing.Point(13, 236);
            this._desertButton.Name = "_desertButton";
            this._desertButton.Size = new System.Drawing.Size(75, 23);
            this._desertButton.TabIndex = 3;
            this._desertButton.Text = "Desert";
            this._desertButton.UseVisualStyleBackColor = true;
            this._desertButton.Click += new System.EventHandler(this._desertButton_Click);
            // 
            // _grassButton
            // 
            this._grassButton.Location = new System.Drawing.Point(13, 286);
            this._grassButton.Name = "_grassButton";
            this._grassButton.Size = new System.Drawing.Size(75, 23);
            this._grassButton.TabIndex = 4;
            this._grassButton.Text = "Grass";
            this._grassButton.UseVisualStyleBackColor = true;
            this._grassButton.Click += new System.EventHandler(this._grassButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 962);
            this.Controls.Add(this._grassButton);
            this.Controls.Add(this._desertButton);
            this.Controls.Add(this._snowButton);
            this.Controls.Add(this._dirtButton);
            this.Controls.Add(this._waterButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _waterButton;
        private System.Windows.Forms.Button _dirtButton;
        private System.Windows.Forms.Button _snowButton;
        private System.Windows.Forms.Button _desertButton;
        private System.Windows.Forms.Button _grassButton;

    }
}

