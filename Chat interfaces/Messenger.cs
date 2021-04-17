using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat_interfaces
{
    public class Messenger
    {
        public Messenger()
        {

        }
        public Messenger(string text, string time)
        {
            Text = text;
            Time = time;
        }

        public string Text { get; set; }
        public string Time { get; set ; }

        public string ImagePath { get; set; }
        public string FullText { get => $" {Time}                      {Text} \n"; }

        public Label GetLabel()
        {
            Label label = new Label();
            label.Height = 150;




            label.Content = $" {Time}                      {Text}";

            label.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

    //        ImageBrush imageBrush = new ImageBrush(new BitmapImage(
    //new Uri(ImagePath, UriKind.Relative)));
    //        label.Background = imageBrush ;

         

 


            return label;
        }

        public Image GetImage() {

            Image images = new Image();
            try
            {


            images.Source = new BitmapImage(new Uri(ImagePath));
            images.Width = 100.00;
            images.Height = 100.00;

                images.Stretch = Stretch.Fill;
            }
            catch (Exception)
            {

              
            }


            return images;
        }

        public override string ToString()
        {
            return $"{Text} {Time}";
        }
    }
}
