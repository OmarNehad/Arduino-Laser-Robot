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

