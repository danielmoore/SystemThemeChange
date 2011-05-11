﻿using System.Windows;
using System.Reflection;

namespace NorthHorizon.Samples.SystemThemeChange
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			//SetTheme("aero", "normalcolor");
		}

		/// <summary>
		/// Sets the WPF system theme.
		/// </summary>
		/// <param name="themeName">The name of the theme. (ie "aero")</param>
		/// <param name="themeColor">The name of the color. (ie "normalcolor")</param>
		public static void SetTheme(string themeName, string themeColor)
		{
			const BindingFlags staticNonPublic = BindingFlags.Static | BindingFlags.NonPublic;

			var presentationFrameworkAsm = Assembly.GetAssembly(typeof(Window));

			var themeWrapper = presentationFrameworkAsm.GetType("MS.Win32.UxThemeWrapper");

			var isActiveField = themeWrapper.GetField("_isActive", staticNonPublic);
			var themeColorField = themeWrapper.GetField("_themeColor", staticNonPublic);
			var themeNameField = themeWrapper.GetField("_themeName", staticNonPublic);

			// Set this to true so WPF doesn't default to classic.
			isActiveField.SetValue(null, true);

			themeColorField.SetValue(null, themeColor);
			themeNameField.SetValue(null, themeName);
		}
	}
}
