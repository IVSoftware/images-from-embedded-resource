When you say that you added images to the .resx, I'm not sure how you went about doing that. But one thing I would try is to embed them by manipulating the .csproj file directly. I tried generating 3500 alternating test images (you said 277kb these happen to be 244kb).

[![solution explorer window][1]][1]

Next, I generated tags I could copy into the .csproj

```
// Copy to cs.proj file
for (int i = 0; i <= 3500; i++) 
{
    Debug.WriteLine(@$"    <EmbeddedResource Include=""Images\sample-image-{i.ToString("D5")}.png"" />");
}
```

with the final result in .csproj being:

```

  <ItemGroup>
	  <EmbeddedResource Include="Images\sample-image-00000.png" />
	  <EmbeddedResource Include="Images\sample-image-00001.png" />
	  <EmbeddedResource Include="Images\sample-image-00002.png" />
	  <EmbeddedResource Include="Images\sample-image-00003.png" />
	  <EmbeddedResource Include="Images\sample-image-00004.png" />
	  <EmbeddedResource Include="Images\sample-image-00005.png" />
	  <EmbeddedResource Include="Images\sample-image-00006.png" />
	  <EmbeddedResource Include="Images\sample-image-00007.png" />
	  <EmbeddedResource Include="Images\sample-image-00008.png" />
	  <EmbeddedResource Include="Images\sample-image-00009.png" />
	  <EmbeddedResource Include="Images\sample-image-00010.png" />
	  <EmbeddedResource Include="Images\sample-image-00011.png" />
	  .
	  .
	  .
	  <EmbeddedResource Include="Images\sample-image-03497.png" />
	  <EmbeddedResource Include="Images\sample-image-03498.png" />
	  <EmbeddedResource Include="Images\sample-image-03499.png" />
	  <EmbeddedResource Include="Images\sample-image-03500.png" />
  </ItemGroup>
```
---
Then all you need is an extension to load an embedded image into the picture box.

```
static class Extensions
{
    public static Image FromNamedResource(this string name)
    {
        using (Stream imageStream = typeof(MainForm).Assembly.GetManifestResourceStream(name))
        {
            if (imageStream == null)
            {
                return new Bitmap(0, 0);
            }
            else
            {
                return new Bitmap(imageStream);
            }
        }
    }
}
```

The executable is a whopping 3/4 of a gigabyte, but it seems to build and run ok. Perhaps you can use this as a starting point and experiment further.

___

Here's the code I used to test this answer:

[![images 1 and 2 of 3500][2]][2]

```
namespace images_from_embedded_resource
{
    public partial class MainForm : Form
    {
        const int MAX_IMAGES = 3500;
        public MainForm()
        {
            InitializeComponent();
            buttonUpArrow.Text = "\u2191";
            buttonDownArrow.Click += (sender, e) => Index = Math.Min(Index + 1, MAX_IMAGES);
            buttonDownArrow.Text = "\u2193";
            buttonUpArrow.Click += (sender, e) => Index = Math.Max(Index - 1, 0);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            Index = 0;

#if GENERATE_TEST_IMAGES
            for (int i = 2; i <= 3500; i++) 
            {
                // Alternating test images
                if(i%2 == 0)
                {
                    File.Copy(
                        @"D:\Github\stackoverflow\Tozz\images-from-embedded-resource\images-from-embedded-resource\Images\sample-image-00000.png",
                       $@"D:\Github\stackoverflow\Tozz\images-from-embedded-resource\images-from-embedded-resource\Images\sample-image-{i.ToString("D5")}.png",
                       overwrite: true
                    );
                }
                else
                {
                    File.Copy(
                        @"D:\Github\stackoverflow\Tozz\images-from-embedded-resource\images-from-embedded-resource\Images\sample-image-00001.png",
                       $@"D:\Github\stackoverflow\Tozz\images-from-embedded-resource\images-from-embedded-resource\Images\sample-image-{i.ToString("D5")}.png",
                       overwrite: true
                    );
                }
            }
#endif
#if GENERATE_CSPROJ_TAGS
            // Copy to cs.proj file
            for (int i = 0; i <= 3500; i++) 
            {
                Debug.WriteLine(@$"    <EmbeddedResource Include=""Images\sample-image-{i.ToString("D5")}.png"" />");
            }
#endif
            // Make sure resources are embedded
            foreach (var name in typeof(MainForm).Assembly.GetManifestResourceNames().Where(_ => _.Contains(".png")))
            {
                Debug.WriteLine(name);
            }
        }
        int _index = -1;
        public int Index
        {
            get => _index;
            set
            {
                if (!Equals(_index, value))
                {
                    _index = value;
                    pictureBox.BackgroundImage = $"images_from_embedded_resource.Images.sample-image-{Index.ToString("D5")}.png".FromNamedResource();
                    Text = $"{Index.ToString("D5")}";
                }
            }
        }
    }
}
```


  [1]: https://i.stack.imgur.com/XBiLL.png
  [2]: https://i.stack.imgur.com/oWoMj.png