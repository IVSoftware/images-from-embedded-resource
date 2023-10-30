using System.Diagnostics;
using System.Windows.Forms;

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
}