using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CustomFrame.Properties
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					ResourceManager resourceManager = (resourceMan = new ResourceManager("CustomFrame.Properties.Resources", typeof(Resources).Assembly));
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap cficon
		{
			get
			{
				object @object = ResourceManager.GetObject("cficon", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Lines
		{
			get
			{
				object @object = ResourceManager.GetObject("Lines", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Simple
		{
			get
			{
				object @object = ResourceManager.GetObject("Simple", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
}

