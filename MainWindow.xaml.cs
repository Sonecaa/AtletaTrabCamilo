using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using TrabCamilo.DAO;
using TrabCamilo.MODEL;

namespace TrabCamilo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            getFields();
            ListarAtletas();
        }

        private void ListarAtletas()
        {
            BaseDAO dao = new BaseDAO();
            var comando = new MySqlCommand("SELECT * FROM atleta");
            DataTable dt = dao.RetornarDataTable(comando);
            lstAtletas.ItemsSource = RetornaTodos(dt) ;
        }

        private List<Atleta> RetornaTodos(DataTable reg)
        {
            List<Atleta> listaAtelta = new List<Atleta>();

            foreach (DataRow dr in reg.Rows)            
            {
                var atleta = new Atleta {
                    Nome = dr["nome_atleta"].ToString(),
                    Peso = Convert.ToDouble(dr["peso_atleta"]),
                    Altura = Convert.ToDouble(dr["altura_atleta"]),
                };
                listaAtelta.Add(atleta);
            }

            return listaAtelta;
        }

        private void actionToSql(String sql)
        {
            getFields();
            BaseDAO dao = new BaseDAO();
            var comando = new MySqlCommand(sql);
            dao.ExecutarComando(comando);
            ListarAtletas();
        }

        private bool validaCampos()
        {
            bool isValid = true;

            if (txtNome.Text == "" || txtNome.Text == null)
                return false;
            if (txtPeso.Text == "" || txtPeso.Text == null)
                return false;
            if (txtAltura.Text == "" || txtAltura.Text == null)
                return false;

            return isValid;
        }

        private Atleta getFields()
        {
            if (validaCampos()) {
            Atleta atleta = new Atleta(txtNome.Text, Double.Parse(txtPeso.Text), Double.Parse(txtAltura.Text));
                return atleta;
            }

            return null;
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
           Atleta atleta = getFields();
            actionToSql("INSERT INTO atleta (nome_atleta, peso_atleta, altura_atleta) VALUES('" + atleta.Nome + "', '" + atleta.Peso + "', '" + atleta.Altura + "'); ");
        }


        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
