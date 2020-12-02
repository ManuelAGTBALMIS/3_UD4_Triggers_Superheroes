using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3_UD4_Triggers_Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Superheroe heroe;
        List<Superheroe> listaHeroes = Superheroe.GetSamples();
        int contador = 0;

        public MainWindow()
        {
            InitializeComponent();
            Mostrar(0);
        }


        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            heroe = (Superheroe)gridContenedor.DataContext;//Cogemos los datos del heroe del contenedor
            listaHeroes.Add(heroe);//añadimos el heroe

            this.Resources.Remove("heroe");//para poder añadir mas de un heroe, eliminamos el recurso anterior
            this.Resources.Add("heroe", new Superheroe());
            Mostrar(0);//Actualizar la barra de abajo
            MessageBox.Show("Heroe creado con éxito ");
        }

        public void Mostrar(int posicion)
        {
            //Barra de abajo con las flechas y el contador
            numeroDePersonajes.Text = listaHeroes.Count.ToString();//Numero de heroes en la lsita
            contadorHeroes.Text = (contador + 1).ToString();//Numero del heroe que estamos mostrando

            //Metemos el heroe actual en el dataContext del Dockpanel
            dockPanel_ColorDeFondo.DataContext = listaHeroes[contador];

        }

        //Cuando le damos a la flecha, nos movemos por el array
        private void flecha2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contador++;

            if (contador >= listaHeroes.Count)
            {
                contador = (listaHeroes.Count - 1);
            }
            Mostrar(contador);
        }

        private void flecha1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contador--;
            if (contador <= 0)
            {
                contador = 0;
            }
            else
            {
                contadorHeroes.Text = contador.ToString();
            }
            Mostrar(contador);
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            nombreSuperheroeTextBox.Text = "";
            imagenSuperheroeTextBox.Text = "";
            vengadoresCheckBox.IsChecked = false;
            xMenCheckBox.IsChecked = false;
        }
    }
}
