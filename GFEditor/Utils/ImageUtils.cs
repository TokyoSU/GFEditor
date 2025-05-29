namespace GFEditor.Utils
{
    public static class ImageUtils
    {
        public static GLFWimage CreateIconFromFile(string path)
        {
            unsafe
            {
                if (!path.FileExist()) return new GLFWimage();
                int width = 0, height = 0, channels = 0;
                var img = StbImage.Load(path, ref width, ref height, ref channels, 0);
                return new GLFWimage(width, height, img);
            }
        }
    }
}
