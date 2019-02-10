using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Threading;

namespace WPF_programowanie_Csharp_01
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageSource[] ImageSources = new ImageSource[50];
        // int[][] sequences = new int[][];
        int[,] sequences = new int[8, 3];
        public Random randomSeed = new Random();
        int properSequenceYIndexFromRandomRange;
        int Score = 0;
        private int time = 30;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();


        public MainWindow()
        {

            fillImagesArray();
            InitializeComponent();
            Label_Timer.Content = "Time: "+ string.Format("00:0{0}:{1}", time / 60, time % 60);
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // code goes here
            if(time > 0)
            {
                time--;
                Label_Timer.Content = "Time: "+ string.Format("00:0{0}:{1}", time / 60, time % 60);
            }
            else
            {
                dispatcherTimer.Stop();
                Button_Generate_Sequence.Visibility = Visibility.Visible;
                Button_Generate_Sequence.IsEnabled = true;
                Score = 0;
                Label_Score.Content = Score.ToString();
                time = 30;
                Label_Timer.Content = "Time: " + string.Format("00:0{0}:{1}", time / 60, time % 60);

            }
        }
        //Metoda BitmapToImageSource zapozyczona spod adresu:
        //https://stackoverflow.com/questions/22499407/how-to-display-a-bitmap-in-a-wpf-image

        private void fillImagesArray()
        {
            ImageSources[0] = BitmapToImageSource(Properties.Resources._001_jetpack_1);
            ImageSources[1] = BitmapToImageSource(Properties.Resources._002_flying_shoes);
            ImageSources[2] = BitmapToImageSource(Properties.Resources._003_exoskeleton);
            ImageSources[3] = BitmapToImageSource(Properties.Resources._004_prothesis);
            ImageSources[4] = BitmapToImageSource(Properties.Resources._005_solar_panels);
            ImageSources[5] = BitmapToImageSource(Properties.Resources._006_robot_4);
            ImageSources[6] = BitmapToImageSource(Properties.Resources._007_renewable_energy);
            ImageSources[7] = BitmapToImageSource(Properties.Resources._008_plant);
            ImageSources[8] = BitmapToImageSource(Properties.Resources._009_windmill);
            ImageSources[9] = BitmapToImageSource(Properties.Resources._010_tree);
            ImageSources[10] = BitmapToImageSource(Properties.Resources._011_satellites);
            ImageSources[11] = BitmapToImageSource(Properties.Resources._012_satellite);
            ImageSources[12] = BitmapToImageSource(Properties.Resources._013_spaceship);
            ImageSources[13] = BitmapToImageSource(Properties.Resources._014_rocket);
            ImageSources[14] = BitmapToImageSource(Properties.Resources._015_solar_panel);
            ImageSources[15] = BitmapToImageSource(Properties.Resources._016_unmanned_aerial_vehicle);
            ImageSources[16] = BitmapToImageSource(Properties.Resources._017_robot_3);
            ImageSources[17] = BitmapToImageSource(Properties.Resources._018_skateboard);
            ImageSources[18] = BitmapToImageSource(Properties.Resources._019_drone);
            ImageSources[19] = BitmapToImageSource(Properties.Resources._020_flying_car);
            ImageSources[20] = BitmapToImageSource(Properties.Resources._021_self_driving);
            ImageSources[21] = BitmapToImageSource(Properties.Resources._022_mechanical_arm_1);
            ImageSources[22] = BitmapToImageSource(Properties.Resources._023_mechanical_arm);
            ImageSources[23] = BitmapToImageSource(Properties.Resources._024_smart_glasses_1);
            ImageSources[24] = BitmapToImageSource(Properties.Resources._025_smart_glasses);
            ImageSources[25] = BitmapToImageSource(Properties.Resources._026_vr_glasses);
            ImageSources[26] = BitmapToImageSource(Properties.Resources._027_kettle);
            ImageSources[27] = BitmapToImageSource(Properties.Resources._028_robot_2);
            ImageSources[28] = BitmapToImageSource(Properties.Resources._029_smart_clothing);
            ImageSources[29] = BitmapToImageSource(Properties.Resources._030_house);
            ImageSources[30] = BitmapToImageSource(Properties.Resources._031_city);
            ImageSources[31] = BitmapToImageSource(Properties.Resources._032_robot_arm);
            ImageSources[32] = BitmapToImageSource(Properties.Resources._033_3d_printer);
            ImageSources[33] = BitmapToImageSource(Properties.Resources._034_graphene);
            ImageSources[34] = BitmapToImageSource(Properties.Resources._035_smart_house_1);
            ImageSources[35] = BitmapToImageSource(Properties.Resources._036_smart_house);
            ImageSources[36] = BitmapToImageSource(Properties.Resources._037_smartwatch_1);
            ImageSources[37] = BitmapToImageSource(Properties.Resources._038_mobile);
            ImageSources[38] = BitmapToImageSource(Properties.Resources._039_robot_1);
            ImageSources[39] = BitmapToImageSource(Properties.Resources._040_smartwatch);
            ImageSources[40] = BitmapToImageSource(Properties.Resources._041_augmented_reality);
            ImageSources[41] = BitmapToImageSource(Properties.Resources._042_hologram);
            ImageSources[42] = BitmapToImageSource(Properties.Resources._043_artificial_intelligence);
            ImageSources[43] = BitmapToImageSource(Properties.Resources._044_interactive);
            ImageSources[44] = BitmapToImageSource(Properties.Resources._045_eye_scanner);
            ImageSources[45] = BitmapToImageSource(Properties.Resources._046_cloud);
            ImageSources[46] = BitmapToImageSource(Properties.Resources._047_chip);
            ImageSources[47] = BitmapToImageSource(Properties.Resources._048_brain);
            ImageSources[48] = BitmapToImageSource(Properties.Resources._049_jetpack);
            ImageSources[49] = BitmapToImageSource(Properties.Resources._050_robot);

        }

        private void Button_Click_Generate_Sequence(object sender, RoutedEventArgs e)
        {
        
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
            GenerateSequence();

            Button_Generate_Sequence.Visibility = Visibility.Hidden;
            Button_Generate_Sequence.IsEnabled = false;

        }

        private void Button_Click_Button_Pick_Sequence_0(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 0)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }
        private void Button_Click_Button_Pick_Sequence_1(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 1)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }
        private void Button_Click_Button_Pick_Sequence_2(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 2)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }

        private void Button_Click_Button_Pick_Sequence_3(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 3)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }

        private void Button_Click_Button_Pick_Sequence_4(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 4)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }

        private void Button_Click_Button_Pick_Sequence_5(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 5)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }

        private void Button_Click_Button_Pick_Sequence_6(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 6)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }

        private void Button_Click_Button_Pick_Sequence_7(object sender, RoutedEventArgs e)
        {
            if (properSequenceYIndexFromRandomRange == 7)
            {
                Score++;
                GenerateSequence();
                Label_Score.Content = "Score: " + Score.ToString();
            }
            else
            {
                GenerateSequence();
                Score--;
                Label_Score.Content = "Score: " + Score.ToString();
            }
        }

        private void GenerateSequence()
        {
            List<int> currentSequenceToBeFound = new List<int>();

            for (int i = 0; i < 3; i++)
                currentSequenceToBeFound.Add(randomSeed.Next(0, ImageSources.Length));

            List<ImageSource> currentSequenceImageSources = new List<ImageSource>();
            Img_Seq_1.Source = ImageSources[currentSequenceToBeFound[0]];
            Img_Seq_2.Source = ImageSources[currentSequenceToBeFound[1]];
            Img_Seq_3.Source = ImageSources[currentSequenceToBeFound[2]];
            currentSequenceImageSources.Add(Img_Seq_1.Source);
            currentSequenceImageSources.Add(Img_Seq_2.Source);
            currentSequenceImageSources.Add(Img_Seq_3.Source);

            properSequenceYIndexFromRandomRange = randomSeed.Next(0, sequences.GetLength(0));
            for (int y = 0; y < sequences.GetLength(0); y++)
            //fill the sequences matrix for the possible picks
            {
                if (y == properSequenceYIndexFromRandomRange)
                {
                    // if the picked index in random range  equals the current y index
                    // set the x values to the sequence to be found
                    for (int x = 0; x < sequences.GetLength(1); x++)
                    {//store proper sequence in one of the rows of the sequences matrix
                        sequences[y, x] = currentSequenceToBeFound[x];
                        //fill appropriate images set
                        FillImagesSequenceForPossiblePick(y, x);
                    }
                }
                else
                {
                    for (int x = 0; x < sequences.GetLength(1); x++)
                    {
                        sequences[y, x] = randomSeed.Next(0, ImageSources.Length);
                        FillImagesSequenceForPossiblePick(y, x);
                    }
                }
            }
        }
        private void FillImagesSequenceForPossiblePick(int y, int x)
        {

            switch (y)
            {
                case 0:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_0_0.Source = ImageSources[sequences[y, x]];
                                    Console.WriteLine("Case y == 0 x == 0");
                                }
                                break;
                            case 1:
                                {
                                    Img_0_1.Source = ImageSources[sequences[y, x]];
                                    Console.WriteLine("Case y == 0 x == 1");
                                }
                                break;
                            case 2:
                                {
                                    Img_0_2.Source = ImageSources[sequences[y, x]];
                                    Console.WriteLine("Case y == 0 x == 2");
                                }
                                break;
                        }


                    }
                    break;
                case 1:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_1_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_1_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_1_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }


                    }
                    break;
                case 2:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_2_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_2_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_2_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }


                    }
                    break;
                case 3:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_3_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_3_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_3_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }


                    }
                    break;
                case 4:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_4_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_4_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_4_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }

                    }
                    break;
                case 5:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_5_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_5_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_5_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }

                    }
                    break;
                case 6:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_6_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_6_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_6_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }

                    }
                    break;
                case 7:
                    {
                        switch (x)
                        {
                            case 0:
                                {
                                    Img_7_0.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 1:
                                {
                                    Img_7_1.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                            case 2:
                                {
                                    Img_7_2.Source = ImageSources[sequences[y, x]];
                                }
                                break;
                        }

                    }
                    break;

            }
        }
    }

}