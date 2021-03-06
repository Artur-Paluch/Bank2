using Bank2.Commands;
using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using Bank2.View.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMPracownikKlienci : ViewModelBase, INotifyPropertyChanged
    {
        private UserControl _TablicaDanych;
        public UserControl TablicaDanych
        {
            get { return _TablicaDanych; }
            set
            {
                _TablicaDanych = value;
                OnPropertyChanged("TablicaDanych");
            }
        }
        public UserControl TablicaDanych2
        {
            get { return _TablicaDanych2; }
            set
            {
                _TablicaDanych2 = value;
                OnPropertyChanged("TablicaDanych2");
            }
        }
        public ICommand klienciWyswietl { get; set; }
        public ICommand klienciDodaj { get; set; }
        public ICommand klienciEdytuj { get; set; }
        public ICommand klienciUsun { get; set; }
        public ICommand klienciUsunieci { get; set; }
        public ICommand KredytWyswietl { get; set; }
        public ICommand KredytDodaj { get; set; }
        public ICommand KredytEdytuj { get; set; }
        public ICommand KredytUsun { get; set; }
        public ICommand KredytUsuniete { get; set; }
        public ICommand LokataWyswietl { get; set; }
        public ICommand LokataDodaj { get; set; }
        public ICommand LokataEdytuj { get; set; }
        public ICommand LokataiUsun { get; set; }
        public ICommand LokataUsuniete { get; set; }
        public ICommand PrzelewWyswietl { get; set; }
        public ICommand PrzelewDodaj { get; set; }
        public ICommand PrzelewWplata { get; set; }
        public ICommand KlientPodsumowanie { get; set; }
        public ICommand wyloguj { get; set; }
        public ICommand wyjdz { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private INavigator _navigator;

        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
        public ObservableCollection<KredytyDataModel> ListaKredytow { get; set; } = new ObservableCollection<KredytyDataModel>();
        public ObservableCollection<LokatyDataModel> ListaLokat { get; set; } = new ObservableCollection<LokatyDataModel>();
        public ObservableCollection<PrzelewyDataModel> ListaPrzelewow { get; set; } = new ObservableCollection<PrzelewyDataModel>();
        public ObservableCollection<RodzajeLokatDataModel> ListaRodzajowLokat { get; set; } = new ObservableCollection<RodzajeLokatDataModel>();
        public ObservableCollection<RodzajeKredytowDataModel> ListaRodzajowKredytow { get; set; } = new ObservableCollection<RodzajeKredytowDataModel>();

        private string _ButtonKlienciWyswietlContent = "Wyświetl";
        public string ButtonKlienciWyswietlContent
        {
            get { return _ButtonKlienciWyswietlContent; }
            set
            {
                _ButtonKlienciWyswietlContent = value;
                OnPropertyChanged("ButtonKlienciWyswietlContent");
            }
        }
        private string _ButtonKredytyWyswietlContent = "Wyświetl";
        public string ButtonKredytyWyswietlContent
        {
            get { return _ButtonKredytyWyswietlContent; }
            set
            {
                _ButtonKredytyWyswietlContent = value;
                OnPropertyChanged("ButtonKredytyWyswietlContent");
            }
        }
        private string _ButtonLokatyWyswietlContent = "Wyświetl";
        public string ButtonLokatyWyswietlContent
        {
            get { return _ButtonLokatyWyswietlContent; }
            set
            {
                _ButtonLokatyWyswietlContent = value;
                OnPropertyChanged("ButtonLokatyWyswietlContent");
            }
        }
        private string _ButtonPrzelewyWyswietlContent = "Wyświetl";
        private UserControl _TablicaDanych2;

        public string ButtonPrzelewyWyswietlContent
        {
            get { return _ButtonPrzelewyWyswietlContent; }
            set
            {
                _ButtonPrzelewyWyswietlContent = value;
                OnPropertyChanged("ButtonPrzelewyWyswietlContent");
            }
        }




        public ICommand Klient { get; set; }

        public VMPracownikKlienci(INavigator navigator)
        {
            _navigator = navigator;


            wyloguj = new UpdateCurrentViewModelCommand<VMLogowanie>(_navigator, () => new VMLogowanie(_navigator));
            wyjdz = new RelayCommand(Wyjdz);
            klienciWyswietl = new RelayCommand(WyswietlKlientow);
            klienciDodaj = new RelayCommand(WyswietlOknoDodajKlienta);
            klienciEdytuj = new RelayCommand(EdytujKlienta);
            klienciUsun = new RelayCommand(UsunKlienta);
            klienciUsunieci = new RelayCommand(PokarzUsunietychKlientow);
            KlientPodsumowanie = new RelayCommand(WyswietlKlientPodsumowanie);

            KredytWyswietl = new RelayCommand(WyswietlKredyty);
            KredytDodaj = new RelayCommand(WyswietlOknoDodajKredyt);
            KredytEdytuj = new RelayCommand(EdytujKredyt);
            KredytUsun = new RelayCommand(UsunKredyt);
            KredytUsuniete = new RelayCommand(PokarzUsunieteKredyty);

            LokataWyswietl = new RelayCommand(WyswietlLokaty);
            LokataDodaj = new RelayCommand(WyswietlOknoDodajLokate);
            LokataEdytuj = new RelayCommand(EdytujLokate);
            LokataiUsun = new RelayCommand(UsunLokate);
            LokataUsuniete = new RelayCommand(PokarzUsunieteLokaty);

            PrzelewWyswietl = new RelayCommand(WyswietlPrzelewy);
            PrzelewDodaj = new RelayCommand(WyswietlOknoZrobPrzelew);
            PrzelewWplata = new RelayCommand(WyswietlOknoZrobWplate);




        }
        private void Wyczysc_Listy_I_UserControlle_Z_Tabelami()
        {
            ListaKlientow.Clear();
            ListaKredytow.Clear();
            ListaLokat.Clear();
            ListaPrzelewow.Clear();
            ListaRodzajowKredytow.Clear();
            ListaRodzajowLokat.Clear();
            TablicaDanych = null;
            TablicaDanych2 = null;
        }
        private void WyswietlKlientPodsumowanie()
        {
            KlienciDataModel temp1 = new KlienciDataModel();
            int licznik = 0;


            //sprawdza zaznaczenie
            foreach (var item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
                TablicaDanych = new KlienciTabela(_navigator);
                TablicaDanych2 = new KlientPodsumowanieNaglowek(_navigator, temp1);


                ListaKlientow.Clear();
                ListaKlientow.Add(temp1);
                ListaKredytow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneKredyty();


            }

        }

        private void PokarzUsunieteLokaty()
        {
            Wyczysc_Listy_I_UserControlle_Z_Tabelami();
            if (ButtonKlienciWyswietlContent == "Schowaj")
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
            }
            if (ButtonKredytyWyswietlContent == "Schowaj")
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
            }
            if (ButtonLokatyWyswietlContent == "Schowaj")
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
            }
            if (ButtonPrzelewyWyswietlContent == "Schowaj")
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
            }

            ListaLokat = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzNieAktywneLokaty();
            TablicaDanych = null;
            TablicaDanych = new LokatyTabela(_navigator);
            TablicaDanych.DataContext = this;
        }

        private void PokarzUsunieteKredyty()
        {
            Wyczysc_Listy_I_UserControlle_Z_Tabelami();
            if (ButtonKlienciWyswietlContent == "Schowaj")
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
            }
            if (ButtonKredytyWyswietlContent == "Schowaj")
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
            }
            if (ButtonLokatyWyswietlContent == "Schowaj")
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
            }
            if (ButtonPrzelewyWyswietlContent == "Schowaj")
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
            }

            ListaKredytow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzNieAktywneKredyty();
            TablicaDanych = null;
            TablicaDanych = new KredytyTabela(_navigator);
            TablicaDanych.DataContext = this;
        }

        private void PokarzUsunietychKlientow()
        {
            Wyczysc_Listy_I_UserControlle_Z_Tabelami();
            if (ButtonKlienciWyswietlContent == "Schowaj")
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
            }
            if (ButtonKredytyWyswietlContent == "Schowaj")
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
            }
            if (ButtonLokatyWyswietlContent == "Schowaj")
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
            }
            if (ButtonPrzelewyWyswietlContent == "Schowaj")
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
            }

            ListaKlientow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzNieAktywniKlienci();
            TablicaDanych = null;
            TablicaDanych = new KlienciTabela(_navigator);
            TablicaDanych.DataContext = this;
        }

        private void UsunLokate()
        {
            LokatyDataModel temp1 = new LokatyDataModel();
            ObservableCollection<LokatyDataModel> znalezione = new ObservableCollection<LokatyDataModel>();
            //sprawdza zaznaczenie
            foreach (var item in ListaLokat)
            {
                if (item.IsSelected == true)
                {

                    znalezione.Add(item);

                }

            }
            if (znalezione.Count == 0)
            {
                MessageBox.Show("Musisz zaznaczyć lokatę.\n");

            }
            else
            {
                string komunikat = "Czy na pewno chcesz usunąć te lokaty?\n";

                var result = MessageBox.Show(komunikat, "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Baza db = new Baza(_navigator.rodzajBazy.ToString());
                    foreach (var item in db.Lokaty)
                    {

                        foreach (var item2 in db.Lokaty)
                        {
                            if (item.Id_Lokaty == item2.Klient)
                            {
                                item2.aktywny = false;
                            }
                        }



                    }
                    db.SaveChanges();
                    ListaLokat = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneLokaty();
                    TablicaDanych = null;
                    TablicaDanych = new LokatyTabela(_navigator);
                    TablicaDanych.DataContext = this;
                }

            }
        }

        private void UsunKredyt()
        {
            KredytyDataModel temp1 = new KredytyDataModel();
            ObservableCollection<KredytyDataModel> znalezione = new ObservableCollection<KredytyDataModel>();
            //sprawdza zaznaczenie
            foreach (var item in ListaKredytow)
            {
                if (item.IsSelected == true)
                {

                    znalezione.Add(item);

                }

            }
            if (znalezione.Count == 0)
            {
                MessageBox.Show("Musisz zaznaczyć kredyt.\n");

            }
            else
            {
                string komunikat = "Czy na pewno chcesz usunąć te kredyty?\n";

                var result = MessageBox.Show(komunikat, "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Baza db = new Baza(_navigator.rodzajBazy.ToString());
                    foreach (var item in db.Kredyty)
                    {

                        foreach (var item2 in db.Kredyty)
                        {
                            if (item.Id_Kredytu == item2.Klient)
                            {
                                item2.aktywny = false;
                            }
                        }



                    }
                    db.SaveChanges();
                    ListaKredytow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneKredyty();
                    TablicaDanych = null;
                    TablicaDanych = new KredytyTabela(_navigator);
                    TablicaDanych.DataContext = this;
                }

            }
        }

        private void UsunKlienta()
        {
            KlienciDataModel temp1 = new KlienciDataModel();
            ObservableCollection<KlienciDataModel> znalezione = new ObservableCollection<KlienciDataModel>();
            //sprawdza zaznaczenie
            foreach (var item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {

                    znalezione.Add(item);

                }

            }
            if (znalezione.Count == 0)
            {
                MessageBox.Show("Musisz zaznaczyć klienta.\n");

            }
            else
            {
                string komunikat = "Czy na pewno chcesz usunąć tych klientów, ich lokaty i kredyty?\n";
                foreach (var item in znalezione)
                {
                    komunikat = komunikat + item.Imię.ToString() + " " + item.Nazwisko.ToString() + "\n";
                }
                var result = MessageBox.Show(komunikat, "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Baza db = new Baza(_navigator.rodzajBazy.ToString());
                    foreach (var item in db.Klienci)
                    {
                        foreach (var doUsuniecia in znalezione)
                        {
                            if (item.Id_klienta == doUsuniecia.Id_klienta)
                            {
                                item.aktywny = false;
                            }
                        }
                        foreach (var item2 in db.Kredyty)
                        {
                            if (item.Id_klienta == item2.Klient)
                            {
                                item2.aktywny = false;
                            }
                        }
                        foreach (var item3 in db.Lokaty)
                        {
                            if (item.Id_klienta == item3.Klient)
                            {
                                item3.aktywny = false;
                            }
                        }


                    }
                    db.SaveChanges();
                    ListaKlientow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywniKlienci();
                    TablicaDanych = null;
                    TablicaDanych = new KlienciTabela(_navigator);
                    TablicaDanych.DataContext = this;
                }

            }

        }

        private void EdytujLokate()
        {

            LokatyDataModel temp1 = new LokatyDataModel();
            int licznik = 0;
            string bladKlienta;

            //sprawdza zaznaczenie
            foreach (var item in ListaLokat)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {
                EdytujLokateWindow okno = new EdytujLokateWindow(_navigator, temp1);
                okno.Closing += Okno_Closing;
                okno.Show();

            }
        }

        private void EdytujKredyt()
        {
            KredytyDataModel temp1 = new KredytyDataModel();
            int licznik = 0;
            string bladKlienta;

            //sprawdza zaznaczenie
            foreach (var item in ListaKredytow)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {
                EdytujKredytWindow okno = new EdytujKredytWindow(_navigator, temp1);
                okno.Closing += Okno_Closing;
                okno.Show();

            }
        }

        private void EdytujKlienta()
        {


            KlienciDataModel temp1 = new KlienciDataModel();
            int licznik = 0;
            string bladKlienta;

            //sprawdza zaznaczenie
            foreach (var item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {

                EdytujKlientaWindow okno = new EdytujKlientaWindow(_navigator, temp1);
                okno.Closing += Okno_Closing;
                okno.Show();
            }
        }

        private void Okno_Closing(object sender, CancelEventArgs e)
        {   /// Aktualizowanie widoku po zmianach
            switch (sender.GetType().Name)
            {
                case "EdytujKlientaWindow":
                    {
                        ListaKlientow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywniKlienci();
                        TablicaDanych = null;
                        TablicaDanych = new KlienciTabela(_navigator);
                        TablicaDanych.DataContext = this;
                        break;
                    }
                case "EdytujKredytWindow":
                    {
                        ListaKredytow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneKredyty();
                        TablicaDanych = null;
                        TablicaDanych = new KredytyTabela(_navigator);
                        TablicaDanych.DataContext = this;
                        break;
                    }
                case "EdytujLokateWindow":
                    {
                        ListaLokat = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneLokaty();
                        TablicaDanych = null;
                        TablicaDanych = new LokatyTabela(_navigator);
                        TablicaDanych.DataContext = this;
                        break;

                    }
            }



        }

        private void WyswietlOknoZrobPrzelew()
        {
            ZrobPrzelewWindow okno = new ZrobPrzelewWindow(_navigator);
            okno.Show();
        }

        private void WyswietlOknoZrobWplate()
        {
            ZrobWplateWindow okno = new ZrobWplateWindow(_navigator);
            okno.Show();
        }

        private void WyswietlOknoDodajLokate()
        {
            DodajLokateWindow okno = new DodajLokateWindow(_navigator);
            okno.Show();
        }

        private void WyswietlOknoDodajKlienta()
        {
            DodajKlientaWindow okno = new DodajKlientaWindow(_navigator);
            okno.Show();
        }
        private void WyswietlOknoDodajKredyt()
        {
            DodajKredytWindow okno = new DodajKredytWindow(_navigator);
            okno.Show();
        }
        private void WyswietlKlientow()
        {
            Wyczysc_Listy_I_UserControlle_Z_Tabelami();

            if (ButtonKredytyWyswietlContent == "Schowaj")
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
            }
            if (ButtonLokatyWyswietlContent == "Schowaj")
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
            }
            if (ButtonPrzelewyWyswietlContent == "Schowaj")
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
            }




            TablicaDanych = new KlienciTabela(_navigator);
            TablicaDanych.DataContext = this;

            if (ButtonKlienciWyswietlContent == "Wyświetl")
            {
                ButtonKlienciWyswietlContent = "Schowaj";

                ListaKlientow.Clear();
                ListaKlientow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywniKlienci();
            }

            else
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
                ListaKlientow.Clear();
                TablicaDanych = null;
            }

        }
        private void WyswietlPrzelewy()
        {

            Wyczysc_Listy_I_UserControlle_Z_Tabelami();
            if (ButtonKlienciWyswietlContent == "Schowaj")
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
            }
            if (ButtonKredytyWyswietlContent == "Schowaj")
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
            }
            if (ButtonLokatyWyswietlContent == "Schowaj")
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
            }



            TablicaDanych = new PrzelewyTabela(_navigator);
            TablicaDanych.DataContext = this;

            if (ButtonPrzelewyWyswietlContent == "Wyświetl")
            {
                ButtonPrzelewyWyswietlContent = "Schowaj";
                ListaPrzelewow.Clear();
                ListaPrzelewow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzPrzelewy();



            }

            else
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
                ListaPrzelewow.Clear();
                TablicaDanych = null;
            }
        }

        private void WyswietlLokaty()
        {

            Wyczysc_Listy_I_UserControlle_Z_Tabelami();
            if (ButtonKlienciWyswietlContent == "Schowaj")
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
            }
            if (ButtonKredytyWyswietlContent == "Schowaj")
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
            }

            if (ButtonPrzelewyWyswietlContent == "Schowaj")
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
            }


            TablicaDanych = new LokatyTabela(_navigator);
            TablicaDanych.DataContext = this;
            if (ButtonLokatyWyswietlContent == "Wyświetl")
            {
                ButtonLokatyWyswietlContent = "Schowaj";

                ListaLokat.Clear();
                ListaLokat = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneLokaty();

            }

            else
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
                ListaLokat.Clear();
                TablicaDanych = null;
            }
        }

        private void WyswietlKredyty()
        {
            Wyczysc_Listy_I_UserControlle_Z_Tabelami();
            if (ButtonKlienciWyswietlContent == "Schowaj")
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
            }
            if (ButtonLokatyWyswietlContent == "Schowaj")
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
            }
            if (ButtonPrzelewyWyswietlContent == "Schowaj")
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
            }

            TablicaDanych = new KredytyTabela(_navigator);
            TablicaDanych.DataContext = this;
            if (ButtonKredytyWyswietlContent == "Wyświetl")
            {
                ButtonKredytyWyswietlContent = "Schowaj";

                ListaKredytow.Clear();
                ListaKredytow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywneKredyty();

            }

            else
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
                ListaKredytow.Clear();
                TablicaDanych = null;
            }
        }



        private void Wyjdz()
        {
            Application.Current.MainWindow.Close();
        }


    }
}
