using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IOperationCounterService
    {
        Task<List<int>> ShowAllCounters();
        public event EventHandler? Counter;
        void IncreaseSongOperationCounter();
        void IncreaseBandOperationCounter();
        void IncreaseGroupMemberOperationCounter();
        void IncreaseAlbumOperationCounter();

        //void Invoke();

        //void OnBandCreated();

        //delegate void Counter();
        //event Counter? CounterChanged;
    }
}
