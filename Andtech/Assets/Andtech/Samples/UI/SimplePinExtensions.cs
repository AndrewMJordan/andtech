
namespace Andtech.Samples
{

    public static class SimplePinExtensions
    {

        public static void Link(this Viewport viewport, SimplePin pin)
        {
            pin.Viewport = viewport;
        }

        public static void Unlink(this Viewport viewport, SimplePin pin)
        {
            pin.Viewport = null;
        }
    }
}
