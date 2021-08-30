using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spa_System
{
    //Main width 1306
    //Main height 704
    //
    //Auth
    //370 width to 367 height
    public static class DtHelper
    {
        public static DateTime myTimeStart
        {
            get { return DateTime.Today.AddYears(-50).AddDays(DateTime.Today.Day - (DateTime.Today.Day - 1)); }
        }
        public static DateTime myTimeEnd
        {
            get { return DateTime.Today.AddYears(-18).AddDays(DateTime.Today.Day - (DateTime.Today.Day - 1)); }
        }
        public static DateTime myTimeStart2
        {
            get { return DateTime.Today; }
        }
        public static DateTime myTimeEnd2
        {
            get { return DateTime.Today.AddDays(7); }
        }
    }
    public partial class MainWindow : Window
    {
        string FillStatus = "";
        int UserID;
        int selectedidworkerFIo;
        string UserRole;
        bool auth = false, IsUsePosSystem_One = false, IsUsePosSystem_Two = false, IsUsePosSystem_Three = false, IsUsePosSystem_Four = false;
        MainDataSet BdSet = new MainDataSet();
        MainDataSetTableAdapters.QueriesTableAdapter OnlyOneSelectAdapter = new MainDataSetTableAdapters.QueriesTableAdapter();
        MainDataSetTableAdapters.UsersTableAdapter UsersAdapter = new MainDataSetTableAdapters.UsersTableAdapter();
        MainDataSetTableAdapters.Users_LogsTableAdapter LogsAdapter = new MainDataSetTableAdapters.Users_LogsTableAdapter();
        MainDataSetTableAdapters.Users_RolesTableAdapter RolesAdapter = new MainDataSetTableAdapters.Users_RolesTableAdapter();
        MainDataSetTableAdapters.WorkersTableAdapter WorkersAdapter = new MainDataSetTableAdapters.WorkersTableAdapter();
        MainDataSetTableAdapters.Workers_FunctionsTableAdapter WorkersFunctionsAdapter = new MainDataSetTableAdapters.Workers_FunctionsTableAdapter();
        MainDataSetTableAdapters.GraphicTableAdapter GraphicWorkerAdapter = new MainDataSetTableAdapters.GraphicTableAdapter();
        MainDataSetTableAdapters.ClientsTableAdapter ClientsAdapter = new MainDataSetTableAdapters.ClientsTableAdapter();
        MainDataSetTableAdapters.ServicesTableAdapter ServicesAdapter = new MainDataSetTableAdapters.ServicesTableAdapter();
        MainDataSetTableAdapters.Records_To_ServicesTableAdapter RecordsAdapter = new MainDataSetTableAdapters.Records_To_ServicesTableAdapter();
        MainDataSetTableAdapters.GoodsTableAdapter GoodsAdapter = new MainDataSetTableAdapters.GoodsTableAdapter();
        MainDataSetTableAdapters.List_GoodsTableAdapter ListGoodsAdapter = new MainDataSetTableAdapters.List_GoodsTableAdapter();
        MainDataSetTableAdapters.SuppliersTableAdapter SuppliersAdapter = new MainDataSetTableAdapters.SuppliersTableAdapter();
        MainDataSetTableAdapters.OrdersTableAdapter OrdersAdapter = new MainDataSetTableAdapters.OrdersTableAdapter();
        List<string> ListLogins = new List<string>();
        List<string> ListPasswords = new List<string>();
        List<string> ListRoles = new List<string>();
        List<string> ListFiWorkers = new List<string>();
        decimal LastPriceList;
        bool deact = false;
        string SelectedRole, SelectedFunction, SelectedGraphic, SelectedService, SelectedGoods, SelectedSupplier;
        int selectedindexRecord = -1, UpdateRecordIndexClient = -1, SelectedClientID = -1, SelectedIDOrder = -1, SelectedIdOrderListGoods = -1;
        bool UpdateUsers = false, UpdateUsersRoles = false, UpdateWorkers = false, UpdateFunctions = false, UpdateGraphic = false, UpdateClients = false, UpdateServices = false, UpdateRecords = false, Update_Goods = false, UpdateSuppliers = false, UpdateOrders = false, UpdateListGoods = false;
        public MainWindow()
        {
            InitializeComponent();
            this.Width = 370;
            this.Height = 367;
            Auth.Visibility = Visibility.Visible;
            UsersAdapter.Fill(BdSet.Users);
            RolesAdapter.Fill(BdSet.Users_Roles);
            LogsAdapter.Fill(BdSet.Users_Logs);
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            Login.MaxLength = 20;
            Password.MaxLength = 20;
            Main.Visibility = Visibility.Hidden;
            DateOfBirthClient.DisplayDateStart = DateOfBirthWorker.DisplayDateStart = DtHelper.myTimeStart;
            DateOfBirthClient.DisplayDateEnd = DateOfBirthWorker.DisplayDateEnd = DtHelper.myTimeEnd;
            DateOfBirthClient.DisplayDateEnd = DateOfBirthWorker.SelectedDate = DateOfBirthWorker.DisplayDateEnd.Value;
            DateRecord.DisplayDateStart = DtHelper.myTimeStart2;
            DateRecord.DisplayDateEnd = DtHelper.myTimeEnd2;
            DateRecord.DisplayDateStart = DtHelper.myTimeStart2;
            Password.MaxLength = Login.MaxLength = Name_Goods.MaxLength = Name_Services.MaxLength = FieldNameWorkerFunction.MaxLength = FieldNameRole.MaxLength = FnameClient.MaxLength = FnameWorker.MaxLength = LnameClient.MaxLength = LnameWorker.MaxLength = MnameClient.MaxLength = MnameWorker.MaxLength = FieldLogin.MaxLength = FieldPassword.MaxLength = 30;
        }
        public void GetLoginsAndPasswords()
        {
            for (int i = 0; i < BdSet.Users.Count; i++)
            {
                string info = BdSet.Tables["Users"].Rows[i].Field<string>("Login");
                ListLogins.Add(info);
                info = BdSet.Tables["Users"].Rows[i].Field<string>("Password");
                ListPasswords.Add(info);
            }
        }
        private void Button_Auth(object sender, RoutedEventArgs e)
        {
            GetLoginsAndPasswords();
            for (int i = 0; i < BdSet.Users_Roles.Count; i++)
            {
                ListRoles.Add(BdSet.Tables["Users_Roles"].Rows[i].Field<string>("Role"));
            }
            for (int i = 0; i < ListLogins.Count; i++)
            {
                if (Login.Text == ListLogins[i] && Password.Text == ListPasswords[i])
                {
                    auth = true;
                    UserID = OnlyOneSelectAdapter.GetUserId(Login.Text).Value;
                    UserRole = BdSet.Tables["Users"].Rows.Find(UserID).Field<string>("Role");
                    IsUsePosSystem_One = BdSet.Tables["Users_Roles"].Rows.Find(UserRole).Field<bool>("IsUsePosSystem_One");
                    IsUsePosSystem_Two = BdSet.Tables["Users_Roles"].Rows.Find(UserRole).Field<bool>("IsUsePosSystem_Two");
                    IsUsePosSystem_Three = BdSet.Tables["Users_Roles"].Rows.Find(UserRole).Field<bool>("IsUsePosSystem_Three");
                    IsUsePosSystem_Four = BdSet.Tables["Users_Roles"].Rows.Find(UserRole).Field<bool>("IsUsePosSystem_Four");
                }
            }
            if (auth == true)
            {
                MessageBox.Show("Авторизация успешна, ваша роль: " + UserRole + " ");
                LogsAdapter.InsertQuery(UserID, "Выполнил вход в систему", OnlyOneSelectAdapter.ScalarQuery().Value);
                this.Width = 1491;
                this.Height = 704;
                Auth.Visibility = Visibility.Hidden;
                Main.Visibility = Visibility.Visible;
                if (IsUsePosSystem_One == false)
                {
                    MainTab_One.Visibility = Visibility.Collapsed;
                    Users_System_Tab.Visibility = Visibility.Collapsed;
                }
                else if (IsUsePosSystem_One)
                {
                    UsersGrid.ItemsSource = BdSet.Users.DefaultView;
                    UserRoles_Grid.ItemsSource = BdSet.Users_Roles.DefaultView;
                    UserLog_Grid.ItemsSource = BdSet.Users_Logs.DefaultView;
                    WorkersAdapter.Fill(BdSet.Workers);
                    for (int i = 0; i < BdSet.Workers.Count; i++)
                    {
                        ListFiWorkers.Add("[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname"));
                    }
                    Workers_Combo_Main.ItemsSource = ListFiWorkers;
                    Workers_Roles_Combo.ItemsSource = BdSet.Users_Roles;
                    Workers_Roles_Combo.DisplayMemberPath = "Role";
                    Workers_Roles_Combo.SelectedValuePath = "Role";
                    Workers_Roles_Combo.SelectedIndex = 0;
                    Workers_Combo_Main.SelectedIndex = 0;
                    LogsAdapter.Fill(BdSet.Users_Logs);
                    UsersGrid.Columns[6].Visibility = Visibility.Collapsed;
                    CheckYval.Visibility = Visibility.Visible;
                    CheckYval_Users.Visibility = Visibility.Visible;
                    ComboSearch.ItemsSource = BdSet.Users.DefaultView;
                    ComboSearch.DisplayMemberPath = "Login";
                    ComboSearch.SelectedValuePath = "Login";
                }
                if (IsUsePosSystem_Two == false)
                {
                    MainTab_Two.Visibility = Visibility.Collapsed;
                }
                else if (IsUsePosSystem_Two)
                {
                    WorkersAdapter.Fill(BdSet.Workers);

                    WorkersFunctionsAdapter.Fill(BdSet.Workers_Functions);
                    GraphicWorkerAdapter.Fill(BdSet.Graphic);
                    WorkersGrid.ItemsSource = BdSet.Workers.DefaultView;
                    Workers_FunctionsGrid.ItemsSource = BdSet.Workers_Functions.DefaultView;
                    WorkersGraphicGrid.ItemsSource = BdSet.Graphic;
                    WorkerFunctionCombo.ItemsSource = BdSet.Workers_Functions.DefaultView;
                    WorkerFunctionCombo.DisplayMemberPath = "Name_Function";
                    WorkerFunctionCombo.SelectedValuePath = "Name_Function";
                    WorkerFunctionCombo.SelectedIndex = 0;
                    graphic_Combo.ItemsSource = BdSet.Graphic.DefaultView;
                    graphic_Combo.DisplayMemberPath = "Name";
                    graphic_Combo.SelectedValuePath = "Name";
                }
                if (IsUsePosSystem_Three == false)
                {
                    MainTab_Three.Visibility = Visibility.Collapsed;
                }
                else if (IsUsePosSystem_Three)
                {
                    WorkersAdapter.Fill(BdSet.Workers);

                    ClientsAdapter.Fill(BdSet.Clients);
                    RecordsAdapter.Fill(BdSet.Records_To_Services);
                    ServicesAdapter.Fill(BdSet.Services);
                    Clients_Grid.ItemsSource = BdSet.Clients;
                    Records_Grid.ItemsSource = BdSet.Records_To_Services;
                    Services_Grid.ItemsSource = BdSet.Services;
                    ComboService.ItemsSource = BdSet.Services;
                    ComboService.DisplayMemberPath = "Name";
                    ComboService.SelectedValuePath = "Name";
                    FillerClients();
                }
                if (IsUsePosSystem_Four == false)
                {
                    MainTab_Four.Visibility = Visibility.Collapsed;
                }
                else if (IsUsePosSystem_Four)
                {
                    WorkersAdapter.Fill(BdSet.Workers);

                    GoodsAdapter.Fill(BdSet.Goods);
                    ListGoodsAdapter.Fill(BdSet.List_Goods);
                    SuppliersAdapter.Fill(BdSet.Suppliers);
                    OrdersAdapter.Fill(BdSet.Orders);
                    Orders_Grid.ItemsSource = BdSet.Orders;
                    ListOrdersGrid.ItemsSource = BdSet.List_Goods;
                    Suppliers_Grid.ItemsSource = BdSet.Suppliers;
                    Goods_Grid.ItemsSource = BdSet.Goods;
                    ComboOrderSupplier.ItemsSource = BdSet.Suppliers;
                    ComboOrderSupplier.DisplayMemberPath = "NameOrg";
                    ComboOrderSupplier.SelectedValuePath = "NameOrg";
                    NumberOrderCombo.ItemsSource = BdSet.Orders;
                    NumberOrderCombo.DisplayMemberPath = "ID";
                    NumberOrderCombo.SelectedValuePath = "ID";
                    GoodsListCombo.ItemsSource = BdSet.Goods;
                    GoodsListCombo.DisplayMemberPath = "Name";
                    GoodsListCombo.SelectedValuePath = "Name";
                }
                //bool 
                for (int i = 0; i < MainTabControl.Items.Count; i++)
                {
                    //if(MainTabControl=)
                }
            }
            else
            {
                MessageBox.Show("Введённые данные неверны, либо вашa учётная запись деактивирована.");
            }
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void AutoGeneratingColumns_DataGrid(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "UserID":
                    {
                        e.Column.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Login":
                    {
                        e.Column.Header = "Логин пользователя";
                    }
                    break;
                case "Id_Worker":
                    {
                        e.Column.Header = "№ Сотрудника";
                    }
                    break;
                case "Password":
                    {
                        e.Column.Header = "Пароль";
                    }
                    break;
                case "Role":
                    {
                        e.Column.Header = "Роль пользователя";
                    }
                    break;
                case "DateAndTime":
                    {
                        e.Column.Header = "Дата и время";
                        e.Column.ClipboardContentBinding.StringFormat = "yyyy.MM.dd HH:mm:ss";
                    } break;
                case "IsUsePosSystem_One":
                    {
                        e.Column.Header = "Доступ к первой подсистеме";
                    } break;
                case "IsUsePosSystem_Two":
                    {
                        e.Column.Header = "Доступ ко второй подсистеме";
                    }
                    break;
                case "IsUsePosSystem_Three":
                    {
                        e.Column.Header = "Доступ к третьей подсистеме";
                    }
                    break;
                case "IsUsePosSystem_Four":
                    {
                        e.Column.Header = "Доступ к четвёртой подсистеме";
                    }
                    break;
                case "User_Action":
                    {
                        e.Column.Header = "Активность пользователя";
                    }
                    break;
                case "Fname":
                    {
                        e.Column.Header = "Имя";
                    } break;
                case "Lname":
                    {
                        e.Column.Header = "Фамилия";
                    }
                    break;
                case "Mname":
                    {
                        e.Column.Header = "Отчество";
                    }
                    break;
                case "Sex":
                    {
                        e.Column.Header = "Пол";
                    }
                    break;
                case "Date_Of_Birth":
                    {
                        e.Column.Header = "Дата рождения";
                        e.Column.ClipboardContentBinding.StringFormat = "yyyy.MM.dd";
                    }
                    break;
                case "Adress":
                    {
                        e.Column.Header = "Адрес";
                    }
                    break;
                case "Phone_Number":
                    {
                        e.Column.Header = "Номер телефона";
                    }
                    break;
                case "Function":
                    {
                        e.Column.Header = "Должность";
                    }
                    break;
                case "Date_Start":
                    {
                        e.Column.Header = "Дата приёма";
                        e.Column.ClipboardContentBinding.StringFormat = "yyyy.MM.dd";
                    }
                    break;
                case "Status":
                    {
                        e.Column.Header = "Статус";
                    }
                    break;
                case "NameFunction":
                    {
                        e.Column.Header = "Наименование должности";
                    } break;
                case "Graphic":
                    {
                        e.Column.Header = "График";
                    }
                    break;
                case "Salary":
                    {
                        e.Column.Header = "Оклад (в руб)";
                    }
                    break;
                case "Time_Start":
                    {
                        e.Column.Header = "Время начала рабочего дня";
                    }
                    break;
                case "Time_End":
                    {
                        e.Column.Header = "Время конца рабочего дня";
                    }
                    break;
                case "Deactivated":
                    {
                        e.Column.Header = "Деактивирован";
                    } break;
                case "Email":
                    {
                        e.Column.Header = "Эл.почта";
                    } break;
                case "TimeRecord":
                    {
                        e.Column.Header = "Время записи";
                    } break;
                case "IDClient":
                    {
                        e.Column.Header = "№ Клиента";
                    } break;
                case "Duration":
                    {
                        e.Column.Header = "Длительность";
                    } break;
                case "Description":
                    {
                        e.Column.Header = "Описание";
                    } break;
                case "Price":
                    {
                        e.Column.Header = "Стоимость";
                    }
                    break;
                case "FnameClient":
                    {
                        e.Column.Header = "Имя клиента";
                    } break;
                case "LnameClient":
                    {
                        e.Column.Header = "Фамилия клиента";
                    } break;
                case "FnameWorker":
                    {
                        e.Column.Header = "Имя сотрудника";
                    } break;
                case "LnameWorker":
                    {
                        e.Column.Header = "Фамилия сотрудника";
                    } break;
            }

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 0:
                    {
                        switch (Users_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    Panel_Add_User.Visibility = Visibility.Visible;
                                    FieldLogin.Text = "";
                                    FieldPassword.Text = "";
                                    FieldNameRole.Text = "";
                                    if (Workers_Roles_Combo.Items.Count != 0)
                                        Workers_Roles_Combo.SelectedIndex = 0;
                                    UpdateUsers = false;
                                } break;
                            case 2:
                                {
                                    Panel_Add_User_Roles.Visibility = Visibility.Visible;
                                    FieldNameRole.Text = "";
                                    System_One.IsChecked = false;
                                    System_Two.IsChecked = false;
                                    System_Three.IsChecked = false;
                                    System_Four.IsChecked = false;
                                    UpdateUsersRoles = false;
                                }
                                break;
                        }
                    } break;
                case 1:
                    {
                        switch (Workers_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    Panel_Add_Workers.Visibility = Visibility.Visible;
                                    FnameWorker.Text = "";
                                    LnameWorker.Text = "";
                                    MnameWorker.Text = "";
                                    DateOfBirthWorker.SelectedDate = DateOfBirthWorker.DisplayDateEnd.Value;
                                    DateOfBirthWorker.Text = "";
                                    PhoneNumberWorker.Text = "";
                                    if (SexWorkerCombo.Items.Count != 0)
                                    {
                                        SexWorkerCombo.SelectedIndex = 0;
                                    }
                                    if (WorkerFunctionCombo.Items.Count != 0)
                                        WorkerFunctionCombo.SelectedIndex = 0;
                                    UpdateWorkers = false;
                                }
                                break;
                            case 1:
                                {
                                    FieldNameWorkerFunction.Text = "";
                                    Oklad.Text = "";
                                    Panel_Add_WorkerFunction.Visibility = Visibility.Visible;
                                    if (graphic_Combo.Items.Count != 0)
                                        graphic_Combo.SelectedIndex = 0;
                                    UpdateFunctions = false;
                                }
                                break;
                            case 2:
                                {
                                    FieldNameWorkerGraphic.Text = "";
                                    TimeStart.Text = "";
                                    TimeEnd.Text = "";
                                    Panel_Add_WorkerFunction_Graphic.Visibility = Visibility.Visible;
                                    UpdateGraphic = false;
                                }
                                break;
                        }
                    } break;
                case 2:
                    {
                        switch (Services_system_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    if (ComboService.Items.Count != 0)
                                    {
                                        ComboService.SelectedIndex = 0;
                                    }
                                    if (ComboClients.Items.Count != 0)
                                    {
                                        ComboClients.SelectedIndex = 0;
                                    }
                                    DateRecord.Text = "";
                                    TimeRecord.Text = "";
                                    Panel_Add_Records.Visibility = Visibility.Visible;
                                    UpdateRecords = false;
                                }
                                break;
                            case 1:
                                {
                                    Name_Services.Text = "";
                                    Duration_Services.Text = "";
                                    Description_Service.Text = "";
                                    Price_Services.Text = "";
                                    Panel_Add_Services.Visibility = Visibility.Visible;
                                    UpdateServices = false;
                                }
                                break;
                            case 2:
                                {
                                    FnameClient.Text = "";
                                    LnameClient.Text = "";
                                    MnameClient.Text = "";
                                    SexClientCombo.Text = "";
                                    PhoneNumberClient.Text = "";
                                    DateOfBirthClient.Text = "";
                                    EmailClient.Text = "";
                                    Panel_Add_Сlients.Visibility = Visibility.Visible;
                                    UpdateClients = false;
                                }
                                break;
                        }

                    } break;
                case 3:
                    {
                        switch (Orders_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    MessageBoxResult result = MessageBox.Show("Если вы хотите создать новый заказ, то нажмите <ДА>, если же хотите добавить список продукции к существующему, нажмите <НЕТ>. Для отмены действия, нажмите <ОТМЕНА>", "Внимание!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                                    if (result == MessageBoxResult.Yes)
                                    {
                                        if (ComboOrderSupplier.Items.Count != 0)
                                        {
                                            ComboOrderSupplier.SelectedIndex = 0;
                                        }
                                        UpdateOrders = false;
                                        Panel_Add_FormingOrder.Visibility = Visibility.Visible;
                                    }
                                    else if (result == MessageBoxResult.No)
                                    {
                                        if (NumberOrderCombo.Items.Count != 0)
                                        {
                                            NumberOrderCombo.SelectedIndex = 0;
                                        }
                                        if (GoodsListCombo.Items.Count != 0)
                                        {
                                            GoodsListCombo.SelectedIndex = 0;
                                        }
                                        PriceOfCountGoodsList.Text = "0";
                                        CountGoodsInList.Text = "";
                                        UpdateListGoods = false;
                                        Panel_Add_ListGoods.Visibility = Visibility.Visible;
                                    }
                                    else if (result == MessageBoxResult.Cancel)
                                    {
                                        ///
                                    }
                                }
                                break;
                            case 1:
                                {
                                    Suplier_Name.Text = "";
                                    AdressSuplier.Text = "";
                                    Phone_Number_Supplier.Text = "";
                                    UpdateSuppliers = false;
                                    Panel_Add_Suppliers.Visibility = Visibility.Visible;
                                }
                                break;
                            case 2:
                                {
                                    Name_Goods.Text = "";
                                    TypesGoods.SelectedIndex = 0;
                                    Price_Of_Piece_Goods.Text = "";
                                    Panel_Add_Goods.Visibility = Visibility.Visible;
                                    Update_Goods = false;
                                }
                                break;
                        }
                    } break;
            }
        }
        //Изменение (общее)
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 0:
                    {
                        switch (Users_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)UsersGrid.SelectedItem;
                                    string IFI;

                                    if (selectedDataRow != null)
                                    {
                                        WorkersAdapter.FillBy(BdSet.Workers);
                                        IFI = "[" + selectedDataRow.Row.ItemArray[0].ToString() + "] " + BdSet.Tables["Workers"].Rows.Find(Convert.ToInt32(selectedDataRow.Row.ItemArray[0])).Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows.Find(Convert.ToInt32(selectedDataRow.Row.ItemArray[0])).Field<string>("Lname");
                                        Workers_Combo_Main.Text = IFI;
                                        selectedidworkerFIo = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                                        FieldLogin.Text = BdSet.Tables["Users"].Rows.Find(Convert.ToInt32(selectedDataRow.Row.ItemArray[0])).Field<string>("Login");
                                        FieldPassword.Text = BdSet.Tables["Users"].Rows.Find(Convert.ToInt32(selectedDataRow.Row.ItemArray[0])).Field<string>("Password");
                                        Workers_Roles_Combo.Text = BdSet.Tables["Users"].Rows.Find(Convert.ToInt32(selectedDataRow.Row.ItemArray[0])).Field<string>("Role");

                                        UpdateUsers = true;
                                        if (Convert.ToBoolean(selectedDataRow.Row.ItemArray[4]) != false)
                                        {
                                            deact = true;
                                            MessageBox.Show("Нельзя изменить деактивированную учётную запись", "Предупреждение");
                                        }
                                        else
                                        {
                                            Panel_Add_User.Visibility = Visibility.Visible; deact = false;
                                        }
                                        WorkersAdapter.Fill(BdSet.Workers);
                                    }

                                    if (selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение учётной записи");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    bool notsysadmin = true;
                                    DataRowView selectedDataRow = (DataRowView)UserRoles_Grid.SelectedItem;
                                    if (selectedDataRow.Row.ItemArray[0].ToString() == "System_Administrator")
                                    {
                                        notsysadmin = false;
                                    }
                                    if (notsysadmin)
                                    {
                                        if (selectedDataRow != null)
                                        {
                                            SelectedRole = FieldNameRole.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                            System_One.IsChecked = Convert.ToBoolean(selectedDataRow.Row.ItemArray[1]);
                                            System_Two.IsChecked = Convert.ToBoolean(selectedDataRow.Row.ItemArray[2]);
                                            System_Three.IsChecked = Convert.ToBoolean(selectedDataRow.Row.ItemArray[3]);
                                            System_Four.IsChecked = Convert.ToBoolean(selectedDataRow.Row.ItemArray[4]);
                                            Panel_Add_User_Roles.Visibility = Visibility.Visible;
                                            UpdateUsersRoles = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не выбрана запись для редактирования", "Изменение выбранной роли");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Данную роль нельзя изменять", "Изменение выбранной роли");
                                        notsysadmin = true;
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case 1:
                    {
                        switch (Workers_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)WorkersGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        FnameWorker.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        LnameWorker.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                        MnameWorker.Text = selectedDataRow.Row.ItemArray[3].ToString();
                                        SexWorkerCombo.Text = selectedDataRow.Row.ItemArray[4].ToString();
                                        DateOfBirthWorker.Text = selectedDataRow.Row.ItemArray[5].ToString();
                                        AdressWorker.Text = selectedDataRow.Row.ItemArray[6].ToString();
                                        PhoneNumberWorker.Text = selectedDataRow.Row.ItemArray[7].ToString();
                                        WorkerFunctionCombo.Text = selectedDataRow.Row.ItemArray[8].ToString();
                                        Panel_Add_Workers.Visibility = Visibility.Visible;
                                        UpdateWorkers = true;
                                    }
                                    if (selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение выбранной роли");
                                    }
                                }
                                break;
                            case 1:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Workers_FunctionsGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        if (selectedDataRow.Row.ItemArray[0].ToString() != "Системный Администратор")
                                        {
                                            FieldNameWorkerFunction.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                            graphic_Combo.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                            Oklad.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                            Panel_Add_WorkerFunction.Visibility = Visibility.Visible;
                                            UpdateFunctions = true;
                                            SelectedFunction = selectedDataRow.Row.ItemArray[0].ToString();
                                            Panel_Add_WorkerFunction.Visibility = Visibility.Visible;
                                        }
                                        if (selectedDataRow.Row.ItemArray[0].ToString() == "Системный Администратор" && UserRole != "System_Administrator")
                                        {
                                            MessageBox.Show("У вас нет прав для редактирования данной должности", "Предупреждение");
                                        }
                                        else if (selectedDataRow.Row.ItemArray[0].ToString() == "Системный Администратор" && UserRole == "System_Administrator")
                                        {
                                            FieldNameWorkerFunction.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                            graphic_Combo.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                            Oklad.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                            Panel_Add_WorkerFunction.Visibility = Visibility.Visible;
                                            UpdateFunctions = true;
                                            SelectedFunction = selectedDataRow.Row.ItemArray[0].ToString();
                                            Panel_Add_WorkerFunction.Visibility = Visibility.Visible;
                                        }
                                    }
                                    if (selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение выбранной роли");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    DataRowView selectedDataRow = (DataRowView)WorkersGraphicGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        FieldNameWorkerGraphic.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                        TimeStart.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        TimeEnd.Text = FieldNameRole.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                        Panel_Add_WorkerFunction_Graphic.Visibility = Visibility.Visible;
                                        UpdateGraphic = true;
                                        SelectedGraphic = selectedDataRow.Row.ItemArray[0].ToString();

                                    }
                                    if (selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение выбранной роли");
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        switch (Services_system_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Records_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        string IFI = "[" + selectedDataRow.Row.ItemArray[4].ToString() + "] " + selectedDataRow.Row.ItemArray[6].ToString() + " " + selectedDataRow.Row.ItemArray[7].ToString();
                                        ComboClients.Text = IFI;
                                        ComboService.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        DateRecord.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                        TimeRecord.Text = selectedDataRow.Row.ItemArray[3].ToString();
                                        Panel_Add_Records.Visibility = Visibility.Visible;
                                        UpdateRecords = true;
                                        selectedindexRecord = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                                        UpdateRecordIndexClient = Convert.ToInt32(selectedDataRow.Row.ItemArray[4]);

                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение записи на процедуру");
                                    }
                                }
                                break;
                            case 1:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Services_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        SelectedService = Name_Services.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                        Duration_Services.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        Description_Service.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                        Price_Services.Text = selectedDataRow.Row[3].ToString();
                                        UpdateServices = true;
                                        Panel_Add_Services.Visibility = Visibility.Visible;
                                    }
                                    else if (selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение данных о клиенте");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Clients_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        FnameClient.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        LnameClient.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                        MnameClient.Text = selectedDataRow.Row.ItemArray[3].ToString();
                                        SexClientCombo.Text = selectedDataRow.Row.ItemArray[4].ToString();
                                        DateOfBirthClient.Text = selectedDataRow.Row.ItemArray[5].ToString();
                                        EmailClient.Text = selectedDataRow.Row.ItemArray[7].ToString();
                                        PhoneNumberClient.Text = selectedDataRow.Row.ItemArray[6].ToString();
                                        Panel_Add_Сlients.Visibility = Visibility.Visible;
                                        UpdateClients = true;
                                        SelectedClientID = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                                    }
                                    else if (selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для редактирования", "Изменение данных о клиенте");
                                    }
                                }
                                break;
                        }

                    }
                    break;
                case 3:
                    {
                        switch (Orders_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow1 = (DataRowView)ListOrdersGrid.SelectedItem;
                                    DataRowView selectedDataRow = (DataRowView)Orders_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        ComboOrderSupplier.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        UpdateOrders = true;
                                        Panel_Add_FormingOrder.Visibility = Visibility.Visible;
                                        SelectedIDOrder = selectedDataRow.Row.Field<int>("ID");
                                        UpdateOrders = true;
                                        Panel_Add_FormingOrder.Visibility = Visibility.Visible;
                                    }
                                    else if (selectedDataRow1 != null)
                                    {
                                        NumberOrderCombo.Text = selectedDataRow1.Row.ItemArray[0].ToString();
                                        GoodsListCombo.Text = selectedDataRow1.Row.ItemArray[1].ToString();
                                        CountGoodsInList.Text = selectedDataRow1.Row.ItemArray[2].ToString();
                                        PriceOfCountGoodsList.Text = selectedDataRow1.Row.ItemArray[3].ToString();
                                        LastPriceList = Convert.ToDecimal(selectedDataRow1.Row.ItemArray[3]);
                                        UpdateListGoods = true;
                                        Panel_Add_ListGoods.Visibility = Visibility.Visible;
                                        SelectedIdOrderListGoods = Convert.ToInt32(selectedDataRow1.Row.ItemArray[0]);
                                    }
                                    else if (selectedDataRow == null & selectedDataRow1 == null)
                                    {
                                        MessageBox.Show("Не выбрана изменяемая запись", "Предупреждение");
                                    }
                                }
                                break;
                            case 1:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Suppliers_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        Suplier_Name.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                        AdressSuplier.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        Phone_Number_Supplier.Text = selectedDataRow.Row[2].ToString();
                                        UpdateSuppliers = true;
                                        SelectedSupplier = selectedDataRow.Row.ItemArray[0].ToString();
                                        Panel_Add_Suppliers.Visibility = Visibility.Visible;

                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана изменяемая запись", "Предупреждение");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Goods_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        Name_Goods.Text = selectedDataRow.Row.ItemArray[0].ToString();
                                        TypesGoods.Text = selectedDataRow.Row.ItemArray[1].ToString();
                                        Price_Of_Piece_Goods.Text = selectedDataRow.Row.ItemArray[2].ToString();
                                        Update_Goods = true;
                                        SelectedGoods = selectedDataRow.Row.ItemArray[0].ToString();
                                        Panel_Add_Goods.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрано ни одной записи", "Предупреждение");
                                    }

                                }
                                break;
                        }
                    }
                    break;
            }
        }
        //Удаление записей
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 0:
                    {
                        switch (Users_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)UsersGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        if (UserID != Convert.ToInt32(selectedDataRow.Row.ItemArray[0]))
                                        {
                                            deact = Convert.ToBoolean(selectedDataRow.Row.ItemArray[4]);
                                            int deleteid = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                                            if (deact != true)
                                            {
                                                UsersAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                                UsersAdapter.Fill(BdSet.Users);
                                                ListLogins.Clear();
                                                ListPasswords.Clear();
                                                GetLoginsAndPasswords();
                                                LogsAdapter.InsertQuery(UserID, "Деактивировал учётную запись сотрудника с номером <" + deleteid + "> (" + BdSet.Workers.Rows.Find(deleteid).Field<string>("Fname") + " " + BdSet.Workers.Rows.Find(deleteid).Field<string>("Lname") + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                                LogsAdapter.Fill(BdSet.Users_Logs);
                                                if (CheckYval_Users.IsChecked.Value == true)
                                                {
                                                    UsersAdapter.FillBy(BdSet.Users);
                                                }
                                                else
                                                {
                                                    UsersAdapter.Fill(BdSet.Users);
                                                }
                                            }
                                            else
                                            {
                                                MessageBoxResult result = MessageBox.Show("Учётная запись и логи связанные с ней данные будут удалены. Вы уверены что хотите это сделать?", "Внимание!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                                                if (result == MessageBoxResult.Yes)
                                                {
                                                    UsersAdapter.FullDelete(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                                    UsersAdapter.Fill(BdSet.Users);
                                                    ListLogins.Clear();
                                                    ListPasswords.Clear();
                                                    GetLoginsAndPasswords();
                                                    WorkersAdapter.FillBy(BdSet.Workers);
                                                    LogsAdapter.InsertQuery(UserID, "Удалил учётную запись сотрудника с номером <" + deleteid + "> (" + BdSet.Workers.Rows.Find(deleteid).Field<string>("Fname") + " " + BdSet.Workers.Rows.Find(deleteid).Field<string>("Lname") + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                                    LogsAdapter.Fill(BdSet.Users_Logs);
                                                    if (CheckYval_Users.IsChecked.Value == true)
                                                    {
                                                        UsersAdapter.FillBy(BdSet.Users);
                                                    }
                                                    else
                                                    {
                                                        UsersAdapter.Fill(BdSet.Users);
                                                    }
                                                    WorkersAdapter.Fill(BdSet.Workers);
                                                    deact = false;
                                                }
                                                else if (result == MessageBoxResult.No)
                                                {
                                                    deact = false;

                                                }

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Вы не можете удалить учётную запись, в которой находитесь", "Деактивация учётной записи");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись", "Деактивация (удаление) учётной записи");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    bool notsysadmin = true;
                                    bool checkusers = false;
                                    DataRowView selectedDataRow = (DataRowView)UserRoles_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        for (int i = 0; i < BdSet.Users.Count; i++)
                                        {
                                            if (selectedDataRow.Row.ItemArray[0].ToString() == BdSet.Tables["Users"].Rows[i].Field<string>("Role"))
                                            {
                                                checkusers = true;
                                            }
                                        }
                                        if (selectedDataRow.Row.ItemArray[0].ToString() == "System_Administrator")
                                        {
                                            notsysadmin = false;
                                        }
                                        if (notsysadmin)
                                        {
                                            if (checkusers != true)
                                            {
                                                RolesAdapter.DeleteQuery(selectedDataRow.Row.ItemArray[0].ToString());
                                                RolesAdapter.Fill(BdSet.Users_Roles);
                                                LogsAdapter.InsertQuery(UserID, "Удалил пользовательскую роль: " + SelectedRole, OnlyOneSelectAdapter.ScalarQuery().Value);
                                                LogsAdapter.Fill(BdSet.Users_Logs);
                                            }
                                            else if (checkusers)
                                            {
                                                MessageBox.Show("Присутствуют учётные записи с данной ролью, удаление роли невозможно", "Удаление роли");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Удалить роль системного администратора невозможно", "Удаление роли");
                                            notsysadmin = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана роль для удаления", "Удаление роли");
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case 1:
                    {
                        switch (Workers_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)WorkersGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        int deleteid = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                                        if (deleteid != UserID)
                                        {
                                            if (selectedDataRow.Row.ItemArray[8].ToString() != "Системный Администратор")
                                            {
                                                LogsAdapter.InsertQuery(UserID, "Уволил сотрудника с номером <" + deleteid + "> (" + BdSet.Workers.Rows.Find(deleteid).Field<string>("Fname") + " " + BdSet.Workers.Rows.Find(deleteid).Field<string>("Lname") + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                                LogsAdapter.Fill(BdSet.Users_Logs);
                                                WorkersAdapter.UpdateStatus("Уволенный", Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                                WorkersAdapter.Fill(BdSet.Workers);
                                                ListFiWorkers.Clear();
                                                for (int i = 0; i < BdSet.Workers.Count; i++)
                                                {
                                                    ListFiWorkers.Add("[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname"));
                                                }
                                                UsersAdapter.DeleteQuery(deleteid);
                                                switch (CheckYval.IsChecked.Value)
                                                {
                                                    case true:
                                                        {
                                                            FillStatus = "";
                                                            WorkersAdapter.FillBy(BdSet.Workers);
                                                        }
                                                        break;
                                                    case false:
                                                        {
                                                            WorkersAdapter.Fill(BdSet.Workers);
                                                            FillStatus = "Работающий";
                                                        }
                                                        break;
                                                }
                                            }
                                            else if (selectedDataRow.Row.ItemArray[8].ToString() == "Системный Администратор" && UserRole == "System_Administrator")
                                            {
                                                LogsAdapter.InsertQuery(UserID, "Уволил сотрудника с номером <" + deleteid + "> (" + BdSet.Workers.Rows.Find(deleteid).Field<string>("Fname") + " " + BdSet.Workers.Rows.Find(deleteid).Field<string>("Lname") + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                                LogsAdapter.Fill(BdSet.Users_Logs);
                                                WorkersAdapter.UpdateStatus("Уволенный", Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                                WorkersAdapter.Fill(BdSet.Workers);
                                                ListFiWorkers.Clear();
                                                for (int i = 0; i < BdSet.Workers.Count; i++)
                                                {
                                                    ListFiWorkers.Add("[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname"));
                                                }
                                                UsersAdapter.DeleteQuery(deleteid);
                                                switch (CheckYval.IsChecked.Value)
                                                {
                                                    case true:
                                                        {
                                                            FillStatus = "";
                                                            WorkersAdapter.FillBy(BdSet.Workers);
                                                        }
                                                        break;
                                                    case false:
                                                        {
                                                            WorkersAdapter.Fill(BdSet.Workers);
                                                            FillStatus = "Работающий";
                                                        }
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Нельзя уволить системного администратора. Только системный оператор может выполнить данную операцию", "Предупреждение");
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Нельзя уволить самого себя", "Предупреждение");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись", "Удаление сотрудника");
                                    }
                                }
                                break;
                            case 1:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Workers_FunctionsGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        try
                                        {
                                            if (selectedDataRow.Row.ItemArray[0].ToString() != "Системный Администратор")
                                            {
                                                string delete = selectedDataRow.Row.ItemArray[0].ToString();
                                                WorkersFunctionsAdapter.DeleteQuery(delete);
                                                LogsAdapter.InsertQuery(UserID, "Удалил должность: " + delete, OnlyOneSelectAdapter.ScalarQuery().Value);
                                                LogsAdapter.Fill(BdSet.Users_Logs);
                                                WorkersFunctionsAdapter.Fill(BdSet.Workers_Functions);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Удалить данную должность невозможно");
                                            }
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Сначала смените должность у сотрудников, которые имеют данную должность", "Удаление должности");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись", "Удаление должности");

                                    }
                                }
                                break;
                            case 2:
                                {
                                    DataRowView selectedDataRow = (DataRowView)WorkersGraphicGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        try
                                        {
                                            string delete = selectedDataRow.Row.ItemArray[0].ToString();
                                            GraphicWorkerAdapter.DeleteQuery(delete);
                                            LogsAdapter.InsertQuery(UserID, "Удалил график с наименованием: " + delete, OnlyOneSelectAdapter.ScalarQuery().Value);
                                            LogsAdapter.Fill(BdSet.Users_Logs);
                                            GraphicWorkerAdapter.Fill(BdSet.Graphic);
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Сначала смените график у должностей, которые имеют данный график", "Удаление графика");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись", "Удаление графика");

                                    }
                                }
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        switch (Services_system_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Records_Grid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        LogsAdapter.InsertQuery(UserID, "Удалил запись на процедуры с номером: " + Convert.ToInt32(selectedDataRow.Row.ItemArray[0]), OnlyOneSelectAdapter.ScalarQuery().Value);
                                        RecordsAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                        RecordsAdapter.Fill(BdSet.Records_To_Services);
                                        LogsAdapter.Fill(BdSet.Users_Logs);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Выберите удаляемую запись", "Предупреждение");
                                    }
                                }
                                break;
                            case 1:
                                {
                                    string service;
                                    DataRowView selectedDataRow = (DataRowView)Services_Grid.SelectedItem;
                                    bool RecordHasDeleteServices = false;
                                    if (selectedDataRow != null)
                                    {
                                        service = selectedDataRow.Row.ItemArray[0].ToString();
                                        for (int i = 0; i < BdSet.Records_To_Services.Count; i++)
                                        {
                                            if (selectedDataRow.Row.ItemArray[0].ToString() == BdSet.Records_To_Services.Rows[i].Field<string>("Service_Name"))
                                            {
                                                RecordHasDeleteServices = true;
                                            }
                                        }
                                        if (!RecordHasDeleteServices)
                                        {
                                            LogsAdapter.InsertQuery(UserID, "Удалил услугу: " + selectedDataRow.Row.ItemArray[0].ToString(), OnlyOneSelectAdapter.ScalarQuery().Value);
                                            ServicesAdapter.DeleteQuery(selectedDataRow.Row.ItemArray[0].ToString());
                                            LogsAdapter.Fill(BdSet.Users_Logs);
                                        }
                                        else if (RecordHasDeleteServices)
                                        {
                                            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить данную услугу? Записи на данную процедуру будут удалены", "Предупреждение при процедуры", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                            if (result == MessageBoxResult.Yes)
                                            {
                                                try
                                                {
                                                    LogsAdapter.InsertQuery(UserID, "Удалил услугу: " + service + ". Изменения затронули записи на процедуры", OnlyOneSelectAdapter.ScalarQuery().Value);
                                                    //RecordsAdapter.DeleteWhereService(service);
                                                    ServicesAdapter.DeleteQuery(service);
                                                    ServicesAdapter.Fill(BdSet.Services);
                                                    RecordHasDeleteServices = false;
                                                    ServicesAdapter.Fill(BdSet.Services);
                                                    RecordsAdapter.Fill(BdSet.Records_To_Services);

                                                }
                                                catch
                                                {
                                                    RecordHasDeleteServices = false;
                                                    MessageBox.Show("Что-то пошло не так", "Удаление услуги");
                                                }
                                            }
                                            else if (result == MessageBoxResult.No)
                                            {
                                                RecordHasDeleteServices = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Выберите удаляемую услугу", "Предупреждение");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    int client;
                                    DataRowView selectedDataRow = (DataRowView)Clients_Grid.SelectedItem;
                                    bool ClientHasRecord = false;
                                    if (selectedDataRow != null)
                                    {
                                        for (int i = 0; i < BdSet.Records_To_Services.Count; i++)
                                        {
                                            if (Convert.ToInt32(selectedDataRow.Row.ItemArray[0]) == BdSet.Records_To_Services.Rows[i].Field<int>("ID_Client"))
                                            {
                                                ClientHasRecord = true;
                                            }
                                        }
                                        if (!ClientHasRecord)
                                        {
                                            LogsAdapter.InsertQuery(UserID, "Удалил клиента с номером: " + Convert.ToInt32(selectedDataRow.Row.ItemArray[0]), OnlyOneSelectAdapter.ScalarQuery().Value);
                                            ClientsAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                            ClientsAdapter.Fill(BdSet.Clients);
                                            LogsAdapter.Fill(BdSet.Users_Logs);
                                            FillerClients();
                                        }
                                        else if (ClientHasRecord)
                                        {
                                            client = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                                            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить данного клиента? Запись на проудеры для этого клиента также будет удалена", "Предупреждение при удалении клиента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                            if (result == MessageBoxResult.Yes)
                                            {
                                                try
                                                {

                                                    LogsAdapter.InsertQuery(UserID, "Удалил клиента с номером: " + client.ToString() + ". Изменения затронули записи на процедуры", OnlyOneSelectAdapter.ScalarQuery().Value);
                                                    RecordsAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                                    RecordsAdapter.Fill(BdSet.Records_To_Services);
                                                    ClientsAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                                    ClientsAdapter.Fill(BdSet.Clients);
                                                    ClientHasRecord = false;
                                                    FillerClients();
                                                }
                                                catch
                                                {
                                                    ClientHasRecord = false;
                                                    MessageBox.Show("Что-то пошло не так", "Удаление клиента");
                                                }
                                            }
                                            else if (result == MessageBoxResult.No)
                                            {
                                                ClientHasRecord = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Выберите удаляемого клиента", "Предупреждение");
                                    }

                                }
                                break;
                        }

                    }
                    break;
                case 3:
                    {
                        switch (Orders_System_Tab.SelectedIndex)
                        {
                            case 0:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Orders_Grid.SelectedItem;
                                    DataRowView selectedDataRow1 = (DataRowView)ListOrdersGrid.SelectedItem;
                                    if (selectedDataRow != null)
                                    {
                                        for (int i = 0; i < BdSet.List_Goods.Count; i++)
                                        {
                                            if (Convert.ToInt32(selectedDataRow.Row.ItemArray[0]) == BdSet.List_Goods.Rows[i].Field<int>("ID_Orders"))
                                            {
                                                ListGoodsAdapter.DeleteQuery(BdSet.List_Goods.Rows[i].Field<int>("ID_Orders"));
                                                LogsAdapter.InsertQuery(UserID, "Удалил товар относящийся к заказу с номером: " + Convert.ToInt32(selectedDataRow.Row.ItemArray[0]), OnlyOneSelectAdapter.ScalarQuery().Value);
                                            }
                                        }
                                        LogsAdapter.InsertQuery(UserID, "Удалил заказ с номером: " + Convert.ToInt32(selectedDataRow.Row.ItemArray[0]), OnlyOneSelectAdapter.ScalarQuery().Value);
                                        LogsAdapter.Fill(BdSet.Users_Logs);
                                        OrdersAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                        OrdersAdapter.Fill(BdSet.Orders);
                                        ListGoodsAdapter.Fill(BdSet.List_Goods);
                                    }
                                    else if (selectedDataRow1 != null)
                                    {
                                        LogsAdapter.InsertQuery(UserID, "Удалил товар относящийся к заказу с номером: " + selectedDataRow1.Row.ItemArray[0].ToString(), OnlyOneSelectAdapter.ScalarQuery().Value);
                                        OnlyOneSelectAdapter.OrderPriceMinus(Convert.ToInt32(selectedDataRow1.Row.ItemArray[0]), Convert.ToDecimal(selectedDataRow1.Row.ItemArray[3]));
                                        ListGoodsAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow1.Row.ItemArray[0]));
                                        ListGoodsAdapter.Fill(BdSet.List_Goods);
                                        OrdersAdapter.Fill(BdSet.Orders);
                                        LogsAdapter.Fill(BdSet.Users_Logs);
                                    }
                                    else if (selectedDataRow1 == null && selectedDataRow == null)
                                    {
                                        MessageBox.Show("Не выбрана запись для удаления", "Предупреждение");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись для удаления", "Предупреждение");
                                    }
                                }
                                break;
                            case 1:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Suppliers_Grid.SelectedItem;
                                    bool OrderHaveupplier = false;
                                    if (selectedDataRow != null)
                                    {
                                        for (int i = 0; i < BdSet.Orders.Count; i++)
                                        {
                                            if (selectedDataRow.Row.ItemArray[0].ToString() == BdSet.Orders.Rows[i].Field<string>("Supplier"))
                                            {
                                                OrderHaveupplier = true;
                                            }
                                        }
                                        if (!OrderHaveupplier)
                                        {
                                            LogsAdapter.InsertQuery(UserID, "Удалил поставщика с наименованием организации: " + selectedDataRow.Row.ItemArray[0].ToString(), OnlyOneSelectAdapter.ScalarQuery().Value);
                                            SuppliersAdapter.DeleteQuery(selectedDataRow.Row.ItemArray[0].ToString());
                                            SuppliersAdapter.Fill(BdSet.Suppliers);
                                            LogsAdapter.Fill(BdSet.Users_Logs);
                                        }
                                        else if (OrderHaveupplier)
                                        {
                                            OrderHaveupplier = false;
                                            MessageBox.Show("Нельзя удалить поставщика, который указан в заказе организации", "Предупреждение");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись для удаления", "Предупреждение");
                                    }
                                }
                                break;
                            case 2:
                                {
                                    DataRowView selectedDataRow = (DataRowView)Goods_Grid.SelectedItem;
                                    bool ListHaveGods = false;
                                    if (selectedDataRow != null)
                                    {
                                        for (int i = 0; i < BdSet.List_Goods.Count; i++)
                                        {
                                            if (selectedDataRow.Row.ItemArray[0].ToString() == BdSet.List_Goods.Rows[i].Field<string>("Goods"))
                                            {
                                                ListHaveGods = true;
                                            }
                                        }
                                        if (!ListHaveGods)
                                        {
                                            LogsAdapter.InsertQuery(UserID, "Удалил товар с наименованием: " + selectedDataRow.Row.ItemArray[0].ToString(), OnlyOneSelectAdapter.ScalarQuery().Value);
                                            LogsAdapter.Fill(BdSet.Users_Logs);
                                            GoodsAdapter.DeleteQuery(selectedDataRow.Row.ItemArray[0].ToString());
                                            GoodsAdapter.Fill(BdSet.Goods);
                                            ListHaveGods = false;
                                        }
                                        else if (ListHaveGods)
                                        {
                                            ListHaveGods = false;
                                            MessageBox.Show("Нельзя удалить товар, который числится в списке товаров к к какому-либо заказу", "Предупреждение при удалении товара");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не выбрана запись для удаления", "Предупреждение");
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (auth == true)
                LogsAdapter.InsertQuery(UserID, "Вышел из системы", OnlyOneSelectAdapter.ScalarQuery().Value);
        }
        //Добавление пользователя (и изменение)
        private void AdderUser_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateUsers == false)
            {
                for (int i = 0; i < BdSet.Workers.Count; i++)
                {
                    bool DoubleLogin = false;
                    int WorkerID = -2;
                    int Checher = -1;
                    string IFI;
                    IFI = "[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname");
                    if (Workers_Combo_Main.Text == IFI)
                    {
                        //WorkerID = BdSet.Tables["Workers"].Rows[i].Field<int>("ID");
                        if (FieldLogin.Text != "" && FieldPassword.Text != "" && Workers_Combo_Main.Text != "")
                        {
                            try
                            {
                                WorkerID = BdSet.Tables["Workers"].Rows[i].Field<int>("ID");
                                Checher = BdSet.Users.Rows.Find(WorkerID).Field<int>("Id_Worker");
                            }
                            catch
                            {
                                Checher = -1;
                            }
                            for (int g = 0; g < ListLogins.Count; g++)
                            {
                                if (ListLogins[g] == FieldLogin.Text)
                                {
                                    DoubleLogin = true;
                                }
                            }
                            if (DoubleLogin == false)
                            {
                                if (Checher != WorkerID)
                                {
                                    try
                                    {
                                        ListLogins.Clear();
                                        ListPasswords.Clear();
                                        UsersAdapter.InsertQuery(WorkerID, FieldLogin.Text, FieldPassword.Text, Workers_Roles_Combo.Text, false);
                                        UsersAdapter.Fill(BdSet.Users);
                                        GetLoginsAndPasswords();
                                        if (CheckYval_Users.IsChecked.Value == true)
                                        {
                                            UsersAdapter.FillBy(BdSet.Users);
                                        }
                                        else
                                        {
                                            UsersAdapter.Fill(BdSet.Users);
                                        }
                                        LogsAdapter.InsertQuery(UserID, "Создал учётную запись сотрудника с номером <" + WorkerID + "> (" + BdSet.Workers.Rows.Find(WorkerID).Field<string>("Fname") + " " + BdSet.Workers.Rows.Find(WorkerID).Field<string>("Lname") + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                        LogsAdapter.Fill(BdSet.Users_Logs);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("К данному сотруднику привязана деактивированная запись", "Предупреждение");
                                        MessageBoxResult result = MessageBox.Show("Если вы хотите активировать старую учётную запись для данного сотрудника, нажмите <Да>, иначе <НЕт>", "Предупреждение при удалении клиента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                        if (result == MessageBoxResult.Yes)
                                        {
                                            try
                                            {
                                                UsersAdapter.UpdateDeact(FieldLogin.Text, FieldPassword.Text, false, Workers_Roles_Combo.Text, WorkerID);
                                                LogsAdapter.InsertQuery(UserID, "Активировал деактивированный аккаунт с номером: " + WorkerID, OnlyOneSelectAdapter.ScalarQuery().Value);
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Что-то пошло не так");
                                            }
                                        }
                                        else if (result == MessageBoxResult.No)
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Для указанного сотрудника уже создана учётная запись!", "Создание учётной записи");
                                }
                            }
                            else
                            {
                                DoubleLogin = false;
                                MessageBox.Show("Такой логин уже занят", "Создание учётной записи");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Проверьте заполнены ли поля логина и пароля и выбран ли сотрудник", "Создание учётной записи");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < BdSet.Workers.Count; i++)
                {
                    bool DoubleLogin = false;
                    int WorkerID = -2;
                    string IFI;
                    IFI = "[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname");
                    if (Workers_Combo_Main.Text == IFI)
                    {
                        WorkerID = BdSet.Tables["Workers"].Rows[i].Field<int>("ID");
                        if (FieldLogin.Text != "" && FieldPassword.Text != "" && Workers_Combo_Main.Text != "")
                        {
                            for (int g = 0; g < ListLogins.Count; g++)
                            {
                                if (ListLogins[g] == FieldLogin.Text && FieldLogin.Text != BdSet.Tables["Users"].Rows.Find(WorkerID).Field<string>("Login"))
                                {
                                    DoubleLogin = true;
                                }
                            }
                            if (DoubleLogin == false)
                            {
                                try
                                {
                                    if (deact == false)
                                    {
                                        ListLogins.Clear();
                                        ListPasswords.Clear();
                                        UsersAdapter.UpdateQuery(FieldLogin.Text, FieldPassword.Text, Workers_Roles_Combo.Text, WorkerID);
                                        UsersAdapter.Fill(BdSet.Users);
                                        GetLoginsAndPasswords();
                                        if (CheckYval_Users.IsChecked.Value == true)
                                        {
                                            UsersAdapter.FillBy(BdSet.Users);
                                        }
                                        else
                                        {
                                            UsersAdapter.Fill(BdSet.Users);
                                        }
                                        MessageBox.Show("Запись успешно изменена!");
                                        Panel_Add_User.Visibility = Visibility.Hidden;
                                        FieldLogin.Text = "";
                                        FieldPassword.Text = "";
                                        Workers_Roles_Combo.SelectedIndex = 0;
                                        Workers_Combo_Main.SelectedIndex = 0;
                                        UpdateUsers = false;
                                        LogsAdapter.InsertQuery(UserID, "Изменил учётную запись сотрудника с номером <" + WorkerID + "> (" + BdSet.Workers.Rows.Find(WorkerID).Field<string>("Fname") + " " + BdSet.Workers.Rows.Find(WorkerID).Field<string>("Lname") + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                        LogsAdapter.Fill(BdSet.Users_Logs);
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Попытка приаязать изменяемую запись к сотруднику , имеющему учётную запись", "Изменение учётной записи");
                                }
                            }
                            else
                            {
                                DoubleLogin = false;
                                MessageBox.Show("Такой логин уже занят", "Изменение учётной записи");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Проверьте заполнены ли поля логина и пароля и выбран ли сотрудник", "Изменение учётной записи");
                        }
                    }
                }
            }

        }

        private void Close_Pannel_Users(object sender, RoutedEventArgs e)
        {
            Panel_Add_User.Visibility = Visibility.Hidden;
            FieldLogin.Text = "";
            FieldPassword.Text = "";
            Workers_Combo_Main.SelectedIndex = 0;
            Workers_Roles_Combo.SelectedIndex = 0;
            if (CheckYval.IsChecked == true)
            {
                WorkersAdapter.FillBy(BdSet.Workers);
            }
            else
            {
                WorkersAdapter.Fill(BdSet.Workers);
            }
        }

        private void UserRoles_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            UserRoles_Grid.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void SelectionChangedTABS(object sender, SelectionChangedEventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case 0:
                    {
                        if (Users_System_Tab.SelectedIndex == 0 && MainTabControl.SelectedIndex == 0)
                        {
                            Delete.Content = "Деактивировать";

                        }
                        else if (Users_System_Tab.SelectedIndex != 0 || MainTabControl.SelectedIndex != 0)
                        {

                            Delete.Content = "Удалить";
                        }
                    }
                    break;
                case 1:
                    {
                        if (Workers_System_Tab.SelectedIndex == 0 && MainTabControl.SelectedIndex == 1)
                        {
                            Delete.Content = "Уволить";

                        }
                        else if (Workers_System_Tab.SelectedIndex != 0 || MainTabControl.SelectedIndex != 1)
                        {
                            Delete.Content = "Удалить";

                        }
                    }
                    break;
                case 2:
                    {
                        Delete.Content = "Удалить";
                    }
                    break;
                case 3:
                    {
                        Delete.Content = "Удалить";
                    }
                    break;
            }


        }

        private void AdderUserRole_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateUsersRoles == false)
            {
                if (FieldNameRole.Text != "")
                {
                    if (System_One.IsChecked == true || System_Two.IsChecked == true || System_Three.IsChecked == true || System_Four.IsChecked == true)
                    {
                        string CheckRole = "";
                        try
                        {
                            CheckRole = BdSet.Tables["Users_Roles"].Rows.Find(FieldNameRole.Text).Field<string>("Role");
                        }
                        catch
                        {
                            CheckRole = "";
                        }
                        if (CheckRole != FieldNameRole.Text)
                        {
                            RolesAdapter.InsertQuery(FieldNameRole.Text, System_One.IsChecked.Value, System_Two.IsChecked.Value, System_Three.IsChecked.Value, System_Four.IsChecked.Value);
                            RolesAdapter.Fill(BdSet.Users_Roles);
                            LogsAdapter.InsertQuery(UserID, "Создал новую роль: " + FieldNameRole.Text + " с набором прав", OnlyOneSelectAdapter.ScalarQuery().Value);
                            LogsAdapter.Fill(BdSet.Users_Logs);
                        }
                        else
                        {
                            MessageBox.Show("Роль с таким наименованием уже существует", "Создание роли пользователей");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нужно выбрать как минимум один из уровней доступа для новой роли", "Создание роли пользователей");
                    }
                }
                else
                {
                    MessageBox.Show("Не указано наименование роли", "Создание роли пользователей");
                }
            }
            else if (UpdateUsersRoles)
            {
                DataRowView selectedRow = (DataRowView)UserRoles_Grid.SelectedItem;
                bool WorkerHasRole = false;
                if (FieldNameRole.Text != "")
                {
                    if (System_One.IsChecked == true || System_Two.IsChecked == true || System_Three.IsChecked == true || System_Four.IsChecked == true)
                    {
                        for (int i = 0; i < BdSet.Users.Count; i++)
                        {
                            // try { }
                            if (SelectedRole == BdSet.Tables["Users"].Rows[i].Field<string>("Role"))
                            {
                                WorkerHasRole = true;
                            }
                        }
                        if (WorkerHasRole != true)
                        {
                            try
                            {
                                RolesAdapter.UpdateQuery(FieldNameRole.Text, System_One.IsChecked.Value, System_Two.IsChecked.Value, System_Three.IsChecked.Value, System_Four.IsChecked.Value, SelectedRole);
                                FieldNameRole.Text = "";
                                System_One.IsChecked = false;
                                System_Two.IsChecked = false;
                                System_Three.IsChecked = false;
                                System_Four.IsChecked = false;
                                RolesAdapter.Fill(BdSet.Users_Roles);
                                LogsAdapter.InsertQuery(UserID, "Изменил роль: " + SelectedRole + " на: " + FieldNameRole.Text + " с набором прав", OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                UpdateUsersRoles = false;
                                Panel_Add_User_Roles.Visibility = Visibility.Hidden;
                            }
                            catch
                            {
                                MessageBox.Show("Уже присутствует роль с данным наименованием", "Предупреждение");
                            }

                        }
                        else if (WorkerHasRole)
                        {
                            MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данную роль? У определённых пользователей системы также будет изменена роль", "Предупреждение при изменении роли", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    RolesAdapter.UpdateQuery(FieldNameRole.Text, System_One.IsChecked.Value, System_Two.IsChecked.Value, System_Three.IsChecked.Value, System_Four.IsChecked.Value, SelectedRole);
                                    Panel_Add_User_Roles.Visibility = Visibility.Hidden;
                                    RolesAdapter.Fill(BdSet.Users_Roles);
                                    if (CheckYval_Users.IsChecked.Value == true)
                                    {
                                        UsersAdapter.FillBy(BdSet.Users);
                                    }
                                    else
                                    {
                                        UsersAdapter.Fill(BdSet.Users);
                                    }
                                    FieldNameRole.Text = "";
                                    System_One.IsChecked = false;
                                    System_Two.IsChecked = false;
                                    System_Three.IsChecked = false;
                                    System_Four.IsChecked = false;
                                    WorkerHasRole = false;
                                    UpdateUsersRoles = false;
                                    LogsAdapter.InsertQuery(UserID, "Изменил роль: " + SelectedRole + " на: " + FieldNameRole.Text + " с набором прав. Изменения затронули некоторые учётные записи", OnlyOneSelectAdapter.ScalarQuery().Value);
                                    LogsAdapter.Fill(BdSet.Users_Logs);
                                    Panel_Add_User_Roles.Visibility = Visibility.Hidden;
                                }
                                catch
                                {
                                    MessageBox.Show("Уже присутствует роль с данным наименованием", "Предупреждение");
                                }

                            }
                            else if (result == MessageBoxResult.No)
                            {
                                WorkerHasRole = false;
                                Panel_Add_User_Roles.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нужно выбрать как минимум один из уровней доступа для новой роли", "Изменение роли");
                    }
                }
                else
                {
                    MessageBox.Show("Не указано наименование роли", "Изменение роли");
                }
            }
        }

        private void UserLog_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            UserLog_Grid.Columns[0].Header = "№";
        }

        private void WorkersGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            WorkersGrid.Columns[0].Header = "№ Сотрудника";
            WorkersGrid.Columns[11].Visibility = Visibility.Collapsed;
            //WorkersGrid.Columns[9].Visibility = Visibility.Collapsed;
        }

        private void Workers_FunctionsGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Workers_FunctionsGrid.Columns[3].Visibility = Visibility.Collapsed;
            Workers_FunctionsGrid.Columns[0].Header = "Наименование должности";
        }

        private void WorkersGraphicGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            WorkersGraphicGrid.Columns[3].Visibility = Visibility.Collapsed;
            WorkersGraphicGrid.Columns[0].Header = "График";
        }
        //Закрытие панели с добавлением (изменением) сотрудников
        private void ClosePanel_Workers_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_Workers.Visibility = Visibility.Hidden;
            FnameWorker.Text = "";
            LnameWorker.Text = "";
            MnameWorker.Text = "";
            SexWorkerCombo.SelectedIndex = 0;
            DateOfBirthWorker.DisplayDate = DateOfBirthWorker.DisplayDateEnd.Value;
            AdressWorker.Text = "";
            PhoneNumberWorker.Text = "";
            WorkerFunctionCombo.SelectedIndex = 0;
        }

        private void DateOfBirthWorker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //DateOfBirthWorker.Text=DateOfBirthWorker.SelectedDate.Value.ToString("yyyy.MM.dd");
        }
        //Чекбокс отображение деактивированных пользователей
        private void CheckYval_Users_Unchecked(object sender, RoutedEventArgs e)
        {
            switch (CheckYval_Users.IsChecked.Value)
            {
                case true:
                    {
                        UsersAdapter.FillBy(BdSet.Users);
                    } break;
                case false:
                    {
                        UsersAdapter.Fill(BdSet.Users);
                    } break;
            }
        }

        private void ClosePanel_Worker_Craphic_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_WorkerFunction_Graphic.Visibility = Visibility.Hidden;
        }

        private void Records_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //UsersGrid.Columns[6].Visibility = Visibility.Collapsed;
            Records_Grid.Columns[0].Header = "№ Записи";
            Records_Grid.Columns[1].Header = "Наименование услуги";
            Records_Grid.Columns[2].Header = "Дата записи";
            Records_Grid.Columns[2].ClipboardContentBinding.StringFormat = "yyyy.MM.dd";
            Records_Grid.Columns[3].Header = "Время записи";
            Records_Grid.Columns[4].Header = "№ Клиента";
            Records_Grid.Columns[5].DisplayIndex = 7;
            for (int i = 0; i < Records_Grid.Columns.Count; i++)
            {
                switch (Records_Grid.Columns[i].Header)
                {
                    case "LnameClient":
                        {
                            Records_Grid.Columns[i].Header = "Фамилия клиента";
                        } break;
                    case "FnameClient":
                        {
                            Records_Grid.Columns[i].Header = "Имя клиента";
                        } break;
                    case "FnameWorker":
                        {
                            Records_Grid.Columns[i].Header = "Имя сотрудника";
                        } break;
                    case "LnameWorker":
                        {
                            Records_Grid.Columns[i].Header = "Фамилия сотрудника";
                        } break;
                    case "CreatedBy_WorkerID":
                        {
                            Records_Grid.Columns[i].Header = "№ Сотрудника записавшего";
                        } break;
                    case "ID_Client":
                        {
                            Records_Grid.Columns[i].Header = "№ Клиента";
                        } break;
                }
            }
        }

        private void Services_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Services_Grid.Columns[4].Visibility = Visibility.Collapsed;
            Services_Grid.Columns[0].Header = "Наименование услуги";
        }

        private void Clients_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Clients_Grid.Columns[0].Header = "№ Клиента";
            Clients_Grid.Columns[8].Visibility = Visibility.Collapsed;
        }
        //Добавление клиента
        private void AdderClient_Click(object sender, RoutedEventArgs e)
        {
            if (FnameClient.Text != "" && LnameClient.Text != "" && DateOfBirthClient.Text != "" && EmailClient.Text != "" && PhoneNumberClient.Text != "")
            {
                if (!UpdateClients)
                {
                    try
                    {
                        ClientsAdapter.InsertQuery(FnameClient.Text, LnameClient.Text, MnameClient.Text, SexClientCombo.Text, DateOfBirthClient.SelectedDate.Value.ToString("yyyy.MM.dd"), PhoneNumberClient.Text, EmailClient.Text);
                        ClientsAdapter.Fill(BdSet.Clients);
                        LogsAdapter.InsertQuery(UserID, "Добавил нового клиента: " + FnameClient.Text + " " + LnameClient + " " + MnameClient.Text, OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                        FillerClients();
                    }
                    catch
                    {
                        MessageBox.Show("Вы пытаетесь добавить клиента с номером телефона, который принадлежит другому клиенту", "Добавление данных о клиенте");
                    }
                }
                else if (UpdateClients)
                {
                    DataRowView selectedDataRow = (DataRowView)Clients_Grid.SelectedItem;
                    try
                    {
                        bool ClientHasRecord = false;

                        for (int i = 0; i < BdSet.Records_To_Services.Count; i++)
                        {
                            if (Convert.ToInt32(selectedDataRow.Row.ItemArray[0]) == BdSet.Records_To_Services.Rows[i].Field<int>("ID_Client"))
                            {
                                ClientHasRecord = true;
                            }
                        }
                        if (!ClientHasRecord)
                        {
                            try
                            {
                                ClientsAdapter.UpdateQuery(FnameClient.Text, LnameClient.Text, MnameClient.Text, SexClientCombo.Text, DateOfBirthClient.SelectedDate.Value.ToString("yyyy.MM.dd"), PhoneNumberClient.Text, EmailClient.Text, Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                ClientsAdapter.Fill(BdSet.Clients);
                                RecordsAdapter.Fill(BdSet.Records_To_Services);
                                UpdateClients = false;
                                LogsAdapter.InsertQuery(UserID, "Изменил данные о клиенте с номером: " + Convert.ToInt32(selectedDataRow.Row.ItemArray[0]), OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                FillerClients();
                                Panel_Add_Сlients.Visibility = Visibility.Hidden;
                            }
                            catch
                            {
                                MessageBox.Show("Уже присутсвует клиент с данным номером телефона", "Предупреждение");
                            }
                        }
                        else if (ClientHasRecord)
                        {
                            MessageBoxResult result = MessageBox.Show("Вы действительно изменить данные данного клиента? Данные записи на процедуры для этого клиента также будет изменена", "Предупреждение при удалении клиента", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    ClientsAdapter.UpdateQuery(FnameClient.Text, LnameClient.Text, MnameClient.Text, SexClientCombo.Text, DateOfBirthClient.SelectedDate.Value.ToString("yyyy.MM.dd"), PhoneNumberClient.Text, EmailClient.Text, Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                                    ClientsAdapter.Fill(BdSet.Clients);
                                    RecordsAdapter.Fill(BdSet.Records_To_Services);
                                    UpdateClients = false;
                                    LogsAdapter.InsertQuery(UserID, "Изменил данные о клиенте с номером: " + SelectedClientID, OnlyOneSelectAdapter.ScalarQuery().Value);
                                    LogsAdapter.Fill(BdSet.Users_Logs);
                                    FillerClients();
                                    Panel_Add_Сlients.Visibility = Visibility.Hidden;
                                    ClientHasRecord = false;
                                }
                                catch
                                {
                                    ClientHasRecord = false;
                                    MessageBox.Show("Уже присутсвует клиент с данным номером телефона", "Предупреждение");
                                }
                            }
                            else if (result == MessageBoxResult.No)
                            {
                                ClientHasRecord = false;
                                Panel_Add_Сlients.Visibility = Visibility.Hidden;
                                UpdateClients = false;
                            }
                        }
                    }


                    catch
                    {
                        //MessageBox.Show("Вы пытаетесь изменить клиента с номером телефона, который принадлежит другому клиенту", "Изменение данных клиента");
                    }
                }
            }
            else
            {
                MessageBox.Show("Проверьте заполнены ли все поля", "Предупреждение");
            }
        }

        private void ClosePanel_Clients_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_Сlients.Visibility = Visibility.Hidden;
        }
        //Добавление записи на процедуры
        private void AdderRecords_Click(object sender, RoutedEventArgs e)
        {
            bool doubledtime = false;
            for (int i = 0; i < BdSet.Records_To_Services.Count; i++)
            {
                if (DateRecord.SelectedDate.Value == BdSet.Records_To_Services.Rows[i].Field<DateTime>("Date_Record") && TimeRecord.Value.ToString() == BdSet.Records_To_Services.Rows[i].Field<TimeSpan>("Time_Record").ToString() && ComboService.Text == BdSet.Records_To_Services.Rows[i].Field<string>("Service_Name"))
                {
                    doubledtime = true;
                }
            }
            if (DateRecord.Text != "" && TimeRecord.Text != "" && ComboService.Text != "" && ComboClients.Text != "" && doubledtime == false)
            {
                int iderclient = -1;
                for (int i = 0; i < BdSet.Clients.Count; i++)
                {
                    string Client;
                    Client = "[" + BdSet.Clients.Rows[i].Field<int>("ID") + "] " + BdSet.Clients.Rows[i].Field<string>("Fname") + " " + BdSet.Clients.Rows[i].Field<string>("Lname");
                    if (Client == ComboClients.Text)
                    {
                        iderclient = BdSet.Clients.Rows[i].Field<int>("ID");
                    }
                }
                if (!UpdateRecords)
                {
                    try
                    {
                        RecordsAdapter.InsertQuery(ComboService.Text, DateRecord.SelectedDate.Value.ToString("yyyy.MM.dd"), TimeRecord.Text, iderclient, UserID);
                        RecordsAdapter.Fill(BdSet.Records_To_Services);
                        LogsAdapter.InsertQuery(UserID, "Записал клиента <" + ComboClients.Text + "> на процедуру: " + ComboService.Text, OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так...", "Добавление записи");
                    }
                }
                else if (UpdateRecords)
                {
                    try
                    {
                        RecordsAdapter.UpdateRecord(ComboService.Text, DateRecord.SelectedDate.Value.ToString("yyyy.MM.dd"), TimeRecord.Text, UpdateRecordIndexClient, UserID, selectedindexRecord);
                        RecordsAdapter.Fill(BdSet.Records_To_Services);
                        LogsAdapter.InsertQuery(UserID, "Изменил данные записи клиента <" + ComboClients.Text + "> на процедуру: " + ComboService.Text, OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                    }
                    catch
                    {

                    }
                    UpdateRecords = false;
                }
            }
            else
            {
                doubledtime = false;
                MessageBox.Show("Возможно не все поля заполнены либо запись на данную дату и время на выбранную процедуру уже имеется", "Предупреждение");
            }
        }

        private void Goods_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Goods_Grid.Columns[0].Header = "Название товара";
            Goods_Grid.Columns[1].Header = "Тип товара";
            Goods_Grid.Columns[2].Header = "Цена за штуку";
            Goods_Grid.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Suppliers_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Suppliers_Grid.Columns[0].Header = "Название организации поставщика";
            Suppliers_Grid.Columns[1].Header = "Адрес организации поставщика";
            Suppliers_Grid.Columns[2].Header = "Номер телефона организации";
            Suppliers_Grid.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void ListOrdersGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            ListOrdersGrid.Columns[0].Header = "№ Заказа";
            ListOrdersGrid.Columns[1].Header = "Товар";
            ListOrdersGrid.Columns[2].Header = "Количество";
            ListOrdersGrid.Columns[3].Header = "Цена";
            //ListOrdersGrid.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void Orders_Grid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Orders_Grid.Columns[0].Header = "№ Заказа";
            Orders_Grid.Columns[1].Header = "Поставщик";
            Orders_Grid.Columns[2].Header = "Цена";
            Orders_Grid.Columns[3].Header = "Номер сотрудника создавшего";
            Orders_Grid.Columns[4].Header = "Имя сотрудника";
            Orders_Grid.Columns[5].Header = "Фамилия сотрудника";
            Orders_Grid.Columns[6].Visibility = Visibility.Collapsed;
        }

        private void Price_Of_Piece_Goods_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
            && (!Price_Of_Piece_Goods.Text.Contains(".")
            && Price_Of_Piece_Goods.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Close_Panel_Order_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_FormingOrder.Visibility = Visibility.Hidden;
        }

        private void NumberOrderCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                decimal price;
                price = Convert.ToDecimal(OnlyOneSelectAdapter.GetPriceGoods(GoodsListCombo.Text));
                int count = Convert.ToInt32(CountGoodsInList.Text);
                PriceOfCountGoodsList.Text = Convert.ToString(count * price);

            }
            catch { }
        }

        private void Close_Panel_List_Goods_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_ListGoods.Visibility = Visibility.Hidden;
        }

        private void CountGoodsInList_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal price;
                price = Convert.ToDecimal(OnlyOneSelectAdapter.GetPriceGoods(GoodsListCombo.Text));
                int count = Convert.ToInt32(CountGoodsInList.Text);
                PriceOfCountGoodsList.Text = Convert.ToString(count * price);

            }
            catch { }
        }

        private void ListOrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Orders_Grid.SelectedIndex = -1;
        }

        private void FillerOrder_Click(object sender, RoutedEventArgs e)
        {
            ListGoodsAdapter.Fill(BdSet.List_Goods);
        }

        private void Orders_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedDataRow = (DataRowView)Orders_Grid.SelectedItem;
                if (selectedDataRow != null)
                {
                    ListGoodsAdapter.FillBy(BdSet.List_Goods, Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                }
                ListOrdersGrid.SelectedIndex = -1;
            }
            catch { }
        }

        private void ComboSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboSearch_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                for (int i = 0; i < BdSet.Users.Count; i++)
                {
                    if (ComboSearch.Text == BdSet.Users.Rows[i].Field<string>("Login"))
                    {
                        id = BdSet.Users.Rows[i].Field<int>("Id_Worker");
                    }
                }
                LogsAdapter.FillByWhere(BdSet.Users_Logs, id);

            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogsAdapter.Fill(BdSet.Users_Logs);
        }

        private void Name_Services_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void Name_Goods_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void Suplier_Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void Login_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void PriceOfCountGoodsList_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Price_Services_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void CountGoodsInList_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                decimal price;
                price = Convert.ToDecimal(OnlyOneSelectAdapter.GetPriceGoods(GoodsListCombo.Text));
                int count = Convert.ToInt32(CountGoodsInList.Text);
                PriceOfCountGoodsList.Text = Convert.ToString(count * price);

            }
            catch { }
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
            && (!Price_Of_Piece_Goods.Text.Contains(".")
            && Price_Of_Piece_Goods.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Adder_List_Goods_Click(object sender, RoutedEventArgs e)
        {
            if (NumberOrderCombo.Text != "" && GoodsListCombo.Text != "" && CountGoodsInList.Text != "")
            {
                if (!UpdateListGoods)
                {
                    ListGoodsAdapter.InsertQuery(Convert.ToInt32(NumberOrderCombo.Text), GoodsListCombo.Text, Convert.ToInt32(CountGoodsInList.Text), Convert.ToDecimal(PriceOfCountGoodsList.Text));
                    ListGoodsAdapter.Fill(BdSet.List_Goods);
                    LogsAdapter.InsertQuery(UserID, "Добавил товар к заказу с номером:" + NumberOrderCombo.Text, OnlyOneSelectAdapter.ScalarQuery().Value);
                    OnlyOneSelectAdapter.OrderPriceAdd(Convert.ToInt32(NumberOrderCombo.Text), Convert.ToDecimal(PriceOfCountGoodsList.Text));
                    OrdersAdapter.Fill(BdSet.Orders);
                    UpdateListGoods = false;
                }
                else if (UpdateListGoods)
                {
                    ListGoodsAdapter.UpdateQuery(Convert.ToInt32(NumberOrderCombo.Text), GoodsListCombo.Text, Convert.ToInt32(CountGoodsInList.Text), Convert.ToDecimal(PriceOfCountGoodsList.Text), SelectedIdOrderListGoods);
                    ListGoodsAdapter.Fill(BdSet.List_Goods);
                    LogsAdapter.InsertQuery(UserID, "Обновил лист товаров к заказам", OnlyOneSelectAdapter.ScalarQuery().Value);
                    if (SelectedIdOrderListGoods == Convert.ToInt32(NumberOrderCombo.Text))
                    {
                        OnlyOneSelectAdapter.OrderUpdateOrderPrice(Convert.ToInt32(NumberOrderCombo.Text), LastPriceList, Convert.ToDecimal(PriceOfCountGoodsList.Text));
                    }
                    else
                    {
                        OnlyOneSelectAdapter.OrderPriceMinus(SelectedIdOrderListGoods, Convert.ToDecimal(PriceOfCountGoodsList.Text));
                        OnlyOneSelectAdapter.OrderPriceAdd(Convert.ToInt32(NumberOrderCombo.Text), Convert.ToDecimal(PriceOfCountGoodsList.Text));
                    }
                    OrdersAdapter.Fill(BdSet.Orders);
                    UpdateListGoods = false;
                    Panel_Add_Goods.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                MessageBox.Show("Не все данные заполнены", "Предупреждение");
            }
        }

        private void Oklad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
            && (!Oklad.Text.Contains(",")
            && Oklad.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Adder_Order_Click(object sender, RoutedEventArgs e)
        {
            if (ComboOrderSupplier.Text != "")
            {
                if (!UpdateOrders)
                {
                    OrdersAdapter.InsertQuery(ComboOrderSupplier.Text, 0, UserID);
                    OrdersAdapter.Fill(BdSet.Orders);
                    LogsAdapter.InsertQuery(UserID, "Добавил новый заказ огранизации: ", OnlyOneSelectAdapter.ScalarQuery().Value);
                    LogsAdapter.Fill(BdSet.Users_Logs);
                }
                else if (UpdateOrders)
                {
                    OrdersAdapter.UpdateQuery(ComboOrderSupplier.Text, SelectedIDOrder);
                    OrdersAdapter.Fill(BdSet.Orders);
                    LogsAdapter.InsertQuery(UserID, "Внёс изменения в заказ огранизации с номером: " + SelectedIDOrder, OnlyOneSelectAdapter.ScalarQuery().Value);
                    LogsAdapter.Fill(BdSet.Users_Logs);
                    UpdateWorkers = false;
                    Panel_Add_FormingOrder.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Close_Panel_Suppliers_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_Suppliers.Visibility = Visibility.Hidden;
        }

        private void Adder_Suppliers_Click(object sender, RoutedEventArgs e)
        {
            if (Suplier_Name.Text != "" && AdressSuplier.Text != "" && Phone_Number_Supplier.Text != "")
            {
                bool OrdersHaveSuppliers = false;
                if (!UpdateSuppliers)
                {
                    try
                    {
                        SuppliersAdapter.InsertQuery(Suplier_Name.Text, AdressSuplier.Text, Phone_Number_Supplier.Text);
                        SuppliersAdapter.Fill(BdSet.Suppliers);
                        LogsAdapter.InsertQuery(UserID, "Добавил новую организацию поставщика: " + Suplier_Name.Text, OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                    }
                    catch
                    {
                        MessageBox.Show("Уже присутсвует организация поставщика с данным наименованием");
                    }
                }
                else if (UpdateSuppliers)
                {
                    if (!OrdersHaveSuppliers)
                    {
                        try
                        {
                            SuppliersAdapter.UpdateQuery(Suplier_Name.Text, AdressSuplier.Text, Phone_Number_Supplier.Text, SelectedSupplier);
                            SuppliersAdapter.Fill(BdSet.Suppliers);
                            LogsAdapter.InsertQuery(UserID, "Изменил данные о организации поставщика с наименованием: " + SelectedSupplier + " текущ.наим (" + Suplier_Name.Text + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                            LogsAdapter.Fill(BdSet.Users_Logs);
                            UpdateSuppliers = false;
                            Panel_Add_Suppliers.Visibility = Visibility.Hidden;
                            OrdersAdapter.Fill(BdSet.Orders);
                        }
                        catch
                        {
                            MessageBox.Show("Уже присутсвует организация поставщика с таким наименованием", "Предупреждение");
                        }
                    }
                    else if (OrdersHaveSuppliers)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данные о организации? Изменения будут пременены к заказам организации", "Предупреждение при изменении поставщика", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                SuppliersAdapter.UpdateQuery(Suplier_Name.Text, AdressSuplier.Text, Phone_Number_Supplier.Text, SelectedSupplier);
                                SuppliersAdapter.Fill(BdSet.Suppliers);
                                LogsAdapter.InsertQuery(UserID, "Изменил данные о организации поставщика с наименованием: " + SelectedSupplier + " текущ.наим (" + Suplier_Name.Text + ")", OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                UpdateSuppliers = false;
                                Panel_Add_Suppliers.Visibility = Visibility.Hidden;
                                OrdersAdapter.Fill(BdSet.Orders);
                                OrdersHaveSuppliers = false;
                            }
                            catch
                            {
                                MessageBox.Show("Уже присутсвует организация поставщика с таким наименованием", "Предупреждение");
                            }
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            OrdersHaveSuppliers = false;
                            Panel_Add_Suppliers.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Предупреждение");
            }

        }

        private void FieldNameRole_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void Close_Panel_Goods_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_Goods.Visibility = Visibility.Hidden;
        }

        private void Adder_Goods_Click(object sender, RoutedEventArgs e)
        {
            if (Name_Goods.Text != "" && TypesGoods.Text != "" && Price_Of_Piece_Goods.Text != "")
            {
                bool ListGoodsHaveGoods = false;
                if (!Update_Goods)
                {
                    try
                    {
                        GoodsAdapter.InsertQuery(Name_Goods.Text, TypesGoods.Text, Convert.ToDecimal(Price_Of_Piece_Goods.Text));
                        GoodsAdapter.Fill(BdSet.Goods);
                        LogsAdapter.InsertQuery(UserID,"Добавил товар: "+Name_Goods.Text,OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                    }
                    catch
                    {
                        MessageBox.Show("Товар с таким наименованием уже присутствует","Добавление товара (продукции)");
                    }
                }
                else if (Update_Goods)
                {
                    for(int i = 0; i < BdSet.List_Goods.Count; i++)
                    {
                        if(SelectedGoods== BdSet.List_Goods[i].Field<string>("Goods"))
                        {
                            ListGoodsHaveGoods = true;
                        }
                    }
                    if (!ListGoodsHaveGoods)
                    {
                        try
                        {
                            GoodsAdapter.UpdateQuery(Name_Goods.Text, TypesGoods.Text, Convert.ToDecimal(Price_Of_Piece_Goods.Text), SelectedGoods);
                            GoodsAdapter.Fill(BdSet.Goods);
                            LogsAdapter.InsertQuery(UserID, "Данные о товаре с наименованием: " + SelectedGoods + " были изменены", OnlyOneSelectAdapter.ScalarQuery().Value);
                            LogsAdapter.Fill(BdSet.Users_Logs);
                            Panel_Add_Goods.Visibility = Visibility.Hidden;
                            Update_Goods = false;
                        }
                        catch
                        {
                            MessageBox.Show("Уже присутсвует товар с данным наименованием","Предупреждение");
                        }
                    }
                    else if (ListGoodsHaveGoods)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данные о выбранном товаре? Данные о товаре, находящемся в списке к заказам будут изменены тоже", "Предупреждение при изменении товара", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                GoodsAdapter.UpdateQuery(Name_Goods.Text,TypesGoods.Text,Convert.ToDecimal(Price_Of_Piece_Goods.Text),SelectedGoods);
                                GoodsAdapter.Fill(BdSet.Goods);
                                LogsAdapter.InsertQuery(UserID, "Данные о товаре с наименованием: " + SelectedGoods + " были изменены", OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                Panel_Add_Goods.Visibility = Visibility.Hidden;
                                Update_Goods = false;
                                ListGoodsHaveGoods = false;
                            }
                            catch
                            {

                                MessageBox.Show("Уже присутсвует товар с данным наименованием", "Предупреждение");
                            }
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            ListGoodsHaveGoods = false;
                            Panel_Add_Goods.Visibility = Visibility.Hidden;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены","Предупреждение");
            }
        }

        private void ClosePanel_Records_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_Records.Visibility = Visibility.Hidden;
        }

        private void ClosePanel_Sevices_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_Services.Visibility = Visibility.Hidden;
        }
        //Добавление услуг
        private void AdderServices_Click(object sender, RoutedEventArgs e)
        {
            if(Name_Services.Text!=""&&Duration_Services.Text!=""&&Description_Service.Text!=""&& Price_Services.Text != "")
            {
                if (!UpdateServices)
                {
                    try
                    {
                        ServicesAdapter.InsertQuery(Name_Services.Text,Duration_Services.Text,Description_Service.Text,Convert.ToDecimal(Price_Services.Text));
                        ServicesAdapter.Fill(BdSet.Services);
                        LogsAdapter.InsertQuery(UserID,"Добавил услугу: "+Name_Services.Text,OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);

                    }
                    catch
                    {
                        MessageBox.Show("Услуга с данным наменованием уже есть","Добавление услуги");
                    }
                }
                else if (UpdateServices)
                {
                    DataRowView selectedDataRow = (DataRowView)Services_Grid.SelectedItem;
                    bool RecordsHasServices = false;
                    for(int i = 0; i < BdSet.Records_To_Services.Count; i++)
                    {
                        if (selectedDataRow.Row.ItemArray[0].ToString() == BdSet.Records_To_Services.Rows[i].Field<string>("Service_Name"))
                        {
                            RecordsHasServices = true;
                        }
                    }
                    if (!RecordsHasServices)
                    {
                        try
                        {
                            LogsAdapter.InsertQuery(UserID, "Изменил список услуг", OnlyOneSelectAdapter.ScalarQuery().Value);
                            ServicesAdapter.UpdateQuery(Name_Services.Text, Duration_Services.Text, Description_Service.Text, Convert.ToDecimal(Price_Services.Text), SelectedService);
                            ServicesAdapter.Fill(BdSet.Services);
                            LogsAdapter.Fill(BdSet.Users_Logs);
                        }
                        catch
                        {
                            MessageBox.Show("Уже есть услуга с данным наименованием","Предупреждение");
                        }
                    }
                    else if (RecordsHasServices)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данную услугу? Запись на процедуры свзанные с этой услугой будут изменены", "Предупреждение при изменении услуги", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                ServicesAdapter.UpdateQuery(Name_Services.Text, Duration_Services.Text, Description_Service.Text, Convert.ToDecimal(Price_Services.Text), SelectedService);
                                RecordsAdapter.Fill(BdSet.Records_To_Services);
                                RecordsHasServices = false;
                                Panel_Add_Services.Visibility = Visibility.Hidden;
                                LogsAdapter.InsertQuery(UserID,"Изменил список услуг. Изменения затронули список записей на процедуры",OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                ServicesAdapter.Fill(BdSet.Services);
                            }
                            catch
                            {
                                RecordsHasServices = false;
                                MessageBox.Show("Уже есть услуга с данным наименованием", "Предупреждение");
                            }
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            RecordsHasServices = false;
                            Panel_Add_Services.Visibility = Visibility.Hidden;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены","Предупреждение");
            }
        }

        private void UsersGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            UsersGrid.Columns[5].Visibility = Visibility.Collapsed;
            UsersGrid.Columns[6].Visibility = Visibility.Collapsed;
            UsersGrid.Columns[7].Visibility = Visibility.Collapsed;
        }
        //Добавление графика работы
        private void AdderWorkerGraphic_Click(object sender, RoutedEventArgs e)
        {
            if (FieldNameWorkerGraphic.Text != "" && TimeStart.Text != "" && TimeEnd.Text != "")
            {
                if (!UpdateGraphic)
                {

                    try
                    {
                        GraphicWorkerAdapter.InsertQuery(FieldNameWorkerGraphic.Text, TimeStart.Text, TimeEnd.Text);
                        GraphicWorkerAdapter.Fill(BdSet.Graphic);
                        LogsAdapter.InsertQuery(UserID, "Обновил список графиков работы", OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                    }
                    catch
                    {
                        MessageBox.Show("График с таким наименованием уже существует", "Добавление графика");
                    }

                }
                else if (UpdateGraphic)
                {
                    bool FunctionsHasGraphic = false;
                    for(int i = 0; i < BdSet.Graphic.Count; i++)
                    {
                        if (SelectedGraphic == BdSet.Graphic.Rows[i].Field<string>("Name"))
                        {
                            FunctionsHasGraphic = true;
                        }
                    }
                    if (!FunctionsHasGraphic)
                    {
                        try
                        {
                            GraphicWorkerAdapter.UpdateQuery(FieldNameWorkerGraphic.Text, TimeStart.Text, TimeEnd.Text,SelectedGraphic);
                            GraphicWorkerAdapter.Fill(BdSet.Graphic);
                            LogsAdapter.InsertQuery(UserID,"Изменил список графиков работы",OnlyOneSelectAdapter.ScalarQuery().Value);
                            LogsAdapter.Fill(BdSet.Users_Logs);
                            UpdateGraphic = false;
                            Panel_Add_WorkerFunction_Graphic.Visibility = Visibility.Hidden;
                        }
                        catch
                        {
                            MessageBox.Show("График с таким наименованием уже существует", "Добавление графика");
                        }
                    }
                    else if (FunctionsHasGraphic)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данный график? У определённых должностей сотрудников также будет измененён график", "Предупреждение при изменении графика", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                GraphicWorkerAdapter.UpdateQuery(FieldNameWorkerGraphic.Text, TimeStart.Text, TimeEnd.Text,SelectedGraphic);
                                GraphicWorkerAdapter.Fill(BdSet.Graphic);
                                WorkersFunctionsAdapter.Fill(BdSet.Workers_Functions);
                                LogsAdapter.InsertQuery(UserID, "Изменил список графиков работы", OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                UpdateGraphic = false;
                                FunctionsHasGraphic = false;
                                Panel_Add_WorkerFunction_Graphic.Visibility = Visibility.Hidden;
                            }
                            catch
                            {
                                MessageBox.Show("График с таким наименованием уже существует", "Добавление графика");
                            }
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            UpdateGraphic = false;
                            FunctionsHasGraphic = false;
                            Panel_Add_WorkerFunction_Graphic.Visibility = Visibility.Hidden;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Проверьте заполнены ди поля", "Предупреждение");
            }
        }

        private void ClosePanel_Worker_Functions_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_WorkerFunction.Visibility = Visibility.Hidden;
        }

        //Чекбокс (отображение уволенных сотрудников)
        private void CheckYval_Unchecked(object sender, RoutedEventArgs e)
        {
            switch (CheckYval.IsChecked.Value)
            {
                case true:
                    {
                        FillStatus = "";
                        WorkersAdapter.FillBy(BdSet.Workers);
                    }
                    break;
                case false:
                    {
                        WorkersAdapter.Fill(BdSet.Workers);
                        FillStatus = "Работающий";
                    }
                    break;
            }
        }
        //Добавление должности
        private void AdderWorkerFunction_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateFunctions == false)
            {
                if (FieldNameWorkerFunction.Text != "" && graphic_Combo.Items.Count != 0 && Oklad.Text != "")
                {
                    try
                    {
                        WorkersFunctionsAdapter.InsertQuery(FieldNameWorkerFunction.Text, graphic_Combo.Text, Convert.ToInt32(Oklad.Text));
                        LogsAdapter.InsertQuery(UserID, "Добавил новую должность: "+ FieldNameWorkerFunction.Text, OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                        WorkersFunctionsAdapter.Fill(BdSet.Workers_Functions);

                    }
                    catch
                    {
                        MessageBox.Show("Уже существует должность с таким наименованием", "Добавление должности");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте заполнены ли поля", "Добавление должности");
                }
            }
            else if (UpdateFunctions)
            {
                bool WorkersHasFunction = false;
                if (FieldNameWorkerFunction.Text != "" && graphic_Combo.Items.Count != 0 && Oklad.Text != "")
                {
                    for(int i = 0; i < BdSet.Workers_Functions.Count; i++)
                    {
                        if (SelectedFunction == BdSet.Workers_Functions.Rows[i].Field<string>("Name_Function"))
                        {
                            WorkersHasFunction = true;
                        }
                    }
                    if (!WorkersHasFunction)
                    {
                        try
                        {
                            WorkersFunctionsAdapter.UpdateQuery(FieldNameWorkerFunction.Text, graphic_Combo.Text, Convert.ToDecimal(Oklad.Text), SelectedFunction);
                            WorkersFunctionsAdapter.Fill(BdSet.Workers_Functions);
                            LogsAdapter.InsertQuery(UserID, "Изменил должность: "+SelectedFunction, OnlyOneSelectAdapter.ScalarQuery().Value);
                            LogsAdapter.Fill(BdSet.Users_Logs);
                            if (FillStatus != "")
                            {
                                WorkersAdapter.FillBy(BdSet.Workers);
                            }
                            else
                            {
                                WorkersAdapter.Fill(BdSet.Workers);
                            }
                            Panel_Add_WorkerFunction.Visibility = Visibility.Hidden;
                            UpdateFunctions = false;
                        }
                        catch
                        {
                            MessageBox.Show("Должность с таким наименованием уже существует", "Изменение должности");
                        }
                    }
                    if (WorkersHasFunction)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данную должность? У определённых пользователей системы также будет изменена роль", "Предупреждение при изменении роли", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                WorkersFunctionsAdapter.UpdateQuery(FieldNameWorkerFunction.Text, graphic_Combo.Text, Convert.ToDecimal(Oklad.Text), SelectedFunction);
                                WorkersFunctionsAdapter.Fill(BdSet.Workers_Functions);
                                LogsAdapter.InsertQuery(UserID, "Изменил должность: " + SelectedFunction + " изменения затронули некоторые записи о сотрудниках", OnlyOneSelectAdapter.ScalarQuery().Value);
                                LogsAdapter.Fill(BdSet.Users_Logs);
                                if (FillStatus != "")
                                {
                                    WorkersAdapter.FillBy(BdSet.Workers);
                                }
                                else
                                {
                                    WorkersAdapter.Fill(BdSet.Workers);
                                }
                                Panel_Add_WorkerFunction.Visibility = Visibility.Hidden;
                                UpdateFunctions = false;
                                WorkersHasFunction = false;
                            }
                            catch
                            {
                                MessageBox.Show("Должность с таким наименованием уже существует", "Изменение должности");
                            }

                        }
                        else if (result == MessageBoxResult.No)
                        {
                            Panel_Add_WorkerFunction.Visibility = Visibility.Hidden;
                            UpdateFunctions = false;
                            WorkersHasFunction = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте заполнены ли все необходимые поля");
                }
            }
        }
        //Добавление сотрудника
        private void AdderWorker_Click(object sender, RoutedEventArgs e)
        {
            if (!UpdateWorkers)
            {
                if (FnameWorker.Text != "" && LnameWorker.Text != ""&& WorkerFunctionCombo.Text != "" && DateOfBirthWorker.Text != "" && AdressWorker.Text != "" && PhoneNumberWorker.Text != "")
                {
                    try
                    {
                        WorkersAdapter.InsertQuery(FnameWorker.Text, LnameWorker.Text, MnameWorker.Text, SexWorkerCombo.Text, DateOfBirthWorker.SelectedDate.Value.ToString("yyyy.MM.dd"), AdressWorker.Text, PhoneNumberWorker.Text, WorkerFunctionCombo.Text, DateTime.Now.ToString("yyyy.MM.dd"), "Работающий");
                        WorkersAdapter.Fill(BdSet.Workers);
                        LogsAdapter.InsertQuery(UserID,"Добавил сотрудника: "+FnameWorker.Text+" "+LnameWorker.Text+" "+MnameWorker.Text,OnlyOneSelectAdapter.ScalarQuery().Value);
                        ListFiWorkers.Clear();
                        for (int i = 0; i < BdSet.Workers.Count; i++)
                        {
                            ListFiWorkers.Add("[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname"));
                        }
                        if (FillStatus != "")
                        {
                            WorkersAdapter.FillBy(BdSet.Workers);
                        }
                        else
                        {
                            WorkersAdapter.Fill(BdSet.Workers);
                        }
                        LogsAdapter.Fill(BdSet.Users_Logs);

                    }
                    catch
                    {
                        MessageBox.Show("Указанный номер принадлежит другому сотруднику", "Добавление сотрудника");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте заполнены ли все поля", "Добавление сотрудника");
                }
            }
            else if (UpdateWorkers)
            {
                DataRowView selectedDataRow = (DataRowView)WorkersGrid.SelectedItem;
                int IderWorker = Convert.ToInt32(selectedDataRow.Row.ItemArray[0]);
                if (FnameWorker.Text != "" && LnameWorker.Text != "" && MnameWorker.Text != "" && WorkerFunctionCombo.Text != "" && DateOfBirthWorker.Text != "" && AdressWorker.Text != "" && PhoneNumberWorker.Text != "")
                {
                    try
                    {
                        OnlyOneSelectAdapter.WorkersEditer(IderWorker, FnameWorker.Text, LnameWorker.Text, MnameWorker.Text, SexWorkerCombo.Text, DateOfBirthWorker.SelectedDate.Value.ToString("yyyy.MM.dd"), AdressWorker.Text, PhoneNumberWorker.Text, WorkerFunctionCombo.Text, DateTime.Now.ToString("yyyy.MM.dd"), "Работающий");
                       // WorkersAdapter.UpdateWorker(FnameWorker.Text, LnameWorker.Text, MnameWorker.Text, SexWorkerCombo.Text, DateOfBirthWorker.SelectedDate.Value.ToString("yyyy.MM.dd"), AdressWorker.Text, PhoneNumberWorker.Text, WorkerFunctionCombo.Text, DateTime.Now.ToString("yyyy.MM.dd"),"Работающий", IderWorker);
                        WorkersAdapter.Fill(BdSet.Workers);
                        LogsAdapter.InsertQuery(UserID, "Изменил данные о сотруднике с номером: "+IderWorker, OnlyOneSelectAdapter.ScalarQuery().Value);
                        LogsAdapter.Fill(BdSet.Users_Logs);
                        UpdateWorkers = false;
                        Panel_Add_Workers.Visibility = Visibility.Hidden;
                        ListFiWorkers.Clear();
                        for (int i = 0; i < BdSet.Workers.Count; i++)
                        {
                            ListFiWorkers.Add("[" + BdSet.Tables["Workers"].Rows[i].Field<int>("ID") + "] " + BdSet.Tables["Workers"].Rows[i].Field<string>("Fname") + " " + BdSet.Tables["Workers"].Rows[i].Field<string>("Lname"));
                        }
                        if (FillStatus != "")
                        {
                            WorkersAdapter.FillBy(BdSet.Workers);
                        }
                        else
                        {
                            WorkersAdapter.Fill(BdSet.Workers);
                        }
                        OrdersAdapter.Fill(BdSet.Orders);
                        RecordsAdapter.Fill(BdSet.Records_To_Services);
                    }
                    catch
                    {
                        MessageBox.Show("Указанный номер телефона принадлежит другому сотруднику", "Добавление сотрудника");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте заполнены ли все поля", "Добавление сотрудника");
                }
            }
        }
        //Закрытие панели с ролями
        private void ClosePanel_Roles_Click(object sender, RoutedEventArgs e)
        {
            Panel_Add_User_Roles.Visibility = Visibility.Hidden;
        }
        private void Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Login.Text=="")
            Login.Text = "Login";
        }
        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Login.Text=="Login")
            Login.Text = "";
        }
        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "Password")
            Password.Text = "";
        }
        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "")
            Password.Text = "Password";
        }
        public void FillerClients()
        {
            ComboClients.Items.Clear();
            for(int i = 0; i < BdSet.Clients.Count; i++)
            {
                ComboClients.Items.Add("["+BdSet.Clients.Rows[i].Field<int>("ID")+"] "+BdSet.Clients.Rows[i].Field<string>("Fname")+" "+ BdSet.Clients.Rows[i].Field<string>("Lname"));
            }
        }
    }
}
