using System.Collections.Generic;

namespace NetFontIcons
{
	public class FontIconSet
	{
		public FontIconSet()
		{
			this.Icons = new List<FontIcon>();
		}

		public FontFamilies FontName { get; internal set; }
		public List<FontIcon> Icons { get; internal set; }
	}
}