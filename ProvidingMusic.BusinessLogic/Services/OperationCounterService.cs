using ProvidingMusic.BusinessLogic.Services.Intefaces;
using static ProvidingMusic.BusinessLogic.Services.Intefaces.IOperationCounterService;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class OperationCounterService: IOperationCounterService
    {
        private int bandOperationCounter = 0;
        private int groupMemberOperationCounter = 0;
        private int albumOperationCounter = 0;
        private int songOperationCounter = 0;

        public event EventHandler? Counter;
        //event Counter? CounterChangedHandler
        //{
        //    add
        //    {
        //        CounterChanged += value;
        //    }
        //    remove
        //    {
        //        CounterChanged -= value;
        //    }
        //}

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
        //public void Invoke()
        //{
        //    Counter.Invoke();
        //}

        //public event Counter? CounterChanged;

        //event Counter? CounterChangedHandler
        //{
        //    add
        //    {
        //        CounterChanged+= value;
        //    }
        //    remove
        //    {
        //        CounterChanged -= value;
        //    }
        //}

        //public void IncreaseSongOperationCounter()
        //{
        //    songOperationCounter++;
        //    Invoke();
        //}
        ////public void IncreaseBandOperationCounter()
        ////{
        ////    bandOperationCounter++;
        ////    //Invoke();
        ////}
        //public void OnBandCreated()
        //{
        //    bandOperationCounter++;
        //    Invoke();   
        //}

        //public void IncreaseGroupMemberOperationCounter()
        //{
        //    groupMemberOperationCounter++;
        //}
        //public void IncreaseAlbumOperationCounter()
        //{
        //    albumOperationCounter++;
        //}



        //public void IncreaseBandOperationCounter()
        //{

        //}
    }
}
