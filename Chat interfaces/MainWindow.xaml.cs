using Microsoft.Win32;
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

namespace Chat_interfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        TextBlock textBlock1 = new TextBlock();
        Label label1 = new Label();

        Image images = new Image();

        List<Messenger> messengersList = new List<Messenger>();

        
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {

            AddTextList();
            listboxText();

        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Textbox1.IsEnabled = false;
            Textbox1.Clear();

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == true)
                {
                    imageLocation = openFileDialog.FileName;
                    foreach (var item in messengersList)
                    {
                        images = item.GetImage();
                    }
                }
            }
            catch (Exception)
            {

            }



            AddImageList();
            listboxImage();

            Textbox1.IsEnabled = true;
        }

        string imageLocation = "";


        
        void AddImageList()
        {

            label1.Content = DateTime.Now.ToString();


            messengersList.Add(new Messenger()
            {
           
                ImagePath = imageLocation,
                Time = label1.Content.ToString(),

            }) ;
        }

        void AddTextList()
        {

            label1.Content = DateTime.Now.ToString();
            textBlock1.Text = Textbox1.Text;
            messengersList.Add(new Messenger(textBlock1.Text, label1.Content.ToString())
            {
                Text = textBlock1.Text,
                Time = label1.Content.ToString(),
                


            });
        }

        void listboxText()
        {
         

            Listbox1.Items.Clear();

            List<Messenger> Distinct_messengersList = messengersList.Distinct().ToList();

            foreach (var item in Distinct_messengersList)
            {
                Label labelText = new Label();

                labelText.Height = 90;

                StackPanel stackPanel = new StackPanel();

                stackPanel.Orientation = Orientation.Horizontal;

                stackPanel.Children.Add(item.GetLabel());

                stackPanel.Children.Add(item.GetImage());

                stackPanel.Margin = new Thickness(0.5);



                labelText.Content = stackPanel;

                if (!Listbox1.Items.Contains(labelText))
                {


                    Listbox1.Items.Add(labelText);


                }


            }


 
        }

        void listboxImage()
        {
               Listbox1.Items.Clear();


            List<Messenger> Distinct_messengersList = messengersList.Distinct().ToList();

            foreach (var item in Distinct_messengersList)
            {
                Label labelPhoto = new Label();
                labelPhoto.Height = 90;

                StackPanel stackPanel = new StackPanel();

                stackPanel.Orientation = Orientation.Horizontal;

        
                stackPanel.Children.Add(item.GetImage());
                stackPanel.Children.Add(item.GetLabel());

                labelPhoto.Content = stackPanel;

                if (!Listbox1.Items.Contains(labelPhoto))
                {
                    Listbox1.Items.Add(labelPhoto);


                }
            }
        }



    }
}

