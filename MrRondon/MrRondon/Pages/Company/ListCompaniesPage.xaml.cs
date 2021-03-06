﻿using Xamarin.Forms;

namespace MrRondon.Pages.Company
{
	public partial class ListCompaniesPage : ContentPage
	{
	    private readonly ListCompaniesPageModel _pageModel;

        public ListCompaniesPage (ListCompaniesPageModel pageModel)
		{
			InitializeComponent();
		    BindingContext = _pageModel = pageModel;
		}

	    protected override void OnAppearing()
	    {
            _pageModel.LoadCitiesCommand.Execute(_pageModel.CategoryId);

	        base.OnAppearing();
        }
	}
}