using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetFontIcons
{
	public static class FontIconProvider
	{
		public static FontIconSet GetAllIcons(FontFamilies fontName)
		{
			List<FontIcon> icons = default;

			switch (fontName)
			{
				case FontFamilies.MaterialDesign:
					icons = GetFontList(typeof(MaterialDesign.Icons));
					break;

				case FontFamilies.FontAwesomeBrands:
					icons = GetFontList(typeof(FontAwesomeBrands.Icons));
					break;

				case FontFamilies.FontAwesomeRegular:
					icons = GetFontList(typeof(FontAwesomeRegular.Icons));
					break;

				case FontFamilies.FontAwesomeSolid:
					icons = GetFontList(typeof(FontAwesomeSolid.Icons));
					break;
			}

			return new FontIconSet()
			{
				FontName = fontName,
				Icons = icons
			};
		}

		private static List<FontIcon> GetFontList(Type type)
		{
			return type
				.GetFields(BindingFlags.Public | BindingFlags.Static)
				.Where(f => f.FieldType == typeof(string))
				.Select(fi =>
					new FontIcon()
					{
						Name = fi.Name,
						Value = fi.GetValue(null).ToString()
					}
				).ToList();
		}
	}
}