using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace ComandosYMenus
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<String> coleccion;
        string elementoAlmacenado;
        DispatcherTimer timer;

        public MainWindow()
        {
            coleccion = new ObservableCollection<String>();
            elementoAlmacenado = null;            
            InitializeComponent();
            lista.DataContext = coleccion;
            copyButton.Command = ApplicationCommands.Copy;
            CrearTemporizador();
        }

        private void CrearTemporizador()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            temporizador.Text = DateTime.Now.ToLongTimeString();
        }

        private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            elementoAlmacenado = lista.SelectedItem.ToString();
        }

        private void Copy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.SelectedItem == null)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
        private void Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            coleccion.Add(elementoAlmacenado);
            elementoAlmacenado = null;
        }

        private void Paste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (elementoAlmacenado == null)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            coleccion.Add("Item añadido a las " + DateTime.Now);
        }

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (coleccion.Count >= 10)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
        private void Salir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            VentanaMain.Close();
        }

        private void Salir_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Vaciar_Executed(object sender, ExecutedRoutedEventArgs e)
        {            
            coleccion.Clear();
        }

        private void Vaciar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (coleccion.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }
}
