using DataLayer.Entitys;
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
        public Dyr Dyrtilkøb { get; set; }
        public decimal? AntalPenge { get; set; }
        TimeSpan defaultTid = new TimeSpan(365, 0, 0, 1);
        public int? KrokodilleAntal { get; set; }
        
        public List<UserDyr> Dyrliste { get; set; }
        public List<UserKunder> KundeListe { get; set; }

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
            Loadallinfo();

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
        
        public void KøbEtDyr(int dyrId)
        {
            Dyr fundetdyr = zooService.getdyrbyid(dyrId);
            if (zooService.TjekOmKanKoobe(User, fundetdyr))
            {
                zooService.KobDyr(User, fundetdyr);
                KundeUpdate(dyrId);
                Loadallinfo();
            }
            
        }
        public void Loadallinfo()
        {
            Dyrliste = zooService.GetAllDyrFromUser(User);
            KundeListe = zooService.GetAllKunderFromUser(User);
        }
        #endregion

        public void Cheat()
        {
            zooService.ADMINMODE(User);
        }
        public void KundeUpdate(int dyrId)
        {
            switch (dyrId)
            {
                case 1:
                    zooService.AddKunder(User, 1);
                    break;
                case 2:
                    zooService.AddKunder(User, 1);
                    break;
                case 3:
                    zooService.AddKunder(User, 3);
                    break;
                case 4:
                    zooService.AddKunder(User, 1);
                    break;
                case 5:
                    zooService.AddKunder(User, 2);
                    break;
                case 6:
                    zooService.AddKunder(User, 3);
                    break;

                default:
                    break;
            }
        }
    }
}
