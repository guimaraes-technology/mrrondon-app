﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MrRondon.Helpers;
using MrRondon.Services;
using Xamarin.Forms;

namespace MrRondon.Pages.Company
{
    public class ListCompaniesPageModel : BasePageModel
    {
        public ListCompaniesPageModel(int segmentId)
        {
            SegmentId = segmentId;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItems());
        }
        
        private bool _notHhasItems;
        public bool NotHasItems
        {
            get => _notHhasItems;
            set => SetProperty(ref _notHhasItems, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        private int _city;
        public int City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private int _segmentId;
        public int SegmentId
        {
            get => _segmentId;
            set => SetProperty(ref _segmentId, value);
        }

        private string _searchBar;
        public string Search
        {
            get => _searchBar;
            set => SetProperty(ref _searchBar, value);
        }

        public ICommand LoadItemsCommand { get; set; }
        public ICommand ItemSelectedCommand { get; set; }

        private ObservableRangeCollection<Entities.Company> _items;
        public ObservableRangeCollection<Entities.Company> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private async Task ExecuteLoadItems()
        {
            try
            {
                if (IsLoading) return;

                NotHasItems = false;
                IsLoading = true;
                Items.Clear();
                var service = new CompanyService();
                var items = await service.GetAsync(SegmentId, City, Search);
                NotHasItems = IsLoading && items != null && !items.Any();
                if (NotHasItems) ErrorMessage = "Nenhuma empresa encontrada";
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await NavigationService.PushAsync(new ErrorPage(new ErrorPageModel(ex.Message, Title) { IsLoading = false }));
            }
            finally
            {
                IsLoading = false;
                IsPresented = false;
            }
        }
    }
}