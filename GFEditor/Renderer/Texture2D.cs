namespace GFEditor.Renderer
{
#pragma warning disable CA1822 // Mark members as static
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

        public void Create()
        {
            if (OpenGL.Ptr == null) return;
            Id = OpenGL.Ptr.GenTexture();
        }

        public void Bind()
        {
            if (OpenGL.Ptr == null) return;
            OpenGL.Ptr.BindTexture(GLTextureTarget.Texture2D, Id);
        }

        public void Unbind()
        {
            if (OpenGL.Ptr == null) return;
            OpenGL.Ptr.BindTexture(GLTextureTarget.Texture2D, 0);
        }

        public void WrapAndFilter(GLTextureWrapMode wrapMode, GLTextureMinFilter minFilter, GLTextureMagFilter magFilter)
        {
            OpenGL.Ptr.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapS, (int)wrapMode);
            OpenGL.Ptr.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.WrapT, (int)wrapMode);
            OpenGL.Ptr.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MinFilter, (int)minFilter);
            OpenGL.Ptr.TexParameteri(GLTextureTarget.Texture2D, GLTextureParameterName.MagFilter, (int)magFilter);
        }

        public unsafe void SetData(byte* data)
        {
            if (OpenGL.Ptr == null) return;
            var format = Channels == 4 ? GLPixelFormat.Rgba : GLPixelFormat.Rgb;
            OpenGL.Ptr.TexImage2D(GLTextureTarget.Texture2D, 0, GLInternalFormat.Rgba, Width, Height, 0, format, GLPixelType.UnsignedByte, data);
        }

        public unsafe void SetData(byte[] data)
        {
            if (OpenGL.Ptr == null) return;
            var format = Channels == 4 ? GLPixelFormat.Rgba : GLPixelFormat.Rgb;
            fixed (byte* ptr = data)
            {
                OpenGL.Ptr.TexImage2D(GLTextureTarget.Texture2D, 0, GLInternalFormat.Rgba, Width, Height, 0, format, GLPixelType.UnsignedByte, ptr);
            }
        }

        public void GenerateMipmap()
        {
            if (OpenGL.Ptr == null) return;
            OpenGL.Ptr.GenerateMipmap(GLTextureTarget.Texture2D);
        }

        public void Dispose()
        {
            if (OpenGL.Ptr == null) return;
            if (Id != 0) OpenGL.Ptr.DeleteTexture(Id);
        }
    }
#pragma warning restore CA1822 // Mark members as static
}
