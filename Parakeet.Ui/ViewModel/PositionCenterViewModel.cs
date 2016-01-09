using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parakeet.Services;
using Parakeet.Services.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Parakeet.Ui.ViewModel
{
    public class PositionCenterViewModel : ViewModelBase
    {
        private IPositionService _positionService;

        public RelayCommand SearchForPositionCommand { get; set; }
        public RelayCommand SavePositionCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

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

        private Position _position;
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
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
            _position = new Position
            {
                Title = "Test",
                Description = "Test Description"
            };

            SearchForPositionCommand = new RelayCommand(() =>
            {
                var found = _positionService.Find(SearchField);
                PositionsFound = new ObservableCollection<Position>(found);
            }, () => { return SearchField.Length > 1; });
        }
    }
}
