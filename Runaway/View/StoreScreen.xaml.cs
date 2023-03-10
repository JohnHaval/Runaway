using Runaway.Objects;
using Runaway.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            Music.PlayMarketplaceSound();
        }

        public void LoadItems()
        {
            if (GamerStats.WaveState >= 2 && GamerStats.WaveState <= 5)
            {
                MessageBox.Show("Это магазин. Здесь вы можете приобрести нужные товары у продавца(или продать свои). Они обновляются с каждым заходом в магазин. Никто не знает, откуда он моментально берет свои товары :D\n-Для того,чтобы купить интересующие вас товары - кликните на товар и нажмите \"Купить\"\n-Для того, чтобы продать ненужные предметы - кликните на них и нажмите \"Продать\"", "Космический магазин", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            for (int i = 0; i < Inventory.EnergyBlockCount; i++) Ship.Items.Add($"Энергетический блок(+{Marketplace.EnergyBlockCost} Ru)");
            for (int i = 0; i < Inventory.UFODebrisCount; i++) Ship.Items.Add($"Обломки НЛО(+{Marketplace.UFODebrisCost} Ru)");
            for (int i = 0; i < Inventory.MeteoritDebrisCount; i++) Ship.Items.Add($"Осколки метеорита(+{Marketplace.MeteoritDebrisCost} Ru)");
            for (int i = 0; i < Inventory.UFOSlimeCount; i++) Ship.Items.Add($"Кусочек инопланетной слизи(+{Marketplace.UFOSlimeCost} Ru)");
            for (int i = 0; i < Inventory.MonolithPartCount; i++) Ship.Items.Add($"Часть монолита(+{Marketplace.MonolithPartCost} Ru)");
            runsinstore.Text = Inventory.Wallet.ToString() + " Ru";
            Seller.Items.Add($"Оружие {ShipStats.LvlWeaponDamage}ур.({Marketplace.WeaponDamageCost} Ru)({ShipStats.WeaponDamage}(+5) D)");
            Seller.Items.Add($"Укрепление корабля {ShipStats.LvlHP}ур.({Marketplace.HPCost} Ru)({ShipStats.HP}(+10) HP)");
            if (ShipStats.BulletSpeed > ShipStats.MaxBulletSpeed) Seller.Items.Add($"Скорость пули {ShipStats.LvlBulletSpeed}ур.({Marketplace.BulletSpeedCost} Ru)({ShipStats.BulletSpeed}(-1) ms)");
            if (ShipStats.FirePower < ShipStats.MaxFirePower) Seller.Items.Add($"Мощность выстрела {ShipStats.LvlFirePower}ур.({Marketplace.FirePowerCost} Ru)({ShipStats.FirePower}(+1) SpS)");
            if (ShipStats.ShipSpeed < ShipStats.MaxShipSpeed) Seller.Items.Add($"Скорость корабля {ShipStats.LvlShipSpeed}ур.({Marketplace.ShipSpeedCost} Ru)({ShipStats.LvlShipSpeed}(+1) SpS)");
        }



        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSounds.PlaySelectSound();
            ((Button)sender).Foreground = new SolidColorBrush(Colors.Black);
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
                if (Convert.ToString(Seller.SelectedItem) == $"Оружие {ShipStats.LvlWeaponDamage}ур.({Marketplace.WeaponDamageCost} Ru)({ShipStats.WeaponDamage}(+5) D)")
                {
                    if (BuyObject(Marketplace.WeaponDamageCost)) ShipStats.WeaponDamage += 5;
                }
                else if (Convert.ToString(Seller.SelectedItem) == $"Укрепление корабля {ShipStats.LvlHP}ур.({Marketplace.HPCost} Ru)({ShipStats.HP}(+10) HP)")
                {
                    if (BuyObject(Marketplace.HPCost)) ShipStats.HP += 10;
                }
                else if (Convert.ToString(Seller.SelectedItem) == $"Скорость пули {ShipStats.LvlBulletSpeed}ур.({Marketplace.BulletSpeedCost} Ru)({ShipStats.BulletSpeed}(-1) ms)")
                {
                    if (BuyObject(Marketplace.BulletSpeedCost)) ShipStats.BulletSpeed--;
                }
                else if (Convert.ToString(Seller.SelectedItem) == $"Мощность выстрела {ShipStats.LvlFirePower}ур.({Marketplace.FirePowerCost} Ru)({ShipStats.FirePower}(+1) SpS)")
                {
                    if (BuyObject(Marketplace.FirePowerCost)) ShipStats.FirePower++;
                }
                else if (Convert.ToString(Seller.SelectedItem) == $"Скорость корабля {ShipStats.LvlShipSpeed}ур.({Marketplace.ShipSpeedCost} Ru)({ShipStats.ShipSpeed}(+1) SpS)")
                {
                    if (BuyObject(Marketplace.ShipSpeedCost)) ShipStats.ShipSpeed++;
                }
            }
            else
            {
                ButtonSounds.PlayCancelSound();
                MessageBox.Show("Для покупки улучшения, необходимо выбрать элемент из правого списка!", "Покупка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool BuyObject(long storeObject)
        {
            if (storeObject > Inventory.Wallet)
            {
                MessageBox.Show("Недостаточно денег для совершения покупки улучшения!", "Неудачная покупка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            Seller.Items.RemoveAt(Seller.SelectedIndex);
            Inventory.Wallet -= storeObject;
            runsinstore.Text = $"{Inventory.Wallet} Ru";
            return true;
        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            if (Ship.SelectedItem != null)
            {
                ButtonSounds.PlaySellSound();
                if (Convert.ToString(Ship.SelectedItem) == $"Энергетический блок(+{Marketplace.EnergyBlockCost} Ru)")
                {
                    SellObject(Marketplace.EnergyBlockCost);
                    Inventory.EnergyBlockCount -= 1;
                }
                else if (Convert.ToString(Ship.SelectedItem) == $"Обломки НЛО(+{Marketplace.UFODebrisCost} Ru)")
                {
                    SellObject(Marketplace.UFODebrisCost);
                    Inventory.UFODebrisCount -= 1;
                }
                else if (Convert.ToString(Ship.SelectedItem) == $"Осколки метеорита(+{Marketplace.MeteoritDebrisCost} Ru)")
                {
                    SellObject(Marketplace.MeteoritDebrisCost);
                    Inventory.MeteoritDebrisCount -= 1;
                }
                else if (Convert.ToString(Ship.SelectedItem) == $"Кусочек инопланетной слизи(+{Marketplace.UFOSlimeCost} Ru)")
                {
                    SellObject(Marketplace.UFOSlimeCost);
                    Inventory.UFOSlimeCount -= 1;
                }
                else if (Convert.ToString(Ship.SelectedItem) == $"Часть монолита(+{Marketplace.MonolithPartCost} Ru)")
                {
                    SellObject(Marketplace.MonolithPartCost);
                    Inventory.MonolithPartCount -= 1;
                }

            }
            else
            {
                ButtonSounds.PlayCancelSound();
                MessageBox.Show("Для продажи предмета из инвентаря, необходимо выбрать элемент из левого списка!", "Продажа", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SellObject(long storeObject)
        {
            Ship.Items.RemoveAt(Ship.SelectedIndex);
            Inventory.Wallet += storeObject;
            runsinstore.Text = $"{Inventory.Wallet} Ru";
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (GamerStats.WaveState == 1)
            {
                MessageBox.Show("Магазин недоступен. Необходимо пройти первую волну для калибровки вашего скилла.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                MainWindow.Main.Content = new MainScreen();
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
