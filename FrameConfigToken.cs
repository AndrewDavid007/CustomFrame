using PaintDotNet.Effects;

namespace CustomFrame
{
    internal class FrameConfigToken : EffectConfigToken
    {
        public int FrameIndex;

        public int BlendMode;

        public int Opacity;

        public FrameConfigToken()
        {
            FrameIndex = 0;
            BlendMode = 0;
            Opacity = 255;
        }

        public FrameConfigToken(FrameConfigToken copyMe)
        {
            FrameIndex = copyMe.FrameIndex;
            BlendMode = copyMe.BlendMode;
            Opacity = copyMe.Opacity;
        }

        public override object Clone()
        {
            return new FrameConfigToken(this);
        }
    }
}
