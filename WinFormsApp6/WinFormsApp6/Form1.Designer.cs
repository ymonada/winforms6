namespace WinFormsApp6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            InitButton = new Button();
            RunButtom = new Button();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(68, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1212, 720);
            mainPanel.TabIndex = 0;
            // 
            // InitButton
            // 
            InitButton.Location = new Point(-4, 0);
            InitButton.Name = "InitButton";
            InitButton.Size = new Size(75, 23);
            InitButton.TabIndex = 0;
            InitButton.Text = "Init";
            InitButton.UseVisualStyleBackColor = true;
            InitButton.Click += InitButton_Click;
            // 
            // RunButtom
            // 
            RunButtom.Location = new Point(-2, 23);
            RunButtom.Name = "RunButtom";
            RunButtom.Size = new Size(75, 23);
            RunButtom.TabIndex = 1;
            RunButtom.Text = "Run";
            RunButtom.UseVisualStyleBackColor = true;
            RunButtom.Click += RunButtom_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(RunButtom);
            Controls.Add(InitButton);
            Controls.Add(mainPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button InitButton;
        private Button RunButtom;
    }
}
