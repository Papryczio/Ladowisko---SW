using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ladowisko
{
    public partial class Form1 : Form
    {
        Size desired_image_size;
        Image<Bgr, byte> image_post, image_PB1, image_temp2;
        Image<Gray, byte> image_temp1;
        VideoCapture camera;
        VectorOfVectorOfPoint rectContour = new VectorOfVectorOfPoint();
        VectorOfVectorOfPoint rectContour_sur = new VectorOfVectorOfPoint();
        VectorOfPoint rectContour_max = new VectorOfPoint();
        Mat rect_mat = new Mat();
        Mat rect_mat_sur = new Mat();
        bool delay;
        bool delay_sur;
        int delay_counter;
        int delay_counter_sur;
        int prev_x, prev_y;
        int prev_approx_min_x_1, prev_approx_min_y_1, prev_approx_max_x_1, prev_approx_max_y_1;
        int maxidx;
        double tolerance;
        byte[,,] prev_surr;
        double perimeter;
        double area;
        String cwiartka;

        public Form1()
        {
            InitializeComponent();
            desired_image_size = picture_ori.Size;
            image_PB1 = new Image<Bgr, byte>(desired_image_size);
            image_temp1 = new Image<Gray, byte>(desired_image_size);
            image_temp2 = new Image<Bgr, byte>(desired_image_size);
            image_post = new Image<Bgr, byte>(desired_image_size);
            timer1.Enabled = false;
            delay = true;
            delay_sur = true;
            delay_counter = 0;
            delay_counter_sur = 0;
            prev_x = -1;
            prev_y = -1;
            prev_approx_min_x_1 = -1;
            prev_approx_min_y_1 = -1;
            prev_approx_max_x_1 = -1;
            prev_approx_max_y_1 = -1;
            maxidx = -1;
            area = -1;
            perimeter = -1;
            //---
            tolerance = 0.06;
            //---
            try
            {
                camera = new VideoCapture();
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, desired_image_size.Width);
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, desired_image_size.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region GUI
        private void button_Browse_Files_PB1_Click(object sender, EventArgs e)
        {
            textBox_Image_Path_PB1.Text = get_image_path();
        }

        private string get_image_path()
        {
            string ret = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Obrazy|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Wybierz obrazek.";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ret = openFileDialog1.FileName;
            }

            return ret;
        }

        private void button_From_File_PB1_Click(object sender, EventArgs e)
        {
            picture_ori.Image = get_image_bitmap_from_file(textBox_Image_Path_PB1.Text, ref image_PB1);
        }



        private Bitmap get_image_bitmap_from_file(string path, ref Image<Bgr, byte> Data)
        {
            try
            {
                Mat temp = CvInvoke.Imread(path);
                CvInvoke.Resize(temp, temp, desired_image_size);
                Data = temp.ToImage<Bgr, byte>();
                return Data.Bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podana ścieżka jest nieprawidłowa");
                return null;
            }
        }

        #endregion

        #region camera_timer

        bool movie = false;

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            Mat temp = camera.QueryFrame();
            CvInvoke.Resize(temp, temp, picture_ori.Size);
            image_PB1 = temp.ToImage<Bgr, byte>();
            picture_ori.Image = image_PB1.Bitmap;
            button_cameraJPG.PerformClick();
            button_threshold.PerformClick();
            button_detect.PerformClick();
            if (delay_counter < 3)
            {
                delay = true;
            }
            else
            {
                delay = false;
            }
            if (delay_counter_sur < 5)
            {
                delay_sur = true;
            }
            else
            {
                delay_sur = false;
            }
        }

        #endregion

        #region program

        private void Kolorki()
        {
            // czyszczenie list
            listView_pos.Clear();
            listView2.Clear();
            //zmienne pomocnicze
            int blockSize = (int)numericUpDown_blockSize.Value;
            int param1 = (int)numericUpDown_param1.Value;
            //kopiowanie image_PB1 do image_temp2
            image_PB1.CopyTo(image_temp2);
            //konwersja z BGR na Gray
            image_temp1 = image_PB1.Convert<Gray, byte>();
            picture_post.Image = image_temp1.Bitmap;
            //progowanie adaptacyjne
            CvInvoke.AdaptiveThreshold(image_temp1, image_temp1, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, blockSize, param1);
            picture_post.Image = image_temp1.Bitmap;
            //odwrocenie kolorow
            image_temp1._Not();
            picture_post.Image = image_temp1.Bitmap;
            picture_post_det.Image = image_temp2.Bitmap;
        }

        private void FindRect()
        {
            #region zmienne pomocnicze
            int matches = 0;
            bool match = false;
            int x;
            int y;
            double area_max = 0;
            double perimeter_max = 0;
            double area_temporary = 0;
            double perimeter_temp = 0;
            bool newmax = false;
            #endregion

            #region findContours

            CvInvoke.FindContours(image_temp1, rectContour, rect_mat, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            Image<Bgr, byte> image_temp1_bgr = image_temp1.Convert<Bgr, byte>();
            //dla każdego konturu:
            for (int i = 0; i < rectContour.Size; i++)
            {
                //obwód
                perimeter = CvInvoke.ArcLength(rectContour[i], true);
                VectorOfPoint approx = new VectorOfPoint();
                //aproksymacja
                CvInvoke.ApproxPolyDP(rectContour[i], approx, 0.01 * perimeter, true);
                //pole
                area = CvInvoke.ContourArea(rectContour[i]);
                #region warunki_na_wzorzec
                switch (matches)
                {
                    //jeżeli nie ma dopasowań sprawdzamy, czy kontur jest czworobokiem, czy jego pole jest wieksze od 2500 pixeli, oraz czy na na obrazie nie znalezliśmy już większego
                    //obiektu, który spełnił wszystkie warunki.
                    case 0:
                        if (approx.Size == 4 && area > 2500 && area > area_max && perimeter > 180)
                        {
                            area_temporary = area;
                            perimeter_temp = perimeter;
                            matches++;
                            newmax = true;
                        }
                        else
                        {
                            matches = 0;
                            newmax = false;
                        }
                        break;
                    //dla jednego dopasowania sprawdzamy czy kontur jest czworobokiem.
                    case 1:
                        if (approx.Size == 4) matches++;
                        else
                        {
                            matches = 0;
                            newmax = false;
                        }
                        break;
                    //dla dwóch dopasowań sprawdzamy, czy kontur po aproksymacji ma więcej niż 4 punkty (jest na przykład 5kątem) - może to być przybliżony okrąg.
                    case 2:
                        if (approx.Size > 4) matches++;
                        else
                        {
                            matches = 0;
                            newmax = false;
                        }
                        break;
                    //dla trzech dopasowań jw.
                    case 3:
                        if (approx.Size > 4) matches++;
                        else
                        {
                            matches = 0;
                            newmax = false;
                        }
                        break;
                    //dla czterech dopasowań sprawdzamy, czy kontur ma więcej niż 7 puntków - może być to przybliżony X.
                    case 4:
                        if (approx.Size > 7 && newmax == true)
                        {
                            maxidx = i;
                            area_max = area_temporary;
                            perimeter_max = perimeter_temp;
                            newmax = false;
                            delay_counter = 0;
                            rectContour_max = rectContour[i - 4];
                            match = true;
                        }
                        else
                        {
                            matches = 0;
                            newmax = false;
                        }
                        break;
                }
                #endregion
            }
            listView1.Clear();
            listView1.Items.Add("Area_max = " + area_max + "\n");

            #endregion

            //sprawdzamy czy możemy dla naszego obiektu wyliczyć momenty (jeżeli będzie exception - znaczy to, że nie znaleziono żadnego obiektu)
            try
            {
                if (match == true)
                {
                    #region momenty_i_zoom
                    //obliczenie momentów
                    var moments = CvInvoke.Moments(rectContour[maxidx - 2]);
                    //środek ciężkości
                    prev_x = x = (int)(moments.M10 / moments.M00);
                    prev_y = y = (int)(moments.M01 / moments.M00);
                    //rysowanie konturu dla 2 pictureboxów
                    CvInvoke.DrawContours(image_temp1_bgr, rectContour, maxidx - 4, new MCvScalar(0, 0, 255));
                    CvInvoke.DrawContours(image_temp2, rectContour, maxidx - 4, new MCvScalar(0, 0, 255));
                    //rysowanie środka ciężkości dla 2 pictureboxów
                    CvInvoke.Circle(image_temp1_bgr, new Point(x, y), 2, new MCvScalar(0, 255, 255), 2);
                    CvInvoke.Circle(image_temp2, new Point(x, y), 2, new MCvScalar(0, 255, 255), 2);
                    //dodawanie informacji o położeniu na listę
                    listView_pos.Items.Add("Pozycja względem środka obrazu = " + ((int)desired_image_size.Width / 2 - x) + ", " + ((int)desired_image_size.Height / 2 - y) + "\n");

                    //ZOOM NA OTOCZENIE LĄDOWISKA
                    byte[,,] temp_bgr = image_PB1.Data;

                    int approx_max_y_1 = -1, approx_max_x_1 = -1;
                    int approx_min_y_1 = 2000, approx_min_x_1 = 2000;

                    //poszukiwanie minimalnych i maksymalnych wartości współrzędnych x i y
                    for (int i = 0; i < rectContour[maxidx - 4].Size; i++)
                    {
                        if (rectContour[maxidx - 4][i].X < approx_min_x_1) approx_min_x_1 = rectContour[maxidx - 4][i].X;
                        if (rectContour[maxidx - 4][i].X > approx_max_x_1) approx_max_x_1 = rectContour[maxidx - 4][i].X;
                        if (rectContour[maxidx - 4][i].Y < approx_min_y_1) approx_min_y_1 = rectContour[maxidx - 4][i].Y;
                        if (rectContour[maxidx - 4][i].Y > approx_max_y_1) approx_max_y_1 = rectContour[maxidx - 4][i].Y;
                    }
                    // rozszerzenie ich o współczynnik oparty na obwodzie pomnożonym przez zmienną
                    prev_approx_min_x_1 = approx_min_x_1 = approx_min_x_1 - (int)(tolerance * perimeter_max);
                    prev_approx_min_y_1 = approx_min_y_1 = approx_min_y_1 - (int)(tolerance * perimeter_max);
                    prev_approx_max_x_1 = approx_max_x_1 = approx_max_x_1 + (int)(tolerance * perimeter_max);
                    prev_approx_max_y_1 = approx_max_y_1 = approx_max_y_1 + (int)(tolerance * perimeter_max);

                    // uwzględnienie rozmiaru obrazu
                    if (approx_min_x_1 - tolerance * perimeter_max < 0) approx_min_x_1 = 0;
                    if (approx_max_x_1 + tolerance * perimeter_max > desired_image_size.Width) approx_max_x_1 = desired_image_size.Width;
                    if (approx_min_y_1 - tolerance * perimeter_max < 0) approx_min_y_1 = 0;
                    if (approx_max_y_1 + tolerance * perimeter_max > desired_image_size.Height) approx_max_y_1 = desired_image_size.Height;

                    //----------------------------
                    Image<Bgr, byte> image_sur = new Image<Bgr, byte>(approx_max_x_1 - approx_min_x_1, approx_max_y_1 - approx_min_y_1);
                    Image<Bgr, byte> image_post_sur = new Image<Bgr, byte>(approx_max_x_1 - approx_min_x_1, approx_max_y_1 - approx_min_y_1);
                    byte[,,] surr = image_sur.Data;
                    int loop_increment_x = 0;
                    int loop_increment_y;
                    //----------------------------

                    //przepisywanie bitów z obrazu do nowych tablic.
                    for (int x_loop = approx_min_x_1; x_loop < approx_max_x_1; x_loop++)
                    {
                        loop_increment_y = 0;
                        for (int y_loop = approx_min_y_1; y_loop < approx_max_y_1; y_loop++)
                        {
                            //Console.WriteLine("x " + loop_increment_x + " y " + loop_increment_y);
                            surr[loop_increment_y, loop_increment_x, 0] = temp_bgr[y_loop, x_loop, 0];
                            surr[loop_increment_y, loop_increment_x, 1] = temp_bgr[y_loop, x_loop, 1];
                            surr[loop_increment_y, loop_increment_x, 2] = temp_bgr[y_loop, x_loop, 2];
                            loop_increment_y++;
                        }
                        loop_increment_x++;
                    }
                    //wyświetlenie
                    image_sur.Data = surr;
                    picture_sur.Image = image_sur.Bitmap;
                    #endregion
                }
                else
                {
                    throw new Exception("No match found");
                }
            }
            //w przypadku gdy nie znaleziono obiektu, sprawdzamy czy w ciągu ostatnich 3 klatek obrazu ten obiekt był wykryty - jeżeli tak to podajemy jego współrzędne.
            catch (Exception ex)
            {
                if (delay == true)
                {
                    if (prev_x != -1 && prev_y != -1)
                    {
                        try
                        {
                            CvInvoke.DrawContours(image_temp1_bgr, rectContour, maxidx - 4, new MCvScalar(0, 0, 255));
                            CvInvoke.DrawContours(image_temp2, rectContour, maxidx - 4, new MCvScalar(0, 0, 255));
                            CvInvoke.Circle(image_temp1_bgr, new Point(prev_x, prev_y), 2, new MCvScalar(0, 255, 255), 2);
                            CvInvoke.Circle(image_temp2, new Point(prev_x, prev_y), 2, new MCvScalar(0, 255, 255), 2);
                            listView_pos.Items.Add("Pozycja względem środka obrazu (delay = " + delay_counter + ") = " + ((int)desired_image_size.Width / 2 - prev_x) + ", " + ((int)desired_image_size.Height / 2 - prev_y) + "\n");
                        }
                        catch (Exception ex2)
                        {
                            CvInvoke.PutText(image_temp1_bgr, "Err", new Point(10, 10), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                            CvInvoke.PutText(image_temp2, "Err", new Point(10, 10), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                        }
                    }
                    delay_counter++;
                }
                //jeżeli tego obiektu nie było w ciągu ostatnich 3 klatek - poszukujemy części wzorca przy krawędziach obrazu
                else
                {
                    if (prev_approx_min_x_1 != -1 && prev_approx_min_y_1 != -1 && prev_approx_max_x_1 != -1 && prev_approx_max_y_1 != -1)
                    {
                        // jeżeli obraz jest przy krawędziach
                        if (prev_approx_min_x_1 <= 2 * tolerance * perimeter_max)
                        {
                            prev_approx_min_x_1 = 0;
                            cwiartka = "Lewa krawędź";
                        }
                        if (prev_approx_min_y_1 <= 2 * tolerance * perimeter_max)
                        {
                            prev_approx_min_y_1 = 0;
                            cwiartka = "Górna krawędź";
                        }
                        if (prev_approx_max_x_1 >= (desired_image_size.Width - 2 * tolerance * perimeter_max))
                        {
                            prev_approx_max_x_1 = desired_image_size.Width;
                            cwiartka = "Prawa krawędź";
                        }
                        if (prev_approx_max_y_1 >= (desired_image_size.Height - 2 * tolerance * perimeter_max))
                        {
                            prev_approx_max_y_1 = desired_image_size.Height;
                            cwiartka = "Dolna krawędź";
                        }

                        //----------------------------
                        Image<Bgr, byte> image_sur = new Image<Bgr, byte>(prev_approx_max_x_1 - prev_approx_min_x_1, prev_approx_max_y_1 - prev_approx_min_y_1);
                        Image<Gray, byte> image_post_sur = new Image<Gray, byte>(prev_approx_max_x_1 - prev_approx_min_x_1, prev_approx_max_y_1 - prev_approx_min_y_1);
                        byte[,,] surr = image_sur.Data;
                        int loop_increment_x = 0;
                        int loop_increment_y;
                        byte[,,] temp_bgr = image_PB1.Data;
                        //----------------------------

                        //przepisywanie bitów z obrazu do nowych tablic.
                        for (int x_loop = prev_approx_min_x_1; x_loop < prev_approx_max_x_1; x_loop++)
                        {
                            loop_increment_y = 0;
                            for (int y_loop = prev_approx_min_y_1; y_loop < prev_approx_max_y_1; y_loop++)
                            {
                                //Console.WriteLine("x " + loop_increment_x + " y " + loop_increment_y);
                                surr[loop_increment_y, loop_increment_x, 0] = temp_bgr[y_loop, x_loop, 0];
                                surr[loop_increment_y, loop_increment_x, 1] = temp_bgr[y_loop, x_loop, 1];
                                surr[loop_increment_y, loop_increment_x, 2] = temp_bgr[y_loop, x_loop, 2];
                                loop_increment_y++;
                            }
                            loop_increment_x++;
                        }
                        #region zmienne_lokalne
                        int matches_sur = 0;
                        
                        int maxidx_sur = -1;
                        int blockSize = (int)numericUpDown2.Value;
                        int param1 = (int)numericUpDown1.Value;
                        int prev_maxidx = -1;
                        int approx_max_x_0 = 0, approx_max_y_0 = 0, approx_min_x_0 = desired_image_size.Width, approx_min_y_0 = desired_image_size.Height;
                        int approx_min_y_1 = desired_image_size.Height, approx_min_x_1 = desired_image_size.Width, approx_max_x_1 = 0, approx_max_y_1 = 0;
                        int approx_min_y_2 = desired_image_size.Height, approx_min_x_2 = desired_image_size.Width, approx_max_x_2 = 0, approx_max_y_2 = 0;
                        double area_sur_max = 0;
                        double perimeter_sur_max = 0;
                        double area_sur_temp = 0;
                        double perimeter_sur_temp = 0;
                        image_post_sur = image_sur.Convert<Gray, byte>();
                        #endregion
                        CvInvoke.AdaptiveThreshold(image_post_sur, image_post_sur, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC, Emgu.CV.CvEnum.ThresholdType.Binary, blockSize, param1);
                        image_post_sur._Not();

                        //szukanie konturów na wycinku
                        Image<Bgr, byte> image_post_sur_bgr = image_post_sur.Convert<Bgr, byte>();
                        CvInvoke.FindContours(image_post_sur, rectContour_sur, rect_mat_sur, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                        for (int i = 0; i < rectContour_sur.Size; i++)
                        {
                            if (i != maxidx_sur)
                            {
                                double perimeter_sur = CvInvoke.ArcLength(rectContour_sur[i], true);
                                VectorOfPoint approx_sur = new VectorOfPoint();
                                CvInvoke.ApproxPolyDP(rectContour_sur[i], approx_sur, 0.01 * perimeter_sur, true);
                                double area_sur = CvInvoke.ContourArea(rectContour_sur[i]);
                                bool match_sur = false;

                                #region warunki_na_wzorzec
                                switch (matches_sur)
                                {
                                    case 0:
                                        if (approx_sur.Size > 5 && approx_sur.Size < 10 && area_sur > 250 && area_sur < 7500)
                                        {
                                            listView_sur.Clear();
                                            matches_sur++;
                                            maxidx_sur = i;
                                            for (int j = 0; j < approx_sur.Size; j++)
                                            {
                                                if (approx_sur[j].X < approx_min_x_0) approx_min_x_0 = approx_sur[j].X;
                                                if (approx_sur[j].X > approx_max_x_0) approx_max_x_0 = approx_sur[j].X;
                                                if (approx_sur[j].Y < approx_min_y_0) approx_min_y_0 = approx_sur[j].Y;
                                                if (approx_sur[j].Y > approx_max_y_0) approx_max_y_0 = approx_sur[j].Y;
                                            }
                                            Console.WriteLine("case 0");
                                            area_sur_temp = area_sur;
                                            perimeter_sur_temp = perimeter_sur;
                                            i = 0;
                                        }
                                        else
                                        {
                                            matches_sur = 0;
                                        }
                                        break;
                                    case 1:
                                        for (int j = 0; j < approx_sur.Size; j++)
                                        {
                                            if (approx_sur[j].X < approx_min_x_1) approx_min_x_1 = approx_sur[j].X;
                                            if (approx_sur[j].X > approx_max_x_1) approx_max_x_1 = approx_sur[j].X;
                                            if (approx_sur[j].Y < approx_min_y_1) approx_min_y_1 = approx_sur[j].Y;
                                            if (approx_sur[j].Y > approx_max_y_1) approx_max_y_1 = approx_sur[j].Y;
                                        }

                                        if (approx_min_x_1 >= approx_min_x_0 && approx_min_y_1 >= approx_min_y_0 && approx_max_x_1 <= approx_max_x_0 && approx_max_y_1 <= approx_max_y_0 && approx_sur.Size > 5)
                                        {
                                            match_sur = true;
                                            matches_sur++;
                                            prev_maxidx = maxidx_sur;
                                            i = 0;
                                            delay_counter_sur = 0;
                                            Console.WriteLine("case 1");
                                            area_sur_max = area_sur_temp;
                                            perimeter_sur_max = perimeter_sur_temp;
                                            listView_sur.Items.Add("Area = " + area_sur_max + "\n");
                                            listView_sur.Items.Add("Perimeter = " + perimeter_sur_max + "\n");
                                        }
                                        else
                                        {
                                            matches_sur = 0;
                                            i = maxidx_sur;
                                            maxidx_sur = -1;
                                        }
                                        break;
                                    case 2:
                                        for (int j = 0; j < approx_sur.Size; j++)
                                        {
                                            if (approx_sur[j].X < approx_min_x_2) approx_min_x_2 = approx_sur[j].X;
                                            if (approx_sur[j].X > approx_max_x_2) approx_max_x_2 = approx_sur[j].X;
                                            if (approx_sur[j].Y < approx_min_y_2) approx_min_y_2 = approx_sur[j].Y;
                                            if (approx_sur[j].Y > approx_max_y_2) approx_max_y_2 = approx_sur[j].Y;
                                        }
                                        if (approx_min_x_2 >= approx_min_x_1 && approx_min_y_2 >= approx_min_y_1 && approx_max_x_2 <= approx_max_x_1 && approx_max_y_2 <= approx_max_y_1 && approx_sur.Size > 3)
                                        {
                                            matches_sur++;
                                            delay_counter_sur = 0;
                                            Console.WriteLine("case 2");
                                        }
                                        break;
                                }
                                #endregion
                                if (match_sur == true && maxidx_sur != -1)
                                {
                                    //rysowanie konturu i punktów aproksymacji

                                    CvInvoke.DrawContours(image_post_sur_bgr, rectContour_sur, maxidx_sur, new MCvScalar(0, 0, 255));
                                    listView_pos.Clear();
                                    listView_pos.Items.Add("Wzorzec częściowo poza obrazem: " + cwiartka);
                                    CvInvoke.DrawContours(image_sur, rectContour_sur, maxidx_sur, new MCvScalar(0, 0, 255));
                                }
                                else
                                {
                                    if(delay_sur == true && prev_maxidx != -1)
                                    {

                                        
                                        CvInvoke.DrawContours(image_post_sur_bgr, rectContour_sur, prev_maxidx, new MCvScalar(0, 0, 255));

                                        
                                        CvInvoke.DrawContours(image_sur, rectContour_sur, prev_maxidx, new MCvScalar(0, 0, 255));
                                    }
                                    else
                                    {
                                        CvInvoke.PutText(image_temp1_bgr, "No match", new Point(10, 10), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                                        CvInvoke.PutText(image_temp2, "No match", new Point(10, 10), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                                        listView_pos.Clear();
                                        listView_pos.Items.Add("Brak wzorca");
                                    }
                                }
                            }

                            //wyświetlenie
                            image_sur.Data = surr;
                            picture_sur.Image = image_sur.Bitmap;
                            picture_post_sur.Image = image_post_sur_bgr.Bitmap;
                            prev_surr = surr;
                        }
                    }
                    // jeżeli nie ma części wzorca przy krawędziach ekranu -  wyświetlamy informację o braku wzorca na obrazie.
                    else
                    {
                        CvInvoke.PutText(image_temp1_bgr, "No match", new Point(10, 10), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                        CvInvoke.PutText(image_temp2, "No match", new Point(10, 10), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
                        listView_pos.Items.Add("Brak wzorca");
                    }
                }
            }

            picture_post_det.Image = image_temp1_bgr.Bitmap;
            picture_ori_det.Image = image_temp2.Bitmap;
        }
        #endregion

        #region filtry
        private void highPassFilter()
        {
            double[] wsp = new double[] { -1, -1, -1,
                                          -1,  9, -1,
                                          -1, -1, -1 };
            double suma_wsp = 0;

            for (int i = 0; i < 9; i++)
            {
                suma_wsp += wsp[i];
            }

            byte[,,] temp1 = image_temp1.Data;
            byte[,,] temp2 = image_temp1.Data;

            for (int x = 1; x < desired_image_size.Width - 1; x++)
            {
                for (int y = 1; y < desired_image_size.Height - 1; y++)
                {
                    double B = 0;
                    B += wsp[0] * temp1[y - 1, x - 1, 0];
                    B += wsp[1] * temp1[y - 1, x, 0];
                    B += wsp[2] * temp1[y - 1, x + 1, 0];

                    B += wsp[3] * temp1[y, x - 1, 0];
                    B += wsp[4] * temp1[y, x, 0];
                    B += wsp[5] * temp1[y, x + 1, 0];

                    B += wsp[6] * temp1[y + 1, x - 1, 0];
                    B += wsp[7] * temp1[y + 1, x, 0];
                    B += wsp[8] * temp1[y + 1, x + 1, 0];

                    if ((int)suma_wsp != 0)
                    {
                        B /= suma_wsp;
                    }

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;

                    temp2[y, x, 0] = (byte)B;
                }
            }
            image_temp1.Data = temp2;
            image_temp1.CopyTo(image_post);
            picture_post.Image = image_temp1.Bitmap;
        }

        private void lowPassFilter()
        {
            double[] wsp = new double[] {1, 8, 1,
                                         4, 6, 4,
                                         1, 8, 1};
            double suma_wsp = 0;

            for (int i = 0; i < 9; i++)
            {
                suma_wsp += wsp[i];
            }

            byte[,,] temp1 = image_temp1.Data;
            byte[,,] temp2 = image_temp1.Data;

            for (int x = 1; x < desired_image_size.Width - 1; x++)
            {
                for (int y = 1; y < desired_image_size.Height - 1; y++)
                {
                    double B = 0;
                    B += wsp[0] * temp1[y - 1, x - 1, 0];
                    B += wsp[1] * temp1[y - 1, x, 0];
                    B += wsp[2] * temp1[y - 1, x + 1, 0];

                    B += wsp[3] * temp1[y, x - 1, 0];
                    B += wsp[4] * temp1[y, x, 0];
                    B += wsp[5] * temp1[y, x + 1, 0];

                    B += wsp[6] * temp1[y + 1, x - 1, 0];
                    B += wsp[7] * temp1[y + 1, x, 0];
                    B += wsp[8] * temp1[y + 1, x + 1, 0];

                    if ((int)suma_wsp != 0)
                    {
                        B /= suma_wsp;
                    }

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;

                    temp2[y, x, 0] = (byte)B;
                }
            }
            image_temp1.Data = temp2;
            picture_post.Image = image_temp1.Bitmap;
        }

        #endregion

        #region events

        private void picture_ori_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            MouseEventArgs me = e as MouseEventArgs;
            byte[,,] temp = image_PB1.Data;
            byte R, G, B;
            B = temp[me.Y, me.X, 0];
            G = temp[me.Y, me.X, 1];
            R = temp[me.Y, me.X, 2];
            listView1.Items.Add("Kolor RGB = " + R.ToString() + ", " + G.ToString() + ", " + B.ToString() + "\n");
            listView1.Items.Add("Pozycja = " + me.X.ToString() + ", " + me.Y.ToString() + "\n");
        }

        private void picture_post_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            byte[,,] temp = image_PB1.Data;
            byte R, G, B;
            B = temp[me.Y, me.X, 0];
            G = temp[me.Y, me.X, 1];
            R = temp[me.Y, me.X, 2];
            listView1.Items.Add("Kolor RGB Przetworzony = " + R.ToString() + ", " + G.ToString() + ", " + B.ToString() + "\n");
        }

        private void button_cameraJPG_Click(object sender, EventArgs e)
        {
            Mat temp = new Mat();
            camera.Read(temp);
            CvInvoke.Resize(temp, temp, picture_ori.Size);
            image_PB1 = temp.ToImage<Bgr, byte>();
            picture_ori.Image = image_PB1.Bitmap;
        }

        private void button_cameraMovie_Click(object sender, EventArgs e)
        {
            movie = !movie;
            timer1.Enabled = movie;
        }

        private void button_threshold_Click(object sender, EventArgs e)
        {
            Kolorki();
        }

        private void button_lowPass_Click(object sender, EventArgs e)
        {
            lowPassFilter();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button_highPass_Click(object sender, EventArgs e)
        {
            highPassFilter();
        }

        private void button_erode_Click(object sender, EventArgs e)
        {
            image_temp1.Erode(1);
            picture_post.Image = image_temp1.Bitmap;
        }

        private void button_dilate_Click(object sender, EventArgs e)
        {
            image_temp1.Dilate(1);
            picture_post.Image = image_temp1.Bitmap;
        }

        private void button_detect_Click(object sender, EventArgs e)
        {
            FindRect();
        }

        #endregion
    }
}
