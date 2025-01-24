# Procedural-Map-Generation

This is a project I built to study Procedural Map Generation.<br />
You can check it at: (https://calistogamestudio.itch.io/procgen)

![image](https://github.com/user-attachments/assets/4ca6aed0-1079-4a43-aa91-d8ad71ac2317)


# How It Works?
To generate the map, I used a Perlin Noise function from Unity's scripting API. This function returns a value between 1 and 0 for each position. <br />
Here is the result: <br /><br />
![Perlin Noise](https://user-images.githubusercontent.com/63363544/224132030-ed4e71c6-a6d7-49a6-a345-dc6cfcb366bc.png)

Then, to generate the image, the values are interpreted as height and colored:
Value         | Color
---------     | ------
0.00 to 0.4   | Blue
0.4 to 0.5    | Yelow
0.5 to 0.8    | Green
0.8 to 1.00   | White

The result is:<br /><br />
![image](https://github.com/user-attachments/assets/588e5574-694d-4d3c-a15f-657064c5b895)

### Ading more detail
To create more details in the terrain, I used a technique called *octaves*. 
The technique involves combining multiple noise images, with varying amplitudes and frequencies.
resulting in the following image:<br /><br />
![Perlin Noise Octaves](https://user-images.githubusercontent.com/63363544/224130552-a108efa0-2133-4975-90ea-783b9551ce33.png "Perlin Noise With 10 Octaves") <br />

And if you add more colors, you will get the first image.



# Some Nice Links
* How to calculate Perlin Noise [video](https://youtu.be/MJ3bvCkHJtE?si=3z_e71niuB3YSMQV&t=404) by Fataho
* Sebastian Lague's [playlist](https://www.youtube.com/playlist?list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3) about implementing procedural terrain generation in Unity.
* Mojang's cofounder Henrik Kniberg's [talk](https://youtu.be/CSa5O6knuwI) about Minecraft's procedural generation. 
