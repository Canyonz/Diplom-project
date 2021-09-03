using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Proga
{
    public class DBConnection
    {
        #region Объявление переменных
        static readonly string connectionString = @"Database = rostelecom4; Data Source = localhost; UserID = root; Password = qwerty; sslmode = none";
        static MySqlConnection msConnect;
        public static MySqlCommand msCommand;
        public static MySqlDataAdapter msDataAdapter;

        static public int NomNaklad;
        static public int NomAbonent;
        static public int NomDogovor;
        static public int NomAct;
        static public string NomAct1;
        static public int NomTypeAct;
        static public int NomNaznach;
        static public int NomCity;

        static public string Doljnost;
        static public string Login;
        static public string NameUsers;
        static public string UserAuthorizationL;
        static public string UserAuthorizationP;
        static public string LoginSave;
        static public string PasswordSave;

        static public DataTable filter = new DataTable();
        static public DataTable filters;
        static public DataTable Equip = new DataTable();
        static public DataTable Typee = new DataTable();
        static public DataTable Equip1 = new DataTable();
        static public DataTable Typee1 = new DataTable();
        static public DataTable NomActReplace = new DataTable();
        static public DataTable serialscore = new DataTable();
        static public DataTable street = new DataTable();

        static public DataTable s_Doljnost = new DataTable();
        static public DataTable s_TypeAct = new DataTable();
        static public DataTable s_stateequip = new DataTable();
        static public DataTable s_naznach = new DataTable();
        static public DataTable s_TypeEquip = new DataTable();
        static public DataTable s_Street = new DataTable();
        static public DataTable s_City = new DataTable();
        static public DataTable s_yslygi = new DataTable();
        static public DataTable s_Reasons = new DataTable();

        static public DataTable t_StatusAD = new DataTable();
        static public DataTable t_Sotryd = new DataTable();
        static public DataTable t_Users = new DataTable();
        static public DataTable t_Abonent = new DataTable();
        static public DataTable t_Postav = new DataTable();
        static public DataTable t_FacialS = new DataTable();
        static public DataTable t_Naklad = new DataTable();
        static public DataTable t_Sklad = new DataTable();
        static public DataTable t_SpecNaklad = new DataTable();
        
        static public DataTable ArhivSE = new DataTable();
        static public DataTable o_Dogovor = new DataTable();
        static public DataTable o_Act = new DataTable();
        static public DataTable o_SpecAct = new DataTable();
        #endregion

        #region Костыли
        /// <summary>
        ///НАХОЖДЕНИЕ КЛЮЧА по названию записи
        /// </summary>
        /// <param name="keyRecord"></param>
        /// <param name="FormRecord"></param>
        /// <param name="ForRecord"></param>
        /// <param name="Record"></param>
        /// <returns></returns>
        static public int keyRecord(string keyRecord, string FormRecord, string ForRecord, string Record)
        {
            msCommand.CommandText = "SELECT " + keyRecord + " From " + FormRecord + " Where " + ForRecord + " = '" + Record + "'";
            Object result = msCommand.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result.ToString());
            }
            else
                return 0;
        }
        /// <summary>
        ///НАХОЖДЕНИЕ названия по ключю записи
        /// </summary>
        /// <param name="keyRecord"></param>
        /// <param name="FormRecord"></param>
        /// <param name="ForRecord"></param>
        /// <param name="Record"></param>
        /// <returns></returns>
        static public string keyValue(string keyRecord, string FormRecord, string ForRecord, string Record)
        {
            msCommand.CommandText = "SELECT " + keyRecord + " From " + FormRecord + " Where " + ForRecord + " = '" + Record + "'";
            Object result = msCommand.ExecuteScalar();
            if (result != null)
            {
                return result.ToString();
            }
            else
                return null;
        }
        /// <summary>
        /// НАХОЖДЕНИЕ даты по названию записи
        /// </summary>
        /// <param name="keyRecord"></param>
        /// <param name="FormRecord"></param>
        /// <param name="ForRecord"></param>
        /// <param name="Record"></param>
        /// <returns></returns>
        static public DateTime dateRecord(string keyRecord, string FormRecord, string ForRecord, string Record)
        {
            msCommand.CommandText = "SELECT " + keyRecord + " From " + FormRecord + " Where " + ForRecord + " = '" + Record + "'";
            Object result = msCommand.ExecuteScalar();
            return Convert.ToDateTime(result.ToString());
        }
        /// <summary>
        /// ВЫВОД ДАННЫХ ДЛЯ отбора
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="From"></param>
        /// <param name="Where"></param>
        static public void ShowFilter(string Name, string From, string Where)
        {
            msCommand.CommandText = @"Select distinct " + Name + " From " + From + " " + Where + "";
            filter.Reset();
            msDataAdapter.Fill(filter);
        }
        /// <summary>
        /// ВЫПОЛНЕНИЕ отбора записей
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="From"></param>
        /// <param name="Where"></param>
        static public void ShowFilters(string Name, string From, string Where)
        {
            filters = new DataTable();
            msCommand.CommandText = @"Select distinct " + Name + " From " + From + " " + Where + "";
            msDataAdapter.Fill(filters);
        }

        /// <summary>
        /// ПОЛУЧЕНИЕ НАЗВАНИЯ ОБОРУДОВАНИЯ ИЗ СВЯЗИ С ТИПОМ ДЛЯ СПЕЦИФИКАЦИИ НАКЛАДНОЙ
        /// </summary>
        /// <param name="type"></param>
        static public void equipFromType(string type)
        {
            try
            {
                msCommand.CommandText = "SELECT t_sklad.equipment From t_sklad,s_typeequip Where t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip =  '" + type + "'";
                Equip.Clear();
                msDataAdapter.Fill(Equip);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ НАЗВАНИЯ ОБОРУДОВАНИЯ ИЗ СВЯЗИ С ТИПОМ ДЛЯ СПЕЦИФИКАЦИИ АКТА
        /// </summary>
        /// <param name="type"></param>
        static public void equipFromType1(string type)
        {
            try
            {
                if (NomTypeAct == 1 || NomTypeAct == 2)
                    msCommand.CommandText = "SELECT t_sklad.equipment From t_sklad,s_typeequip Where t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip =  '" + type + "'";
                else if (NomTypeAct == 3)
                    msCommand.CommandText = "SELECT distinct t_sklad.equipment From t_akt,t_specact,t_sklad,s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_typeact = '2' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + type + "';";
                else if (NomTypeAct == 4)
                    msCommand.CommandText = "SELECT distinct t_sklad.equipment From t_akt,t_specact,t_sklad,s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_typeact = '1' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + type + "';";
                Equip1.Clear();
                msDataAdapter.Fill(Equip1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ ТИПА ОБОРУДОВАНИЯ ИСПОЛЬЗОВАННОГО НА СКЛАДЕ
        /// </summary>
        static public void Types()
        {
            try
            {
                Typee.Clear();
                msCommand.CommandText = "select distinct s_typeequip.typeequip from t_sklad, s_typeequip where t_sklad.id_typeequip = s_typeequip.id_typeequip order by s_typeequip.typeequip";
                msDataAdapter.Fill(Typee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        /// <summary>
        /// ПОЛУЧЕНИЕ ТИПА ОБОРУДОВАНИЯ ИСПОЛЬЗОВАННОГО НА СКЛАДЕ ДЛЯ ВЫБОРА В СПЕЦИФИКАЦИИ АКТОВ
        /// </summary>
        static public void Types1()
        {
            try
            {
                Typee1.Clear();
                if (NomTypeAct == 1 || NomTypeAct == 2)
                    msCommand.CommandText = "select distinct s_typeequip.typeequip from t_sklad, s_typeequip where t_sklad.id_typeequip = s_typeequip.id_typeequip order by s_typeequip.typeequip";
                else if (NomTypeAct == 3)
                    msCommand.CommandText = "select distinct s_typeequip.typeequip from t_akt,t_specact,t_sklad,s_typeequip where t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_typeact = '2' and t_specact.id_skladequip = t_sklad.id_skladequip order by s_typeequip.typeequip";
                else if (NomTypeAct == 4)
                    msCommand.CommandText = "select distinct s_typeequip.typeequip from t_akt,t_specact,t_sklad,s_typeequip where t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_typeact = '1' and t_specact.id_skladequip = t_sklad.id_skladequip order by s_typeequip.typeequip";
                msDataAdapter.Fill(Typee1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ СЕРИЙНОГО НОМЕРА ОБОРУДОВАНИЯ
        /// </summary>
        /// <param name="equip"></param>
        static public void SerialScore(string equip)
        {
            try
            {
                serialscore.Clear();
                if (NomTypeAct == 3)
                    msCommand.CommandText = "SELECT t_specact.serialscore From t_akt,t_specact,t_sklad,s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_typeact = '2' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and concat(s_typeequip.typeequip,' ', t_sklad.equipment) = '" + equip + "'";
                else if (NomTypeAct == 4)
                    msCommand.CommandText = "SELECT t_specact.serialscore From t_akt,t_specact,t_sklad,s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_typeact = '1' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and concat(s_typeequip.typeequip,' ', t_sklad.equipment) = '" + equip + "'";
                msDataAdapter.Fill(serialscore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ ЦВЕТА СТАТУСА ОПРЕДЕЛЕННОГО СТАТУСА
        /// </summary>
        /// <param name="statusad"></param>
        /// <returns></returns>
        static public string colorFromStatusE(string statusad)
        {
            msCommand.CommandText = "SELECT s_statusad.colorstatusad From s_statusad Where s_statusad.statusad = '" + statusad + "'";
            Object result = msCommand.ExecuteScalar();
            return result.ToString();
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ СТАТУСА ОПРЕДЕЛЕННОГО АКТА
        /// </summary>
        /// <param name="id_akt"></param>
        /// <param name="id_statusad"></param>
        static public void editColorAct(int id_akt, int id_statusad)
        {
            msCommand.CommandText = "Update t_akt set id_statusad = '" + id_statusad + "' where id_akt = '" + id_akt + "'";
            msCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// УНИВЕРСАЛЬНЫЙ ЗАПРОС
        /// </summary>
        /// <param name="zapros"></param>
        /// <returns></returns>
        static public bool edit(string zapros)
        {
            msCommand.CommandText = zapros;
            if (msCommand.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// ПРОВЕРКА НА ВЫПОЛНЕНИЕ АКТОВ В ДОГОВОРЕ
        /// </summary>
        /// <param name="nomdogovor"></param>
        /// <param name="id_statusad"></param>
        /// <returns></returns>
        static public bool countZavAct(int nomdogovor, int id_statusad)
        {
            int zav, act;
            msCommand.CommandText = "select count(*) from t_akt,t_dogovor where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_statusad = '" + id_statusad + "' and t_dogovor.id_dogovor = '" + nomdogovor + "'";
            zav = Convert.ToInt32(msCommand.ExecuteScalar());
            msCommand.CommandText = "select count(*) from t_akt,t_dogovor where t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.id_dogovor = '" + nomdogovor + "'";
            act = Convert.ToInt32(msCommand.ExecuteScalar());
            if (zav == act)
                return true;
            else
                return false;
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ ПОСЛЕДНЕЙ ЦЕНЫ НА ОПРЕДЕЛЕННОЕ ОБОРУДОВАНИЕ ИЗ СПЕЦИФИКАЦИИ НАКЛАДНОЙ
        /// </summary>
        /// <param name="id_skladequip"></param>
        /// <returns></returns>
        static public int price(int id_skladequip)
        {
            msCommand.CommandText = "SELECT t_specnakl.price FROM t_nakladnaya, t_specnakl where t_nakladnaya.id_nakladnaya = t_specnakl.id_nakladnaya and id_skladequip = '" + id_skladequip + "' order by datenakl desc;";
            Object result = msCommand.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result.ToString());
            }
            else
                return 0;
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ АКТА НА ЗАМЕНУ ОБОРУДОВАНИЯ
        /// </summary>
        /// <param name="nomTypeAct"></param>
        static public void nomActFromReplace(int nomTypeAct)
        {
            try
            {
                if (nomTypeAct == 1)
                    msCommand.CommandText = "SELECT t_akt.nomact From t_akt,t_dogovor Where t_dogovor.id_dogovor = t_akt.id_dogovor and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_naznach = '2' and t_akt.id_typeact = '3'; ";
                else if (nomTypeAct == 0)
                    msCommand.CommandText = "SELECT t_akt.nomact From t_akt,t_dogovor Where t_dogovor.id_dogovor = t_akt.id_dogovor and t_akt.id_dogovor = '" + NomDogovor + "' and t_akt.id_naznach = '2' and t_akt.id_typeact = '4'; ";
                NomActReplace.Clear();
                msDataAdapter.Fill(NomActReplace);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        #endregion

        #region Подключение к базе
        /// <summary>
        /// ПОДКЛЮЧЕНИЕ К БАЗЕ ДАННЫХ
        /// </summary>
        /// <returns></returns>
        static public bool Connect(int r)
        {
            try
            {
                msConnect = new MySqlConnection(connectionString);
                msConnect.Open();
                msCommand = new MySqlCommand
                {
                    Connection = msConnect
                };
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch (Exception ex)
            {
                if (r == 0)
                MessageBox.Show("Невозможно подлючиться к базе данных:\n" + ex.Message, "Ошибка!");
                return false;
            }
        }
        /// <summary>
        /// ЗАКРЫТИЕ БАЗЫ ДАННЫХ
        /// </summary>
        static public void Close()
        {
            msConnect.Close();
        }
        /// <summary>
        /// АВТОРИЗАЦИЯ В СИСТЕМУ
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static public bool Authorization(string login, string password)
        {
            try
            {
                msCommand.CommandText = "SELECT s_doljnost.key_doljnost From authorization, s_doljnost Where authorization.key_doljnost = s_doljnost.key_doljnost  And authorization.Login = '" + login + "' And authorization.Password = '" + password + "'";
                Object result = msCommand.ExecuteScalar();
                if (result != null)
                {
                    Doljnost = result.ToString();
                    UserAuthorizationL = login;
                    UserAuthorizationP = password;
                    return true;
                }
                else
                {
                    Doljnost = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Doljnost = UserAuthorizationL = UserAuthorizationP = null;
                MessageBox.Show(ex.ToString(), "Ошибка!");
                return false;
            }
        }
        /// <summary>
        /// РЕГИСТРАЦИЯ НОВОГО ПОЛЬЗОВАТЕЛЯ
        /// </summary>
        /// <param name="fiosotryd"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static public bool Autho(string fiosotryd, string adres, string telephone, string login, string password)
        {
            try
            {
                if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
                {
                    msCommand.CommandText = "Insert Into authorization (fiosotryd,key_doljnost,id_ylitca,adres,telephone,Login,Password) Values('" + fiosotryd + "',2,1,'" + adres + "','" + telephone + "','" + login + "','" + password + "');";
                    msCommand.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Данная учетная запись уже существует", "Ошибка");
                return false;
            }
        }

        /// <summary>
        /// ПРОВЕРКА НА СУЩЕСТВОВАНИЕ ПОЛЬЗОВАТЕЛЯ
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static public bool ALogin(string login)
        {
            try
            {
                msCommand.CommandText = "SELECT authorization.Login From authorization Where authorization.Login = '" + login + "'";
                Object result = msCommand.ExecuteScalar();
                if (result != null)
                {
                    Login = result.ToString();
                    return true;
                }
                else
                {
                    Login = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Login = null;
                MessageBox.Show(ex.ToString(), "Ошибка!");
                return false;
            }
        }
        /// <summary>
        /// ПОЛУЧЕНИЕ ПОЛЬЗОВАТЕЛЯ ПО ЛОГИНУ
        /// </summary>
        /// <returns></returns>
        static public bool NameUser()
        {
            try
            {
                msCommand.CommandText = "SELECT authorization.fiosotryd From authorization Where authorization.Login = '" + UserAuthorizationL + "'";
                Object result = msCommand.ExecuteScalar();
                if (result != null)
                {
                    NameUsers = result.ToString();
                    return true;
                }
                else
                {
                    NameUsers = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                NameUsers = null;
                MessageBox.Show(ex.ToString(), "Ошибка!");
                return false;
            }
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ЛОГИНА ИЛИ ПАРОЛЯ ПОЛЬЗОВАТЕЛЕЙ
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="edit"></param>
        /// <returns></returns>
        //РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ АВТОРИЗАЦИЯ
        static public bool EditTableAuthorization(string login, string password, bool edit)
        {
            if (!String.IsNullOrEmpty(password))
            {
                msCommand.CommandText = "Update authorization SET Password = '" + password + "'  WHERE Login = '" + login + "';";
                if (edit)
                {
                    if (msCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Пароль успешно изменен!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Пароль изменить не удалось!");
                        return false;
                    }
                }
                else
                {
                    msCommand.ExecuteNonQuery();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Пароль не может быть пустой!");
                return false;
            }
        }
        /// <summary>
        /// НАХОЖДЕНИЕ ДАННЫХ ПОЛЬЗОВАТЕЛЯ С АВТОСОХРАНЕНИЕМ ЛОГИНА И ПАРОЛЯ ДЛЯ ВХОДА В СИСТЕМУ
        /// </summary>
        static public void SaveLPAuthorizatoin()
        {
            try
            {
                msCommand.CommandText = "SELECT authorization.login From authorization Where authorization.id_sotryd = " + Properties.Settings.Default.saveuser + "";
                if (msCommand.ExecuteScalar() != null)
                {
                    LoginSave = msCommand.ExecuteScalar().ToString();
                    msCommand.CommandText = "SELECT authorization.password From authorization Where authorization.id_sotryd = " + Properties.Settings.Default.saveuser + "";
                    msCommand.ExecuteScalar();
                    PasswordSave = msCommand.ExecuteScalar().ToString();
                }
                else
                {
                    LoginSave = "Логин";
                    PasswordSave = "Пароль";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }

        }
        #endregion

        #region Справочники
        #region S_DOLJNOST
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_DOLJNOST ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableDoljnost()
        {
            msCommand.CommandText = "Select * From s_doljnost order by doljnost";
            s_Doljnost.Clear();
            msDataAdapter.Fill(s_Doljnost);
        }

        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_DOLJNOST 
        /// </summary>
        /// <param name="doljnost"></param>
        /// <returns></returns>
        static public int AddTableDoljnost(string doljnost)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_doljnost where doljnost = '" + doljnost + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_doljnost (doljnost) Values('" + doljnost + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;

            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_DOLJNOST
        /// </summary>
        /// <param name="key_doljnost"></param>
        /// <param name="doljnost"></param>
        /// <returns></returns>
        static public int EditTableDoljnost(int key_doljnost, string doljnost)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_doljnost where doljnost = '" + doljnost + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_doljnost SET doljnost = '" + doljnost + "' WHERE key_doljnost = '" + key_doljnost + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_DOLJNOST
        /// </summary>
        /// <param name="key_doljnost"></param>
        /// <returns></returns>
        static public int DellTableDoljnost(int key_doljnost)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM authorization where key_doljnost = '" + key_doljnost + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from s_doljnost Where key_doljnost = '" + key_doljnost + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_TYPEACT
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_TYPEACT ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableTypeAct()
        {
            msCommand.CommandText = "Select * From s_typeact order by typeact";
            s_TypeAct.Clear();
            msDataAdapter.Fill(s_TypeAct);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_TYPEACT
        /// </summary>
        /// <param name="typeact"></param>
        /// <returns></returns>
        static public int AddTableTypeAct(string typeact)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_typeact where typeact = '" + typeact + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_typeact (typeact) Values('" + typeact + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_TYPEACT
        /// </summary>
        /// <param name="id_typeact"></param>
        /// <param name="typeact"></param>
        /// <returns></returns>
        static public int EditTableTypeAct(int id_typeact, string typeact)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_typeact where typeact = '" + typeact + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_typeact SET typeact = '" + typeact + "' WHERE id_typeact = '" + id_typeact + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_TYPEACT
        /// </summary>
        /// <param name="id_typeact"></param>
        /// <returns></returns>
        static public int DellTableTypeAct(int id_typeact)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_typeact = '" + id_typeact + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                if (id_typeact == 1 || id_typeact == 2 || id_typeact == 3 || id_typeact == 4)
                    msCommand.CommandText = "Update s_typeact SET typeact = null WHERE id_typeact = '" + id_typeact + "';";
                else
                    msCommand.CommandText = "Delete from s_typeact Where id_typeact = '" + id_typeact + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_STATEEQUIPMENT
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_STATEEQUIPMENT ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableStateEquipment()
        {
            msCommand.CommandText = "Select * From s_stateequip order by stateequip";
            s_stateequip.Clear();
            msDataAdapter.Fill(s_stateequip);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_STATEEQUIPMENT
        /// </summary>
        /// <param name="stateequip"></param>
        /// <returns></returns>
        static public int AddTableStateEquipment(string stateequip)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_stateequip where stateequip = '" + stateequip + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_stateequip (stateequip) Values('" + stateequip + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_STATEEQUIPMENT
        /// </summary>
        /// <param name="id_stateequip"></param>
        /// <param name="stateequip"></param>
        /// <returns></returns>
        static public int EditTableStateEquipment(int id_stateequip, string stateequip)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_stateequip where stateequip = '" + stateequip + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_stateequip SET stateequip = '" + stateequip + "' WHERE id_stateequip = '" + id_stateequip + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_STATEEQUIPMENT
        /// </summary>
        /// <param name="id_stateequip"></param>
        /// <returns></returns>
        static public int DellTableStateEquipment(int id_stateequip)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_specact where id_stateequip = '" + id_stateequip + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from s_stateequip Where id_stateequip = '" + id_stateequip + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_YSLYGI
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_YSLYGI ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableYslygi()
        {
            msCommand.CommandText = "Select * From s_yslyg order by yslyga";
            s_yslygi.Clear();
            msDataAdapter.Fill(s_yslygi);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_YSLYGI
        /// </summary>
        /// <param name="yslyga"></param>
        /// <returns></returns>
        static public int AddTableYslygi(string yslyga)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_yslyg where yslyga = '" + yslyga + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_yslyg (yslyga) Values('" + yslyga + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_YSLYGI
        /// </summary>
        /// <param name="id_yslyg"></param>
        /// <param name="yslyga"></param>
        /// <returns></returns>
        static public int EditTableYslygi(int id_yslyg, string yslyga)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_yslyg where yslyga = '" + yslyga + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_yslyg SET yslyga = '" + yslyga + "' WHERE id_yslyg = '" + id_yslyg + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_YSLYGI
        /// </summary>
        /// <param name="id_yslyg"></param>
        /// <returns></returns>
        static public int DellTableYslygi(int id_yslyg)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_dogovor where id_yslyg = '" + id_yslyg + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from s_yslyg Where id_yslyg = '" + id_yslyg + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_NAZNACH
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_NAZNACH ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableNaznach()
        {
            msCommand.CommandText = "Select * From s_naznach order by naznach";
            s_naznach.Clear();
            msDataAdapter.Fill(s_naznach);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_NAZNACH
        /// </summary>
        /// <param name="naznach"></param>
        /// <returns></returns>
        static public int AddTableNaznach(string naznach)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_naznach where naznach = '" + naznach + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_naznach (naznach) Values('" + naznach + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_NAZNACH
        /// </summary>
        /// <param name="id_naznach"></param>
        /// <param name="naznach"></param>
        /// <returns></returns>
        static public int EditTableNaznach(int id_naznach, string naznach)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_naznach where naznach = '" + naznach + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_naznach SET naznach = '" + naznach + "' WHERE id_naznach = '" + id_naznach + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;

        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_NAZNACH
        /// </summary>
        /// <param name="id_naznach"></param>
        /// <returns></returns>
        static public int DellTableNaznach(int id_naznach)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_naznach = '" + id_naznach + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                if (id_naznach == 1 || id_naznach == 2)
                    msCommand.CommandText = "Update s_naznach SET naznach = null WHERE id_naznach = '" + id_naznach + "';";
                else
                    msCommand.CommandText = "Delete from s_naznach Where id_naznach = '" + id_naznach + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_STATUSAD
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_STATUSAD ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableStatusAD()
        {
            msCommand.CommandText = "Select id_statusad, statusad, colorstatusad From s_statusad";
            t_StatusAD.Clear();
            msDataAdapter.Fill(t_StatusAD);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_STATUSAD
        /// </summary>
        /// <param name="statusad"></param>
        /// <param name="colorstatusad"></param>
        /// <returns></returns>
        static public int AddTableStatusAD(string statusad, string colorstatusad)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_statusad where statusad = '" + statusad + "' or colorstatusad = '" + colorstatusad + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_statusad (statusad,colorstatusad) Values('" + statusad + "','" + colorstatusad + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_STATUSAD
        /// </summary>
        /// <param name="id_statusad"></param>
        /// <param name="statusad"></param>
        /// <param name="colorstatusad"></param>
        /// <returns></returns>
        static public int EditTableStatusAD(int id_statusad, string statusad, string colorstatusad)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_statusad where id_statusad != '" + id_statusad + "' and (statusad = '" + statusad + "' or colorstatusad = '" + colorstatusad + "')";//(statusad = '" + statusad + "' or
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_statusad SET statusad = '" + statusad + "', colorstatusad = '" + colorstatusad + "'  WHERE id_statusad = '" + id_statusad + "';";//statusad = '" + statusad + "',
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_STATUSAD
        /// </summary>
        /// <param name="id_statusad"></param>
        /// <returns></returns>
        static public int DellTableStatusAD(int id_statusad)
        {
            List<string> from = new List<string>() { "t_akt", "t_dogovor" };
            int result = 0;
            for (int j = 0; j < from.Count; j++)
            {
                msCommand.CommandText = "SELECT count(*) FROM " + from[j] + " where id_statusad = '" + id_statusad + "'";
                result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
                if (result != 0)
                {
                    switch (from[j])
                    {
                        case "t_akt":
                            return 3;
                        case "t_dogovor":
                            return 4;
                    }
                    break;
                }
            }
            if (id_statusad == 1 || id_statusad == 2 || id_statusad == 3)
                msCommand.CommandText = "Update s_statusad SET statusad = null, colorstatusad = null  WHERE id_statusad = '" + id_statusad + "';";
            else
                msCommand.CommandText = "Delete from s_statusad Where id_statusad = '" + id_statusad + "';";
            if (msCommand.ExecuteNonQuery() > 0)
                return 1;
            else
                return 2;
        }
        #endregion

        #region S_TYPEEQUIP
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_TYPEEQUIP ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableTypeEquip()
        {
            s_TypeEquip.Clear();
            msCommand.CommandText = "Select * From s_typeequip order by typeequip";
            msDataAdapter.Fill(s_TypeEquip);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_TYPEEQUIP
        /// </summary>
        /// <param name="typeequip"></param>
        /// <returns></returns>
        static public int AddTableTypeEquip(string typeequip)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_typeequip where typeequip = '" + typeequip + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_typeequip (typeequip) Values('" + typeequip + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;

            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_TYPEEQUIP
        /// </summary>
        /// <param name="id_typeequip"></param>
        /// <param name="typeequip"></param>
        /// <returns></returns>
        static public int EditTableTypeEquip(int id_typeequip, string typeequip)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_typeequip where typeequip = '" + typeequip + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_typeequip SET typeequip = '" + typeequip + "' WHERE id_typeequip = '" + id_typeequip + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_TYPEEQUIP
        /// </summary>
        /// <param name="id_typeequip"></param>
        /// <returns></returns>
        static public int DellTableTypeEquip(int id_typeequip)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_sklad where id_typeequip = '" + id_typeequip + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from s_typeequip Where id_typeequip = '" + id_typeequip + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_REASONS
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_REASONS ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableReasons()
        {
            s_Reasons.Clear();
            msCommand.CommandText = "Select * From s_reasons order by reasons";
            msDataAdapter.Fill(s_Reasons);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_REASONS
        /// </summary>
        /// <param name="reasons"></param>
        /// <returns></returns>
        static public int AddTableReasons(string reasons)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_reasons where reasons = '" + reasons + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_reasons (reasons) Values('" + reasons + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;

            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_REASONS
        /// </summary>
        /// <param name="id_reasons"></param>
        /// <param name="reasons"></param>
        /// <returns></returns>
        static public int EditTableReasons(int id_reasons, string reasons)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_reasons where reasons = '" + reasons + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_reasons SET reasons = '" + reasons + "' WHERE id_reasons = '" + id_reasons + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_REASONS
        /// </summary>
        /// <param name="id_reasons"></param>
        /// <returns></returns>
        static public int DellTableReasons(int id_reasons)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_specact where id_reasons = '" + id_reasons + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from s_reasons Where id_reasons = '" + id_reasons + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region S_STREET
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_STREET ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        /// <param name="city"></param>
        static public void ShowTableStreet(int city)
        {
            s_Street.Clear();
            msCommand.CommandText = "Select * From s_street where id_gorod = '" + city + "' order by ylitca ";
            msDataAdapter.Fill(s_Street);
        }
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_STREET ИЗ БАЗЫ ДАННЫХ ДЛЯ COMBOBOX
        /// </summary>
        /// <param name="city"></param>
        static public void ShowStreet(string city)
        {
            street.Clear();
            msCommand.CommandText = "Select s_street.id_ylitca,s_street.ylitca From s_street,s_city where s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + city + "' order by ylitca";
            msDataAdapter.Fill(street);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_STREET
        /// </summary>
        /// <param name="ylitca"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        static public int AddTableStreet(string ylitca, int city)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_street where ylitca = '" + ylitca + "' and id_gorod = '" + city + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_street (ylitca,id_gorod) Values('" + ylitca + "','" + city + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_STREET
        /// </summary>
        /// <param name="id_ylitca"></param>
        /// <param name="ylitca"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        static public int EditTableStreet(int id_ylitca, string ylitca, int city)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_street where ylitca = '" + ylitca + "' and id_gorod = '" + city + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_street SET ylitca = '" + ylitca + "' WHERE id_ylitca = '" + id_ylitca + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_STREET
        /// </summary>
        /// <param name="id_ylitca"></param>
        /// <param name="ylitca"></param>
        /// <returns></returns>
        static public int DellTableStreet(int id_ylitca, string ylitca)
        {
            List<string> from = new List<string>() { "t_abonent", "authorization", "t_postavshik" };
            int result = 0;
            for (int j = 0; j < from.Count; j++)
            {
                msCommand.CommandText = "SELECT count(*) FROM " + from[j] + " where id_ylitca = '" + id_ylitca + "'";
                result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
                if (result != 0)
                {
                    switch (from[j])
                    {
                        case "t_abonent":
                            return 3;
                        case "authorization":
                            return 4;
                        case "t_postavshik":
                            return 5;
                    }
                    break;
                }
            }
            msCommand.CommandText = "Delete from s_street Where id_ylitca = '" + id_ylitca + "';";
            if (msCommand.ExecuteNonQuery() > 0)
                return 1;
            else
                return 2;
        }
        #endregion

        #region S_CITY
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ S_CITY ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableCity()
        {
            s_City.Clear();
            msCommand.CommandText = "Select id_gorod,gorod From s_city where id_gorod != 1 order by gorod";
            msDataAdapter.Fill(s_City);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ S_CITY
        /// </summary>
        /// <param name="gorod"></param>
        /// <returns></returns>
        static public int AddTableCity(string gorod)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_city where gorod = '" + gorod + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into s_city (gorod) Values('" + gorod + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ S_CITY
        /// </summary>
        /// <param name="id_gorod"></param>
        /// <param name="gorod"></param>
        /// <returns></returns>
        static public int EditTableCity(int id_gorod, string gorod)
        {
            msCommand.CommandText = "SELECT count(*) FROM s_city where gorod = '" + gorod + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update s_city SET gorod = '" + gorod + "' WHERE id_gorod = '" + id_gorod + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ S_CITY
        /// </summary>
        /// <param name="id_gorod"></param>
        /// <returns></returns>
        static public int DellTableCity(int id_gorod)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM s_street where id_gorod = '" + id_gorod + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from s_city Where id_gorod = '" + id_gorod + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #endregion

        #region Таблицы
        #region SOTRYD
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ SOTRYD ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableSotryd()
        {
            msCommand.CommandText = @"Select authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone,s_city.gorod,s_street.ylitca,authorization.adres
            From authorization,s_street,s_city where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 1 order by fiosotryd";
            t_Sotryd.Clear();
            msDataAdapter.Fill(t_Sotryd);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ SOTRYD
        /// </summary>
        /// <param name="fiosotryd"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        static public int AddTableSotryd(string fiosotryd, int id_ylitca, string adres, string telephone)
        {
            msCommand.CommandText = "SELECT count(*) FROM authorization where fiosotryd = '" + fiosotryd + "' or telephone = '" + telephone + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into authorization (fiosotryd,key_doljnost,id_ylitca,adres,telephone) Values('" + fiosotryd + "',1,'" + id_ylitca + "','" + adres + "','" + telephone + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ SOTRYD
        /// </summary>
        /// <param name="id_sotryd"></param>
        /// <param name="fiosotryd"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        static public int EditTableSotryd(int id_sotryd, string fiosotryd, int id_ylitca, string adres, string telephone)
        {
            msCommand.CommandText = "SELECT count(*) FROM authorization where id_sotryd != '" + id_sotryd + "' and (fiosotryd = '" + fiosotryd + "'  or telephone = '" + telephone + "')";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update authorization SET fiosotryd = '" + fiosotryd + "',key_doljnost = '1',id_ylitca = '" + id_ylitca + "',adres = '" + adres + "',telephone = '" + telephone + "' WHERE id_sotryd = '" + id_sotryd + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ SOTRYD
        /// </summary>
        /// <param name="id_sotryd"></param>
        /// <returns></returns>
        static public int DellTableSotryd(int id_sotryd)
        {
            List<string> from = new List<string>() { "t_dogovor", "t_akt" };
            int result;
            for (int j = 0; j < from.Count; j++)
            {
                msCommand.CommandText = "SELECT count(*) FROM " + from[j] + " where id_sotryd = '" + id_sotryd + "'";
                result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
                if (result != 0)
                {
                    switch (from[j])
                    {
                        case "t_dogovor":
                            return 3;
                        case "t_akt":
                            return 4;
                    }
                    break;
                }
            }
            msCommand.CommandText = "Delete from authorization Where id_sotryd = '" + id_sotryd + "';";
            if (msCommand.ExecuteNonQuery() > 0)
                return 1;
            else
                return 2;
        }
        #endregion
        #region USERS
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ USERS ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableUsers()
        {
            msCommand.CommandText = @"Select authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone, authorization.login, authorization.password,s_city.gorod,s_street.ylitca,authorization.adres From authorization,s_street,s_city where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 2 order by fiosotryd";
            t_Users.Clear();
            msDataAdapter.Fill(t_Users);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ USERS 
        /// </summary>
        /// <param name="fiosotryd"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static public int AddTableUsers(string fiosotryd, int id_ylitca, string adres, string telephone, string login, string password)
        {
            msCommand.CommandText = "SELECT count(*) FROM authorization where fiosotryd = '" + fiosotryd + "' or login = '" + login + "'or telephone = '" + telephone + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert into authorization (fiosotryd,key_doljnost,id_ylitca,adres,telephone,login,password) values('" + fiosotryd + "',2,'" + id_ylitca + "','" + adres + "','" + telephone + "','" + login + "','" + password + "')";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦУ USERS 
        /// </summary>
        /// <param name="id_sotryd"></param>
        /// <param name="fiosotryd"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static public int EditTableUsers(int id_sotryd, string fiosotryd, int id_ylitca, string adres, string telephone, string login, string password)
        {
            msCommand.CommandText = "SELECT count(*) FROM authorization where id_sotryd != '" + id_sotryd + "' and (fiosotryd = '" + fiosotryd + "' or login = '" + login + "'or telephone = '" + telephone + "')";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update authorization SET fiosotryd = '" + fiosotryd + "',key_doljnost = 2,id_ylitca = '" + id_ylitca + "',adres = '" + adres + "',telephone = '" + telephone + "',login = '" + login + "',password = '" + password + "' WHERE id_sotryd = '" + id_sotryd + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        #endregion
        #region ABONENT
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ ABONENT ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableAbonent()
        {
            msCommand.CommandText = @"Select t_abonent.id_abonent,t_abonent.fioabonent,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_abonent.adres) as 'adres1', t_abonent.telephone,s_city.gorod, s_street.ylitca, t_abonent.adres
            From t_abonent,s_street,s_city where t_abonent.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod order by fioabonent";
            t_Abonent.Clear();
            msDataAdapter.Fill(t_Abonent);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ ABONENT
        /// </summary>
        /// <param name="fioabonent"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        static public int AddTableAbonent(string fioabonent, int id_ylitca, string adres, string telephone)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_abonent where fioabonent = '" + fioabonent + "' or telephone = '" + telephone + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_abonent (fioabonent,id_ylitca,adres,telephone) Values('" + fioabonent + "','" + id_ylitca + "','" + adres + "','" + telephone + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ ABONENT
        /// </summary>
        /// <param name="id_abonent"></param>
        /// <param name="fioabonent"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
        static public int EditTableAbonent(int id_abonent, string fioabonent, int id_ylitca, string adres, string telephone)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_abonent where id_abonent != '" + id_abonent + "' and (fioabonent = '" + fioabonent + "' or telephone = '" + telephone + "')";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_abonent SET fioabonent = '" + fioabonent + "',id_ylitca = '" + id_ylitca + "', adres = '" + adres + "',telephone = '" + telephone + "' WHERE id_abonent = '" + id_abonent + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ ABONENT
        /// </summary>
        /// <param name="id_abonent"></param>
        /// <returns></returns>
        static public int DellTableAbonent(int id_abonent)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_facialscore where id_abonent = '" + id_abonent + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_abonent Where id_abonent = '" + id_abonent + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #region POSTAV
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ POSTAV ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTablePostav()
        {
            msCommand.CommandText = @"Select t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres
            From t_postavshik,s_street,s_city
            where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod order by naimpost";
            t_Postav.Clear();
            msDataAdapter.Fill(t_Postav);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ POSTAV 
        /// </summary>
        /// <param name="naimpost"></param>
        /// <param name="INN"></param>
        /// <param name="KPP"></param>
        /// <param name="OGRN"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <returns></returns>
        static public int AddTablePostav(string naimpost, string INN, string KPP, string OGRN, string telephone, string email, int id_ylitca, string adres)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_postavshik where naimpost = '" + naimpost + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_postavshik (naimpost,INN,KPP,OGRN,telephone,email,id_ylitca,adres) Values('" + naimpost + "','" + INN + "','" + KPP + "','" + OGRN + "','" + telephone + "','" + email + "','" + id_ylitca + "','" + adres + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ POSTAV
        /// </summary>
        /// <param name="id_postavshik"></param>
        /// <param name="naimpost"></param>
        /// <param name="INN"></param>
        /// <param name="KPP"></param>
        /// <param name="OGRN"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <returns></returns>
        static public int EditTablePostav(int id_postavshik, string naimpost, string INN, string KPP, string OGRN, string telephone, string email, int id_ylitca, string adres)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_postavshik where id_postavshik != '" + id_postavshik + "' and naimpost = '" + naimpost + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_postavshik SET naimpost = '" + naimpost + "', INN = '" + INN + "',KPP = '" + KPP + "',OGRN = '" + OGRN + "',telephone = '" + telephone + "',email = '" + email + "',id_ylitca = '" + id_ylitca + "',adres = '" + adres + "' WHERE id_postavshik = '" + id_postavshik + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ POSTAV
        /// </summary>
        /// <param name="id_postavshik"></param>
        /// <returns></returns>
        static public int DellTablePostav(int id_postavshik)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_nakladnaya where id_postavshik = '" + id_postavshik + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_postavshik Where id_postavshik = '" + id_postavshik + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #region FACIALS
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ FACIALS ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        /// <param name="id_abonent"></param>
        static public void ShowTableFacialS(int id_abonent)
        {
            msCommand.CommandText = @"Select t_facialscore.id_facialscore, t_facialscore.facialscore
            From t_facialscore
            where t_facialscore.id_abonent = '" + id_abonent + "' order by facialscore";
            t_FacialS.Clear();
            msDataAdapter.Fill(t_FacialS);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ FACIALS
        /// </summary>
        /// <param name="facialscore"></param>
        /// <param name="id_abonent"></param>
        /// <returns></returns>
        static public int AddTableFacialS(string facialscore, int id_abonent)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_facialscore where facialscore = '" + facialscore + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_facialscore (facialscore,id_abonent) Values('" + facialscore + "','" + id_abonent + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ FACIALS
        /// </summary>
        /// <param name="id_facialscore"></param>
        /// <param name="facialscore"></param>
        /// <returns></returns>
        static public int EditTableFacialS(int id_facialscore, string facialscore)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_facialscore where id_facialscore != '" + id_facialscore + "' and facialscore = '" + facialscore + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_facialscore SET facialscore = '" + facialscore + "' WHERE id_facialscore = '" + id_facialscore + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ FACIALS
        /// </summary>
        /// <param name="id_facialscore"></param>
        /// <returns></returns>
        static public int DellTableFacialS(int id_facialscore)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_dogovor where id_facialscore = '" + id_facialscore + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_facialscore Where id_facialscore = '" + id_facialscore + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #region NAKLAD
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ NAKLAD ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableNaklad()
        {
            msCommand.CommandText = @"Select t_nakladnaya.id_nakladnaya, t_nakladnaya.numnaklad,  t_postavshik.naimpost, t_nakladnaya.datenakl
            From t_nakladnaya, t_postavshik
            where t_nakladnaya.id_postavshik = t_postavshik.id_postavshik order by datenakl desc";
            t_Naklad.Clear();
            msDataAdapter.Fill(t_Naklad);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ NAKLAD
        /// </summary>
        /// <param name="numnaklad"></param>
        /// <param name="id_postavshik"></param>
        /// <param name="datenakl"></param>
        /// <returns></returns>
        static public int AddTableNaklad(string numnaklad, int id_postavshik, DateTime datenakl)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_nakladnaya where numnaklad = '" + numnaklad + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_nakladnaya (numnaklad,id_postavshik,datenakl) Values('" + numnaklad + "','" + id_postavshik + "','" + datenakl.ToString("yyyy.MM.dd") + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ NAKLAD
        /// </summary>
        /// <param name="id_nakladnaya"></param>
        /// <param name="numnaklad"></param>
        /// <param name="id_postavshik"></param>
        /// <param name="datenakl"></param>
        /// <returns></returns>
        static public int EditTableNaklad(int id_nakladnaya, string numnaklad, int id_postavshik, DateTime datenakl)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_nakladnaya where id_nakladnaya != '" + id_nakladnaya + "' and numnaklad = '" + numnaklad + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_nakladnaya SET numnaklad = '" + numnaklad + "', id_postavshik = '" + id_postavshik + "', datenakl = '" + datenakl.ToString("yyyy.MM.dd") + "' WHERE id_nakladnaya = '" + id_nakladnaya + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ NAKLAD
        /// </summary>
        /// <param name="id_nakladnaya"></param>
        /// <returns></returns>
        static public int DellTableNaklad(int id_nakladnaya)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_specnakl where id_nakladnaya = '" + id_nakladnaya + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_nakladnaya Where id_nakladnaya = '" + id_nakladnaya + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #region SPECNAKLAD
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ SPECNAKLAD ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        /// <param name="id_nakladnaya"></param>
        static public void ShowTableSpecNaklad(int id_nakladnaya)
        {
            msCommand.CommandText = @"Select t_specnakl.id_specnakl,s_typeequip.typeequip,t_sklad.equipment, concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'type_equipment', t_specnakl.count, t_specnakl.price
            From t_specnakl,t_sklad,s_typeequip
            where t_specnakl.id_nakladnaya = '" + id_nakladnaya + "' and t_specnakl.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip order by concat(s_typeequip.typeequip,' ', t_sklad.equipment)";
            t_SpecNaklad.Clear();
            msDataAdapter.Fill(t_SpecNaklad);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ SPECNAKLAD
        /// </summary>
        /// <param name="id_nakladnaya"></param>
        /// <param name="id_skladequip"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static public int AddTableSpecNaklad(int id_nakladnaya, int id_skladequip, int count, int price)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_specnakl where id_nakladnaya = '" + id_nakladnaya + "' and id_skladequip = '" + id_skladequip + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_specnakl (id_nakladnaya,id_skladequip,count, price) Values('" + id_nakladnaya + "','" + id_skladequip + "','" + count + "','" + price + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ SPECNAKLAD
        /// </summary>
        /// <param name="id_specnakl"></param>
        /// <param name="id_nakladnaya"></param>
        /// <param name="id_skladequip"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        static public int EditTableSpecNaklad(int id_specnakl, int id_nakladnaya, int id_skladequip, int count, int price)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_specnakl where id_specnakl != '" + id_specnakl + "' and id_nakladnaya = '" + id_nakladnaya + "' and id_skladequip = '" + id_skladequip + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_specnakl SET id_nakladnaya = '" + id_nakladnaya + "', id_skladequip = '" + id_skladequip + "', count = '" + count + "', price = '" + price + "' WHERE id_specnakl = '" + id_specnakl + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ SPECNAKLAD
        /// </summary>
        /// <param name="id_specnakl"></param>
        /// <returns></returns>
        static public int DellTableSpecNaklad(int id_specnakl)
        {
                msCommand.CommandText = "Delete from t_specnakl Where id_specnakl = '" + id_specnakl + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
        }
        #endregion
        #region SKLAD
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ SKLAD ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableSklad()
        {
            msCommand.CommandText = @"Select t_sklad.id_skladequip, s_typeequip.typeequip, t_sklad.equipment, t_sklad.count
            From t_sklad, s_typeequip
            where t_sklad.id_typeequip = s_typeequip.id_typeequip order by typeequip";
            t_Sklad.Clear();
            msDataAdapter.Fill(t_Sklad);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ SKLAD 
        /// </summary>
        /// <param name="id_typeequip"></param>
        /// <param name="equipment"></param>
        /// <returns></returns>
        static public int AddTableSklad(int id_typeequip, string equipment)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_sklad where equipment = '" + equipment + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_sklad (id_typeequip,equipment) Values('" + id_typeequip + "','" + equipment + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ SKLAD
        /// </summary>
        /// <param name="id_skladequip"></param>
        /// <param name="id_typeequip"></param>
        /// <param name="equipment"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static public int EditTableSklad(int id_skladequip, int id_typeequip, string equipment, int count)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_sklad where id_skladequip != '" + id_skladequip + "' and equipment = '" + equipment + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_sklad SET  id_typeequip = '" + id_typeequip + "',equipment = '" + equipment + "', count = '" + count + "' WHERE id_skladequip = '" + id_skladequip + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ SKLAD
        /// </summary>
        /// <param name="id_skladequip"></param>
        /// <returns></returns>
        static public int DellTableSklad(int id_skladequip)
        {
            List<string> from = new List<string>() { "t_specact", "t_specnakl" };
            int result;
            for (int j = 0; j < from.Count; j++)
            {
                msCommand.CommandText = "SELECT count(*) FROM " + from[j] + " where id_skladequip = '" + id_skladequip + "'";
                result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
                if (result != 0)
                {
                    switch (from[j])
                    {
                        case "t_specact":
                            return 3;
                        case "t_specnakl":
                            return 4;
                    }
                    break;
                }
            }
            msCommand.CommandText = "Delete from t_sklad Where id_skladequip = '" + id_skladequip + "';";
            if (msCommand.ExecuteNonQuery() > 0)
                return 1;
            else
                return 2;
        }
        #endregion
        #region DOGOVOR
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ DOGOVOR ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        static public void ShowTableDogovor()
        {
            msCommand.CommandText = @"Select t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres
            From t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg
            where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent order by nomdogovor desc";
            o_Dogovor.Clear();
            msDataAdapter.Fill(o_Dogovor);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ DOGOVOR 
        /// </summary>
        /// <param name="nomdogovor"></param>
        /// <param name="id_yslyg"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="id_sotryd"></param>
        /// <param name="id_facialscore"></param>
        /// <param name="id_statusad"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public int AddTableDogovor(string nomdogovor, int id_yslyg, int id_ylitca, string adres, int id_sotryd, int id_facialscore, int id_statusad, DateTime date)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_dogovor where nomdogovor = '" + nomdogovor + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_dogovor (nomdogovor,id_facialscore,id_yslyg,id_ylitca,adres,id_sotryd,id_statusad,date) Values('" + nomdogovor + "','" + id_facialscore + "','" + id_yslyg + "','" + id_ylitca + "','" + adres + "','" + id_sotryd + "','" + id_statusad + "','" + date.ToString("yyyy.MM.dd") + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ DOGOVOR
        /// </summary>
        /// <param name="id_dogovor"></param>
        /// <param name="nomdogovor"></param>
        /// <param name="id_yslyg"></param>
        /// <param name="id_ylitca"></param>
        /// <param name="adres"></param>
        /// <param name="id_facialscore"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public int EditTableDogovor(int id_dogovor, string nomdogovor, int id_yslyg, int id_ylitca, string adres, int id_facialscore, DateTime date)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_dogovor where id_dogovor != '" + id_dogovor + "' and nomdogovor = '" + nomdogovor + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_dogovor SET nomdogovor = '" + nomdogovor + "',id_facialscore = '" + id_facialscore + "',id_yslyg = '" + id_yslyg + "',id_ylitca = '" + id_ylitca + "',adres = '" + adres + "', date = '" + date.ToString("yyyy.MM.dd") + "' WHERE id_dogovor = '" + id_dogovor + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ DOGOVOR
        /// </summary>
        /// <param name="id_dogovor"></param>
        /// <returns></returns>
        static public int DellTableDogovor(int id_dogovor)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_dogovor = '" + id_dogovor + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_dogovor Where id_dogovor = '" + id_dogovor + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #region ACT
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ ACT ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        /// <param name="dogovor"></param>
        static public void ShowTableAct(int dogovor)
        {
            o_Act.Clear();
            msCommand.CommandText = @"Select t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date
            From t_dogovor, t_akt, authorization, s_statusad, s_naznach, s_typeact
            where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd 
            and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + dogovor + "' order by date desc";
            msDataAdapter.Fill(o_Act);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ ACT
        /// </summary>
        /// <param name="nomact"></param>
        /// <param name="id_dogovor"></param>
        /// <param name="id_naznach"></param>
        /// <param name="id_typeact"></param>
        /// <param name="id_sotryd"></param>
        /// <param name="id_statusad"></param>
        /// <param name="arenda"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public int AddTableAct(string nomact, int id_dogovor, int id_naznach, int id_typeact, int id_sotryd, int id_statusad, int arenda, DateTime date)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_dogovor = '" + id_dogovor + "' and nomact = '" + nomact + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Insert Into t_akt (nomact,id_dogovor,id_naznach,id_typeact,id_sotryd,id_statusad,arenda,date) Values('" + nomact + "','" + id_dogovor + "','" + id_naznach + "','" + id_typeact + "','" + id_sotryd + "','" + id_statusad + "','" + arenda + "','" + date.ToString("yyyy.MM.dd") + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ ACT
        /// </summary>
        /// <param name="nomact"></param>
        /// <param name="id_dogovor"></param>
        /// <param name="id_naznach"></param>
        /// <param name="id_typeact"></param>
        /// <param name="id_sotryd"></param>
        /// <param name="id_statusad"></param>
        /// <param name="arenda"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public int AddTableAct1(string nomact, int id_dogovor, int id_naznach, int id_typeact, int id_sotryd, int id_statusad, int arenda, DateTime date)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_dogovor = '" + id_dogovor + "' and nomact = '" + nomact + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 1)
            {
                msCommand.CommandText = "Insert Into t_akt (nomact,id_dogovor,id_naznach,id_typeact,id_sotryd,id_statusad,arenda,date) Values('" + nomact + "','" + id_dogovor + "','" + id_naznach + "','" + id_typeact + "','" + id_sotryd + "','" + id_statusad + "','" + arenda + "','" + date.ToString("yyyy.MM.dd") + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ ACT
        /// </summary>
        /// <param name="id_akt"></param>
        /// <param name="nomact"></param>
        /// <param name="id_dogovor"></param>
        /// <param name="id_naznach"></param>
        /// <param name="id_typeact"></param>
        /// <param name="id_sotryd"></param>
        /// <param name="arenda"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public int EditTableAct(int id_akt, string nomact, int id_dogovor, int id_naznach, int id_typeact, int id_sotryd, int arenda, DateTime date)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_dogovor != '" + id_dogovor + "' and id_dogovor = '" + id_dogovor + "' and nomact = '" + nomact + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update t_akt SET nomact = '" + nomact + "',id_dogovor = '" + id_dogovor + "', id_naznach = '" + id_naznach + "', id_typeact = '" + id_typeact + "',  id_sotryd = '" + id_sotryd + "', arenda = '" + arenda + "', date = '" + date.ToString("yyyy.MM.dd") + "' WHERE id_akt = '" + id_akt + "';";//, id_statusad = '" + id_statusad + "'
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ ACT
        /// </summary>
        /// <param name="id_akt"></param>
        /// <param name="nomact"></param>
        /// <param name="id_dogovor"></param>
        /// <param name="id_naznach"></param>
        /// <param name="id_typeact"></param>
        /// <param name="id_sotryd"></param>
        /// <param name="arenda"></param>
        /// <param name="date"></param>
        /// <returns></returns>

        static public int EditTableAct1(int id_akt, string nomact, int id_dogovor, int id_naznach, int id_typeact, int id_sotryd, int arenda, DateTime date)
        {
            msCommand.CommandText = "SELECT count(*) FROM t_akt where id_dogovor != '" + id_dogovor + "' and id_dogovor = '" + id_dogovor + "' and nomact = '" + nomact + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 1)
            {
                msCommand.CommandText = "Update t_akt SET nomact = '" + nomact + "',id_dogovor = '" + id_dogovor + "', id_naznach = '" + id_naznach + "', id_typeact = '" + id_typeact + "',  id_sotryd = '" + id_sotryd + "', arenda = '" + arenda + "', date = '" + date.ToString("yyyy.MM.dd") + "' WHERE id_akt = '" + id_akt + "';";//, id_statusad = '" + id_statusad + "'
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ ACT
        /// </summary>
        /// <param name="id_akt"></param>
        /// <returns></returns>
        static public int DellTableAct(int id_akt)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM t_specact where id_act = '" + id_akt + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_akt Where id_akt = '" + id_akt + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion
        #region SPECACT
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ SPECACT ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        /// <param name="Act"></param>
        static public void ShowTableSpecAct(int Act)
        {//,t_specact.pricearenda 
            msCommand.CommandText = @"Select t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons
            From t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons
            where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons
            and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + Act + "' order by typeequip";
            o_SpecAct.Clear();
            msDataAdapter.Fill(o_SpecAct);
        }
        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ SPECACT
        /// </summary>
        /// <param name="id_act"></param>
        /// <param name="id_skladequip"></param>
        /// <param name="serialscore"></param>
        /// <param name="id_stateequip"></param>
        /// <param name="price"></param>
        /// <param name="id_reasons"></param>
        /// <returns></returns>
        static public int AddTableSpecAct(int id_act, int id_skladequip, string serialscore, int id_stateequip, int price/*, int pricearenda*/, int id_reasons)
        {
            Object result1 = null;
            int serial = DBConnection.keyRecord("id_specact", "t_specact", "serialscore", serialscore);
            int id_akt = DBConnection.keyRecord("id_akt", "t_akt,t_specact", "t_akt.id_akt = t_specact.id_act and t_specact.id_specact", serial.ToString());
            int prices = DBConnection.keyRecord("price", "t_specact", "serialscore", serialscore);
            if (NomTypeAct == 4)
            {
                msCommand.CommandText = "SELECT t_akt.date From t_akt, t_specact, t_sklad, s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_typeact = '1' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_sklad.id_skladequip  = '" + id_skladequip + "' and t_specact.serialscore = '" + serialscore + "'";
                result1 = msCommand.ExecuteScalar();
                DBConnection.edit("Delete from t_specact Where id_specact = '" + serial + "'");
                DBConnection.edit("update t_akt set stoimost = stoimost - '" + prices + "' where id_akt = '" + id_akt + "'");
            }
            else if (NomTypeAct == 3)
            {
                msCommand.CommandText = "SELECT t_akt.date From t_akt, t_specact, t_sklad, s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_typeact = '2' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_sklad.id_skladequip  = '" + id_skladequip + "' and t_specact.serialscore = '" + serialscore + "'";
                result1 = msCommand.ExecuteScalar();
                DBConnection.edit("Delete from t_specact Where id_specact = '" + serial + "'");
                DBConnection.edit("update t_akt set stoimost = stoimost - '" + prices + "' where id_akt = '" + id_akt + "'");
            }

            msCommand.CommandText = "SELECT count(*) FROM t_specact where serialscore = '" + serialscore + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                if (NomTypeAct == 4 || NomTypeAct == 3)
                    msCommand.CommandText = "Insert Into t_specact (id_act,id_skladequip,serialscore,id_stateequip,price,dateArend,id_reasons) Values('" + id_act + "','" + id_skladequip + "','" + serialscore + "','" + id_stateequip + "','" + price + "','" + Convert.ToDateTime(result1).ToString("yyyy.MM.dd") + "','" + id_reasons + "');";//,'" + pricearenda + "' ,pricearenda
                else
                    msCommand.CommandText = "Insert Into t_specact (id_act,id_skladequip,serialscore,id_stateequip,price,dateArend,id_reasons) Values('" + id_act + "','" + id_skladequip + "','" + serialscore + "','" + id_stateequip + "','" + price + "',null,'" + id_reasons + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                {
                    return 1;
                }
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ SPECACT
        /// </summary>
        /// <param name="id_specact"></param>
        /// <param name="id_act"></param>
        /// <param name="id_skladequip"></param>
        /// <param name="serialscore"></param>
        /// <param name="id_stateequip"></param>
        /// <param name="price"></param>
        /// <param name="id_reasons"></param>
        /// <returns></returns>
        static public int EditTableSpecAct(int id_specact, int id_act, int id_skladequip, string serialscore, int id_stateequip, int price/*, int pricearenda*/, int id_reasons)
        {
            Object result1 = 0;
            if (NomTypeAct == 4)
            {
                msCommand.CommandText = "SELECT t_akt.date From  t_akt, t_specact, t_sklad, s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_typeact = '1' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_sklad.id_skladequip  = '" + id_skladequip + "' and t_specact.serialscore = '" + serialscore + "'";
                result1 = msCommand.ExecuteScalar();
                msCommand.CommandText = "Update t_specact SET id_act = '" + id_act + "', id_skladequip = '" + id_skladequip + "', serialscore = '" + serialscore + "', id_stateequip = '" + id_stateequip + "', price = '" + price + "',  dateArend ='" + result1.ToString() + "', id_reasons ='" + id_reasons + "' WHERE id_specact = '" + id_specact + "';";//pricearenda = '" + pricearenda + "',
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else if (NomTypeAct == 3)
            {
                msCommand.CommandText = "SELECT t_akt.date From  t_akt, t_specact, t_sklad, s_typeequip Where t_specact.id_act = t_akt.id_akt and t_akt.id_typeact = '2' and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_sklad.id_skladequip = '" + id_skladequip + "' and t_specact.serialscore = '" + serialscore + "'";
                result1 = msCommand.ExecuteScalar();
                msCommand.CommandText = "Update t_specact SET id_act = '" + id_act + "', id_skladequip = '" + id_skladequip + "', serialscore = '" + serialscore + "', id_stateequip = '" + id_stateequip + "', price = '" + price + "',  dateArend ='" + result1.ToString() + "', id_reasons ='" + id_reasons + "' WHERE id_specact = '" + id_specact + "';";//pricearenda = '" + pricearenda + "',
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
            {
                msCommand.CommandText = "SELECT count(*) FROM t_specact where id_specact != '" + id_specact + "' and serialscore = '" + serialscore + "'";
                int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
                if (result == 0)
                {
                    msCommand.CommandText = "Update t_specact SET id_act = '" + id_act + "', id_skladequip = '" + id_skladequip + "', serialscore = '" + serialscore + "', id_stateequip = '" + id_stateequip + "', price = '" + price + "',  dateArend ='" + result1.ToString() + "' WHERE id_specact = '" + id_specact + "';";//pricearenda = '" + pricearenda + "',
                    if (msCommand.ExecuteNonQuery() > 0)
                        return 1;
                    else
                        return 2;
                }
                else
                    return 3;
            }
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ SPECACT
        /// </summary>
        /// <param name="id_specact"></param>
        /// <returns></returns>
        static public int DellTableSpecAct(int id_specact)
        {
            int result;
            msCommand.CommandText = "SELECT count(*) FROM arhivse where id_specact = '" + id_specact + "'";
            result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result != 0)
                return 3;
            else
            {
                msCommand.CommandText = "Delete from t_specact Where id_specact = '" + id_specact + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
        }
        #endregion

        #region ArhivSE
        /// <summary>
        /// ВЫВОД ТАБЛИЦЫ ARHIVSE ИЗ БАЗЫ ДАННЫХ
        /// </summary>
        /// <param name="Act"></param>
        static public void ShowTableArhivSE()
        {
            msCommand.CommandText = @"Select arhivse.id_arhivSE,t_dogovor.nomdogovor,t_akt.nomact,concat (s_typeequip.typeequip,' ',t_sklad.equipment) as 'equip',arhivse.serialscore, arhivse.dateSpis From arhivse,t_specact,t_sklad,s_typeequip,t_akt,t_dogovor where arhivse.id_specact = t_specact.id_specact and arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor order by arhivse.dateSpis desc";
            ArhivSE.Clear();
            msDataAdapter.Fill(ArhivSE);
        }

        /// <summary>
        /// ДОБАВЛЕНИЕ ДАННЫХ В ТАБЛИЦУ ARHIVSE
        /// </summary>
        /// <param name="id_act"></param>
        /// <param name="id_skladequip"></param>
        /// <param name="serialscore"></param>
        /// <param name="id_stateequip"></param>
        /// <param name="price"></param>
        /// <param name="id_reasons"></param>
        /// <returns></returns>
        static public int AddTableArhivSE(int id_specact, int id_skladequip, string serialscore, DateTime dateSpis)
        {
            msCommand.CommandText = "SELECT count(*) FROM arhivse where serialscore = '" + serialscore + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {

                msCommand.CommandText = "Insert Into arhivse (id_specact,id_skladequip,serialscore,dateSpis) Values('" + id_specact + "','" + id_skladequip + "','" + serialscore + "','" + dateSpis.ToString("yyyy.MM.dd") + "');";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ SPECACT
        /// </summary>
        /// <param name="id_specact"></param>
        /// <param name="id_act"></param>
        /// <param name="id_skladequip"></param>
        /// <param name="serialscore"></param>
        /// <param name="id_stateequip"></param>
        /// <param name="price"></param>
        /// <param name="id_reasons"></param>
        /// <returns></returns>
        static public int EditTableArhivSE(int id_specact, int id_skladequip, string serialscore, DateTime dateSpis,string serial)
        {
            int id_arhivSE = DBConnection.keyRecord("id_arhivSE", "arhivse", "serialscore", serial);
            msCommand.CommandText = "SELECT count(*) FROM arhivse where id_specact != '" + id_specact + "' and serialscore = '" + serialscore + "'";
            int result = Convert.ToInt32(msCommand.ExecuteScalar().ToString());
            if (result == 0)
            {
                msCommand.CommandText = "Update arhivse SET id_specact = '" + id_specact + "', id_skladequip = '" + id_skladequip + "', serialscore = '" + serialscore + "', dateSpis = '" + dateSpis.ToString("yyyy.MM.dd") + "' WHERE id_arhivSE = '" + id_arhivSE + "';";
                if (msCommand.ExecuteNonQuery() > 0)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }
        /// <summary>
        /// УДАЛЕНИЕ ДАННЫХ ИЗ ТАБЛИЦЫ ARHIVSE
        /// </summary>
        /// <param name="id_arhivSE"></param>
        /// <returns></returns>
        static public int DellTableArhivSE(int id_arhivSE)
        {
            msCommand.CommandText = "Delete from arhivse Where id_arhivSE = '" + id_arhivSE + "';";
            if (msCommand.ExecuteNonQuery() > 0)
                return 1;
            else
                return 2;
        }
        #endregion
        #endregion
    }
}