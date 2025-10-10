using BCnEncoder.Decoder;
using BCnEncoder.ImageSharp;
using GFEditor.Renderer;
using GFEditor.Specific;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GFEditor.Utils
{

    public static class TextureUtils
    {
        public static Texture2D LoadTextureFromFile(string filePath)
        {
            var texture = new Texture2D();
            if (OpenGL.Ptr == null) return texture;

            // Load DDS files using BCnEncoder
            if (Path.GetExtension(filePath).Equals(".dds", StringComparison.CurrentCultureIgnoreCase))
                return LoadDDSTextureFromFile(filePath);

            // Else use StbImage for other formats
            if (!filePath.FileExist()) return texture;

            unsafe
            {
                int width = 0, height = 0, channels = 0;
                var img = StbImage.Load(filePath, ref width, ref height, ref channels, 0);
                texture.Width = width;
                texture.Height = height;
                texture.Channels = channels;
                texture.Create();
                texture.Bind();
                texture.WrapAndFilter(GLTextureWrapMode.Repeat, GLTextureMinFilter.Linear, GLTextureMagFilter.Linear);
                texture.SetData(img);
                texture.GenerateMipmap();
                texture.Unbind();
                StbImage.ImageFree(img);
            }

            return texture;
        }

        private static Texture2D LoadDDSTextureFromFile(string filePath)
        {
            var texture = new Texture2D();
            if (OpenGL.Ptr == null) return texture;

            using var fs = File.OpenRead(filePath);
            var decoder = new BcDecoder();
            using Image<Rgba32> image = decoder.DecodeToImageRgba32(fs);

            texture.Width = image.Width;
            texture.Height = image.Height;
            texture.Channels = 4; // Rgba32 has 4 channels

            // Extract pixel data as a byte array
            var pixelData = new byte[image.Width * image.Height * 4];
            image.CopyPixelDataTo(pixelData);

            texture.Create();
            texture.Bind();
            texture.WrapAndFilter(GLTextureWrapMode.Repeat, GLTextureMinFilter.Linear, GLTextureMagFilter.Linear);
            texture.SetData(pixelData);
            texture.GenerateMipmap();
            texture.Unbind();

            return texture;
        }
    }
}
