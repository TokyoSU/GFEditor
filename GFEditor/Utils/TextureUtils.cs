using BCnEncoder.Decoder;
using BCnEncoder.ImageSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GFEditor.Utils
{
    public class Texture2D
    {
        public uint Id = 0;
        public int Width = 0;
        public int Height = 0;
        public int Channels = 0;

        public unsafe ImTextureRef ToImGui()
        {
            return new ImTextureRef(null, new ImTextureID(Id));
        }
    }

    public static class TextureUtils
    {
        private static GL? gl;

        public static void SetGLContext(GL glContext) => gl = glContext;

        public static Texture2D LoadTextureFromFile(string filePath)
        {
            // Load DDS files using BCnEncoder
            if (Path.GetExtension(filePath).Equals(".dds", StringComparison.CurrentCultureIgnoreCase))
                return LoadDDSTextureFromFile(filePath);

            // Else use StbImage for other formats
            var texture = new Texture2D();
            if (gl == null) return texture;
            if (!filePath.FileExist()) return texture;

            unsafe
            {
                int width = 0, height = 0, channels = 0;
                var img = StbImage.Load(filePath, ref width, ref height, ref channels, 0);
                texture.Id = gl.GenTexture();
                texture.Width = width;
                texture.Height = height;
                texture.Channels = channels;
                gl.BindTexture(GLTextureTarget.Texture2D, texture.Id);
                gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapS, (int)GLTextureWrapMode.Repeat);
                gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapT, (int)GLTextureWrapMode.Repeat);
                gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MinFilter, (int)GLTextureMinFilter.Linear);
                gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MagFilter, (int)GLTextureMagFilter.Linear);
                var format = texture.Channels == 4 ? GLPixelFormat.Rgba : GLPixelFormat.Rgb;
                gl.TexImage2D(GLTextureTarget.Texture2D, 0, GLInternalFormat.Rgba, texture.Width, texture.Height, 0, format, GLPixelType.UnsignedByte, img);
                gl.GenerateMipmap(GLTextureTarget.Texture2D);
                StbImage.ImageFree(img);
            }

            return texture;
        }

        private static Texture2D LoadDDSTextureFromFile(string filePath)
        {
            var texture = new Texture2D();
            if (gl == null) return texture;
            using var fs = File.OpenRead(filePath);
            var decoder = new BcDecoder();
            using Image<Rgba32> image = decoder.DecodeToImageRgba32(fs);

            texture.Width = image.Width;
            texture.Height = image.Height;
            texture.Channels = 4; // Rgba32 has 4 channels

            // Extract pixel data as a byte array
            var pixelData = new byte[image.Width * image.Height * 4];
            image.CopyPixelDataTo(pixelData);

            texture.Id = gl.GenTexture();
            gl.BindTexture(GLTextureTarget.Texture2D, texture.Id);
            gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapS, (int)GLTextureWrapMode.Repeat);
            gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapT, (int)GLTextureWrapMode.Repeat);
            gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MinFilter, (int)GLTextureMinFilter.Linear);
            gl.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MagFilter, (int)GLTextureMagFilter.Linear);

            unsafe
            {
                fixed (byte* ptr = pixelData)
                {
                    gl.TexImage2D(
                        GLTextureTarget.Texture2D,
                        0,
                        GLInternalFormat.Rgba,
                        texture.Width,
                        texture.Height,
                        0,
                        GLPixelFormat.Rgba,
                        GLPixelType.UnsignedByte,
                        (IntPtr)ptr
                    );
                }
            }

            gl.GenerateMipmap(GLTextureTarget.Texture2D);

            return texture;
        }

        public static void DisposeTexture(Texture2D texture)
        {
            gl?.DeleteTexture(texture.Id);
        }
    }
}
