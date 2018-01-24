using System;
using System.Collections.Generic;
using System.IO;
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

namespace LabSheet1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Band> bandList = new List<Band>();
        private List<string> genreList = new List<string>();
        private Random rn = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateDummyData();

            cbox_Genre.ItemsSource = genreList;
            cbox_Genre.SelectedIndex = 0;
            lbox_Bands.ItemsSource = bandList;
            lbox_Bands.SelectedIndex = 0;
        }

        private void CreateDummyData()
        {
            RockBand rb1 = new RockBand("Rock1", "1950",
                                        new List<string> { "Member1" },
                                        new List<Album> { new Album("Album1", new DateTime(rn.Next(1850, 2000), rn.Next(1, 12), rn.Next(1, 20)), rn.Next(300, 600)) });

            PopBand pb1 = new PopBand("Pop1", "1850",
                                        new List<string> { "Member1", "Member2" },
                                        new List<Album> { new Album("Album1", new DateTime(rn.Next(1850, 2000), rn.Next(1, 12), rn.Next(1, 20)), rn.Next(300, 600)),
                                        new Album("Album2", new DateTime(rn.Next(1850, 2000), rn.Next(1, 12), rn.Next(1, 20)), rn.Next(300, 600))});

            IndieBand ib1 = new IndieBand("Indie1", "1980",
                                        new List<string> { "Member1", "Member2", "Member3" },
                                        new List<Album> { new Album("Album1", new DateTime(rn.Next(1850, 2000), rn.Next(1, 12), rn.Next(1, 20)), rn.Next(300, 600)),
                                        new Album("Album2", new DateTime(rn.Next(1850, 2000), rn.Next(1, 12), rn.Next(1, 20)), rn.Next(300, 600)),
                                        new Album("Album3", new DateTime(rn.Next(1850, 2000), rn.Next(1, 12), rn.Next(1, 20)), rn.Next(300, 600))});

            bandList.Add(rb1);
            bandList.Add(pb1);
            bandList.Add(ib1);

            genreList.Add("All");
            genreList.Add("Rock");
            genreList.Add("Pop");
            genreList.Add("Indie");

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("Text.txt",FileMode.OpenOrCreate);

            StreamReader sr = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs);

            Band band = (Band)lbox_Bands.SelectedItem;

            string s;
            int lineCount = 0;
            while((s = sr.ReadLine())!= null){
                lineCount++;
            }
            //sw.NewLine = lineCount+1;
            sw.WriteLine(band.DetailsForFileWrite());
            foreach (Album item in band.Albums)
            {
                sw.WriteLine(item.DetailsForFileWrite());
                
            }

            sw.Dispose();
            sw.Close();
            fs.Dispose();
            fs.Close();


        }

        private void lbox_Bands_Selected(object sender, RoutedEventArgs e)
        {
            if(lbox_Bands.SelectedItem != null && cbox_Genre.SelectedItem != null)
            {
                Band temp = (Band)lbox_Bands.SelectedItem;


                lbl_FormedData.Content = temp.YearFormed;
                lbl_MembersData.Content = String.Join(",",temp.Members);

                lbox_Albums.ItemsSource = temp.Albums;
            }
        }

        private void lbox_Albums_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void cbox_Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbox_Genre.SelectedItem != null)
            {
                if (cbox_Genre.SelectedItem.ToString() != "All")
                {
                    List<Band> tempList = new List<Band>();

                    foreach (Band item in bandList)
                    {
                        if (item.GetType().Name.Contains(cbox_Genre.SelectedItem.ToString()))
                        {
                            tempList.Add(item);
                        }
                    }

                    lbox_Bands.ItemsSource = tempList;
                }
                else lbox_Bands.ItemsSource = bandList;


            }
        }
    }
}
