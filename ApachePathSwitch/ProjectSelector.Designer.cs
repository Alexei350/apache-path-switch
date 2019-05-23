namespace ApachePathSwitch
{
    partial class ProjectSelector
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSelector));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnProjetos = new System.Windows.Forms.Button();
            this.txtProjetos = new System.Windows.Forms.TextBox();
            this.cmbProjetos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXampp = new System.Windows.Forms.Button();
            this.txtXampp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(290, 119);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnProjetos
            // 
            this.btnProjetos.Location = new System.Drawing.Point(11, 42);
            this.btnProjetos.Name = "btnProjetos";
            this.btnProjetos.Size = new System.Drawing.Size(106, 23);
            this.btnProjetos.TabIndex = 1;
            this.btnProjetos.Text = "Localizar Projetos";
            this.btnProjetos.UseVisualStyleBackColor = true;
            this.btnProjetos.Click += new System.EventHandler(this.BtnProjetos_Click);
            // 
            // txtProjetos
            // 
            this.txtProjetos.Enabled = false;
            this.txtProjetos.Location = new System.Drawing.Point(123, 45);
            this.txtProjetos.Name = "txtProjetos";
            this.txtProjetos.Size = new System.Drawing.Size(230, 20);
            this.txtProjetos.TabIndex = 2;
            // 
            // cmbProjetos
            // 
            this.cmbProjetos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjetos.FormattingEnabled = true;
            this.cmbProjetos.Location = new System.Drawing.Point(135, 92);
            this.cmbProjetos.Name = "cmbProjetos";
            this.cmbProjetos.Size = new System.Drawing.Size(230, 21);
            this.cmbProjetos.TabIndex = 3;
            this.cmbProjetos.SelectedIndexChanged += new System.EventHandler(this.CmbProjetos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Projeto:";
            // 
            // btnXampp
            // 
            this.btnXampp.Location = new System.Drawing.Point(11, 16);
            this.btnXampp.Name = "btnXampp";
            this.btnXampp.Size = new System.Drawing.Size(106, 23);
            this.btnXampp.TabIndex = 1;
            this.btnXampp.Text = "Localizar Xampp";
            this.btnXampp.UseVisualStyleBackColor = true;
            this.btnXampp.Click += new System.EventHandler(this.BtnXampp_Click);
            // 
            // txtXampp
            // 
            this.txtXampp.Enabled = false;
            this.txtXampp.Location = new System.Drawing.Point(123, 19);
            this.txtXampp.Name = "txtXampp";
            this.txtXampp.Size = new System.Drawing.Size(230, 20);
            this.txtXampp.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtXampp);
            this.groupBox1.Controls.Add(this.btnXampp);
            this.groupBox1.Controls.Add(this.txtProjetos);
            this.groupBox1.Controls.Add(this.btnProjetos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações";
            // 
            // ProjectSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 160);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProjetos);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProjectSelector";
            this.Text = "Troca de Projetos do Apache";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnProjetos;
        private System.Windows.Forms.TextBox txtProjetos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProjetos;
        private System.Windows.Forms.TextBox txtXampp;
        private System.Windows.Forms.Button btnXampp;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

