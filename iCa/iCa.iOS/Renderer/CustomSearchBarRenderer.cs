using System;
using System.Collections.Generic;
using Common;
using Foundation;
using iCa.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace iCa.iOS.Renderer
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            var searchbar = (UISearchBar)Control;

            if (e.NewElement != null)
            {

                Foundation.NSString _searchField = new Foundation.NSString("searchField");
                var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
                
                searchbar.TintColor = UIColor.FromRGB(102, 198, 212);

                searchbar.BarTintColor = UIColor.Clear;
                searchbar.Layer.CornerRadius = 10;
                searchbar.Layer.BorderColor = UIColor.Clear.CGColor;
                searchbar.SearchBarStyle = UISearchBarStyle.Minimal;
                searchbar.SetShowsCancelButton(false, false);
                searchbar.ShowsCancelButton = false;

                searchbar.TextChanged += delegate
                {
                    searchbar.ShowsCancelButton = false;
                };
                searchbar.OnEditingStarted += delegate
                {
                    searchbar.Layer.BorderWidth = 2;
                    searchbar.Layer.BorderColor = UIColor.FromRGB(102, 198, 212).CGColor;
                };
                searchbar.OnEditingStopped += delegate
                {
                    searchbar.Layer.BorderWidth = 0;
                };

                if (!Settings.IsDarkMode)
                {
                    textFieldInsideSearchBar.BackgroundColor = UIColor.FromRGB(255, 255, 255);
                    searchbar.Layer.BorderColor = UIColor.FromRGB(255, 255, 255).CGColor;
                    //searchbar.BackgroundColor = UIColor.FromRGB(255, 255, 255);
                }
                else
                {
                    textFieldInsideSearchBar.BackgroundColor = UIColor.FromRGB(29, 29, 29);
                    searchbar.Layer.BorderColor = UIColor.FromRGB(29, 29, 29).CGColor;
                    //searchbar.BackgroundColor = UIColor.FromRGB(29, 29, 29);
                }
            }
        }
    }
}
