using System.Drawing;
using System.IO;
using CustomFrame.Properties;
using PaintDotNet;
using PaintDotNet.Effects;

namespace CustomFrame
{
    public class EffectPlugin : Effect
    {
        private Surface sFrame;

        private UserBlendOp ubo;

        public static string StaticName => "Add Custom Frame";

        public static Bitmap StaticIcon => Resources.cficon;

        public static string StaticSubMenuName => SubmenuNames.Render;

        public EffectPlugin()
            : base(StaticName, StaticIcon, StaticSubMenuName, EffectFlags.Configurable)
        {
        }

        public override EffectConfigDialog CreateConfigDialog()
        {
            return new SelectFrame();
        }

        private UserBlendOp BlendModeFromValue(int value)
        {
            switch (value)
            {
                case 0:
                    return new UserBlendOps.NormalBlendOp();
                case 1:
                    return new UserBlendOps.MultiplyBlendOp();
                case 2:
                    return new UserBlendOps.AdditiveBlendOp();
                case 3:
                    return new UserBlendOps.ColorBurnBlendOp();
                case 4:
                    return new UserBlendOps.ColorDodgeBlendOp();
                case 5:
                    return new UserBlendOps.ReflectBlendOp();
                case 6:
                    return new UserBlendOps.GlowBlendOp();
                case 7:
                    return new UserBlendOps.OverlayBlendOp();
                case 8:
                    return new UserBlendOps.DifferenceBlendOp();
                case 9:
                    return new UserBlendOps.NegationBlendOp();
                case 10:
                    return new UserBlendOps.LightenBlendOp();
                case 11:
                    return new UserBlendOps.DarkenBlendOp();
                case 12:
                    return new UserBlendOps.ScreenBlendOp();
                case 13:
                    return new UserBlendOps.XorBlendOp();
                default:
                    return new UserBlendOps.NormalBlendOp();
            }
        }

        protected override void OnSetRenderInfo(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs)
        {
            FrameConfigToken frameConfigToken = (FrameConfigToken)parameters;
            string text = Path.Combine(PdnInfo.UserDataPath, "Custom Frames");
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
                Resources.Lines.Save(Path.Combine(text, "Lines.png"));
                Resources.Simple.Save(Path.Combine(text, "Simple.png"));
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(text);
            Bitmap original = new Bitmap(1, 1);
            if (frameConfigToken.FrameIndex > 0)
            {
                original = new Bitmap(Image.FromFile(directoryInfo.GetFiles()[frameConfigToken.FrameIndex - 1].FullName));
            }
            sFrame = new Surface(srcArgs.Size);
            sFrame.CopySurface(Surface.CopyFromBitmap(new Bitmap(original, srcArgs.Size)));
            ubo = BlendModeFromValue(frameConfigToken.BlendMode).CreateWithOpacity(frameConfigToken.Opacity);
        }

        public override void Render(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs, Rectangle[] rois, int startIndex, int length)
        {
            _ = (FrameConfigToken)parameters;
            for (int i = startIndex; i < length; i++)
            {
                Rectangle rectangle = rois[i];
                for (int j = rectangle.Top; j < rectangle.Bottom; j++)
                {
                    for (int k = rectangle.Left; k < rectangle.Right; k++)
                    {
                        dstArgs.Surface[k, j] = ubo.Apply(srcArgs.Surface[k, j], sFrame[k, j]);
                    }
                }
            }
        }
    }
}

