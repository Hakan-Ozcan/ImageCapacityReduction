using System.Drawing;
using System.Drawing.Imaging;


//C# İle Resim Kapasitesini Ayarlama
class KapasiteAyarlayici
{
    private static ImageCodecInfo TipBilgisi(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }

    public static void KapasiteDusur(Image Resim)
    {
        Bitmap myBitmap;
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;

        myBitmap = new Bitmap(Resim);

        myImageCodecInfo = TipBilgisi("image/jpeg");

        myEncoder = System.Drawing.Imaging.Encoder.Quality;

        myEncoderParameters = new EncoderParameters(1);

        // 1L - 100L arasında bir değer ile kapasite ayarını gerçekleştiriyoruz.
        myEncoderParameter = new EncoderParameter(myEncoder, 1L);

        myEncoderParameters.Param[0] = myEncoderParameter;
        myBitmap.Save("Kayıt Edilecek Dizin", myImageCodecInfo, myEncoderParameters);
    }
}