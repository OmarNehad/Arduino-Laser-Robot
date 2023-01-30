using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using Emgu.CV.UI;
using System.Reflection.Emit;


namespace MainApp
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        public byte[] Buff = new byte[2]; // Holds the data sent to the arduion; 2 bytes for 2 thetas

        private double Px2CmScale;

        private Capture capture;
        private Image<Bgr, Byte> IMG;

        private Image<Gray, Byte> R_frame;
        private Image<Gray, Byte> G_frame;
        private Image<Gray, Byte> B_frame;

        private Image<Gray, Byte> R_Img_seg;
        private Image<Gray, Byte> R_Img_cor;
        private Image<Gray, Byte> B_Img_seg;
        private Image<Gray, Byte> B_Img_cor;

        public Form1()
        {
            _serialPort = new SerialPort(); 
            _serialPort.PortName = "COM4"; //Change according to the port connected to the ardiuno
            _serialPort.BaudRate = 9600;   // Sets up the BaudRate same as the one defined in the arduino
            _serialPort.Open();

            InitializeComponent();
        }

        private void processFrame(object sender, EventArgs e)
        {
            // Define the catpure camera used for image processing
            if (capture == null)
            {
                try
                {
                    capture = new Capture(1); // the paramter defines the index of the available cameras, 0 being the default one.
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            // Contiously stores the captured frame and convert it to a grey image
            IMG = capture.QueryFrame();
            IMG.Convert<Gray, Byte>();

            // Split the image into BGR ( Blue, Green, Red) channels respectively 
            B_frame = IMG[0].Copy();
            G_frame = IMG[1].Copy();
            R_frame = IMG[2].Copy();

            //Define variables that stores the segmentated & corrosioned red and black images for the red and black dots
            R_Img_seg = IMG.Convert<Gray, Byte>();
            R_Img_cor = IMG.Convert<Gray, Byte>();
            B_Img_seg = IMG.Convert<Gray, Byte>();
            B_Img_cor = IMG.Convert<Gray, Byte>();



            int r_th, b_th, r_cor, b_cor;

            r_th = trackBarRedThr.Value;
            b_th = trackBarBlackThr.Value;
            r_cor = trackBarRedCor.Value;
            b_cor = trackBarBlackCor.Value;


            // Apply segmenetation to the variables holding the red and black images by going through each pixel and setting it to white or black based on a variable threshold.

            // Red Image segmenetation
            for (int i = 0; i < IMG.Width; i++)
            {
                for (int j = 0; j < IMG.Height; j++)
                {
                    if ((R_frame[j, i].Intensity >= r_th) && (B_frame[j, i].Intensity + G_frame[j, i].Intensity) < r_th)

                        R_Img_seg.Data[j, i, 0] = 255;
                    else
                        R_Img_seg.Data[j, i, 0] = 0;

                }
            }

            // Black Image segmenetation
            for (int i = 0; i < IMG.Width; i++)
            {
                for (int j = 0; j < IMG.Height; j++)
                {
                    if (((B_frame[j, i].Intensity < b_th) && (R_frame[j, i].Intensity) < b_th) && (G_frame[j, i].Intensity) < b_th)
                        B_Img_seg.Data[j, i, 0] = 255;
                    else
                        B_Img_seg.Data[j, i, 0] = 0;
                }

            }
            //Since we are outputting / using the corrosion varables, we need to copy the segmentation result into them.
            R_Img_cor = R_Img_seg.Copy();


            // Apply corrosions to the variables holding the red and black images by going through each pixel a variable amount of time and filtering it to white or black based on the intensity of its neighbors.
            // This code is a bit slow but it yeild an clean image, in case of a slow peformance, check the SmoothMedian function

            // Red Image corrosion
            for (int count = 0; count < r_cor; count++)
            {
                for (int i = 1; i < IMG.Width - 1; i++)
                    for (int j = 1; j < IMG.Height - 1; j++)

                        if (R_Img_seg[j, i].Intensity != 0)
                        {
                            if ((R_Img_seg[j, i + 1].Intensity == 0) ||
                                (R_Img_seg[j - 1, i - 1].Intensity == 0) ||
                                (R_Img_seg[j - 1, i].Intensity == 0) ||
                                (R_Img_seg[j - 1, i + 1].Intensity == 0) ||
                                (R_Img_seg[j + 1, i + 1].Intensity == 0) ||
                                (R_Img_seg[j + 1, i].Intensity == 0) ||
                                (R_Img_seg[j + 1, i - 1].Intensity == 0))
                                R_Img_cor.Data[j, i, 0] = 0;
                            else R_Img_cor.Data[j, i, 0] = 255;

                        }
                        else
                            R_Img_cor.Data[j, i, 0] = 0;

                // Update the segmentation variable using the corrosion result.
                R_Img_cor.CopyTo(R_Img_seg);
            }

            //Copy the segmentation result into corrosion variable.
            B_Img_cor = B_Img_seg.Copy();

            // Black Image corrosion
            for (int count = 0; count < b_cor; count++)
            {
                for (int i = 1; i < IMG.Width - 1; i++)
                    for (int j = 1; j < IMG.Height - 1; j++)

                        if (B_Img_seg[j, i].Intensity != 0)
                        {
                            if ((B_Img_seg[j, i + 1].Intensity == 0) ||
                                (B_Img_seg[j - 1, i - 1].Intensity == 0) ||
                                (B_Img_seg[j - 1, i].Intensity == 0) ||
                                (B_Img_seg[j - 1, i + 1].Intensity == 0) ||
                                (B_Img_seg[j + 1, i + 1].Intensity == 0) ||
                                (B_Img_seg[j + 1, i].Intensity == 0) ||
                                (B_Img_seg[j + 1, i - 1].Intensity == 0))
                                B_Img_cor.Data[j, i, 0] = 0;
                            else B_Img_cor.Data[j, i, 0] = 255;

                        }
                        else
                            B_Img_cor.Data[j, i, 0] = 0;


                B_Img_cor.CopyTo(B_Img_seg);
            }


            try
            {
                //Outputs the original image and the processed Red and Black images.
                imageBoxOriginal.Image = IMG;
                imageBoxRed.Image = R_Img_cor;
                imageBoxBlack.Image = B_Img_cor;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Allows the continous capture of image frames when the start button is clicked
        private void buttonStartCamera_Click(object sender, EventArgs e)
        {
            Application.Idle += processFrame;
            buttonStartCamera.Enabled = false;
            buttonStopCamera.Enabled = true;
        }

        // Stops the continous capture of image frames when the stop button is clicked
        private void buttonStopCamera_Click(object sender, EventArgs e)
        {
            Application.Idle -= processFrame;
            buttonStartCamera.Enabled = true;
            buttonStopCamera.Enabled = false;
        }


        private void buttonCalibration_Click(object sender, EventArgs e)
        {

            // Output the image width and height, this helps later for checking if scale value looks sound.
            labelWidth.Text = "Width: " + IMG.Width.ToString();
            labelHeight.Text = "Height: " + IMG.Height.ToString();

            double distanceBetweenPoints = 20.0;

            // This code loops over every pixel and finds the total red color intensity in one column and saves it in the projection variable
            double[] projection = new double[IMG.Width];
            for (int i = 0; i < IMG.Width; i++)
            {
                double Pxcolumn = 0;
                for (int j = 0; j < IMG.Height; j++)
                {
                    projection[i] = Pxcolumn = Pxcolumn + ((R_Img_cor[j, i].Intensity) / 255); // diving by 255 yeilds the result in 0-1 range
                }

            }

            //This piece of code loops over the projection array and detects the average value needed to calcualate the pixel to cm scale.
            int k = 0;
            double sum = 0;

            while (k < projection.Length && projection[k] == 0) { k++; }
            k += 5;
            int start = k; // start of the current red dot
            for (int i = 0; i < 2; i++)
            {
                while (k < projection.Length && projection[k] != 0) k++;
                k += 5;

                while (k < (IMG.Width - 5) && projection[k] == 0) k++;
                k += 5;
                int end = k; // end of the current red dot
                sum = sum + (end - start); //
                start = end; 
            }

            double Avg = sum / 2.0; //
            Px2CmScale = distanceBetweenPoints / Avg;

            labelScale.Text = "Scale: " + Px2CmScale.ToString("0.00");
            labelAverage.Text = "Average: " + Avg.ToString();
        }

        private void buttonShoot_Click(object sender, EventArgs e)
        {

            int Xpx = 0;
            int Ypx = 0;
            int n = 0;

            // This loop looks for the black dot (target)
            for (int i = 0; i < IMG.Width; i++)
                for (int j = 0; j < IMG.Height; j++)
                {
                    if (B_Img_cor[j, i].Intensity > 128)
                    {
                        Xpx += i;
                        Ypx += j;
                        n++;

                    }
                }

            if (n > 0)
            {

                //
                Xpx = Xpx / n;
                Ypx = Ypx / n;


                // calcuting the pixel coordiantes relative to the Origin point in the middle
                double Py = Xpx - (IMG.Width / 2); 
                double Pz = -(Ypx - (IMG.Height / 2));

                double cameraToTarget = 100; // Distance from camera to target in cm.
                double laserToCamera = 24; // Distance from camera to laser in cm.
                
                double Ycm = Py * Px2CmScale;
                double Zcm = Pz * Px2CmScale + laserToCamera;

                textBoxY_Cm.Text = Ycm.ToString("0.00");
                textBoxZ_Cm.Text = Zcm.ToString("0.00");
                textBoxX_Pix.Text = Xpx.ToString("0.00");
                textBoxY_Pix.Text = Ypx.ToString("0.00");

                // Calculting the angles using the derived kinematics equation
                double Th1 = Math.Atan(Ycm / cameraToTarget);
                double Th2 = Math.Atan(((Zcm) / Ycm) * Math.Sin(Math.Atan(Ycm / cameraToTarget)));
                
                //Converting the angle from radians to degrees.
                Th2 *= (180 / Math.PI);
                Th1 *= (180 / Math.PI);

                textBoxTheta_1.Text = Th1.ToString("0.00");
                textBoxTheta_2.Text = Th2.ToString("0.00");

                // Target is below the middle
                if (Th2 < 0)
                {
                    Th1 = ((int)90 - Th1);
                    Th2 = ((int)100 - Th2);
                }
                else // Target is above the middle
                {
                    Th1 = ((int)40 - Th1);
                    Th2 = ((int)40 - Th2);
                }

                //Populating the array that will be sent to the arduino, varialbe order is crucial.
                Buff[0] = (byte)Th1;
                Buff[1] = (byte)Th2;

                //Sending thetas to arduino
                _serialPort.Write(Buff, 0, 2);
            }

        }

        // Resets the robot to the default orientation of 90 degrees horizantally and vertically.
        private void buttonResetRobot_Click(object sender, EventArgs e)
        {
            Buff[0] = (byte)90;
            Buff[1] = (byte)80;
            _serialPort.Write(Buff, 0, 2);
        }

        // Test the communcation with the arduiono port by moving the robot.
        private void buttonTestRobot_Click(object sender, EventArgs e)
        {
            Buff[0] = (byte)45;
            Buff[1] = (byte)45;
            _serialPort.Write(Buff, 0, 2);
        }

    }
}
