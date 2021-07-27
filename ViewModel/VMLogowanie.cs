﻿using Bank2.Commands;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMLogowanie : ViewModelBase//: Page//, INotifyPropertyChanged//,  IViewModel
    {
        // private NavigationService _navigationService;

        //  private IEventAggregator _ea;

        private string _imie;
        public string Imie { get
            {
                return _imie;
            }
            set
            {
                _imie = value;
            //    OnPropertyChanged(nameof(Imie));
            }
        }

        public string Nazwisko { get; set; }
        public string Password { get; set; }


        //private Baza model = new Baza();
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Zarejestruj { get; set; }
        public ICommand Zaloguj { get; set; }

        //bool zalogowany = false;

        //private string imie;
        //private string nazwisko;
        //public string Password { private get; set; }



        //public string Imie
        //{

        //    get
        //    {
        //        return imie;
        //    }
        //    set
        //    {
        //        imie = value;
        //        OnPropertyChanged(nameof(Imie));
        //    }

        //}

        private void OnPropertyChanged(string nazwa)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }



        /*   public ICommand Zarejestruj
           {

           }*/


       
        public VMLogowanie(INavigator navigator)//IEventAggregator ea)//NavigationService navigationService)
        {
               Zarejestruj = new UpdateCurrentViewModelCommand<VMDodajPracownika>(navigator, ()=>new VMDodajPracownika(navigator));
            //  Zaloguj = new UpdateCurrentViewModelCommand<VMPracownikLayout>(navigator, () => new VMPracownikLayout(navigator));
            Zaloguj = new ZalogujPracownikaCommand<VMPracownikNavigationBar>(navigator, () => new VMPracownikNavigationBar(navigator));

            //    Zaloguj = new RelayCommand(new Action<object>(ShowMessage));
           
            //   _navigationService = navigationService;
            //      _ea = ea;
            //       Zarejestruj = new RelayCommand(
            //            ExecuteApplyChangesCommand);



        }

     /*   private void ExecuteApplyChangesCommand()
        {
           
            PracownikPage page = new PracownikPage();
      //      this.NavigationService.Navigate(page);
            
            //  NavigationService.



            //   NavigationService.GetNavigationService(this);
            //    ns.Navigate(page);

            //  Frame.NavigationService.Navigate(page);
            //  throw new NotImplementedException();


        }*/


        public void ShowMessage(object obj)
        {
            //   MessageBox.Show(obj.ToString());
        }
       
    }


}
