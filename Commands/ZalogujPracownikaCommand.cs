﻿using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bank2.Commands
{

    public class ZalogujPracownikaCommand<TViewModel> : ICommand
           where TViewModel : ViewModelBase
    {
        public event EventHandler CanExecuteChanged;
        private readonly INavigator _navigator;
        private readonly Func<TViewModel> _createViewModel;
      //  private bool _zalogowany = false;

        public ZalogujPracownikaCommand(INavigator navigator, Func<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
          

        }




        public void Execute(object parameter)
        {
            if (_navigator.CurrentViewModel is VMLogowanie)
            {
                Pracownicy pracownik = null;
                pracownik = Zaloguj(_navigator.CurrentViewModel as VMLogowanie);
               if (pracownik!=null)
                {
                    _navigator.zalogowanyPracownik = pracownik;
                    _navigator.CurrentViewModel = _createViewModel();
                }
                else
                {
                  /*  (_navigator.CurrentViewModel as VMLogowanie).Imie = "";
                    (_navigator.CurrentViewModel as VMLogowanie).Nazwisko = "";
                    (_navigator.CurrentViewModel as VMLogowanie).Password = "";
                    _navigator.CurrentViewModel = new VMLogowanie(_navigator);*/
                }

            }

           
         


        }


        private Pracownicy Zaloguj(VMLogowanie vm)
        {
            Pracownicy zalogowany = null;
          
            if (!(vm.Imie==null || vm.Nazwisko == null || vm.Password == null))
            {

                try
                {
                    Baza db = new Baza();
                   

                        foreach (var item in db.Pracownicy)
                    {
                        if (
                            vm.Imie == item.Imię_pracownika.TrimEnd()
                          && vm.Nazwisko == item.Nazwisko_pracownika.TrimEnd()
                            && vm.Password == item.Password.TrimEnd())
                        {
                            zalogowany = item;
                            break;
                        }


                    }
                    if (zalogowany!=null)
                    {
                        MessageBox.Show("Dobre dane logowania");
                        return zalogowany;
                    }
                    else
                    {
                        MessageBox.Show("Złe dane logowania");
                        return null;
                    }



                }
                catch
                {
                    MessageBox.Show("Błąd logowania do bazy danych.");
                    return null;
                }



            }
            else
            {
                MessageBox.Show("Uzupełnij wszystkie pola");
                return null;
            }
            
          //  return zalogowany;
        }


    }

}
