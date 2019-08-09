using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Empresas
{
    public partial class frm_crud : Form
    {
        public frm_crud()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dataHora = DateTime.Now;
            lbDateTime.Text = "Data: " + dataHora.ToShortDateString() + " Hora:" + dataHora.ToLongTimeString(); 
         }

        private void frm_crud_Load(object sender, EventArgs e)
        {
            timer1_Tick(e, e);
        }
            
        private void frm_Crud_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja sair do Sistema?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
             
        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                       
        private void btAdd_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            ArrayList arr = new ArrayList();
            try
            {

                arr.Add(tbCad_nome.Text);
                arr.Add(tbCad_rs.Text);
                arr.Add(tbCad_cnpj.Text);
                arr.Add(tbCad_endereco.Text);
                arr.Add(cbCadCidade.Text);
                arr.Add(cbCadUF.Text);
                arr.Add(tbCad_telefone.Text);
                arr.Add(tbCad_email.Text);
                arr.Add(tbCad_categoria.Text);
                arr.Add(tbCad_status.Text);
                arr.Add(tbCad_agencia.Text);
                arr.Add(tbCad_conta.Text);
                

            
            if (obj.Insert(arr))
            {
                MessageBox.Show("Cadastro Efetuado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao Cadastrar Empresa!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro + "Erro Ocorrido");
            }

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            ArrayList arr = new ArrayList();

            arr.Add(tbEdit_codigo.Text);
            arr.Add(tbEdit_nome.Text);
            arr.Add(tbEdit_rs.Text);
            arr.Add(tbEdit_cnpj.Text);
            arr.Add(tbEdit_endereco.Text);
            arr.Add(cbEditCidade.Text);
            arr.Add(cbEditUF.Text);
            arr.Add(tbEdit_telefone.Text);
            arr.Add(tbEdit_email.Text);
            arr.Add(tbEdit_categoria.Text);
            arr.Add(tbEdit_status.Text);
            arr.Add(tbEdit_agencia.Text);
            arr.Add(tbEdit_conta.Text);
            


            if (obj.Update(arr))
            {
                MessageBox.Show("Cadastro Atualizado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPage2_Enter(e, e);
            }
            else
            {
                MessageBox.Show("Erro ao Atualizar Empresa!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            int CodEmpresa = Convert.ToInt16 (tb_Excluir.Text);
            if (obj.Delete(CodEmpresa))
            {
                MessageBox.Show("Cadastro Excluido com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPage3_Enter(e, e);
            }
            else
            {
                MessageBox.Show("Erro ao Excluir Empresa!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            cbEditUF.DataSource = obj.listaUF();
            dgEdit.DataSource =  obj.ListaGrid();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();

            dgExcluir.DataSource = obj.ListaGrid();
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            string sql;

            if (rbNome.Checked)
            {
                sql = "SELECT [NOME], [RAZAO_SOCIAL], [CNPJ], [ENDERECO], [CIDADE], [UF], [TELEFONE], [EMAIL], [CATEGORIA], [STATUS], [AGENCIA], [CONTA] FROM CRUDEMPRESA WHERE NOME LIKE @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, "%"+tbVPesquisa.Text+"%");
            }
            else
            {
                sql = "SELECT [NOME], [RAZAO_SOCIAL], [CNPJ], [ENDERECO], [CIDADE], [UF], [TELEFONE], [EMAIL], [CATEGORIA], [STATUS], [AGENCIA], [CONTA] FROM CRUDEMPRESA WHERE ID_EMPRESA = @VALOR";
                dgPesquisa.DataSource = obj.Pesquisar(sql, tbVPesquisa.Text);
            }

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            cbCadUF.DataSource = obj.listaUF();
            cbCadUF.DisplayMember = "UF";
            
        }

        private void cbCadUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            cbCadCidade.DataSource = obj.listaCidade(cbCadUF.Text);
            cbCadCidade.DisplayMember = "NOME";
        }

        private void cbEditUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            sisDBADM obj = new sisDBADM();
            cbEditCidade.DataSource = obj.listaCidade(cbEditUF.Text);
            cbEditCidade.DisplayMember = "NOME";
        }

    }
}
