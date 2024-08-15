
namespace My_Garden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Grass = new System.Windows.Forms.PictureBox();
            this.SG = new System.Windows.Forms.Button();
            this.EX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grass)).BeginInit();
            this.SuspendLayout();
            // 
            // Grass
            // 
            this.Grass.Image = ((System.Drawing.Image)(resources.GetObject("Grass.Image")));
            this.Grass.Location = new System.Drawing.Point(0, 0);
            this.Grass.Name = "Grass";
            this.Grass.Size = new System.Drawing.Size(605, 449);
            this.Grass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Grass.TabIndex = 0;
            this.Grass.TabStop = false;
            // 
            // SG
            // 
            this.SG.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.SG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SG.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SG.Location = new System.Drawing.Point(210, 132);
            this.SG.Name = "SG";
            this.SG.Size = new System.Drawing.Size(175, 66);
            this.SG.TabIndex = 1;
            this.SG.Text = "Start Game";
            this.SG.UseVisualStyleBackColor = true;
            this.SG.Click += new System.EventHandler(this.SG_Click);
            // 
            // EX
            // 
            this.EX.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.EX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EX.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EX.Location = new System.Drawing.Point(210, 246);
            this.EX.Name = "EX";
            this.EX.Size = new System.Drawing.Size(175, 66);
            this.EX.TabIndex = 3;
            this.EX.Text = "EXIT";
            this.EX.UseVisualStyleBackColor = true;
            this.EX.Click += new System.EventHandler(this.EX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(130, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "welcome to My Garden";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EX);
            this.Controls.Add(this.SG);
            this.Controls.Add(this.Grass);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Grass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Grass;
        private System.Windows.Forms.Button SG;
        private System.Windows.Forms.Button EX;
        private System.Windows.Forms.Label label1;
    }
}

