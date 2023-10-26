# . NET MAUI APP NOTES 
---

# Folder Structure 

1. Platforms 
   Platform Specific Files 
   - Android
   - iOS
   - MacCatalyst
   - Tizen
   - Windows
2. Resources 
   Resources that can be used in all supported platforms 
   - AppIcon
   - Fonts
   - Images
   - Raw
   - Splash
   - Styles 
3. Dependencies 
   SDKs, NugetPackages, Third-Party Libraries, Custom Components, etc.
   Also contains a launchsettings.json file in a Properties Folder to configure profiles, environmentable variables arguments.
**App.xaml**
 - App.xaml.cs
**AppShell.xaml**
 - AppShell.xaml.cs
**MainPage.xaml**
 - MainPage.xaml.cs
**MauiProgram.cs**

---

# What is XAML?

XAML (i.e., Extensible Application Markup Language) is XML-based markup language that is used to define the user interface in .Net Applications. 
There are three XAML files that are included in the project template, which are 
**App.xaml, AppShell.xaml, MainPage.xaml.** 
These files are platform agnostic. Each XAML file is in pair with the C# file, which is a code-behind file associated with the XAML file.
**MainPage.xaml** 
If you open the XAML file you will see xmlns which stands for XML Namespace, declared with some URI pointing to Microsoft.com. 
These URIs actually not pointing to some content or documentation, but actually, these are version identifiers. 
- First, xmlns defines the tags with no prefix in the XAML Document. Example, ContentPage, ScrollView, etc. 
- Second xmlns:x namespace defines the prefix of x. This is used for several elements and attributes which are intrinsic to XAML. Example, x.Class, x.Name etc. 
- Third is x.Class which specifies the fully qualified .NET Class name and points to the C# code-behind file. 
**MauiProgram.cs** 
Provides the entry point for the application. It enables the application to start from a single location and is used to configure fonts, services, and third-party libraries. 
In case you are familiar with .Net Core, you can easily relate to Program.cs class of the application. 
The App class mentioned in the UseMauiApp method is the root object of the application. 
The App class is inherited from the Application class and is used for defining the first starting page of the application. 
In **App.xaml.cs**, 
you will see the MainPage is holding the reference/object of AppShell class. 
In **AppShell.xaml**, 
you will see ShellContent with the title as Home and ContentTemplate with route passed as MainPage, which is actually a ContentPage having an Image, a few labels with a button as shown in the below image. A ContentPage is a page that displays a single view.

---

# **The below examples are taken from The MUAI Dev Express Application**

# Model 

namespace XAMLUITemplates.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Value { get; set; }
    }
}

# Example View Model

using System.Collections.ObjectModel;
using XAMLUITemplates.Models;

namespace XAMLUITemplates.ViewModels
{
    public class DataGridViewModel : BaseViewModel
    {
        public DataGridViewModel()
        {
            Title = "DataGrid";
            Items = new ObservableCollection<Item>();
        }

        public ObservableCollection<Item> Items { get; private set; }

        async public void OnAppearing()
        {
            IEnumerable<Item> items = await DataStore.GetItemsAsync(true);
            Items.Clear();
            foreach (Item item in items)
            {
                Items.Add(item);
            }
        }
    }
}

# Services 

## IDataStore Services
namespace XAMLUITemplates.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(string id);

        Task<T> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }

}

## INavigationService
using XAMLUITemplates.ViewModels;

namespace XAMLUITemplates.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(bool isAbsoluteRoute) where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task GoBackAsync();
    }
}

## MockDataStoreService

using XAMLUITemplates.Models;

namespace XAMLUITemplates.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            DateTime baseDate = DateTime.Today;
            this.items = new List<Item>() {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", StartTime = baseDate.AddHours(1), EndTime = baseDate.AddHours(2), Value=17.098 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.", StartTime = baseDate.AddHours(2), EndTime = baseDate.AddHours(4), Value=9.985 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", StartTime = baseDate.AddHours(3), EndTime = baseDate.AddHours(5), Value=9.597},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", StartTime = baseDate.AddHours(5), EndTime = baseDate.AddHours(6), Value=9.834 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.", StartTime = baseDate.AddHours(9), EndTime = baseDate.AddHours(12), Value=3.287 },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", StartTime = baseDate.AddHours(12), EndTime = baseDate.AddHours(15), Value=81.2 }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            this.items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = this.items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            this.items.Remove(oldItem);
            this.items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = this.items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            this.items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(this.items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(this.items);
        }
    }
}

