using HigLabo.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BlobToEnumApplication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static BackgroundService BackgroundService { get; set; } = new(nameof(BackgroundService), 0);

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        App.BackgroundService.StartThread();
    }
}
