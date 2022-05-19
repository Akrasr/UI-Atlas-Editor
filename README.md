# UI-Atlas-Editor
The tool for editing UIAtlas files in AJ, AAI and AAI2 mobile ports

# What is UI Atlas?
Some of the interfaces' images are saved as atlases. Atlas is the image that contains the other images used somewhere. These atlases contain images of UI elements. So the game loads these images from atlas by cutting them from it. UIAtlas is the class, objects of which contain all information about how to cut images from atlases and how to place them right.

# Where are the UIAtlas files that I will need to edit?
AJ:<br>
Title Atlas: in sharedassets 4 with File id being equal 120<br>
Options Atlas: faa765654f656a84eb69f5118270dd22<br>
SaveLoad Atlas: cd82c3e2ce004ff4c9145891d8718a8a<br>
NamePlate Atlas: 190392c10e17c4f7d81f4d0aa082dfde<br>
AAI:<br>
Title Atlas: sharedassets5 (if you will extract everything from it with UnityEX the name of file you need is "sharedassets5_00001.-3")<br>
Dialog Atlas: sharedassets1 ("sharedassets1_00001.-9")<br>
Options Atlas: sharedassets1 ("sharedassets1_00003.-9")<br>
Retry Atlas: sharedassets1 ("sharedassets1_00004.-9")<br>
SaveLoad Atlas: sharedassets1 ("sharedassets1_00005.-9" or "sharedassets1_00007.-9")<br>
AAI2:<br>
Episode Select Atlas: 3f05dd507ac1943489a86adf731cc966<br>
Title Atlas: 6bc2c5a5e39fd43768b9c3ead893bbed<br>
Dialog Atlas: 0eb7eaece68ca47229d1f4807fd659f9<br>
Options Atlas: 5feea654de648420f91535b98332b779<br>
Retry Atlas: fe6876381a12e5148a0a6fc95e926848<br>
SaveLoad Atlas: 539b3f0e6339f48debff1761d3f06f38 and 3a9d8ee405ae7430ba263b6ae3647fa1<br>

# How can I edit the images from atlas texture?
Use Photoshop or Paint Tool Sai or whatever you use to edit graphics.

# How to use this tool?
1. Open UIAtlas file and atlas texture that you need to edit them.
2. Choose the image that you want to edit in listbox and edit it.
3. Save it.

# OK. Now I have changed the width and height of an image but it looks compressed inside the game. How can I fix that?
Edit paddings of an image. For example, if your image is higher by 4 pixels than the original, add -2 to PaddingTop and PaddingBottom. And if it's longer by 6 add -3 to PaddingLeft and PaddingRight.

# I want to change position of UI element on the screen. How can I do that?
You can edit paddings for these purposes. For example, if you need to place an Image to 2 pixels higher, add -2 to PaddingTop and 2 to PaddingBottom.
