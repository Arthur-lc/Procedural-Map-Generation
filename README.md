# Procedural-Map-Generation

This is a project I built to study Procedural Map Generation.<br />
You can check it at: (https://calistogamestudio.itch.io/procgen)

# How It Works?
To generate the map, I used a Perlin Noise function from Unity's scripting API. This function returns a value between 1 and 0 for each position. <br />
This is the result: <br />
![Perlin Noise exemple](https://user-images.githubusercontent.com/63363544/224120548-36f7c559-df58-4df6-915b-9852f278001b.png)

Then, to generate the image, each value is interpreted as height, and colored based on this table:
Value         | Color
---------     | ------
0.00 to 0.02  | Dark Blue
0.02 to 0.68  | Blue
0.06 to 0.17  | Light Blue
0.17 to 0.32  | Light Green
0.32 to 0.70  | Dark Green
0.70 to 0.87  | Light Gray
0.87 to 1.00  | White

<br />
To create more details on the terrain, it was used a technique called octaves. 
The technique consists in creating more than one noise images and adding them together.
Resulting in this: <br />
![image](https://user-images.githubusercontent.com/63363544/224125517-fe809263-1d35-45d3-a7ca-1c1563c1789e.png)