## NavigationService

using System.Globalization;
using System.Reflection;
using System.Web;
using XAMLUITemplates.ViewModels;
using XAMLUITemplates.Views;

namespace XAMLUITemplates.Services
{
    public class NavigationService : INavigationService
    {

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            await InternalNavigateToAsync(typeof(TViewModel), null, false);
        }

        public async Task NavigateToAsync<TViewModel>(bool isAbsoluteRoute) where TViewModel : BaseViewModel
        {
            await InternalNavigateToAsync(typeof(TViewModel), null, isAbsoluteRoute);
        }

        public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            await InternalNavigateToAsync(typeof(TViewModel), parameter, false);
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        async Task InternalNavigateToAsync(Type viewModelType, object parameter, bool isAbsoluteRoute = false)
        {
            var viewName = viewModelType.FullName.Replace("ViewModels", "Views").Replace("ViewModel", "Page");
            string absolutePrefix = isAbsoluteRoute ? "///" : String.Empty;
            if (parameter != null)
            {
                await Shell.Current.GoToAsync(
                    $"{absolutePrefix}{viewName}?id={HttpUtility.UrlEncode(parameter.ToString())}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{absolutePrefix}{viewName}");
            }
        }
    }
}

## App.xaml

<Application xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:windows="clr-namespace:Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;assembly=Microsoft.Maui.Controls"
             xmlns:local="clr-namespace:XAMLUITemplates"
             x:Class= "XAMLUITemplates.App"
             windows:Application.ImageDirectory="Assets">
    <Application.Resources>
        <ResourceDictionary>
            <Color x:Key="Primary">#512BD4</Color>
            <Color x:Key="NormalText">#55575c</Color>
            <Color x:Key="NormalHeaderText">#55575c</Color>
            <Color x:Key="NormalLightText">#959aa0</Color>
            <Color x:Key="TitleTextColor">White</Color>
            <Color x:Key="NormalBackgroundColor">White</Color>
            <Style TargetType="NavigationPage">
                <Setter Property="BarBackgroundColor" Value="{StaticResource Primary}"/>
                <Setter Property="BarTextColor" Value="White"/>
            </Style>
            <Style x:Key="PrimaryButton" TargetType="Button">
                <Setter Property="BackgroundColor" Value="{StaticResource Primary}"/>
                <Setter Property="TextColor" Value="White"/>
            </Style>
            <Style x:Key="ShellStyle" TargetType="Element">
                <Setter Property="Shell.BackgroundColor" Value="{StaticResource Primary}" />
                <Setter Property="Shell.TitleColor" Value="{StaticResource TitleTextColor}" />
                <Setter Property="Shell.ForegroundColor" Value="{StaticResource TitleTextColor}" />
                <Setter Property="Shell.TabBarBackgroundColor" Value="{StaticResource NormalBackgroundColor}" />
                <Setter Property="Shell.TabBarForegroundColor" Value="{StaticResource Primary}" />
                <Setter Property="Shell.TabBarTitleColor" Value="{StaticResource Primary}" />
                <Setter Property="Shell.TabBarUnselectedColor" Value="{StaticResource NormalText}" />
            </Style>
        </ResourceDictionary>
    </Application.Resources>
</Application>

## App.xaml.cs

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using XAMLUITemplates.Services;
using XAMLUITemplates.ViewModels;
using XAMLUITemplates.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace XAMLUITemplates
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();

            Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));
            MainPage = new MainPage();
            // Use the NavigateToAsync<ViewModelName> method
            // to display the corresponding view.
            // Code lines below show how to navigate to a specific page.
            // Comment out all but one of these lines
            // to open the corresponding page.
            //var navigationService = DependencyService.Get<INavigationService>();
            //navigationService.NavigateToAsync<LoginViewModel>(true);
        }
    }
}

## MAUI Program Class

using DevExpress.Maui;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace XAMLUITemplates
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                    fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("univia-pro-medium.ttf", "Univia-Pro Medium");
                });
            DevExpress.Maui.Charts.Initializer.Init();
            DevExpress.Maui.CollectionView.Initializer.Init();
            DevExpress.Maui.Controls.Initializer.Init();
            DevExpress.Maui.Editors.Initializer.Init();
            DevExpress.Maui.DataGrid.Initializer.Init();
            DevExpress.Maui.Scheduler.Initializer.Init();
            return builder.Build();
        }
    }
}

