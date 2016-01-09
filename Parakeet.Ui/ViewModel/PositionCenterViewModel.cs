using Parakeet.Services.Models;

namespace Parakeet.Ui.ViewModel
{
    public class PositionCenterViewModel
    {
        private Position _position;
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public PositionCenterViewModel()
        {
            _position = new Position
            {
                Title = "Test",
                Description = "Test Description"
            };
        }
    }
}
