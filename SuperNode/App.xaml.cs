﻿using SuperNode.StarGraph;

namespace SuperNode;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//MainPage = new AppTabbedPage();
	}
}
