using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parakeet.Services;
using Parakeet.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Parakeet.Ui.ViewModel
{
    public class PositionCenterViewModel : ViewModelBase
    {
        private IPositionService _positionService;

        private bool _searching = false; 

        public RelayCommand SearchForPositionCommand { get; set; }
        public RelayCommand ExpandComboBoxCommand { get; set; }
        public RelayCommand SavePositionCommand { get; set; }
        public RelayCommand ClearPositionCommand { get; set; }
        public RelayCommand UpdateCanSaveCommand { get; private set; }

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
            }
        }

        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                Set("SelectedPosition", ref _selectedPosition, value);
                SavePositionCommand.RaiseCanExecuteChanged();
            }
        }

        private string _searchField;
        public string SearchField
        {
            get
            {
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
            SearchForPositionCommand = new RelayCommand(() =>
            {
                if (SearchField.Length > 1)
                {
                    var found = _positionService.Find(SearchField);
                    PositionsFound = new ObservableCollection<Position>(found);
                }
            }, () => { return true; });

            SavePositionCommand = new RelayCommand(
                () => {
                    _positionService.Save(SelectedPosition);
                    
                    if (PositionsFound != null)
                        PositionsFound.Clear();
                }
                ,() =>
                {
                    return SelectedPosition != null
                        && SelectedPosition.Title != null && SelectedPosition.Title.Length > 1
                        && SelectedPosition.Description != null && SelectedPosition.Description.Length > 1;
                }
            );

            ClearPositionCommand = new RelayCommand(() =>
            {
                SelectedPosition = new Position();
                SearchField = "";
                if (PositionsFound != null)
                    PositionsFound.Clear();
                SearchForPositionCommand.RaiseCanExecuteChanged();
            });

            UpdateCanSaveCommand = new RelayCommand(() =>
            {
                SavePositionCommand.RaiseCanExecuteChanged();
            });

            ExpandComboBoxCommand = new RelayCommand(() =>
            {
                ShowMatchingPositions = true;
            });

            SelectedPosition = new Position();
        }
    }
}
