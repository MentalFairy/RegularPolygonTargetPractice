# RegularPolygonTargetPractice

Firstly, thanks for the challenge! I had fun and learned something new. Here's a breakdown of my approach:

###Instructions:
Open with Unity 6.0.x.1f, build with .26 version as per instructions, but should work with anything.
Hit play, test it out.
Or attach your android phone, build and deploy to your device.
Or if you risk yourself, or trust me that I did not add any crypto miners in the build, you can install the .apk.

### Time to Develop:
- **Time spent**: Probably less than an hour.
- **Wild Goose Chase**: The first 2 hours were spent chasing a wild goose. I initially thought it would be nice to create a component where you could specify the number of equal sides for a shape. The idea was to use a `LineRenderer` to draw it and have a `PolygonCollider` to detect clicks/taps inside the shape. However, the shader intended to mask content inside the LineRenderer didn’t work as expected, and the masking failed. I realized that this solution would only work for polygons with equal sides and wouldn't work for custom shapes. 

So, I decided to pivot and come up with a more customizable solution!

### New Solution:
- **Shape Click Detection**: Ensures that clicks/taps only inside the shape trigger a double-click/tap response.
- **Sprite Color Change**: Changes the color of the sprite renderer when clicked/tapped.
- **Shape Selection**: Includes a dropdown to select the shape (from triangle to decagon). Yes, I hand-drew those textures.
- **Customization**: Can add any shape, with any polygoncollider, with the added simplicity of prefab variants.
- **Overkilled with events**: Most of my large-scale architecture solutions, even inside unity, are based around events as they can decouple logic and simplify tasks for teamwork. 
  
### Optional Challenges:
- **Dotween Integration**: Added a simple scale animation using `DOTween`.
- **Gesture Handling**: I didn't create a new solution for custom gestures, as I did that during my second year of university, and it's now deprecated. Instead, I use [Lean Touch](https://assetstore.unity.com/packages/tools/input-management/lean-touch-72356) — worth every penny. Couldn't add it here, it's against Terms of service.
- **Image Masking**: I masked a Naruto sprite (it’s pretty simple). I also considered implementing this in the UI, so I added the `SoftMask` package to the project.
- **Trippy Shader**: Added a very trippy shader to increase the difficulty of hitting the shape.
- **Game**: It can be considered a game (a very basic one, but still a game). 😄
- **Audio**: It's not much, but I also added a mastermixer as a good practice. 

### More show-off:
For more info, check out my [Toptal profile](https://www.toptal.com/resume/radu-adrian-marcu) or [LinkedIn](https://www.linkedin.com/in/radu-adrian-marcu-992349108/), both listed in my resume.

P.S.
When unity says that "Both" input systems are no longer supported on mobile devices concomitently, they actually mean that only the new one is supported.