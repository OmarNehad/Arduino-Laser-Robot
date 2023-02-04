# About the Project
This a report of the elective COME317 Intelligent Robotics course final project at UU. In this project an Arduino-powered robot is developed with a flexible design that enables it to accurately direct a mounted laser towards a designated target dot. The project showcases the utilization of the Arduino board, the solution of the robot's kinematic equations, and the application of image processing techniques.

# The robot build

The robot is constructed using a pan-tilt stand with two servomotors to enable the stand to move horizontally and vertically (check the figure below), the first motor is responsible for the horizontal motion, this motor is attached to the bottom of the stand connecting the whole structure to the base, and the second motor is responsible for the vertical motion, this motor holds the upper and lower part of the robot together resulting in a joint that rotates in the x-y plane. Together with a laser-module we were able to construct the robot, thus finalizing the mechanical work for this project, and what was left to do is the software part.
![Robot body](https://user-images.githubusercontent.com/52573189/216757954-ff6cc295-190e-4c4d-be1c-745ce065900c.jpg)

The board selected has the following characteristics, the structure is shown in the figure below: 

- The are 3 dots used for calibration.
- The number of distances among these dots is 3, where each distance is 20 cm.
![Target board structure](https://user-images.githubusercontent.com/52573189/216757980-65325221-1f00-44c0-9d2a-d0f8c67c6638.jpg)

# Solving kinematics equation

1. Assigning Coordinate Frames: X, Y & Z axes.  
2. Finding Link Variable Table:  Inline equation: $\theta \text{ or} \space d$. . 
3. Substitute values to A matrices.
4. Find Root to Hand Matrix
5. Find Hand Location or Orientation


# Building the application
To complete the project, a .NET C# form application is built to give the user control of the variables that will affect the robot calibration and shoot functionalities as well as feedback of some values that may aid him in finding where the miscalculation has occurred.

## UI
Specifically the user can start and stop the camera; test and reset the robot orientation; calibrate the image to calculate the scale and a shoot button to shoot the laser; segmentation and corrosion sliders to manipulate the threshold values, more on that later.
## Coding the robot
![UI](https://user-images.githubusercontent.com/52573189/216758123-383f6341-442d-4777-984d-be53236900aa.jpg)

## App Logic part I: Image processing

For the robot to be able to shoot, it needs to process image and detect the black target and the red calibration dots. In order to achieve this we will first capture the current frame from the camera and   then separate them into grey scaled blue, green and red channels. Then, based on some threshold configured from the UI, we can basically filter the image to get the black and red dots by employing the segmentation and corrosion functions which will eventually gives us the needed data to calculate the coordinates of the target. Keep in mind that since the calibration dots are red and the target is black; the segmentation and corrosion functions are only done on those two colors.

### Capturing the image

```C#
// Define the catpure camera used for image processing
if (capture == null)
{
    try
    {
			// The paramter takes the index of the available cameras, 0 being the default one.
        capture = new Capture(1); 
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

// Define variables that stores the segmentated & corrosioned red and black images for the red and black dots */
R_Img_seg = IMG.Convert<Gray, Byte>();
R_Img_cor = IMG.Convert<Gray, Byte>();
B_Img_seg = IMG.Convert<Gray, Byte>();
B_Img_cor = IMG.Convert<Gray, Byte>();

````
### Segmentation

To cluster the red dots and the black target, segmentation is applied to the variables holding the red and black images by going through each pixel and setting it to white or black based on a variable threshold.

```C#
// Red Image segmenetation
for (int i = 0; i < IMG.Width; i++)
{
    for (int j = 0; j < IMG.Height; j++)
    {
        if ((R_frame[j, i].Intensity >= r_th) &&
					 (B_frame[j, i].Intensity + G_frame[j, i].Intensity) < r_th)

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
        if (((B_frame[j, i].Intensity < b_th) &&
					 (R_frame[j, i].Intensity) < b_th) &&
					 (G_frame[j, i].Intensity) < b_th)
            
						B_Img_seg.Data[j, i, 0] = 255;
        else
            B_Img_seg.Data[j, i, 0] = 0;
    }

}
```
### Corrosion

We apply corrosion to the variables holding the red and black images by going through each pixel a variable amount of time and filtering it to white or black based on the intensity of its neighbors.
This code is a bit slow but it yields a clean image. There is an alternate SmoothMedian function in Emgu.CV library that can achieve a good enough result but we went ahead and used the expensive solution since it does not hinder the application.

```C#

// Ultimately we are outputting corrosion varables so we need tocopy the segmentation result into them to be able to see them.
R_Img_cor = R_Img_seg.Copy();

//in case of a slow performance, check the SmoothMedian function

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
```

## App Logic part II: Shooting the target

### Projection

```csharp
double[] projection = new double[IMG.Width];
for (int i = 0; i < IMG.Width; i++)
{
    double Pxcolumn = 0;
    for (int j = 0; j < IMG.Height; j++)
    {
				// diving by 255 yeilds the result in 0-1 range
        projection[i] = Pxcolumn = Pxcolumn + ((R_Img_cor[j, i].Intensity) / 255); 
    }

}
```

### Calculating pixel to cm scale

```csharp
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
```

### Calculating target pixel coordinates

```csharp
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
		double Ycm = Py * Px2CmScale;
		double Zcm = Pz * Px2CmScale + laserToCamera;
		.............
```

### Inverse kinematics equation

```csharp
// Calculting the angles using the derived kinematics equation
double Th1 = Math.Atan(Ycm / cameraToTarget);
double Th2 = Math.Atan(((Zcm) / Ycm) * Math.Sin(Math.Atan(Ycm / cameraToTarget)));

//Converting the angle from radians to degrees.
Th2 *= (180 / Math.PI);
Th1 *= (180 / Math.PI);
```

### C# & Arduino communication

```csharp
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
```

