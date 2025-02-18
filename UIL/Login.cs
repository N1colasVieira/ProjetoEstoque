﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UIL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Metodos mt = new BLL.Metodos();
        string botao;

        private void ILogin_Load(object sender, EventArgs e)
        {
            botao = "btnLogin_normal.png";
            if (mt.ArquivoExiste(Metodos.pathImagens, botao))
            {
                Image bt = Image.FromFile(Metodos.pathImagens + botao);
                btnLogin.BackgroundImage = bt;
            }
        }

        #region Mouse Move
        private int mov, movX, movY;
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        #endregion

        #region Eventos do painel de botões
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Black;
        }
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.White;
        }
        #endregion

        #region Eventos Esqueceu a Senha
        private void lblEsqueceuSenha_MouseEnter(object sender, EventArgs e)
        {
            lblEsqueceuSenha.ForeColor = Color.Black;
        }
        private void lblEsqueceuSenha_MouseLeave(object sender, EventArgs e)
        {
            lblEsqueceuSenha.ForeColor = Color.White;
        }
        private void lblEsqueceuSenha_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            NovaSenha ns = new NovaSenha();
            ns.Show();
        }
        #endregion

        #region Novo Usuario
        private void lblNovoUsuario_MouseEnter(object sender, EventArgs e)
        {
            lblNovoUsuario.ForeColor = Color.Black;
        }
        private void lblNovoUsuario_MouseLeave(object sender, EventArgs e)
        {
            lblNovoUsuario.ForeColor = Color.White;
        }
        private void lblNovoUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            CadastroUsuario cu = new CadastroUsuario();
            cu.Show();
        }
        #endregion

        #region Eventos do botão Login

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            botao = "btnLogin_focus.png";
            if (mt.ArquivoExiste(Metodos.pathImagens, botao))
            {
                Image bt = Image.FromFile(Metodos.pathImagens + botao);
                btnLogin.BackgroundImage = bt;
            }
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            botao = "btnLogin_normal.png";
            if (mt.ArquivoExiste(Metodos.pathImagens, botao))
            {
                Image bt = Image.FromFile(Metodos.pathImagens + botao);
                btnLogin.BackgroundImage = bt;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<string> login = new List<string>() { txtUsuario.Text, txtSenha.Text };
            if (mt.Autenticacao(login) == string.Empty)
            {               
                this.Hide();
                Estoque es = new Estoque();
                es.Show();
            }
            else
            {
                CaixaDeMensagem cm = new CaixaDeMensagem();
                string mensagem = mt.Autenticacao(login);
                if( mensagem == "Usuário ou senha incorretos!")
                {                    
                    cm.MostrarCaixaDeMensagem(mensagem, "Erro", 3);
                }
                else 
                {
                    cm.MostrarCaixaDeMensagem(mensagem, "Atenção", 2);
                }            
                cm.Show();
            }
        }
        #endregion
    }
}
