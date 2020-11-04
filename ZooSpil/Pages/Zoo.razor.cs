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
        public int? LøveAntal { get; set; }
        public int? ElefantAntal { get; set; }
        public int? PingvinAntal { get; set; }
        public int? DrageAntal { get; set; }
        public int? TigerAntal { get; set; }

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
        
        public void KøbEtDyr(int dyrId)
        {
            Dyr fundetdyr = zooService.getdyrbyid(dyrId);
            if (zooService.TjekOmKanKoobe(User, fundetdyr))
            {
                zooService.KobDyr(User, fundetdyr);
                Loadallinfo(User);
            }
            
        }
        public void Loadallinfo(User user)
        {
            var krokodiller = user.userDyrs.Where(x => x.DyrId == 1).FirstOrDefault();
            if (krokodiller == null)
            {
                KrokodilleAntal = 0;
            }
            else
            {
                KrokodilleAntal = krokodiller.Antal;
            }
            var løveAntal = user.userDyrs.Where(x => x.DyrId == 2).FirstOrDefault();
            if (løveAntal == null)
            {
                LøveAntal = 0;
            }
            else
            {
                LøveAntal = løveAntal.Antal;
            }
            var elefantAntal = user.userDyrs.Where(x => x.DyrId == 3).FirstOrDefault();
            if (elefantAntal == null)
            {
                ElefantAntal = 0;
            }
            else
            {
                ElefantAntal = elefantAntal.Antal;
            }
            var pingvinAntal = user.userDyrs.Where(x => x.DyrId == 4).FirstOrDefault();
            if (pingvinAntal == null)
            {
                PingvinAntal = 0;
            }
            else
            {
                PingvinAntal = pingvinAntal.Antal;
            }
            var drageAntal = user.userDyrs.Where(x => x.DyrId == 5).FirstOrDefault();
            if (drageAntal == null)
            {
                DrageAntal = 0;
            }
            else
            {
                DrageAntal = drageAntal.Antal;
            }
            var tigerAntal = user.userDyrs.Where(x => x.DyrId == 6).FirstOrDefault();
            if (tigerAntal == null)
            {
                TigerAntal = 0;
            }
            else
            {
                TigerAntal = tigerAntal.Antal;
            }
        }
        #endregion
    }
}
