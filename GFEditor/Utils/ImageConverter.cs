using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats;
using System.Drawing.Imaging;
using System.IO;
using SLImage = SixLabors.ImageSharp.Image;
using WLImage = global::System.Drawing.Image;

namespace GFEditor.Utils
{
    public static class ImageConverter
    {
        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="imageIn">The Image to convert</param>
        /// <returns>An byte array containing the JPG format Image</returns>
        public static byte[] ToArray(this SLImage imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, JpegFormat.Instance);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="imageIn">The Image to convert</param>
        /// <param name="fmt"></param>
        /// <returns>An byte array containing the JPG format Image</returns>
        public static byte[] ToArray(this SLImage imageIn, IImageFormat fmt)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, fmt);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="imageIn">The Image to convert</param>
        /// <returns>An byte array containing the JPG format Image</returns>
        public static byte[] ToArray(this WLImage imageIn)
        {
            return ToArray(imageIn, ImageFormat.Png);
        }

        /// <summary>
        /// Converts the image data into a byte array.
        /// </summary>
        /// <param name="imageIn">The image to convert to an array</param>
        /// <param name="fmt">The format to save the image in</param>
        /// <returns>An array of bytes</returns>
        public static byte[] ToArray(this WLImage imageIn, ImageFormat fmt)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, fmt);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Extension method that converts a byte array with JPG data to an Image
        /// </summary>
        /// <param name="byteArrayIn">The byte array with JPG data</param>
        /// <returns>The reconstructed Image</returns>
        public static SLImage ToImage(this byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
                return SLImage.Load(ms);
        }

        public static WLImage ToNetImage(this byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
                return WLImage.FromStream(ms);
        }
    }
}
