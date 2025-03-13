# RegularPolygonTargetPractice

Firstly, thanks for the challenge! I had fun and learned something new. Here's a breakdown of my approach:

### Time to Develop:
- **Time spent**: Probably less than an hour.
- **Wild Goose Chase**: The first 2 hours were spent chasing a wild goose. I initially thought it would be nice to create a component where you could specify the number of equal sides for a shape. The idea was to use a `LineRenderer` to draw it and have a `PolygonCollider` to detect clicks/taps inside the shape. However, the shader intended to mask content inside the LineRenderer didn’t work as expected, and the masking failed. I realized that this solution would only work for polygons with equal sides and wouldn't work for custom shapes. 

So, I decided to pivot and come up with a more customizable solution!

### New Solution:
- **Shape Click Detection**: Ensures that clicks/taps only inside the shape trigger a double-click/tap response.
- **Sprite Color Change**: Changes the color of the sprite renderer when clicked/tapped.
- **Shape Selection**: Includes a dropdown to select the shape (from triangle to decagon). Yes, I hand-drew those textures.
  
### Optional Challenges:
- **Dotween Integration**: Added a simple scale animation using `DOTween`.
- **Gesture Handling**: I didn't create a new solution for custom gestures, as I did that during my second year of university, and it's now deprecated. Instead, I use [Lean Touch](https://assetstore.unity.com/packages/tools/input-management/lean-touch-72356) — worth every penny. Couldn't add it here, it's against Terms of service.
- **Image Masking**: I masked a Naruto sprite (it’s pretty simple). I also considered implementing this in the UI, so I added the `SoftMask` package to the project.
- **Trippy Shader**: Added a very trippy shader to increase the difficulty of hitting the shape.
- **Game**: It can be considered a game (a very basic one, but still a game). 😄

### Extra:
For more info, check out my [Toptal profile](https://www.toptal.com/resume/radu-adrian-marcu) or [LinkedIn](https://www.linkedin.com/in/radu-adrian-marcu-992349108/), both listed in my resume.

### P.S.
I own a Pixel 7 and ran into this issue:  
[Unity Issue Tracker: Android touch input unresponsive on Pixel 7 Pro](https://issuetracker.unity3d.com/issues/android-touch-input-is-unresponsive-when-building-for-pixel-7-pro-device?page=2#comments)  
It's still unresolved as of now, but the UI works fine on Unity Remote 5 and on other devices.

