using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ApachePathSwitch
{
    public partial class ProjectSelector : Form
    {
        #region Parâmetros

        private string porta;
        private string projeto;
        private string caminhoXampp;
        private string caminhoProjetos;

        #endregion

        #region Construtor

        public ProjectSelector()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos Privados

        private void AtualizaCampos()
        {
            txtXampp.Text = string.IsNullOrWhiteSpace(caminhoXampp) ? string.Empty : caminhoXampp;
            txtProjetos.Text = string.IsNullOrWhiteSpace(caminhoProjetos) ? string.Empty : caminhoProjetos;

            if (ValidaCampos())
                btnSalvar.Enabled = true;
        }

        private void PreencheComboBox()
        {
            cmbProjetos.Items.Clear();

            string[] pastas = Directory.GetDirectories(caminhoProjetos);

            foreach (string pasta in pastas)
                cmbProjetos.Items.Add(RemovePrefixo(pasta));
        }

        private void SalvaXML()
        {
            try
            {
                using (DataSet dsResultado = new DataSet())
                {
                    if(File.Exists("config.xml"))
                        dsResultado.ReadXml("config.xml");

                    if (dsResultado.Tables?.Count == 0)
                    {
                        XmlTextWriter writer = new XmlTextWriter("config.xml", System.Text.Encoding.UTF8);

                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;

                        writer.WriteStartElement("Config");

                        writer.WriteStartElement("CaminhoXampp");
                        writer.WriteString(caminhoXampp);
                        writer.WriteEndElement();

                        writer.WriteStartElement("CaminhoProjetos");
                        writer.WriteString(caminhoProjetos);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Porta");
                        writer.WriteString(porta);
                        writer.WriteEndElement();

                        writer.WriteEndDocument();

                        writer.Close();
                        dsResultado.ReadXml("config.xml");
                    }
                    else
                    {
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["CaminhoXampp"] = caminhoXampp;
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["CaminhoProjetos"] = caminhoProjetos;
                        dsResultado.AcceptChanges();

                        dsResultado.WriteXml("config.xml");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar XML: \n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaXML()
        {
            try
            {
                using (DataSet dsResultado = new DataSet())
                {
                    dsResultado.ReadXml("config.xml");
                    if (dsResultado.Tables.Count != 0)
                    {
                        caminhoXampp = dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["CaminhoXampp"].ToString();
                        caminhoProjetos = dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["CaminhoProjetos"].ToString();

                        AtualizaCampos();
                        PreencheComboBox();
                    }
                }
            }
            catch
            {

            }
        }

        private void SalvaCaminho()
        {
            try
            {
                string caminhoConf = $@"{caminhoXampp}\apache\conf\httpd.conf";
                string caminhoProjeto = $@"{caminhoProjetos}\{projeto}";

                string[] lines = File.ReadAllLines(caminhoConf);

                using (StreamWriter writer = new StreamWriter(caminhoConf))
                {
                    bool edita = false;

                    foreach (string line in lines)
                    {
                        if (line.ToString().StartsWith("DocumentRoot"))
                        {
                            writer.WriteLine($"DocumentRoot \"{caminhoProjeto}\"");

                            edita = true;
                        }
                        else if (edita)
                        {
                            writer.WriteLine($"<Directory \"{caminhoProjeto}\">");

                            edita = false;
                        }
                        else
                        {
                            writer.WriteLine(line.ToString());
                        }
                    }
                }

                MessageBox.Show("Caminho alterado com sucesso");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private bool ValidaCampos() => !string.IsNullOrWhiteSpace(txtXampp.Text)
                                    && !string.IsNullOrWhiteSpace(txtProjetos.Text)
                                    && !string.IsNullOrWhiteSpace(cmbProjetos.Text)
                                    && !string.IsNullOrWhiteSpace(txtPorta.Text);

        private string SelecionaPasta()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                    return fbd.SelectedPath;
                else
                    return null;
            }
        }

        private string RemovePrefixo(string caminho) => caminho.Replace($@"{caminhoProjetos}\", string.Empty);

        #endregion

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaXML();
        }

        private void BtnXampp_Click(object sender, EventArgs e)
        {
            caminhoXampp = SelecionaPasta();

            AtualizaCampos();
            PreencheComboBox();
        }

        private void BtnProjetos_Click(object sender, EventArgs e)
        {
            caminhoProjetos = SelecionaPasta();

            AtualizaCampos();
            PreencheComboBox();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"{caminhoXampp}/apache_stop.bat");
            SalvaCaminho();
            SalvaXML();
            System.Diagnostics.Process.Start($"http://localhost:{porta}");
        }

        private void CmbProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaCampos();

            projeto = cmbProjetos.Text;
        }

        #endregion
    }
}
