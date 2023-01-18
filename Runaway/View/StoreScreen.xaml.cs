using Runaway.Objects;
using Runaway.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Runaway.View
{
    /// <summary>
    /// Логика взаимодействия для StoreScreen.xaml
    /// </summary>
    public partial class StoreScreen : UserControl
    {
        public StoreScreen()
        {
            InitializeComponent();
            LoadItems();
        }

        public void LoadItems()
        {
            if (GamerStats.WaveState == 1) MessageBox.Show("Магазин недоступен. Необходимо пройти первую волну для калибровки вашего скилла.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                if (GamerStats.WaveState == 2)
                {
                    MessageBox.Show("Это магазин. Здесь вы можете приобрести нужные товары у продавца(или продать свои). Они обновляются с каждым заходом в магазин. Никто не знает, откуда он моментально берет свои товары :D\n-Для того,чтобы купить интересующие вас товары - кликните на товар и нажмите \"Купить\"\n-Для того, чтобы продать ненужные предметы - кликните на них и нажмите \"Продать\"", "Космический магазин", MessageBoxButton.OK, MessageBoxImage.Question);
                }
                for (int i = 0; i < Inventory.EnergyBlockCount; i++) Ship.Items.Add("Энергетический блок(+500 Ru)");
                for (int i = 0; i < Inventory.UFODebrisCount; i++) Ship.Items.Add("Обломки НЛО(+300 Ru)");
                for (int i = 0; i < Inventory.MeteoritDebrisCount; i++) Ship.Items.Add("Осколки метеорита(+2000 Ru)");
                for (int i = 0; i < Inventory.UFOSlimeCount; i++) Ship.Items.Add("Кусочек инопланетной слизи(+1000 Ru");
                for (int i = 0; i < Inventory.MonolithPartCount; i++) Ship.Items.Add("Часть монолита(+15000 Ru)");
                runsinstore.Text = Inventory.Wallet.ToString() + " Ru";
                Seller.Items.Add($"Оружие {ShipStats.LvlWeaponDamage}ур.({Marketplace.WeaponDamageCost} Ru)({ShipStats.WeaponDamage}(+5) D)");
                Seller.Items.Add($"Укрепление корабля {ShipStats.LvlHP}ур.({Marketplace.HPCost} Ru)({ShipStats.HP}(+10) HP)");
                if (ShipStats.MaxBulletSpeed > 1) Seller.Items.Add($"Скорость пули {ShipStats.LvlBulletSpeed}ур.({Marketplace.BulletSpeedCost} Ru)({ShipStats.BulletSpeed}(-1) ms)");
                if (ShipStats.MaxFirePower < 5) Seller.Items.Add($"Мощность выстрела {ShipStats.LvlFirePower}ур.({Marketplace.FirePowerCost} Ru)({ShipStats.FirePower}(+1) SpS)");
            }
        }



        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSounds.PlaySelectSound();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonSounds.PlayClickSound();
            MainWindow.Main.Content = new View.MainScreen();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if (Seller.SelectedItem != null)
            {
                ButtonSounds.PlayBuySound();
                long storeobject = 0;
                if (Convert.ToString(Seller.SelectedItem) == ($"Оружие {ShipStats.LvlWeaponDamage}ур.({Marketplace.WeaponDamageCost} Ru)({ShipStats.WeaponDamage}(+5) D)"))
                {
                    storeobject = Marketplace.WeaponDamageCost;
                    ShipStats.WeaponDamage += 5;
                }
                if (Convert.ToString(Seller.SelectedItem) == ($"Укрепление корабля {ShipStats.LvlHP}ур.({Marketplace.HPCost} Ru)({ShipStats.HP}(+10) HP)"))
                {
                    storeobject = Marketplace.HPCost;
                    ShipStats.HP += 10;
                }
                if (Convert.ToString(Seller.SelectedItem) == ($"Скорость пули {ShipStats.LvlBulletSpeed}ур.({Marketplace.BulletSpeedCost} Ru)({ShipStats.BulletSpeed}(-1) ms)"))
                {
                    storeobject = Marketplace.BulletSpeedCost;
                    ShipStats.BulletSpeed--;
                }
                if (Convert.ToString(Seller.SelectedItem) == ($"Мощность выстрела {ShipStats.LvlFirePower}ур.({Marketplace.FirePowerCost} Ru)({ShipStats.FirePower}(+1) SpS)"))
                {
                    storeobject = Marketplace.FirePowerCost;
                    ShipStats.FirePower++;
                }
                Seller.Items.RemoveAt(Seller.SelectedIndex);
                runsinstore.Text = runsinstore.Text.Replace("Ru", "");
                runsinstore.Text = Convert.ToString(Convert.ToInt32(runsinstore.Text) + storeobject) + " Ru";
                Inventory.Wallet -= storeobject;
            }
            else
            {
                ButtonSounds.PlayCancelSound();
            }
        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            if (Ship.SelectedItem != null)
            {
                long storeobject = 0;
                ButtonSounds.PlaySellSound();
                if (Convert.ToString(Ship.SelectedItem) == "Энергетический блок(+500 Ru)")
                {
                    storeobject = Marketplace.EnergyBlockCost;
                    Inventory.EnergyBlockCount -= 1;
                }
                if (Convert.ToString(Ship.SelectedItem) == "Обломки НЛО(+300 Ru)")
                {
                    storeobject = Marketplace.UFODebrisCost;
                    Inventory.UFODebrisCount -= 1;
                }
                if (Convert.ToString(Ship.SelectedItem) == "Осколки метеорита(+2000 Ru)")
                {
                    storeobject = Marketplace.MeteoritDebrisCost;
                    Inventory.MeteoritDebrisCount -= 1;
                }
                if (Convert.ToString(Ship.SelectedItem) == "Кусочек инопланетной слизи(+1000 Ru)")
                {
                    storeobject = Marketplace.UFOSlimeCost;
                    Inventory.UFOSlimeCount -= 1;
                }
                if (Convert.ToString(Ship.SelectedItem) == "Часть монолита(+15000 Ru)")
                {
                    storeobject = Marketplace.MonolithPartCost;
                    Inventory.MonolithPartCount -= 1;
                }
                Ship.Items.RemoveAt(Ship.SelectedIndex);
                runsinstore.Text = runsinstore.Text.Replace("Ru", "");
                runsinstore.Text = Convert.ToString(Convert.ToInt32(runsinstore.Text) + storeobject) + " Ru";
                Inventory.Wallet += storeobject;
            }
            else
            {
                ButtonSounds.PlayCancelSound();
            }
        }
    }
}
