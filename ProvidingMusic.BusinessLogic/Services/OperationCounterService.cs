using ProvidingMusic.BusinessLogic.Services.Intefaces;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class OperationCounterService: IOperationCounterService
    {
        private int bandOperationCounter = 0;
        private int groupMemberOperationCounter = 0;
        private int albumOperationCounter = 0;
        private int songOperationCounter = 0;

        public event EventHandler? Counter;
        public void IncreaseAlbumOperationCounter()
        {
            albumOperationCounter++;
            Counter?.Invoke(this, EventArgs.Empty);

        }
        public void IncreaseBandOperationCounter()
        {
            bandOperationCounter++;
            Counter?.Invoke(this, EventArgs.Empty);
        }
        public void IncreaseGroupMemberOperationCounter()
        {
            groupMemberOperationCounter++;
            Counter?.Invoke(this, EventArgs.Empty);
        }

        public void IncreaseSongOperationCounter()
        {
            songOperationCounter++;
            Counter?.Invoke(this, EventArgs.Empty);
        }
        public async Task<List<int>> ShowAllCounters()
        {
            return new List<int> {
                bandOperationCounter,
                groupMemberOperationCounter,
                albumOperationCounter,
                songOperationCounter
            };
        }
    }
}
