using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parakeet.Services;
using Parakeet.Services.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Parakeet.Ui.ViewModel
{
    public class SkillCenterViewModel : ViewModelBase
    {
        private IPositionService _positionService;

        private readonly List<long> PositionsFoundHashes = new List<long>();

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
                _positionsFound = value;
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

        public SkillCenterViewModel(IPositionService positionService)
        {
            _positionService = positionService;

            InitializeView();
        }

        private void InitializeView()
        {
            SearchForPositionCommand = new RelayCommand(() =>
            {
                PositionsFoundHashes.Clear();

                var found = _positionService.Find(SearchField);

                if (PositionsFound.Count > 0)
                {
                    var index = 0;
                    do
                    {
                        if (PositionsFound[index] == SelectedPosition)
                            index++;
                        else
                            PositionsFound.RemoveAt(index);
                    } while (index < PositionsFound.Count);
                }

                foreach(var position in found)
                {
                    if (SelectedPosition == null || position.Id != SelectedPosition.Id)
                        PositionsFound.Add(position);
                }

                var hashes = PositionsFound.Select(x => (long)(x.Title + x.Description).GetHashCode());
                PositionsFoundHashes.AddRange(hashes);
            }, () => { return true; });

            SavePositionCommand = new RelayCommand(
                () => {
                    _positionService.Save(SelectedPosition);

                    PositionsFoundHashes.Clear();
                    var hashes = PositionsFound.Select(x => (long)(x.Title + x.Description).GetHashCode());
                    PositionsFoundHashes.AddRange(hashes);

                    SearchField = SelectedPosition.Title;

                    SavePositionCommand.RaiseCanExecuteChanged();
                }
                ,() =>
                {
                    var selectedPositionHash = SelectedPosition == null 
                        ? 0 
                        : (SelectedPosition.Title + SelectedPosition.Description).GetHashCode();

                    return SelectedPosition != null
                        && SelectedPosition.Title != null && SelectedPosition.Title.Length > 1
                        && SelectedPosition.Description != null && SelectedPosition.Description.Length > 1
                        && !PositionsFoundHashes.Contains(selectedPositionHash);
                }
            );

            ClearPositionCommand = new RelayCommand(() =>
            {
                SelectedPosition = new Position();
                SearchField = "";
                PositionsFound.Clear();
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
            PositionsFound = new ObservableCollection<Position>();
        }
    }
}
