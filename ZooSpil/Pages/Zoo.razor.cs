using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ZooSpil.Pages
{
    public partial class Zoo
    {
        #region prop/feilds        
        [Parameter]
        public string UserId { get; set; }
        public DataLayer.Entitys.User User { get; set; }  
        public decimal? AntalPenge { get; set; }
        TimeSpan defaultTid = new TimeSpan(365, 0, 0, 1);
        #endregion


        #region Timers
        protected override async Task OnInitializedAsync()
        {
            User = zooService.LoadUser(UserId);
            StartTimer();
        }

        public void StartTimer()
        {
            Task.Delay(1000);
            Timer();
            TimerSave();
        }

        async Task Timer()
        {
            while (defaultTid > new TimeSpan())
            {
                await Task.Delay(1000);
                defaultTid = defaultTid.Subtract(new TimeSpan(0, 0, 0, 1));
                AntalPenge = await zooService.UpdatePenge(User);
                StateHasChanged();
            }
            StateHasChanged();
        }
        async Task TimerSave()
        {
            while (defaultTid > new TimeSpan())
            {
                await Task.Delay(10000);
                defaultTid = defaultTid.Subtract(new TimeSpan(0, 0, 0, 1));
                zooService.Commit();
            }
        }
        #endregion

        #region Kunder

        #endregion
        #region Dyr

        #endregion
    }
}
