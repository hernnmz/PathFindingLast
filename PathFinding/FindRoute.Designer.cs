namespace PathFinding
{
    partial class FindRoute
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
            this.btnFileUpload = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbPathNodes = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFoleUpload
            // 
            this.btnFileUpload.Location = new System.Drawing.Point(12, 373);
            this.btnFileUpload.Name = "btnFoleUpload";
            this.btnFileUpload.Size = new System.Drawing.Size(75, 23);
            this.btnFileUpload.TabIndex = 0;
            this.btnFileUpload.Text = "Upload";
            this.btnFileUpload.UseVisualStyleBackColor = true;
            this.btnFileUpload.Click += new System.EventHandler(this.BtnFileUpload_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(93, 373);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // tbPathNodes
            // 
            this.tbPathNodes.Location = new System.Drawing.Point(12, 58);
            this.tbPathNodes.Multiline = true;
            this.tbPathNodes.Name = "tbPathNodes";
            this.tbPathNodes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPathNodes.Size = new System.Drawing.Size(881, 309);
            this.tbPathNodes.TabIndex = 2;
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoute.Location = new System.Drawing.Point(313, 9);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(291, 36);
            this.lblRoute.TabIndex = 3;
            this.lblRoute.Text = "The Longest Road";
            // 
            // FindRoute
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(905, 409);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.tbPathNodes);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnFileUpload);
            this.Name = "FindRoute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.TextBox textBoxNodes;
        //private System.Windows.Forms.Button btnFileUpload;
        //private System.Windows.Forms.Button btnGo;
        //private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFileUpload;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbPathNodes;
        private System.Windows.Forms.Label lblRoute;
    }
}