using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parakeet.Services;
using Parakeet.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Parakeet.Ui.ViewModel
{
    public class PositionCenterViewModel : ViewModelBase
    {
        private IPositionService _positionService;

        private bool _searching = false; 

        public RelayCommand SearchForPositionCommand { get; set; }
        public RelayCommand OnEnterSearch { get; set; }
        public RelayCommand OnExitSearch { get; set; }
        public RelayCommand SavePosition { get; set; }
        public RelayCommand ClearPosition { get; set; }

        private bool _showMatchingPositions;
        public bool ShowMatchingPositions
        {
            get
            {
                return _showMatchingPositions;
            }
            set
            {
                Set(ref _showMatchingPositions, value);
            }
        }

        private ObservableCollection<Position> _positionsFound;
        public ObservableCollection<Position> PositionsFound
        {
            get { return _positionsFound; }
            set
            {
                Set(ref _positionsFound, value);
                ShowMatchingPositions = true;
            }
        }

        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get { return _selectedPosition; }
            set { Set("SelectedPosition", ref _selectedPosition, value); }
        }

        private string _searchField;
        public string SearchField
        {
            get
            {
                if (SelectedPosition.Id == null && _searching == false)
                    return "Add new role...";

                return _searchField;
            }
            set
            {
                Set(ref _searchField, value);
            }
        }

        public PositionCenterViewModel(IPositionService positionService)
        {
            _positionService = positionService;

            InitializeView();
        }

        private void InitializeView()
        {
            SelectedPosition = new Position();

            SearchForPositionCommand = new RelayCommand(() =>
            {
                var found = _positionService.Find(SearchField);
                PositionsFound = new ObservableCollection<Position>(found);
            }, () => { return SearchField.Length > 1; });

            OnEnterSearch = new RelayCommand(() =>
            {
                _searching = true;
                SearchField = "";
                SelectedPosition = new Position();
            });

            OnExitSearch = new RelayCommand(() =>
            {
                if (SelectedPosition == null)
                    _searching = false;

                _searching = false;
            });

            SavePosition = new RelayCommand(() =>
            {
                _positionService.Save(SelectedPosition);
                Console.WriteLine("");
            });

            ClearPosition = new RelayCommand(() =>
            {
                SelectedPosition = new Position();
            });
        }
    }
}
